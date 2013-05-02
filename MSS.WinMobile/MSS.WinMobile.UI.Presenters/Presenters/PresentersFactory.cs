using MSS.WinMobile.Infrastructure.SqliteRepositoties;
using MSS.WinMobile.UI.Presenters.Views;

namespace MSS.WinMobile.UI.Presenters.Presenters
{
    public class PresentersFactory {
        private readonly SqLiteDatabase _sqLiteDatabase;
        public PresentersFactory(SqLiteDatabase sqLiteDatabase) {
            _sqLiteDatabase = sqLiteDatabase;
        }

        public LogonPresenter CreateLogonPresenter(ILogonView logonView) {
            return new LogonPresenter(logonView);
        }

        public SynchronizationPresenter CreateSynchronizationPresenter(ISynchronizationView synchronizationView) {
            return new SynchronizationPresenter(synchronizationView, _sqLiteDatabase);
        }

        public RoutePresenter CreateRoutePresenter(IRouteView routeView) {
            return new RoutePresenter(routeView, _sqLiteDatabase.UnitOfWork);
        }
    }
}
