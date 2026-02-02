
using RPGHub.Common.Logic;

namespace RPGHub.Common
{
    public interface ILogicProxy
    {
        public IStuffLogic  StuffLogic { get; }
        public ICourseCfgLogic CourseCfgLogic { get; }
        public ISecurityLogic SecurityLogic { get; }    
    }
}
