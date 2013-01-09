using System.Collections.Specialized;
using System.IO;
using System.Reflection;
using System.Xml;

namespace MSS.WinMobile.Config
{
    public static class Mobile
    {
        public static NameValueCollection Settings;

        static Mobile()
        {
            string appPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase);
            string configFile = Path.Combine(appPath, "App.config");

            if (!File.Exists(configFile))
            {
                throw new FileNotFoundException(string.Format("Application configuration file '{0}' not found.",
                                                              configFile));
            }

            var xmlDocument = new XmlDocument();
            xmlDocument.Load(configFile);

            XmlNodeList nodeList = xmlDocument.GetElementsByTagName("appSettings");
            Settings = new NameValueCollection();

            foreach (XmlNode node in nodeList)
            {
                foreach (XmlNode key in node.ChildNodes)
                {
                    Settings.Add(key.Attributes["key"].Value, key.Attributes["value"].Value);
                }
            }
        }
    }
}
