namespace MSS.WinMobile.UI.Views.LookUps {
    partial class CategoryLookUpView {
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this._categoriesTreeView = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // _categoriesTreeView
            // 
            this._categoriesTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this._categoriesTreeView.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular);
            this._categoriesTreeView.Location = new System.Drawing.Point(0, 0);
            this._categoriesTreeView.Name = "_categoriesTreeView";
            this._categoriesTreeView.Size = new System.Drawing.Size(240, 268);
            this._categoriesTreeView.TabIndex = 0;
            // 
            // CategoryLookUpView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this._categoriesTreeView);
            this.Name = "CategoryLookUpView";
            this.Text = "Categories";
            this.Load += new System.EventHandler(this.CategoryLookUpViewLoad);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView _categoriesTreeView;

    }
}