using MSS.WinMobile.Application.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Xml;

namespace MSS.WinMobile.Application.Configuration.Tests
{
    
    
    /// <summary>
    ///This is a test class for SectionTest and is intended
    ///to contain all SectionTest Unit Tests
    ///</summary>
    [TestClass()]
    public class SectionTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

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
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for GetSetting
        ///</summary>
        [TestMethod()]
        public void GetSettingTest()
        {
            XmlNode xmlNode = null; // TODO: Initialize to an appropriate value
            Section target = new Section(xmlNode); // TODO: Initialize to an appropriate value
            string name = string.Empty; // TODO: Initialize to an appropriate value
            Setting expected = null; // TODO: Initialize to an appropriate value
            Setting actual;
            actual = target.GetSetting(name);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for AddSetting
        ///</summary>
        [TestMethod()]
        public void AddSettingTest()
        {
            XmlNode xmlNode = null; // TODO: Initialize to an appropriate value
            Section target = new Section(xmlNode); // TODO: Initialize to an appropriate value
            string name = string.Empty; // TODO: Initialize to an appropriate value
            target.AddSetting(name);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Section Constructor
        ///</summary>
        [TestMethod()]
        public void SectionConstructorTest()
        {
            XmlNode xmlNode = null; // TODO: Initialize to an appropriate value
            Section target = new Section(xmlNode);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }
    }
}
