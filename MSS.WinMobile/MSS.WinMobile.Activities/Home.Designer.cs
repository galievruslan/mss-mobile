namespace MSS.WinMobile.Activities
{
    partial class Home
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
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem();
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home));
            this._lwHome = new System.Windows.Forms.ListView();
            this._ilHome = new System.Windows.Forms.ImageList();
            this.SuspendLayout();
            // 
            // _lwHome
            // 
            this._lwHome.Dock = System.Windows.Forms.DockStyle.Fill;
            listViewItem1.ImageIndex = 0;
            listViewItem1.Text = "Route";
            listViewItem2.ImageIndex = 1;
            listViewItem2.Text = "Customers";
            this._lwHome.Items.Add(listViewItem1);
            this._lwHome.Items.Add(listViewItem2);
            this._lwHome.LargeImageList = this._ilHome;
            this._lwHome.Location = new System.Drawing.Point(0, 0);
            this._lwHome.Name = "_lwHome";
            this._lwHome.Size = new System.Drawing.Size(219, 253);
            this._lwHome.TabIndex = 0;
            this._lwHome.ItemActivate += new System.EventHandler(this._lwHome_ItemActivate);
            // 
            // _ilHome
            // 
            this._ilHome.ImageSize = new System.Drawing.Size(64, 64);
            this._ilHome.Images.Clear();
            this._ilHome.Images.Add(((System.Drawing.Image)(resources.GetObject("resource"))));
            this._ilHome.Images.Add(((System.Drawing.Image)(resources.GetObject("resource1"))));
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this._lwHome);
            this.Name = "Home";
            this.Size = new System.Drawing.Size(219, 253);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView _lwHome;
        private System.Windows.Forms.ImageList _ilHome;

    }
}
