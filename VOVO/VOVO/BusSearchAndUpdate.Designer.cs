namespace VOVO
{
    partial class BusSearchAndUpdate
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
            this.registration_number_button = new System.Windows.Forms.Button();
            this.company_name_button = new System.Windows.Forms.Button();
            this.search_button = new System.Windows.Forms.Button();
            this.search_tb = new MetroFramework.Controls.MetroTextBox();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(430, 50);
            this.panel1.TabIndex = 0;
            // 
            // registration_number_button
            // 
            this.registration_number_button.Enabled = false;
            this.registration_number_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.registration_number_button.Location = new System.Drawing.Point(12, 72);
            this.registration_number_button.Name = "registration_number_button";
            this.registration_number_button.Size = new System.Drawing.Size(163, 40);
            this.registration_number_button.TabIndex = 3;
            this.registration_number_button.Text = "Registration Number";
            this.registration_number_button.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.registration_number_button.UseVisualStyleBackColor = true;
            this.registration_number_button.Click += new System.EventHandler(this.registration_number_button_Click);
            // 
            // company_name_button
            // 
            this.company_name_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.company_name_button.Location = new System.Drawing.Point(193, 72);
            this.company_name_button.Name = "company_name_button";
            this.company_name_button.Size = new System.Drawing.Size(136, 40);
            this.company_name_button.TabIndex = 3;
            this.company_name_button.Text = "Company Name";
            this.company_name_button.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.company_name_button.UseVisualStyleBackColor = true;
            this.company_name_button.Click += new System.EventHandler(this.company_name_button_Click);
            // 
            // search_button
            // 
            this.search_button.BackColor = System.Drawing.Color.Coral;
            this.search_button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.search_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.search_button.Location = new System.Drawing.Point(302, 168);
            this.search_button.Name = "search_button";
            this.search_button.Size = new System.Drawing.Size(105, 35);
            this.search_button.TabIndex = 3;
            this.search_button.Text = "Search";
            this.search_button.UseVisualStyleBackColor = false;
            this.search_button.Click += new System.EventHandler(this.search_button_Click);
            // 
            // search_tb
            // 
            // 
            // 
            // 
            this.search_tb.CustomButton.Image = null;
            this.search_tb.CustomButton.Location = new System.Drawing.Point(380, 2);
            this.search_tb.CustomButton.Name = "";
            this.search_tb.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.search_tb.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.search_tb.CustomButton.TabIndex = 1;
            this.search_tb.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.search_tb.CustomButton.UseSelectable = true;
            this.search_tb.CustomButton.Visible = false;
            this.search_tb.Lines = new string[0];
            this.search_tb.Location = new System.Drawing.Point(12, 136);
            this.search_tb.MaxLength = 32767;
            this.search_tb.Name = "search_tb";
            this.search_tb.PasswordChar = '\0';
            this.search_tb.PromptText = "Enter Bus Registration Number";
            this.search_tb.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.search_tb.SelectedText = "";
            this.search_tb.SelectionLength = 0;
            this.search_tb.SelectionStart = 0;
            this.search_tb.ShortcutsEnabled = true;
            this.search_tb.Size = new System.Drawing.Size(404, 26);
            this.search_tb.TabIndex = 6;
            this.search_tb.UseCustomBackColor = true;
            this.search_tb.UseCustomForeColor = true;
            this.search_tb.UseSelectable = true;
            this.search_tb.WaterMark = "Enter Bus Registration Number";
            this.search_tb.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.search_tb.WaterMarkFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // BusSearchAndUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(430, 215);
            this.Controls.Add(this.search_tb);
            this.Controls.Add(this.search_button);
            this.Controls.Add(this.company_name_button);
            this.Controls.Add(this.registration_number_button);
            this.Controls.Add(this.panel1);
            this.Name = "BusSearchAndUpdate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BusSearchAndUpdate";
            this.SizeChanged += new System.EventHandler(this.BusSearchAndUpdate_SizeChanged);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button registration_number_button;
        private System.Windows.Forms.Button company_name_button;
        private System.Windows.Forms.Button search_button;
        private MetroFramework.Controls.MetroTextBox search_tb;
    }
}