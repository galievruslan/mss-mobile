using System;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Xml;
using MSS.WinMobile.Application.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace MSS.WinMobile.Application.Configuration.Tests
{
    
    
    /// <summary>
    ///This is a test class for SettingExtensionsTest and is intended
    ///to contain all SettingExtensionsTest Unit Tests
    ///</summary>
    [TestClass()]
    public class SettingExtensionsTest
    {
        private string _applicationPath;
        private string _configDirectory;
        private string _configPath;

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        [TestInitialize]
        public void MyTestInitialize()
        {
            var directoryName = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase);
            if (directoryName != null)
            {
                _applicationPath = directoryName.Replace("file:\\", "");
            }

            _configDirectory = _applicationPath + @"\Config";
            Directory.CreateDirectory(_configDirectory);
            _configPath = _configDirectory + @"\" + "Common.config";

            var xmlDocument = new XmlDocument();
            XmlElement sections = xmlDocument.CreateElement("Sections");
            xmlDocument.AppendChild(sections);

            // Create section
            XmlElement section = xmlDocument.CreateElement("Section");
            XmlAttribute sectionAttribute = xmlDocument.CreateAttribute("name");
            sectionAttribute.Value = string.Format("section {0}", 0);
            section.Attributes.Append(sectionAttribute);
            sections.AppendChild(section);
            // Create setting
            XmlElement setting = xmlDocument.CreateElement("Setting");
            XmlAttribute settingAttribute = xmlDocument.CreateAttribute("name");
            settingAttribute.Value = string.Format("setting {0}", 0);
            setting.Attributes.Append(settingAttribute);
            section.AppendChild(setting);
            // Create setting items (Array)
            for (int i = 0; i < 5; i++) {
                XmlElement item = xmlDocument.CreateElement("Item");
                item.InnerText = i.ToString(CultureInfo.InvariantCulture);
                setting.AppendChild(item);
            }

            xmlDocument.Save(_configPath);
        }

        //Use TestCleanup to run code after each test has run
        [TestCleanup]
        public void MyTestCleanup()
        {
            try
            {
                Directory.Delete(_configDirectory, true);
            }
            catch (Exception)
            {
            }
        }
        #endregion


        /// <summary>
        ///A test for AsStringArray
        ///</summary>
        [TestMethod()]
        public void AsStringArrayTest()
        {
            var config = new Config(_configPath);
            Section section = config.GetSection("Section 0");
            Setting setting = section.GetSetting("Setting 0");
            int[] actual = setting.AsArray<int>();
            Assert.AreEqual(5, actual.Length);
        }
    }
}
