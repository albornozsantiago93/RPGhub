using AutoMapper;
using AutoMapper.Configuration;
using RPGHub.Domain;

namespace RPGHub.Common
{
    public class BaseMapper
    {
        Dictionary<string, IMapper> _mappers = new Dictionary<string, IMapper>();

        public ILogicProxy Logic { get; set; }

        public IMapper Mapper(string language)
        {
            if (!_mappers.ContainsKey(language))
            {
                _mappers.Add(language, GetMapperConfiguration(language).CreateMapper());
            }

            return _mappers[language];
        }

        public T MapTo<T>(object item, string targetLanguage)
        {
            return Mapper(targetLanguage).Map<T>(item);
        }

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
