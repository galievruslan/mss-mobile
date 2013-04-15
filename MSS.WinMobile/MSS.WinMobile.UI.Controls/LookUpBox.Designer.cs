using MSS.WinMobile.UI.Controls.Buttons;

namespace MSS.WinMobile.UI.Controls
{
    partial class LookUpBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LookUpBox));
            this._inputPanel = new System.Windows.Forms.Panel();
            this._valueLabel = new System.Windows.Forms.Label();
            this._buttonPanel = new System.Windows.Forms.Panel();
            this.resetButton = new PictureButton();
            this.lookUpButton = new PictureButton();
            this._inputPanel.SuspendLayout();
            this._buttonPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // _inputPanel
            // 
            this._inputPanel.BackColor = System.Drawing.Color.DarkOrange;
            this._inputPanel.Controls.Add(this._valueLabel);
            this._inputPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this._inputPanel.Location = new System.Drawing.Point(0, 0);
            this._inputPanel.Name = "_inputPanel";
            this._inputPanel.Size = new System.Drawing.Size(154, 24);
            // 
            // _valueLabel
            // 
            this._valueLabel.BackColor = System.Drawing.Color.White;
            this._valueLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._valueLabel.Location = new System.Drawing.Point(0, 0);
            this._valueLabel.Name = "_valueLabel";
            this._valueLabel.Size = new System.Drawing.Size(154, 24);
            this._valueLabel.Text = "- none -";
            this._valueLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // _buttonPanel
            // 
            this._buttonPanel.BackColor = System.Drawing.Color.White;
            this._buttonPanel.Controls.Add(this.resetButton);
            this._buttonPanel.Controls.Add(this.lookUpButton);
            this._buttonPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this._buttonPanel.Location = new System.Drawing.Point(154, 0);
            this._buttonPanel.Name = "_buttonPanel";
            this._buttonPanel.Size = new System.Drawing.Size(44, 22);
            // 
            // resetButton
            // 
            this.resetButton.BackColor = System.Drawing.Color.White;
            this.resetButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("resetButton.BackgroundImage")));
            this.resetButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.resetButton.Location = new System.Drawing.Point(22, 0);
            this.resetButton.Name = "resetButton";
            this.resetButton.PressedImage = null;
            this.resetButton.Size = new System.Drawing.Size(22, 22);
            this.resetButton.TabIndex = 1;
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // lookUpButton
            // 
            this.lookUpButton.BackColor = System.Drawing.Color.White;
            this.lookUpButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("lookUpButton.BackgroundImage")));
            this.lookUpButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.lookUpButton.Location = new System.Drawing.Point(0, 0);
            this.lookUpButton.Name = "lookUpButton";
            this.lookUpButton.PressedImage = null;
            this.lookUpButton.Size = new System.Drawing.Size(22, 22);
            this.lookUpButton.TabIndex = 0;
            this.lookUpButton.Click += new System.EventHandler(this._lookUpButton_Click);
            // 
            // LookUpBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this._inputPanel);
            this.Controls.Add(this._buttonPanel);
            this.Name = "LookUpBox";
            this.Size = new System.Drawing.Size(198, 22);
            this._inputPanel.ResumeLayout(false);
            this._buttonPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel _inputPanel;
        private System.Windows.Forms.Panel _buttonPanel;
        private PictureButton lookUpButton;
        private System.Windows.Forms.Label _valueLabel;
        private PictureButton resetButton;
    }
}
