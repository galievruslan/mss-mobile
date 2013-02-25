﻿namespace MSS.WinMobile.UI.Controls.ListBox
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
            this._mainPanel = new System.Windows.Forms.Panel();
            this._dataPanel = new System.Windows.Forms.Panel();
            this._vScrollBar = new System.Windows.Forms.VScrollBar();
            this._mainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // _mainPanel
            // 
            this._mainPanel.BackColor = System.Drawing.Color.White;
            this._mainPanel.Controls.Add(this._dataPanel);
            this._mainPanel.Controls.Add(this._vScrollBar);
            this._mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._mainPanel.Location = new System.Drawing.Point(0, 0);
            this._mainPanel.Name = "_mainPanel";
            this._mainPanel.Size = new System.Drawing.Size(226, 297);
            // 
            // _dataPanel
            // 
            this._dataPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._dataPanel.Location = new System.Drawing.Point(0, 0);
            this._dataPanel.Name = "_dataPanel";
            this._dataPanel.Size = new System.Drawing.Size(213, 297);
            // 
            // _vScrollBar
            // 
            this._vScrollBar.Dock = System.Windows.Forms.DockStyle.Right;
            this._vScrollBar.Location = new System.Drawing.Point(213, 0);
            this._vScrollBar.Name = "_vScrollBar";
            this._vScrollBar.Size = new System.Drawing.Size(13, 297);
            this._vScrollBar.TabIndex = 0;
            this._vScrollBar.ValueChanged += new System.EventHandler(this.VScrollBarValueChanged);
            // 
            // VirtualListBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this._mainPanel);
            this.Name = "VirtualListBox";
            this.Size = new System.Drawing.Size(226, 297);
            this._mainPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel _mainPanel;
        private System.Windows.Forms.VScrollBar _vScrollBar;
        private System.Windows.Forms.Panel _dataPanel;
    }
}