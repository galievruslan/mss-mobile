using System;
using System.Globalization;
using System.Threading;
using MSS.WinMobile.Application.Configuration;
using MSS.WinMobile.Application.Environment;
using MSS.WinMobile.Common.Observable;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.ModelTranslators;
using MSS.WinMobile.Infrastructure.SqliteRepositoties;
using MSS.WinMobile.Infrastructure.WebRepositories;
using MSS.WinMobile.Infrastructure.WebRepositories.Dtos;
using MSS.WinMobile.Synchronizer;
using MSS.WinMobile.Synchronizer.FaultHandling;
using MSS.WinMobile.UI.Presenters.ViewModels;
using MSS.WinMobile.UI.Presenters.Views;
using log4net;

namespace MSS.WinMobile.UI.Presenters.Presenters
{
    public class SynchronizationPresenter : IObserver
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(SynchronizationPresenter));

        private readonly ConfigurationManager _configurationManager;
        private readonly ISynchronizationView _view;
        private SqLiteDatabase _sqLiteDatabase;

        public SynchronizationPresenter(ISynchronizationView view, SqLiteDatabase sqLiteDatabase) {
            _configurationManager = new ConfigurationManager(Environments.AppPath);
            _view = view;
            _sqLiteDatabase = sqLiteDatabase;
        }

        private Thread _thread;

        public void Synchronize() {
            _thread = new Thread(RunSynchronizationInBackground);
            _thread.Start();
        }

        private void RunSynchronizationInBackground() {
            
                var serverAddress =
                    _configurationManager.GetConfig("Common").GetSection("Server").GetSetting("Address").Value;
                var username =
                    _configurationManager.GetConfig("Common").GetSection("Server").GetSetting("Username").Value;
                var password =
                    _configurationManager.GetConfig("Common").GetSection("Server").GetSetting("Password").Value;
                var bathSize =
                    _configurationManager.GetConfig("Common").GetSection("Server").GetSetting("BathSize").As<int>();

                var databaseName =
                    _configurationManager.GetConfig("Common").GetSection("Database").GetSetting("FileName").Value;
                var schemaScript =
                    _configurationManager.GetConfig("Common").GetSection("Database").GetSetting("SchemaScript").Value;

            using (
                var webConnectionFactory = new WebConnectionFactory(new WebServer(serverAddress), username, password)
                ) {
                if (_viewModel.SynchronizeFully) {
                    Notify(new TextNotification("Clear Database"));
                    _sqLiteDatabase.UnitOfWork.Dispose();
                    _sqLiteDatabase.Delete();
                }

                DateTime synchronizationDate = webConnectionFactory.CurrentConnection.ServerTime();

                // Initialization
                string databaseScriptFullPath = Environments.AppPath + schemaScript;
                string databaseFileFullPath = Environments.AppPath + databaseName;
                _sqLiteDatabase = SqLiteDatabase.CreateOrOpenFileDatabase(databaseFileFullPath,
                                                                          databaseScriptFullPath);

                Notify(new TextNotification("Start synchronization."));
                _view.ShowProgressBar();
                using (var unitOfWork = new SqLiteUnitOfWork(_sqLiteDatabase)) {

                    try {
                        // Customers synchronization
                        Notify(new TextNotification("Customers synchronization"));
                        var customerDtoRepository = new WebRepository<CustomerDto>(webConnectionFactory);
                        var customerSqLiteRepository = new CustomerRepository(unitOfWork);
                        DtoTranslator<Customer, CustomerDto> customerTranslator =
                            new CustomerTranslator(new ShippingAddressRepository(unitOfWork));

                        Command<CustomerDto, Customer> customerSyncCmd = _viewModel.SynchronizeFully
                                                                             ? new SynchronizationCommand
                                                                                   <CustomerDto, Customer>(
                                                                                   customerDtoRepository,
                                                                                   customerSqLiteRepository,
                                                                                   customerTranslator, 
                                                                                   unitOfWork,
                                                                                   bathSize)
                                                                             : new SynchronizationCommand
                                                                                   <CustomerDto, Customer>(
                                                                                   customerDtoRepository,
                                                                                   customerSqLiteRepository,
                                                                                   customerTranslator,
                                                                                   unitOfWork, 
                                                                                   bathSize,
                                                                                   _viewModel
                                                                                       .LastSynchronizationDate);

                        customerSyncCmd = customerSyncCmd.RepeatOnError(3, 5000);
                        customerSyncCmd.Execute();
                        Notify(new ProgressNotification(7));

                        // Shipping addresses synchronization
                        Notify(new TextNotification("Shipping addresses synchronization"));
                        var shippingAddressDtoRepository = new WebRepository<ShippingAddressDto>(webConnectionFactory);
                        var shippingAddressSqLiteRepository = new ShippingAddressRepository(unitOfWork);
                        DtoTranslator<ShippingAddress, ShippingAddressDto> shippingAddressdTranslator =
                            new ShippingAddressdTranslator();

                        Command<ShippingAddressDto, ShippingAddress> shippingAddressSyncCmd =
                            _viewModel.SynchronizeFully
                                ? new SynchronizationCommand
                                      <ShippingAddressDto,
                                      ShippingAddress>(
                                      shippingAddressDtoRepository,
                                      shippingAddressSqLiteRepository,
                                      shippingAddressdTranslator,
                                      unitOfWork,
                                      bathSize)
                                : new SynchronizationCommand
                                      <ShippingAddressDto,
                                      ShippingAddress>(
                                      shippingAddressDtoRepository,
                                      shippingAddressSqLiteRepository,
                                      shippingAddressdTranslator,
                                      unitOfWork,
                                      bathSize,
                                      _viewModel
                                          .LastSynchronizationDate);
                        shippingAddressSyncCmd = shippingAddressSyncCmd.RepeatOnError(3, 5000);
                        shippingAddressSyncCmd.Execute();
                        Notify(new ProgressNotification(15));

                        // My shipping addresses synchronization
                        Notify(new TextNotification("My shipping addresses synchronization"));
                        var myShippingAddressDtoRepository =
                            new WebRepository<MyShippingAddressDto>(webConnectionFactory);
                        shippingAddressSqLiteRepository = new ShippingAddressRepository(unitOfWork);
                        Command<MyShippingAddressDto, ShippingAddress> myShippingAddressSyncCmd =
                            _viewModel.SynchronizeFully
                                ? new MyShippingAddressesSynchronization(
                                      myShippingAddressDtoRepository,
                                      shippingAddressSqLiteRepository,
                                      unitOfWork,
                                      bathSize)
                                : new MyShippingAddressesSynchronization(
                                      myShippingAddressDtoRepository,
                                      shippingAddressSqLiteRepository,
                                      unitOfWork, 
                                      bathSize,
                                      _viewModel.LastSynchronizationDate);

                        myShippingAddressSyncCmd = myShippingAddressSyncCmd.RepeatOnError(3, 5000);
                        myShippingAddressSyncCmd.Execute();
                        Notify(new ProgressNotification(22));

                        // Categories synchronization
                        Notify(new TextNotification("Categories synchronization"));
                        var categoriesDtoRepository = new WebRepository<CategoryDto>(webConnectionFactory);
                        var categorySqLiteRepository = new CategoryRepository(unitOfWork);
                        DtoTranslator<Category, CategoryDto> categoriesTranslator = new CategoryTranslator();
                        Command<CategoryDto, Category> categoriesSyncCmd = _viewModel.SynchronizeFully
                                                                               ? new CategotiesSynchronization(
                                                                                     categoriesDtoRepository,
                                                                                     categorySqLiteRepository,
                                                                                     categoriesTranslator,
                                                                                     unitOfWork, bathSize)
                                                                               : new CategotiesSynchronization(
                                                                                     categoriesDtoRepository,
                                                                                     categorySqLiteRepository,
                                                                                     categoriesTranslator,
                                                                                     unitOfWork, bathSize,
                                                                                     _viewModel.LastSynchronizationDate);

                        categoriesSyncCmd = categoriesSyncCmd.RepeatOnError(3, 5000);
                        categoriesSyncCmd.Execute();
                        Notify(new ProgressNotification(30));

                        // Statuses synchronization
                        Notify(new TextNotification("Statuses synchronization"));
                        var statusDtoRepository = new WebRepository<StatusDto>(webConnectionFactory);
                        var statusSqLiteRepository = new StatusRepository(unitOfWork);
                        DtoTranslator<Status, StatusDto> statusTranslator = new StatusTranslator();

                        Command<StatusDto, Status> statusSyncCommand = _viewModel.SynchronizeFully
                                                                           ? new SynchronizationCommand
                                                                                 <StatusDto, Status>(
                                                                                 statusDtoRepository,
                                                                                 statusSqLiteRepository,
                                                                                 statusTranslator,
                                                                                 unitOfWork, bathSize)
                                                                           : new SynchronizationCommand
                                                                                 <StatusDto, Status>(
                                                                                 statusDtoRepository,
                                                                                 statusSqLiteRepository,
                                                                                 statusTranslator,
                                                                                 unitOfWork, bathSize,
                                                                                 _viewModel
                                                                                     .LastSynchronizationDate);

                        statusSyncCommand = statusSyncCommand.RepeatOnError(3, 5000);
                        statusSyncCommand.Execute();
                        Notify(new ProgressNotification(37));

                        // Warehouses synchronization
                        Notify(new TextNotification("Warehouses synchronization"));
                        var warehouseDtoRepository = new WebRepository<WarehouseDto>(webConnectionFactory);
                        var warehouseSqLiteRepository = new WarehouseRepository(unitOfWork);
                        DtoTranslator<Warehouse, WarehouseDto> warehouseTranslator = new WarehouseTranslator();

                        Command<WarehouseDto, Warehouse> warehouseSyncCommand = _viewModel.SynchronizeFully
                                                                                    ? new SynchronizationCommand
                                                                                          <WarehouseDto, Warehouse>(
                                                                                          warehouseDtoRepository,
                                                                                          warehouseSqLiteRepository,
                                                                                          warehouseTranslator,
                                                                                          unitOfWork, bathSize)
                                                                                    : new SynchronizationCommand
                                                                                          <WarehouseDto, Warehouse>(
                                                                                          warehouseDtoRepository,
                                                                                          warehouseSqLiteRepository,
                                                                                          warehouseTranslator,
                                                                                          unitOfWork, bathSize,
                                                                                          _viewModel
                                                                                              .LastSynchronizationDate);

                        warehouseSyncCommand = warehouseSyncCommand.RepeatOnError(3, 5000);
                        warehouseSyncCommand.Execute();
                        Notify(new ProgressNotification(45));

                        // Price lists synchronization
                        Notify(new TextNotification("Price lists synchronization"));
                        var priceListDtoRepository = new WebRepository<PriceListDto>(webConnectionFactory);
                        var priceListSqLiteRepository = new PriceListRepository(unitOfWork);
                        DtoTranslator<PriceList, PriceListDto> priceListTranslator = new PriceListTranslator();

                        Command<PriceListDto, PriceList> priceListSyncCommand = _viewModel.SynchronizeFully
                                                                                    ? new SynchronizationCommand
                                                                                          <PriceListDto, PriceList>(
                                                                                          priceListDtoRepository,
                                                                                          priceListSqLiteRepository,
                                                                                          priceListTranslator,
                                                                                          unitOfWork, bathSize)
                                                                                    : new SynchronizationCommand
                                                                                          <PriceListDto, PriceList>(
                                                                                          priceListDtoRepository,
                                                                                          priceListSqLiteRepository,
                                                                                          priceListTranslator,
                                                                                          unitOfWork, bathSize,
                                                                                          _viewModel
                                                                                              .LastSynchronizationDate);

                        priceListSyncCommand = priceListSyncCommand.RepeatOnError(3, 5000);
                        priceListSyncCommand.Execute();
                        Notify(new ProgressNotification(52));

                        // UnitOfMeasures synchronization
                        Notify(new TextNotification("UnitOfMeasures synchronization"));
                        var unitOfMeasureDtoRepository = new WebRepository<UnitOfMeasureDto>(webConnectionFactory);
                        var unitOfMeasureSqLiteRepository = new UnitOfMeasureRepository(unitOfWork);
                        DtoTranslator<UnitOfMeasure, UnitOfMeasureDto> unitOfMeasureTranslator =
                            new UnitOfMeasureTranslator();

                        Command<UnitOfMeasureDto, UnitOfMeasure> unitOfMeasureSyncCommand = _viewModel.SynchronizeFully
                                                                                                ? new SynchronizationCommand
                                                                                                      <UnitOfMeasureDto,
                                                                                                      UnitOfMeasure>(
                                                                                                      unitOfMeasureDtoRepository,
                                                                                                      unitOfMeasureSqLiteRepository,
                                                                                                      unitOfMeasureTranslator,
                                                                                                      unitOfWork,
                                                                                                      bathSize)
                                                                                                : new SynchronizationCommand
                                                                                                      <UnitOfMeasureDto,
                                                                                                      UnitOfMeasure>(
                                                                                                      unitOfMeasureDtoRepository,
                                                                                                      unitOfMeasureSqLiteRepository,
                                                                                                      unitOfMeasureTranslator,
                                                                                                      unitOfWork,
                                                                                                      bathSize,
                                                                                                      _viewModel
                                                                                                          .LastSynchronizationDate);

                        unitOfMeasureSyncCommand = unitOfMeasureSyncCommand.RepeatOnError(3, 5000);
                        unitOfMeasureSyncCommand.Execute();
                        Notify(new ProgressNotification(60));

                        // Products synchronization
                        Notify(new TextNotification("Products synchronization"));
                        var productDtoRepository = new WebRepository<ProductDto>(webConnectionFactory);
                        var productSqLiteRepository = new ProductRepository(unitOfWork);
                        DtoTranslator<Product, ProductDto> productTranslator = new ProductTranslator();

                        Command<ProductDto, Product> productSyncCommand = _viewModel.SynchronizeFully
                                                                              ? new SynchronizationCommand
                                                                                    <ProductDto, Product>(
                                                                                    productDtoRepository,
                                                                                    productSqLiteRepository,
                                                                                    productTranslator,
                                                                                    unitOfWork,
                                                                                    bathSize)
                                                                              : new SynchronizationCommand
                                                                                    <ProductDto, Product>(
                                                                                    productDtoRepository,
                                                                                    productSqLiteRepository,
                                                                                    productTranslator,
                                                                                    unitOfWork, bathSize,
                                                                                    _viewModel
                                                                                        .LastSynchronizationDate);
                        productSyncCommand = productSyncCommand.RepeatOnError(3, 5000);
                        productSyncCommand.Execute();
                        Notify(new ProgressNotification(67));

                        // Product prices synchronization
                        Notify(new TextNotification("Product prices synchronization"));
                        var productsPriceDtoRepository = new WebRepository<ProductPriceDto>(webConnectionFactory);
                        var productsPriceSqLiteRepository = new ProductsPriceRepository(unitOfWork);
                        DtoTranslator<ProductsPrice, ProductPriceDto> productsPriceTranslator =
                            new ProductsPriceTranslator();

                        Command<ProductPriceDto, ProductsPrice> productsPricesSyncCommand = _viewModel.SynchronizeFully
                                                                                                ? new SynchronizationCommand
                                                                                                      <ProductPriceDto,
                                                                                                      ProductsPrice>(
                                                                                                      productsPriceDtoRepository,
                                                                                                      productsPriceSqLiteRepository,
                                                                                                      productsPriceTranslator,
                                                                                                      unitOfWork,
                                                                                                      bathSize)
                                                                                                : new SynchronizationCommand
                                                                                                      <ProductPriceDto,
                                                                                                      ProductsPrice>(
                                                                                                      productsPriceDtoRepository,
                                                                                                      productsPriceSqLiteRepository,
                                                                                                      productsPriceTranslator,
                                                                                                      unitOfWork,
                                                                                                      bathSize,
                                                                                                      _viewModel
                                                                                                          .LastSynchronizationDate);

                        productsPricesSyncCommand = productsPricesSyncCommand.RepeatOnError(3, 5000);
                        productsPricesSyncCommand.Execute();
                        Notify(new ProgressNotification(75));

                        // Product units of measure synchronization
                        Notify(new TextNotification("Product units of measure synchronization"));
                        var productsUomDtoRepository = new WebRepository<ProductUnitOfMeasureDto>(webConnectionFactory);
                        var productsUnitOfMeasureSqLiteRepository = new ProductsUnitOfMeasureRepository(unitOfWork);
                        DtoTranslator<ProductsUnitOfMeasure, ProductUnitOfMeasureDto> productsUnitOfMeasureTranslator =
                            new ProductsUnitOfMeasureTranslator();

                        Command<ProductUnitOfMeasureDto, ProductsUnitOfMeasure> productsUomSyncCommand =
                            _viewModel.SynchronizeFully
                                ? new SynchronizationCommand
                                      <ProductUnitOfMeasureDto, ProductsUnitOfMeasure>(
                                      productsUomDtoRepository, productsUnitOfMeasureSqLiteRepository,
                                      productsUnitOfMeasureTranslator,
                                      unitOfWork, bathSize)
                                : new SynchronizationCommand
                                      <ProductUnitOfMeasureDto, ProductsUnitOfMeasure>(
                                      productsUomDtoRepository, productsUnitOfMeasureSqLiteRepository,
                                      productsUnitOfMeasureTranslator,
                                      unitOfWork, bathSize,
                                      _viewModel.LastSynchronizationDate);

                        productsUomSyncCommand = productsUomSyncCommand.RepeatOnError(3, 5000);
                        productsUomSyncCommand.Execute();
                        Notify(new ProgressNotification(82));

                        // Route templates synchronization
                        Notify(new TextNotification("Route templates synchronization"));
                        var routeTemplateDtoRepository = new WebRepository<RouteTemplateDto>(webConnectionFactory);
                        var routeTemplateSqLiteRepository = new RouteTemplateRepository(unitOfWork);
                        DtoTranslator<RouteTemplate, RouteTemplateDto> routeTemplateTranslator =
                            new RouteTemplateTranslator();

                        Command<RouteTemplateDto, RouteTemplate> routeTemplateSyncCommand = _viewModel.SynchronizeFully
                                                                                                ? new SynchronizationCommand
                                                                                                      <RouteTemplateDto,
                                                                                                      RouteTemplate>(
                                                                                                      routeTemplateDtoRepository,
                                                                                                      routeTemplateSqLiteRepository,
                                                                                                      routeTemplateTranslator,
                                                                                                      unitOfWork,
                                                                                                      bathSize)
                                                                                                : new SynchronizationCommand
                                                                                                      <RouteTemplateDto,
                                                                                                      RouteTemplate>(
                                                                                                      routeTemplateDtoRepository,
                                                                                                      routeTemplateSqLiteRepository,
                                                                                                      routeTemplateTranslator,
                                                                                                      unitOfWork,
                                                                                                      bathSize,
                                                                                                      _viewModel
                                                                                                          .LastSynchronizationDate);

                        routeTemplateSyncCommand = routeTemplateSyncCommand.RepeatOnError(3, 5000);
                        routeTemplateSyncCommand.Execute();
                        Notify(new ProgressNotification(90));

                        // Route points templates synchronization
                        Notify(new TextNotification("Route points templates synchronization"));
                        var routePointTemplateDtoRepository =
                            new WebRepository<RoutePointTemplateDto>(webConnectionFactory);
                        var routePointTemplateSqLiteRepository = new RoutePointTemplateRepository(unitOfWork);
                        DtoTranslator<RoutePointTemplate, RoutePointTemplateDto> routePointTemplateTranslator =
                            new RoutePointTemplateTranslator();

                        Command<RoutePointTemplateDto, RoutePointTemplate> routePointTemplateSyncCommand =
                            _viewModel.SynchronizeFully
                                ? new SynchronizationCommand
                                      <RoutePointTemplateDto, RoutePointTemplate>(
                                      routePointTemplateDtoRepository,
                                      routePointTemplateSqLiteRepository,
                                      routePointTemplateTranslator,
                                      unitOfWork, bathSize)
                                : new SynchronizationCommand
                                      <RoutePointTemplateDto, RoutePointTemplate>(
                                      routePointTemplateDtoRepository,
                                      routePointTemplateSqLiteRepository,
                                      routePointTemplateTranslator,
                                      unitOfWork, bathSize,
                                      _viewModel.LastSynchronizationDate);

                        routePointTemplateSyncCommand = routePointTemplateSyncCommand.RepeatOnError(3, 5000);
                        routePointTemplateSyncCommand.Execute();
                        Notify(new ProgressNotification(100));

                        _configurationManager.GetConfig("Common")
                                             .GetSection("Synchronization")
                                             .GetSetting("LastSyncDate").Value =
                            synchronizationDate.ToString(CultureInfo.InvariantCulture);
                    }
                    catch(Exception exception) {
                        Notify(new TextNotification("Synchronization failed"));
                        Log.Error("Synchronization failed", exception);
                    }
                }
            }
            _view.CloseView();
        }

        public void Cancel() {
            try {
                if (_thread != null)
                    _thread.Abort();
            }
            catch (ThreadAbortException threadAbortException) {
                Log.Error("Synchronization cancelation error", threadAbortException);
            }
        }

        #region IObserver

        public void Notify(INotification notification)
        {
            if (notification is TextNotification)
            {
                var textNotification = notification as TextNotification;
                _view.UpdateStatus(textNotification.Text);
            }
            else if (notification is ProgressNotification)
            {
                var progressNotification = notification as ProgressNotification;
                _view.UpdateProgress(progressNotification.Progress);
            }
        }

        #endregion

        private SynchronizationViewModel _viewModel;
        public SynchronizationViewModel InitializeView() {

            DateTime lastSynchronizationDate = DateTime.MinValue;
            if (_configurationManager.GetConfig("Common")
                                     .GetSection("Synchronization")
                                     .GetSetting("LastSyncDate").Value != string.Empty)
                lastSynchronizationDate = _configurationManager.GetConfig("Common")
                                                               .GetSection("Synchronization")
                                                               .GetSetting("LastSyncDate").As<DateTime>();
            _viewModel = new SynchronizationViewModel
                {
                    SynchronizeFully = false,
                    LastSynchronizationDate = lastSynchronizationDate
                };
            return _viewModel;
        }
    }
}
