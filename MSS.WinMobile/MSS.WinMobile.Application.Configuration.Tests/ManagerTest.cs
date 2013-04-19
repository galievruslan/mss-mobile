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
            foreach (var config in _configs)
            {
                try
                {
                    File.Delete(config);
                }
                catch
                {
                }
            }
        }
        
        #endregion

        /// <summary>
        ///A test for GetConfig
        ///</summary>
        [TestMethod]
        public void GetConfigTest()
        {
            var target = new Manager(_applicationPath);
            var actual = target.GetConfig(@"Common");
            Assert.IsNotNull(actual);
        }

        /// <summary>
        ///A test for Manager Constructor
        ///</summary>
        [TestMethod]
        public void ManagerConstructorTest()
        {
            string applicationPath = string.Empty; // TODO: Initialize to an appropriate value
            Manager target = new Manager(applicationPath);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }
    }
}
