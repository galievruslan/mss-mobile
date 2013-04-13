using System;
using MSS.WinMobile.Domain.Models.ActiveRecord;
using MSS.WinMobile.Domain.Models.ActiveRecord.QueryBinders;
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

            // Register navigator for presenters
            NavigationContext.RegisterNavigator(new Navigator());

            Log.Info("Application start");
            ActiveRecordBase.Initialize(false);
            ActiveRecordBase.Register(new CategoryBinder());
            ActiveRecordBase.Register(new CustomerBinder());
            ActiveRecordBase.Register(new ManagerBinder());
            ActiveRecordBase.Register(new OrderBinder());
            ActiveRecordBase.Register(new OrderItemBinder());
            ActiveRecordBase.Register(new PriceListBinder());
            ActiveRecordBase.Register(new ProductBinder());
            ActiveRecordBase.Register(new ProductsPriceBinder());
            ActiveRecordBase.Register(new ProductsUnitOfMeasureBinder());
            ActiveRecordBase.Register(new RouteBinder());
            ActiveRecordBase.Register(new RoutePointBinder());
            ActiveRecordBase.Register(new RouteTemplateBinder());
            ActiveRecordBase.Register(new RoutePointTemplateBinder());
            ActiveRecordBase.Register(new ShippingAddressBinder());
            ActiveRecordBase.Register(new StatusBinder());
            ActiveRecordBase.Register(new UnitOfMeasureBinder());
            ActiveRecordBase.Register(new WarehouseBinder());

            System.Windows.Forms.Application.Run(new MenuView());
            Log.Info("Application finish");
        }
    }
}