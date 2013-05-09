using System.Collections;

namespace LitJson
{
    public interface IOrderedDictionary : IDictionary
    {
        object this[int idx]
        {
            get;
            set;
        }

        new IDictionaryEnumerator GetEnumerator();

        void Insert(int idx, object key, object value);

        void RemoveAt(int idx);
    }
}
