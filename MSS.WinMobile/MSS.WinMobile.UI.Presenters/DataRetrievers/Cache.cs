namespace MSS.WinMobile.UI.Presenters.DataRetrievers
{
    public class Cache<T> where T : class 
    {
        private static int _rowsPerPage;

        // Represents one page of data.  
        public struct DataPage
        {
            public T[] Content;
            private readonly int _lowestIndexValue;
            private readonly int _highestIndexValue;

            public DataPage(T[] content, int rowIndex)
            {
                Content = content;
                _lowestIndexValue = MapToLowerBoundary(rowIndex);
                _highestIndexValue = MapToUpperBoundary(rowIndex);
                System.Diagnostics.Debug.Assert(_lowestIndexValue >= 0);
                System.Diagnostics.Debug.Assert(_highestIndexValue >= 0);
            }

            public int LowestIndex
            {
                get
                {
                    return _lowestIndexValue;
                }
            }

            public int HighestIndex
            {
                get
                {
                    return _highestIndexValue;
                }
            }

            public static int MapToLowerBoundary(int rowIndex)
            {
                // Return the lowest index of a page containing the given index.
                return (rowIndex / _rowsPerPage) * _rowsPerPage;
            }

            private static int MapToUpperBoundary(int rowIndex)
            {
                // Return the highest index of a page containing the given index.
                return MapToLowerBoundary(rowIndex) + _rowsPerPage - 1;
            }
        }

        private DataPage[] _cachePages;
        private readonly IDataPageRetriever<T> _dataSupply;

        public Cache(IDataPageRetriever<T> dataSupplier, int rowsPerPage)
        {
            _dataSupply = dataSupplier;
            _rowsPerPage = rowsPerPage;
            LoadFirstTwoPages();
        }

        // Sets the value of the element parameter if the value is in the cache.
        private T IfPageCached_ThenSetElement(int rowIndex)
        {
            T element = null;
            if (IsRowCachedInPage(0, rowIndex))
            {
                element = _cachePages[0].Content[rowIndex % _rowsPerPage];
            }
            else if (IsRowCachedInPage(1, rowIndex))
            {
                element = _cachePages[1].Content[rowIndex % _rowsPerPage];
            }

            return element;
        }

        public T RetrieveElement(int rowIndex)
        {
            T element = IfPageCached_ThenSetElement(rowIndex);

            if (element != null)
            {
                return element;
            }

            return RetrieveData_CacheIt_ThenReturnElement(rowIndex);
        }

        private void LoadFirstTwoPages()
        {
            _cachePages = new[]
                {
                    new DataPage(_dataSupply.SupplyPageOfData(
                        DataPage.MapToLowerBoundary(0), _rowsPerPage), 0),
                    new DataPage(_dataSupply.SupplyPageOfData(
                        DataPage.MapToLowerBoundary(_rowsPerPage),
                        _rowsPerPage), _rowsPerPage)
                };
        }

        private T RetrieveData_CacheIt_ThenReturnElement(
            int rowIndex)
        {
            // Retrieve a page worth of data containing the requested value.
            T[] content = _dataSupply.SupplyPageOfData(
                DataPage.MapToLowerBoundary(rowIndex), _rowsPerPage);

            // Replace the cached page furthest from the requested cell
            // with a new page containing the newly retrieved data.
            _cachePages[GetIndexToUnusedPage(rowIndex)] = new DataPage(content, rowIndex);

            return RetrieveElement(rowIndex);
        }

        // Returns the index of the cached page most distant from the given index
        // and therefore least likely to be reused.
        private int GetIndexToUnusedPage(int rowIndex)
        {
            if (rowIndex > _cachePages[0].HighestIndex &&
                rowIndex > _cachePages[1].HighestIndex)
            {
                int offsetFromPage0 = rowIndex - _cachePages[0].HighestIndex;
                int offsetFromPage1 = rowIndex - _cachePages[1].HighestIndex;
                if (offsetFromPage0 < offsetFromPage1)
                {
                    return 1;
                }
                return 0;
            }
            else
            {
                int offsetFromPage0 = _cachePages[0].LowestIndex - rowIndex;
                int offsetFromPage1 = _cachePages[1].LowestIndex - rowIndex;
                if (offsetFromPage0 < offsetFromPage1)
                {
                    return 1;
                }
                return 0;
            }

        }

        // Returns a value indicating whether the given row index is contained
        // in the given DataPage. 
        private bool IsRowCachedInPage(int pageNumber, int rowIndex)
        {
            return rowIndex <= _cachePages[pageNumber].HighestIndex &&
                rowIndex >= _cachePages[pageNumber].LowestIndex;
        }
    }
}
