using System.Drawing;
using System.Windows.Forms;

namespace MSS.WinMobile.UI.Controls.ListBox.ListBoxItems {
    public class VirtualListBoxItem : UserControl, IPaintControl {
        protected VirtualListBoxItem() {
            Index = -1;
            UnSelected += VirtualListBoxItem_UnSelected;
            Selected += VirtualListBoxItem_Selected;
        }

        private void VirtualListBoxItem_Selected(VirtualListBoxItem sender) {
            BackColor = Color.LightSkyBlue;
            Refresh();
        }

        private void VirtualListBoxItem_UnSelected(VirtualListBoxItem sender) {
            BackColor = Color.White;
            Refresh();
        }

        public delegate void OnDataNeeded(VirtualListBoxItem sender);

        public delegate void OnSelected(VirtualListBoxItem sender);

        public delegate void OnUnSelected(VirtualListBoxItem sender);

        public event OnDataNeeded DataNeeded;
        public event OnSelected Selected;
        public event OnUnSelected UnSelected;
        public int Index { get; set; }

        private bool _isSelected;

        public bool IsSelected {
            get { return _isSelected; }
            set {
                _isSelected = value;
                if (!_isSelected)
                    if (UnSelected != null)
                        UnSelected.Invoke(this);
            }
        }

        public void RefreshData() {
            if (DataNeeded != null)
                DataNeeded.Invoke(this);
        }

        protected override void OnPaint(PaintEventArgs e) {
            base.OnPaint(e);
            e.Graphics.DrawLine(new Pen(Color.Gainsboro), 4, Height - 1, Width - 8, Height - 1);
        }

        private void InitializeComponent() {
            this.SuspendLayout();
            // 
            // VirtualListBoxItem
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.White;
            this.Name = "VirtualListBoxItem";
            this.Size = new System.Drawing.Size(200, 30);
            this.Click += new System.EventHandler(this.VirtualListBoxItemClick);
            this.ResumeLayout(false);

        }

        protected void VirtualListBoxItemClick(object sender, System.EventArgs e) {
            if (Selected != null)
                Selected.Invoke(this);
        }

        public void InvokePaintBackground(PaintEventArgs e) {
            OnPaintBackground(e);
        }
    }
}
