namespace MSS.WinMobile.UI.Views
{
    partial class MenuView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MainMenu mainMenu1;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuView));
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this._goRouteButton = new MSS.WinMobile.UI.Controls.PictureButton();
            this._goCustomersButton = new MSS.WinMobile.UI.Controls.PictureButton();
            this._goBaliBaliButton = new MSS.WinMobile.UI.Controls.PictureButton();
            this._goSynchronizationButton = new MSS.WinMobile.UI.Controls.PictureButton();
            this.SuspendLayout();
            // 
            // _goRouteButton
            // 
            this._goRouteButton.BackColor = System.Drawing.Color.White;
            this._goRouteButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("_goRouteButton.BackgroundImage")));
            this._goRouteButton.Location = new System.Drawing.Point(3, 3);
            this._goRouteButton.Name = "_goRouteButton";
            this._goRouteButton.PressedImage = null;
            this._goRouteButton.Size = new System.Drawing.Size(110, 110);
            this._goRouteButton.TabIndex = 0;
            this._goRouteButton.Click += new System.EventHandler(this._goRouteButton_Click);
            // 
            // _goCustomersButton
            // 
            this._goCustomersButton.BackColor = System.Drawing.Color.White;
            this._goCustomersButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("_goCustomersButton.BackgroundImage")));
            this._goCustomersButton.Location = new System.Drawing.Point(127, 3);
            this._goCustomersButton.Name = "_goCustomersButton";
            this._goCustomersButton.PressedImage = null;
            this._goCustomersButton.Size = new System.Drawing.Size(110, 110);
            this._goCustomersButton.TabIndex = 1;
            this._goCustomersButton.Click += new System.EventHandler(this._goCustomersButton_Click);
            // 
            // _goBaliBaliButton
            // 
            this._goBaliBaliButton.BackColor = System.Drawing.Color.White;
            this._goBaliBaliButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("_goBaliBaliButton.BackgroundImage")));
            this._goBaliBaliButton.Location = new System.Drawing.Point(127, 128);
            this._goBaliBaliButton.Name = "_goBaliBaliButton";
            this._goBaliBaliButton.PressedImage = null;
            this._goBaliBaliButton.Size = new System.Drawing.Size(110, 110);
            this._goBaliBaliButton.TabIndex = 3;
            this._goBaliBaliButton.Click += new System.EventHandler(this._goBaliBaliButton_Click);
            // 
            // _goSynchronizationButton
            // 
            this._goSynchronizationButton.BackColor = System.Drawing.Color.White;
            this._goSynchronizationButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("_goSynchronizationButton.BackgroundImage")));
            this._goSynchronizationButton.Location = new System.Drawing.Point(3, 128);
            this._goSynchronizationButton.Name = "_goSynchronizationButton";
            this._goSynchronizationButton.PressedImage = null;
            this._goSynchronizationButton.Size = new System.Drawing.Size(110, 110);
            this._goSynchronizationButton.TabIndex = 2;
            this._goSynchronizationButton.Click += new System.EventHandler(this._goSynchronizationButton_Click);
            // 
            // MenuView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this._goBaliBaliButton);
            this.Controls.Add(this._goSynchronizationButton);
            this.Controls.Add(this._goCustomersButton);
            this.Controls.Add(this._goRouteButton);
            this.Menu = this.mainMenu1;
            this.Name = "MenuView";
            this.Text = "MenuView";
            this.ResumeLayout(false);

        }

        #endregion

        private MSS.WinMobile.UI.Controls.PictureButton _goRouteButton;
        private MSS.WinMobile.UI.Controls.PictureButton _goCustomersButton;
        private MSS.WinMobile.UI.Controls.PictureButton _goBaliBaliButton;
        private MSS.WinMobile.UI.Controls.PictureButton _goSynchronizationButton;

    }
}