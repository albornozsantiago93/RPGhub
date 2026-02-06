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

            config.CreateMap<Character, GetCharacterModel>()
                .ForMember(dest => dest.Class, opt => opt.MapFrom(src => src.Class!= null ? src.Class.ToString(): null))
                .ForMember(dest => dest.Race, opt => opt.MapFrom(src => src.Race != null ? src.Race.ToString() : null))
                .ForMember(dest => dest.OwnerId, opt => opt.MapFrom(src => src.SystemUser.Id)); 

            return config;
        }
        public async Task<Character> MapCharacterModelToEntity(CreateCharacterModel model, Guid currentUserId)
        {
            Character character = new Character(model.Name, model.Picture, (Class)model.Class, (Race)model.Race);
            character.SystemUser = await Logic.UserLogic.GetUserById(currentUserId);

            return character;
        }
    }
}
