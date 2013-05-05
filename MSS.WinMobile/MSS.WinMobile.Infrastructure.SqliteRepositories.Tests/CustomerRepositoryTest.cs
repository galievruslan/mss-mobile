using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Sqlite.Repositoties;
using MSS.WinMobile.Infrastructure.Sqlite.Repositoties.VirtualProxies;
using MSS.WinMobile.Infrastructure.Sqlite.SpecificationsTranslators;
using MSS.WinMobile.Infrastructure.Storage;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.Helpers;

namespace MSS.WinMobile.Infrastructure.SqliteRepositories.Tests
{
    /// <summary>
    ///This is a test class for CustomerRepositoryTest and is intended
    ///to contain all CustomerRepositoryTest Unit Tests
    ///</summary>
    [TestClass]
    public class CustomerRepositoryTest
    {
        private IStorage _sqliteDtabase;
        private RepositoryFactory _repositoryFactory;

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
            var storageManager = new SqLiteStorageManager();

            _sqliteDtabase = storageManager.InitializeInMemoryStorage(databaseScriptFullPath);
            _repositoryFactory = new RepositoryFactory(storageManager);
            _repositoryFactory.RegisterSpecificationTranslator(new CommonTranslator<Customer>())
                             .RegisterSpecificationTranslator(new ShippingAddressSpecTranslator());
        }
        
        //Use TestCleanup to run code after each test has run
        [TestCleanup]
        public void MyTestCleanup()
        {
            _sqliteDtabase.Dispose();
        }
        
        #endregion

        [TestMethod]
        public void SaveTest() {
            using (var unitOfWork = new SqLiteUnitOfWork(_sqliteDtabase.Connect())) {
                var customerRepository = _repositoryFactory.CreateRepository<Customer>();
                var shippingAddressRepository =
                    _repositoryFactory.CreateRepository<ShippingAddress>();
                var customer = new CustomerProxy(shippingAddressRepository) {
                    Id = 1,
                    Name = "Test User"
                };

                unitOfWork.BeginTransaction();
                customerRepository.Save(customer);
                unitOfWork.Commit();
                const int expectedCount = 1;
                int actualCount = customerRepository.Find().Count();
                Assert.AreEqual(expectedCount, actualCount);

                const string expectedCustomerName = "ModyfiedName";
                customer.Name = expectedCustomerName;
                unitOfWork.BeginTransaction();
                customerRepository.Save(customer);
                unitOfWork.Commit();
                string actualName = customerRepository.GetById(customer.Id).Name;
                Assert.AreEqual(expectedCustomerName, actualName);
            }
        }

        [TestMethod]
        public void DeleteTest()
        {
            using (var unitOfWork = new SqLiteUnitOfWork(_sqliteDtabase.Connect())) {
                var customerRepository = _repositoryFactory.CreateRepository<Customer>();
                var shippingAddressRepository =
                    _repositoryFactory.CreateRepository<ShippingAddress>();
                
                var customer = new CustomerProxy(shippingAddressRepository) {
                    Id = 1,
                    Name = "Test User"
                };
                unitOfWork.BeginTransaction();
                customerRepository.Save(customer);
                unitOfWork.Commit();
                int expectedCount = 1;
                int actualCount = customerRepository.Find().Count();
                Assert.AreEqual(expectedCount, actualCount);

                unitOfWork.BeginTransaction();
                customerRepository.Delete(customer);
                unitOfWork.Commit();
                expectedCount = 0;
                actualCount = customerRepository.Find().Count();
                Assert.AreEqual(expectedCount, actualCount);
            }
        }
    }
}
