﻿using MSS.WinMobile.UI.Controls.ListBox.ListBoxItems;
using MSS.WinMobile.UI.Presenters.ViewModels;

namespace MSS.WinMobile.UI.Controls.Concret.ListBoxItems {
    public class WarehouseListBoxItem : VirtualListBoxItem {
        private System.Windows.Forms.LinkLabel _nameLabel;

        public WarehouseListBoxItem() {
            InitializeComponent();
        }

        private System.Windows.Forms.LinkLabel _addressLabel;

        private WarehouseViewModel _viewModel;

        public WarehouseViewModel ViewModel {
            get { return _viewModel; }
            set {
                _viewModel = value;
                _nameLabel.Text = ViewModel.Name;
                _addressLabel.Text = ViewModel.Address;
            }
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e) {
            _nameLabel.BackColor = _addressLabel.BackColor = IsSelected ? ColorSelected : ColorUnselected;
            base.OnPaint(e);
            DrawDivisor(e.Graphics);
        }

        private void InitializeComponent() {
            this._nameLabel = new System.Windows.Forms.LinkLabel();
            this._addressLabel = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // _nameLabel
            // 
            this._nameLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this._nameLabel.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular);
            this._nameLabel.ForeColor = System.Drawing.Color.Black;
            this._nameLabel.Location = new System.Drawing.Point(0, 0);
            this._nameLabel.Name = "_nameLabel";
            this._nameLabel.Size = new System.Drawing.Size(200, 14);
            this._nameLabel.TabIndex = 0;
            this._nameLabel.Text = "linkLabel1";
            this._nameLabel.Click += new System.EventHandler(this.LabelClick);
            // 
            // _addressLabel
            // 
            this._addressLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this._addressLabel.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular);
            this._addressLabel.ForeColor = System.Drawing.Color.Black;
            this._addressLabel.Location = new System.Drawing.Point(0, 14);
            this._addressLabel.Name = "_addressLabel";
            this._addressLabel.Size = new System.Drawing.Size(200, 14);
            this._addressLabel.TabIndex = 1;
            this._addressLabel.Text = "linkLabel1";
            this._addressLabel.Click += new System.EventHandler(this.LabelClick);
            // 
            // WarehouseListBoxItem
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this._addressLabel);
            this.Controls.Add(this._nameLabel);
            this.Name = "WarehouseListBoxItem";
            this.Size = new System.Drawing.Size(200, 29);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.ListBoxItemPaint);
            this.ResumeLayout(false);

        }

        private void LabelClick(object sender, System.EventArgs e) {
            VirtualListBoxItemClick(sender, e);
        }

        private void ListBoxItemPaint(object sender, System.Windows.Forms.PaintEventArgs e) {
            DrawDivisor(e.Graphics);
        }
    }
}
