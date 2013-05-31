namespace MSS.WinMobile.UI.Views {
    partial class Main {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (_details != null) {
                _details.Dispose();
            }
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this._mainMenu = new System.Windows.Forms.MainMenu();
            this._leftButton = new System.Windows.Forms.MenuItem();
            this._rightButton = new System.Windows.Forms.MenuItem();
            this._details = new Microsoft.WindowsCE.Forms.Notification();
            this._inputPanel = new Microsoft.WindowsCE.Forms.InputPanel();
            this.SuspendLayout();
            // 
            // _mainMenu
            // 
            this._mainMenu.MenuItems.Add(this._leftButton);
            this._mainMenu.MenuItems.Add(this._rightButton);
            // 
            // _leftButton
            // 
            this._leftButton.Text = "LeftButton";
            // 
            // _rightButton
            // 
            this._rightButton.Text = "RightButton";
            // 
            // _details
            // 
            this._details.Text = "notification1";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Menu = this._mainMenu;
            this.Name = "Main";
            this.Text = "MSS";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MainMenu _mainMenu;
        private Microsoft.WindowsCE.Forms.Notification _details;
        internal Microsoft.WindowsCE.Forms.InputPanel _inputPanel;
        internal System.Windows.Forms.MenuItem _leftButton;
        internal System.Windows.Forms.MenuItem _rightButton;
    }
}