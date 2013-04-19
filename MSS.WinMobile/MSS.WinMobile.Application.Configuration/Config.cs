using System;

using System.Collections.Generic;
using System.Xml;

namespace MSS.WinMobile.Application.Configuration
{
    public class Config
    {
        private const string SectionTagName = "Section";
        private const string SectionNameAttribute = "name";

        private readonly string _configPath;
        private readonly XmlDocument _xmlDocument;
        
        public Config(string configPath)
        {
            _configPath = configPath;
            _sections = new Dictionary<string, Section>();

            _xmlDocument = new XmlDocument();
            _xmlDocument.Load(_configPath);

            XmlNodeList xmlNodeList = _xmlDocument.GetElementsByTagName(SectionTagName);
            for (int i = 0; i < xmlNodeList.Count; i++)
            {
                var xmlAttributeCollection = xmlNodeList[i].Attributes;
                if (xmlAttributeCollection != null)
                {
                    XmlAttribute xmlAttribute = xmlAttributeCollection[SectionNameAttribute];
                    if (xmlAttribute != null)
                    {
                        lock (_sections)
                        {
                            _sections.Add(xmlAttribute.Value.ToLower(), new Section(xmlNodeList[i]));
                        }
                    }
                }
            }
        }

        private readonly Dictionary<string, Section> _sections;

        public Section GetSection(string name)
        {
            string nameInLowerCase = name.ToLower();
            lock (_sections)
            {
                if (_sections.ContainsKey(nameInLowerCase))
                    return _sections[nameInLowerCase];
            }

            throw new SectionNotFoundException(name);
        }

        public void AddSection(string name)
        {
            lock (_sections)
            {
                if (!_sections.ContainsKey(name))
                {
                    XmlElement xmlElement = _xmlDocument.CreateElement(SectionTagName);
                    XmlAttribute xmlAttribute = _xmlDocument.CreateAttribute(SectionNameAttribute);
                    xmlAttribute.Value = name;
                    xmlElement.Attributes.Append(xmlAttribute);

                    _xmlDocument.AppendChild(xmlElement);
                    _sections.Add(name.ToLower(), new Section(xmlElement));
                }
            }

            throw new SectionAlreadyExistException(name);
        }

        public void Save()
        {
            _xmlDocument.Save(_configPath);
        }
    }

    public class SectionNotFoundException : Exception
    {
        public SectionNotFoundException(string name) :
            base(string.Format("Section with name \"{0}\" not found", name))
        {
        }
    }

    public class SectionAlreadyExistException : Exception
    {
        public SectionAlreadyExistException(string name) :
            base(string.Format("Section with name \"{0}\" already exist", name))
        {
        }
    }
}
