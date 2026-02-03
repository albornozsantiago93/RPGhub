using RPGHub.Domain;

namespace RPGHub.Common.Logic
{
    public interface ICharacterLogic
    {
        public bool CharacterCreate(Character character, Guid userId, out string error);
        public bool AddCharacterToUser(Character character, Guid userId, out string error);

    }
}
