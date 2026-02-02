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

        public LogicProxy(ISqlContext context)
        {
            _stuffLogic = new StuffLogic((SqlContext)context);
            _userLogic = new UserLogic((SqlContext)context);
            _securityLogic = new SecurityLogic((SqlContext)context);
            _characterLogic = new CharacterLogic((SqlContext)context);

        }

        public IStuffLogic StuffLogic => _stuffLogic;
        public IUserLogic UserLogic => _userLogic;
        public ISecurityLogic SecurityLogic => _securityLogic;
        public ICharacterLogic CharacterLogic => _characterLogic;


    }
}
