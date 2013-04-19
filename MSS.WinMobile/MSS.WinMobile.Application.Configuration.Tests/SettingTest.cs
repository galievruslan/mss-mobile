using MSS.WinMobile.Application.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Xml;

namespace MSS.WinMobile.Application.Configuration.Tests
{
    
    
    /// <summary>
    ///This is a test class for SettingTest and is intended
    ///to contain all SettingTest Unit Tests
    ///</summary>
    [TestClass()]
    public class SettingTest
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
        ///A test for Value
        ///</summary>
        [TestMethod()]
        public void ValueTest()
        {
            XmlNode xmlNode = null; // TODO: Initialize to an appropriate value
            Setting target = new Setting(xmlNode); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            target.Value = expected;
            actual = target.Value;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Setting Constructor
        ///</summary>
        [TestMethod()]
        public void SettingConstructorTest()
        {
            XmlNode xmlNode = null; // TODO: Initialize to an appropriate value
            Setting target = new Setting(xmlNode);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }
    }
}
