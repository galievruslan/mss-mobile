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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RouteView));
            this._routeVirtualListBox = new MSS.WinMobile.UI.Controls.ListBox.VirtualListBox();
            this._actionPanel = new System.Windows.Forms.Panel();
            this._createOrderIcon = new MSS.WinMobile.UI.Controls.PictureButton();
            this._actionPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // _routeVirtualListBox
            // 
            this._routeVirtualListBox.BackColor = System.Drawing.Color.White;
            this._routeVirtualListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this._routeVirtualListBox.ItemCount = 0;
            this._routeVirtualListBox.Location = new System.Drawing.Point(0, 30);
            this._routeVirtualListBox.Name = "_routeVirtualListBox";
            this._routeVirtualListBox.SelectedIndex = 0;
            this._routeVirtualListBox.Size = new System.Drawing.Size(240, 264);
            this._routeVirtualListBox.TabIndex = 0;
            // 
            // _actionPanel
            // 
            this._actionPanel.Controls.Add(this._createOrderIcon);
            this._actionPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this._actionPanel.Location = new System.Drawing.Point(0, 0);
            this._actionPanel.Name = "_actionPanel";
            this._actionPanel.Size = new System.Drawing.Size(240, 30);
            // 
            // _createOrderIcon
            // 
            this._createOrderIcon.BackColor = System.Drawing.Color.White;
            this._createOrderIcon.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("_createOrderIcon.BackgroundImage")));
            this._createOrderIcon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._createOrderIcon.Location = new System.Drawing.Point(3, 3);
            this._createOrderIcon.Name = "_createOrderIcon";
            this._createOrderIcon.PressedImage = null;
            this._createOrderIcon.Size = new System.Drawing.Size(24, 24);
            this._createOrderIcon.TabIndex = 0;
            this._createOrderIcon.Click += new System.EventHandler(this._createOrderIcon_Click);
            // 
            // RouteView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(240, 294);
            this.Controls.Add(this._routeVirtualListBox);
            this.Controls.Add(this._actionPanel);
            this.Name = "RouteView";
            this.Load += new System.EventHandler(this.RouteView_Load);
            this._actionPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MSS.WinMobile.UI.Controls.ListBox.VirtualListBox _routeVirtualListBox;
        private System.Windows.Forms.Panel _actionPanel;
        private MSS.WinMobile.UI.Controls.PictureButton _createOrderIcon;
    }
}
