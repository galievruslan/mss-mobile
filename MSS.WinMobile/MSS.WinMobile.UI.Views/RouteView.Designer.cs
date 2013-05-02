using MSS.WinMobile.UI.Controls.Buttons;
using MSS.WinMobile.UI.Presenters.Views;

namespace MSS.WinMobile.UI.Views
{
    partial class RouteView
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RouteView));
            this._actionPanel = new System.Windows.Forms.Panel();
            this.panel = new System.Windows.Forms.Panel();
            this.dateLabel = new System.Windows.Forms.Label();
            this.datePicker = new System.Windows.Forms.DateTimePicker();
            this.routePointListBox = new MSS.WinMobile.UI.Controls.Concret.RoutePointListBox();
            this._createOrderIcon = new MSS.WinMobile.UI.Controls.Buttons.PictureButton();
            this.routeViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this._actionPanel.SuspendLayout();
            this.panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.routeViewModelBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // _actionPanel
            // 
            this._actionPanel.Controls.Add(this._createOrderIcon);
            this._actionPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this._actionPanel.Location = new System.Drawing.Point(0, 0);
            this._actionPanel.Name = "_actionPanel";
            this._actionPanel.Size = new System.Drawing.Size(240, 24);
            // 
            // panel
            // 
            this.panel.Controls.Add(this.datePicker);
            this.panel.Controls.Add(this.dateLabel);
            this.panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel.Location = new System.Drawing.Point(0, 24);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(240, 26);
            // 
            // dateLabel
            // 
            this.dateLabel.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular);
            this.dateLabel.Location = new System.Drawing.Point(3, 2);
            this.dateLabel.Name = "dateLabel";
            this.dateLabel.Size = new System.Drawing.Size(40, 20);
            this.dateLabel.Text = "Date";
            // 
            // datePicker
            // 
            this.datePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.routeViewModelBindingSource, "Date", true));
            this.datePicker.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular);
            this.datePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.datePicker.Location = new System.Drawing.Point(49, 2);
            this.datePicker.Name = "datePicker";
            this.datePicker.Size = new System.Drawing.Size(188, 22);
            this.datePicker.TabIndex = 1;
            this.datePicker.ValueChanged += new System.EventHandler(this.DatePickerValueChanged);
            // 
            // routePointListBox
            // 
            this.routePointListBox.BackColor = System.Drawing.Color.White;
            this.routePointListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.routePointListBox.Location = new System.Drawing.Point(0, 50);
            this.routePointListBox.Name = "routePointListBox";
            this.routePointListBox.Size = new System.Drawing.Size(240, 244);
            this.routePointListBox.TabIndex = 3;
            // 
            // _createOrderIcon
            // 
            this._createOrderIcon.BackColor = System.Drawing.Color.White;
            this._createOrderIcon.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("_createOrderIcon.BackgroundImage")));
            this._createOrderIcon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._createOrderIcon.Location = new System.Drawing.Point(2, 2);
            this._createOrderIcon.Name = "_createOrderIcon";
            this._createOrderIcon.PressedImage = null;
            this._createOrderIcon.Size = new System.Drawing.Size(20, 20);
            this._createOrderIcon.TabIndex = 0;
            this._createOrderIcon.Click += new System.EventHandler(this.CreateOrderClick);
            // 
            // routeViewModelBindingSource
            // 
            this.routeViewModelBindingSource.DataSource = typeof(MSS.WinMobile.UI.Presenters.ViewModels.RouteViewModel);
            // 
            // RouteView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(240, 294);
            this.Controls.Add(this.routePointListBox);
            this.Controls.Add(this.panel);
            this.Controls.Add(this._actionPanel);
            this.Name = "RouteView";
            this.Load += new System.EventHandler(this.ViewLoad);
            this._actionPanel.ResumeLayout(false);
            this.panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.routeViewModelBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel _actionPanel;
        private PictureButton _createOrderIcon;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.DateTimePicker datePicker;
        private System.Windows.Forms.Label dateLabel;
        private MSS.WinMobile.UI.Controls.Concret.RoutePointListBox routePointListBox;
        private System.Windows.Forms.BindingSource routeViewModelBindingSource;
    }
}
