using System;

using System.Collections.Generic;
using System.IO;
using log4net;

namespace MSS.WinMobile.Application.Configuration
{
    public class Manager
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(Manager));
        private const string ConfigurationFolder = @"\Config";

        private readonly string _configurationPath;
        public Manager(string applicationPath)
        {
            _configurationPath = applicationPath + ConfigurationFolder;
            _configs = new Dictionary<string, Config>();

            string[] configurationFiles = Directory.GetFiles(_configurationPath, "*.config");
            foreach (var configurationFile in configurationFiles)
            {
                try
                {
                    var fileInfo = new FileInfo(configurationFile);
                    var config = new Config(configurationFile);
                    _configs.Add(fileInfo.Name.Replace(fileInfo.Extension, string.Empty).ToLower(), config);
                }
                catch (Exception exception)
                {
                    Log.Error(exception);
                }
            }
        }

        private readonly IDictionary<string, Config> _configs;

        public Config GetConfig(string name)
        {
            string nameInLowerCase = name.ToLower();
            lock (_configs)
            {
                if (_configs.ContainsKey(nameInLowerCase))
                    return _configs[nameInLowerCase];
            }

            throw new ConfigNotFoundException(name);
        }

        public class ConfigNotFoundException : Exception
        {
            public ConfigNotFoundException(string name) :
                base(string.Format("Config with name \"{0}\" not found", name))
            {
            }
        }
    }
}
