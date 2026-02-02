namespace RPGHub.Infrastructure
{
    public class CacheCfg
    {
        private static readonly Dictionary<CacheKeys, CacheKeyConfig> _keyConfigs = new Dictionary<CacheKeys, CacheKeyConfig>();

        private static object _initLock = new object();

        public static CacheKeyConfig Get(CacheKeys key)
        {
            if (_keyConfigs.Count == 0)
            {
                lock (_keyConfigs)
                {
                    if (_keyConfigs.Count == 0)
                    {
                        _keyConfigs.Add(CacheKeys.parameters, new CacheKeyConfig("parameters", 0, 0));
                        _keyConfigs.Add(CacheKeys.requestResponseTime, new CacheKeyConfig("requestResponseTime", 0, 0));
                    }
                }
            }
            return _keyConfigs[key];
        }
    }

    public class CacheKeyConfig
    {
        public CacheKeyConfig()
        {

        }
        public CacheKeyConfig(string name) : this(name, 0, 0)
        {
        }

        public CacheKeyConfig(string name, int ttlMinutes) : this(name, ttlMinutes, 0)
        {
        }

        public CacheKeyConfig(string name, int ttlMinutes, int ttlSeconds)
        {
            Name = name;
            if (ttlMinutes != 0 || ttlSeconds != 0)
            {
                TTL = new TimeSpan(0, ttlMinutes, ttlSeconds);
            }
        }

        public string Name { get; }
        public TimeSpan? TTL { get; internal set; }
    }

    public enum CacheKeys
    {
        parameters,
        requestResponseTime
    }
}
