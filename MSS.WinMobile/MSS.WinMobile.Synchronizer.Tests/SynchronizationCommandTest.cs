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
            var customerSqLiteRepository = new CustomerRepository(unitOfWork);
            DtoTranslator<Customer, CustomerDto> customerTranslator =
                new CustomerTranslator(new ShippingAddressRepository(unitOfWork));
            
            var customerSyncCmd =
                new SynchronizationCommand<CustomerDto, Customer>(customerDtoRepository, customerSqLiteRepository,
                                                                  customerTranslator, unitOfWork, bathSize);

            customerSyncCmd.Execute();

            // Shipping addresses synchronization
            var shippingAddressDtoRepository = new WebRepository<ShippingAddressDto>(webConnectionFactory);
            var shippingAddressSqLiteRepository = new ShippingAddressRepository(unitOfWork);
            DtoTranslator<ShippingAddress, ShippingAddressDto> shippingAddressdTranslator = new ShippingAddressdTranslator();

            var shippingAddressSyncCmd =
                new SynchronizationCommand<ShippingAddressDto, ShippingAddress>(shippingAddressDtoRepository, shippingAddressSqLiteRepository,
                                                                  shippingAddressdTranslator, unitOfWork, bathSize);
            shippingAddressSyncCmd.Execute();

            // My shipping addresses synchronization
            var myShippingAddressDtoRepository = new WebRepository<MyShippingAddressDto>(webConnectionFactory);
            shippingAddressSqLiteRepository = new ShippingAddressRepository(unitOfWork);
            var myShippingAddressSyncCmd = new MyShippingAddressesSynchronization(myShippingAddressDtoRepository,
                                                                                  shippingAddressSqLiteRepository, unitOfWork, bathSize);

            myShippingAddressSyncCmd.Execute();

            // Categories synchronization
            var categoriesDtoRepository = new WebRepository<CategoryDto>(webConnectionFactory);
            var categorySqLiteRepository = new CategoryRepository(unitOfWork);
            DtoTranslator<Category, CategoryDto> categoriesTranslator = new CategoryTranslator();
            var categoriesSyncCmd = new CategotiesSynchronization(categoriesDtoRepository,
                                                                  categorySqLiteRepository, categoriesTranslator, unitOfWork, bathSize);

            categoriesSyncCmd.Execute();

            // Statuses synchronization
            var statusDtoRepository = new WebRepository<StatusDto>(webConnectionFactory);
            var statusSqLiteRepository = new StatusRepository(unitOfWork);
            DtoTranslator<Status, StatusDto> statusTranslator = new StatusTranslator();

            var statusSyncCommand =
                new SynchronizationCommand<StatusDto, Status>(statusDtoRepository, statusSqLiteRepository,
                                                                  statusTranslator, unitOfWork, bathSize);

            statusSyncCommand.Execute();

            // Warehouses synchronization
            var warehouseDtoRepository = new WebRepository<WarehouseDto>(webConnectionFactory);
            var warehouseSqLiteRepository = new WarehouseRepository(unitOfWork);
            DtoTranslator<Warehouse, WarehouseDto> warehouseTranslator = new WarehouseTranslator();

            var warehouseSyncCommand =
                new SynchronizationCommand<WarehouseDto, Warehouse>(warehouseDtoRepository, warehouseSqLiteRepository,
                                                                  warehouseTranslator, unitOfWork, bathSize);

            warehouseSyncCommand.Execute();

            // Price lists synchronization
            var priceListDtoRepository = new WebRepository<PriceListDto>(webConnectionFactory);
            var priceListSqLiteRepository = new PriceListRepository(unitOfWork);
            DtoTranslator<PriceList, PriceListDto> priceListTranslator = new PriceListTranslator();

            var priceListSyncCommand =
                new SynchronizationCommand<PriceListDto, PriceList>(priceListDtoRepository, priceListSqLiteRepository,
                                                                  priceListTranslator, unitOfWork, bathSize);

            priceListSyncCommand.Execute();

            // UnitOfMeasures synchronization
            var unitOfMeasureDtoRepository = new WebRepository<UnitOfMeasureDto>(webConnectionFactory);
            var unitOfMeasureSqLiteRepository = new UnitOfMeasureRepository(unitOfWork);
            DtoTranslator<UnitOfMeasure, UnitOfMeasureDto> unitOfMeasureTranslator = new UnitOfMeasureTranslator();

            var unitOfMeasureSyncCommand =
                new SynchronizationCommand<UnitOfMeasureDto, UnitOfMeasure>(unitOfMeasureDtoRepository, unitOfMeasureSqLiteRepository,
                                                                  unitOfMeasureTranslator, unitOfWork, bathSize);

            unitOfMeasureSyncCommand.Execute();

            // Products synchronization
            var productDtoRepository = new WebRepository<ProductDto>(webConnectionFactory);
            var productSqLiteRepository = new ProductRepository(unitOfWork);
            DtoTranslator<Product, ProductDto> productTranslator = new ProductTranslator();

            var productSyncCommand =
                new SynchronizationCommand<ProductDto, Product>(productDtoRepository, productSqLiteRepository,
                                                                  productTranslator, unitOfWork, bathSize);

            productSyncCommand.Execute();

            // Product prices synchronization
            var productsPriceDtoRepository = new WebRepository<ProductPriceDto>(webConnectionFactory);
            var productsPriceSqLiteRepository = new ProductsPriceRepository(unitOfWork);
            DtoTranslator<ProductsPrice, ProductPriceDto> productsPriceTranslator = new ProductsPriceTranslator();

            var productsPricesSyncCommand =
                new SynchronizationCommand<ProductPriceDto, ProductsPrice>(productsPriceDtoRepository, productsPriceSqLiteRepository,
                                                                  productsPriceTranslator, unitOfWork, bathSize);

            productsPricesSyncCommand.Execute();

            // Product units of measure synchronization
            var productsUomDtoRepository = new WebRepository<ProductUnitOfMeasureDto>(webConnectionFactory);
            var productsUnitOfMeasureSqLiteRepository = new ProductsUnitOfMeasureRepository(unitOfWork);
            DtoTranslator<ProductsUnitOfMeasure, ProductUnitOfMeasureDto> productsUnitOfMeasureTranslator = new ProductsUnitOfMeasureTranslator();

            var productsUomSyncCommand =
                new SynchronizationCommand<ProductUnitOfMeasureDto, ProductsUnitOfMeasure>(productsUomDtoRepository, productsUnitOfMeasureSqLiteRepository,
                                                                  productsUnitOfMeasureTranslator, unitOfWork, bathSize);

            productsUomSyncCommand.Execute();

            // Route templates synchronization
            var routeTemplateDtoRepository = new WebRepository<RouteTemplateDto>(webConnectionFactory);
            var routeTemplateSqLiteRepository = new RouteTemplateRepository(unitOfWork);
            DtoTranslator<RouteTemplate, RouteTemplateDto> routeTemplateTranslator = new RouteTemplateTranslator();

            var routeTemplateSyncCommand =
                new SynchronizationCommand<RouteTemplateDto, RouteTemplate>(routeTemplateDtoRepository, routeTemplateSqLiteRepository,
                                                                  routeTemplateTranslator, unitOfWork, bathSize);

            routeTemplateSyncCommand.Execute();

            // Route points templates synchronization
            var routePointTemplateDtoRepository = new WebRepository<RoutePointTemplateDto>(webConnectionFactory);
            var routePointTemplateSqLiteRepository = new RoutePointTemplateRepository(unitOfWork);
            DtoTranslator<RoutePointTemplate, RoutePointTemplateDto> routePointTemplateTranslator = new RoutePointTemplateTranslator();

            var routePointTemplateSyncCommand =
                new SynchronizationCommand<RoutePointTemplateDto, RoutePointTemplate>(routePointTemplateDtoRepository, routePointTemplateSqLiteRepository,
                                                                  routePointTemplateTranslator, unitOfWork, bathSize);

            routePointTemplateSyncCommand.Execute();

            // Copy result database
            File.Copy(databaseFileFullPath, @"\Storage Card\storage.sqlite");
            database.Dispose();
        }
    }
}
