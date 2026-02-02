using RPGHub.Domain;

namespace RPGHub.Common.Logic
{
    public interface ISecurityLogic
    {
        public Task<UserView> UserViewsGetByEmail(string email);
        public Task<List<PlatformPermission>> GetPermissionsByUserId(Guid userId);
        public string GetToken(UserView user, List<PlatformPermission> permissions, out int ttl);
    }
}
