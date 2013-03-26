namespace MSS.WinMobile.UI.Presenters.Presenters.DataRetrievers
{
    public interface IDataPageRetriever<T>
    {
        int Count { get; }

        T[] SupplyPageOfData(int lowerPageBoundary, int rowsPerPage);
    }
}
