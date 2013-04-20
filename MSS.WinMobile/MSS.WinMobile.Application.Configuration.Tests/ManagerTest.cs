using System;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Xml;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace MSS.WinMobile.Application.Configuration.Tests
{
    
    
    /// <summary>
    ///This is a test class for ManagerTest and is intended
    ///to contain all ManagerTest Unit Tests
    ///</summary>
    [TestClass]
    public class ManagerTest
    {
        private string _applicationPath;
        private string _configPath;

        private string[] _configs;

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

            _configPath = _applicationPath + @"\Config";
            Directory.CreateDirectory(_configPath);
            _configs = new[] { _configPath + "\\" + "Common.config", _configPath + "\\" + "Empty.config" };

            var xmlDocument = new XmlDocument();
            XmlElement sections = xmlDocument.CreateElement("Sections");
            xmlDocument.AppendChild(sections);
            for (int i = 0; i < 5; i ++)
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
            xmlDocument.Save(_configs[0]);

            using (File.Create(_configs[1])) {}
        }
        
        //Use TestCleanup to run code after each test has run
        [TestCleanup]
        public void MyTestCleanup()
        {
            try
            {
                Directory.Delete(_configPath, true);
            }
            catch (Exception)
            {
            }
        }
        
        #endregion

        /// <summary>
        ///A test for GetConfig
        ///</summary>
        [TestMethod]
        public void GetConfigTest()
        {
            var target = new ConfigurationManager(_applicationPath);
            var actual = target.GetConfig(@"Common");
            Assert.IsNotNull(actual);
        }

        /// <summary>
        ///A test for GetConfig
        ///</summary>
        [TestMethod, ExpectedException(typeof(ConfigNotFoundException))]
        public void GetNotExistingConfigTest()
        {
            var target = new ConfigurationManager(_applicationPath);
            try {
                var actual = target.GetConfig(@"NotExisted");
                Assert.Fail("Expected exception wasn't thrown.");
            }
            catch (ConfigNotFoundException) {
            }
        }
    }
}
