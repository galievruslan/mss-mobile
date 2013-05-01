using MSS.WinMobile.Infrastructure.SqliteRepositoties;
using MSS.WinMobile.Infrastructure.SqliteRepositoties.QueryObjects;
using MSS.WinMobile.Infrastructure.SqliteRepositoties.VirtualProxies;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.Helpers;

namespace MSS.WinMobile.Infrastructure.SqliteRepositories.Tests
{
    /// <summary>
    ///This is a test class for CustomerRepositoryTest and is intended
    ///to contain all CustomerRepositoryTest Unit Tests
    ///</summary>
    [TestClass()]
    public class CustomerRepositoryTest
    {
        private static SqLiteDatabase _sqliteDtabase;
        private static SqLiteUnitOfWork _unitOfWork;

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
            
        //}
        
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //    _sqliteDtabase.Dispose();
        //}
        
        //Use TestInitialize to run code before running each test
        [TestInitialize]
        public void MyTestInitialize()
        {
            const string dbScriptFileName = @"\schema.sql";
            string databaseScriptFullPath = TestEnvironment.GetApplicationDirectory() + dbScriptFileName;
            _sqliteDtabase = new SqLiteDatabase(databaseScriptFullPath);
            _unitOfWork = new SqLiteUnitOfWork(_sqliteDtabase);
        }
        
        //Use TestCleanup to run code after each test has run
        [TestCleanup()]
        public void MyTestCleanup()
        {
            _sqliteDtabase.Dispose();
        }
        
        #endregion

        [TestMethod]
        public void SaveTest()
        {
            var customerRepository = new CustomerRepository(_sqliteDtabase, _unitOfWork);
            var customer = new CustomerProxy
                {
                    Id = 1,
                    Name = "Test User"
                };
            customerRepository.Save(customer);
            const int expectedCount = 1;
            int actualCount = customerRepository.Find().GetCount();
            Assert.AreEqual(expectedCount, actualCount);

            const string expectedCustomerName = "ModyfiedName";
            customer.Name = expectedCustomerName;
            customerRepository.Save(customer);
            string actualName = customerRepository.GetById(customer.Id).Name;
            Assert.AreEqual(expectedCustomerName, actualName);
        }

        [TestMethod]
        public void DeleteTest()
        {
            var customerRepository = new CustomerRepository(_sqliteDtabase, _unitOfWork);
            var customer = new CustomerProxy
            {
                Id = 1,
                Name = "Test User"
            };
            customerRepository.Save(customer);
            int expectedCount = 1;
            int actualCount = customerRepository.Find().GetCount();
            Assert.AreEqual(expectedCount, actualCount);

            customerRepository.Delete(customer);
            expectedCount = 0;
            actualCount = customerRepository.Find().GetCount();
            Assert.AreEqual(expectedCount, actualCount);
        }
    }
}
