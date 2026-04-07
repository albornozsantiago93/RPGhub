using RPGHub.Domain;

namespace RPGHub.Common.Logic
{
    public interface IInvitationLogic
    {
        public Task<int> InviteUserAsync(Guid user, Guid gameSessionId, Guid inviteUserId);
    }
}
