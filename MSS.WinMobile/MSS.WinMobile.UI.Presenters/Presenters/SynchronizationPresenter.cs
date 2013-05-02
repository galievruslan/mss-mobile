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
using MSS.WinMobile.UI.Presenters.ViewModels;
using MSS.WinMobile.UI.Presenters.Views;
using log4net;

namespace MSS.WinMobile.UI.Presenters.Presenters
{
    public class SynchronizationPresenter : IPresenter, IObserver
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
            var username = _configurationManager.GetConfig("Common").GetSection("Server").GetSetting("Username").Value;
            var password = _configurationManager.GetConfig("Common").GetSection("Server").GetSetting("Password").Value;
            var bathSize = _configurationManager.GetConfig("Common").GetSection("Server").GetSetting("BathSize").As<int>();

            var databaseName =
                _configurationManager.GetConfig("Common").GetSection("Database").GetSetting("FileName").Value;
            var schemaScript =
                _configurationManager.GetConfig("Common").GetSection("Database").GetSetting("SchemaScript").Value;

            using (var webConnectionFactory = new WebConnectionFactory(new WebServer(serverAddress), username, password)) {
                if (_viewModel.SynchronizeFully) {
                    _sqLiteDatabase.UnitOfWork.Dispose();
                    _sqLiteDatabase.Delete();
                }

                DateTime synchronizationDate = webConnectionFactory.CurrentConnection.ServerTime();

                // Initialization
                string databaseScriptFullPath = Environments.AppPath + schemaScript;
                string databaseFileFullPath = Environments.AppPath + databaseName;
                _sqLiteDatabase = SqLiteDatabase.CreateOrOpenFileDatabase(databaseFileFullPath, databaseScriptFullPath);
                var unitOfWork = new SqLiteUnitOfWork(_sqLiteDatabase);

                // Customers synchronization
                var customerDtoRepository = new WebRepository<CustomerDto>(webConnectionFactory);
                var customerSqLiteRepository = new CustomerRepository(unitOfWork);
                DtoTranslator<Customer, CustomerDto> customerTranslator =
                    new CustomerTranslator(new ShippingAddressRepository(unitOfWork));

                var customerSyncCmd = _viewModel.SynchronizeFully
                                          ? new SynchronizationCommand
                                                <CustomerDto, Customer>(
                                                customerDtoRepository,
                                                customerSqLiteRepository,
                                                customerTranslator, bathSize)
                                          : new SynchronizationCommand
                                                <CustomerDto, Customer>(
                                                customerDtoRepository,
                                                customerSqLiteRepository,
                                                customerTranslator, bathSize,
                                                _viewModel
                                                    .LastSynchronizationDate);

                unitOfWork.BeginTransaction();
                customerSyncCmd.Execute();
                unitOfWork.Commit();

                // Shipping addresses synchronization
                var shippingAddressDtoRepository = new WebRepository<ShippingAddressDto>(webConnectionFactory);
                var shippingAddressSqLiteRepository = new ShippingAddressRepository(unitOfWork);
                DtoTranslator<ShippingAddress, ShippingAddressDto> shippingAddressdTranslator = new ShippingAddressdTranslator();

                var shippingAddressSyncCmd = _viewModel.SynchronizeFully
                                                 ? new SynchronizationCommand<ShippingAddressDto, ShippingAddress>(
                                                       shippingAddressDtoRepository, shippingAddressSqLiteRepository,
                                                       shippingAddressdTranslator, bathSize)
                                                 : new SynchronizationCommand<ShippingAddressDto, ShippingAddress>(
                                                       shippingAddressDtoRepository, shippingAddressSqLiteRepository,
                                                       shippingAddressdTranslator, bathSize,
                                                       _viewModel.LastSynchronizationDate);
                unitOfWork.BeginTransaction();
                shippingAddressSyncCmd.Execute();
                unitOfWork.Commit();

                // My shipping addresses synchronization
                var myShippingAddressDtoRepository = new WebRepository<MyShippingAddressDto>(webConnectionFactory);
                shippingAddressSqLiteRepository = new ShippingAddressRepository(unitOfWork);
                var myShippingAddressSyncCmd = _viewModel.SynchronizeFully
                                                   ? new MyShippingAddressesSynchronization(
                                                         myShippingAddressDtoRepository,
                                                         shippingAddressSqLiteRepository, bathSize)
                                                   : new MyShippingAddressesSynchronization(
                                                         myShippingAddressDtoRepository,
                                                         shippingAddressSqLiteRepository, bathSize,
                                                         _viewModel.LastSynchronizationDate);

                unitOfWork.BeginTransaction();
                myShippingAddressSyncCmd.Execute();
                unitOfWork.Commit();

                // Categories synchronization
                var categoriesDtoRepository = new WebRepository<CategoryDto>(webConnectionFactory);
                var categorySqLiteRepository = new CategoryRepository(unitOfWork);
                DtoTranslator<Category, CategoryDto> categoriesTranslator = new CategoryTranslator();
                var categoriesSyncCmd = _viewModel.SynchronizeFully
                                            ? new CategotiesSynchronization(categoriesDtoRepository,
                                                                            categorySqLiteRepository,
                                                                            categoriesTranslator, bathSize)
                                            : new CategotiesSynchronization(categoriesDtoRepository,
                                                                            categorySqLiteRepository,
                                                                            categoriesTranslator, bathSize,
                                                                            _viewModel.LastSynchronizationDate);

                unitOfWork.BeginTransaction();
                categoriesSyncCmd.Execute();
                unitOfWork.Commit();

                // Statuses synchronization
                var statusDtoRepository = new WebRepository<StatusDto>(webConnectionFactory);
                var statusSqLiteRepository = new StatusRepository(unitOfWork);
                DtoTranslator<Status, StatusDto> statusTranslator = new StatusTranslator();

                var statusSyncCommand = _viewModel.SynchronizeFully
                                            ? new SynchronizationCommand<StatusDto, Status>(statusDtoRepository,
                                                                                            statusSqLiteRepository,
                                                                                            statusTranslator, bathSize)
                                            : new SynchronizationCommand<StatusDto, Status>(statusDtoRepository,
                                                                                            statusSqLiteRepository,
                                                                                            statusTranslator, bathSize,
                                                                                            _viewModel
                                                                                                .LastSynchronizationDate);

                unitOfWork.BeginTransaction();
                statusSyncCommand.Execute();
                unitOfWork.Commit();

                // Warehouses synchronization
                var warehouseDtoRepository = new WebRepository<WarehouseDto>(webConnectionFactory);
                var warehouseSqLiteRepository = new WarehouseRepository(unitOfWork);
                DtoTranslator<Warehouse, WarehouseDto> warehouseTranslator = new WarehouseTranslator();

                var warehouseSyncCommand = _viewModel.SynchronizeFully
                                               ? new SynchronizationCommand<WarehouseDto, Warehouse>(
                                                     warehouseDtoRepository, warehouseSqLiteRepository,
                                                     warehouseTranslator, bathSize)
                                               : new SynchronizationCommand<WarehouseDto, Warehouse>(
                                                     warehouseDtoRepository, warehouseSqLiteRepository,
                                                     warehouseTranslator, bathSize, _viewModel.LastSynchronizationDate);

                unitOfWork.BeginTransaction();
                warehouseSyncCommand.Execute();
                unitOfWork.Commit();

                // Price lists synchronization
                var priceListDtoRepository = new WebRepository<PriceListDto>(webConnectionFactory);
                var priceListSqLiteRepository = new PriceListRepository(unitOfWork);
                DtoTranslator<PriceList, PriceListDto> priceListTranslator = new PriceListTranslator();

                var priceListSyncCommand = _viewModel.SynchronizeFully
                                               ? new SynchronizationCommand<PriceListDto, PriceList>(
                                                     priceListDtoRepository, priceListSqLiteRepository,
                                                     priceListTranslator, bathSize)
                                               : new SynchronizationCommand<PriceListDto, PriceList>(
                                                     priceListDtoRepository, priceListSqLiteRepository,
                                                     priceListTranslator, bathSize, _viewModel.LastSynchronizationDate);

                unitOfWork.BeginTransaction();
                priceListSyncCommand.Execute();
                unitOfWork.Commit();

                // UnitOfMeasures synchronization
                var unitOfMeasureDtoRepository = new WebRepository<UnitOfMeasureDto>(webConnectionFactory);
                var unitOfMeasureSqLiteRepository = new UnitOfMeasureRepository(unitOfWork);
                DtoTranslator<UnitOfMeasure, UnitOfMeasureDto> unitOfMeasureTranslator = new UnitOfMeasureTranslator();

                var unitOfMeasureSyncCommand = _viewModel.SynchronizeFully
                                                   ? new SynchronizationCommand<UnitOfMeasureDto, UnitOfMeasure>(
                                                         unitOfMeasureDtoRepository, unitOfMeasureSqLiteRepository,
                                                         unitOfMeasureTranslator, bathSize)
                                                   : new SynchronizationCommand<UnitOfMeasureDto, UnitOfMeasure>(
                                                         unitOfMeasureDtoRepository, unitOfMeasureSqLiteRepository,
                                                         unitOfMeasureTranslator, bathSize,
                                                         _viewModel.LastSynchronizationDate);

                unitOfWork.BeginTransaction();
                unitOfMeasureSyncCommand.Execute();
                unitOfWork.Commit();

                // Products synchronization
                var productDtoRepository = new WebRepository<ProductDto>(webConnectionFactory);
                var productSqLiteRepository = new ProductRepository(unitOfWork);
                DtoTranslator<Product, ProductDto> productTranslator = new ProductTranslator();

                var productSyncCommand = _viewModel.SynchronizeFully
                                             ? new SynchronizationCommand<ProductDto, Product>(productDtoRepository,
                                                                                               productSqLiteRepository,
                                                                                               productTranslator,
                                                                                               bathSize)
                                             : new SynchronizationCommand<ProductDto, Product>(productDtoRepository,
                                                                                               productSqLiteRepository,
                                                                                               productTranslator, bathSize,
                                                                                               _viewModel
                                                                                                   .LastSynchronizationDate);

                unitOfWork.BeginTransaction();
                productSyncCommand.Execute();
                unitOfWork.Commit();

                // Product prices synchronization
                var productsPriceDtoRepository = new WebRepository<ProductPriceDto>(webConnectionFactory);
                var productsPriceSqLiteRepository = new ProductsPriceRepository(unitOfWork);
                DtoTranslator<ProductsPrice, ProductPriceDto> productsPriceTranslator = new ProductsPriceTranslator();

                var productsPricesSyncCommand = _viewModel.SynchronizeFully
                                                    ? new SynchronizationCommand<ProductPriceDto, ProductsPrice>(
                                                          productsPriceDtoRepository, productsPriceSqLiteRepository,
                                                          productsPriceTranslator, bathSize)
                                                    : new SynchronizationCommand<ProductPriceDto, ProductsPrice>(
                                                          productsPriceDtoRepository, productsPriceSqLiteRepository,
                                                          productsPriceTranslator, bathSize,
                                                          _viewModel.LastSynchronizationDate);

                unitOfWork.BeginTransaction();
                productsPricesSyncCommand.Execute();
                unitOfWork.Commit();

                // Product units of measure synchronization
                var productsUomDtoRepository = new WebRepository<ProductUnitOfMeasureDto>(webConnectionFactory);
                var productsUnitOfMeasureSqLiteRepository = new ProductsUnitOfMeasureRepository(unitOfWork);
                DtoTranslator<ProductsUnitOfMeasure, ProductUnitOfMeasureDto> productsUnitOfMeasureTranslator = new ProductsUnitOfMeasureTranslator();

                var productsUomSyncCommand = _viewModel.SynchronizeFully
                                                 ? new SynchronizationCommand
                                                       <ProductUnitOfMeasureDto, ProductsUnitOfMeasure>(
                                                       productsUomDtoRepository, productsUnitOfMeasureSqLiteRepository,
                                                       productsUnitOfMeasureTranslator, bathSize)
                                                 : new SynchronizationCommand
                                                       <ProductUnitOfMeasureDto, ProductsUnitOfMeasure>(
                                                       productsUomDtoRepository, productsUnitOfMeasureSqLiteRepository,
                                                       productsUnitOfMeasureTranslator, bathSize,
                                                       _viewModel.LastSynchronizationDate);

                unitOfWork.BeginTransaction();
                productsUomSyncCommand.Execute();
                unitOfWork.Commit();

                // Route templates synchronization
                var routeTemplateDtoRepository = new WebRepository<RouteTemplateDto>(webConnectionFactory);
                var routeTemplateSqLiteRepository = new RouteTemplateRepository(unitOfWork);
                DtoTranslator<RouteTemplate, RouteTemplateDto> routeTemplateTranslator = new RouteTemplateTranslator();

                var routeTemplateSyncCommand = _viewModel.SynchronizeFully
                                                   ? new SynchronizationCommand<RouteTemplateDto, RouteTemplate>(
                                                         routeTemplateDtoRepository, routeTemplateSqLiteRepository,
                                                         routeTemplateTranslator, bathSize)
                                                   : new SynchronizationCommand<RouteTemplateDto, RouteTemplate>(
                                                         routeTemplateDtoRepository, routeTemplateSqLiteRepository,
                                                         routeTemplateTranslator, bathSize,
                                                         _viewModel.LastSynchronizationDate);

                unitOfWork.BeginTransaction();
                routeTemplateSyncCommand.Execute();
                unitOfWork.Commit();

                // Route points templates synchronization
                var routePointTemplateDtoRepository = new WebRepository<RoutePointTemplateDto>(webConnectionFactory);
                var routePointTemplateSqLiteRepository = new RoutePointTemplateRepository(unitOfWork);
                DtoTranslator<RoutePointTemplate, RoutePointTemplateDto> routePointTemplateTranslator = new RoutePointTemplateTranslator();

                var routePointTemplateSyncCommand = _viewModel.SynchronizeFully
                                                        ? new SynchronizationCommand
                                                              <RoutePointTemplateDto, RoutePointTemplate>(
                                                              routePointTemplateDtoRepository,
                                                              routePointTemplateSqLiteRepository,
                                                              routePointTemplateTranslator, bathSize)
                                                        : new SynchronizationCommand
                                                              <RoutePointTemplateDto, RoutePointTemplate>(
                                                              routePointTemplateDtoRepository,
                                                              routePointTemplateSqLiteRepository,
                                                              routePointTemplateTranslator, bathSize,
                                                              _viewModel.LastSynchronizationDate);

                unitOfWork.BeginTransaction();
                routePointTemplateSyncCommand.Execute();
                unitOfWork.Commit();
                _configurationManager.GetConfig("Common")
                                     .GetSection("Synchronization")
                                     .GetSetting("LastSyncDate").Value = synchronizationDate.ToString(CultureInfo.InvariantCulture);
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
            var lastSynchronizationDate =
                _configurationManager.GetConfig("Common")
                                     .GetSection("Synchronization")
                                     .GetSetting("LastSyncDate")
                                     .As<DateTime>();
            _viewModel = new SynchronizationViewModel
                {
                    SynchronizeFully = false,
                    LastSynchronizationDate = lastSynchronizationDate
                };
            return _viewModel;
        }
    }
}
