using System.Drawing;
using System.Windows.Forms;
using MSS.WinMobile.Localization;

namespace MSS.WinMobile.UI.Controls.ListBox.ListBoxItems {
    public class NewVirtualListBoxItem : UserControl {
        protected NewVirtualListBoxItem() {
            Index = -1;
        }

        protected readonly Color ColorSelected = Color.LightSkyBlue;
        protected readonly Color ColorUnselected = Color.White;

        public ILocalizationManager LocalizationManager { protected get; set; }

        private const int DivisorLeftMargin = 4;
        private const int DivisorRightMargin = 4;
        private const int DivisorBottomMargin = 1;

        protected override void OnPaint(PaintEventArgs e) {
            base.OnPaint(e);
            e.Graphics.DrawLine(new Pen(Color.Gainsboro), DivisorLeftMargin,
                                Height - DivisorBottomMargin,
                                Width - DivisorLeftMargin - DivisorRightMargin,
                                Height - DivisorBottomMargin);
        }

        public delegate void OnDataNeeded(NewVirtualListBoxItem sender);
        public event OnDataNeeded DataNeeded;

        private int _index;

        public int Index {
            get { return _index; }
            set {
                if (_index != value)
                    Selected = false;

                _index = value;
                if (DataNeeded != null)
                    DataNeeded.Invoke(this);
                Refresh();
            }
        }

        protected bool Selected;
        public void Select() {
            if (!Selected) {
                Selected = true;
                Refresh();
            }
        }

        public void UnSelect() {
            if (Selected) {
                Selected = false;
                Refresh();
            }
        }

        public void RefreshData() {
            if (DataNeeded != null)
                DataNeeded.Invoke(this);
            Refresh();
        }
    }
}
