using System;
using System.Collections.Specialized;
using System.IO;
using System.Xml;

namespace MSS.WinMobile
{
    /// <summary>
    /// Provides access to configuration files for client applications on the 
    /// .NET Compact Framework.
    /// </summary>
    public static class ConfigurationManager
    {
        private static string _configFile;

        /// <summary>
        /// Gets configuration settings in the appSettings section.
        /// </summary>
        public static NameValueCollection AppSettings { get; private set; }

        /// <summary>
        /// Static constructor.
        /// </summary>
        static ConfigurationManager()
        {
            AppSettings = new NameValueCollection();
            Load();
        }

        private static void Load()
        {
            AppSettings.Clear();

            // Determine the location of the config file
            _configFile = String.Format("{0}.config",
                                       System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);

            // Ensure configuration file exists
            if (!File.Exists(_configFile))
            {
                throw new FileNotFoundException(String.Format("Configuration file ({0}) could not be found.", _configFile));
            }

            // Load config file as an XmlDocument
            var myXmlDocument = new XmlDocument();
            myXmlDocument.Load(_configFile);

            // Add keys and values to the AppSettings NameValueCollection
            var appSettingNodes = myXmlDocument.SelectNodes("/configuration/appSettings/add");
            if (appSettingNodes != null)
            {
                foreach (XmlNode appSettingNode in appSettingNodes)
                {
                    if (appSettingNode.Attributes != null)
                        AppSettings.Add(appSettingNode.Attributes["key"].Value, appSettingNode.Attributes["value"].Value);
                }
            }
        }

        /// <summary>
        /// Saves changes made to the configuration settings.
        /// </summary>
        public static void Save()
        {
            // Load config file as an XmlDocument
            var myXmlDocument = new XmlDocument();
            myXmlDocument.Load(_configFile);

            // Get the appSettings node
            XmlNode appSettingsNode = myXmlDocument.SelectSingleNode("/configuration/appSettings");
            if (appSettingsNode != null)
            {
                // Remove all previous appSetting nodes
                appSettingsNode.RemoveAll();

                foreach (string key in AppSettings.AllKeys)
                {
                    // Create a new appSetting node
                    var appSettingNode = myXmlDocument.CreateElement("add");

                    // Create the key attribute and assign its value
                    XmlAttribute keyAttribute = myXmlDocument.CreateAttribute("key");
                    keyAttribute.Value = key;

                    // Create the value attribute and assign its value
                    XmlAttribute valueAttribute = myXmlDocument.CreateAttribute("value");
                    valueAttribute.Value = AppSettings[key];
                                     
                    // Append the key and value attribute to the appSetting node
                    appSettingNode.Attributes.Append(keyAttribute);
                    appSettingNode.Attributes.Append(valueAttribute);

                    // Append the appSetting node to the appSettings node
                    appSettingsNode.AppendChild(appSettingNode);
                }
            }

            // Save config file
            myXmlDocument.Save(_configFile);

            Load();
        }
    }
}
