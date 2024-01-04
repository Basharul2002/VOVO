namespace VOVO
{
    partial class DriverRegistration
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
            this.title = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.licence_number_tb = new CustomControls.CustomControls.CustomTextBox();
            this.licence_type_tb = new CustomControls.CustomControls.CustomTextBox();
            this.licence_expiration_date_tb = new CustomControls.CustomControls.CustomTextBox();
            this.driving_history_vehicle_type = new CustomControls.CustomControls.CustomTextBox();
            this.driving_history_registration_number = new CustomControls.CustomControls.CustomTextBox();
            this.driving_history_compilance_record_tb = new CustomControls.CustomControls.CustomTextBox();
            this.next_button = new System.Windows.Forms.Button();
            this.clear_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.Font = new System.Drawing.Font("Montserrat", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title.Location = new System.Drawing.Point(113, 11);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(254, 29);
            this.title.TabIndex = 0;
            this.title.Text = "Driving Informarion";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(14, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "Licence Number";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(14, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 20);
            this.label4.TabIndex = 1;
            this.label4.Text = "License Type";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(14, 154);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(118, 20);
            this.label5.TabIndex = 1;
            this.label5.Text = "Expiration Date";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(14, 230);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(99, 20);
            this.label6.TabIndex = 1;
            this.label6.Text = "Vehicle Type";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 266);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Registration Number";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(7, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Licence Information";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(7, 200);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(110, 20);
            this.label7.TabIndex = 1;
            this.label7.Text = "Driving History";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(14, 305);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(156, 20);
            this.label8.TabIndex = 1;
            this.label8.Text = "Compliance Records";
            // 
            // licence_number_tb
            // 
            this.licence_number_tb.BackColor = System.Drawing.Color.RosyBrown;
            this.licence_number_tb.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.licence_number_tb.BorderFocusColor = System.Drawing.Color.HotPink;
            this.licence_number_tb.BorderRadius = 0;
            this.licence_number_tb.BorderSize = 2;
            this.licence_number_tb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.licence_number_tb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.licence_number_tb.Location = new System.Drawing.Point(145, 79);
            this.licence_number_tb.Margin = new System.Windows.Forms.Padding(4);
            this.licence_number_tb.MaxLength = 32767;
            this.licence_number_tb.Multiline = false;
            this.licence_number_tb.Name = "licence_number_tb";
            this.licence_number_tb.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.licence_number_tb.PasswordChar = false;
            this.licence_number_tb.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.licence_number_tb.PlaceholderText = "";
            this.licence_number_tb.ReadOnly = false;
            this.licence_number_tb.Size = new System.Drawing.Size(250, 31);
            this.licence_number_tb.TabIndex = 2;
            this.licence_number_tb.Texts = "";
            this.licence_number_tb.UnderlinedStyle = true;
            // 
            // licence_type_tb
            // 
            this.licence_type_tb.BackColor = System.Drawing.Color.RosyBrown;
            this.licence_type_tb.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.licence_type_tb.BorderFocusColor = System.Drawing.Color.HotPink;
            this.licence_type_tb.BorderRadius = 0;
            this.licence_type_tb.BorderSize = 2;
            this.licence_type_tb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.licence_type_tb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.licence_type_tb.Location = new System.Drawing.Point(134, 109);
            this.licence_type_tb.Margin = new System.Windows.Forms.Padding(4);
            this.licence_type_tb.MaxLength = 32767;
            this.licence_type_tb.Multiline = false;
            this.licence_type_tb.Name = "licence_type_tb";
            this.licence_type_tb.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.licence_type_tb.PasswordChar = false;
            this.licence_type_tb.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.licence_type_tb.PlaceholderText = "";
            this.licence_type_tb.ReadOnly = false;
            this.licence_type_tb.Size = new System.Drawing.Size(250, 31);
            this.licence_type_tb.TabIndex = 2;
            this.licence_type_tb.Texts = "";
            this.licence_type_tb.UnderlinedStyle = true;
            // 
            // licence_expiration_date_tb
            // 
            this.licence_expiration_date_tb.BackColor = System.Drawing.Color.RosyBrown;
            this.licence_expiration_date_tb.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.licence_expiration_date_tb.BorderFocusColor = System.Drawing.Color.HotPink;
            this.licence_expiration_date_tb.BorderRadius = 0;
            this.licence_expiration_date_tb.BorderSize = 2;
            this.licence_expiration_date_tb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.licence_expiration_date_tb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.licence_expiration_date_tb.Location = new System.Drawing.Point(134, 143);
            this.licence_expiration_date_tb.Margin = new System.Windows.Forms.Padding(4);
            this.licence_expiration_date_tb.MaxLength = 32767;
            this.licence_expiration_date_tb.Multiline = false;
            this.licence_expiration_date_tb.Name = "licence_expiration_date_tb";
            this.licence_expiration_date_tb.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.licence_expiration_date_tb.PasswordChar = false;
            this.licence_expiration_date_tb.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.licence_expiration_date_tb.PlaceholderText = "";
            this.licence_expiration_date_tb.ReadOnly = false;
            this.licence_expiration_date_tb.Size = new System.Drawing.Size(250, 31);
            this.licence_expiration_date_tb.TabIndex = 2;
            this.licence_expiration_date_tb.Texts = "";
            this.licence_expiration_date_tb.UnderlinedStyle = true;
            // 
            // driving_history_vehicle_type
            // 
            this.driving_history_vehicle_type.BackColor = System.Drawing.Color.RosyBrown;
            this.driving_history_vehicle_type.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.driving_history_vehicle_type.BorderFocusColor = System.Drawing.Color.HotPink;
            this.driving_history_vehicle_type.BorderRadius = 0;
            this.driving_history_vehicle_type.BorderSize = 2;
            this.driving_history_vehicle_type.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.driving_history_vehicle_type.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.driving_history_vehicle_type.Location = new System.Drawing.Point(120, 219);
            this.driving_history_vehicle_type.Margin = new System.Windows.Forms.Padding(4);
            this.driving_history_vehicle_type.MaxLength = 32767;
            this.driving_history_vehicle_type.Multiline = false;
            this.driving_history_vehicle_type.Name = "driving_history_vehicle_type";
            this.driving_history_vehicle_type.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.driving_history_vehicle_type.PasswordChar = false;
            this.driving_history_vehicle_type.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.driving_history_vehicle_type.PlaceholderText = "";
            this.driving_history_vehicle_type.ReadOnly = false;
            this.driving_history_vehicle_type.Size = new System.Drawing.Size(250, 31);
            this.driving_history_vehicle_type.TabIndex = 2;
            this.driving_history_vehicle_type.Texts = "";
            this.driving_history_vehicle_type.UnderlinedStyle = true;
            // 
            // driving_history_registration_number
            // 
            this.driving_history_registration_number.BackColor = System.Drawing.Color.RosyBrown;
            this.driving_history_registration_number.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.driving_history_registration_number.BorderFocusColor = System.Drawing.Color.HotPink;
            this.driving_history_registration_number.BorderRadius = 0;
            this.driving_history_registration_number.BorderSize = 2;
            this.driving_history_registration_number.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.driving_history_registration_number.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.driving_history_registration_number.Location = new System.Drawing.Point(177, 255);
            this.driving_history_registration_number.Margin = new System.Windows.Forms.Padding(4);
            this.driving_history_registration_number.MaxLength = 32767;
            this.driving_history_registration_number.Multiline = false;
            this.driving_history_registration_number.Name = "driving_history_registration_number";
            this.driving_history_registration_number.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.driving_history_registration_number.PasswordChar = false;
            this.driving_history_registration_number.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.driving_history_registration_number.PlaceholderText = "";
            this.driving_history_registration_number.ReadOnly = false;
            this.driving_history_registration_number.Size = new System.Drawing.Size(250, 31);
            this.driving_history_registration_number.TabIndex = 2;
            this.driving_history_registration_number.Texts = "";
            this.driving_history_registration_number.UnderlinedStyle = true;
            // 
            // driving_history_compilance_record_tb
            // 
            this.driving_history_compilance_record_tb.BackColor = System.Drawing.Color.RosyBrown;
            this.driving_history_compilance_record_tb.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.driving_history_compilance_record_tb.BorderFocusColor = System.Drawing.Color.HotPink;
            this.driving_history_compilance_record_tb.BorderRadius = 0;
            this.driving_history_compilance_record_tb.BorderSize = 2;
            this.driving_history_compilance_record_tb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.driving_history_compilance_record_tb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.driving_history_compilance_record_tb.Location = new System.Drawing.Point(177, 294);
            this.driving_history_compilance_record_tb.Margin = new System.Windows.Forms.Padding(4);
            this.driving_history_compilance_record_tb.MaxLength = 32767;
            this.driving_history_compilance_record_tb.Multiline = false;
            this.driving_history_compilance_record_tb.Name = "driving_history_compilance_record_tb";
            this.driving_history_compilance_record_tb.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.driving_history_compilance_record_tb.PasswordChar = false;
            this.driving_history_compilance_record_tb.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.driving_history_compilance_record_tb.PlaceholderText = "";
            this.driving_history_compilance_record_tb.ReadOnly = false;
            this.driving_history_compilance_record_tb.Size = new System.Drawing.Size(250, 31);
            this.driving_history_compilance_record_tb.TabIndex = 2;
            this.driving_history_compilance_record_tb.Texts = "";
            this.driving_history_compilance_record_tb.UnderlinedStyle = true;
            // 
            // next_button
            // 
            this.next_button.BackColor = System.Drawing.Color.OrangeRed;
            this.next_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.next_button.FlatAppearance.BorderColor = System.Drawing.Color.Sienna;
            this.next_button.FlatAppearance.BorderSize = 2;
            this.next_button.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.next_button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.next_button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.next_button.Font = new System.Drawing.Font("Microsoft Tai Le", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.next_button.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.next_button.Location = new System.Drawing.Point(258, 347);
            this.next_button.Margin = new System.Windows.Forms.Padding(2);
            this.next_button.Name = "next_button";
            this.next_button.Size = new System.Drawing.Size(98, 31);
            this.next_button.TabIndex = 4;
            this.next_button.Text = "Next";
            this.next_button.UseVisualStyleBackColor = false;
            this.next_button.Click += new System.EventHandler(this.next_button_Click);
            // 
            // clear_button
            // 
            this.clear_button.BackColor = System.Drawing.Color.LightCyan;
            this.clear_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.clear_button.FlatAppearance.BorderColor = System.Drawing.Color.Sienna;
            this.clear_button.FlatAppearance.BorderSize = 2;
            this.clear_button.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.clear_button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.clear_button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.clear_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clear_button.Location = new System.Drawing.Point(106, 347);
            this.clear_button.Margin = new System.Windows.Forms.Padding(2);
            this.clear_button.Name = "clear_button";
            this.clear_button.Size = new System.Drawing.Size(98, 31);
            this.clear_button.TabIndex = 5;
            this.clear_button.Text = "Clear";
            this.clear_button.UseVisualStyleBackColor = false;
            // 
            // DriverRegistration
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.RosyBrown;
            this.Controls.Add(this.next_button);
            this.Controls.Add(this.clear_button);
            this.Controls.Add(this.driving_history_compilance_record_tb);
            this.Controls.Add(this.driving_history_registration_number);
            this.Controls.Add(this.driving_history_vehicle_type);
            this.Controls.Add(this.licence_expiration_date_tb);
            this.Controls.Add(this.licence_type_tb);
            this.Controls.Add(this.licence_number_tb);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.title);
            this.Name = "DriverRegistration";
            this.Size = new System.Drawing.Size(507, 391);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label title;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private CustomControls.CustomControls.CustomTextBox licence_number_tb;
        private CustomControls.CustomControls.CustomTextBox licence_type_tb;
        private CustomControls.CustomControls.CustomTextBox licence_expiration_date_tb;
        private CustomControls.CustomControls.CustomTextBox driving_history_vehicle_type;
        private CustomControls.CustomControls.CustomTextBox driving_history_registration_number;
        private CustomControls.CustomControls.CustomTextBox driving_history_compilance_record_tb;
        private System.Windows.Forms.Button next_button;
        private System.Windows.Forms.Button clear_button;
    }
}
