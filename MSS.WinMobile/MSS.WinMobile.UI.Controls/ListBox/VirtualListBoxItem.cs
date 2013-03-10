using System;
using System.Drawing;
using System.Windows.Forms;

namespace MSS.WinMobile.UI.Controls.ListBox
{
    public partial class VirtualListBoxItem : UserControl, IListBoxItem
    {
        private readonly Color _unselectedBackgroundColor = Color.White;
        private readonly Color _selectedBackgroundColor = Color.SteelBlue;
        private readonly Color _unselectedFontColor = Color.Black;
        private readonly Color _selectedFontColor = Color.White;
        private readonly Font _font = new Font("Tahoma", 8, FontStyle.Regular);

        public VirtualListBoxItem()
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

        public Data Data { get; set; }

        public bool IsSelected { get; set; }
        private void VirtualListBoxItem_Click(object sender, EventArgs e)
        {
            IsSelected = true;
            if (Selected != null)
                Selected.Invoke(this);
        }

        private void VirtualListBoxItem_Paint(object sender, PaintEventArgs e)
        {
            if (Data.Equals(Data.Empty))
                return;

            e.Graphics.FillRectangle(
                IsSelected ? new SolidBrush(_selectedBackgroundColor) : new SolidBrush(_unselectedBackgroundColor),
                e.ClipRectangle);

            e.Graphics.DrawString(Data.Label, _font,
                                  IsSelected ? new SolidBrush(_selectedFontColor) : new SolidBrush(_unselectedFontColor),
                                  new Rectangle(e.ClipRectangle.X + 3, e.ClipRectangle.Y + 3, e.ClipRectangle.Width - 6,
                                                e.ClipRectangle.Height - 6));

            e.Graphics.DrawLine(new Pen(Color.DarkGray), e.ClipRectangle.X + 3, e.ClipRectangle.Height - 2,
                                e.ClipRectangle.Width - 6, e.ClipRectangle.Height - 2);
        }
    }
}
