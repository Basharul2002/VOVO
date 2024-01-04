﻿namespace VOVO
{
    partial class CustomerSearch
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.search_tb = new CustomControls.CustomControls.CustomTextBox();
            this.search_button = new System.Windows.Forms.Button();
            this.name_button = new System.Windows.Forms.Button();
            this.phone_number_button = new System.Windows.Forms.Button();
            this.email_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(431, 66);
            this.panel1.TabIndex = 0;
            // 
            // search_tb
            // 
            this.search_tb.BackColor = System.Drawing.SystemColors.Window;
            this.search_tb.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.search_tb.BorderFocusColor = System.Drawing.Color.HotPink;
            this.search_tb.BorderRadius = 0;
            this.search_tb.BorderSize = 2;
            this.search_tb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.search_tb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.search_tb.Location = new System.Drawing.Point(13, 127);
            this.search_tb.Margin = new System.Windows.Forms.Padding(4);
            this.search_tb.MaxLength = 32767;
            this.search_tb.Multiline = false;
            this.search_tb.Name = "search_tb";
            this.search_tb.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.search_tb.PasswordChar = false;
            this.search_tb.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.search_tb.PlaceholderText = "Enter Customer Name";
            this.search_tb.ReadOnly = false;
            this.search_tb.SelectionStart = 0;
            this.search_tb.Size = new System.Drawing.Size(404, 31);
            this.search_tb.TabIndex = 9;
            this.search_tb.Texts = "";
            this.search_tb.UnderlinedStyle = false;
            // 
            // search_button
            // 
            this.search_button.BackColor = System.Drawing.Color.Coral;
            this.search_button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.search_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.search_button.Location = new System.Drawing.Point(302, 176);
            this.search_button.Name = "search_button";
            this.search_button.Size = new System.Drawing.Size(105, 35);
            this.search_button.TabIndex = 6;
            this.search_button.Text = "Search";
            this.search_button.UseVisualStyleBackColor = false;
            this.search_button.Click += new System.EventHandler(this.search_button_Click);
            // 
            // name_button
            // 
            this.name_button.Enabled = false;
            this.name_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.name_button.Location = new System.Drawing.Point(12, 80);
            this.name_button.Name = "name_button";
            this.name_button.Size = new System.Drawing.Size(60, 40);
            this.name_button.TabIndex = 8;
            this.name_button.Text = "Name";
            this.name_button.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.name_button.UseVisualStyleBackColor = true;
            this.name_button.Click += new System.EventHandler(this.name_button_Click);
            // 
            // phone_number_button
            // 
            this.phone_number_button.Enabled = false;
            this.phone_number_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phone_number_button.Location = new System.Drawing.Point(78, 80);
            this.phone_number_button.Name = "phone_number_button";
            this.phone_number_button.Size = new System.Drawing.Size(124, 40);
            this.phone_number_button.TabIndex = 8;
            this.phone_number_button.Text = "Phone Number";
            this.phone_number_button.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.phone_number_button.UseVisualStyleBackColor = true;
            this.phone_number_button.Click += new System.EventHandler(this.phone_number_button_Click);
            // 
            // email_button
            // 
            this.email_button.Enabled = false;
            this.email_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.email_button.Location = new System.Drawing.Point(208, 80);
            this.email_button.Name = "email_button";
            this.email_button.Size = new System.Drawing.Size(58, 40);
            this.email_button.TabIndex = 8;
            this.email_button.Text = "Email";
            this.email_button.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.email_button.UseVisualStyleBackColor = true;
            this.email_button.Click += new System.EventHandler(this.email_button_Click);
            // 
            // CustomerSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(431, 221);
            this.Controls.Add(this.search_tb);
            this.Controls.Add(this.search_button);
            this.Controls.Add(this.email_button);
            this.Controls.Add(this.phone_number_button);
            this.Controls.Add(this.name_button);
            this.Controls.Add(this.panel1);
            this.Name = "CustomerSearch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CustomerSearch";
            this.SizeChanged += new System.EventHandler(this.CustomerSearch_SizeChanged);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private CustomControls.CustomControls.CustomTextBox search_tb;
        private System.Windows.Forms.Button search_button;
        private System.Windows.Forms.Button name_button;
        private System.Windows.Forms.Button phone_number_button;
        private System.Windows.Forms.Button email_button;
    }
}