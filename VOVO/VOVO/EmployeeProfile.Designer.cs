namespace VOVO
{
    partial class EmployeeProfile
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.licences_number = new System.Windows.Forms.Label();
            this.personal_Info_panel = new System.Windows.Forms.Panel();
            this.change_pasword_button = new System.Windows.Forms.Button();
            this.picture = new System.Windows.Forms.PictureBox();
            this.nationality = new System.Windows.Forms.Label();
            this.gender = new System.Windows.Forms.Label();
            this.phonenumber = new System.Windows.Forms.Label();
            this.email = new System.Windows.Forms.Label();
            this.dob = new System.Windows.Forms.Label();
            this.id = new System.Windows.Forms.Label();
            this.name = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.personal_Info_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picture)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.Color.RosyBrown;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.personal_Info_panel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(551, 462);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.licences_number);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 355);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(551, 105);
            this.panel2.TabIndex = 3;
            this.panel2.Visible = false;
            // 
            // licences_number
            // 
            this.licences_number.AutoSize = true;
            this.licences_number.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.licences_number.Location = new System.Drawing.Point(56, 22);
            this.licences_number.Name = "licences_number";
            this.licences_number.Size = new System.Drawing.Size(149, 22);
            this.licences_number.TabIndex = 0;
            this.licences_number.Text = "Licences Number";
            // 
            // personal_Info_panel
            // 
            this.personal_Info_panel.Controls.Add(this.change_pasword_button);
            this.personal_Info_panel.Controls.Add(this.picture);
            this.personal_Info_panel.Controls.Add(this.nationality);
            this.personal_Info_panel.Controls.Add(this.gender);
            this.personal_Info_panel.Controls.Add(this.phonenumber);
            this.personal_Info_panel.Controls.Add(this.email);
            this.personal_Info_panel.Controls.Add(this.dob);
            this.personal_Info_panel.Controls.Add(this.id);
            this.personal_Info_panel.Controls.Add(this.name);
            this.personal_Info_panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.personal_Info_panel.Location = new System.Drawing.Point(0, 0);
            this.personal_Info_panel.Name = "personal_Info_panel";
            this.personal_Info_panel.Size = new System.Drawing.Size(551, 355);
            this.personal_Info_panel.TabIndex = 2;
            // 
            // change_pasword_button
            // 
            this.change_pasword_button.FlatAppearance.BorderSize = 3;
            this.change_pasword_button.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Blue;
            this.change_pasword_button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.change_pasword_button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.change_pasword_button.Location = new System.Drawing.Point(177, 121);
            this.change_pasword_button.Name = "change_pasword_button";
            this.change_pasword_button.Size = new System.Drawing.Size(116, 23);
            this.change_pasword_button.TabIndex = 3;
            this.change_pasword_button.Text = "Change Password";
            this.change_pasword_button.UseVisualStyleBackColor = true;
            this.change_pasword_button.Click += new System.EventHandler(this.change_pasword_button_Click);
            // 
            // picture
            // 
            this.picture.Location = new System.Drawing.Point(60, 40);
            this.picture.Name = "picture";
            this.picture.Size = new System.Drawing.Size(106, 106);
            this.picture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picture.TabIndex = 2;
            this.picture.TabStop = false;
            // 
            // nationality
            // 
            this.nationality.AutoSize = true;
            this.nationality.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nationality.Location = new System.Drawing.Point(56, 323);
            this.nationality.Name = "nationality";
            this.nationality.Size = new System.Drawing.Size(94, 22);
            this.nationality.TabIndex = 0;
            this.nationality.Text = "Nationality";
            // 
            // gender
            // 
            this.gender.AutoSize = true;
            this.gender.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gender.Location = new System.Drawing.Point(56, 289);
            this.gender.Name = "gender";
            this.gender.Size = new System.Drawing.Size(75, 22);
            this.gender.TabIndex = 0;
            this.gender.Text = "Gender:";
            // 
            // phonenumber
            // 
            this.phonenumber.AutoSize = true;
            this.phonenumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phonenumber.Location = new System.Drawing.Point(56, 247);
            this.phonenumber.Name = "phonenumber";
            this.phonenumber.Size = new System.Drawing.Size(130, 22);
            this.phonenumber.TabIndex = 0;
            this.phonenumber.Text = "Phone Number";
            // 
            // email
            // 
            this.email.AutoSize = true;
            this.email.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.email.Location = new System.Drawing.Point(56, 211);
            this.email.Name = "email";
            this.email.Size = new System.Drawing.Size(59, 22);
            this.email.TabIndex = 0;
            this.email.Text = "Email:";
            // 
            // dob
            // 
            this.dob.AutoSize = true;
            this.dob.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dob.Location = new System.Drawing.Point(56, 171);
            this.dob.Name = "dob";
            this.dob.Size = new System.Drawing.Size(214, 22);
            this.dob.TabIndex = 0;
            this.dob.Text = "Date Of Birth: 06/01/2000";
            // 
            // id
            // 
            this.id.AutoSize = true;
            this.id.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.id.Location = new System.Drawing.Point(172, 95);
            this.id.Name = "id";
            this.id.Size = new System.Drawing.Size(168, 22);
            this.id.TabIndex = 0;
            this.id.Text = "ID: ADM-2300001-1";
            // 
            // name
            // 
            this.name.AutoSize = true;
            this.name.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.name.Location = new System.Drawing.Point(172, 64);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(221, 25);
            this.name.TabIndex = 0;
            this.name.Text = "Name: Basharul Alam";
            // 
            // EmployeeProfile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "EmployeeProfile";
            this.Size = new System.Drawing.Size(551, 462);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.personal_Info_panel.ResumeLayout(false);
            this.personal_Info_panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picture)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label gender;
        private System.Windows.Forms.Label phonenumber;
        private System.Windows.Forms.Label email;
        private System.Windows.Forms.Label dob;
        private System.Windows.Forms.Label id;
        private System.Windows.Forms.Label name;
        private System.Windows.Forms.Label nationality;
        private System.Windows.Forms.Panel personal_Info_panel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label licences_number;
        private System.Windows.Forms.PictureBox picture;
        private System.Windows.Forms.Button change_pasword_button;
    }
}
