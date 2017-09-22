using System;
using System.Collections.Concurrent;
using System.Configuration;

namespace High.Net.Core.Helpers
{
    public static class SettingsHelper
    {
        private static readonly ConcurrentDictionary<string, string> Cache = new ConcurrentDictionary<string, string>();

        public static string GetSetting(string key)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentNullException(nameof(key));
            }

            string val;
            if (Cache.TryGetValue(key, out val)) return val;

            lock (Cache)
            {
                if (Cache.TryGetValue(key, out val)) return val;

                val = RetrieveSettingValue(key);
                Cache.TryAdd(key, val);
                return val;
            }
        }

        private static string RetrieveSettingValue(string key)
        {
            //use environment variable
            var val = Environment.GetEnvironmentVariable(key);
            return !string.IsNullOrWhiteSpace(val) ? val : ConfigurationManager.AppSettings[key];
        }
    }
}
