using MSS.WinMobile.Infrastructure.Server;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mss.WinMobile.Domain.Model;
using System.Collections.Generic;

namespace MSS.WinMobile.Infrastructure.Server.Tests
{
    
    
    /// <summary>
    ///This is a test class for ManagerRepositoryTest and is intended
    ///to contain all ManagerRepositoryTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ManagerRepositoryTest
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
            MssServer server = null; // TODO: Initialize to an appropriate value
            ManagerRepository target = new ManagerRepository(server); // TODO: Initialize to an appropriate value
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
            MssServer server = new MssServer("192.168.0.102", 3000);
            ManagerRepository target = new ManagerRepository(server);
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
            MssServer server = null; // TODO: Initialize to an appropriate value
            ManagerRepository target = new ManagerRepository(server); // TODO: Initialize to an appropriate value
            IEnumerable<Manager> expected = null; // TODO: Initialize to an appropriate value
            IEnumerable<Manager> actual;
            actual = target.Find();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Delete
        ///</summary>
        [TestMethod()]
        public void DeleteTest()
        {
            MssServer server = null; // TODO: Initialize to an appropriate value
            ManagerRepository target = new ManagerRepository(server); // TODO: Initialize to an appropriate value
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
            MssServer server = null; // TODO: Initialize to an appropriate value
            ManagerRepository target = new ManagerRepository(server); // TODO: Initialize to an appropriate value
            Manager entity = null; // TODO: Initialize to an appropriate value
            target.Add(entity);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for ManagerRepository Constructor
        ///</summary>
        [TestMethod()]
        public void ManagerRepositoryConstructorTest()
        {
            MssServer server = null; // TODO: Initialize to an appropriate value
            ManagerRepository target = new ManagerRepository(server);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }
    }
}
