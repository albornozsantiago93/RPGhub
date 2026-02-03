using RPGHub.Domain;

namespace RPGHub.Common.Logic
{
    public interface ICharacterLogic
    {
        public bool CharacterCreate(Character character, Guid userId, out string error);
        public bool AddCharacterToUser(Character character, Guid userId, out string error);
        public Task<Character> GetCharacterById(Guid characterId);
        public Task<List<Character>> GetCharacters();
    }
}
