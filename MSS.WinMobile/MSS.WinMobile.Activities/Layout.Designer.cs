using MSS.WinMobile.UI.Activities.Controls;

namespace MSS.WinMobile.UI.Activities
{
    partial class Layout
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Layout));
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this._pMenu = new System.Windows.Forms.Panel();
            this._pBody = new System.Windows.Forms.Panel();
            this._pbHome = new PictureButton();
            this._pMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // _pMenu
            // 
            this._pMenu.BackColor = System.Drawing.SystemColors.Info;
            this._pMenu.Controls.Add(this._pbHome);
            this._pMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this._pMenu.Location = new System.Drawing.Point(0, 0);
            this._pMenu.Name = "_pMenu";
            this._pMenu.Size = new System.Drawing.Size(240, 35);
            // 
            // _pBody
            // 
            this._pBody.BackColor = System.Drawing.Color.LightGreen;
            this._pBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this._pBody.Location = new System.Drawing.Point(0, 35);
            this._pBody.Name = "_pBody";
            this._pBody.Size = new System.Drawing.Size(240, 233);
            // 
            // _pbHome
            // 
            this._pbHome.BackColor = System.Drawing.Color.Transparent;
            this._pbHome.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("_pbHome.BackgroundImage")));
            this._pbHome.Location = new System.Drawing.Point(3, 3);
            this._pbHome.Name = "_pbHome";
            this._pbHome.PressedImage = null;
            this._pbHome.Size = new System.Drawing.Size(30, 30);
            this._pbHome.TabIndex = 0;
            this._pbHome.Click += new System.EventHandler(this.PbHomeClick);
            // 
            // Layout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this._pBody);
            this.Controls.Add(this._pMenu);
            this.Menu = this.mainMenu1;
            this.Name = "Layout";
            this.Text = "Main";
            this._pMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel _pMenu;
        private System.Windows.Forms.Panel _pBody;
        private PictureButton _pbHome;

    }
}