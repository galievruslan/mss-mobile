namespace MSS.WinMobile.UI.Views
{
    partial class RouteListView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RouteListView));
            this._actionPanel = new System.Windows.Forms.Panel();
            this._openRouteIcon = new MSS.WinMobile.UI.Controls.Buttons.PictureButton();
            this._createRouteIcon = new MSS.WinMobile.UI.Controls.Buttons.PictureButton();
            this.routeListBox = new MSS.WinMobile.UI.Controls.Concret.RouteListBox();
            this._actionPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // _actionPanel
            // 
            this._actionPanel.Controls.Add(this._openRouteIcon);
            this._actionPanel.Controls.Add(this._createRouteIcon);
            this._actionPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this._actionPanel.Location = new System.Drawing.Point(0, 0);
            this._actionPanel.Name = "_actionPanel";
            this._actionPanel.Size = new System.Drawing.Size(240, 24);
            // 
            // _openRouteIcon
            // 
            this._openRouteIcon.BackColor = System.Drawing.Color.White;
            this._openRouteIcon.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("_openRouteIcon.BackgroundImage")));
            this._openRouteIcon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._openRouteIcon.Location = new System.Drawing.Point(2, 2);
            this._openRouteIcon.Name = "_openRouteIcon";
            this._openRouteIcon.PressedImage = null;
            this._openRouteIcon.Size = new System.Drawing.Size(20, 20);
            this._openRouteIcon.TabIndex = 1;
            this._openRouteIcon.Click += new System.EventHandler(this.OpenRouteClick);
            // 
            // _createRouteIcon
            // 
            this._createRouteIcon.BackColor = System.Drawing.Color.White;
            this._createRouteIcon.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("_createRouteIcon.BackgroundImage")));
            this._createRouteIcon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._createRouteIcon.Location = new System.Drawing.Point(24, 2);
            this._createRouteIcon.Name = "_createRouteIcon";
            this._createRouteIcon.PressedImage = null;
            this._createRouteIcon.Size = new System.Drawing.Size(20, 20);
            this._createRouteIcon.TabIndex = 0;
            this._createRouteIcon.Click += new System.EventHandler(this.CreateRouteClick);
            // 
            // routeListBox
            // 
            this.routeListBox.BackColor = System.Drawing.Color.White;
            this.routeListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.routeListBox.Location = new System.Drawing.Point(0, 24);
            this.routeListBox.Name = "routeListBox";
            this.routeListBox.Size = new System.Drawing.Size(240, 270);
            this.routeListBox.TabIndex = 2;
            // 
            // RouteListView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 294);
            this.Controls.Add(this.routeListBox);
            this.Controls.Add(this._actionPanel);
            this.Name = "RouteListView";
            this.Text = "RouteListView";
            this.Load += new System.EventHandler(this.ViewLoad);
            this._actionPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel _actionPanel;
        private MSS.WinMobile.UI.Controls.Buttons.PictureButton _createRouteIcon;
        private MSS.WinMobile.UI.Controls.Concret.RouteListBox routeListBox;
        private MSS.WinMobile.UI.Controls.Buttons.PictureButton _openRouteIcon;
    }
}