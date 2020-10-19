namespace Comparison_shopping_engine.Forms
{
    partial class GroupedForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GroupedForm));
            this.productListView = new System.Windows.Forms.ListView();
            this.productName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.productPrice = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.productSource = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.titleBar = new System.Windows.Forms.Panel();
            this.buttonBack = new System.Windows.Forms.Button();
            this.appName = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.titleBar.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // productListView
            // 
            this.productListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.productName,
            this.productPrice,
            this.productSource});
            this.productListView.HideSelection = false;
            this.productListView.Location = new System.Drawing.Point(12, 150);
            this.productListView.MultiSelect = false;
            this.productListView.Name = "productListView";
            this.productListView.Size = new System.Drawing.Size(776, 288);
            this.productListView.TabIndex = 3;
            this.productListView.UseCompatibleStateImageBehavior = false;
            this.productListView.View = System.Windows.Forms.View.Details;
            // 
            // productName
            // 
            this.productName.Text = "Name";
            this.productName.Width = 631;
            // 
            // productPrice
            // 
            this.productPrice.Text = "Price";
            this.productPrice.Width = 79;
            // 
            // productSource
            // 
            this.productSource.Text = "Source";
            this.productSource.Width = 62;
            // 
            // titleBar
            // 
            this.titleBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(79)))), ((int)(((byte)(91)))));
            this.titleBar.Controls.Add(this.buttonBack);
            this.titleBar.Controls.Add(this.appName);
            this.titleBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.titleBar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(14)))), ((int)(((byte)(59)))));
            this.titleBar.Location = new System.Drawing.Point(0, 0);
            this.titleBar.Name = "titleBar";
            this.titleBar.Size = new System.Drawing.Size(800, 48);
            this.titleBar.TabIndex = 4;
            this.titleBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MoveWindow);
            // 
            // buttonBack
            // 
            this.buttonBack.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonBack.BackgroundImage")));
            this.buttonBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonBack.FlatAppearance.BorderSize = 0;
            this.buttonBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBack.Location = new System.Drawing.Point(4, 4);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(60, 40);
            this.buttonBack.TabIndex = 1;
            this.buttonBack.UseVisualStyleBackColor = true;
            this.buttonBack.Click += new System.EventHandler(this.GoBack);
            // 
            // appName
            // 
            this.appName.Dock = System.Windows.Forms.DockStyle.Right;
            this.appName.Font = new System.Drawing.Font("Courier New", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.appName.Location = new System.Drawing.Point(544, 0);
            this.appName.Name = "appName";
            this.appName.Size = new System.Drawing.Size(256, 48);
            this.appName.TabIndex = 0;
            this.appName.Text = "CheapShop";
            this.appName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.appName.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MoveWindow);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 55);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(776, 89);
            this.panel1.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(776, 89);
            this.label1.TabIndex = 0;
            this.label1.Text = "VIETA GRUPIŲ POGRUPIAMS";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // GroupedForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(173)))), ((int)(((byte)(161)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.titleBar);
            this.Controls.Add(this.productListView);
            this.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(106)))), ((int)(((byte)(109)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "GroupedForm";
            this.Text = "testCategory";
            this.Load += new System.EventHandler(this.GroupedForm_Load);
            this.titleBar.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ListView productListView;
        private System.Windows.Forms.ColumnHeader productName;
        private System.Windows.Forms.ColumnHeader productPrice;
        private System.Windows.Forms.ColumnHeader productSource;
        private System.Windows.Forms.Panel titleBar;
        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.Label appName;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
    }
}