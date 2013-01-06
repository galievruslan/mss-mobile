using MSS.WinMobile.Infrastructure.Server;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSS.WinMobile.Infrastructure.Remote.Data;
namespace MSS.WinMobile.Infrastructure.Server.Tests
{
    
    
    /// <summary>
    ///This is a test class for LowercaseContractResolverTest and is intended
    ///to contain all LowercaseContractResolverTest Unit Tests
    ///</summary>
    [TestClass()]
    public class LowercaseContractResolverTest
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
        ///A test for ResolvePropertyName
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MSS.WinMobile.Infrastructure.Remote.Data.dll")]
        public void ResolvePropertyNameTest()
        {
            LowercaseContractResolver_Accessor target = new LowercaseContractResolver_Accessor(); // TODO: Initialize to an appropriate value
            string propertyName = "PropertyName";
            string expected = "property_name";
            string actual;
            actual = target.ResolvePropertyName(propertyName);
            Assert.AreEqual(expected, actual);
        }
    }
}
