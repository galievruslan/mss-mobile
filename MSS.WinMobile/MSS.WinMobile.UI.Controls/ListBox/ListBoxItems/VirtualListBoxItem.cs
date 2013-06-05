using System.Drawing;
using System.Windows.Forms;
using MSS.WinMobile.Resources;

namespace MSS.WinMobile.UI.Controls.ListBox.ListBoxItems {
    public class VirtualListBoxItem : UserControl {
        protected VirtualListBoxItem() {
            Index = -1;
        }

        protected readonly Color ColorSelected = Color.LightSkyBlue;
        protected readonly Color ColorUnselected = Color.White;

        public ILocalizator Localizator { protected get; set; }

        protected void DrawDivisor(Graphics graphics) {
            graphics.DrawLine(new Pen(Color.Gainsboro), 4, Height - 1, Width - 8, Height - 1);
        }

        public delegate void OnDataNeeded(VirtualListBoxItem sender);
        public delegate void OnSelected(VirtualListBoxItem sender);
        public delegate void OnUnSelected(VirtualListBoxItem sender);

        public event OnDataNeeded DataNeeded;
        public event OnSelected Selected;
        public event OnUnSelected UnSelected;

        private int _index;

        public int Index {
            get { return _index; }
            set {
                _index = value;
                if (DataNeeded != null)
                    DataNeeded.Invoke(this);
                Refresh();
            }
        }

        private bool _isSelected;

        public bool IsSelected {
            get { return _isSelected; }
            set {
                _isSelected = value;
                if (!_isSelected)
                    if (UnSelected != null)
                        UnSelected.Invoke(this);
                Refresh();
            }
        }

        public void RefreshData() {
            if (DataNeeded != null)
                DataNeeded.Invoke(this);
        }

        private void InitializeComponent() {
            this.SuspendLayout();
            // 
            // VirtualListBoxItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Name = "VirtualListBoxItem";
            this.Size = new System.Drawing.Size(200, 28);
            this.Click += new System.EventHandler(this.VirtualListBoxItemClick);
            this.ResumeLayout(false);

        }

        protected void VirtualListBoxItemClick(object sender, System.EventArgs e) {
            if (!IsSelected && Selected != null)
                Selected.Invoke(this);
        }
    }
}
