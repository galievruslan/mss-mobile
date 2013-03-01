namespace MSS.WinMobile.UI.Views.Layouts
{
    partial class Layout
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
            System.Windows.Forms.MainMenu _mainMenu;
            this._navigationPanel = new System.Windows.Forms.Panel();
            this._bodyPanel = new System.Windows.Forms.Panel();
            _mainMenu = new System.Windows.Forms.MainMenu();
            this.SuspendLayout();
            // 
            // _navigationPanel
            // 
            this._navigationPanel.BackColor = System.Drawing.Color.LightBlue;
            this._navigationPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this._navigationPanel.Location = new System.Drawing.Point(0, 0);
            this._navigationPanel.Name = "_navigationPanel";
            this._navigationPanel.Size = new System.Drawing.Size(240, 24);
            // 
            // _bodyPanel
            // 
            this._bodyPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._bodyPanel.Location = new System.Drawing.Point(0, 24);
            this._bodyPanel.Name = "_bodyPanel";
            this._bodyPanel.Size = new System.Drawing.Size(240, 244);
            // 
            // Layout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this._bodyPanel);
            this.Controls.Add(this._navigationPanel);
            this.Menu = _mainMenu;
            this.Name = "Layout";
            this.Text = "SimpleLayout";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel _navigationPanel;
        private System.Windows.Forms.Panel _bodyPanel;
    }
}