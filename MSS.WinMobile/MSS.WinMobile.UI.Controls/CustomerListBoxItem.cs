using System.Drawing;
using System.Windows.Forms;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.UI.Controls.ListBox;

namespace MSS.WinMobile.UI.Controls
{
    public class CustomerListBoxItem : UserControl, IListBoxItem<Customer>
    {
        public CustomerListBoxItem()
        {
            InitializeComponent();
            Height = 24;
            _dataPanel.Paint += _dataPanel_Paint;
        }

        void _dataPanel_Paint(object sender, PaintEventArgs e)
        {
            if (Data != null)
            {
                e.Graphics.DrawString(Data.Name,
                                      new Font(FontFamily.GenericSansSerif,
                                      10,
                                      FontStyle.Regular),
                                      new SolidBrush(Color.Black),
                                      7, 5);

                e.Graphics.DrawLine(new Pen(Color.Gainsboro), 7, Height - 1, Width - 7, Height - 1);
            }
        }

        private Panel _dataPanel;

        public event OnDataNeeded DataNeeded;
        public event OnSelectNeeded SelectNeeded;

        private int _index = -1;
        public int Index
        {
            get { return _index; }
            set
            {
                if (value == _index) return;
                _index = value;

                if (DataNeeded == null) return;
                DataNeeded.Invoke(this);
                _dataPanel.Refresh();
            }
        }

        public Customer Data { get; set; }
        public void Select()
        {
            _dataPanel.BackColor = Color.Gainsboro;
            _dataPanel.Refresh();
        }

        public void UnSelect()
        {
            _dataPanel.BackColor = Color.White;
            _dataPanel.Refresh();
        }

        private void InitializeComponent()
        {
            this._dataPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // _dataPanel
            // 
            this._dataPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._dataPanel.Location = new System.Drawing.Point(0, 0);
            this._dataPanel.Name = "_dataPanel";
            this._dataPanel.Size = new System.Drawing.Size(206, 24);
            this._dataPanel.Click += new System.EventHandler(this._dataPanel_Click);
            // 
            // CustomerListBoxItem
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this._dataPanel);
            this.Name = "CustomerListBoxItem";
            this.Size = new System.Drawing.Size(206, 24);
            this.ResumeLayout(false);

        }
        
        private void _dataPanel_Click(object sender, System.EventArgs e)
        {
            if (SelectNeeded != null)
                SelectNeeded.Invoke(this);
        }
    }
}
