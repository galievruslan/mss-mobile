namespace MSS.WinMobile.UI.Views
{
    partial class Customers
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
            this.listBox1 = new System.Windows.Forms.ListBox();
            this._viewActionsPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.listBox1.Location = new System.Drawing.Point(0, 0);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(226, 254);
            this.listBox1.TabIndex = 0;
            // 
            // _viewActionsPanel
            // 
            this._viewActionsPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._viewActionsPanel.Location = new System.Drawing.Point(0, 249);
            this._viewActionsPanel.Name = "_viewActionsPanel";
            this._viewActionsPanel.Size = new System.Drawing.Size(226, 24);
            // 
            // Customers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this._viewActionsPanel);
            this.Controls.Add(this.listBox1);
            this.Name = "Customers";
            this.Size = new System.Drawing.Size(226, 273);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Panel _viewActionsPanel;
    }
}
