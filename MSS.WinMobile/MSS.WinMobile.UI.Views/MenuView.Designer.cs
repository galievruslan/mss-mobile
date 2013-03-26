namespace MSS.WinMobile.UI.Views
{
    partial class MenuView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuView));
            this._routeIcon = new System.Windows.Forms.PictureBox();
            this._routeLabel = new System.Windows.Forms.LinkLabel();
            this._synchronizationIcon = new System.Windows.Forms.PictureBox();
            this._synchronizationLabel = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // _routeIcon
            // 
            this._routeIcon.Image = ((System.Drawing.Image)(resources.GetObject("_routeIcon.Image")));
            this._routeIcon.Location = new System.Drawing.Point(3, 3);
            this._routeIcon.Name = "_routeIcon";
            this._routeIcon.Size = new System.Drawing.Size(30, 30);
            this._routeIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            // 
            // _routeLabel
            // 
            this._routeLabel.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Underline);
            this._routeLabel.ForeColor = System.Drawing.Color.Black;
            this._routeLabel.Location = new System.Drawing.Point(39, 9);
            this._routeLabel.Name = "_routeLabel";
            this._routeLabel.Size = new System.Drawing.Size(201, 20);
            this._routeLabel.TabIndex = 1;
            this._routeLabel.Text = "Route";
            this._routeLabel.Click += new System.EventHandler(this._routeLabel_Click);
            // 
            // _synchronizationIcon
            // 
            this._synchronizationIcon.Image = ((System.Drawing.Image)(resources.GetObject("_synchronizationIcon.Image")));
            this._synchronizationIcon.Location = new System.Drawing.Point(3, 38);
            this._synchronizationIcon.Name = "_synchronizationIcon";
            this._synchronizationIcon.Size = new System.Drawing.Size(30, 30);
            this._synchronizationIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            // 
            // _synchronizationLabel
            // 
            this._synchronizationLabel.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Underline);
            this._synchronizationLabel.ForeColor = System.Drawing.Color.Black;
            this._synchronizationLabel.Location = new System.Drawing.Point(39, 44);
            this._synchronizationLabel.Name = "_synchronizationLabel";
            this._synchronizationLabel.Size = new System.Drawing.Size(201, 20);
            this._synchronizationLabel.TabIndex = 7;
            this._synchronizationLabel.Text = "Synchronization";
            this._synchronizationLabel.Click += new System.EventHandler(this._synchronizationLabel_Click);
            // 
            // MenuView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 294);
            this.Controls.Add(this._synchronizationLabel);
            this.Controls.Add(this._synchronizationIcon);
            this.Controls.Add(this._routeLabel);
            this.Controls.Add(this._routeIcon);
            this.Name = "MenuView";
            this.Load += new System.EventHandler(this.MenuView_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox _routeIcon;
        private System.Windows.Forms.LinkLabel _routeLabel;
        private System.Windows.Forms.PictureBox _synchronizationIcon;
        private System.Windows.Forms.LinkLabel _synchronizationLabel;



    }
}