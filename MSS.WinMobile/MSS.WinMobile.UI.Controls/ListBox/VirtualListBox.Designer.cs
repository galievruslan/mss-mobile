namespace MSS.WinMobile.UI.Controls.ListBox
{
    partial class VirtualListBox<T>
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
            this._searchPanel = new System.Windows.Forms.Panel();
            this._dataPanel = new System.Windows.Forms.Panel();
            this._vScrollBar = new System.Windows.Forms.VScrollBar();
            this.searchPanel1 = new MSS.WinMobile.UI.Controls.ListBox.SearchPanel();
            this._searchPanel.SuspendLayout();
            this._dataPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // _searchPanel
            // 
            this._searchPanel.AutoScroll = true;
            this._searchPanel.BackColor = System.Drawing.Color.Coral;
            this._searchPanel.Controls.Add(this.searchPanel1);
            this._searchPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this._searchPanel.Location = new System.Drawing.Point(0, 0);
            this._searchPanel.Name = "_searchPanel";
            this._searchPanel.Size = new System.Drawing.Size(226, 21);
            // 
            // _dataPanel
            // 
            this._dataPanel.BackColor = System.Drawing.Color.SkyBlue;
            this._dataPanel.Controls.Add(this._vScrollBar);
            this._dataPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._dataPanel.Location = new System.Drawing.Point(0, 21);
            this._dataPanel.Name = "_dataPanel";
            this._dataPanel.Size = new System.Drawing.Size(226, 276);
            // 
            // _vScrollBar
            // 
            this._vScrollBar.Dock = System.Windows.Forms.DockStyle.Right;
            this._vScrollBar.Location = new System.Drawing.Point(213, 0);
            this._vScrollBar.Name = "_vScrollBar";
            this._vScrollBar.Size = new System.Drawing.Size(13, 276);
            this._vScrollBar.TabIndex = 0;
            this._vScrollBar.ValueChanged += new System.EventHandler(this.VScrollBarValueChanged);
            // 
            // searchPanel1
            // 
            this.searchPanel1.BackColor = System.Drawing.Color.White;
            this.searchPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.searchPanel1.Location = new System.Drawing.Point(0, 0);
            this.searchPanel1.Name = "searchPanel1";
            this.searchPanel1.Size = new System.Drawing.Size(226, 21);
            this.searchPanel1.TabIndex = 0;
            // 
            // VirtualListBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.PaleGreen;
            this.Controls.Add(this._dataPanel);
            this.Controls.Add(this._searchPanel);
            this.Name = "VirtualListBox";
            this.Size = new System.Drawing.Size(226, 297);
            this.Resize += new System.EventHandler(this.ListBoxResize);
            this._searchPanel.ResumeLayout(false);
            this._dataPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel _searchPanel;
        private System.Windows.Forms.Panel _dataPanel;
        private System.Windows.Forms.VScrollBar _vScrollBar;
        private SearchPanel searchPanel1;
    }
}
