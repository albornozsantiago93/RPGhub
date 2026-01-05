using LMS.Application.Logic;
using LMS.Infrastructure;

namespace LMS.Application
{
    public class LogicProxy
    {
        private StuffLogic      _stuffLogic;
        private CourseCfgLogic  _courseCfgLogic;

        public LogicProxy(SqlContext context)
        {
            _stuffLogic = new StuffLogic(context);
            _courseCfgLogic = new CourseCfgLogic(context);
        }

        public StuffLogic StuffLogic { get { return _stuffLogic; } }
        public CourseCfgLogic CourseCfgLogic { get { return _courseCfgLogic; } }

    }
}
