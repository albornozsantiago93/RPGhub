using AutoMapper.Configuration;
using RPGHub.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            GameSession gameSession = new GameSession
            {
                Id = Guid.NewGuid(),
                Title = model.Title,
                Description = model.Description,
                ScheduledDate = DateTime.UtcNow,
                Status = GameStatus.Active
            };

            return gameSession;
        }

    }
}
