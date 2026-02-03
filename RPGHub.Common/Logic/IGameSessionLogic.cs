using RPGHub.Domain;

namespace RPGHub.Common.Logic
{
    public interface IGameSessionLogic
    {
        public Task CreateGameSession(GameSession gameSession, Guid userId);
    }
}
