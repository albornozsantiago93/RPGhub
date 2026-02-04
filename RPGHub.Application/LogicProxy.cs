using RPGHub.Application.Logic;
using RPGHub.Common;
using RPGHub.Common.Logic;
using RPGHub.Infrastructure;

namespace RPGHub.Application
{
    public class LogicProxy : ILogicProxy
    {
        private readonly IStuffLogic _stuffLogic;
        private readonly IUserLogic _userLogic;
        private readonly ISecurityLogic _securityLogic;
        private readonly ICharacterLogic _characterLogic;
        private readonly IGameSessionLogic _gameSessionLogic;
        private readonly IInvitationLogic _invitationLogic;

        public LogicProxy(ISqlContext context)
        {
            _stuffLogic = new StuffLogic((SqlContext)context);
            _userLogic = new UserLogic((SqlContext)context);
            _securityLogic = new SecurityLogic((SqlContext)context);
            _characterLogic = new CharacterLogic((SqlContext)context);
            _gameSessionLogic = new GameSessionLogic((SqlContext)context);
            _invitationLogic = new InvitationLogic((SqlContext)context);
        }

        public IStuffLogic StuffLogic => _stuffLogic;
        public IUserLogic UserLogic => _userLogic;
        public ISecurityLogic SecurityLogic => _securityLogic;
        public ICharacterLogic CharacterLogic => _characterLogic;
        public IGameSessionLogic GameSessionLogic => _gameSessionLogic;
        public IInvitationLogic InvitationLogic => _invitationLogic;


    }
}
