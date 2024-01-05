namespace VOVO
{
    partial class CustomerProfile
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.title_panel = new System.Windows.Forms.Panel();
            this.title = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.back_button = new System.Windows.Forms.Button();
            this.delete_update_button = new System.Windows.Forms.Button();
            this.password_tb = new CustomControls.CustomControls.CustomTextBox();
            this.email_tb = new CustomControls.CustomControls.CustomTextBox();
            this.phone_number_tb = new CustomControls.CustomControls.CustomTextBox();
            this.name_tb = new CustomControls.CustomControls.CustomTextBox();
            this.id_tb = new CustomControls.CustomControls.CustomTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.male_radio_button = new System.Windows.Forms.RadioButton();
            this.female_radio_button = new System.Windows.Forms.RadioButton();
            this.others_radio_button = new System.Windows.Forms.RadioButton();
            this.prefernottosay_radio_button = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.title_panel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // title_panel
            // 
            this.title_panel.Controls.Add(this.title);
            this.title_panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.title_panel.Location = new System.Drawing.Point(0, 0);
            this.title_panel.Name = "title_panel";
            this.title_panel.Size = new System.Drawing.Size(611, 101);
            this.title_panel.TabIndex = 0;
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title.Image = global::VOVO.Properties.Resources.squares1;
            this.title.Location = new System.Drawing.Point(173, 36);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(270, 39);
            this.title.TabIndex = 0;
            this.title.Text = "Customer Profile";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(42, 125);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(42, 175);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 25);
            this.label2.TabIndex = 0;
            this.label2.Text = "Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(42, 217);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(143, 25);
            this.label3.TabIndex = 0;
            this.label3.Text = "Phone Number";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(46, 273);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 25);
            this.label4.TabIndex = 0;
            this.label4.Text = "Email";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(42, 364);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 25);
            this.label5.TabIndex = 0;
            this.label5.Text = "Password";
            // 
            // back_button
            // 
            this.back_button.BackColor = System.Drawing.Color.Coral;
            this.back_button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.back_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.back_button.Location = new System.Drawing.Point(349, 426);
            this.back_button.Name = "back_button";
            this.back_button.Size = new System.Drawing.Size(105, 35);
            this.back_button.TabIndex = 7;
            this.back_button.Text = "Back";
            this.back_button.UseVisualStyleBackColor = false;
            this.back_button.Click += new System.EventHandler(this.back_button_Click);
            // 
            // delete_update_button
            // 
            this.delete_update_button.BackColor = System.Drawing.Color.Coral;
            this.delete_update_button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.delete_update_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.delete_update_button.Location = new System.Drawing.Point(204, 426);
            this.delete_update_button.Name = "delete_update_button";
            this.delete_update_button.Size = new System.Drawing.Size(105, 35);
            this.delete_update_button.TabIndex = 7;
            this.delete_update_button.Text = "Delete";
            this.delete_update_button.UseVisualStyleBackColor = false;
            this.delete_update_button.Visible = false;
            this.delete_update_button.Click += new System.EventHandler(this.delete_update_button_Click);
            // 
            // password_tb
            // 
            this.password_tb.BackColor = System.Drawing.SystemColors.Window;
            this.password_tb.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.password_tb.BorderFocusColor = System.Drawing.Color.HotPink;
            this.password_tb.BorderRadius = 0;
            this.password_tb.BorderSize = 2;
            this.password_tb.Enabled = false;
            this.password_tb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.password_tb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.password_tb.Location = new System.Drawing.Point(204, 358);
            this.password_tb.Margin = new System.Windows.Forms.Padding(4);
            this.password_tb.MaxLength = 32767;
            this.password_tb.Multiline = false;
            this.password_tb.Name = "password_tb";
            this.password_tb.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.password_tb.PasswordChar = false;
            this.password_tb.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.password_tb.PlaceholderText = "";
            this.password_tb.ReadOnly = true;
            this.password_tb.SelectionStart = 0;
            this.password_tb.Size = new System.Drawing.Size(339, 31);
            this.password_tb.TabIndex = 1;
            this.password_tb.Texts = "";
            this.password_tb.UnderlinedStyle = false;
            this.password_tb._TextChanged += new System.EventHandler(this.tb_TextChanged);
            // 
            // email_tb
            // 
            this.email_tb.BackColor = System.Drawing.SystemColors.Window;
            this.email_tb.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.email_tb.BorderFocusColor = System.Drawing.Color.HotPink;
            this.email_tb.BorderRadius = 0;
            this.email_tb.BorderSize = 2;
            this.email_tb.Enabled = false;
            this.email_tb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.email_tb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.email_tb.Location = new System.Drawing.Point(204, 273);
            this.email_tb.Margin = new System.Windows.Forms.Padding(4);
            this.email_tb.MaxLength = 32767;
            this.email_tb.Multiline = false;
            this.email_tb.Name = "email_tb";
            this.email_tb.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.email_tb.PasswordChar = false;
            this.email_tb.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.email_tb.PlaceholderText = "";
            this.email_tb.ReadOnly = true;
            this.email_tb.SelectionStart = 0;
            this.email_tb.Size = new System.Drawing.Size(339, 31);
            this.email_tb.TabIndex = 1;
            this.email_tb.Texts = "";
            this.email_tb.UnderlinedStyle = false;
            this.email_tb._TextChanged += new System.EventHandler(this.tb_TextChanged);
            // 
            // phone_number_tb
            // 
            this.phone_number_tb.BackColor = System.Drawing.SystemColors.Window;
            this.phone_number_tb.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.phone_number_tb.BorderFocusColor = System.Drawing.Color.HotPink;
            this.phone_number_tb.BorderRadius = 0;
            this.phone_number_tb.BorderSize = 2;
            this.phone_number_tb.Enabled = false;
            this.phone_number_tb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phone_number_tb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.phone_number_tb.Location = new System.Drawing.Point(204, 217);
            this.phone_number_tb.Margin = new System.Windows.Forms.Padding(4);
            this.phone_number_tb.MaxLength = 32767;
            this.phone_number_tb.Multiline = false;
            this.phone_number_tb.Name = "phone_number_tb";
            this.phone_number_tb.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.phone_number_tb.PasswordChar = false;
            this.phone_number_tb.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.phone_number_tb.PlaceholderText = "";
            this.phone_number_tb.ReadOnly = true;
            this.phone_number_tb.SelectionStart = 0;
            this.phone_number_tb.Size = new System.Drawing.Size(339, 31);
            this.phone_number_tb.TabIndex = 1;
            this.phone_number_tb.Texts = "";
            this.phone_number_tb.UnderlinedStyle = false;
            this.phone_number_tb._TextChanged += new System.EventHandler(this.tb_TextChanged);
            // 
            // name_tb
            // 
            this.name_tb.BackColor = System.Drawing.SystemColors.Window;
            this.name_tb.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.name_tb.BorderFocusColor = System.Drawing.Color.HotPink;
            this.name_tb.BorderRadius = 0;
            this.name_tb.BorderSize = 2;
            this.name_tb.Enabled = false;
            this.name_tb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.name_tb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.name_tb.Location = new System.Drawing.Point(204, 169);
            this.name_tb.Margin = new System.Windows.Forms.Padding(4);
            this.name_tb.MaxLength = 32767;
            this.name_tb.Multiline = false;
            this.name_tb.Name = "name_tb";
            this.name_tb.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.name_tb.PasswordChar = false;
            this.name_tb.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.name_tb.PlaceholderText = "";
            this.name_tb.ReadOnly = true;
            this.name_tb.SelectionStart = 0;
            this.name_tb.Size = new System.Drawing.Size(339, 31);
            this.name_tb.TabIndex = 1;
            this.name_tb.Texts = "";
            this.name_tb.UnderlinedStyle = false;
            this.name_tb._TextChanged += new System.EventHandler(this.tb_TextChanged);
            // 
            // id_tb
            // 
            this.id_tb.BackColor = System.Drawing.SystemColors.Window;
            this.id_tb.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.id_tb.BorderFocusColor = System.Drawing.Color.HotPink;
            this.id_tb.BorderRadius = 0;
            this.id_tb.BorderSize = 2;
            this.id_tb.Enabled = false;
            this.id_tb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.id_tb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.id_tb.Location = new System.Drawing.Point(204, 119);
            this.id_tb.Margin = new System.Windows.Forms.Padding(4);
            this.id_tb.MaxLength = 32767;
            this.id_tb.Multiline = false;
            this.id_tb.Name = "id_tb";
            this.id_tb.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.id_tb.PasswordChar = false;
            this.id_tb.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.id_tb.PlaceholderText = "";
            this.id_tb.ReadOnly = true;
            this.id_tb.SelectionStart = 0;
            this.id_tb.Size = new System.Drawing.Size(339, 31);
            this.id_tb.TabIndex = 1;
            this.id_tb.Texts = "";
            this.id_tb.UnderlinedStyle = false;
            this.id_tb._TextChanged += new System.EventHandler(this.tb_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(42, 324);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 25);
            this.label6.TabIndex = 0;
            this.label6.Text = "Gender";
            // 
            // male_radio_button
            // 
            this.male_radio_button.AutoSize = true;
            this.male_radio_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.male_radio_button.Location = new System.Drawing.Point(0, 2);
            this.male_radio_button.Name = "male_radio_button";
            this.male_radio_button.Size = new System.Drawing.Size(61, 24);
            this.male_radio_button.TabIndex = 8;
            this.male_radio_button.TabStop = true;
            this.male_radio_button.Text = "Male";
            this.male_radio_button.UseVisualStyleBackColor = true;
            // 
            // female_radio_button
            // 
            this.female_radio_button.AutoSize = true;
            this.female_radio_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.female_radio_button.Location = new System.Drawing.Point(76, 2);
            this.female_radio_button.Name = "female_radio_button";
            this.female_radio_button.Size = new System.Drawing.Size(80, 24);
            this.female_radio_button.TabIndex = 8;
            this.female_radio_button.TabStop = true;
            this.female_radio_button.Text = "Female";
            this.female_radio_button.UseVisualStyleBackColor = true;
            // 
            // others_radio_button
            // 
            this.others_radio_button.AutoSize = true;
            this.others_radio_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.others_radio_button.Location = new System.Drawing.Point(171, 2);
            this.others_radio_button.Name = "others_radio_button";
            this.others_radio_button.Size = new System.Drawing.Size(75, 24);
            this.others_radio_button.TabIndex = 8;
            this.others_radio_button.TabStop = true;
            this.others_radio_button.Text = "Others";
            this.others_radio_button.UseVisualStyleBackColor = true;
            // 
            // prefernottosay_radio_button
            // 
            this.prefernottosay_radio_button.AutoSize = true;
            this.prefernottosay_radio_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.prefernottosay_radio_button.Location = new System.Drawing.Point(256, 2);
            this.prefernottosay_radio_button.Name = "prefernottosay_radio_button";
            this.prefernottosay_radio_button.Size = new System.Drawing.Size(83, 24);
            this.prefernottosay_radio_button.TabIndex = 8;
            this.prefernottosay_radio_button.TabStop = true;
            this.prefernottosay_radio_button.Text = "Not Say";
            this.prefernottosay_radio_button.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.female_radio_button);
            this.panel1.Controls.Add(this.prefernottosay_radio_button);
            this.panel1.Controls.Add(this.male_radio_button);
            this.panel1.Controls.Add(this.others_radio_button);
            this.panel1.Location = new System.Drawing.Point(204, 322);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(339, 27);
            this.panel1.TabIndex = 9;
            // 
            // CustomerProfile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.back_button);
            this.Controls.Add(this.password_tb);
            this.Controls.Add(this.email_tb);
            this.Controls.Add(this.phone_number_tb);
            this.Controls.Add(this.name_tb);
            this.Controls.Add(this.id_tb);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.title_panel);
            this.Controls.Add(this.delete_update_button);
            this.Name = "CustomerProfile";
            this.Size = new System.Drawing.Size(611, 493);
            this.Load += new System.EventHandler(this.CustomerProfile_Load);
            this.title_panel.ResumeLayout(false);
            this.title_panel.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel title_panel;
        private System.Windows.Forms.Label title;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private CustomControls.CustomControls.CustomTextBox id_tb;
        private CustomControls.CustomControls.CustomTextBox name_tb;
        private CustomControls.CustomControls.CustomTextBox phone_number_tb;
        private CustomControls.CustomControls.CustomTextBox email_tb;
        private CustomControls.CustomControls.CustomTextBox password_tb;
        private System.Windows.Forms.Button back_button;
        private System.Windows.Forms.Button delete_update_button;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RadioButton male_radio_button;
        private System.Windows.Forms.RadioButton female_radio_button;
        private System.Windows.Forms.RadioButton others_radio_button;
        private System.Windows.Forms.RadioButton prefernottosay_radio_button;
        private System.Windows.Forms.Panel panel1;
    }
}
