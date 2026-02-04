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

            await _context.GameSession.AddAsync(gameSession);
            await _context.SaveChangesAsync();
        }

    }
}
