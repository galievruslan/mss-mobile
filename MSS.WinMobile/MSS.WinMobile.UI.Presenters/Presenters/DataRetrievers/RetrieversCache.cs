namespace MSS.WinMobile.UI.Presenters.Presenters.DataRetrievers
{
    public static class RetrieversCache
    {
        private static RoutePointRetriever _currentRoutePointRetriever;
        public static void InitializeCurrentRoutePointRetriever()
        {
            _currentRoutePointRetriever = new RoutePointRetriever();
        }

        public static RoutePointRetriever GetCurrentRoutePointRetriever()
        {
            if (_currentRoutePointRetriever == null)
                _currentRoutePointRetriever = new RoutePointRetriever();

            return _currentRoutePointRetriever;
        }
    }
}
