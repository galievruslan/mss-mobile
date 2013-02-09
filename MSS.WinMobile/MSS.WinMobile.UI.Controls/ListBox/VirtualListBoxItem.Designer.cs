namespace MSS.WinMobile.UI.Controls.ListBox
{
    partial class VirtualListBoxItem<T>
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
            this._textLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // _textLabel
            // 
            this._textLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._textLabel.Location = new System.Drawing.Point(0, 0);
            this._textLabel.Name = "_textLabel";
            this._textLabel.Size = new System.Drawing.Size(150, 24);
            this._textLabel.Text = "text";
            // 
            // VirtualListBoxItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this._textLabel);
            this.Name = "VirtualListBoxItem";
            this.Size = new System.Drawing.Size(150, 24);
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.Label _textLabel;

    }
}
