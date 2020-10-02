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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.search = new System.Windows.Forms.TextBox();
            this.scrape = new System.Windows.Forms.Button();
            this.productListView = new System.Windows.Forms.ListView();
            this.productName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.productPrice = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.productSource = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.productPicture = new System.Windows.Forms.PictureBox();
            this.productN = new System.Windows.Forms.Label();
            this.productGroup = new System.Windows.Forms.Label();
            this.productLink = new System.Windows.Forms.LinkLabel();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.productPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // search
            // 
            this.search.Location = new System.Drawing.Point(60, 47);
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
            // productListView
            // 
            this.productListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.productName,
            this.productPrice,
            this.productSource});
            this.productListView.HideSelection = false;
            this.productListView.Location = new System.Drawing.Point(60, 90);
            this.productListView.MultiSelect = false;
            this.productListView.Name = "productListView";
            this.productListView.Size = new System.Drawing.Size(667, 386);
            this.productListView.TabIndex = 2;
            this.productListView.UseCompatibleStateImageBehavior = false;
            this.productListView.View = System.Windows.Forms.View.Details;
            this.productListView.Click += new System.EventHandler(this.productList_ClickOnItem);
            // 
            // productName
            // 
            this.productName.Text = "Name";
            this.productName.Width = 461;
            // 
            // productPrice
            // 
            this.productPrice.Text = "Price";
            this.productPrice.Width = 79;
            // 
            // productSource
            // 
            this.productSource.Text = "Source";
            this.productSource.Width = 121;
            // 
            // productPicture
            // 
            this.productPicture.Location = new System.Drawing.Point(792, 90);
            this.productPicture.Name = "productPicture";
            this.productPicture.Size = new System.Drawing.Size(184, 184);
            this.productPicture.TabIndex = 3;
            this.productPicture.TabStop = false;
            // 
            // productN
            // 
            this.productN.AutoSize = true;
            this.productN.Location = new System.Drawing.Point(789, 297);
            this.productN.Name = "productN";
            this.productN.Size = new System.Drawing.Size(241, 13);
            this.productN.TabIndex = 4;
            this.productN.Text = "Paspauskite ant prekės norėdami sužnoti daugiau";
            // 
            // productGroup
            // 
            this.productGroup.AutoSize = true;
            this.productGroup.Location = new System.Drawing.Point(789, 284);
            this.productGroup.Name = "productGroup";
            this.productGroup.Size = new System.Drawing.Size(0, 13);
            this.productGroup.TabIndex = 5;
            // 
            // productLink
            // 
            this.productLink.AutoSize = true;
            this.productLink.Location = new System.Drawing.Point(789, 310);
            this.productLink.Name = "productLink";
            this.productLink.Size = new System.Drawing.Size(0, 13);
            this.productLink.TabIndex = 6;
            this.productLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1310, 542);
            this.Controls.Add(this.productLink);
            this.Controls.Add(this.productGroup);
            this.Controls.Add(this.productN);
            this.Controls.Add(this.productPicture);
            this.Controls.Add(this.productListView);
            this.Controls.Add(this.scrape);
            this.Controls.Add(this.search);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.productPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox search;
        private System.Windows.Forms.Button scrape;
        private System.Windows.Forms.ListView productListView;
        private System.Windows.Forms.ColumnHeader productSource;
        private System.Windows.Forms.ColumnHeader productName;
        private System.Windows.Forms.ColumnHeader productPrice;
        private System.Windows.Forms.PictureBox productPicture;
        private System.Windows.Forms.Label productN;
        private System.Windows.Forms.Label productGroup;
        private System.Windows.Forms.LinkLabel productLink;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}

