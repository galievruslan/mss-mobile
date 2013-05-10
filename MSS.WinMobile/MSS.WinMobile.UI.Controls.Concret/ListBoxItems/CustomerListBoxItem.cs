using MSS.WinMobile.UI.Controls.ListBox.ListBoxItems;
using MSS.WinMobile.UI.Presenters.ViewModels;

namespace MSS.WinMobile.UI.Controls.Concret.ListBoxItems
{
    public class CustomerListBoxItem : VirtualListBoxItem {
        private System.Windows.Forms.LinkLabel _nameLabel;
        private System.Windows.Forms.BindingSource _customerViewModelBindingSource;
        private System.ComponentModel.IContainer components;

        public CustomerListBoxItem() {
            InitializeComponent();
        }

        private CustomerViewModel _viewModel;
        public CustomerViewModel ViewModel {
            get { return _viewModel; }
            set {
                _viewModel = value;
                _customerViewModelBindingSource.DataSource = _viewModel;
            }
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            _nameLabel.BackColor = IsSelected ? ColorSelected : ColorUnselected;
            base.OnPaint(e);
            DrawDivisor(e.Graphics);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this._nameLabel = new System.Windows.Forms.LinkLabel();
            this._customerViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this._customerViewModelBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // _nameLabel
            // 
            this._nameLabel.DataBindings.Add(new System.Windows.Forms.Binding("Text", this._customerViewModelBindingSource, "Name", true));
            this._nameLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this._nameLabel.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular);
            this._nameLabel.ForeColor = System.Drawing.Color.Black;
            this._nameLabel.Location = new System.Drawing.Point(0, 0);
            this._nameLabel.Name = "_nameLabel";
            this._nameLabel.Size = new System.Drawing.Size(200, 28);
            this._nameLabel.TabIndex = 0;
            this._nameLabel.Text = "linkLabel1";
            this._nameLabel.Click += new System.EventHandler(this.NameLabelClick);
            // 
            // _customerViewModelBindingSource
            // 
            this._customerViewModelBindingSource.DataSource = typeof(MSS.WinMobile.UI.Presenters.ViewModels.CustomerViewModel);
            // 
            // CustomerListBoxItem
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this._nameLabel);
            this.Name = "CustomerListBoxItem";
            this.Size = new System.Drawing.Size(200, 30);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.CustomerListBoxItemPaint);
            ((System.ComponentModel.ISupportInitialize)(this._customerViewModelBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        private void NameLabelClick(object sender, System.EventArgs e) {
            VirtualListBoxItemClick(sender, e);
        }

        private void CustomerListBoxItemPaint(object sender, System.Windows.Forms.PaintEventArgs e) {
            DrawDivisor(e.Graphics);
        }
    }
}
