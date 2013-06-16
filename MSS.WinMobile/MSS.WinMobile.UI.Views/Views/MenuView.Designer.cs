namespace MSS.WinMobile.UI.Views.Views {
    partial class MenuView {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuView));
            this._settingsLabel = new System.Windows.Forms.LinkLabel();
            this._settingsIcon = new System.Windows.Forms.PictureBox();
            this._synchronizationLabel = new System.Windows.Forms.LinkLabel();
            this._synchronizationIcon = new System.Windows.Forms.PictureBox();
            this._routesLabel = new System.Windows.Forms.LinkLabel();
            this._routeIcon = new System.Windows.Forms.PictureBox();
            this._ordersLabel = new System.Windows.Forms.LinkLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this._updatesLabel = new System.Windows.Forms.LinkLabel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.SuspendLayout();
            // 
            // _settingsLabel
            // 
            this._settingsLabel.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular);
            this._settingsLabel.ForeColor = System.Drawing.Color.Black;
            this._settingsLabel.Location = new System.Drawing.Point(39, 116);
            this._settingsLabel.Name = "_settingsLabel";
            this._settingsLabel.Size = new System.Drawing.Size(161, 20);
            this._settingsLabel.TabIndex = 20;
            this._settingsLabel.TabStop = false;
            this._settingsLabel.Text = "Settings";
            this._settingsLabel.Click += new System.EventHandler(this.SettingsLabelClick);
            // 
            // _settingsIcon
            // 
            this._settingsIcon.BackColor = System.Drawing.Color.White;
            this._settingsIcon.Image = ((System.Drawing.Image)(resources.GetObject("_settingsIcon.Image")));
            this._settingsIcon.Location = new System.Drawing.Point(3, 110);
            this._settingsIcon.Name = "_settingsIcon";
            this._settingsIcon.Size = new System.Drawing.Size(30, 30);
            this._settingsIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            // 
            // _synchronizationLabel
            // 
            this._synchronizationLabel.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular);
            this._synchronizationLabel.ForeColor = System.Drawing.Color.Black;
            this._synchronizationLabel.Location = new System.Drawing.Point(39, 80);
            this._synchronizationLabel.Name = "_synchronizationLabel";
            this._synchronizationLabel.Size = new System.Drawing.Size(161, 20);
            this._synchronizationLabel.TabIndex = 19;
            this._synchronizationLabel.TabStop = false;
            this._synchronizationLabel.Text = "Synchronization";
            this._synchronizationLabel.Click += new System.EventHandler(this.SynchronizationLabelClick);
            // 
            // _synchronizationIcon
            // 
            this._synchronizationIcon.BackColor = System.Drawing.Color.White;
            this._synchronizationIcon.Image = ((System.Drawing.Image)(resources.GetObject("_synchronizationIcon.Image")));
            this._synchronizationIcon.Location = new System.Drawing.Point(3, 74);
            this._synchronizationIcon.Name = "_synchronizationIcon";
            this._synchronizationIcon.Size = new System.Drawing.Size(30, 30);
            this._synchronizationIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            // 
            // _routesLabel
            // 
            this._routesLabel.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular);
            this._routesLabel.ForeColor = System.Drawing.Color.Black;
            this._routesLabel.Location = new System.Drawing.Point(39, 9);
            this._routesLabel.Name = "_routesLabel";
            this._routesLabel.Size = new System.Drawing.Size(161, 20);
            this._routesLabel.TabIndex = 18;
            this._routesLabel.TabStop = false;
            this._routesLabel.Text = "Routes";
            this._routesLabel.Click += new System.EventHandler(this.RouteClick);
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
            // _ordersLabel
            // 
            this._ordersLabel.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular);
            this._ordersLabel.ForeColor = System.Drawing.Color.Black;
            this._ordersLabel.Location = new System.Drawing.Point(39, 44);
            this._ordersLabel.Name = "_ordersLabel";
            this._ordersLabel.Size = new System.Drawing.Size(161, 20);
            this._ordersLabel.TabIndex = 25;
            this._ordersLabel.TabStop = false;
            this._ordersLabel.Text = "Orders";
            this._ordersLabel.Click += new System.EventHandler(this.OrdersLabelClick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(3, 38);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(30, 30);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            // 
            // _updatesLabel
            // 
            this._updatesLabel.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular);
            this._updatesLabel.ForeColor = System.Drawing.Color.Black;
            this._updatesLabel.Location = new System.Drawing.Point(39, 152);
            this._updatesLabel.Name = "_updatesLabel";
            this._updatesLabel.Size = new System.Drawing.Size(161, 20);
            this._updatesLabel.TabIndex = 31;
            this._updatesLabel.TabStop = false;
            this._updatesLabel.Text = "Updates";
            this._updatesLabel.Click += new System.EventHandler(this.UpdatesLabelClick);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.White;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(3, 146);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(30, 30);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            // 
            // MenuView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.Controls.Add(this._updatesLabel);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this._ordersLabel);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this._settingsLabel);
            this.Controls.Add(this._settingsIcon);
            this.Controls.Add(this._synchronizationLabel);
            this.Controls.Add(this._synchronizationIcon);
            this.Controls.Add(this._routesLabel);
            this.Controls.Add(this._routeIcon);
            this.Name = "MenuView";
            this.Load += new MSS.WinMobile.UI.Views.Views.View.OnLoad(this.MenuViewLoad);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.LinkLabel _settingsLabel;
        private System.Windows.Forms.PictureBox _settingsIcon;
        private System.Windows.Forms.LinkLabel _synchronizationLabel;
        private System.Windows.Forms.PictureBox _synchronizationIcon;
        private System.Windows.Forms.LinkLabel _routesLabel;
        private System.Windows.Forms.PictureBox _routeIcon;
        private System.Windows.Forms.LinkLabel _ordersLabel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.LinkLabel _updatesLabel;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}
