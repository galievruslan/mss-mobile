using System.Xml;

namespace MSS.WinMobile.Application.Configuration
{
    public class Setting
    {
        private readonly XmlNode _xmlNode;
        public Setting(XmlNode xmlNode)
        {
            _xmlNode = xmlNode;
            
        }

        public string Value
        {
            get { return Value = _xmlNode.InnerXml; }
            set { _xmlNode.InnerXml = value; }
        }
    }
}
