using System.Windows.Forms;

namespace Comparison_shopping_engine.Forms
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.mainGroupPanelRight = new System.Windows.Forms.Button();
            this.mainGroupPanelLeft = new System.Windows.Forms.Button();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.mainGroupPanelLabel2 = new System.Windows.Forms.Label();
            this.mainGroupPanelPicture2 = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.mainGroupPanelLabel3 = new System.Windows.Forms.Label();
            this.mainGroupPanelPicture3 = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.mainGroupPanelPicture1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.mainGroupPanelLabel1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.faqButton = new System.Windows.Forms.Button();
            this.aboutButton = new System.Windows.Forms.Button();
            this.titleBar = new System.Windows.Forms.Panel();
            this.exitButton = new System.Windows.Forms.Button();
            this.appName = new System.Windows.Forms.Label();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.searchField = new System.Windows.Forms.TextBox();
            this.searchButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainGroupPanelPicture2)).BeginInit();
            this.tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainGroupPanelPicture3)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainGroupPanelPicture1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.titleBar.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.Controls.Add(this.mainGroupPanelRight, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.mainGroupPanelLeft, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel4, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 177);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 212);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // mainGroupPanelRight
            // 
            this.mainGroupPanelRight.FlatAppearance.BorderSize = 0;
            this.mainGroupPanelRight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.mainGroupPanelRight.Image = ((System.Drawing.Image)(resources.GetObject("mainGroupPanelRight.Image")));
            this.mainGroupPanelRight.Location = new System.Drawing.Point(771, 3);
            this.mainGroupPanelRight.Name = "mainGroupPanelRight";
            this.mainGroupPanelRight.Size = new System.Drawing.Size(26, 172);
            this.mainGroupPanelRight.TabIndex = 4;
            this.mainGroupPanelRight.UseVisualStyleBackColor = true;
            this.mainGroupPanelRight.Click += new System.EventHandler(this.MoveListToRight);
            // 
            // mainGroupPanelLeft
            // 
            this.mainGroupPanelLeft.FlatAppearance.BorderSize = 0;
            this.mainGroupPanelLeft.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.mainGroupPanelLeft.Image = ((System.Drawing.Image)(resources.GetObject("mainGroupPanelLeft.Image")));
            this.mainGroupPanelLeft.Location = new System.Drawing.Point(3, 3);
            this.mainGroupPanelLeft.Name = "mainGroupPanelLeft";
            this.mainGroupPanelLeft.Size = new System.Drawing.Size(24, 172);
            this.mainGroupPanelLeft.TabIndex = 0;
            this.mainGroupPanelLeft.UseVisualStyleBackColor = true;
            this.mainGroupPanelLeft.Click += new System.EventHandler(this.MoveListToLeft);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.mainGroupPanelLabel2, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.mainGroupPanelPicture2, 0, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(279, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 85F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(239, 206);
            this.tableLayoutPanel3.TabIndex = 6;
            // 
            // mainGroupPanelLabel2
            // 
            this.mainGroupPanelLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainGroupPanelLabel2.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainGroupPanelLabel2.Location = new System.Drawing.Point(3, 175);
            this.mainGroupPanelLabel2.Name = "mainGroupPanelLabel2";
            this.mainGroupPanelLabel2.Size = new System.Drawing.Size(233, 31);
            this.mainGroupPanelLabel2.TabIndex = 4;
            this.mainGroupPanelLabel2.Text = "label2";
            this.mainGroupPanelLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mainGroupPanelPicture2
            // 
            this.mainGroupPanelPicture2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainGroupPanelPicture2.Location = new System.Drawing.Point(3, 3);
            this.mainGroupPanelPicture2.Name = "mainGroupPanelPicture2";
            this.mainGroupPanelPicture2.Size = new System.Drawing.Size(233, 169);
            this.mainGroupPanelPicture2.TabIndex = 3;
            this.mainGroupPanelPicture2.TabStop = false;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.mainGroupPanelLabel3, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.mainGroupPanelPicture3, 0, 0);
            this.tableLayoutPanel4.Location = new System.Drawing.Point(525, 3);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 85F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(239, 206);
            this.tableLayoutPanel4.TabIndex = 7;
            // 
            // mainGroupPanelLabel3
            // 
            this.mainGroupPanelLabel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainGroupPanelLabel3.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainGroupPanelLabel3.Location = new System.Drawing.Point(3, 175);
            this.mainGroupPanelLabel3.Name = "mainGroupPanelLabel3";
            this.mainGroupPanelLabel3.Size = new System.Drawing.Size(233, 31);
            this.mainGroupPanelLabel3.TabIndex = 5;
            this.mainGroupPanelLabel3.Text = "label3";
            this.mainGroupPanelLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mainGroupPanelPicture3
            // 
            this.mainGroupPanelPicture3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainGroupPanelPicture3.Location = new System.Drawing.Point(3, 3);
            this.mainGroupPanelPicture3.Name = "mainGroupPanelPicture3";
            this.mainGroupPanelPicture3.Size = new System.Drawing.Size(233, 169);
            this.mainGroupPanelPicture3.TabIndex = 4;
            this.mainGroupPanelPicture3.TabStop = false;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.mainGroupPanelPicture1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(33, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 85F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(239, 206);
            this.tableLayoutPanel2.TabIndex = 8;
            // 
            // mainGroupPanelPicture1
            // 
            this.mainGroupPanelPicture1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainGroupPanelPicture1.Location = new System.Drawing.Point(3, 3);
            this.mainGroupPanelPicture1.Name = "mainGroupPanelPicture1";
            this.mainGroupPanelPicture1.Size = new System.Drawing.Size(233, 169);
            this.mainGroupPanelPicture1.TabIndex = 3;
            this.mainGroupPanelPicture1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.mainGroupPanelLabel1);
            this.panel1.Location = new System.Drawing.Point(3, 178);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(233, 25);
            this.panel1.TabIndex = 4;
            // 
            // mainGroupPanelLabel1
            // 
            this.mainGroupPanelLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainGroupPanelLabel1.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainGroupPanelLabel1.Location = new System.Drawing.Point(3, 0);
            this.mainGroupPanelLabel1.Name = "mainGroupPanelLabel1";
            this.mainGroupPanelLabel1.Size = new System.Drawing.Size(229, 25);
            this.mainGroupPanelLabel1.TabIndex = 0;
            this.mainGroupPanelLabel1.Text = "label1";
            this.mainGroupPanelLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(224)))), ((int)(((byte)(204)))));
            this.panel2.Controls.Add(this.faqButton);
            this.panel2.Controls.Add(this.aboutButton);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 418);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(800, 32);
            this.panel2.TabIndex = 1;
            // 
            // faqButton
            // 
            this.faqButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.faqButton.FlatAppearance.BorderSize = 0;
            this.faqButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.faqButton.Font = new System.Drawing.Font("Courier New", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.faqButton.Location = new System.Drawing.Point(105, 0);
            this.faqButton.Name = "faqButton";
            this.faqButton.Size = new System.Drawing.Size(92, 32);
            this.faqButton.TabIndex = 1;
            this.faqButton.Text = "D.U.K.";
            this.faqButton.UseVisualStyleBackColor = true;
            this.faqButton.Click += new System.EventHandler(this.faqButton_Click);
            // 
            // aboutButton
            // 
            this.aboutButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.aboutButton.FlatAppearance.BorderSize = 0;
            this.aboutButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.aboutButton.Font = new System.Drawing.Font("Courier New", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aboutButton.Location = new System.Drawing.Point(30, 0);
            this.aboutButton.Name = "aboutButton";
            this.aboutButton.Size = new System.Drawing.Size(75, 32);
            this.aboutButton.TabIndex = 0;
            this.aboutButton.Text = "Apie";
            this.aboutButton.UseVisualStyleBackColor = true;
            this.aboutButton.Click += new System.EventHandler(this.aboutButton_Click);
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
            this.titleBar.Size = new System.Drawing.Size(800, 48);
            this.titleBar.TabIndex = 2;
            this.titleBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MoveWindow);
            // 
            // exitButton
            // 
            this.exitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.exitButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("exitButton.BackgroundImage")));
            this.exitButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.exitButton.FlatAppearance.BorderSize = 0;
            this.exitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exitButton.Location = new System.Drawing.Point(752, 4);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(40, 40);
            this.exitButton.TabIndex = 1;
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.ExitApplicationClick);
            // 
            // appName
            // 
            this.appName.Dock = System.Windows.Forms.DockStyle.Left;
            this.appName.Font = new System.Drawing.Font("Courier New", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.appName.Location = new System.Drawing.Point(0, 0);
            this.appName.Name = "appName";
            this.appName.Size = new System.Drawing.Size(256, 48);
            this.appName.TabIndex = 0;
            this.appName.Text = "CheapShop";
            this.appName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.appName.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MoveWindow);
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel5.Controls.Add(this.searchField, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.searchButton, 1, 0);
            this.tableLayoutPanel5.Location = new System.Drawing.Point(150, 95);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(500, 40);
            this.tableLayoutPanel5.TabIndex = 3;
            // 
            // searchField
            // 
            this.searchField.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.searchField.BackColor = System.Drawing.Color.White;
            this.searchField.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.searchField.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchField.ForeColor = System.Drawing.Color.Gray;
            this.searchField.Location = new System.Drawing.Point(3, 7);
            this.searchField.Name = "searchField";
            this.searchField.Size = new System.Drawing.Size(394, 26);
            this.searchField.TabIndex = 0;
            this.searchField.Text = "Įveskite ieškomą prekę";
            this.searchField.Enter += new System.EventHandler(this.SearchEnter);
            this.searchField.Leave += new System.EventHandler(this.SearchLeave);
            // 
            // searchButton
            // 
            this.searchButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.searchButton.FlatAppearance.BorderSize = 2;
            this.searchButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.searchButton.Font = new System.Drawing.Font("Courier New", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchButton.Location = new System.Drawing.Point(403, 5);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(94, 30);
            this.searchButton.TabIndex = 1;
            this.searchButton.Text = "Ieškoti";
            this.searchButton.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(173)))), ((int)(((byte)(161)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanel5);
            this.Controls.Add(this.titleBar);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(106)))), ((int)(((byte)(109)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mainGroupPanelPicture2)).EndInit();
            this.tableLayoutPanel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mainGroupPanelPicture3)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mainGroupPanelPicture1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.titleBar.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button mainGroupPanelRight;
        private System.Windows.Forms.Button mainGroupPanelLeft;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label mainGroupPanelLabel2;
        private System.Windows.Forms.PictureBox mainGroupPanelPicture2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Label mainGroupPanelLabel3;
        private System.Windows.Forms.PictureBox mainGroupPanelPicture3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.PictureBox mainGroupPanelPicture1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label mainGroupPanelLabel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button aboutButton;
        private System.Windows.Forms.Button faqButton;
        private System.Windows.Forms.Panel titleBar;
        private System.Windows.Forms.Label appName;
        private System.Windows.Forms.Button exitButton;
        private TableLayoutPanel tableLayoutPanel5;
        private TextBox searchField;
        private Button searchButton;
    }
}