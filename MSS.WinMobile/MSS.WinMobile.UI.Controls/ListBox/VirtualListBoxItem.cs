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
        public event OnSelectNeeded SelectNeeded;
        public int Index { get; set; }
        public string Label { get; set; }
        public int Id { get; set; }

        private bool _selected;
        public void Select()
        {
            _selected = true;
        }

        public void UnSelect()
        {
            _selected = false;
        }

        private void VirtualListBoxItem_Click(object sender, EventArgs e)
        {
            if (_selected)
                UnSelect();
            else
                Select();
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);
            e.Graphics.FillRectangle(
                _selected ? new SolidBrush(_selectedBackgroundColor) : new SolidBrush(_unselectedBackgroundColor),
                e.ClipRectangle);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.DrawString(Label, _font,
                                  _selected ? new SolidBrush(_selectedFontColor) : new SolidBrush(_unselectedFontColor),
                                  e.ClipRectangle);
        }
    }
}
