namespace VOVO
{
    partial class CustomerRegistrationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomerRegistrationForm));
            this.top_border_panel = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.icon = new System.Windows.Forms.PictureBox();
            this.minimize_btn = new System.Windows.Forms.Button();
            this.maximized_btn = new System.Windows.Forms.Button();
            this.maximize_btn = new System.Windows.Forms.Button();
            this.close_btn = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.previous_form_btn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel = new System.Windows.Forms.Panel();
            this.not_say_radio_button = new System.Windows.Forms.RadioButton();
            this.others_radio_button = new System.Windows.Forms.RadioButton();
            this.female_radio_button = new System.Windows.Forms.RadioButton();
            this.male_radio_Button = new System.Windows.Forms.RadioButton();
            this.gender_panel = new System.Windows.Forms.Panel();
            this.country_code = new System.Windows.Forms.ComboBox();
            this.pass_hide_btn = new System.Windows.Forms.Button();
            this.con_pass_hide_btn = new System.Windows.Forms.Button();
            this.con_pass_show_btn = new System.Windows.Forms.Button();
            this.pass_show_btn = new System.Windows.Forms.Button();
            this.clear_btn = new System.Windows.Forms.Button();
            this.create_account_btn = new System.Windows.Forms.Button();
            this.pass_tb = new System.Windows.Forms.TextBox();
            this.con_pass_tb = new System.Windows.Forms.TextBox();
            this.phn_num_tb = new System.Windows.Forms.TextBox();
            this.email_tb = new System.Windows.Forms.TextBox();
            this.customer_id_tb = new System.Windows.Forms.TextBox();
            this.name_tb = new System.Windows.Forms.TextBox();
            this.title = new System.Windows.Forms.Label();
            this.phone_number = new System.Windows.Forms.Label();
            this.confirm_pass = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.password = new System.Windows.Forms.Label();
            this.email = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.name = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.top_border_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.icon)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // top_border_panel
            // 
            this.top_border_panel.BackColor = System.Drawing.Color.Coral;
            this.top_border_panel.Controls.Add(this.label5);
            this.top_border_panel.Controls.Add(this.icon);
            this.top_border_panel.Controls.Add(this.minimize_btn);
            this.top_border_panel.Controls.Add(this.maximized_btn);
            this.top_border_panel.Controls.Add(this.maximize_btn);
            this.top_border_panel.Controls.Add(this.close_btn);
            this.top_border_panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.top_border_panel.Location = new System.Drawing.Point(0, 0);
            this.top_border_panel.Name = "top_border_panel";
            this.top_border_panel.Size = new System.Drawing.Size(800, 40);
            this.top_border_panel.TabIndex = 0;
            this.top_border_panel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.top_border_panel_MouseDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Dock = System.Windows.Forms.DockStyle.Left;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(45, 0);
            this.label5.Name = "label5";
            this.label5.Padding = new System.Windows.Forms.Padding(0, 9, 0, 0);
            this.label5.Size = new System.Drawing.Size(59, 29);
            this.label5.TabIndex = 4;
            this.label5.Text = "VOVO";
            // 
            // icon
            // 
            this.icon.Dock = System.Windows.Forms.DockStyle.Left;
            this.icon.Location = new System.Drawing.Point(0, 0);
            this.icon.Name = "icon";
            this.icon.Size = new System.Drawing.Size(45, 40);
            this.icon.TabIndex = 3;
            this.icon.TabStop = false;
            // 
            // minimize_btn
            // 
            this.minimize_btn.AutoSize = true;
            this.minimize_btn.BackColor = System.Drawing.Color.Transparent;
            this.minimize_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.minimize_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.minimize_btn.Dock = System.Windows.Forms.DockStyle.Right;
            this.minimize_btn.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.minimize_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.minimize_btn.ForeColor = System.Drawing.Color.Coral;
            this.minimize_btn.Image = global::VOVO.Properties.Resources.minimize_sign;
            this.minimize_btn.Location = new System.Drawing.Point(544, 0);
            this.minimize_btn.Name = "minimize_btn";
            this.minimize_btn.Size = new System.Drawing.Size(64, 40);
            this.minimize_btn.TabIndex = 0;
            this.minimize_btn.UseVisualStyleBackColor = false;
            this.minimize_btn.Click += new System.EventHandler(this.minimize_btn_Click);
            this.minimize_btn.MouseEnter += new System.EventHandler(this.minimize_btn_MouseEnter);
            this.minimize_btn.MouseLeave += new System.EventHandler(this.minimize_btn_MouseLeave);
            // 
            // maximized_btn
            // 
            this.maximized_btn.AutoSize = true;
            this.maximized_btn.BackColor = System.Drawing.Color.Transparent;
            this.maximized_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.maximized_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.maximized_btn.Dock = System.Windows.Forms.DockStyle.Right;
            this.maximized_btn.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.maximized_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.maximized_btn.ForeColor = System.Drawing.Color.Coral;
            this.maximized_btn.Image = global::VOVO.Properties.Resources.squares;
            this.maximized_btn.Location = new System.Drawing.Point(608, 0);
            this.maximized_btn.Name = "maximized_btn";
            this.maximized_btn.Size = new System.Drawing.Size(64, 40);
            this.maximized_btn.TabIndex = 0;
            this.maximized_btn.UseVisualStyleBackColor = false;
            this.maximized_btn.Visible = false;
            this.maximized_btn.Click += new System.EventHandler(this.maximized_btn_Click);
            this.maximized_btn.MouseEnter += new System.EventHandler(this.maximized_btn_MouseEnter);
            this.maximized_btn.MouseLeave += new System.EventHandler(this.maximized_btn_MouseLeave);
            // 
            // maximize_btn
            // 
            this.maximize_btn.AutoSize = true;
            this.maximize_btn.BackColor = System.Drawing.Color.Transparent;
            this.maximize_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.maximize_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.maximize_btn.Dock = System.Windows.Forms.DockStyle.Right;
            this.maximize_btn.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.maximize_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.maximize_btn.ForeColor = System.Drawing.Color.Coral;
            this.maximize_btn.Image = global::VOVO.Properties.Resources.maximize;
            this.maximize_btn.Location = new System.Drawing.Point(672, 0);
            this.maximize_btn.Name = "maximize_btn";
            this.maximize_btn.Size = new System.Drawing.Size(64, 40);
            this.maximize_btn.TabIndex = 0;
            this.maximize_btn.UseVisualStyleBackColor = false;
            this.maximize_btn.Click += new System.EventHandler(this.maximize_btn_Click);
            this.maximize_btn.MouseEnter += new System.EventHandler(this.maximize_btn_MouseEnter);
            this.maximize_btn.MouseLeave += new System.EventHandler(this.maximize_btn_MouseLeave);
            // 
            // close_btn
            // 
            this.close_btn.AutoSize = true;
            this.close_btn.BackColor = System.Drawing.Color.Transparent;
            this.close_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.close_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.close_btn.Dock = System.Windows.Forms.DockStyle.Right;
            this.close_btn.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.close_btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.close_btn.Image = global::VOVO.Properties.Resources.reject;
            this.close_btn.Location = new System.Drawing.Point(736, 0);
            this.close_btn.Name = "close_btn";
            this.close_btn.Size = new System.Drawing.Size(64, 40);
            this.close_btn.TabIndex = 0;
            this.close_btn.UseVisualStyleBackColor = false;
            this.close_btn.Click += new System.EventHandler(this.close_btn_Click);
            this.close_btn.MouseEnter += new System.EventHandler(this.close_btn_MouseEnter);
            this.close_btn.MouseLeave += new System.EventHandler(this.close_btn_MouseLeave);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Coral;
            this.panel2.Controls.Add(this.previous_form_btn);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(280, 403);
            this.panel2.TabIndex = 1;
            // 
            // previous_form_btn
            // 
            this.previous_form_btn.BackColor = System.Drawing.Color.Coral;
            this.previous_form_btn.FlatAppearance.BorderSize = 0;
            this.previous_form_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.previous_form_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.previous_form_btn.ForeColor = System.Drawing.Color.Coral;
            this.previous_form_btn.Image = global::VOVO.Properties.Resources.Previous__small_;
            this.previous_form_btn.Location = new System.Drawing.Point(5, 0);
            this.previous_form_btn.Name = "previous_form_btn";
            this.previous_form_btn.Size = new System.Drawing.Size(37, 35);
            this.previous_form_btn.TabIndex = 2;
            this.previous_form_btn.UseVisualStyleBackColor = false;
            this.previous_form_btn.Click += new System.EventHandler(this.previous_btn_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.4F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Location = new System.Drawing.Point(-1, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(281, 80);
            this.label1.TabIndex = 0;
            this.label1.Text = "We\'re thrilled to have you join our \r\nBus Ticket Management System family! \r\nCrea" +
    "ting your account is the first step \r\ntowards effortless and convenient \r\nbus tr" +
    "avel.";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel
            // 
            this.panel.BackColor = System.Drawing.Color.White;
            this.panel.Controls.Add(this.not_say_radio_button);
            this.panel.Controls.Add(this.others_radio_button);
            this.panel.Controls.Add(this.female_radio_button);
            this.panel.Controls.Add(this.male_radio_Button);
            this.panel.Controls.Add(this.gender_panel);
            this.panel.Controls.Add(this.country_code);
            this.panel.Controls.Add(this.pass_hide_btn);
            this.panel.Controls.Add(this.con_pass_hide_btn);
            this.panel.Controls.Add(this.con_pass_show_btn);
            this.panel.Controls.Add(this.pass_show_btn);
            this.panel.Controls.Add(this.clear_btn);
            this.panel.Controls.Add(this.create_account_btn);
            this.panel.Controls.Add(this.pass_tb);
            this.panel.Controls.Add(this.con_pass_tb);
            this.panel.Controls.Add(this.phn_num_tb);
            this.panel.Controls.Add(this.email_tb);
            this.panel.Controls.Add(this.customer_id_tb);
            this.panel.Controls.Add(this.name_tb);
            this.panel.Controls.Add(this.title);
            this.panel.Controls.Add(this.phone_number);
            this.panel.Controls.Add(this.confirm_pass);
            this.panel.Controls.Add(this.label3);
            this.panel.Controls.Add(this.password);
            this.panel.Controls.Add(this.email);
            this.panel.Controls.Add(this.label2);
            this.panel.Controls.Add(this.name);
            this.panel.Location = new System.Drawing.Point(289, 3);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(508, 403);
            this.panel.TabIndex = 0;
            // 
            // not_say_radio_button
            // 
            this.not_say_radio_button.AutoSize = true;
            this.not_say_radio_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.not_say_radio_button.ForeColor = System.Drawing.Color.Coral;
            this.not_say_radio_button.Location = new System.Drawing.Point(408, 219);
            this.not_say_radio_button.Name = "not_say_radio_button";
            this.not_say_radio_button.Size = new System.Drawing.Size(76, 21);
            this.not_say_radio_button.TabIndex = 3;
            this.not_say_radio_button.TabStop = true;
            this.not_say_radio_button.Text = "Not Say";
            this.not_say_radio_button.UseVisualStyleBackColor = true;
            // 
            // others_radio_button
            // 
            this.others_radio_button.AutoSize = true;
            this.others_radio_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.others_radio_button.ForeColor = System.Drawing.Color.Coral;
            this.others_radio_button.Location = new System.Drawing.Point(333, 218);
            this.others_radio_button.Name = "others_radio_button";
            this.others_radio_button.Size = new System.Drawing.Size(69, 21);
            this.others_radio_button.TabIndex = 3;
            this.others_radio_button.TabStop = true;
            this.others_radio_button.Text = "Others";
            this.others_radio_button.UseVisualStyleBackColor = true;
            // 
            // female_radio_button
            // 
            this.female_radio_button.AutoSize = true;
            this.female_radio_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.female_radio_button.ForeColor = System.Drawing.Color.Coral;
            this.female_radio_button.Location = new System.Drawing.Point(255, 217);
            this.female_radio_button.Name = "female_radio_button";
            this.female_radio_button.Size = new System.Drawing.Size(72, 21);
            this.female_radio_button.TabIndex = 3;
            this.female_radio_button.TabStop = true;
            this.female_radio_button.Text = "Female";
            this.female_radio_button.UseVisualStyleBackColor = true;
            // 
            // male_radio_Button
            // 
            this.male_radio_Button.AutoSize = true;
            this.male_radio_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.male_radio_Button.ForeColor = System.Drawing.Color.Coral;
            this.male_radio_Button.Location = new System.Drawing.Point(193, 217);
            this.male_radio_Button.Name = "male_radio_Button";
            this.male_radio_Button.Size = new System.Drawing.Size(56, 21);
            this.male_radio_Button.TabIndex = 3;
            this.male_radio_Button.TabStop = true;
            this.male_radio_Button.Text = "Male";
            this.male_radio_Button.UseVisualStyleBackColor = true;
            // 
            // gender_panel
            // 
            this.gender_panel.Location = new System.Drawing.Point(181, 217);
            this.gender_panel.Name = "gender_panel";
            this.gender_panel.Size = new System.Drawing.Size(297, 27);
            this.gender_panel.TabIndex = 4;
            // 
            // country_code
            // 
            this.country_code.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.country_code.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.country_code.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.country_code.FormattingEnabled = true;
            this.country_code.Items.AddRange(new object[] {
            "+880(BAN)"});
            this.country_code.Location = new System.Drawing.Point(193, 173);
            this.country_code.Name = "country_code";
            this.country_code.Size = new System.Drawing.Size(82, 24);
            this.country_code.TabIndex = 3;
            this.country_code.TabStop = false;
            this.country_code.Text = "Choose";
            // 
            // pass_hide_btn
            // 
            this.pass_hide_btn.BackColor = System.Drawing.Color.White;
            this.pass_hide_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pass_hide_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.pass_hide_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pass_hide_btn.ForeColor = System.Drawing.Color.Coral;
            this.pass_hide_btn.Image = global::VOVO.Properties.Resources.hide__small_;
            this.pass_hide_btn.Location = new System.Drawing.Point(450, 239);
            this.pass_hide_btn.Name = "pass_hide_btn";
            this.pass_hide_btn.Size = new System.Drawing.Size(28, 20);
            this.pass_hide_btn.TabIndex = 2;
            this.pass_hide_btn.UseVisualStyleBackColor = false;
            this.pass_hide_btn.Visible = false;
            this.pass_hide_btn.Click += new System.EventHandler(this.pass_hide_btn_Click);
            // 
            // con_pass_hide_btn
            // 
            this.con_pass_hide_btn.BackColor = System.Drawing.Color.White;
            this.con_pass_hide_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.con_pass_hide_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.con_pass_hide_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.con_pass_hide_btn.ForeColor = System.Drawing.Color.Coral;
            this.con_pass_hide_btn.Image = global::VOVO.Properties.Resources.hide__small_;
            this.con_pass_hide_btn.Location = new System.Drawing.Point(452, 273);
            this.con_pass_hide_btn.Name = "con_pass_hide_btn";
            this.con_pass_hide_btn.Size = new System.Drawing.Size(28, 20);
            this.con_pass_hide_btn.TabIndex = 2;
            this.con_pass_hide_btn.UseVisualStyleBackColor = false;
            this.con_pass_hide_btn.Visible = false;
            this.con_pass_hide_btn.Click += new System.EventHandler(this.con_pass_hide_btn_Click);
            // 
            // con_pass_show_btn
            // 
            this.con_pass_show_btn.BackColor = System.Drawing.Color.White;
            this.con_pass_show_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.con_pass_show_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.con_pass_show_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.con_pass_show_btn.ForeColor = System.Drawing.Color.Coral;
            this.con_pass_show_btn.Image = global::VOVO.Properties.Resources.show__small_;
            this.con_pass_show_btn.Location = new System.Drawing.Point(416, 287);
            this.con_pass_show_btn.Name = "con_pass_show_btn";
            this.con_pass_show_btn.Size = new System.Drawing.Size(28, 20);
            this.con_pass_show_btn.TabIndex = 2;
            this.con_pass_show_btn.UseVisualStyleBackColor = false;
            this.con_pass_show_btn.Click += new System.EventHandler(this.con_pass_show_btn_Click);
            // 
            // pass_show_btn
            // 
            this.pass_show_btn.BackColor = System.Drawing.Color.White;
            this.pass_show_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pass_show_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pass_show_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.pass_show_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pass_show_btn.ForeColor = System.Drawing.Color.Coral;
            this.pass_show_btn.Image = global::VOVO.Properties.Resources.show__small_;
            this.pass_show_btn.Location = new System.Drawing.Point(416, 250);
            this.pass_show_btn.Name = "pass_show_btn";
            this.pass_show_btn.Size = new System.Drawing.Size(28, 20);
            this.pass_show_btn.TabIndex = 2;
            this.pass_show_btn.UseVisualStyleBackColor = false;
            this.pass_show_btn.Click += new System.EventHandler(this.pass_show_btn_Click);
            // 
            // clear_btn
            // 
            this.clear_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clear_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clear_btn.ForeColor = System.Drawing.Color.Coral;
            this.clear_btn.Location = new System.Drawing.Point(137, 334);
            this.clear_btn.Name = "clear_btn";
            this.clear_btn.Size = new System.Drawing.Size(72, 49);
            this.clear_btn.TabIndex = 2;
            this.clear_btn.Text = "Clear";
            this.clear_btn.UseVisualStyleBackColor = true;
            this.clear_btn.Click += new System.EventHandler(this.clear_btn_Click);
            // 
            // create_account_btn
            // 
            this.create_account_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.create_account_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.create_account_btn.ForeColor = System.Drawing.Color.Coral;
            this.create_account_btn.Location = new System.Drawing.Point(255, 334);
            this.create_account_btn.Name = "create_account_btn";
            this.create_account_btn.Size = new System.Drawing.Size(72, 49);
            this.create_account_btn.TabIndex = 2;
            this.create_account_btn.Text = "Create Account";
            this.create_account_btn.UseVisualStyleBackColor = true;
            this.create_account_btn.Click += new System.EventHandler(this.create_account_btn_Click);
            // 
            // pass_tb
            // 
            this.pass_tb.BackColor = System.Drawing.SystemColors.Control;
            this.pass_tb.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pass_tb.Location = new System.Drawing.Point(193, 250);
            this.pass_tb.Name = "pass_tb";
            this.pass_tb.Size = new System.Drawing.Size(225, 20);
            this.pass_tb.TabIndex = 1;
            this.pass_tb.UseSystemPasswordChar = true;
            // 
            // con_pass_tb
            // 
            this.con_pass_tb.BackColor = System.Drawing.SystemColors.Control;
            this.con_pass_tb.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.con_pass_tb.Location = new System.Drawing.Point(193, 287);
            this.con_pass_tb.Name = "con_pass_tb";
            this.con_pass_tb.Size = new System.Drawing.Size(225, 20);
            this.con_pass_tb.TabIndex = 1;
            this.con_pass_tb.UseSystemPasswordChar = true;
            // 
            // phn_num_tb
            // 
            this.phn_num_tb.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phn_num_tb.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.phn_num_tb.Location = new System.Drawing.Point(274, 174);
            this.phn_num_tb.MaxLength = 10;
            this.phn_num_tb.Name = "phn_num_tb";
            this.phn_num_tb.Size = new System.Drawing.Size(170, 23);
            this.phn_num_tb.TabIndex = 1;
            this.phn_num_tb.Text = "xxxxxxxxxx";
            this.phn_num_tb.Enter += new System.EventHandler(this.phn_num_tb_Enter);
            this.phn_num_tb.Leave += new System.EventHandler(this.phn_num_tb_Leave);
            // 
            // email_tb
            // 
            this.email_tb.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.email_tb.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.email_tb.Location = new System.Drawing.Point(193, 137);
            this.email_tb.Name = "email_tb";
            this.email_tb.Size = new System.Drawing.Size(251, 23);
            this.email_tb.TabIndex = 1;
            this.email_tb.Text = "email@gmail.com";
            this.email_tb.Enter += new System.EventHandler(this.email_tb_Enter);
            this.email_tb.Leave += new System.EventHandler(this.email_tb_Leave);
            // 
            // customer_id_tb
            // 
            this.customer_id_tb.AllowDrop = true;
            this.customer_id_tb.BackColor = System.Drawing.Color.White;
            this.customer_id_tb.Enabled = false;
            this.customer_id_tb.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customer_id_tb.ForeColor = System.Drawing.Color.Coral;
            this.customer_id_tb.Location = new System.Drawing.Point(193, 59);
            this.customer_id_tb.MaxLength = 10;
            this.customer_id_tb.Name = "customer_id_tb";
            this.customer_id_tb.Size = new System.Drawing.Size(251, 23);
            this.customer_id_tb.TabIndex = 1;
            this.customer_id_tb.Leave += new System.EventHandler(this.name_tb_Leave);
            // 
            // name_tb
            // 
            this.name_tb.BackColor = System.Drawing.Color.White;
            this.name_tb.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.name_tb.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.name_tb.Location = new System.Drawing.Point(193, 101);
            this.name_tb.Name = "name_tb";
            this.name_tb.Size = new System.Drawing.Size(251, 23);
            this.name_tb.TabIndex = 1;
            this.name_tb.Text = "Vovo";
            this.name_tb.Enter += new System.EventHandler(this.name_tb_Enter);
            this.name_tb.Leave += new System.EventHandler(this.name_tb_Leave);
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.BackColor = System.Drawing.Color.Transparent;
            this.title.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title.ForeColor = System.Drawing.Color.Coral;
            this.title.Location = new System.Drawing.Point(176, 9);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(222, 29);
            this.title.TabIndex = 0;
            this.title.Text = "Registration Form";
            // 
            // phone_number
            // 
            this.phone_number.AutoSize = true;
            this.phone_number.BackColor = System.Drawing.Color.Transparent;
            this.phone_number.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phone_number.ForeColor = System.Drawing.Color.Coral;
            this.phone_number.Location = new System.Drawing.Point(42, 178);
            this.phone_number.Name = "phone_number";
            this.phone_number.Size = new System.Drawing.Size(115, 20);
            this.phone_number.TabIndex = 0;
            this.phone_number.Text = "Phone Number";
            // 
            // confirm_pass
            // 
            this.confirm_pass.AutoSize = true;
            this.confirm_pass.BackColor = System.Drawing.Color.Transparent;
            this.confirm_pass.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.confirm_pass.ForeColor = System.Drawing.Color.Coral;
            this.confirm_pass.Location = new System.Drawing.Point(42, 287);
            this.confirm_pass.Name = "confirm_pass";
            this.confirm_pass.Size = new System.Drawing.Size(132, 20);
            this.confirm_pass.TabIndex = 0;
            this.confirm_pass.Text = "Confim Password";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Coral;
            this.label3.Location = new System.Drawing.Point(48, 218);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Gender";
            // 
            // password
            // 
            this.password.AutoSize = true;
            this.password.BackColor = System.Drawing.Color.Transparent;
            this.password.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.password.ForeColor = System.Drawing.Color.Coral;
            this.password.Location = new System.Drawing.Point(48, 250);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(78, 20);
            this.password.TabIndex = 0;
            this.password.Text = "Password";
            // 
            // email
            // 
            this.email.AutoSize = true;
            this.email.BackColor = System.Drawing.Color.Transparent;
            this.email.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.email.ForeColor = System.Drawing.Color.Coral;
            this.email.Location = new System.Drawing.Point(48, 140);
            this.email.Name = "email";
            this.email.Size = new System.Drawing.Size(48, 20);
            this.email.TabIndex = 0;
            this.email.Text = "Email";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Coral;
            this.label2.Location = new System.Drawing.Point(45, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Customer ID";
            // 
            // name
            // 
            this.name.AutoSize = true;
            this.name.BackColor = System.Drawing.Color.Transparent;
            this.name.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.name.ForeColor = System.Drawing.Color.Coral;
            this.name.Location = new System.Drawing.Point(48, 101);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(51, 20);
            this.name.TabIndex = 0;
            this.name.Text = "Name";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.75F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 64.25F));
            this.tableLayoutPanel1.Controls.Add(this.panel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 40);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 409);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // CustomerRegistrationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 449);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.top_border_panel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CustomerRegistrationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CustomerRegistrationForm";
            this.Load += new System.EventHandler(this.CustomerRegistrationForm_Load);
            this.SizeChanged += new System.EventHandler(this.CustomerRegistrationForm_SizeChanged);
            this.top_border_panel.ResumeLayout(false);
            this.top_border_panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.icon)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel top_border_panel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button maximized_btn;
        private System.Windows.Forms.Button minimize_btn;
        private System.Windows.Forms.Button maximize_btn;
        private System.Windows.Forms.Button close_btn;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Label name;
        private System.Windows.Forms.Label title;
        private System.Windows.Forms.Label phone_number;
        private System.Windows.Forms.Label password;
        private System.Windows.Forms.Label email;
        private System.Windows.Forms.Label confirm_pass;
        private System.Windows.Forms.TextBox con_pass_tb;
        private System.Windows.Forms.TextBox phn_num_tb;
        private System.Windows.Forms.TextBox email_tb;
        private System.Windows.Forms.TextBox name_tb;
        private System.Windows.Forms.Button clear_btn;
        private System.Windows.Forms.Button create_account_btn;
        private System.Windows.Forms.Button pass_show_btn;
        private System.Windows.Forms.ComboBox country_code;
        private System.Windows.Forms.Button con_pass_show_btn;
        private System.Windows.Forms.Button pass_hide_btn;
        private System.Windows.Forms.Button con_pass_hide_btn;
        private System.Windows.Forms.Button previous_form_btn;
        private System.Windows.Forms.TextBox pass_tb;
        private System.Windows.Forms.TextBox customer_id_tb;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton others_radio_button;
        private System.Windows.Forms.RadioButton female_radio_button;
        private System.Windows.Forms.RadioButton male_radio_Button;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox icon;
        private System.Windows.Forms.RadioButton not_say_radio_button;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel gender_panel;
    }
}