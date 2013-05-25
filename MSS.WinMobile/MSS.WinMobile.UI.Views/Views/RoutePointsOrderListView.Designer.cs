namespace MSS.WinMobile.UI.Views.Views {
    partial class RoutePointsOrderListView {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RoutePointsOrderListView));
            this._actionPanel = new System.Windows.Forms.Panel();
            this._closeButton = new MSS.WinMobile.UI.Controls.Buttons.PictureButton();
            this._editOrderButton = new MSS.WinMobile.UI.Controls.Buttons.PictureButton();
            this._createOrderButton = new MSS.WinMobile.UI.Controls.Buttons.PictureButton();
            this._orderListBox = new MSS.WinMobile.UI.Controls.Concret.OrderListBox();
            this._deleteOrderButton = new MSS.WinMobile.UI.Controls.Buttons.PictureButton();
            this._actionPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // _actionPanel
            // 
            this._actionPanel.Controls.Add(this._deleteOrderButton);
            this._actionPanel.Controls.Add(this._closeButton);
            this._actionPanel.Controls.Add(this._editOrderButton);
            this._actionPanel.Controls.Add(this._createOrderButton);
            this._actionPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this._actionPanel.Location = new System.Drawing.Point(0, 0);
            this._actionPanel.Name = "_actionPanel";
            this._actionPanel.Size = new System.Drawing.Size(240, 24);
            // 
            // _closeButton
            // 
            this._closeButton.BackColor = System.Drawing.Color.White;
            this._closeButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("_closeButton.BackgroundImage")));
            this._closeButton.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._closeButton.Location = new System.Drawing.Point(218, 2);
            this._closeButton.Name = "_closeButton";
            this._closeButton.PressedImage = null;
            this._closeButton.Size = new System.Drawing.Size(20, 20);
            this._closeButton.TabIndex = 6;
            this._closeButton.Click += new System.EventHandler(this.CloseButtonClick);
            // 
            // _editOrderButton
            // 
            this._editOrderButton.BackColor = System.Drawing.Color.White;
            this._editOrderButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("_editOrderButton.BackgroundImage")));
            this._editOrderButton.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._editOrderButton.Location = new System.Drawing.Point(46, 2);
            this._editOrderButton.Name = "_editOrderButton";
            this._editOrderButton.PressedImage = null;
            this._editOrderButton.Size = new System.Drawing.Size(20, 20);
            this._editOrderButton.TabIndex = 1;
            this._editOrderButton.Click += new System.EventHandler(this.EditOrderClick);
            // 
            // _createOrderButton
            // 
            this._createOrderButton.BackColor = System.Drawing.Color.White;
            this._createOrderButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("_createOrderButton.BackgroundImage")));
            this._createOrderButton.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._createOrderButton.Location = new System.Drawing.Point(2, 2);
            this._createOrderButton.Name = "_createOrderButton";
            this._createOrderButton.PressedImage = null;
            this._createOrderButton.Size = new System.Drawing.Size(20, 20);
            this._createOrderButton.TabIndex = 0;
            this._createOrderButton.Click += new System.EventHandler(this.CreateOrderClick);
            // 
            // _orderListBox
            // 
            this._orderListBox.BackColor = System.Drawing.Color.White;
            this._orderListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this._orderListBox.Location = new System.Drawing.Point(0, 24);
            this._orderListBox.Name = "_orderListBox";
            this._orderListBox.Size = new System.Drawing.Size(240, 244);
            this._orderListBox.TabIndex = 4;
            // 
            // _deleteOrderButton
            // 
            this._deleteOrderButton.BackColor = System.Drawing.Color.White;
            this._deleteOrderButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("_deleteOrderButton.BackgroundImage")));
            this._deleteOrderButton.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._deleteOrderButton.Location = new System.Drawing.Point(24, 2);
            this._deleteOrderButton.Name = "_deleteOrderButton";
            this._deleteOrderButton.PressedImage = null;
            this._deleteOrderButton.Size = new System.Drawing.Size(20, 20);
            this._deleteOrderButton.TabIndex = 7;
            this._deleteOrderButton.Click += new System.EventHandler(this.DeleteOrderButtonClick);
            // 
            // OrderListView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this._orderListBox);
            this.Controls.Add(this._actionPanel);
            this.Name = "OrderListView";
            this.Load += new MSS.WinMobile.UI.Views.Views.View.OnLoad(this.OrderListViewLoad);
            this._actionPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel _actionPanel;
        private MSS.WinMobile.UI.Controls.Buttons.PictureButton _editOrderButton;
        private MSS.WinMobile.UI.Controls.Buttons.PictureButton _createOrderButton;
        private MSS.WinMobile.UI.Controls.Concret.OrderListBox _orderListBox;
        private MSS.WinMobile.UI.Controls.Buttons.PictureButton _closeButton;
        private MSS.WinMobile.UI.Controls.Buttons.PictureButton _deleteOrderButton;
    }
}
