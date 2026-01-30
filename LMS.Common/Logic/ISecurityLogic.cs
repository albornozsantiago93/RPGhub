using LMS.Domain;

namespace LMS.Common.Logic
{
    public interface ISecurityLogic
    {
        public UserView UserViewsGetByEmail(string email);
        public Task<List<PlatformPermission>> GetPermissionsByUserId(Guid userId);
        public string GetToken(UserView user, List<PlatformPermission> permissions, out int ttl);
    }
}
