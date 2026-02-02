using RPGHub.Common.Logic;
using RPGHub.Infrastructure;

namespace RPGHub.Application.Logic
{
    public class UserLogic : IUserLogic
    {
        private SqlContext _context;

        public UserLogic(SqlContext context)
        {
            _context = context;
        }

        public string GetCourseInfo()
        {
            return "Course information retrieved successfully.";
        }


    }
}
