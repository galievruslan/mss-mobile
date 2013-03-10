namespace MSS.WinMobile.UI.Presenters.DataRetrievers
{
    public interface IDataPageRetriever<T>
    {
        int Count { get; }

        T[] SupplyPageOfData(int lowerPageBoundary, int rowsPerPage);
    }
}
