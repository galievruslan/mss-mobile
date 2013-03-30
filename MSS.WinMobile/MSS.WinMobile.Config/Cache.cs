using System.Collections.Generic;
using log4net;

namespace MSS.WinMobile
{
    public static class Cache
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(Cache));
        private static readonly IDictionary<string, object> CacheDictionary = new Dictionary<string, object>();

        public static void Add<T>(string key, T value)
        {
            lock (CacheDictionary)
            {
                if (CacheDictionary.ContainsKey(key))
                    CacheDictionary[key] = value;
                else
                    CacheDictionary.Add(key, value);
            }

            Log.DebugFormat("Added to cache entry with key {0} and value {1}", key, value);
        }

        public static void Remove(string key)
        {
            lock (CacheDictionary)
            {
                if (CacheDictionary.ContainsKey(key))
                {
                    CacheDictionary.Remove(key);
                    Log.DebugFormat("Removed from cache entry with key {0}", key);
                }
            }
        }

        public static bool Contains(string key)
        {
            return CacheDictionary.ContainsKey(key);
        }

        public static T Get<T>(string key)
        {
            object result = null;
            lock (CacheDictionary)
            {
                if (CacheDictionary.ContainsKey(key))
                {
                     result = CacheDictionary[key];
                }
            }

            if (result != null && result.GetType() == typeof (T))
            {
                Log.DebugFormat("Retrieved cache entry with key {0} and value {1}", key, result);
                return (T) result;
            }

            return default(T);
        }
    }
}
