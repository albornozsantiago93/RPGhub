
using RPGHub.Common.Logic;

namespace RPGHub.Common
{
    public interface ILogicProxy
    {
        public IStuffLogic  StuffLogic { get; }
        public IUserLogic UserLogic { get; }
        public ISecurityLogic SecurityLogic { get; }
        public ICharacterLogic CharacterLogic { get; }
        public IGameSessionLogic GameSessionLogic { get; }
        public IInvitationLogic InvitationLogic { get; }
    }
}
