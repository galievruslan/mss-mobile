using System;
using System.Globalization;
using System.Threading;
using MSS.WinMobile.Application.Configuration;
using MSS.WinMobile.Application.Environment;
using MSS.WinMobile.Common.Observable;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Sqlite.ModelTranslators;
using MSS.WinMobile.Infrastructure.Storage;
using MSS.WinMobile.Infrastructure.Web;
using MSS.WinMobile.Infrastructure.Web.Repositories;
using MSS.WinMobile.Infrastructure.Web.Repositories.Dtos;
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
        private readonly IStorageManager _storageManager;
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;
        private readonly IRepositoryFactory _repositoryFactory;
        private readonly INavigator _navigator;

        public SynchronizationPresenter(ISynchronizationView view, 
            IStorageManager storageManager, 
            IUnitOfWorkFactory unitOfWorkFactory, 
            IRepositoryFactory repositoryFactory,
            INavigator navigator) {
            _configurationManager = new ConfigurationManager(Environments.AppPath);
            _view = view;

            _storageManager = storageManager;
            _unitOfWorkFactory = unitOfWorkFactory;
            _repositoryFactory = repositoryFactory;
            _navigator = navigator;
        }

        private Thread _thread;
        public void Synchronize() {
            _view.MakeInactive();

            _thread = new Thread(RunSynchronizationInBackground);
            _thread.Start();
        }

        private void RunSynchronizationInBackground() {
            try {
                var serverAddress =
                    _configurationManager.GetConfig("Common")
                                         .GetSection("Server")
                                         .GetSetting("Address")
                                         .Value;
                var username =
                    _configurationManager.GetConfig("Common")
                                         .GetSection("Server")
                                         .GetSetting("Username")
                                         .Value;
                var password =
                    _configurationManager.GetConfig("Common")
                                         .GetSection("Server")
                                         .GetSetting("Password")
                                         .Value;
                var bathSize =
                    _configurationManager.GetConfig("Common")
                                         .GetSection("Synchronization")
                                         .GetSetting("BathSize")
                                         .As<int>();

                var databaseName =
                    _configurationManager.GetConfig("Common")
                                         .GetSection("Database")
                                         .GetSetting("FileName")
                                         .Value;
                var schemaScript =
                    _configurationManager.GetConfig("Common")
                                         .GetSection("Database")
                                         .GetSetting("SchemaScript")
                                         .Value;

                using (IWebServer webServer = new WebServer(serverAddress, username, password)) {
                    Notify(new TextNotification("Start synchronization."));
                    _view.ShowProgressBar();


                    Notify(new TextNotification("Routes synchronization"));
                    var routesRepository = _repositoryFactory.CreateRepository<Route>();
                    var routePointsRepository = _repositoryFactory.CreateRepository<RoutePoint>();
                    var routesSyncCmd =
                        new RoutesSynchronization(webServer, routesRepository, routePointsRepository,
                                                  _unitOfWorkFactory).RepeatOnError(3, 5000);
                    routesSyncCmd.Execute();

                    Notify(new TextNotification("Orders synchronization"));
                    var ordersRepository = _repositoryFactory.CreateRepository<Order>();
                    var ordersSyncCmd =
                        new OrdersSynchronization(webServer, ordersRepository,
                                                  _unitOfWorkFactory).RepeatOnError(3, 5000);
                    ordersSyncCmd.Execute();

                    if (_viewModel.SynchronizeFully) {
                        Notify(new TextNotification("Clear Database"));
                        _storageManager.DeleteCurrentStorage();

                        // Initialization
                        string databaseScriptFullPath = Environments.AppPath + schemaScript;
                        string databaseFileFullPath = Environments.AppPath + databaseName;
                        _storageManager.CreateOrOpenStorage(databaseFileFullPath,
                                                            databaseScriptFullPath);
                    }

                    DateTime synchronizationDate = webServer.Connect().ServerTime();

                    // Customers synchronization
                    Notify(new TextNotification("Customers synchronization"));
                    var customerDtoRepository = new WebRepository<CustomerDto>(webServer);
                    var customerRepository = _repositoryFactory.CreateRepository<Customer>();
                    DtoTranslator<Customer, CustomerDto> customerTranslator =
                        new CustomerTranslator(_repositoryFactory);

                    Command<CustomerDto, Customer> customerSyncCmd = _viewModel.SynchronizeFully
                                                                         ? new SynchronizationCommand
                                                                               <CustomerDto,
                                                                               Customer>(
                                                                               customerDtoRepository,
                                                                               customerRepository,
                                                                               customerTranslator,
                                                                               _unitOfWorkFactory,
                                                                               bathSize)
                                                                         : new SynchronizationCommand
                                                                               <CustomerDto,
                                                                               Customer>(
                                                                               customerDtoRepository,
                                                                               customerRepository,
                                                                               customerTranslator,
                                                                               _unitOfWorkFactory,
                                                                               bathSize,
                                                                               _viewModel
                                                                                   .LastSynchronizationDate);

                    customerSyncCmd = customerSyncCmd.RepeatOnError(3, 5000);
                    customerSyncCmd.Execute();
                    Notify(new ProgressNotification(7));

                    // Shipping addresses synchronization
                    Notify(new TextNotification("Shipping addresses synchronization"));
                    var shippingAddressDtoRepository =
                        new WebRepository<ShippingAddressDto>(webServer);
                    var shippingAddressSqLiteRepository =
                        _repositoryFactory.CreateRepository<ShippingAddress>();
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
                                  _unitOfWorkFactory,
                                  bathSize)
                            : new SynchronizationCommand
                                  <ShippingAddressDto,
                                  ShippingAddress>(
                                  shippingAddressDtoRepository,
                                  shippingAddressSqLiteRepository,
                                  shippingAddressdTranslator,
                                  _unitOfWorkFactory,
                                  bathSize,
                                  _viewModel
                                      .LastSynchronizationDate);
                    shippingAddressSyncCmd = shippingAddressSyncCmd.RepeatOnError(3, 5000);
                    shippingAddressSyncCmd.Execute();
                    Notify(new ProgressNotification(15));

                    // My shipping addresses synchronization
                    Notify(new TextNotification("My shipping addresses synchronization"));
                    var myShippingAddressDtoRepository =
                        new WebRepository<MyShippingAddressDto>(webServer);
                    shippingAddressSqLiteRepository =
                        _repositoryFactory.CreateRepository<ShippingAddress>();
                    Command<MyShippingAddressDto, ShippingAddress> myShippingAddressSyncCmd =
                        _viewModel.SynchronizeFully
                            ? new MyShippingAddressesSynchronization(
                                  myShippingAddressDtoRepository,
                                  shippingAddressSqLiteRepository,
                                  _unitOfWorkFactory,
                                  bathSize)
                            : new MyShippingAddressesSynchronization(
                                  myShippingAddressDtoRepository,
                                  shippingAddressSqLiteRepository,
                                  _unitOfWorkFactory,
                                  bathSize,
                                  _viewModel.LastSynchronizationDate);

                    myShippingAddressSyncCmd = myShippingAddressSyncCmd.RepeatOnError(3, 5000);
                    myShippingAddressSyncCmd.Execute();
                    Notify(new ProgressNotification(22));

                    // Categories synchronization
                    Notify(new TextNotification("Categories synchronization"));
                    var categoriesDtoRepository = new WebRepository<CategoryDto>(webServer);
                    var categorySqLiteRepository =
                        _repositoryFactory.CreateRepository<Category>();
                    DtoTranslator<Category, CategoryDto> categoriesTranslator =
                        new CategoryTranslator();
                    Command<CategoryDto, Category> categoriesSyncCmd = _viewModel.SynchronizeFully
                                                                           ? new CategotiesSynchronization
                                                                                 (
                                                                                 categoriesDtoRepository,
                                                                                 categorySqLiteRepository,
                                                                                 categoriesTranslator,
                                                                                 _unitOfWorkFactory,
                                                                                 bathSize)
                                                                           : new CategotiesSynchronization
                                                                                 (
                                                                                 categoriesDtoRepository,
                                                                                 categorySqLiteRepository,
                                                                                 categoriesTranslator,
                                                                                 _unitOfWorkFactory,
                                                                                 bathSize,
                                                                                 _viewModel
                                                                                     .LastSynchronizationDate);

                    categoriesSyncCmd = categoriesSyncCmd.RepeatOnError(3, 5000);
                    categoriesSyncCmd.Execute();
                    Notify(new ProgressNotification(30));

                    // Statuses synchronization
                    Notify(new TextNotification("Statuses synchronization"));
                    var statusDtoRepository = new WebRepository<StatusDto>(webServer);
                    var statusSqLiteRepository =
                        _repositoryFactory.CreateRepository<Status>();
                    DtoTranslator<Status, StatusDto> statusTranslator = new StatusTranslator();

                    Command<StatusDto, Status> statusSyncCommand = _viewModel.SynchronizeFully
                                                                       ? new SynchronizationCommand
                                                                             <StatusDto, Status>(
                                                                             statusDtoRepository,
                                                                             statusSqLiteRepository,
                                                                             statusTranslator,
                                                                             _unitOfWorkFactory,
                                                                             bathSize)
                                                                       : new SynchronizationCommand
                                                                             <StatusDto, Status>(
                                                                             statusDtoRepository,
                                                                             statusSqLiteRepository,
                                                                             statusTranslator,
                                                                             _unitOfWorkFactory,
                                                                             bathSize,
                                                                             _viewModel
                                                                                 .LastSynchronizationDate);

                    statusSyncCommand = statusSyncCommand.RepeatOnError(3, 5000);
                    statusSyncCommand.Execute();
                    Notify(new ProgressNotification(37));

                    // Warehouses synchronization
                    Notify(new TextNotification("Warehouses synchronization"));
                    var warehouseDtoRepository = new WebRepository<WarehouseDto>(webServer);
                    var warehouseSqLiteRepository =
                        _repositoryFactory.CreateRepository<Warehouse>();
                    DtoTranslator<Warehouse, WarehouseDto> warehouseTranslator =
                        new WarehouseTranslator();

                    Command<WarehouseDto, Warehouse> warehouseSyncCommand =
                        _viewModel.SynchronizeFully
                            ? new SynchronizationCommand
                                  <WarehouseDto, Warehouse>(
                                  warehouseDtoRepository,
                                  warehouseSqLiteRepository,
                                  warehouseTranslator,
                                  _unitOfWorkFactory, bathSize)
                            : new SynchronizationCommand
                                  <WarehouseDto, Warehouse>(
                                  warehouseDtoRepository,
                                  warehouseSqLiteRepository,
                                  warehouseTranslator,
                                  _unitOfWorkFactory, bathSize,
                                  _viewModel
                                      .LastSynchronizationDate);

                    warehouseSyncCommand = warehouseSyncCommand.RepeatOnError(3, 5000);
                    warehouseSyncCommand.Execute();
                    Notify(new ProgressNotification(45));

                    // Price lists synchronization
                    Notify(new TextNotification("Price lists synchronization"));
                    var priceListDtoRepository = new WebRepository<PriceListDto>(webServer);
                    var priceListSqLiteRepository =
                        _repositoryFactory.CreateRepository<PriceList>();
                    DtoTranslator<PriceList, PriceListDto> priceListTranslator =
                        new PriceListTranslator(_repositoryFactory);

                    Command<PriceListDto, PriceList> priceListSyncCommand =
                        _viewModel.SynchronizeFully
                            ? new SynchronizationCommand
                                  <PriceListDto, PriceList>(
                                  priceListDtoRepository,
                                  priceListSqLiteRepository,
                                  priceListTranslator,
                                  _unitOfWorkFactory, bathSize)
                            : new SynchronizationCommand
                                  <PriceListDto, PriceList>(
                                  priceListDtoRepository,
                                  priceListSqLiteRepository,
                                  priceListTranslator,
                                  _unitOfWorkFactory, bathSize,
                                  _viewModel
                                      .LastSynchronizationDate);

                    priceListSyncCommand = priceListSyncCommand.RepeatOnError(3, 5000);
                    priceListSyncCommand.Execute();
                    Notify(new ProgressNotification(52));

                    // UnitOfMeasures synchronization
                    Notify(new TextNotification("UnitOfMeasures synchronization"));
                    var unitOfMeasureDtoRepository = new WebRepository<UnitOfMeasureDto>(webServer);
                    var unitOfMeasureSqLiteRepository =
                        _repositoryFactory.CreateRepository<UnitOfMeasure>();
                    DtoTranslator<UnitOfMeasure, UnitOfMeasureDto> unitOfMeasureTranslator =
                        new UnitOfMeasureTranslator();

                    Command<UnitOfMeasureDto, UnitOfMeasure> unitOfMeasureSyncCommand =
                        _viewModel.SynchronizeFully
                            ? new SynchronizationCommand
                                  <UnitOfMeasureDto,
                                  UnitOfMeasure>(
                                  unitOfMeasureDtoRepository,
                                  unitOfMeasureSqLiteRepository,
                                  unitOfMeasureTranslator,
                                  _unitOfWorkFactory,
                                  bathSize)
                            : new SynchronizationCommand
                                  <UnitOfMeasureDto,
                                  UnitOfMeasure>(
                                  unitOfMeasureDtoRepository,
                                  unitOfMeasureSqLiteRepository,
                                  unitOfMeasureTranslator,
                                  _unitOfWorkFactory,
                                  bathSize,
                                  _viewModel
                                      .LastSynchronizationDate);

                    unitOfMeasureSyncCommand = unitOfMeasureSyncCommand.RepeatOnError(3, 5000);
                    unitOfMeasureSyncCommand.Execute();
                    Notify(new ProgressNotification(60));

                    // Products synchronization
                    Notify(new TextNotification("Products synchronization"));
                    var productDtoRepository = new WebRepository<ProductDto>(webServer);
                    var productSqLiteRepository =
                        _repositoryFactory.CreateRepository<Product>();
                    DtoTranslator<Product, ProductDto> productTranslator =
                        new ProductTranslator(_repositoryFactory);

                    Command<ProductDto, Product> productSyncCommand = _viewModel.SynchronizeFully
                                                                          ? new SynchronizationCommand
                                                                                <ProductDto, Product
                                                                                >(
                                                                                productDtoRepository,
                                                                                productSqLiteRepository,
                                                                                productTranslator,
                                                                                _unitOfWorkFactory,
                                                                                bathSize)
                                                                          : new SynchronizationCommand
                                                                                <ProductDto, Product
                                                                                >(
                                                                                productDtoRepository,
                                                                                productSqLiteRepository,
                                                                                productTranslator,
                                                                                _unitOfWorkFactory,
                                                                                bathSize,
                                                                                _viewModel
                                                                                    .LastSynchronizationDate);
                    productSyncCommand = productSyncCommand.RepeatOnError(3, 5000);
                    productSyncCommand.Execute();
                    Notify(new ProgressNotification(67));

                    // Product prices synchronization
                    Notify(new TextNotification("Product prices synchronization"));
                    var productsPriceDtoRepository = new WebRepository<ProductPriceDto>(webServer);
                    var productsPriceSqLiteRepository =
                        _repositoryFactory.CreateRepository<ProductsPrice>();
                    DtoTranslator<ProductsPrice, ProductPriceDto> productsPriceTranslator =
                        new ProductsPriceTranslator();

                    Command<ProductPriceDto, ProductsPrice> productsPricesSyncCommand =
                        _viewModel.SynchronizeFully
                            ? new SynchronizationCommand
                                  <ProductPriceDto,
                                  ProductsPrice>(
                                  productsPriceDtoRepository,
                                  productsPriceSqLiteRepository,
                                  productsPriceTranslator,
                                  _unitOfWorkFactory,
                                  bathSize)
                            : new SynchronizationCommand
                                  <ProductPriceDto,
                                  ProductsPrice>(
                                  productsPriceDtoRepository,
                                  productsPriceSqLiteRepository,
                                  productsPriceTranslator,
                                  _unitOfWorkFactory,
                                  bathSize,
                                  _viewModel
                                      .LastSynchronizationDate);

                    productsPricesSyncCommand = productsPricesSyncCommand.RepeatOnError(3, 5000);
                    productsPricesSyncCommand.Execute();
                    Notify(new ProgressNotification(75));

                    // Product units of measure synchronization
                    Notify(new TextNotification("Product units of measure synchronization"));
                    var productsUomDtoRepository =
                        new WebRepository<ProductUnitOfMeasureDto>(webServer);
                    var productsUnitOfMeasureSqLiteRepository =
                        _repositoryFactory.CreateRepository<ProductsUnitOfMeasure>();
                    DtoTranslator<ProductsUnitOfMeasure, ProductUnitOfMeasureDto>
                        productsUnitOfMeasureTranslator =
                            new ProductsUnitOfMeasureTranslator();

                    Command<ProductUnitOfMeasureDto, ProductsUnitOfMeasure> productsUomSyncCommand =
                        _viewModel.SynchronizeFully
                            ? new SynchronizationCommand
                                  <ProductUnitOfMeasureDto, ProductsUnitOfMeasure>(
                                  productsUomDtoRepository, productsUnitOfMeasureSqLiteRepository,
                                  productsUnitOfMeasureTranslator,
                                  _unitOfWorkFactory, bathSize)
                            : new SynchronizationCommand
                                  <ProductUnitOfMeasureDto, ProductsUnitOfMeasure>(
                                  productsUomDtoRepository, productsUnitOfMeasureSqLiteRepository,
                                  productsUnitOfMeasureTranslator,
                                  _unitOfWorkFactory, bathSize,
                                  _viewModel.LastSynchronizationDate);

                    productsUomSyncCommand = productsUomSyncCommand.RepeatOnError(3, 5000);
                    productsUomSyncCommand.Execute();
                    Notify(new ProgressNotification(82));

                    // GoToRoute templates synchronization
                    Notify(new TextNotification("GoToRoute templates synchronization"));
                    var routeTemplateDtoRepository = new WebRepository<RouteTemplateDto>(webServer);
                    var routeTemplateSqLiteRepository =
                        _repositoryFactory.CreateRepository<RouteTemplate>();
                    DtoTranslator<RouteTemplate, RouteTemplateDto> routeTemplateTranslator =
                        new RouteTemplateTranslator(_repositoryFactory);

                    Command<RouteTemplateDto, RouteTemplate> routeTemplateSyncCommand =
                        _viewModel.SynchronizeFully
                            ? new SynchronizationCommand
                                  <RouteTemplateDto,
                                  RouteTemplate>(
                                  routeTemplateDtoRepository,
                                  routeTemplateSqLiteRepository,
                                  routeTemplateTranslator,
                                  _unitOfWorkFactory,
                                  bathSize)
                            : new SynchronizationCommand
                                  <RouteTemplateDto,
                                  RouteTemplate>(
                                  routeTemplateDtoRepository,
                                  routeTemplateSqLiteRepository,
                                  routeTemplateTranslator,
                                  _unitOfWorkFactory,
                                  bathSize,
                                  _viewModel
                                      .LastSynchronizationDate);

                    routeTemplateSyncCommand = routeTemplateSyncCommand.RepeatOnError(3, 5000);
                    routeTemplateSyncCommand.Execute();
                    Notify(new ProgressNotification(90));

                    // GoToRoute points templates synchronization
                    Notify(new TextNotification("GoToRoute points templates synchronization"));
                    var routePointTemplateDtoRepository =
                        new WebRepository<RoutePointTemplateDto>(webServer);
                    var routePointTemplateSqLiteRepository =
                        _repositoryFactory.CreateRepository<RoutePointTemplate>();
                    DtoTranslator<RoutePointTemplate, RoutePointTemplateDto>
                        routePointTemplateTranslator =
                            new RoutePointTemplateTranslator();

                    Command<RoutePointTemplateDto, RoutePointTemplate> routePointTemplateSyncCommand
                        =
                        _viewModel.SynchronizeFully
                            ? new SynchronizationCommand
                                  <RoutePointTemplateDto, RoutePointTemplate>(
                                  routePointTemplateDtoRepository,
                                  routePointTemplateSqLiteRepository,
                                  routePointTemplateTranslator,
                                  _unitOfWorkFactory, bathSize)
                            : new SynchronizationCommand
                                  <RoutePointTemplateDto, RoutePointTemplate>(
                                  routePointTemplateDtoRepository,
                                  routePointTemplateSqLiteRepository,
                                  routePointTemplateTranslator,
                                  _unitOfWorkFactory, bathSize,
                                  _viewModel.LastSynchronizationDate);

                    routePointTemplateSyncCommand = routePointTemplateSyncCommand.RepeatOnError(3,
                                                                                                5000);
                    routePointTemplateSyncCommand.Execute();
                    Notify(new ProgressNotification(100));

                    _configurationManager.GetConfig("Common")
                                         .GetSection("Synchronization")
                                         .GetSetting("LastSyncDate").Value =
                        synchronizationDate.ToString(DateTimeFormatInfo.InvariantInfo);
                    _configurationManager.GetConfig("Common").Save();
                    _view.ShowInformation("Synchronization complete");
                }
            }
            catch (ThreadAbortException) {
            }
            catch (Exception exception) {
                Log.Error("Synchronization failed", exception);
                _view.ShowError("Synchronization failed");
            }
            finally {
                _view.MakeActive();
            }

            _view.ReturnToMenu();
        }

        public void Cancel() {
            try {
                if (_thread != null) {
                    _thread.Abort();
                    _thread.Join();
                }
            }
            catch (ThreadAbortException) {
                
            }
            finally {
                _view.MakeActive();
            }

            _view.ReturnToMenu();
        }

        public void ReturnToMenu() {
            _navigator.GoToMenu();
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
