namespace MSS.WinMobile.UI.Controls.ListBox
{
    partial class VirtualListBox
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
        protected void InitializeComponent()
        {
            this._dataPanel = new System.Windows.Forms.Panel();
            this._vScrollBar = new System.Windows.Forms.VScrollBar();
            this.SuspendLayout();
            // 
            // _dataPanel
            // 
            this._dataPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._dataPanel.Location = new System.Drawing.Point(0, 0);
            this._dataPanel.Name = "_dataPanel";
            this._dataPanel.Size = new System.Drawing.Size(226, 297);
            this._dataPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.DataPanelPaint);
            // 
            // _vScrollBar
            // 
            this._vScrollBar.Dock = System.Windows.Forms.DockStyle.Right;
            this._vScrollBar.Location = new System.Drawing.Point(213, 0);
            this._vScrollBar.Name = "_vScrollBar";
            this._vScrollBar.Size = new System.Drawing.Size(13, 297);
            this._vScrollBar.TabIndex = 0;
            this._vScrollBar.Visible = false;
            this._vScrollBar.ValueChanged += new System.EventHandler(this.VScrollBarValueChanged);
            // 
            // VirtualListBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this._vScrollBar);
            this.Controls.Add(this._dataPanel);
            this.Name = "VirtualListBox";
            this.Size = new System.Drawing.Size(226, 297);
            this.Resize += new System.EventHandler(this.VirtualListBoxResize);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.VScrollBar _vScrollBar;
        private System.Windows.Forms.Panel _dataPanel;
    }
}
