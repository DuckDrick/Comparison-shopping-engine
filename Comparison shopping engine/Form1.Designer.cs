namespace Comparison_shopping_engine
{
    partial class Form1
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
            this.search = new System.Windows.Forms.TextBox();
            this.scrape = new System.Windows.Forms.Button();
            this.productList = new System.Windows.Forms.ListView();
            this.productSource = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.productName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.productPrice = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // search
            // 
            this.search.Location = new System.Drawing.Point(106, 46);
            this.search.Name = "search";
            this.search.Size = new System.Drawing.Size(294, 20);
            this.search.TabIndex = 0;
            // 
            // scrape
            // 
            this.scrape.Location = new System.Drawing.Point(406, 46);
            this.scrape.Name = "scrape";
            this.scrape.Size = new System.Drawing.Size(294, 20);
            this.scrape.TabIndex = 1;
            this.scrape.Text = "Scrape";
            this.scrape.UseVisualStyleBackColor = true;
            this.scrape.Click += new System.EventHandler(this.Scrape);
            // 
            // productList
            // 
            this.productList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.productSource,
            this.productName,
            this.productPrice});
            this.productList.HideSelection = false;
            this.productList.Location = new System.Drawing.Point(106, 91);
            this.productList.Name = "productList";
            this.productList.Size = new System.Drawing.Size(594, 385);
            this.productList.TabIndex = 2;
            this.productList.UseCompatibleStateImageBehavior = false;
            this.productList.View = System.Windows.Forms.View.Details;
            // 
            // productSource
            // 
            this.productSource.Text = "Source";
            this.productSource.Width = 66;
            // 
            // productName
            // 
            this.productName.Text = "Name";
            this.productName.Width = 461;
            // 
            // productPrice
            // 
            this.productPrice.Text = "Price";
            this.productPrice.Width = 55;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(848, 488);
            this.Controls.Add(this.productList);
            this.Controls.Add(this.scrape);
            this.Controls.Add(this.search);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox search;
        private System.Windows.Forms.Button scrape;
        private System.Windows.Forms.ListView productList;
        private System.Windows.Forms.ColumnHeader productSource;
        private System.Windows.Forms.ColumnHeader productName;
        private System.Windows.Forms.ColumnHeader productPrice;
    }
}

