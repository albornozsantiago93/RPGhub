using RPGHub.Domain;

namespace RPGHub.Common.Logic
{
    public interface IUserLogic
    {
        public SystemUser UserCreate(SystemUser user);
        public Task<bool> UserExist(string email);

    }
}
