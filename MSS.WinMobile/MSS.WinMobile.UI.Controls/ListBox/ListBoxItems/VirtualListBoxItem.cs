using System;
using System.Drawing;
using System.Windows.Forms;

namespace MSS.WinMobile.UI.Controls.ListBox.ListBoxItems
{
    public partial class VirtualListBoxItem : UserControl
    {
        public delegate void OnDataNeeded(VirtualListBoxItem sender);
        public delegate void OnSelected(VirtualListBoxItem sender);

        protected VirtualListBoxItem()
        {
            InitializeComponent();
            Empty = true;
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

        public bool Empty { get; protected set; }

        public bool IsSelected { get; set; }
        private void VirtualListBoxItem_Click(object sender, EventArgs e)
        {
            IsSelected = true;
            if (Selected != null)
                Selected.Invoke(this);
        }

        protected virtual void DrawItem(Graphics graphics, Rectangle rectangle)
        {
        }

        private void VirtualListBoxItem_Paint(object sender, PaintEventArgs e)
        {
            if (Empty)
                return;

            e.Graphics.FillRectangle(
                IsSelected ? new SolidBrush(Constants.ColorSelected) : new SolidBrush(Constants.ColorUnSelected),
                e.ClipRectangle);

            e.Graphics.DrawLine(new Pen(Color.DarkGray), e.ClipRectangle.X + Constants.MARGIN,
                                e.ClipRectangle.Height - 2,
                                e.ClipRectangle.Width - Constants.DIVISOR_LINE*Constants.MARGIN,
                                e.ClipRectangle.Height - Constants.DIVISOR_LINE);

            DrawItem(e.Graphics, e.ClipRectangle);
        }
    }
}
