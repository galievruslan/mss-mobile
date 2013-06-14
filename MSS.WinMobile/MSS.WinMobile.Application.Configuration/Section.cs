using System;
using System.Collections.Generic;
using System.Xml;

namespace MSS.WinMobile.Application.Configuration
{
    public class Section : ISection {
        private const string SettingTagName = "Setting";
        private const string SettingNameAttribute = "name";

        private readonly XmlNode _xmlNode;
        public Section(XmlNode xmlNode)
        {
            _xmlNode = xmlNode;
            _settings = new Dictionary<string, Setting>();

            for (int i = 0; i < xmlNode.ChildNodes.Count; i++)
            {
                lock (_settings)
                {
                    var xmlAttributeCollection = xmlNode.ChildNodes[i].Attributes;
                    if (xmlAttributeCollection != null)
                    {
                        XmlAttribute xmlAttribute = xmlAttributeCollection[SettingNameAttribute];
                        if (xmlAttribute != null)
                        {
                            lock (_settings)
                            {
                                _settings.Add(xmlAttribute.Value.ToLower(), new Setting(xmlNode.ChildNodes[i]));
                            }
                        }
                    }
                }
            }
        }

        private readonly Dictionary<string, Setting> _settings;

        public ISetting GetSetting(string name)
        {
            string nameInLowerCase = name.ToLower();
            lock (_settings)
            {
                if (_settings.ContainsKey(nameInLowerCase))
                    return _settings[nameInLowerCase];
            }

            throw new SettingNotFoundException(name);
        }

        public void AddSetting(string name)
        {
            lock (_settings)
            {
                if (!_settings.ContainsKey(name))
                {
                    if (_xmlNode.OwnerDocument != null)
                    {
                        XmlElement xmlElement = _xmlNode.OwnerDocument.CreateElement(SettingTagName);
                        XmlAttribute xmlAttribute = _xmlNode.OwnerDocument.CreateAttribute(SettingNameAttribute);
                        xmlAttribute.Value = name;
                        xmlElement.Attributes.Append(xmlAttribute);

                        _xmlNode.AppendChild(xmlElement);
                        _settings.Add(name.ToLower(), new Setting(xmlElement));
                        return;
                    }
                }
            }

            throw new SettingAlreadyExistException(name);
        }
    }

    public class SettingNotFoundException : Exception
    {
        public SettingNotFoundException(string name) :
            base(string.Format("Setting with name \"{0}\" not found", name))
        {
        }
    }

    public class SettingAlreadyExistException : Exception
    {
        public SettingAlreadyExistException(string name) :
            base(string.Format("Setting with name \"{0}\" already exist", name))
        {
        }
    }
}
