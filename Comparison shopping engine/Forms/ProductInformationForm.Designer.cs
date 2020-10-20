namespace Comparison_shopping_engine.Forms
{
    partial class ProductInformationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductInformationForm));
            this.titleBar = new System.Windows.Forms.Panel();
            this.exitButton = new System.Windows.Forms.Button();
            this.appName = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.productPicture = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.productLink = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.productGroup = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.productPrice = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.productSource = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.productName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.titleBar.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.productPicture)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // titleBar
            // 
            this.titleBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(79)))), ((int)(((byte)(91)))));
            this.titleBar.Controls.Add(this.exitButton);
            this.titleBar.Controls.Add(this.appName);
            this.titleBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.titleBar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(14)))), ((int)(((byte)(59)))));
            this.titleBar.Location = new System.Drawing.Point(0, 0);
            this.titleBar.Name = "titleBar";
            this.titleBar.Size = new System.Drawing.Size(764, 52);
            this.titleBar.TabIndex = 4;
            this.titleBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MoveWindow);
            // 
            // exitButton
            // 
            this.exitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.exitButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("exitButton.BackgroundImage")));
            this.exitButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.exitButton.FlatAppearance.BorderSize = 0;
            this.exitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exitButton.Location = new System.Drawing.Point(708, 4);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(47, 43);
            this.exitButton.TabIndex = 1;
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.CloseWindow);
            // 
            // appName
            // 
            this.appName.Dock = System.Windows.Forms.DockStyle.Left;
            this.appName.Font = new System.Drawing.Font("Courier New", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.appName.Location = new System.Drawing.Point(0, 0);
            this.appName.Name = "appName";
            this.appName.Size = new System.Drawing.Size(299, 52);
            this.appName.TabIndex = 0;
            this.appName.Text = "CheapShop";
            this.appName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.appName.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MoveWindow);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70.69768F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 29.30233F));
            this.tableLayoutPanel1.Controls.Add(this.productPicture, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(6, 62);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 159F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(752, 159);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // productPicture
            // 
            this.productPicture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.productPicture.Location = new System.Drawing.Point(534, 3);
            this.productPicture.Name = "productPicture";
            this.productPicture.Size = new System.Drawing.Size(215, 153);
            this.productPicture.TabIndex = 0;
            this.productPicture.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.productLink);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.productGroup);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.productPrice);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.productSource);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.productName);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(525, 153);
            this.panel1.TabIndex = 1;
            // 
            // productLink
            // 
            this.productLink.AutoSize = true;
            this.productLink.Dock = System.Windows.Forms.DockStyle.Top;
            this.productLink.Location = new System.Drawing.Point(0, 126);
            this.productLink.Name = "productLink";
            this.productLink.Size = new System.Drawing.Size(49, 14);
            this.productLink.TabIndex = 9;
            this.productLink.Text = "label6";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Top;
            this.label7.Location = new System.Drawing.Point(0, 112);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 14);
            this.label7.TabIndex = 8;
            this.label7.Text = "Nuoroda";
            // 
            // productGroup
            // 
            this.productGroup.AutoSize = true;
            this.productGroup.Dock = System.Windows.Forms.DockStyle.Top;
            this.productGroup.Location = new System.Drawing.Point(0, 98);
            this.productGroup.Name = "productGroup";
            this.productGroup.Size = new System.Drawing.Size(49, 14);
            this.productGroup.TabIndex = 7;
            this.productGroup.Text = "label8";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Dock = System.Windows.Forms.DockStyle.Top;
            this.label9.Location = new System.Drawing.Point(0, 84);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(42, 14);
            this.label9.TabIndex = 6;
            this.label9.Text = "Grupė";
            // 
            // productPrice
            // 
            this.productPrice.AutoSize = true;
            this.productPrice.Dock = System.Windows.Forms.DockStyle.Top;
            this.productPrice.Location = new System.Drawing.Point(0, 70);
            this.productPrice.Name = "productPrice";
            this.productPrice.Size = new System.Drawing.Size(56, 14);
            this.productPrice.TabIndex = 5;
            this.productPrice.Text = "label10";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Top;
            this.label5.Location = new System.Drawing.Point(0, 56);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 14);
            this.label5.TabIndex = 4;
            this.label5.Text = "Kaina";
            // 
            // productSource
            // 
            this.productSource.AutoSize = true;
            this.productSource.Dock = System.Windows.Forms.DockStyle.Top;
            this.productSource.Location = new System.Drawing.Point(0, 42);
            this.productSource.Name = "productSource";
            this.productSource.Size = new System.Drawing.Size(49, 14);
            this.productSource.TabIndex = 3;
            this.productSource.Text = "label4";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Location = new System.Drawing.Point(0, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 14);
            this.label3.TabIndex = 2;
            this.label3.Text = "Šaltinis";
            // 
            // productName
            // 
            this.productName.AutoSize = true;
            this.productName.Dock = System.Windows.Forms.DockStyle.Top;
            this.productName.Location = new System.Drawing.Point(0, 14);
            this.productName.Name = "productName";
            this.productName.Size = new System.Drawing.Size(49, 14);
            this.productName.TabIndex = 1;
            this.productName.Text = "label2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "Pavadinimas";
            // 
            // ProductInformationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(173)))), ((int)(((byte)(161)))));
            this.ClientSize = new System.Drawing.Size(764, 233);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.titleBar);
            this.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Bold);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(106)))), ((int)(((byte)(109)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ProductInformationForm";
            this.Text = "ProductInformationForm";
            this.titleBar.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.productPicture)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel titleBar;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Label appName;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.PictureBox productPicture;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label productLink;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label productGroup;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label productPrice;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label productSource;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label productName;
        private System.Windows.Forms.Label label1;
    }
}