using System.Windows.Forms;

namespace MSS.WinMobile.UI.Controls.ListBox
{
    public partial class VirtualListBoxItem<T> : UserControl, IListBoxItem<T> where T : class 
    {
        public event OnDataNeeded DataNeeded;

        // Designer only
        public VirtualListBoxItem()
        {
            InitializeComponent();
        }

        public VirtualListBoxItem(int index)
        {
            InitializeComponent();
            Index = index;
        }

        private int _index = -1;
        public int Index {
            get { return _index; }
            set
            {
                if (value == _index) return;
                _index = value;

                if (DataNeeded == null) return;
                DataNeeded.Invoke(this);
            }
        }

        private T _data;
        public T Data {
            get { return _data; }
            set { 
                _data = value; 
                DispalyData();
            }
        }

        protected virtual void DispalyData()
        {
            if (_data == null)
                Hide();
            else
                Show();
        }
    }
}
