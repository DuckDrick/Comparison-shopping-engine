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
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker3 = new System.ComponentModel.BackgroundWorker();
            this.button1 = new System.Windows.Forms.Button();
            this.productCategory = new System.Windows.Forms.Panel();
            this.buttonProductsforkids = new System.Windows.Forms.Button();
            this.buttonBuitinesprekes = new System.Windows.Forms.Button();
            this.buttonComputers = new System.Windows.Forms.Button();
            this.buttonTelecomunication = new System.Windows.Forms.Button();
            this.buttonGaming = new System.Windows.Forms.Button();
            this.labelFilter = new System.Windows.Forms.Label();
            this.buttonExit = new System.Windows.Forms.Button();
            this.backgroundWorker4 = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.productPicture)).BeginInit();
            this.productCategory.SuspendLayout();
            this.SuspendLayout();
            // 
            // search
            // 
            this.search.Location = new System.Drawing.Point(60, 47);
            this.search.Name = "search";
            this.search.Size = new System.Drawing.Size(464, 22);
            this.search.TabIndex = 0;
            // 
            // scrape
            // 
            this.scrape.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scrape.Location = new System.Drawing.Point(588, 47);
            this.scrape.Name = "scrape";
            this.scrape.Size = new System.Drawing.Size(139, 23);
            this.scrape.TabIndex = 1;
            this.scrape.Text = "Search";
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
            this.productListView.Size = new System.Drawing.Size(667, 506);
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
            this.productN.Size = new System.Drawing.Size(298, 17);
            this.productN.TabIndex = 4;
            this.productN.Text = "Paspauskite ant prekės norėdami sužnoti daugiau";
            // 
            // productGroup
            // 
            this.productGroup.AutoSize = true;
            this.productGroup.Location = new System.Drawing.Point(789, 284);
            this.productGroup.Name = "productGroup";
            this.productGroup.Size = new System.Drawing.Size(0, 17);
            this.productGroup.TabIndex = 5;
            // 
            // productLink
            // 
            this.productLink.AutoSize = true;
            this.productLink.Location = new System.Drawing.Point(789, 310);
            this.productLink.Name = "productLink";
            this.productLink.Size = new System.Drawing.Size(0, 17);
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
            // backgroundWorker2
            // 
            this.backgroundWorker2.WorkerReportsProgress = true;
            this.backgroundWorker2.WorkerSupportsCancellation = true;
            this.backgroundWorker2.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker2_DoWork);
            this.backgroundWorker2.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker2_ProgressChanged);
            this.backgroundWorker2.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker2_RunWorkerCompleted);
            // 
            // backgroundWorker3
            // 
            this.backgroundWorker3.WorkerReportsProgress = true;
            this.backgroundWorker3.WorkerSupportsCancellation = true;
            this.backgroundWorker3.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker3_DoWork);
            this.backgroundWorker3.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker3_ProgressChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(732, 43);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(103, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "StopScraping";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // productCategory
            // 
            this.productCategory.Controls.Add(this.buttonProductsforkids);
            this.productCategory.Controls.Add(this.buttonBuitinesprekes);
            this.productCategory.Controls.Add(this.buttonComputers);
            this.productCategory.Controls.Add(this.buttonTelecomunication);
            this.productCategory.Controls.Add(this.buttonGaming);
            this.productCategory.Location = new System.Drawing.Point(1110, 100);
            this.productCategory.Name = "productCategory";
            this.productCategory.Size = new System.Drawing.Size(200, 496);
            this.productCategory.TabIndex = 7;
            // 
            // buttonProductsforkids
            // 
            this.buttonProductsforkids.BackColor = System.Drawing.Color.MediumOrchid;
            this.buttonProductsforkids.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonProductsforkids.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonProductsforkids.ForeColor = System.Drawing.Color.White;
            this.buttonProductsforkids.Location = new System.Drawing.Point(0, 400);
            this.buttonProductsforkids.Name = "buttonProductsforkids";
            this.buttonProductsforkids.Size = new System.Drawing.Size(200, 100);
            this.buttonProductsforkids.TabIndex = 4;
            this.buttonProductsforkids.Text = "Vaikų prekės";
            this.buttonProductsforkids.UseVisualStyleBackColor = false;
            // 
            // buttonBuitinesprekes
            // 
            this.buttonBuitinesprekes.BackColor = System.Drawing.Color.MediumOrchid;
            this.buttonBuitinesprekes.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonBuitinesprekes.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonBuitinesprekes.ForeColor = System.Drawing.Color.White;
            this.buttonBuitinesprekes.Location = new System.Drawing.Point(0, 300);
            this.buttonBuitinesprekes.Name = "buttonBuitinesprekes";
            this.buttonBuitinesprekes.Size = new System.Drawing.Size(200, 100);
            this.buttonBuitinesprekes.TabIndex = 3;
            this.buttonBuitinesprekes.Text = "Buitinės prekės";
            this.buttonBuitinesprekes.UseVisualStyleBackColor = false;
            // 
            // buttonComputers
            // 
            this.buttonComputers.BackColor = System.Drawing.Color.MediumOrchid;
            this.buttonComputers.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonComputers.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonComputers.ForeColor = System.Drawing.Color.White;
            this.buttonComputers.Image = ((System.Drawing.Image)(resources.GetObject("buttonComputers.Image")));
            this.buttonComputers.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.buttonComputers.Location = new System.Drawing.Point(0, 200);
            this.buttonComputers.Name = "buttonComputers";
            this.buttonComputers.Size = new System.Drawing.Size(200, 100);
            this.buttonComputers.TabIndex = 2;
            this.buttonComputers.Text = "Kompiuterinė ir\r\ntinklo įranga";
            this.buttonComputers.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.buttonComputers.UseVisualStyleBackColor = false;
            this.buttonComputers.Click += new System.EventHandler(this.buttonComputers_Click);
            // 
            // buttonTelecomunication
            // 
            this.buttonTelecomunication.BackColor = System.Drawing.Color.MediumOrchid;
            this.buttonTelecomunication.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonTelecomunication.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonTelecomunication.ForeColor = System.Drawing.Color.White;
            this.buttonTelecomunication.Image = ((System.Drawing.Image)(resources.GetObject("buttonTelecomunication.Image")));
            this.buttonTelecomunication.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.buttonTelecomunication.Location = new System.Drawing.Point(0, 100);
            this.buttonTelecomunication.Name = "buttonTelecomunication";
            this.buttonTelecomunication.Size = new System.Drawing.Size(200, 100);
            this.buttonTelecomunication.TabIndex = 1;
            this.buttonTelecomunication.Text = "Telefonai ir priedai\r\nLaisvų rankų \r\nįranga\r\n";
            this.buttonTelecomunication.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.buttonTelecomunication.UseVisualStyleBackColor = false;
            this.buttonTelecomunication.Click += new System.EventHandler(this.buttonTelecomunication_Click);
            // 
            // buttonGaming
            // 
            this.buttonGaming.BackColor = System.Drawing.Color.MediumOrchid;
            this.buttonGaming.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonGaming.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonGaming.ForeColor = System.Drawing.SystemColors.Control;
            this.buttonGaming.Image = ((System.Drawing.Image)(resources.GetObject("buttonGaming.Image")));
            this.buttonGaming.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.buttonGaming.Location = new System.Drawing.Point(0, 0);
            this.buttonGaming.Name = "buttonGaming";
            this.buttonGaming.Size = new System.Drawing.Size(200, 100);
            this.buttonGaming.TabIndex = 0;
            this.buttonGaming.Text = "Žaidimai ir žaidimų įranga";
            this.buttonGaming.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.buttonGaming.UseVisualStyleBackColor = false;
            this.buttonGaming.Click += new System.EventHandler(this.buttonGaming_Click);
            // 
            // labelFilter
            // 
            this.labelFilter.AutoSize = true;
            this.labelFilter.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFilter.Location = new System.Drawing.Point(1131, 78);
            this.labelFilter.Name = "labelFilter";
            this.labelFilter.Size = new System.Drawing.Size(157, 19);
            this.labelFilter.TabIndex = 3;
            this.labelFilter.Text = "Ieškoti katergorijoje";
            this.labelFilter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonExit
            // 
            this.buttonExit.BackColor = System.Drawing.Color.Thistle;
            this.buttonExit.Image = ((System.Drawing.Image)(resources.GetObject("buttonExit.Image")));
            this.buttonExit.Location = new System.Drawing.Point(1265, 13);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(44, 40);
            this.buttonExit.TabIndex = 8;
            this.buttonExit.UseVisualStyleBackColor = false;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // backgroundWorker4
            // 
            this.backgroundWorker4.WorkerReportsProgress = true;
            this.backgroundWorker4.WorkerSupportsCancellation = true;
            this.backgroundWorker4.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker4_DoWork);
            this.backgroundWorker4.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker4_ProgressChanged);
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Thistle;
            this.ClientSize = new System.Drawing.Size(1350, 625);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.labelFilter);
            this.Controls.Add(this.productCategory);
            this.Controls.Add(this.productLink);
            this.Controls.Add(this.productGroup);
            this.Controls.Add(this.productN);
            this.Controls.Add(this.productPicture);
            this.Controls.Add(this.productListView);
            this.Controls.Add(this.scrape);
            this.Controls.Add(this.search);
            this.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "pre-release0.0000.00.01";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.productPicture)).EndInit();
            this.productCategory.ResumeLayout(false);
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
        private System.ComponentModel.BackgroundWorker backgroundWorker2;

        private System.Windows.Forms.Button button1;

        private System.Windows.Forms.Panel productCategory;
        private System.Windows.Forms.Button buttonGaming;
        private System.Windows.Forms.Button buttonTelecomunication;
        private System.Windows.Forms.Button buttonComputers;
        private System.Windows.Forms.Button buttonProductsforkids;
        private System.Windows.Forms.Button buttonBuitinesprekes;
        private System.Windows.Forms.Label labelFilter;
        private System.Windows.Forms.Button buttonExit;
        private System.ComponentModel.BackgroundWorker backgroundWorker3;
        private System.ComponentModel.BackgroundWorker backgroundWorker4;
    }
}

