using System;
using System.Drawing;
using System.Windows.Forms;

namespace MSS.WinMobile.UI.Controls.ListBox
{
    public abstract partial class VirtualListBoxItem<T> : UserControl where T : class 
    {
        public delegate void OnDataNeeded(VirtualListBoxItem<T> sender);
        public delegate void OnSelected(VirtualListBoxItem<T> sender);

        protected VirtualListBoxItem()
        {
            InitializeComponent();
        }

        public event OnDataNeeded DataNeeded;
        public event OnSelected Selected;

        private int _index = -1;
        public int Index {
            get { return _index; }
            set {
                if (_index == value)
                    return;

                _index = value;
                if (DataNeeded != null)
                    DataNeeded.Invoke(this);
            }
        }

        public T Data { get; set; }

        public bool IsSelected { get; set; }
        private void VirtualListBoxItem_Click(object sender, EventArgs e)
        {
            IsSelected = true;
            if (Selected != null)
                Selected.Invoke(this);
        }

        protected abstract void DrawItem(Graphics graphics, Rectangle rectangle);

        private void VirtualListBoxItem_Paint(object sender, PaintEventArgs e)
        {
            if (Data == null)
                return;

            DrawItem(e.Graphics, e.ClipRectangle);
        }
    }
}
