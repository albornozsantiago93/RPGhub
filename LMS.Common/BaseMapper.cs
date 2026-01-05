using AutoMapper;
using AutoMapper.Configuration;
using LMS.Common.DTOs;
using LMS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Common
{
    public class BaseMapper
    {
        Dictionary<string, IMapper> _mappers = new Dictionary<string, IMapper>();
        public IMapper Mapper(string language)
        {
            if (!_mappers.ContainsKey(language))
            {
                _mappers.Add(language, GetMapperConfiguration(language).CreateMapper());
            }

            return _mappers[language];

        }

        public LogicProxy Logic { get; set; }

        protected MapperConfiguration GetMapperConfiguration(string language)
        {
            return new MapperConfiguration(GetMapperConfigurationExpression(language));
        }

        protected virtual MapperConfigurationExpression GetMapperConfigurationExpression(string language)
        {
            MapperConfigurationExpression config = new MapperConfigurationExpression();

            config.CreateMap<Country, CountryModel>();

            return config;
        }
    }
}
