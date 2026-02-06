using Microsoft.EntityFrameworkCore;
using RPGHub.Common;
using RPGHub.Common.Logic;
using RPGHub.Domain;
using RPGHub.Infrastructure;

namespace RPGHub.Application.Logic
{
    public class CharacterLogic : ICharacterLogic
    {
        private SqlContext _context;

        public CharacterLogic(SqlContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Creates a new character for the specified user.
        /// </summary>
        /// <remarks>This method validates that the character's name is unique for the specified user,
        /// ignoring case and whitespace. If the character already exists or if any validation fails, the method returns
        /// <see langword="false"/> and sets the <paramref name="error"/> parameter to an appropriate error
        /// message.</remarks>
        /// <param name="character">The character to be created. Cannot be <see langword="null"/>.</param>
        /// <param name="userId">The unique identifier of the user who owns the character. Must not be <see cref="Guid.Empty"/>.</param>
        /// <param name="error">When this method returns, contains a message describing the result of the operation. If the operation fails,
        /// this parameter contains an error message; otherwise, it contains a success message.</param>
        /// <returns><see langword="true"/> if the character was successfully created; otherwise, <see langword="false"/>.</returns>
        public bool CharacterCreate(Character character, Guid userId, out string error)
        {
            error = null;

            if (character == null)
            {
                error = "El personaje no puede ser nulo.";
                return false;
            }

            if (userId == Guid.Empty)
            {
                error = "El ID de usuario no es válido.";
                return false;
            }

            // Validación directa en la base de datos, ignorando mayúsculas/minúsculas y espacios
            bool exists = _context.Character
                .Any(c => c.SystemUser.Id == userId &&
                          c.Name.Trim().ToLower() == character.Name.Trim().ToLower());

            if (exists)
            {
                error = "Ya existe un personaje con ese nombre para este usuario.";
                return false;
            }

            _context.Character.Add(character);

            try
            {
                _context.SaveChanges();
                error = "Personaje creado correctamente.";
                return true;
            }
            catch (Exception ex)
            {
                error = $"Error al guardar el personaje: {ex.Message}";
                return false;
            }
        }


        /// <summary>
        /// Adds a character to the specified user.
        /// </summary>
        /// <remarks>This method checks if a character with the same name already exists for the specified
        /// user. If a duplicate is found, the operation fails and an appropriate error message is returned. The method
        /// also handles database exceptions and returns an error message if the operation cannot be
        /// completed.</remarks>
        /// <param name="character">The character to add. Cannot be <see langword="null"/>.</param>
        /// <param name="userId">The unique identifier of the user to whom the character will be added.</param>
        /// <param name="error">When the method returns, contains an error message if the operation fails; otherwise, contains a success
        /// message. This parameter is passed uninitialized.</param>
        /// <returns><see langword="true"/> if the character was successfully added to the user; otherwise, <see
        /// langword="false"/>.</returns>
        public bool AddCharacterToUser(Character character, Guid userId, out string error)
        {
            error = null;

            if (character == null)
            {
                error = "El personaje no puede ser nulo.";
                return false;
            }

            var user = _context.SystemUser.Include(x => x.Characters).FirstOrDefault(x => x.Id == userId);

            bool exists = _context.Character.Any(c => c.SystemUser.Id == userId && c.Name.Trim().ToLower() == character.Name.Trim().ToLower());

            if (exists)
            {
                error = "Ya existe un personaje con ese nombre para este usuario.";
                return false;
            }

            try
            {
                user.Characters.Add(character);
                error = "Character successfully added to user.";
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                error = $"Error al guardar el personaje: {ex.Message}";
                return false;
            }
        }

        public async Task<Character> GetCharacterById(Guid characterId)
        {
            return await _context.Character.Where( x => x.Id == characterId).FirstOrDefaultAsync();    
        }

        public async Task<List<Character>> GetCharacters()
        {
            return await _context.Character.OrderByDescending(x=> x.Id).ToListAsync();
        }


    }
}
