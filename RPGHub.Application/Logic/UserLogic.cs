using Microsoft.EntityFrameworkCore;
using RPGHub.Common;
using RPGHub.Common.Logic;
using RPGHub.Domain;
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

        public async Task <bool> UserExist(string email)
        {
            return await _context.SystemUser.Where(x => x.Email == email).FirstOrDefaultAsync() != null;
        }

        public SystemUser UserCreate(SystemUser user)
        {
            _context.SystemUser.Add(user);
            _context.SaveChanges();

            return user;
        }


    }
}
