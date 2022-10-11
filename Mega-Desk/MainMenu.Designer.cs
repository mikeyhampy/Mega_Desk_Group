using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mega_Desk_Hampton
{
    partial class MainMenu
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
            this.Add_New_Quote = new System.Windows.Forms.Button();
            this.View_Quotes = new System.Windows.Forms.Button();
            this.Search_Quotes = new System.Windows.Forms.Button();
            this.ExitButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Add_New_Quote
            // 
            this.Add_New_Quote.Location = new System.Drawing.Point(78, 33);
            this.Add_New_Quote.Name = "Add_New_Quote";
            this.Add_New_Quote.Size = new System.Drawing.Size(143, 48);
            this.Add_New_Quote.TabIndex = 0;
            this.Add_New_Quote.Text = "Add New Quote";
            this.Add_New_Quote.UseVisualStyleBackColor = true;
            this.Add_New_Quote.Click += new System.EventHandler(this.Add_New_Quote_Click);
            // 
            // View_Quotes
            // 
            this.View_Quotes.Location = new System.Drawing.Point(78, 97);
            this.View_Quotes.Name = "View_Quotes";
            this.View_Quotes.Size = new System.Drawing.Size(143, 48);
            this.View_Quotes.TabIndex = 1;
            this.View_Quotes.Text = "View Quotes";
            this.View_Quotes.UseVisualStyleBackColor = true;
            this.View_Quotes.Click += new System.EventHandler(this.View_Quotes_Click);
            // 
            // Search_Quotes
            // 
            this.Search_Quotes.Location = new System.Drawing.Point(78, 171);
            this.Search_Quotes.Name = "Search_Quotes";
            this.Search_Quotes.Size = new System.Drawing.Size(143, 48);
            this.Search_Quotes.TabIndex = 2;
            this.Search_Quotes.Text = "Search Quotes";
            this.Search_Quotes.UseVisualStyleBackColor = true;
            this.Search_Quotes.Click += new System.EventHandler(this.Search_Quotes_Click);
            // 
            // ExitButton
            // 
            this.ExitButton.Location = new System.Drawing.Point(78, 242);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(143, 48);
            this.ExitButton.TabIndex = 3;
            this.ExitButton.Text = "Exit";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.Exit);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.Search_Quotes);
            this.Controls.Add(this.View_Quotes);
            this.Controls.Add(this.Add_New_Quote);
            this.Name = "MainMenu";
            this.Text = "MegaDesk";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Button Add_New_Quote;
        private Button View_Quotes;
        private Button Search_Quotes;
        private Button ExitButton;
    }
}

