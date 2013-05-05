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
            this._newOrderLabel = new System.Windows.Forms.LinkLabel();
            this.newOrderIcon = new System.Windows.Forms.PictureBox();
            this._settingsLabel = new System.Windows.Forms.LinkLabel();
            this._settingsIcon = new System.Windows.Forms.PictureBox();
            this._logoutLabel = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // _routeIcon
            // 
            this._routeIcon.BackColor = System.Drawing.Color.White;
            this._routeIcon.Image = ((System.Drawing.Image)(resources.GetObject("_routeIcon.Image")));
            this._routeIcon.Location = new System.Drawing.Point(3, 3);
            this._routeIcon.Name = "_routeIcon";
            this._routeIcon.Size = new System.Drawing.Size(30, 30);
            this._routeIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            // 
            // _routeLabel
            // 
            this._routeLabel.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular);
            this._routeLabel.ForeColor = System.Drawing.Color.Black;
            this._routeLabel.Location = new System.Drawing.Point(39, 9);
            this._routeLabel.Name = "_routeLabel";
            this._routeLabel.Size = new System.Drawing.Size(201, 20);
            this._routeLabel.TabIndex = 1;
            this._routeLabel.Text = "Route";
            this._routeLabel.Click += new System.EventHandler(this.RouteClick);
            // 
            // _synchronizationIcon
            // 
            this._synchronizationIcon.BackColor = System.Drawing.Color.White;
            this._synchronizationIcon.Image = ((System.Drawing.Image)(resources.GetObject("_synchronizationIcon.Image")));
            this._synchronizationIcon.Location = new System.Drawing.Point(3, 75);
            this._synchronizationIcon.Name = "_synchronizationIcon";
            this._synchronizationIcon.Size = new System.Drawing.Size(30, 30);
            this._synchronizationIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            // 
            // _synchronizationLabel
            // 
            this._synchronizationLabel.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular);
            this._synchronizationLabel.ForeColor = System.Drawing.Color.Black;
            this._synchronizationLabel.Location = new System.Drawing.Point(39, 81);
            this._synchronizationLabel.Name = "_synchronizationLabel";
            this._synchronizationLabel.Size = new System.Drawing.Size(201, 20);
            this._synchronizationLabel.TabIndex = 7;
            this._synchronizationLabel.Text = "Synchronization";
            this._synchronizationLabel.Click += new System.EventHandler(this.SynchronizationLabelClick);
            // 
            // _newOrderLabel
            // 
            this._newOrderLabel.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular);
            this._newOrderLabel.ForeColor = System.Drawing.Color.Black;
            this._newOrderLabel.Location = new System.Drawing.Point(39, 45);
            this._newOrderLabel.Name = "_newOrderLabel";
            this._newOrderLabel.Size = new System.Drawing.Size(201, 20);
            this._newOrderLabel.TabIndex = 10;
            this._newOrderLabel.Text = "Add Order";
            // 
            // newOrderIcon
            // 
            this.newOrderIcon.BackColor = System.Drawing.Color.White;
            this.newOrderIcon.Image = ((System.Drawing.Image)(resources.GetObject("newOrderIcon.Image")));
            this.newOrderIcon.Location = new System.Drawing.Point(3, 39);
            this.newOrderIcon.Name = "newOrderIcon";
            this.newOrderIcon.Size = new System.Drawing.Size(30, 30);
            this.newOrderIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            // 
            // _settingsLabel
            // 
            this._settingsLabel.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular);
            this._settingsLabel.ForeColor = System.Drawing.Color.Black;
            this._settingsLabel.Location = new System.Drawing.Point(39, 117);
            this._settingsLabel.Name = "_settingsLabel";
            this._settingsLabel.Size = new System.Drawing.Size(201, 20);
            this._settingsLabel.TabIndex = 14;
            this._settingsLabel.Text = "Settings";
            // 
            // _settingsIcon
            // 
            this._settingsIcon.BackColor = System.Drawing.Color.White;
            this._settingsIcon.Image = ((System.Drawing.Image)(resources.GetObject("_settingsIcon.Image")));
            this._settingsIcon.Location = new System.Drawing.Point(3, 111);
            this._settingsIcon.Name = "_settingsIcon";
            this._settingsIcon.Size = new System.Drawing.Size(30, 30);
            this._settingsIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            // 
            // _logoutLabel
            // 
            this._logoutLabel.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular);
            this._logoutLabel.ForeColor = System.Drawing.Color.Black;
            this._logoutLabel.Location = new System.Drawing.Point(174, 260);
            this._logoutLabel.Name = "_logoutLabel";
            this._logoutLabel.Size = new System.Drawing.Size(52, 20);
            this._logoutLabel.TabIndex = 16;
            this._logoutLabel.Text = "Logout";
            // 
            // MenuView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 294);
            this.Controls.Add(this._logoutLabel);
            this.Controls.Add(this._settingsLabel);
            this.Controls.Add(this._settingsIcon);
            this.Controls.Add(this.newOrderIcon);
            this.Controls.Add(this._newOrderLabel);
            this.Controls.Add(this._synchronizationLabel);
            this.Controls.Add(this._synchronizationIcon);
            this.Controls.Add(this._routeLabel);
            this.Controls.Add(this._routeIcon);
            this.Name = "MenuView";
            this.Load += new System.EventHandler(this.ViewLoad);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox _routeIcon;
        private System.Windows.Forms.LinkLabel _routeLabel;
        private System.Windows.Forms.PictureBox _synchronizationIcon;
        private System.Windows.Forms.LinkLabel _synchronizationLabel;
        private System.Windows.Forms.LinkLabel _newOrderLabel;
        private System.Windows.Forms.PictureBox newOrderIcon;
        private System.Windows.Forms.LinkLabel _settingsLabel;
        private System.Windows.Forms.PictureBox _settingsIcon;
        private System.Windows.Forms.LinkLabel _logoutLabel;



    }
}