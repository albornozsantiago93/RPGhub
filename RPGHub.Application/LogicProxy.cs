using RPGHub.Application.Logic;
using RPGHub.Common;
using RPGHub.Common.Logic;
using RPGHub.Infrastructure;

namespace RPGHub.Application
{
    public class LogicProxy : ILogicProxy
    {
        private readonly IStuffLogic _stuffLogic;
        private readonly ICourseCfgLogic _courseCfgLogic;
        private readonly ISecurityLogic _securityLogic;

        public LogicProxy(ISqlContext context)
        {
            _stuffLogic = new StuffLogic((SqlContext)context);
            _courseCfgLogic = new CourseCfgLogic((SqlContext)context);
            _securityLogic = new SecurityLogic((SqlContext)context);

        }

        public IStuffLogic StuffLogic => _stuffLogic;
        public ICourseCfgLogic CourseCfgLogic => _courseCfgLogic;
        public ISecurityLogic SecurityLogic => _securityLogic;

    }
}
