namespace MSS.WinMobile.UI.Views
{
    partial class OrderListView
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrderListView));
            this._actionPanel = new System.Windows.Forms.Panel();
            this._orderListBox = new MSS.WinMobile.UI.Controls.Concret.OrderListBox();
            this._editOrderButton = new MSS.WinMobile.UI.Controls.Buttons.PictureButton();
            this._createOrderButton = new MSS.WinMobile.UI.Controls.Buttons.PictureButton();
            this._sendOrderButton = new MSS.WinMobile.UI.Controls.Buttons.PictureButton();
            this._actionPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // _actionPanel
            // 
            this._actionPanel.Controls.Add(this._sendOrderButton);
            this._actionPanel.Controls.Add(this._editOrderButton);
            this._actionPanel.Controls.Add(this._createOrderButton);
            this._actionPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this._actionPanel.Location = new System.Drawing.Point(0, 0);
            this._actionPanel.Name = "_actionPanel";
            this._actionPanel.Size = new System.Drawing.Size(240, 24);
            // 
            // _orderListBox
            // 
            this._orderListBox.BackColor = System.Drawing.Color.White;
            this._orderListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this._orderListBox.Location = new System.Drawing.Point(0, 24);
            this._orderListBox.Name = "_orderListBox";
            this._orderListBox.Size = new System.Drawing.Size(240, 270);
            this._orderListBox.TabIndex = 2;
            // 
            // _editOrderButton
            // 
            this._editOrderButton.BackColor = System.Drawing.Color.White;
            this._editOrderButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("_editOrderButton.BackgroundImage")));
            this._editOrderButton.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._editOrderButton.Location = new System.Drawing.Point(24, 2);
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
            // _sendOrderButton
            // 
            this._sendOrderButton.BackColor = System.Drawing.Color.White;
            this._sendOrderButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("_sendOrderButton.BackgroundImage")));
            this._sendOrderButton.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._sendOrderButton.Location = new System.Drawing.Point(46, 2);
            this._sendOrderButton.Name = "_sendOrderButton";
            this._sendOrderButton.PressedImage = null;
            this._sendOrderButton.Size = new System.Drawing.Size(20, 20);
            this._sendOrderButton.TabIndex = 2;
            this._sendOrderButton.Click += new System.EventHandler(this.SendOrderClick);
            // 
            // OrderListView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 294);
            this.Controls.Add(this._orderListBox);
            this.Controls.Add(this._actionPanel);
            this.Name = "OrderListView";
            this.Text = "OrderListView";
            this.Load += new System.EventHandler(this.ViewLoad);
            this._actionPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel _actionPanel;
        private MSS.WinMobile.UI.Controls.Buttons.PictureButton _createOrderButton;
        private MSS.WinMobile.UI.Controls.Concret.OrderListBox _orderListBox;
        private MSS.WinMobile.UI.Controls.Buttons.PictureButton _editOrderButton;
        private MSS.WinMobile.UI.Controls.Buttons.PictureButton _sendOrderButton;
    }
}