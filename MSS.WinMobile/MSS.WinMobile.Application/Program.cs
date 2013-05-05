using System;
using MSS.WinMobile.Application.Configuration;
using MSS.WinMobile.Application.Environment;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Sqlite.Repositoties;
using MSS.WinMobile.Infrastructure.Sqlite.Repositoties.VirtualProxies;
using MSS.WinMobile.Infrastructure.Sqlite.SpecificationsTranslators;
using MSS.WinMobile.Infrastructure.Storage;
using MSS.WinMobile.UI.Presenters;
using MSS.WinMobile.UI.Views;
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

            var configurationManager = new ConfigurationManager(Environments.AppPath);
            var databaseName =
                configurationManager.GetConfig("Common").GetSection("Database").GetSetting("FileName").Value;
            var schemaScript =
                configurationManager.GetConfig("Common").GetSection("Database").GetSetting("SchemaScript").Value;

            IStorageManager storageManager = new SqLiteStorageManager();
            storageManager.CreateOrOpenStorage(
                string.Concat(Environments.AppPath, databaseName),
                string.Concat(Environments.AppPath, schemaScript));

            var repositoryFactory = new RepositoryFactory(storageManager);
            repositoryFactory.RegisterSpecificationTranslator(new CommonTranslator<Customer>())
                             .RegisterSpecificationTranslator(new ShippingAddressSpecTranslator())
                             .RegisterSpecificationTranslator(new CommonTranslator<Category>())
                             .RegisterSpecificationTranslator(new CommonTranslator<PriceList>())
                             .RegisterSpecificationTranslator(new CommonTranslator<Product>())
                             .RegisterSpecificationTranslator(new CommonTranslator<Order>())
                             .RegisterSpecificationTranslator(new OrderItemSpecTranslator())
                             .RegisterSpecificationTranslator(new ProductPriceSpecTranslator())
                             .RegisterSpecificationTranslator(
                                 new CommonTranslator<ProductsUnitOfMeasure>())
                             .RegisterSpecificationTranslator(new RoutePointSpecTranslator())
                             .RegisterSpecificationTranslator(new RouteSpecTranslator())
                             .RegisterSpecificationTranslator(
                                 new RoutePointTemplateSpecTranslator())
                             .RegisterSpecificationTranslator(new RouteTemplateSpecTranslator())
                             .RegisterSpecificationTranslator(new CommonTranslator<Status>())
                             .RegisterSpecificationTranslator(new CommonTranslator<UnitOfMeasure>())
                             .RegisterSpecificationTranslator(new CommonTranslator<Warehouse>());

            IModelsFactory modelsFactory = new ModelsFactory(repositoryFactory);
            var presentersFactory = new PresentersFactory(storageManager, repositoryFactory,
                                                          modelsFactory);
            // Register navigator for presenters
            NavigationContext.RegisterNavigator(new Navigator(presentersFactory));

            Log.Info("Application start");
            System.Windows.Forms.Application.Run(new MenuView());
            Log.Info("Application finish");
        }
    }
}