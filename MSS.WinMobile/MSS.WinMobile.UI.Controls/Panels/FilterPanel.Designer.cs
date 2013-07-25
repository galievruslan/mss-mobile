using MSS.WinMobile.UI.Controls.Buttons;

namespace MSS.WinMobile.UI.Controls.Panels
{
    partial class FilterPanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FilterPanel));
            this._buttonPanel = new System.Windows.Forms.Panel();
            this._inputPanel = new System.Windows.Forms.Panel();
            this._filterLabel = new System.Windows.Forms.Label();
            this._clearButton = new MSS.WinMobile.UI.Controls.Buttons.PictureButton();
            this._filterButton = new MSS.WinMobile.UI.Controls.Buttons.PictureButton();
            this._buttonPanel.SuspendLayout();
            this._inputPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // _buttonPanel
            // 
            this._buttonPanel.BackColor = System.Drawing.Color.White;
            this._buttonPanel.Controls.Add(this._clearButton);
            this._buttonPanel.Controls.Add(this._filterButton);
            this._buttonPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this._buttonPanel.Location = new System.Drawing.Point(190, 0);
            this._buttonPanel.Name = "_buttonPanel";
            this._buttonPanel.Size = new System.Drawing.Size(48, 22);
            // 
            // _inputPanel
            // 
            this._inputPanel.BackColor = System.Drawing.Color.White;
            this._inputPanel.Controls.Add(this._filterLabel);
            this._inputPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this._inputPanel.Location = new System.Drawing.Point(0, 0);
            this._inputPanel.Name = "_inputPanel";
            this._inputPanel.Size = new System.Drawing.Size(190, 22);
            // 
            // _filterLabel
            // 
            this._filterLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._filterLabel.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular);
            this._filterLabel.Location = new System.Drawing.Point(3, 3);
            this._filterLabel.Name = "_filterLabel";
            this._filterLabel.Size = new System.Drawing.Size(184, 16);
            // 
            // _clearButton
            // 
            this._clearButton.BackColor = System.Drawing.Color.White;
            this._clearButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("_clearButton.BackgroundImage")));
            this._clearButton.Location = new System.Drawing.Point(26, 1);
            this._clearButton.Name = "_clearButton";
            this._clearButton.PressedImage = ((System.Drawing.Image)(resources.GetObject("_clearButton.PressedImage")));
            this._clearButton.Size = new System.Drawing.Size(20, 20);
            this._clearButton.TabIndex = 2;
            this._clearButton.Click += new System.EventHandler(this.ClearButtonClick);
            // 
            // _filterButton
            // 
            this._filterButton.BackColor = System.Drawing.Color.White;
            this._filterButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("_filterButton.BackgroundImage")));
            this._filterButton.Location = new System.Drawing.Point(2, 1);
            this._filterButton.Name = "_filterButton";
            this._filterButton.PressedImage = ((System.Drawing.Image)(resources.GetObject("_filterButton.PressedImage")));
            this._filterButton.Size = new System.Drawing.Size(20, 20);
            this._filterButton.TabIndex = 0;
            this._filterButton.Click += new System.EventHandler(this.FilterButtonClick);
            // 
            // FilterPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this._inputPanel);
            this.Controls.Add(this._buttonPanel);
            this.Name = "FilterPanel";
            this.Size = new System.Drawing.Size(238, 22);
            this._buttonPanel.ResumeLayout(false);
            this._inputPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel _buttonPanel;
        private System.Windows.Forms.Panel _inputPanel;
        private PictureButton _filterButton;
        private PictureButton _clearButton;
        private System.Windows.Forms.Label _filterLabel;
    }
}
