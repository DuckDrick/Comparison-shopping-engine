namespace Comparison_shopping_engine.Forms
{
    partial class SearchForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SearchForm));
            this.titleBar = new System.Windows.Forms.Panel();
            this.buttonBack = new System.Windows.Forms.Button();
            this.appName = new System.Windows.Forms.Label();
            this.productListView = new System.Windows.Forms.ListView();
            this.productName = new System.Windows.Forms.ColumnHeader();
            this.productPrice = new System.Windows.Forms.ColumnHeader();
            this.productSource = new System.Windows.Forms.ColumnHeader();
            this.filterPanel = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.scrapingInfo = new System.Windows.Forms.Button();
            this.scrapingSettings = new System.Windows.Forms.Button();
            this.startScraping = new System.Windows.Forms.Button();
            this.filter = new System.Windows.Forms.Button();
            this.sourcePanel = new System.Windows.Forms.Panel();
            this.sources = new System.Windows.Forms.CheckedListBox();
            this.source = new System.Windows.Forms.Button();
            this.groupPanel = new System.Windows.Forms.Panel();
            this.groups = new System.Windows.Forms.CheckedListBox();
            this.@group = new System.Windows.Forms.Button();
            this.pricePanel = new System.Windows.Forms.Panel();
            this.toLabel = new System.Windows.Forms.Label();
            this.to = new System.Windows.Forms.TextBox();
            this.@from = new System.Windows.Forms.TextBox();
            this.fromLabel = new System.Windows.Forms.Label();
            this.price = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.searchKeywords = new System.Windows.Forms.Label();
            this.scrapingPictureBox = new System.Windows.Forms.PictureBox();
            this.titleBar.SuspendLayout();
            this.filterPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.sourcePanel.SuspendLayout();
            this.groupPanel.SuspendLayout();
            this.pricePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.scrapingPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // titleBar
            // 
            this.titleBar.BackColor = System.Drawing.Color.FromArgb(((int) (((byte) (117)))), ((int) (((byte) (79)))), ((int) (((byte) (91)))));
            this.titleBar.Controls.Add(this.buttonBack);
            this.titleBar.Controls.Add(this.appName);
            this.titleBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.titleBar.ForeColor = System.Drawing.Color.FromArgb(((int) (((byte) (50)))), ((int) (((byte) (14)))), ((int) (((byte) (59)))));
            this.titleBar.Location = new System.Drawing.Point(0, 0);
            this.titleBar.Name = "titleBar";
            this.titleBar.Size = new System.Drawing.Size(800, 52);
            this.titleBar.TabIndex = 5;
            this.titleBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MoveWindow);
            // 
            // buttonBack
            // 
            this.buttonBack.BackgroundImage = ((System.Drawing.Image) (resources.GetObject("buttonBack.BackgroundImage")));
            this.buttonBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonBack.FlatAppearance.BorderSize = 0;
            this.buttonBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBack.Location = new System.Drawing.Point(5, 4);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(70, 43);
            this.buttonBack.TabIndex = 1;
            this.buttonBack.UseVisualStyleBackColor = true;
            this.buttonBack.Click += new System.EventHandler(this.ButtonBack_Click);
            // 
            // appName
            // 
            this.appName.Dock = System.Windows.Forms.DockStyle.Right;
            this.appName.Font = new System.Drawing.Font("Courier New", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.appName.Location = new System.Drawing.Point(501, 0);
            this.appName.Name = "appName";
            this.appName.Size = new System.Drawing.Size(299, 52);
            this.appName.TabIndex = 0;
            this.appName.Text = "CheapShop";
            this.appName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.appName.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MoveWindow);
            // 
            // productListView
            // 
            this.productListView.Anchor = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Right)));
            this.productListView.BackColor = System.Drawing.SystemColors.Window;
            this.productListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {this.productName, this.productPrice, this.productSource});
            this.productListView.HideSelection = false;
            this.productListView.Location = new System.Drawing.Point(223, 58);
            this.productListView.MultiSelect = false;
            this.productListView.Name = "productListView";
            this.productListView.Size = new System.Drawing.Size(570, 354);
            this.productListView.TabIndex = 6;
            this.productListView.UseCompatibleStateImageBehavior = false;
            this.productListView.View = System.Windows.Forms.View.Details;
            this.productListView.DoubleClick += new System.EventHandler(this.ShowMoreInfoAboutProduct);
            // 
            // productName
            // 
            this.productName.Text = "Name";
            this.productName.Width = 421;
            // 
            // productPrice
            // 
            this.productPrice.Text = "Price";
            this.productPrice.Width = 79;
            // 
            // productSource
            // 
            this.productSource.Text = "Source";
            this.productSource.Width = 63;
            // 
            // filterPanel
            // 
            this.filterPanel.Controls.Add(this.panel1);
            this.filterPanel.Controls.Add(this.filter);
            this.filterPanel.Controls.Add(this.sourcePanel);
            this.filterPanel.Controls.Add(this.source);
            this.filterPanel.Controls.Add(this.groupPanel);
            this.filterPanel.Controls.Add(this.@group);
            this.filterPanel.Controls.Add(this.pricePanel);
            this.filterPanel.Controls.Add(this.price);
            this.filterPanel.Location = new System.Drawing.Point(5, 58);
            this.filterPanel.Name = "filterPanel";
            this.filterPanel.Size = new System.Drawing.Size(216, 385);
            this.filterPanel.TabIndex = 7;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.scrapingInfo);
            this.panel1.Controls.Add(this.scrapingSettings);
            this.panel1.Controls.Add(this.startScraping);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 353);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(216, 32);
            this.panel1.TabIndex = 7;
            // 
            // scrapingInfo
            // 
            this.scrapingInfo.Dock = System.Windows.Forms.DockStyle.Right;
            this.scrapingInfo.Font = new System.Drawing.Font("Courier New", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.scrapingInfo.Location = new System.Drawing.Point(191, 0);
            this.scrapingInfo.Name = "scrapingInfo";
            this.scrapingInfo.Size = new System.Drawing.Size(25, 32);
            this.scrapingInfo.TabIndex = 6;
            this.scrapingInfo.Text = "?";
            this.scrapingInfo.UseVisualStyleBackColor = true;
            this.scrapingInfo.Click += new System.EventHandler(this.scrapingInfo_Click);
            // 
            // scrapingSettings
            // 
            this.scrapingSettings.Dock = System.Windows.Forms.DockStyle.Left;
            this.scrapingSettings.Font = new System.Drawing.Font("Courier New", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.scrapingSettings.Location = new System.Drawing.Point(0, 0);
            this.scrapingSettings.Name = "scrapingSettings";
            this.scrapingSettings.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.scrapingSettings.Size = new System.Drawing.Size(31, 32);
            this.scrapingSettings.TabIndex = 5;
            this.scrapingSettings.Text = "⚙";
            this.scrapingSettings.UseVisualStyleBackColor = true;
            this.scrapingSettings.Click += new System.EventHandler(this.scrapingSettings_Click);
            // 
            // startScraping
            // 
            this.startScraping.Dock = System.Windows.Forms.DockStyle.Fill;
            this.startScraping.Location = new System.Drawing.Point(0, 0);
            this.startScraping.Name = "startScraping";
            this.startScraping.Size = new System.Drawing.Size(216, 32);
            this.startScraping.TabIndex = 4;
            this.startScraping.Text = "Scrape";
            this.startScraping.UseVisualStyleBackColor = true;
            this.startScraping.Click += new System.EventHandler(this.StartScraping);
            // 
            // filter
            // 
            this.filter.Dock = System.Windows.Forms.DockStyle.Top;
            this.filter.Location = new System.Drawing.Point(0, 75);
            this.filter.Name = "filter";
            this.filter.Size = new System.Drawing.Size(216, 26);
            this.filter.TabIndex = 6;
            this.filter.Text = "Filtruoti";
            this.filter.UseVisualStyleBackColor = true;
            this.filter.Click += new System.EventHandler(this.Filter_Click);
            // 
            // sourcePanel
            // 
            this.sourcePanel.Controls.Add(this.sources);
            this.sourcePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.sourcePanel.Enabled = false;
            this.sourcePanel.Location = new System.Drawing.Point(0, 75);
            this.sourcePanel.Name = "sourcePanel";
            this.sourcePanel.Size = new System.Drawing.Size(216, 0);
            this.sourcePanel.TabIndex = 5;
            // 
            // sources
            // 
            this.sources.CheckOnClick = true;
            this.sources.Dock = System.Windows.Forms.DockStyle.Top;
            this.sources.FormattingEnabled = true;
            this.sources.Location = new System.Drawing.Point(0, 0);
            this.sources.Name = "sources";
            this.sources.Size = new System.Drawing.Size(216, 94);
            this.sources.TabIndex = 0;
            // 
            // source
            // 
            this.source.Dock = System.Windows.Forms.DockStyle.Top;
            this.source.Location = new System.Drawing.Point(0, 50);
            this.source.Name = "source";
            this.source.Size = new System.Drawing.Size(216, 25);
            this.source.TabIndex = 4;
            this.source.Text = "Šaltinis";
            this.source.UseVisualStyleBackColor = true;
            this.source.Click += new System.EventHandler(this.ToggleSourcePanel);
            // 
            // groupPanel
            // 
            this.groupPanel.Controls.Add(this.groups);
            this.groupPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupPanel.Location = new System.Drawing.Point(0, 50);
            this.groupPanel.Name = "groupPanel";
            this.groupPanel.Size = new System.Drawing.Size(216, 0);
            this.groupPanel.TabIndex = 3;
            // 
            // groups
            // 
            this.groups.CheckOnClick = true;
            this.groups.Dock = System.Windows.Forms.DockStyle.Top;
            this.groups.FormattingEnabled = true;
            this.groups.Location = new System.Drawing.Point(0, 0);
            this.groups.Name = "groups";
            this.groups.Size = new System.Drawing.Size(216, 94);
            this.groups.TabIndex = 0;
            // 
            // group
            // 
            this.@group.Dock = System.Windows.Forms.DockStyle.Top;
            this.@group.Location = new System.Drawing.Point(0, 25);
            this.@group.Name = "group";
            this.@group.Size = new System.Drawing.Size(216, 25);
            this.@group.TabIndex = 2;
            this.@group.Text = "Grupė";
            this.@group.UseVisualStyleBackColor = true;
            this.@group.Click += new System.EventHandler(this.ToggleGroupPanel);
            // 
            // pricePanel
            // 
            this.pricePanel.Controls.Add(this.toLabel);
            this.pricePanel.Controls.Add(this.to);
            this.pricePanel.Controls.Add(this.@from);
            this.pricePanel.Controls.Add(this.fromLabel);
            this.pricePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.pricePanel.Enabled = false;
            this.pricePanel.Location = new System.Drawing.Point(0, 25);
            this.pricePanel.Name = "pricePanel";
            this.pricePanel.Size = new System.Drawing.Size(216, 0);
            this.pricePanel.TabIndex = 1;
            // 
            // toLabel
            // 
            this.toLabel.AutoSize = true;
            this.toLabel.Location = new System.Drawing.Point(106, 3);
            this.toLabel.Name = "toLabel";
            this.toLabel.Size = new System.Drawing.Size(28, 14);
            this.toLabel.TabIndex = 3;
            this.toLabel.Text = "Iki";
            // 
            // to
            // 
            this.to.Location = new System.Drawing.Point(110, 20);
            this.to.MaxLength = 13;
            this.to.Name = "to";
            this.to.ShortcutsEnabled = false;
            this.to.Size = new System.Drawing.Size(102, 20);
            this.to.TabIndex = 2;
            this.to.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.From_KeyPress);
            // 
            // from
            // 
            this.@from.Location = new System.Drawing.Point(3, 20);
            this.@from.MaxLength = 13;
            this.@from.Name = "from";
            this.@from.ShortcutsEnabled = false;
            this.@from.Size = new System.Drawing.Size(98, 20);
            this.@from.TabIndex = 1;
            this.@from.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.From_KeyPress);
            // 
            // fromLabel
            // 
            this.fromLabel.AutoSize = true;
            this.fromLabel.Location = new System.Drawing.Point(3, 3);
            this.fromLabel.Name = "fromLabel";
            this.fromLabel.Size = new System.Drawing.Size(28, 14);
            this.fromLabel.TabIndex = 0;
            this.fromLabel.Text = "Nuo";
            // 
            // price
            // 
            this.price.Dock = System.Windows.Forms.DockStyle.Top;
            this.price.Location = new System.Drawing.Point(0, 0);
            this.price.Name = "price";
            this.price.Size = new System.Drawing.Size(216, 25);
            this.price.TabIndex = 0;
            this.price.Text = "Kaina";
            this.price.UseVisualStyleBackColor = true;
            this.price.Click += new System.EventHandler(this.TogglePricePanel);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(245, 421);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 14);
            this.label1.TabIndex = 8;
            this.label1.Text = "Ieškoma: ";
            // 
            // searchKeywords
            // 
            this.searchKeywords.AutoSize = true;
            this.searchKeywords.Location = new System.Drawing.Point(304, 421);
            this.searchKeywords.Name = "searchKeywords";
            this.searchKeywords.Size = new System.Drawing.Size(49, 14);
            this.searchKeywords.TabIndex = 9;
            this.searchKeywords.Text = "label2";
            // 
            // scrapingPictureBox
            // 
            this.scrapingPictureBox.Location = new System.Drawing.Point(223, 420);
            this.scrapingPictureBox.Name = "scrapingPictureBox";
            this.scrapingPictureBox.Size = new System.Drawing.Size(16, 15);
            this.scrapingPictureBox.TabIndex = 7;
            this.scrapingPictureBox.TabStop = false;
            // 
            // SearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int) (((byte) (201)))), ((int) (((byte) (173)))), ((int) (((byte) (161)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.scrapingPictureBox);
            this.Controls.Add(this.searchKeywords);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.filterPanel);
            this.Controls.Add(this.productListView);
            this.Controls.Add(this.titleBar);
            this.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Bold);
            this.ForeColor = System.Drawing.Color.FromArgb(((int) (((byte) (77)))), ((int) (((byte) (106)))), ((int) (((byte) (109)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SearchForm";
            this.Text = "SearchForm";
            this.Load += new System.EventHandler(this.SearchForm_Load);
            this.titleBar.ResumeLayout(false);
            this.filterPanel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.sourcePanel.ResumeLayout(false);
            this.groupPanel.ResumeLayout(false);
            this.pricePanel.ResumeLayout(false);
            this.pricePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize) (this.scrapingPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel titleBar;
        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.Label appName;
        private System.Windows.Forms.ListView productListView;
        private System.Windows.Forms.ColumnHeader productName;
        private System.Windows.Forms.ColumnHeader productPrice;
        private System.Windows.Forms.ColumnHeader productSource;
        private System.Windows.Forms.Panel filterPanel;
        private System.Windows.Forms.Button group;
        private System.Windows.Forms.Panel pricePanel;
        private System.Windows.Forms.Label fromLabel;
        private System.Windows.Forms.Button price;
        private System.Windows.Forms.Panel sourcePanel;
        private System.Windows.Forms.CheckedListBox sources;
        private System.Windows.Forms.Button source;
        private System.Windows.Forms.Panel groupPanel;
        private System.Windows.Forms.CheckedListBox groups;
        private System.Windows.Forms.Label toLabel;
        private System.Windows.Forms.TextBox to;
        private System.Windows.Forms.TextBox from;
        private System.Windows.Forms.Button filter;
        private System.Windows.Forms.Button startScraping;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button scrapingInfo;
        private System.Windows.Forms.Button scrapingSettings;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label searchKeywords;
        private System.Windows.Forms.PictureBox scrapingPictureBox;
    }
}