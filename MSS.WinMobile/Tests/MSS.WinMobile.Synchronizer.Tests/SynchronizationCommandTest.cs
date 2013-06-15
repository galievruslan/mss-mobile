using System.IO;
using MSS.WinMobile.Infrastructure.Sqlite.ModelTranslators;
using MSS.WinMobile.Infrastructure.Sqlite.Repositoties;
using MSS.WinMobile.Infrastructure.Sqlite.SpecificationsTranslators;
using MSS.WinMobile.Infrastructure.Web.Repositories;
using MSS.WinMobile.Infrastructure.Web.Repositories.Dtos;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSS.WinMobile.Domain.Models;
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
            var webServer = new WebServer("http://mss.alkotorg.com", "manager", "423200");
            const int bathSize = 300;
            var storageManager = new SqLiteStorageManager();
            var unitOfWorkFactory = new SqLiteUnitOfWorkFactory(storageManager);

            // Initialization
            const string dbScriptFileName = @"\schema.sql";
            string databaseScriptFullPath = TestEnvironment.GetApplicationDirectory() + dbScriptFileName;
            string databaseFileFullPath = TestEnvironment.GetApplicationDirectory() + @"\storage.sqlite";
            var database = storageManager.CreateOrOpenStorage(databaseFileFullPath, databaseScriptFullPath);

            var repositoryFactory = new RepositoryFactory(storageManager);
            repositoryFactory.RegisterSpecificationTranslator(new CommonTranslator<Customer>())
                             .RegisterSpecificationTranslator(new ShippingAddressSpecTranslator())
                             .RegisterSpecificationTranslator(new CommonTranslator<Category>())
                             .RegisterSpecificationTranslator(new CommonTranslator<PriceList>())
                             .RegisterSpecificationTranslator(new CommonTranslator<Product>())
                             .RegisterSpecificationTranslator(new OrderSpecTranslator())
                             .RegisterSpecificationTranslator(new OrderItemSpecTranslator())
                             .RegisterSpecificationTranslator(new ProductPriceSpecTranslator())
                             .RegisterSpecificationTranslator(
                                 new ProductsUnitOfMeasureSpecTranslator())
                             .RegisterSpecificationTranslator(new RoutePointSpecTranslator())
                             .RegisterSpecificationTranslator(new RouteSpecTranslator())
                             .RegisterSpecificationTranslator(
                                 new RoutePointTemplateSpecTranslator())
                             .RegisterSpecificationTranslator(new RouteTemplateSpecTranslator())
                             .RegisterSpecificationTranslator(new CommonTranslator<Status>())
                             .RegisterSpecificationTranslator(new CommonTranslator<UnitOfMeasure>())
                             .RegisterSpecificationTranslator(new CommonTranslator<Warehouse>());

                // Customers synchronization
                var customerDtoRepository = new WebRepository<CustomerDto>(webServer);
                var customerSqLiteRepository = repositoryFactory.CreateRepository<Customer>();
                DtoTranslator<Customer, CustomerDto> customerTranslator =
                    new CustomerTranslator(repositoryFactory);

                var customerSyncCmd =
                    new SynchronizationCommand<CustomerDto, Customer>(customerDtoRepository,
                                                                      customerSqLiteRepository,
                                                                      customerTranslator, unitOfWorkFactory,
                                                                      bathSize);

                customerSyncCmd.Execute();

                // Shipping addresses synchronization
                var shippingAddressDtoRepository =
                    new WebRepository<ShippingAddressDto>(webServer);
                var shippingAddressSqLiteRepository = repositoryFactory.CreateRepository<ShippingAddress>();
                DtoTranslator<ShippingAddress, ShippingAddressDto> shippingAddressdTranslator =
                    new ShippingAddressdTranslator();

                var shippingAddressSyncCmd =
                    new SynchronizationCommand<ShippingAddressDto, ShippingAddress>(
                        shippingAddressDtoRepository, shippingAddressSqLiteRepository,
                        shippingAddressdTranslator, unitOfWorkFactory, bathSize);
                shippingAddressSyncCmd.Execute();

                // Categories synchronization
                var categoriesDtoRepository = new WebRepository<CategoryDto>(webServer);
                var categorySqLiteRepository = repositoryFactory.CreateRepository<Category>();
                DtoTranslator<Category, CategoryDto> categoriesTranslator = new CategoryTranslator();
                var categoriesSyncCmd = new CategotiesSynchronization(categoriesDtoRepository,
                                                                      categorySqLiteRepository,
                                                                      categoriesTranslator,
                                                                      unitOfWorkFactory, bathSize);

                categoriesSyncCmd.Execute();

                // Statuses synchronization
                var statusDtoRepository = new WebRepository<StatusDto>(webServer);
                var statusSqLiteRepository = repositoryFactory.CreateRepository<Status>();
                DtoTranslator<Status, StatusDto> statusTranslator = new StatusTranslator();

                var statusSyncCommand =
                    new SynchronizationCommand<StatusDto, Status>(statusDtoRepository,
                                                                  statusSqLiteRepository,
                                                                  statusTranslator, unitOfWorkFactory,
                                                                  bathSize);

                statusSyncCommand.Execute();

                // Warehouses synchronization
                var warehouseDtoRepository = new WebRepository<WarehouseDto>(webServer);
                var warehouseSqLiteRepository = repositoryFactory.CreateRepository<Warehouse>();
                DtoTranslator<Warehouse, WarehouseDto> warehouseTranslator =
                    new WarehouseTranslator();

                var warehouseSyncCommand =
                    new SynchronizationCommand<WarehouseDto, Warehouse>(warehouseDtoRepository,
                                                                        warehouseSqLiteRepository,
                                                                        warehouseTranslator,
                                                                        unitOfWorkFactory, bathSize);

                warehouseSyncCommand.Execute();

                // Price lists synchronization
                var priceListDtoRepository = new WebRepository<PriceListDto>(webServer);
                var priceListSqLiteRepository = repositoryFactory.CreateRepository<PriceList>();
                DtoTranslator<PriceList, PriceListDto> priceListTranslator =
                    new PriceListTranslator(repositoryFactory);

                var priceListSyncCommand =
                    new SynchronizationCommand<PriceListDto, PriceList>(priceListDtoRepository,
                                                                        priceListSqLiteRepository,
                                                                        priceListTranslator,
                                                                        unitOfWorkFactory, bathSize);

                priceListSyncCommand.Execute();

                // UnitOfMeasures synchronization
                var unitOfMeasureDtoRepository =
                    new WebRepository<UnitOfMeasureDto>(webServer);
                var unitOfMeasureSqLiteRepository = repositoryFactory.CreateRepository<UnitOfMeasure>();
                DtoTranslator<UnitOfMeasure, UnitOfMeasureDto> unitOfMeasureTranslator =
                    new UnitOfMeasureTranslator();

                var unitOfMeasureSyncCommand =
                    new SynchronizationCommand<UnitOfMeasureDto, UnitOfMeasure>(
                        unitOfMeasureDtoRepository, unitOfMeasureSqLiteRepository,
                        unitOfMeasureTranslator, unitOfWorkFactory, bathSize);

                unitOfMeasureSyncCommand.Execute();

                // Products synchronization
                var productDtoRepository = new WebRepository<ProductDto>(webServer);
                var productSqLiteRepository = repositoryFactory.CreateRepository<Product>();
                DtoTranslator<Product, ProductDto> productTranslator = new ProductTranslator(repositoryFactory);

                var productSyncCommand =
                    new SynchronizationCommand<ProductDto, Product>(productDtoRepository,
                                                                    productSqLiteRepository,
                                                                    productTranslator, unitOfWorkFactory,
                                                                    bathSize);

                productSyncCommand.Execute();

                // Product prices synchronization
                var productsPriceDtoRepository =
                    new WebRepository<ProductPriceDto>(webServer);
                var productsPriceSqLiteRepository = repositoryFactory.CreateRepository<ProductsPrice>();
                DtoTranslator<ProductsPrice, ProductPriceDto> productsPriceTranslator =
                    new ProductsPriceTranslator();

                var productsPricesSyncCommand =
                    new SynchronizationCommand<ProductPriceDto, ProductsPrice>(
                        productsPriceDtoRepository, productsPriceSqLiteRepository,
                        productsPriceTranslator, unitOfWorkFactory, bathSize);

                productsPricesSyncCommand.Execute();

                // Product units of measure synchronization
                var productsUomDtoRepository =
                    new WebRepository<ProductUnitOfMeasureDto>(webServer);
                var productsUnitOfMeasureSqLiteRepository =
                    repositoryFactory.CreateRepository<ProductsUnitOfMeasure>();
                DtoTranslator<ProductsUnitOfMeasure, ProductUnitOfMeasureDto>
                    productsUnitOfMeasureTranslator = new ProductsUnitOfMeasureTranslator();

                var productsUomSyncCommand =
                    new SynchronizationCommand<ProductUnitOfMeasureDto, ProductsUnitOfMeasure>(
                        productsUomDtoRepository, productsUnitOfMeasureSqLiteRepository,
                        productsUnitOfMeasureTranslator, unitOfWorkFactory, bathSize);

                productsUomSyncCommand.Execute();

                // Route templates synchronization
                var routeTemplateDtoRepository =
                    new WebRepository<RouteTemplateDto>(webServer);
                var routeTemplateSqLiteRepository = repositoryFactory.CreateRepository<RouteTemplate>();
                DtoTranslator<RouteTemplate, RouteTemplateDto> routeTemplateTranslator =
                    new RouteTemplateTranslator(repositoryFactory);

                var routeTemplateSyncCommand =
                    new SynchronizationCommand<RouteTemplateDto, RouteTemplate>(
                        routeTemplateDtoRepository, routeTemplateSqLiteRepository,
                        routeTemplateTranslator, unitOfWorkFactory, bathSize);

                routeTemplateSyncCommand.Execute();

                // Route points templates synchronization
                var routePointTemplateDtoRepository =
                    new WebRepository<RoutePointTemplateDto>(webServer);
                var routePointTemplateSqLiteRepository =
                    repositoryFactory.CreateRepository<RoutePointTemplate>();
                DtoTranslator<RoutePointTemplate, RoutePointTemplateDto>
                    routePointTemplateTranslator = new RoutePointTemplateTranslator();

                var routePointTemplateSyncCommand =
                    new SynchronizationCommand<RoutePointTemplateDto, RoutePointTemplate>(
                        routePointTemplateDtoRepository, routePointTemplateSqLiteRepository,
                        routePointTemplateTranslator, unitOfWorkFactory, bathSize);

                routePointTemplateSyncCommand.Execute();
            

            // Copy result database
            File.Copy(databaseFileFullPath, @"\Storage Card\storage.sqlite");
            database.Dispose();
        }
    }
}
