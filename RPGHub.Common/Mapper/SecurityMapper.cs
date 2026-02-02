using AutoMapper.Configuration;
using RPGHub.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGHub.Common
{
    public class SecurityMapper : BaseMapper
    {
        public SecurityMapper()
        {

        }
        public SecurityMapper(ILogicProxy logic)
        {
            Logic = logic;
        }

        protected override MapperConfigurationExpression GetMapperConfigurationExpression(string language)
        {
            MapperConfigurationExpression config = new MapperConfigurationExpression();

            config.CreateMap<UserView, UserModel>()
                .ForMember(x => x.Password, opt => opt.Ignore())
                .ForMember(x => x.IsFirstLogin, opt => opt.MapFrom(x => x.LastLogin == null))
                .ForMember(x => x.Profiles, opt => opt.Ignore())
                .ForMember(x => x.Permissions, opt => opt.Ignore());

            return config;
        }

        public UserModel MapToUserModel(UserView userView, List<string> roles, List<PlatformPermission> permissions, string lang)
        {
            UserModel model = MapTo<UserModel>(userView, lang);

            model.Permissions = permissions.Select(x => x.PermissionName.ToString()).ToList();

            foreach (string role in roles)
            {
                model.Profiles.Add(new ProfileModel(role));
            }
            return model;
        }
    }
}
