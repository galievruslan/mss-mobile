using System.Linq;
using MSS.WinMobile.Infrastructure.Data;
using MSS.WinMobile.Infrastructure.Remote.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mss.WinMobile.Domain.Model;
using Tests.Properties;

namespace Tests.MSS.WinMobile.Infrastructure.Remote.Data
{
    /// <summary>
    /// Summary description for RemoteGenericRepositoryTest
    /// </summary>
    [TestClass]
    public class RemoteGenericRepositoryTest
    {
        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext { get; set; }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void FindManagersTest()
        {
            ISession unitOfWork = new Session(Settings.Default.MssServerIp, Settings.Default.MssServerPort);
            using (var transaction = unitOfWork.BeginTransaction())
            {
                var managerRepository = transaction.Resolve<Manager>();
                var managers = managerRepository.Find();
                Assert.AreEqual(3, managers.Count());
            }
        }
    }
}
