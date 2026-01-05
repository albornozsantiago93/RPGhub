using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Infrastructure
{
    internal class CacheManager
    {
        private static IConnectionMultiplexer _connectionMultiplexer;
        private static JsonSerializerSettings _serializerSettings;


        public static void Init(IConnectionMultiplexer multiplexer)
        {
            _connectionMultiplexer = multiplexer;
            _serializerSettings = new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore };
        }

        public static JsonSerializerSettings SerializerSettings
        {
            get
            {
                return _serializerSettings;
            }
        }

        private static IDatabase Redis
        {
            get { return _connectionMultiplexer.GetDatabase(); }
        }

        public static string StringGet(CacheKeys key, params object[] keyNameParameters)
        {
            string keyName = GetCacheKeyName(key, keyNameParameters);

            RedisValue val = Redis.StringGet(keyName);
            if (val.HasValue)
            {
                return val.ToString();
            }

            return null;
        }

        private static string GetCacheKeyName(CacheKeys key, object[] parameters)
        {
            ;
            return GetCacheKeyName(key, out CacheKeyConfig cfg, parameters);
        }

        private static string GetCacheKeyName(CacheKeys key, out CacheKeyConfig cfg, object[] parameters)
        {
            cfg = CacheCfg.Get(key);
            string keyName = cfg.Name;

            for (int i = 0; i < parameters.Length; i++)
            {
                keyName += $"_{parameters[i]}";
            }

            return keyName;
        }
    }
}
