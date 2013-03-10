namespace MSS.WinMobile.UI.Views
{
    partial class OrderView
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
            this.tabControl = new System.Windows.Forms.TabControl();
            this._generalTab = new System.Windows.Forms.TabPage();
            this._detailsTab = new System.Windows.Forms.TabPage();
            this._notesTab = new System.Windows.Forms.TabPage();
            this.tabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this._generalTab);
            this.tabControl.Controls.Add(this._detailsTab);
            this.tabControl.Controls.Add(this._notesTab);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(240, 294);
            this.tabControl.TabIndex = 0;
            // 
            // _generalTab
            // 
            this._generalTab.Location = new System.Drawing.Point(0, 0);
            this._generalTab.Name = "_generalTab";
            this._generalTab.Size = new System.Drawing.Size(240, 271);
            this._generalTab.Text = "General";
            // 
            // _detailsTab
            // 
            this._detailsTab.Location = new System.Drawing.Point(0, 0);
            this._detailsTab.Name = "_detailsTab";
            this._detailsTab.Size = new System.Drawing.Size(240, 271);
            this._detailsTab.Text = "Details";
            // 
            // _notesTab
            // 
            this._notesTab.Location = new System.Drawing.Point(0, 0);
            this._notesTab.Name = "_notesTab";
            this._notesTab.Size = new System.Drawing.Size(240, 271);
            this._notesTab.Text = "Notes";
            // 
            // OrderView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 294);
            this.Controls.Add(this.tabControl);
            this.Name = "OrderView";
            this.Text = "OrderView";
            this.Load += new System.EventHandler(this.OrderView_Load);
            this.tabControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage _generalTab;
        private System.Windows.Forms.TabPage _detailsTab;
        private System.Windows.Forms.TabPage _notesTab;

    }
}