using AutoMapper.Configuration;
using RPGHub.Domain;

namespace RPGHub.Common
{
    public class GameSessionMapper : BaseMapper
    {
        public GameSessionMapper()
        {

        }
        public GameSessionMapper(ILogicProxy logic)
        {
            Logic = logic;
        }

        protected override MapperConfigurationExpression GetMapperConfigurationExpression(string language)
        {
            MapperConfigurationExpression config = new MapperConfigurationExpression();

            //config.CreateMap<Country, CountryModel>();

            return config;
        }
        public async Task<GameSession> MapCreateGameSessionModelToGameSession(CreateGameSessionModel model)
        {
            GameSession gameSession = new GameSession(model.Title, model.Description, model.ScheduleDate, GameSessionStatus.Pending, model.GameCfgId);
            gameSession.GameCfg = await Logic.GameSessionLogic.GetGameCfgById(model.GameCfgId);
            gameSession.Master = await Logic.UserLogic.GetUserById(model.MasterId);
            gameSession.MasterId = model.MasterId;

            return gameSession;
        }

    }
}
