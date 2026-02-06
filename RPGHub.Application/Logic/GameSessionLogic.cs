using RPGHub.Common.Logic;
using RPGHub.Domain;
using RPGHub.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;


namespace RPGHub.Application.Logic
{
    public class GameSessionLogic : IGameSessionLogic
    {
        private SqlContext _context;

        public GameSessionLogic(SqlContext context)
        {
            _context = context;
        }

        public async Task<GameSession> GetGameSessionById(Guid id)
        {
            return await _context.GameSession.FirstOrDefaultAsync(x => x.Id == id);
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

        public async Task AddPlayerToGameSession(Guid gameSessionId, Guid characterId, RoleType role, Guid userId)
        {
            GameSession gameSession = await GetGameSessionById(gameSessionId);
            Character character = await _context.Character.FirstOrDefaultAsync(x => x.Id == characterId && x.SystemUser.Id == userId);

            GameSessionParticipant gameSessionParticipant = new GameSessionParticipant(gameSession, character, role);

            await _context.GameSessionParticipant.AddAsync(gameSessionParticipant);
            await _context.SaveChangesAsync();
        }

        public async Task<GameCfg> GetGameCfgById(int gameCfgId)
        {
            return await _context.GameCfg.FirstOrDefaultAsync(x => x.Id == gameCfgId);
        }
    }
}
