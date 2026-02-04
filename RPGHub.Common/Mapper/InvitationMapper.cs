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
    public class InvitationMapper : BaseMapper
    {
        public InvitationMapper()
        {

        }
        public InvitationMapper(ILogicProxy logic)
        {
            Logic = logic;
        }


        protected override MapperConfigurationExpression GetMapperConfigurationExpression(string language)
        {
            MapperConfigurationExpression config = new MapperConfigurationExpression();

            //config.CreateMap<SystemUser, GetUserModel>()
            //    .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Country != null ? src.Country.Name : null));

            return config;
        }

    }
}
