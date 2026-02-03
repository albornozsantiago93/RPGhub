using AutoMapper.Configuration;
using RPGHub.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGHub.Common
{
    public class CharacterMapper : BaseMapper
    {
        public CharacterMapper()
        {

        }
        public CharacterMapper(ILogicProxy logic)
        {
            Logic = logic;
        }


        protected override MapperConfigurationExpression GetMapperConfigurationExpression(string language)
        {
            MapperConfigurationExpression config = new MapperConfigurationExpression();

            //config.CreateMap<Country, CountryModel>();

            return config;
        }
        public async Task<Character> MapCharacterModelToEntity(CreateCharacterModel model, string currentLanguage)
        {
            Character character = new Character(model.Name, model.Picture, (Class)model.Class, (Race)model.Race);
            character.Level = 1;

            return character;
        }
    }
}
