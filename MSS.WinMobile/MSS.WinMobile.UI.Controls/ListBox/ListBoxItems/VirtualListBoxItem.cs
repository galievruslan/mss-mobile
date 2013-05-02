using System.Drawing;
using System.Windows.Forms;

namespace MSS.WinMobile.UI.Controls.ListBox.ListBoxItems
{
    public class VirtualListBoxItem : UserControl
    {
        protected VirtualListBoxItem() {
            Index = -1;
        }

        public delegate void OnDataNeeded(VirtualListBoxItem sender);
        public delegate void OnSelected(VirtualListBoxItem sender);

        public event OnDataNeeded DataNeeded;
        public event OnSelected Selected;
        public int Index { get; set; }
        public bool IsSelected { get; set; }
        public void RefreshData() {
            if (DataNeeded != null)
                DataNeeded.Invoke(this);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.DrawLine(new Pen(Color.Gainsboro), 2, Height - 2, Width - 4, Height - 4);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // VirtualListBoxItem
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.White;
            this.Name = "VirtualListBoxItem";
            this.Size = new System.Drawing.Size(200, 30);
            this.ResumeLayout(false);

        }
    }
}
