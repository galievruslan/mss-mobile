using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using log4net;

namespace MSS.WinMobile.Resources {
    public class Localization : ILocalization {
        private static readonly ILog Log = LogManager.GetLogger(typeof(Localization));

        public Localization(string localizationFile) {
            Path = localizationFile;
            var fileInfo = new FileInfo(Path);
            Name = fileInfo.Name.Replace("." + fileInfo.Extension, string.Empty);
        }

        public string Name { get; private set; }

        public string Path { get; private set; }

        readonly IDictionary<string, string> _values = new Dictionary<string, string>();

        public void Load() {
            const string nameAttribute = "name";

            try {
                var xmlDocument = new XmlDocument();
                xmlDocument.Load(Path);
                XmlNodeList xmlNodeList = xmlDocument.GetElementsByTagName("Root")[0].ChildNodes;
                for (int i = 0; i < xmlNodeList.Count; i++) {
                    var xmlAttributeCollection = xmlNodeList[i].Attributes;
                    if (xmlAttributeCollection != null) {
                        XmlAttribute xmlAttribute = xmlAttributeCollection[nameAttribute];
                        if (xmlAttribute != null) {
                            string attributeValueInLower = xmlAttribute.Value.ToLower();
                            if (_values.ContainsKey(attributeValueInLower))
                                _values[attributeValueInLower] = xmlNodeList[i].InnerText;
                            else
                                _values.Add(attributeValueInLower, xmlNodeList[i].InnerText);
                        }
                    }
                }
            }
            catch (Exception exception) {
                Log.Error(exception);
            }
        }

        public string GetLocalizedValue(string valueToLocalizate) {
            string valueToLocalizateInLower = valueToLocalizate.ToLower();
            if (_values.ContainsKey(valueToLocalizateInLower))
                return _values[valueToLocalizateInLower];

            return valueToLocalizate;
        }
    }
}
