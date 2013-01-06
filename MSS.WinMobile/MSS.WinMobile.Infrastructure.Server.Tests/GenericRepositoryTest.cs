using MSS.WinMobile.Infrastructure.Server;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mss.WinMobile.Domain.Model;
using System.Collections.Generic;
using System.Linq;
using MSS.WinMobile.Infrastructure.Server.Tests.Properties;

namespace MSS.WinMobile.Infrastructure.Server.Tests
{
    
    
    /// <summary>
    ///This is a test class for GenericRepository<Manager>Test and is intended
    ///to contain all GenericRepository<Manager>Test Unit Tests
    ///</summary>
    [TestClass()]
    public class GenericRepositoryTest
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
        ///A test for Update
        ///</summary>
        [TestMethod()]
        public void UpdateTest()
        {
            MssServer server = new MssServer(Settings.Default.ServerIP, Settings.Default.Port);
            GenericRepository<Manager> target = new GenericRepository<Manager>(server); // TODO: Initialize to an appropriate value
            Manager entity = null; // TODO: Initialize to an appropriate value
            target.Update(entity);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for GetById
        ///</summary>
        [TestMethod()]
        public void GetByIdTest()
        {
            MssServer server = new MssServer(Settings.Default.ServerIP, Settings.Default.Port);
            GenericRepository<Manager> target = new GenericRepository<Manager>(server);
            int id = 1;
            Manager actual;
            actual = target.GetById(id);
            Assert.AreEqual(id, actual.Id);
        }

        /// <summary>
        ///A test for Find
        ///</summary>
        [TestMethod()]
        public void FindTest()
        {
            MssServer server = new MssServer(Settings.Default.ServerIP, Settings.Default.Port);
            GenericRepository<Manager> target = new GenericRepository<Manager>(server);            
            IEnumerable<Manager> actual;
            int expectedCount = 2;
            actual = target.Find();
            Assert.AreEqual(expectedCount, actual.Count());
        }

        /// <summary>
        ///A test for Delete
        ///</summary>
        [TestMethod()]
        public void DeleteTest()
        {
            MssServer server = new MssServer(Settings.Default.ServerIP, Settings.Default.Port);
            GenericRepository<Manager> target = new GenericRepository<Manager>(server); // TODO: Initialize to an appropriate value
            Manager entity = null; // TODO: Initialize to an appropriate value
            target.Delete(entity);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Add
        ///</summary>
        [TestMethod()]
        public void AddTest()
        {
            MssServer server = new MssServer(Settings.Default.ServerIP, Settings.Default.Port);
            GenericRepository<Manager> target = new GenericRepository<Manager>(server); // TODO: Initialize to an appropriate value
            Manager entity = new Manager(0, "Some New Manager");
            target.Add(entity);
        }
    }
}
