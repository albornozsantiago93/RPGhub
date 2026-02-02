using Microsoft.Extensions.Configuration;
using System;
using System.ComponentModel.DataAnnotations.Schema;


namespace RPGHub.Common.Config
{
    public static class ApiConfiguration
    {
        private static IConfiguration currentConfig;

        public static void SetConfig(IConfiguration configuration)
        {
            currentConfig = configuration;
        }


        public static string GetConnectionStringConfiguration(string configKey)
        {
            try
            {
                string connectionString = currentConfig.GetConnectionString(configKey);
                return connectionString;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public static string GetConfig(string key)
        {
            return currentConfig[key];
        }
    }
}
