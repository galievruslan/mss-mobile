using System;
using System.Globalization;
using System.IO;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Xml;
using Tests.Helpers;

namespace MSS.WinMobile.Application.Configuration.Tests
{
    
    
    /// <summary>
    ///This is a test class for SectionTest and is intended
    ///to contain all SectionTest Unit Tests
    ///</summary>
    [TestClass]
    public class SectionTest
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
            _applicationPath = TestEnvironment.GetApplicationDirectory();
            _configDirectory = _applicationPath + @"\Config";
            Directory.CreateDirectory(_configDirectory);
            _configPath = _configDirectory + @"\" + "Common.config";

            var xmlDocument = new XmlDocument();
            XmlElement sections = xmlDocument.CreateElement("Sections");
            xmlDocument.AppendChild(sections);
            for (int i = 0; i < 5; i++)
            {
                XmlElement section = xmlDocument.CreateElement("Section");
                XmlAttribute sectionAttribute = xmlDocument.CreateAttribute("name");
                sectionAttribute.Value = string.Format("section {0}", i);
                section.Attributes.Append(sectionAttribute);
                sections.AppendChild(section);

                for (int j = 0; j < 5; j++)
                {
                    XmlElement setting = xmlDocument.CreateElement("Setting");
                    XmlAttribute settingAttribute = xmlDocument.CreateAttribute("name");
                    settingAttribute.Value = string.Format("setting {0}", j);
                    setting.Attributes.Append(settingAttribute);
                    setting.InnerText = j.ToString(CultureInfo.InvariantCulture);
                    section.AppendChild(setting);
                }
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
        ///A test for GetSetting
        ///</summary>
        [TestMethod()]
        public void GetSettingTest()
        {
            var config = new Config(_configPath);
            ISection target = config.GetSection("Section 2");
            ISetting actual = target.GetSetting("Setting 3");
            Assert.IsNotNull(actual);
        }

        /// <summary>
        ///A test for AddSetting
        ///</summary>
        [TestMethod()]
        public void AddSettingTest()
        {
            var config = new Config(_configPath);
            ISection target = config.GetSection("Section 2");
            target.AddSetting("New Setting");

            ISetting actual = target.GetSetting("New Setting");
            Assert.IsNotNull(actual);
        }
    }
}
