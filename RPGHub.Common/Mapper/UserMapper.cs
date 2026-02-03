using AutoMapper.Configuration;
using RPGHub.Domain;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGHub.Common
{
    public class UserMapper : BaseMapper
    {
        public UserMapper()
        {

        }
        public UserMapper(ILogicProxy logic)
        {
            Logic = logic;
        }


        protected override MapperConfigurationExpression GetMapperConfigurationExpression(string language)
        {
            MapperConfigurationExpression config = new MapperConfigurationExpression();

            config.CreateMap<Country, CountryModel>();
            config.CreateMap<SystemUser, GetUserModel>()
                .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Country != null ? src.Country.Name : null));


            return config;
        }
        public async Task<SystemUser> MapUserModelToEntity(CreateUserModel model, string currentLanguage)
        {
            Country country = await Logic.StuffLogic.GetCountryById(model.CountryId);

            SystemUser user = new SystemUser(model.Firstname, model.Lastname, model.Email, model.BirthDate, model.Username, country , model.Language, model.Picture, model.Password);

            user.Role = RoleType.Player;
            user.CreatedUser = model.Email;
            user.Language = model.Language;
            user.ModifiedUser = model.Email;

            return user;
        }
    }
}
