using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Xml;
using MSS.WinMobile.Application.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.Helpers;

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
            _applicationPath = TestEnvironment.GetApplicationDirectory();
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
            // Create setting
            setting = xmlDocument.CreateElement("Setting");
            settingAttribute = xmlDocument.CreateAttribute("name");
            settingAttribute.Value = string.Format("setting {0}", 1);
            setting.Attributes.Append(settingAttribute);
            section.AppendChild(setting);
            // Create setting items (Dictionary)
            for (int i = 0; i < 5; i++)
            {
                XmlElement item = xmlDocument.CreateElement("Item");
                XmlElement key = xmlDocument.CreateElement("Key");
                XmlElement value = xmlDocument.CreateElement("Value");
                key.InnerText = i.ToString(CultureInfo.InvariantCulture);
                value.InnerText = string.Format("value {0}", i);
                item.AppendChild(key);
                item.AppendChild(value);
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
        public void AsArrayTest()
        {
            var config = new Config(_configPath);
            ISection section = config.GetSection("Section 0");
            ISetting setting = section.GetSetting("Setting 0");
            string[] actual = setting.AsArray<string>();
            Assert.AreEqual(5, actual.Length);
        }

        [TestMethod()]
        public void AsDictionaryTest()
        {
            var config = new Config(_configPath);
            ISection section = config.GetSection("Section 0");
            ISetting setting = section.GetSetting("Setting 1");
            Dictionary<int, string> actual = setting.AsDictionary<int, string>();
            Assert.AreEqual(5, actual.Count);
        }
    }
}
