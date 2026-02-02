using RPGHub.Domain;

namespace RPGHub.Common.Logic
{
    public interface IUserLogic
    {
        Task<SystemUser> GetUserById(Guid userId);
        public SystemUser UserCreate(SystemUser user);
        public Task<bool> UserExist(string email);

    }
}
