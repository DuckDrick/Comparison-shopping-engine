namespace Comparison_shopping_engine.Forms
{
    partial class ScraperSettings
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
            this.titleBar = new System.Windows.Forms.Panel();
            this.appName = new System.Windows.Forms.Label();
            this.scraperSettingsSave = new System.Windows.Forms.Button();
            this.scraperSettingsCancel = new System.Windows.Forms.Button();
            this.scraperAmount = new System.Windows.Forms.NumericUpDown();
            this.scraperTimeout = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.titleBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scraperAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scraperTimeout)).BeginInit();
            this.SuspendLayout();
            // 
            // titleBar
            // 
            this.titleBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(79)))), ((int)(((byte)(91)))));
            this.titleBar.Controls.Add(this.appName);
            this.titleBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.titleBar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(14)))), ((int)(((byte)(59)))));
            this.titleBar.Location = new System.Drawing.Point(0, 0);
            this.titleBar.Name = "titleBar";
            this.titleBar.Size = new System.Drawing.Size(480, 52);
            this.titleBar.TabIndex = 5;
            this.titleBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MoveWindow);
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
            // scraperSettingsSave
            // 
            this.scraperSettingsSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.scraperSettingsSave.Location = new System.Drawing.Point(381, 184);
            this.scraperSettingsSave.Name = "scraperSettingsSave";
            this.scraperSettingsSave.Size = new System.Drawing.Size(87, 23);
            this.scraperSettingsSave.TabIndex = 6;
            this.scraperSettingsSave.Text = "Išsaugoti";
            this.scraperSettingsSave.UseVisualStyleBackColor = true;
            this.scraperSettingsSave.Click += new System.EventHandler(this.scraperSettingsSave_Click);
            // 
            // scraperSettingsCancel
            // 
            this.scraperSettingsCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.scraperSettingsCancel.Location = new System.Drawing.Point(300, 184);
            this.scraperSettingsCancel.Name = "scraperSettingsCancel";
            this.scraperSettingsCancel.Size = new System.Drawing.Size(75, 23);
            this.scraperSettingsCancel.TabIndex = 7;
            this.scraperSettingsCancel.Text = "Atšaukti";
            this.scraperSettingsCancel.UseVisualStyleBackColor = true;
            this.scraperSettingsCancel.Click += new System.EventHandler(this.scraperSettingsCancel_Click);
            // 
            // scraperAmount
            // 
            this.scraperAmount.Location = new System.Drawing.Point(12, 76);
            this.scraperAmount.Name = "scraperAmount";
            this.scraperAmount.Size = new System.Drawing.Size(120, 20);
            this.scraperAmount.TabIndex = 8;
            // 
            // scraperTimeout
            // 
            this.scraperTimeout.Location = new System.Drawing.Point(12, 114);
            this.scraperTimeout.Name = "scraperTimeout";
            this.scraperTimeout.Size = new System.Drawing.Size(120, 20);
            this.scraperTimeout.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(294, 14);
            this.label1.TabIndex = 10;
            this.label1.Text = "Vieno puslapio papildomų scraperių kiekis";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(175, 14);
            this.label2.TabIndex = 11;
            this.label2.Text = "Scraperio laukimo laikas";
            // 
            // ScraperSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(173)))), ((int)(((byte)(161)))));
            this.ClientSize = new System.Drawing.Size(480, 219);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.scraperTimeout);
            this.Controls.Add(this.scraperAmount);
            this.Controls.Add(this.scraperSettingsCancel);
            this.Controls.Add(this.scraperSettingsSave);
            this.Controls.Add(this.titleBar);
            this.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Bold);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(106)))), ((int)(((byte)(109)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ScraperSettings";
            this.Text = "ScraperSettings";
            this.Load += new System.EventHandler(this.ScraperSettings_Load);
            this.titleBar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scraperAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.scraperTimeout)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel titleBar;
        private System.Windows.Forms.Label appName;
        private System.Windows.Forms.Button scraperSettingsSave;
        private System.Windows.Forms.Button scraperSettingsCancel;
        private System.Windows.Forms.NumericUpDown scraperAmount;
        private System.Windows.Forms.NumericUpDown scraperTimeout;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}