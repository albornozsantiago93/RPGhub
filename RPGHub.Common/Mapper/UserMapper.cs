using AutoMapper.Configuration;
using RPGHub.Domain;
using System;
using System.Collections.Generic;
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

        protected MapperConfigurationExpression GetMapperConfigurationExpression(string language)
        {
            MapperConfigurationExpression config = new MapperConfigurationExpression();

            config.CreateMap<Country, CountryModel>();

            return config;
        }
    }
}
