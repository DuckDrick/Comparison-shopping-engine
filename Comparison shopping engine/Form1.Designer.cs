﻿namespace Comparison_shopping_engine
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
            this.results = new System.Windows.Forms.RichTextBox();
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
            // results
            // 
            this.results.Location = new System.Drawing.Point(106, 81);
            this.results.Name = "results";
            this.results.Size = new System.Drawing.Size(594, 395);
            this.results.TabIndex = 2;
            this.results.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(848, 488);
            this.Controls.Add(this.results);
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
        private System.Windows.Forms.RichTextBox results;
    }
}

