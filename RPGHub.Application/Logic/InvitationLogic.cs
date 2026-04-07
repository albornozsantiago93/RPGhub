using Microsoft.EntityFrameworkCore;
using RPGHub.Common;
using RPGHub.Common.Logic;
using RPGHub.Domain;
using RPGHub.Infrastructure;

namespace RPGHub.Application.Logic
{
    public class InvitationLogic : IInvitationLogic
    {
        private SqlContext _context;

        public InvitationLogic(SqlContext context)
        {
            _context = context;
        }

        public async Task<int> InviteUserAsync(Guid user, Guid gameSessionId, Guid inviteUserId)
        {
            GameSession gameSession = await _context.GameSession.FirstOrDefaultAsync(x => x.Id == gameSessionId);
            if(gameSession == null) throw new Exception("Game session not found");


            var alreadyParticipant = await _context.GameSessionParticipant.AnyAsync
                (x => x.GameSessionId == gameSessionId && x.UserId == inviteUserId);
            
            if (alreadyParticipant) throw new Exception("El usuario ya es participante.");

            var alreadyInvited = await _context.Invitation.AnyAsync
                (x => x.GameSessionId == gameSessionId && x.InvitedUserId == inviteUserId && x.Status == InvitationStatus.Pending);
            
            if (alreadyInvited) throw new Exception("El usuario ya tiene una invitación pendiente.");

            var invitation = new Invitation
            {
                GameSessionId = gameSessionId,
                InvitedUserId = inviteUserId,
                Status = InvitationStatus.Pending,
                SentDate = DateTime.UtcNow
            };

            _context.Invitation.Add(invitation);
            await _context.SaveChangesAsync();
            return invitation.Id;

        }

    }
}
