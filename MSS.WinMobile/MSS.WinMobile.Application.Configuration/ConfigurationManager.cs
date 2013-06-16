using System;

using System.Collections.Generic;
using System.IO;
using log4net;

namespace MSS.WinMobile.Application.Configuration
{
    public class ConfigurationManager : IConfigurationManager {
        private static readonly ILog Log = LogManager.GetLogger(typeof(ConfigurationManager));

        public string Path { get; private set; }
        public ConfigurationManager(string configurationsesPath) {
            Path = configurationsesPath;
            _configs = new Dictionary<string, Config>();

            string[] configurationFiles = Directory.GetFiles(Path, "*.config");
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

        public IConfig GetConfig(string name)
        {
            string nameInLowerCase = name.ToLower();
            lock (_configs)
            {
                if (_configs.ContainsKey(nameInLowerCase))
                    return _configs[nameInLowerCase];
            }

            throw new ConfigNotFoundException(name);
        }
    }

    public class ConfigNotFoundException : Exception
    {
        public ConfigNotFoundException(string name) :
            base(string.Format("Config with name \"{0}\" not found", name))
        {
        }
    }
}
