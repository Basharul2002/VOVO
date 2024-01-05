namespace VOVO
{
    partial class CustomerLoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomerLoginForm));
            this.sign_in_panel = new System.Windows.Forms.Panel();
            this.sign_up_btn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.sign_up_panel = new System.Windows.Forms.Panel();
            this.home_page_button = new System.Windows.Forms.Button();
            this.login_picture_box = new System.Windows.Forms.PictureBox();
            this.hide_button = new System.Windows.Forms.Button();
            this.show_button = new System.Windows.Forms.Button();
            this.password_label = new System.Windows.Forms.Label();
            this.customer_id_label = new System.Windows.Forms.Label();
            this.customer_id_tb = new System.Windows.Forms.TextBox();
            this.password_tb = new System.Windows.Forms.TextBox();
            this.sign_in_btn = new System.Windows.Forms.Button();
            this.forgotten_password = new System.Windows.Forms.LinkLabel();
            this.top_border_panel = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.icon = new System.Windows.Forms.PictureBox();
            this.minimize_btn = new System.Windows.Forms.Button();
            this.close_btn = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.sign_in_panel.SuspendLayout();
            this.sign_up_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.login_picture_box)).BeginInit();
            this.top_border_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.icon)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // sign_in_panel
            // 
            this.sign_in_panel.BackColor = System.Drawing.Color.Coral;
            this.sign_in_panel.Controls.Add(this.sign_up_btn);
            this.sign_in_panel.Controls.Add(this.label1);
            this.sign_in_panel.Controls.Add(this.label3);
            this.sign_in_panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sign_in_panel.Location = new System.Drawing.Point(405, 0);
            this.sign_in_panel.Margin = new System.Windows.Forms.Padding(0);
            this.sign_in_panel.Name = "sign_in_panel";
            this.sign_in_panel.Size = new System.Drawing.Size(406, 451);
            this.sign_in_panel.TabIndex = 3;
            // 
            // sign_up_btn
            // 
            this.sign_up_btn.BackColor = System.Drawing.Color.Transparent;
            this.sign_up_btn.FlatAppearance.BorderSize = 3;
            this.sign_up_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sign_up_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sign_up_btn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.sign_up_btn.Location = new System.Drawing.Point(152, 259);
            this.sign_up_btn.Name = "sign_up_btn";
            this.sign_up_btn.Size = new System.Drawing.Size(103, 40);
            this.sign_up_btn.TabIndex = 15;
            this.sign_up_btn.Text = "SIGN UP";
            this.sign_up_btn.UseVisualStyleBackColor = false;
            this.sign_up_btn.Click += new System.EventHandler(this.sign_up_btn_Click);
            this.sign_up_btn.MouseEnter += new System.EventHandler(this.sign_up_btn_MouseEnter);
            this.sign_up_btn.MouseLeave += new System.EventHandler(this.sign_up_btn_MouseLeave);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Franklin Gothic Medium", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(58, 188);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(285, 42);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enter your details and start journey with \r\nus";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(116, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 46);
            this.label3.TabIndex = 0;
            this.label3.Text = "Hello!";
            // 
            // sign_up_panel
            // 
            this.sign_up_panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(209)))), ((int)(((byte)(209)))));
            this.sign_up_panel.Controls.Add(this.home_page_button);
            this.sign_up_panel.Controls.Add(this.login_picture_box);
            this.sign_up_panel.Controls.Add(this.hide_button);
            this.sign_up_panel.Controls.Add(this.show_button);
            this.sign_up_panel.Controls.Add(this.password_label);
            this.sign_up_panel.Controls.Add(this.customer_id_label);
            this.sign_up_panel.Controls.Add(this.customer_id_tb);
            this.sign_up_panel.Controls.Add(this.password_tb);
            this.sign_up_panel.Controls.Add(this.sign_in_btn);
            this.sign_up_panel.Controls.Add(this.forgotten_password);
            this.sign_up_panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sign_up_panel.ForeColor = System.Drawing.Color.Coral;
            this.sign_up_panel.Location = new System.Drawing.Point(0, 0);
            this.sign_up_panel.Margin = new System.Windows.Forms.Padding(0);
            this.sign_up_panel.Name = "sign_up_panel";
            this.sign_up_panel.Size = new System.Drawing.Size(405, 451);
            this.sign_up_panel.TabIndex = 2;
            // 
            // home_page_button
            // 
            this.home_page_button.FlatAppearance.BorderSize = 0;
            this.home_page_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.home_page_button.Image = global::VOVO.Properties.Resources.home;
            this.home_page_button.Location = new System.Drawing.Point(3, 6);
            this.home_page_button.Name = "home_page_button";
            this.home_page_button.Size = new System.Drawing.Size(51, 40);
            this.home_page_button.TabIndex = 19;
            this.home_page_button.UseVisualStyleBackColor = true;
            this.home_page_button.Click += new System.EventHandler(this.home_page_button_Click);
            this.home_page_button.MouseEnter += new System.EventHandler(this.home_page_button_MouseEnter);
            this.home_page_button.MouseLeave += new System.EventHandler(this.home_page_button_MouseLeave);
            // 
            // login_picture_box
            // 
            this.login_picture_box.BackColor = System.Drawing.Color.Coral;
            this.login_picture_box.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.login_picture_box.Image = global::VOVO.Properties.Resources.Still;
            this.login_picture_box.Location = new System.Drawing.Point(121, 57);
            this.login_picture_box.Name = "login_picture_box";
            this.login_picture_box.Size = new System.Drawing.Size(148, 145);
            this.login_picture_box.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.login_picture_box.TabIndex = 18;
            this.login_picture_box.TabStop = false;
            // 
            // hide_button
            // 
            this.hide_button.FlatAppearance.BorderSize = 0;
            this.hide_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.hide_button.Image = global::VOVO.Properties.Resources.hide1;
            this.hide_button.Location = new System.Drawing.Point(344, 318);
            this.hide_button.Name = "hide_button";
            this.hide_button.Size = new System.Drawing.Size(35, 22);
            this.hide_button.TabIndex = 17;
            this.hide_button.UseVisualStyleBackColor = true;
            this.hide_button.Visible = false;
            this.hide_button.Click += new System.EventHandler(this.hide_btn_Click);
            // 
            // show_button
            // 
            this.show_button.FlatAppearance.BorderSize = 0;
            this.show_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.show_button.Image = global::VOVO.Properties.Resources.show;
            this.show_button.Location = new System.Drawing.Point(299, 313);
            this.show_button.Name = "show_button";
            this.show_button.Size = new System.Drawing.Size(35, 22);
            this.show_button.TabIndex = 17;
            this.show_button.UseVisualStyleBackColor = true;
            this.show_button.Click += new System.EventHandler(this.show_btn_Click);
            // 
            // password_label
            // 
            this.password_label.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.password_label.AutoSize = true;
            this.password_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.password_label.ForeColor = System.Drawing.Color.Coral;
            this.password_label.Location = new System.Drawing.Point(57, 295);
            this.password_label.Margin = new System.Windows.Forms.Padding(0);
            this.password_label.Name = "password_label";
            this.password_label.Size = new System.Drawing.Size(78, 20);
            this.password_label.TabIndex = 11;
            this.password_label.Text = "Password";
            this.password_label.Visible = false;
            // 
            // customer_id_label
            // 
            this.customer_id_label.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.customer_id_label.AutoSize = true;
            this.customer_id_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customer_id_label.ForeColor = System.Drawing.Color.Coral;
            this.customer_id_label.Location = new System.Drawing.Point(60, 235);
            this.customer_id_label.Margin = new System.Windows.Forms.Padding(0);
            this.customer_id_label.Name = "customer_id_label";
            this.customer_id_label.Size = new System.Drawing.Size(158, 17);
            this.customer_id_label.TabIndex = 11;
            this.customer_id_label.Text = "Email or Phone Number";
            this.customer_id_label.Visible = false;
            // 
            // customer_id_tb
            // 
            this.customer_id_tb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(209)))), ((int)(((byte)(209)))));
            this.customer_id_tb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.customer_id_tb.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.customer_id_tb.ForeColor = System.Drawing.Color.Gray;
            this.customer_id_tb.Location = new System.Drawing.Point(52, 245);
            this.customer_id_tb.Name = "customer_id_tb";
            this.customer_id_tb.Size = new System.Drawing.Size(286, 30);
            this.customer_id_tb.TabIndex = 16;
            this.customer_id_tb.Text = "Email or Phone Number";
            this.customer_id_tb.Enter += new System.EventHandler(this.customer_id_tb_Enter);
            this.customer_id_tb.Leave += new System.EventHandler(this.customer_id_tb_Leave);
            // 
            // password_tb
            // 
            this.password_tb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(209)))), ((int)(((byte)(209)))));
            this.password_tb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.password_tb.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.password_tb.ForeColor = System.Drawing.Color.Gray;
            this.password_tb.Location = new System.Drawing.Point(52, 311);
            this.password_tb.Name = "password_tb";
            this.password_tb.Size = new System.Drawing.Size(286, 30);
            this.password_tb.TabIndex = 16;
            this.password_tb.Text = "Password";
            this.password_tb.TextChanged += new System.EventHandler(this.password_tb_TextChanged);
            this.password_tb.Enter += new System.EventHandler(this.password_tb_Enter);
            this.password_tb.Leave += new System.EventHandler(this.password_tb_Leave);
            // 
            // sign_in_btn
            // 
            this.sign_in_btn.BackColor = System.Drawing.Color.Transparent;
            this.sign_in_btn.FlatAppearance.BorderSize = 5;
            this.sign_in_btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.sign_in_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sign_in_btn.Location = new System.Drawing.Point(134, 392);
            this.sign_in_btn.Name = "sign_in_btn";
            this.sign_in_btn.Size = new System.Drawing.Size(103, 40);
            this.sign_in_btn.TabIndex = 14;
            this.sign_in_btn.Text = "Sign In";
            this.sign_in_btn.UseVisualStyleBackColor = false;
            this.sign_in_btn.Click += new System.EventHandler(this.sign_in_btn_Click);
            this.sign_in_btn.MouseEnter += new System.EventHandler(this.sign_in_btn_MouseEnter);
            this.sign_in_btn.MouseLeave += new System.EventHandler(this.sign_in_btn_MouseLeave);
            // 
            // forgotten_password
            // 
            this.forgotten_password.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(209)))), ((int)(((byte)(209)))));
            this.forgotten_password.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.forgotten_password.AutoSize = true;
            this.forgotten_password.Cursor = System.Windows.Forms.Cursors.Hand;
            this.forgotten_password.DisabledLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(209)))), ((int)(((byte)(209)))));
            this.forgotten_password.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.3F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.forgotten_password.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(209)))), ((int)(((byte)(209)))));
            this.forgotten_password.LinkColor = System.Drawing.Color.Coral;
            this.forgotten_password.Location = new System.Drawing.Point(205, 349);
            this.forgotten_password.Name = "forgotten_password";
            this.forgotten_password.Size = new System.Drawing.Size(127, 16);
            this.forgotten_password.TabIndex = 3;
            this.forgotten_password.TabStop = true;
            this.forgotten_password.Text = "Forgotten Password";
            this.forgotten_password.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.forgotten_password.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(209)))), ((int)(((byte)(209)))));
            this.forgotten_password.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.forgotten_password_LinkClicked);
            // 
            // top_border_panel
            // 
            this.top_border_panel.BackColor = System.Drawing.Color.Coral;
            this.top_border_panel.Controls.Add(this.label2);
            this.top_border_panel.Controls.Add(this.icon);
            this.top_border_panel.Controls.Add(this.minimize_btn);
            this.top_border_panel.Controls.Add(this.close_btn);
            this.top_border_panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.top_border_panel.Location = new System.Drawing.Point(0, 0);
            this.top_border_panel.Name = "top_border_panel";
            this.top_border_panel.Size = new System.Drawing.Size(811, 37);
            this.top_border_panel.TabIndex = 0;
            this.top_border_panel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.border_panel_MouseDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(38, 0);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.label2.Size = new System.Drawing.Size(66, 30);
            this.label2.TabIndex = 2;
            this.label2.Text = "VOVO";
            // 
            // icon
            // 
            this.icon.Dock = System.Windows.Forms.DockStyle.Left;
            this.icon.Image = global::VOVO.Properties.Resources.Icon;
            this.icon.Location = new System.Drawing.Point(0, 0);
            this.icon.Name = "icon";
            this.icon.Size = new System.Drawing.Size(38, 37);
            this.icon.TabIndex = 1;
            this.icon.TabStop = false;
            // 
            // minimize_btn
            // 
            this.minimize_btn.BackColor = System.Drawing.Color.Transparent;
            this.minimize_btn.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.minimize_btn.Dock = System.Windows.Forms.DockStyle.Right;
            this.minimize_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.minimize_btn.ForeColor = System.Drawing.Color.Maroon;
            this.minimize_btn.Image = global::VOVO.Properties.Resources.minimize_sign;
            this.minimize_btn.Location = new System.Drawing.Point(703, 0);
            this.minimize_btn.Name = "minimize_btn";
            this.minimize_btn.Size = new System.Drawing.Size(50, 37);
            this.minimize_btn.TabIndex = 1;
            this.minimize_btn.UseVisualStyleBackColor = false;
            this.minimize_btn.Click += new System.EventHandler(this.minimize_btn_Click);
            // 
            // close_btn
            // 
            this.close_btn.BackColor = System.Drawing.Color.Transparent;
            this.close_btn.Dock = System.Windows.Forms.DockStyle.Right;
            this.close_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.close_btn.ForeColor = System.Drawing.Color.Maroon;
            this.close_btn.Image = global::VOVO.Properties.Resources.reject;
            this.close_btn.Location = new System.Drawing.Point(753, 0);
            this.close_btn.Name = "close_btn";
            this.close_btn.Size = new System.Drawing.Size(58, 37);
            this.close_btn.TabIndex = 1;
            this.close_btn.UseVisualStyleBackColor = false;
            this.close_btn.Click += new System.EventHandler(this.close_btn_Click);
            this.close_btn.MouseEnter += new System.EventHandler(this.close_btn_MouseEnter);
            this.close_btn.MouseLeave += new System.EventHandler(this.close_btn_MouseLeave);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.sign_in_panel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.sign_up_panel, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 37);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(811, 451);
            this.tableLayoutPanel1.TabIndex = 14;
            // 
            // CustomerLoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(811, 488);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.top_border_panel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CustomerLoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CustomerLoginFormcs";
            this.Load += new System.EventHandler(this.CustomerLoginForm_Load);
            this.SizeChanged += new System.EventHandler(this.CustomerLoginForm_SizeChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CustomerLoginForm_KeyDown);
            this.sign_in_panel.ResumeLayout(false);
            this.sign_in_panel.PerformLayout();
            this.sign_up_panel.ResumeLayout(false);
            this.sign_up_panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.login_picture_box)).EndInit();
            this.top_border_panel.ResumeLayout(false);
            this.top_border_panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.icon)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel top_border_panel;
        private System.Windows.Forms.Button minimize_btn;
        private System.Windows.Forms.Button close_btn;
        private System.Windows.Forms.PictureBox icon;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel sign_up_panel;
        private System.Windows.Forms.LinkLabel forgotten_password;
        private System.Windows.Forms.Label customer_id_label;
        private System.Windows.Forms.Label password_label;
        private System.Windows.Forms.Panel sign_in_panel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button sign_in_btn;
        private System.Windows.Forms.Button sign_up_btn;
        private System.Windows.Forms.TextBox password_tb;
        private System.Windows.Forms.TextBox customer_id_tb;
        private System.Windows.Forms.Button show_button;
        private System.Windows.Forms.Button hide_button;
        private System.Windows.Forms.PictureBox login_picture_box;
        private System.Windows.Forms.Button home_page_button;
    }
}