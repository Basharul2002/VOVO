namespace VOVO
{
    partial class Office
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.id_tb = new System.Windows.Forms.TextBox();
            this.country_code_tb = new System.Windows.Forms.ComboBox();
            this.register_button = new System.Windows.Forms.Button();
            this.name_tb = new System.Windows.Forms.TextBox();
            this.email_tb = new System.Windows.Forms.TextBox();
            this.phone_number_tb = new System.Windows.Forms.TextBox();
            this.address_tb = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(110, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(232, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = "NEW OFFICE";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(33, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 25);
            this.label2.TabIndex = 0;
            this.label2.Text = "ID";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(33, 153);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 25);
            this.label3.TabIndex = 0;
            this.label3.Text = "Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(33, 298);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 25);
            this.label4.TabIndex = 0;
            this.label4.Text = "Address";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(31, 249);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(143, 25);
            this.label5.TabIndex = 0;
            this.label5.Text = "Phone Number";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(31, 201);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 25);
            this.label6.TabIndex = 0;
            this.label6.Text = "Email";
            // 
            // id_tb
            // 
            this.id_tb.Enabled = false;
            this.id_tb.Location = new System.Drawing.Point(183, 107);
            this.id_tb.Multiline = true;
            this.id_tb.Name = "id_tb";
            this.id_tb.ReadOnly = true;
            this.id_tb.Size = new System.Drawing.Size(250, 29);
            this.id_tb.TabIndex = 4;
            // 
            // country_code_tb
            // 
            this.country_code_tb.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.country_code_tb.FormattingEnabled = true;
            this.country_code_tb.Items.AddRange(new object[] {
            "+880(BAN)"});
            this.country_code_tb.Location = new System.Drawing.Point(183, 249);
            this.country_code_tb.Name = "country_code_tb";
            this.country_code_tb.Size = new System.Drawing.Size(100, 28);
            this.country_code_tb.TabIndex = 5;
            // 
            // register_button
            // 
            this.register_button.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.register_button.FlatAppearance.BorderSize = 0;
            this.register_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.register_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.register_button.ForeColor = System.Drawing.Color.White;
            this.register_button.Location = new System.Drawing.Point(151, 428);
            this.register_button.Name = "register_button";
            this.register_button.Size = new System.Drawing.Size(132, 36);
            this.register_button.TabIndex = 6;
            this.register_button.Text = "Register";
            this.register_button.UseVisualStyleBackColor = false;
            this.register_button.Click += new System.EventHandler(this.register_button_Click);
            // 
            // name_tb
            // 
            this.name_tb.Location = new System.Drawing.Point(183, 153);
            this.name_tb.Multiline = true;
            this.name_tb.Name = "name_tb";
            this.name_tb.Size = new System.Drawing.Size(250, 29);
            this.name_tb.TabIndex = 7;
            // 
            // email_tb
            // 
            this.email_tb.Location = new System.Drawing.Point(181, 201);
            this.email_tb.Multiline = true;
            this.email_tb.Name = "email_tb";
            this.email_tb.Size = new System.Drawing.Size(250, 29);
            this.email_tb.TabIndex = 8;
            // 
            // phone_number_tb
            // 
            this.phone_number_tb.Location = new System.Drawing.Point(282, 250);
            this.phone_number_tb.Multiline = true;
            this.phone_number_tb.Name = "phone_number_tb";
            this.phone_number_tb.Size = new System.Drawing.Size(151, 28);
            this.phone_number_tb.TabIndex = 9;
            // 
            // address_tb
            // 
            this.address_tb.Location = new System.Drawing.Point(181, 298);
            this.address_tb.Multiline = true;
            this.address_tb.Name = "address_tb";
            this.address_tb.Size = new System.Drawing.Size(250, 94);
            this.address_tb.TabIndex = 10;
            // 
            // Office
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.Controls.Add(this.address_tb);
            this.Controls.Add(this.phone_number_tb);
            this.Controls.Add(this.email_tb);
            this.Controls.Add(this.name_tb);
            this.Controls.Add(this.register_button);
            this.Controls.Add(this.country_code_tb);
            this.Controls.Add(this.id_tb);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Office";
            this.Size = new System.Drawing.Size(472, 494);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox id_tb;
        private System.Windows.Forms.ComboBox country_code_tb;
        private System.Windows.Forms.Button register_button;
        private System.Windows.Forms.TextBox name_tb;
        private System.Windows.Forms.TextBox email_tb;
        private System.Windows.Forms.TextBox phone_number_tb;
        private System.Windows.Forms.TextBox address_tb;
    }
}

