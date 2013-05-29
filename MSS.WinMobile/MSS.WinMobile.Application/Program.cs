using System;
using System.Linq;
using System.Collections.Generic;
using MSS.WinMobile.Application.Configuration;
using MSS.WinMobile.Application.Environment;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Sqlite.Repositoties;
using MSS.WinMobile.Infrastructure.Sqlite.Repositoties.VirtualProxies;
using MSS.WinMobile.Infrastructure.Sqlite.SpecificationsTranslators;
using MSS.WinMobile.Infrastructure.Storage;
using MSS.WinMobile.Resources;
using MSS.WinMobile.UI.Views;
using MSS.WinMobile.UI.Views.Views;
using log4net.Config;

namespace MSS.WinMobile.Application
{
    static class Program
    {
        private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(typeof(Program));

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [MTAThread]
        static void Main()
        {
            // Load Config.xml to setup log4net
            string path = System.IO.Path.GetDirectoryName(
                System.Reflection.Assembly.GetExecutingAssembly()
               .GetModules()[0].FullyQualifiedName)
               + "\\log4net.xml";
            if (System.IO.File.Exists(path))
            {
                XmlConfigurator.Configure(new System.IO.FileInfo(path));
            }

            // Setup storage manager
            var configurationManager = new ConfigurationManager(Environments.AppPath);
            var databaseName =
                configurationManager.GetConfig("Common").GetSection("Database").GetSetting("FileName").Value;
            var schemaScript =
                configurationManager.GetConfig("Common").GetSection("Database").GetSetting("SchemaScript").Value;
            IStorageManager storageManager = new SqLiteStorageManager();
            storageManager.CreateOrOpenStorage(
                string.Concat(Environments.AppPath, databaseName),
                string.Concat(Environments.AppPath, schemaScript));

            // Setup localization
            ILocalizator localizator = new Localizator();
            try {
                var localization = configurationManager.GetConfig("Common")
                                                       .GetSection("Localization")
                                                       .GetSetting("Current")
                                                       .Value;

                List<ILocalization> localizations =
                    localizator.GetAvailableLocalizations(Environments.AppPath);
                ILocalization current = null;
                if (!string.IsNullOrEmpty(localization)) {
                    current =
                        localizations.FirstOrDefault(l => l.Path.ToUpper() == localization.ToUpper());
                }

                if (current == null) {
                    current = localizations.FirstOrDefault();
                }
                localizator.SetupLocalization(current);
            }
            catch (Exception exception) {
                Log.Error(exception);
            }

            // Setup repositories
            var repositoryFactory = new RepositoryFactory(storageManager);
            repositoryFactory.RegisterSpecificationTranslator(new CustomerSpecTranslator())
                             .RegisterSpecificationTranslator(new ShippingAddressSpecTranslator())
                             .RegisterSpecificationTranslator(new CategorySpecTranslator())
                             .RegisterSpecificationTranslator(new PriceListSpecTranslator())
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
                             .RegisterSpecificationTranslator(new WarehouseSpecTranslator());

            IModelsFactory modelsFactory = new ModelsFactory(repositoryFactory);

            var main = new Main(localizator);
            var presentersFactory = new PresentersFactory(storageManager, repositoryFactory,
                                                          modelsFactory, main, localizator);
            
            string userName = configurationManager.GetConfig("Common").GetSection("Server").GetSetting("Username").Value;
            string password = configurationManager.GetConfig("Common").GetSection("Server").GetSetting("Password").Value;

            if (string.IsNullOrEmpty(userName) ||
                string.IsNullOrEmpty(password)) {
                main.SetView(new LogonView(presentersFactory, localizator));
            }
            else {
                main.SetView(new MenuView(presentersFactory, localizator));
            }

            Log.Info("Application start");
            System.Windows.Forms.Application.Run(main);
            Log.Info("Application finish");
        }
    }
}