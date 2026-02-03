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
        public bool CharacterCreate(Character character, Guid userId, out string error)
        {
            SystemUser user = _context.SystemUser.Where(x => x.Id == userId).FirstOrDefault();

            // Validación: ¿ya existe un personaje con el mismo nombre para este usuario?
            if (user.Characters.Any(c => c.Name == character.Name))
            {
                error = "Ya existe un personaje con ese nombre para este usuario.";
                return false;
            }

            character.OwnerId = userId;
            _context.Character.Add(character);

            try
            {
                _context.SaveChanges();
                error = null;
                return true;
            }
            catch (Exception ex)
            {
                error = $"Error al guardar el personaje: {ex.Message}";
                return false;
            }
        }

        // Si quieres mantener el método separado:
        public bool AddCharacterToUser(Character character, Guid userId, out string error)
        {
            error = null;

            if (character == null)
            {
                error = "El personaje no puede ser nulo.";
                return false;
            }

            var user = _context.SystemUser.Include(x => x.Characters).FirstOrDefault(x => x.Id == userId);

            // Validación: ¿ya existe un personaje con el mismo nombre para este usuario?
            if (user.Characters.Any(c => c.Name == character.Name))
            {
                error = "Ya existe un personaje con ese nombre para este usuario.";
                return false;
            }

            user.Characters.Add(character);

            try
            {
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                error = $"Error al guardar el personaje: {ex.Message}";
                return false;
            }
        }
    }
}
