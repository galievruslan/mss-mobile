using System.Linq;

namespace MSS.WinMobile.UI.Presenters.Presenters.DataRetrievers
{
    public class Cache<T> where T : class 
    {
        // Represents one page of data.  
        private struct DataPage {
            public readonly T[] Content;
            private readonly int _lowestIndexValue;
            private readonly int _highestIndexValue;

            public DataPage(T[] content, int rowIndex, int rowPerPage) {
                Content = content;
                _lowestIndexValue = MapToLowerBoundary(rowIndex, rowPerPage);
                _highestIndexValue = MapToUpperBoundary(rowIndex, rowPerPage);
                System.Diagnostics.Debug.Assert(_lowestIndexValue >= 0);
                System.Diagnostics.Debug.Assert(_highestIndexValue >= 0);
            }

            public int LowestIndex {
                get { return _lowestIndexValue; }
            }

            public int HighestIndex {
                get { return _highestIndexValue; }
            }

            public static int MapToLowerBoundary(int rowIndex, int rowPerPage) {
                // Return the lowest index of a page containing the given index.
                return (rowIndex/rowPerPage)*rowPerPage;
            }

            private static int MapToUpperBoundary(int rowIndex, int rowPerPage) {
                // Return the highest index of a page containing the given index.
                return MapToLowerBoundary(rowIndex, rowPerPage) + rowPerPage - 1;
            }
        }

        private readonly int _rowsPerPage;
        private DataPage[] _cachePages;
        private readonly IDataPageRetriever<T> _dataSupply;

        public Cache(IDataPageRetriever<T> dataSupplier, int rowsPerPage) {
            _dataSupply = dataSupplier;
            _rowsPerPage = rowsPerPage;
            LoadFirstTwoPages();
        }

        // Sets the value of the element parameter if the value is in the cache.
        private T IfPageCachedThenSetElement(int rowIndex) {
            T element = null;
            if (IsRowCachedInPage(0, rowIndex)) {
                element = _cachePages[0].Content[rowIndex%_rowsPerPage];
            }
            else if (IsRowCachedInPage(1, rowIndex)) {
                element = _cachePages[1].Content[rowIndex%_rowsPerPage];
            }

            return element;
        }

        public T RetrieveElement(int rowIndex) {
            T element = IfPageCachedThenSetElement(rowIndex);

            if (element != null) {
                return element;
            }

            return RetrieveDataCacheItThenReturnElement(rowIndex);
        }

        private void LoadFirstTwoPages() {
            // Load data for two pages for one database trip
            T[] twoPageData = _dataSupply.SupplyPageOfData(0, _rowsPerPage*2);

            _cachePages = new[]
                {
                    new DataPage(twoPageData.Take(_rowsPerPage).ToArray(), 0, _rowsPerPage),
                    new DataPage(twoPageData.Skip(_rowsPerPage).Take(_rowsPerPage).ToArray(), _rowsPerPage, _rowsPerPage)
                };
        }

        private T RetrieveDataCacheItThenReturnElement(
            int rowIndex) {
            // Retrieve a page worth of data containing the requested value.
            T[] content = _dataSupply.SupplyPageOfData(
                DataPage.MapToLowerBoundary(rowIndex, _rowsPerPage), _rowsPerPage);

            // Replace the cached page furthest from the requested cell
            // with a new page containing the newly retrieved data.
            _cachePages[GetIndexToUnusedPage(rowIndex)] = new DataPage(content, rowIndex, _rowsPerPage);

            return RetrieveElement(rowIndex);
        }

        // Returns the index of the cached page most distant from the given index
        // and therefore least likely to be reused.
        private int GetIndexToUnusedPage(int rowIndex) {
            if (rowIndex > _cachePages[0].HighestIndex &&
                rowIndex > _cachePages[1].HighestIndex) {
                int offsetFromPage0 = rowIndex - _cachePages[0].HighestIndex;
                int offsetFromPage1 = rowIndex - _cachePages[1].HighestIndex;
                if (offsetFromPage0 < offsetFromPage1) {
                    return 1;
                }
                return 0;
            }
            else {
                int offsetFromPage0 = _cachePages[0].LowestIndex - rowIndex;
                int offsetFromPage1 = _cachePages[1].LowestIndex - rowIndex;
                if (offsetFromPage0 < offsetFromPage1) {
                    return 1;
                }
                return 0;
            }
        }

        // Returns a value indicating whether the given row index is contained
        // in the given DataPage. 
        private bool IsRowCachedInPage(int pageNumber, int rowIndex) {
            return rowIndex <= _cachePages[pageNumber].HighestIndex &&
                   rowIndex >= _cachePages[pageNumber].LowestIndex;
        }
    }
}
