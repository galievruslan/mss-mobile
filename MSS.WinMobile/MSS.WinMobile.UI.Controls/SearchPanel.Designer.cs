using MSS.WinMobile.UI.Controls.Buttons;

namespace MSS.WinMobile.UI.Controls
{
    partial class SearchPanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SearchPanel));
            this._buttonPanel = new System.Windows.Forms.Panel();
            this._searchButton = new PictureButton();
            this._inputPanel = new System.Windows.Forms.Panel();
            this._searchTextBox = new System.Windows.Forms.TextBox();
            this._buttonPanel.SuspendLayout();
            this._inputPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // _buttonPanel
            // 
            this._buttonPanel.BackColor = System.Drawing.Color.White;
            this._buttonPanel.Controls.Add(this._searchButton);
            this._buttonPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this._buttonPanel.Location = new System.Drawing.Point(214, 0);
            this._buttonPanel.Name = "_buttonPanel";
            this._buttonPanel.Size = new System.Drawing.Size(24, 24);
            // 
            // _searchButton
            // 
            this._searchButton.BackColor = System.Drawing.Color.White;
            this._searchButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("_searchButton.BackgroundImage")));
            this._searchButton.Location = new System.Drawing.Point(2, 2);
            this._searchButton.Name = "_searchButton";
            this._searchButton.Size = new System.Drawing.Size(20, 20);
            this._searchButton.TabIndex = 0;
            this._searchButton.Click += new System.EventHandler(this._searchButton_Click);
            // 
            // _inputPanel
            // 
            this._inputPanel.BackColor = System.Drawing.Color.White;
            this._inputPanel.Controls.Add(this._searchTextBox);
            this._inputPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this._inputPanel.Location = new System.Drawing.Point(0, 0);
            this._inputPanel.Name = "_inputPanel";
            this._inputPanel.Size = new System.Drawing.Size(214, 24);
            // 
            // _searchTextBox
            // 
            this._searchTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._searchTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._searchTextBox.Font = new System.Drawing.Font("Tahoma", 8.5F, System.Drawing.FontStyle.Regular);
            this._searchTextBox.ForeColor = System.Drawing.Color.Black;
            this._searchTextBox.Location = new System.Drawing.Point(2, 2);
            this._searchTextBox.Name = "_searchTextBox";
            this._searchTextBox.Size = new System.Drawing.Size(209, 20);
            this._searchTextBox.TabIndex = 0;
            this._searchTextBox.Text = "Search";
            // 
            // SearchPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this._inputPanel);
            this.Controls.Add(this._buttonPanel);
            this.Name = "SearchPanel";
            this.Size = new System.Drawing.Size(238, 24);
            this._buttonPanel.ResumeLayout(false);
            this._inputPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel _buttonPanel;
        private System.Windows.Forms.Panel _inputPanel;
        private System.Windows.Forms.TextBox _searchTextBox;
        private PictureButton _searchButton;
    }
}
