using System.IO;
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
    [TestClass]
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

        [TestMethod]
        public void SynchronizeTest()
        {
            var webServer = new WebServer("http://mss.alkotorg.com");
            var webConnectionFactory = new WebConnectionFactory(webServer, "manager", "423200");
            const int bathSize = 300;

            // Initialization
            const string dbScriptFileName = @"\schema.sql";
            string databaseScriptFullPath = TestEnvironment.GetApplicationDirectory() + dbScriptFileName;
            string databaseFileFullPath = TestEnvironment.GetApplicationDirectory() + @"\storage.sqlite";
            var database = SqLiteDatabase.CreateOrOpenFileDatabase(databaseFileFullPath, databaseScriptFullPath);
            var unitOfWork = new SqLiteUnitOfWork(database);

            // Customers synchronization
            var customerDtoRepository = new WebRepository<CustomerDto>(webConnectionFactory);
            var customerSqLiteRepository = new CustomerRepository(database, unitOfWork);
            DtoTranslator<Customer, CustomerDto> customerTranslator =
                new CustomerTranslator(new ShippingAddressRepository(database, unitOfWork));
            
            var customerSyncCmd =
                new SynchronizationCommand<CustomerDto, Customer>(customerDtoRepository, customerSqLiteRepository,
                                                                  customerTranslator, bathSize);

            unitOfWork.BeginTransaction();
            customerSyncCmd.Execute();
            unitOfWork.Commit();

            // Shipping addresses synchronization
            var shippingAddressDtoRepository = new WebRepository<ShippingAddressDto>(webConnectionFactory);
            var shippingAddressSqLiteRepository = new ShippingAddressRepository(database, unitOfWork);
            DtoTranslator<ShippingAddress, ShippingAddressDto> shippingAddressdTranslator = new ShippingAddressdTranslator();

            var shippingAddressSyncCmd =
                new SynchronizationCommand<ShippingAddressDto, ShippingAddress>(shippingAddressDtoRepository, shippingAddressSqLiteRepository,
                                                                  shippingAddressdTranslator, bathSize);
            unitOfWork.BeginTransaction();
            shippingAddressSyncCmd.Execute();
            unitOfWork.Commit();

            // My shipping addresses synchronization
            var myShippingAddressDtoRepository = new WebRepository<MyShippingAddressDto>(webConnectionFactory);
            shippingAddressSqLiteRepository = new ShippingAddressRepository(database, unitOfWork);
            var myShippingAddressSyncCmd = new MyShippingAddressesSynchronization(myShippingAddressDtoRepository,
                                                                                  shippingAddressSqLiteRepository, bathSize);

            unitOfWork.BeginTransaction();
            myShippingAddressSyncCmd.Execute();
            unitOfWork.Commit();

            // Categories synchronization
            var categoriesDtoRepository = new WebRepository<CategoryDto>(webConnectionFactory);
            var categorySqLiteRepository = new CategoryRepository(database, unitOfWork);
            DtoTranslator<Category, CategoryDto> categoriesTranslator = new CategoryTranslator();
            var categoriesSyncCmd = new CategotiesSynchronization(categoriesDtoRepository,
                                                                  categorySqLiteRepository, categoriesTranslator, bathSize);

            unitOfWork.BeginTransaction();
            categoriesSyncCmd.Execute();
            unitOfWork.Commit();

            // Statuses synchronization
            var statusDtoRepository = new WebRepository<StatusDto>(webConnectionFactory);
            var statusSqLiteRepository = new StatusRepository(database, unitOfWork);
            DtoTranslator<Status, StatusDto> statusTranslator = new StatusTranslator();

            var statusSyncCommand =
                new SynchronizationCommand<StatusDto, Status>(statusDtoRepository, statusSqLiteRepository,
                                                                  statusTranslator, bathSize);

            unitOfWork.BeginTransaction();
            statusSyncCommand.Execute();
            unitOfWork.Commit();

            // Warehouses synchronization
            var warehouseDtoRepository = new WebRepository<WarehouseDto>(webConnectionFactory);
            var warehouseSqLiteRepository = new WarehouseRepository(database, unitOfWork);
            DtoTranslator<Warehouse, WarehouseDto> warehouseTranslator = new WarehouseTranslator();

            var warehouseSyncCommand =
                new SynchronizationCommand<WarehouseDto, Warehouse>(warehouseDtoRepository, warehouseSqLiteRepository,
                                                                  warehouseTranslator, bathSize);

            unitOfWork.BeginTransaction();
            warehouseSyncCommand.Execute();
            unitOfWork.Commit();

            // Price lists synchronization
            var priceListDtoRepository = new WebRepository<PriceListDto>(webConnectionFactory);
            var priceListSqLiteRepository = new PriceListRepository(database, unitOfWork);
            DtoTranslator<PriceList, PriceListDto> priceListTranslator = new PriceListTranslator();

            var priceListSyncCommand =
                new SynchronizationCommand<PriceListDto, PriceList>(priceListDtoRepository, priceListSqLiteRepository,
                                                                  priceListTranslator, bathSize);

            unitOfWork.BeginTransaction();
            priceListSyncCommand.Execute();
            unitOfWork.Commit();

            // UnitOfMeasures synchronization
            var unitOfMeasureDtoRepository = new WebRepository<UnitOfMeasureDto>(webConnectionFactory);
            var unitOfMeasureSqLiteRepository = new UnitOfMeasureRepository(database, unitOfWork);
            DtoTranslator<UnitOfMeasure, UnitOfMeasureDto> unitOfMeasureTranslator = new UnitOfMeasureTranslator();

            var unitOfMeasureSyncCommand =
                new SynchronizationCommand<UnitOfMeasureDto, UnitOfMeasure>(unitOfMeasureDtoRepository, unitOfMeasureSqLiteRepository,
                                                                  unitOfMeasureTranslator, bathSize);

            unitOfWork.BeginTransaction();
            unitOfMeasureSyncCommand.Execute();
            unitOfWork.Commit();

            // Products synchronization
            var productDtoRepository = new WebRepository<ProductDto>(webConnectionFactory);
            var productSqLiteRepository = new ProductRepository(database, unitOfWork);
            DtoTranslator<Product, ProductDto> productTranslator = new ProductTranslator();

            var productSyncCommand =
                new SynchronizationCommand<ProductDto, Product>(productDtoRepository, productSqLiteRepository,
                                                                  productTranslator, bathSize);

            unitOfWork.BeginTransaction();
            productSyncCommand.Execute();
            unitOfWork.Commit();

            // Product prices synchronization
            var productsPriceDtoRepository = new WebRepository<ProductPriceDto>(webConnectionFactory);
            var productsPriceSqLiteRepository = new ProductsPriceRepository(database, unitOfWork);
            DtoTranslator<ProductsPrice, ProductPriceDto> productsPriceTranslator = new ProductsPriceTranslator();

            var productsPricesSyncCommand =
                new SynchronizationCommand<ProductPriceDto, ProductsPrice>(productsPriceDtoRepository, productsPriceSqLiteRepository,
                                                                  productsPriceTranslator, bathSize);

            unitOfWork.BeginTransaction();
            productsPricesSyncCommand.Execute();
            unitOfWork.Commit();

            // Product units of measure synchronization
            var productsUomDtoRepository = new WebRepository<ProductUnitOfMeasureDto>(webConnectionFactory);
            var productsUnitOfMeasureSqLiteRepository = new ProductsUnitOfMeasureRepository(database, unitOfWork);
            DtoTranslator<ProductsUnitOfMeasure, ProductUnitOfMeasureDto> productsUnitOfMeasureTranslator = new ProductsUnitOfMeasureTranslator();

            var productsUomSyncCommand =
                new SynchronizationCommand<ProductUnitOfMeasureDto, ProductsUnitOfMeasure>(productsUomDtoRepository, productsUnitOfMeasureSqLiteRepository,
                                                                  productsUnitOfMeasureTranslator, bathSize);

            unitOfWork.BeginTransaction();
            productsUomSyncCommand.Execute();
            unitOfWork.Commit();

            // Route templates synchronization
            var routeTemplateDtoRepository = new WebRepository<RouteTemplateDto>(webConnectionFactory);
            var routeTemplateSqLiteRepository = new RouteTemplateRepository(database, unitOfWork);
            DtoTranslator<RouteTemplate, RouteTemplateDto> routeTemplateTranslator = new RouteTemplateTranslator();

            var routeTemplateSyncCommand =
                new SynchronizationCommand<RouteTemplateDto, RouteTemplate>(routeTemplateDtoRepository, routeTemplateSqLiteRepository,
                                                                  routeTemplateTranslator, bathSize);

            unitOfWork.BeginTransaction();
            routeTemplateSyncCommand.Execute();
            unitOfWork.Commit();

            // Route points templates synchronization
            var routePointTemplateDtoRepository = new WebRepository<RoutePointTemplateDto>(webConnectionFactory);
            var routePointTemplateSqLiteRepository = new RoutePointTemplateRepository(database, unitOfWork);
            DtoTranslator<RoutePointTemplate, RoutePointTemplateDto> routePointTemplateTranslator = new RoutePointTemplateTranslator();

            var routePointTemplateSyncCommand =
                new SynchronizationCommand<RoutePointTemplateDto, RoutePointTemplate>(routePointTemplateDtoRepository, routePointTemplateSqLiteRepository,
                                                                  routePointTemplateTranslator, bathSize);

            unitOfWork.BeginTransaction();
            routePointTemplateSyncCommand.Execute();
            unitOfWork.Commit();

            // Copy result database
            File.Copy(databaseFileFullPath, @"\Storage Card\storage.sqlite");
            database.Dispose();
        }
    }
}
