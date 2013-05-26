namespace MSS.WinMobile.UI.Views.Views {
    partial class RouteView {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RouteView));
            this._createOrderButton = new MSS.WinMobile.UI.Controls.Buttons.PictureButton();
            this._createRoutePointButton = new MSS.WinMobile.UI.Controls.Buttons.PictureButton();
            this.divisorLabel = new System.Windows.Forms.Label();
            this._listOrdersButton = new MSS.WinMobile.UI.Controls.Buttons.PictureButton();
            this._actionPanel = new System.Windows.Forms.Panel();
            this._changeStatusButton = new MSS.WinMobile.UI.Controls.Buttons.PictureButton();
            this._deleteRoutePointButton = new MSS.WinMobile.UI.Controls.Buttons.PictureButton();
            this.datePicker = new System.Windows.Forms.DateTimePicker();
            this.createRouteOnDateButton = new MSS.WinMobile.UI.Controls.Buttons.PictureButton();
            this.panel = new System.Windows.Forms.Panel();
            this.routePointListBox = new MSS.WinMobile.UI.Controls.Concret.RoutePointListBox();
            this._actionPanel.SuspendLayout();
            this.panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // _createOrderButton
            // 
            this._createOrderButton.BackColor = System.Drawing.Color.White;
            this._createOrderButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("_createOrderButton.BackgroundImage")));
            this._createOrderButton.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._createOrderButton.Location = new System.Drawing.Point(94, 2);
            this._createOrderButton.Name = "_createOrderButton";
            this._createOrderButton.PressedImage = null;
            this._createOrderButton.Size = new System.Drawing.Size(20, 20);
            this._createOrderButton.TabIndex = 0;
            this._createOrderButton.Click += new System.EventHandler(this.CreateOrderClick);
            // 
            // _createRoutePointButton
            // 
            this._createRoutePointButton.BackColor = System.Drawing.Color.White;
            this._createRoutePointButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("_createRoutePointButton.BackgroundImage")));
            this._createRoutePointButton.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._createRoutePointButton.Location = new System.Drawing.Point(2, 2);
            this._createRoutePointButton.Name = "_createRoutePointButton";
            this._createRoutePointButton.PressedImage = null;
            this._createRoutePointButton.Size = new System.Drawing.Size(20, 20);
            this._createRoutePointButton.TabIndex = 1;
            this._createRoutePointButton.Click += new System.EventHandler(this.CreateRoutePointButtonClick);
            // 
            // divisorLabel
            // 
            this.divisorLabel.Location = new System.Drawing.Point(64, 3);
            this.divisorLabel.Name = "divisorLabel";
            this.divisorLabel.Size = new System.Drawing.Size(5, 20);
            this.divisorLabel.Text = "|";
            // 
            // _listOrdersButton
            // 
            this._listOrdersButton.BackColor = System.Drawing.Color.White;
            this._listOrdersButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("_listOrdersButton.BackgroundImage")));
            this._listOrdersButton.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._listOrdersButton.Location = new System.Drawing.Point(72, 2);
            this._listOrdersButton.Name = "_listOrdersButton";
            this._listOrdersButton.PressedImage = null;
            this._listOrdersButton.Size = new System.Drawing.Size(20, 20);
            this._listOrdersButton.TabIndex = 3;
            this._listOrdersButton.Click += new System.EventHandler(this.ListOrdersButtonClick);
            // 
            // _actionPanel
            // 
            this._actionPanel.Controls.Add(this._changeStatusButton);
            this._actionPanel.Controls.Add(this._deleteRoutePointButton);
            this._actionPanel.Controls.Add(this._listOrdersButton);
            this._actionPanel.Controls.Add(this.divisorLabel);
            this._actionPanel.Controls.Add(this._createRoutePointButton);
            this._actionPanel.Controls.Add(this._createOrderButton);
            this._actionPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this._actionPanel.Location = new System.Drawing.Point(0, 0);
            this._actionPanel.Name = "_actionPanel";
            this._actionPanel.Size = new System.Drawing.Size(240, 24);
            // 
            // _changeStatusButton
            // 
            this._changeStatusButton.BackColor = System.Drawing.Color.White;
            this._changeStatusButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("_changeStatusButton.BackgroundImage")));
            this._changeStatusButton.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._changeStatusButton.Location = new System.Drawing.Point(46, 2);
            this._changeStatusButton.Name = "_changeStatusButton";
            this._changeStatusButton.PressedImage = null;
            this._changeStatusButton.Size = new System.Drawing.Size(20, 20);
            this._changeStatusButton.TabIndex = 9;
            this._changeStatusButton.Click += new System.EventHandler(this.ChangeStatusButtonClick);
            // 
            // _deleteRoutePointButton
            // 
            this._deleteRoutePointButton.BackColor = System.Drawing.Color.White;
            this._deleteRoutePointButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("_deleteRoutePointButton.BackgroundImage")));
            this._deleteRoutePointButton.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._deleteRoutePointButton.Location = new System.Drawing.Point(24, 2);
            this._deleteRoutePointButton.Name = "_deleteRoutePointButton";
            this._deleteRoutePointButton.PressedImage = null;
            this._deleteRoutePointButton.Size = new System.Drawing.Size(20, 20);
            this._deleteRoutePointButton.TabIndex = 7;
            this._deleteRoutePointButton.Click += new System.EventHandler(this.DeleteRoutePointButtonClick);
            // 
            // datePicker
            // 
            this.datePicker.CustomFormat = "dd.MM.yyyy";
            this.datePicker.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular);
            this.datePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datePicker.Location = new System.Drawing.Point(2, 1);
            this.datePicker.Name = "datePicker";
            this.datePicker.Size = new System.Drawing.Size(208, 22);
            this.datePicker.TabIndex = 1;
            // 
            // createRouteOnDateButton
            // 
            this.createRouteOnDateButton.BackColor = System.Drawing.Color.White;
            this.createRouteOnDateButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("createRouteOnDateButton.BackgroundImage")));
            this.createRouteOnDateButton.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.createRouteOnDateButton.Location = new System.Drawing.Point(216, 2);
            this.createRouteOnDateButton.Name = "createRouteOnDateButton";
            this.createRouteOnDateButton.PressedImage = null;
            this.createRouteOnDateButton.Size = new System.Drawing.Size(20, 20);
            this.createRouteOnDateButton.TabIndex = 3;
            this.createRouteOnDateButton.Click += new System.EventHandler(this.CreateRouteOnDateButtonClick);
            // 
            // panel
            // 
            this.panel.Controls.Add(this.createRouteOnDateButton);
            this.panel.Controls.Add(this.datePicker);
            this.panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel.Location = new System.Drawing.Point(0, 24);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(240, 24);
            // 
            // routePointListBox
            // 
            this.routePointListBox.BackColor = System.Drawing.Color.White;
            this.routePointListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.routePointListBox.Location = new System.Drawing.Point(0, 48);
            this.routePointListBox.Name = "routePointListBox";
            this.routePointListBox.Size = new System.Drawing.Size(240, 220);
            this.routePointListBox.TabIndex = 6;
            // 
            // RouteView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.routePointListBox);
            this.Controls.Add(this.panel);
            this.Controls.Add(this._actionPanel);
            this.Name = "RouteView";
            this.Load += new MSS.WinMobile.UI.Views.Views.View.OnLoad(this.RouteViewLoad);
            this._actionPanel.ResumeLayout(false);
            this.panel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MSS.WinMobile.UI.Controls.Buttons.PictureButton _createOrderButton;
        private MSS.WinMobile.UI.Controls.Buttons.PictureButton _createRoutePointButton;
        private System.Windows.Forms.Label divisorLabel;
        private MSS.WinMobile.UI.Controls.Buttons.PictureButton _listOrdersButton;
        private System.Windows.Forms.Panel _actionPanel;
        private System.Windows.Forms.DateTimePicker datePicker;
        private MSS.WinMobile.UI.Controls.Buttons.PictureButton createRouteOnDateButton;
        private System.Windows.Forms.Panel panel;
        private MSS.WinMobile.UI.Controls.Concret.RoutePointListBox routePointListBox;
        private MSS.WinMobile.UI.Controls.Buttons.PictureButton _deleteRoutePointButton;
        private MSS.WinMobile.UI.Controls.Buttons.PictureButton _changeStatusButton;

    }
}
