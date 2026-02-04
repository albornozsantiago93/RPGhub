using RPGHub.Common.Logic;
using RPGHub.Domain;
using RPGHub.Infrastructure;
using Microsoft.EntityFrameworkCore;


namespace RPGHub.Application.Logic
{
    public class GameSessionLogic : IGameSessionLogic
    {
        private SqlContext _context;

        public GameSessionLogic(SqlContext context)
        {
            _context = context;
        }

        public async Task CreateGameSession(GameSession gameSession, Guid userId)
        {
            if (gameSession.Id == Guid.Empty)
            {
                gameSession.Id = Guid.NewGuid();
            }

            gameSession.MasterId = userId;

            await _context.GameSession.AddAsync(gameSession);
            await _context.SaveChangesAsync();

            GameSessionParticipant participant = new GameSessionParticipant();

            participant.GameSession = gameSession;
            participant.GameSessionId = gameSession.Id;
            participant.SystemUserId = userId;
            participant.SystemUser = gameSession.Master;
            participant.JoinedAt = DateTime.UtcNow;

            await _context.GameSessionParticipant.AddAsync(participant);
            await _context.SaveChangesAsync();
        }

    }
}
