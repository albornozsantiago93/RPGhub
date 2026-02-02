using Microsoft.EntityFrameworkCore;
using RPGHub.Common;
using RPGHub.Common.Logic;
using RPGHub.Domain;
using RPGHub.Infrastructure;

namespace RPGHub.Application.Logic
{
    public class CharacterLogic : ICharacterLogic
    {
        private SqlContext _context;

        public CharacterLogic(SqlContext context)
        {
            _context = context;
        }

        //public async Task <bool> UserExist(string email)
        //{
        //    return await _context.SystemUser.Where(x => x.Email == email).FirstOrDefaultAsync() != null;
        //}

        //public SystemUser UserCreate(SystemUser user)
        //{
        //    _context.SystemUser.Add(user);
        //    _context.SaveChanges();

        //    return user;
        //}

        //public Task<SystemUser> GetUserById(Guid userId)
        //{
        //    return _context.SystemUser.Where(x => x.Id == userId).FirstOrDefaultAsync();
        //}



    }
}
