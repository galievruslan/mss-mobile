namespace MSS.WinMobile.UI.Views.LookUps
{
    partial class LookUpView
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
            this._mainMenu = new System.Windows.Forms.MainMenu();
            this._okMenuItem = new System.Windows.Forms.MenuItem();
            this._cancelMenuItem = new System.Windows.Forms.MenuItem();
            this._details = new Microsoft.WindowsCE.Forms.Notification();
            this._inputPanel = new Microsoft.WindowsCE.Forms.InputPanel();
            this.SuspendLayout();
            // 
            // _mainMenu
            // 
            this._mainMenu.MenuItems.Add(this._okMenuItem);
            this._mainMenu.MenuItems.Add(this._cancelMenuItem);
            // 
            // _okMenuItem
            // 
            this._okMenuItem.Text = "OK";
            this._okMenuItem.Click += new System.EventHandler(this.OkMenuItemClick);
            // 
            // _cancelMenuItem
            // 
            this._cancelMenuItem.Text = "Cancel";
            this._cancelMenuItem.Click += new System.EventHandler(this.CancelMenuItemClick);
            // 
            // _details
            // 
            this._details.Text = "notification1";
            // 
            // LookUpView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.KeyPreview = true;
            this.Menu = this._mainMenu;
            this.Name = "LookUpView";
            this.Text = "LookUpView";
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.WindowsCE.Forms.Notification _details;
        private System.Windows.Forms.MenuItem _okMenuItem;
        private System.Windows.Forms.MenuItem _cancelMenuItem;
        private Microsoft.WindowsCE.Forms.InputPanel _inputPanel;
        internal System.Windows.Forms.MainMenu _mainMenu;

    }
}