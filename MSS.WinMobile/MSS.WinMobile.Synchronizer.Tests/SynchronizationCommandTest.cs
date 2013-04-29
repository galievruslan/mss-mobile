using MSS.WinMobile.Synchronizer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSS.WinMobile.Infrastructure.WebRepositories.Dtos;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.WebRepositories;
using MSS.WinMobile.Infrastructure.SqliteRepositoties;
using MSS.WinMobile.Infrastructure.ModelTranslators;
using Tests.Helpers;

namespace MSS.WinMobile.Synchronizer.Tests
{
    
    
    /// <summary>
    ///This is a test class for SynchronizationCommandTest and is intended
    ///to contain all SynchronizationCommandTest Unit Tests
    ///</summary>
    [TestClass()]
    public class SynchronizationCommandTest
    {
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

        [TestMethod()]
        public void SynchronizeTest()
        {
            WebServer webServer = new WebServer("");
            WebConnectionFactory webConnectionFactory = new WebConnectionFactory(webServer, "", "");

            const string dbScriptFileName = @"\schema.sql";
            string databaseScriptFullPath = TestEnvironment.GetApplicationDirectory() + dbScriptFileName;
            var database = new SQLiteDatabase(databaseScriptFullPath);
            var unitOfWork = new SQLiteUnitOfWork(database);

            WebRepository<CustomerDto> customerDtoRepository = new WebRepository<CustomerDto>(webConnectionFactory);
            CustomerSQLiteRepository customerSQLiteRepository = new CustomerSQLiteRepository(database, unitOfWork);
            DtoTranslator<Customer, CustomerDto> translator = new CustomerTranslator();

            unitOfWork.BeginTransaction();
            SynchronizationCommand<CustomerDto, Customer> target =
                new SynchronizationCommand<CustomerDto, Customer>(customerDtoRepository, customerSQLiteRepository,
                                                                  translator, 100);
            target.Execute();
            unitOfWork.Commit();

            WebRepository<ShippingAddressDto> shippingAddressDtoRepository = new WebRepository<ShippingAddressDto>(webConnectionFactory);
            ShippingAddressSQLiteRepository shippingAddressSQLiteRepository = new ShippingAddressSQLiteRepository(database, unitOfWork);
            DtoTranslator<ShippingAddress, ShippingAddressDto> translator1 = new ShippingAddressdTranslator();

            unitOfWork.BeginTransaction();
            SynchronizationCommand<ShippingAddressDto, ShippingAddress> target1 =
                new SynchronizationCommand<ShippingAddressDto, ShippingAddress>(shippingAddressDtoRepository, shippingAddressSQLiteRepository,
                                                                  translator1, 100);
            target1.Execute();
            unitOfWork.Commit();
        }
    }
}
