using RPGHub.Domain;

namespace RPGHub.Common.Logic
{
    public interface IGameSessionLogic
    {
        public Task AddPlayerToGameSession(Guid gameSessionId, Guid characterId,RoleType role, Guid value);
        public Task CreateGameSession(GameSession gameSession, Guid userId);
        public Task<GameCfg> GetGameCfgById(int gameCfgId);
    }
}
