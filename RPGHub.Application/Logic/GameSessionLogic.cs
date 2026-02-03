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
            _context.GameSession.Add(gameSession);
            _context.SaveChangesAsync();
        }

    }
}
