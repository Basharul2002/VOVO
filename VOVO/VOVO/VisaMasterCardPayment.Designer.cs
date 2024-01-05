namespace VOVO
{
    partial class VisaMasterCardPayment
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
            this.components = new System.ComponentModel.Container();
            this.card_picture_box = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.submit_button = new System.Windows.Forms.Button();
            this.cvv_code_tb = new MetroFramework.Controls.MetroTextBox();
            this.expiry_date_tb = new MetroFramework.Controls.MetroTextBox();
            this.card_number_tb = new MetroFramework.Controls.MetroTextBox();
            this.card_holder_name_tb = new MetroFramework.Controls.MetroTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.expiry_date = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.card_holder_name = new System.Windows.Forms.Label();
            this.card_number = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.top_border_panel = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.icon = new System.Windows.Forms.PictureBox();
            this.minimize_btn = new System.Windows.Forms.Button();
            this.maximized_btn = new System.Windows.Forms.Button();
            this.maximize_btn = new System.Windows.Forms.Button();
            this.close_btn = new System.Windows.Forms.Button();
            this.metroContextMenu1 = new MetroFramework.Controls.MetroContextMenu(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.card_picture_box)).BeginInit();
            this.panel1.SuspendLayout();
            this.top_border_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.icon)).BeginInit();
            this.SuspendLayout();
            // 
            // card_picture_box
            // 
            this.card_picture_box.Image = global::VOVO.Properties.Resources.Card;
            this.card_picture_box.Location = new System.Drawing.Point(458, 110);
            this.card_picture_box.Name = "card_picture_box";
            this.card_picture_box.Size = new System.Drawing.Size(276, 174);
            this.card_picture_box.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.card_picture_box.TabIndex = 2;
            this.card_picture_box.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(209)))), ((int)(((byte)(209)))));
            this.panel1.Controls.Add(this.submit_button);
            this.panel1.Controls.Add(this.cvv_code_tb);
            this.panel1.Controls.Add(this.expiry_date_tb);
            this.panel1.Controls.Add(this.card_number_tb);
            this.panel1.Controls.Add(this.card_holder_name_tb);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.expiry_date);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.card_holder_name);
            this.panel1.Controls.Add(this.card_number);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.card_picture_box);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(762, 450);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // submit_button
            // 
            this.submit_button.BackColor = System.Drawing.Color.Coral;
            this.submit_button.FlatAppearance.BorderColor = System.Drawing.Color.Coral;
            this.submit_button.FlatAppearance.BorderSize = 0;
            this.submit_button.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Coral;
            this.submit_button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Coral;
            this.submit_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.submit_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.submit_button.ForeColor = System.Drawing.Color.White;
            this.submit_button.Image = global::VOVO.Properties.Resources.Next_Arrow1;
            this.submit_button.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.submit_button.Location = new System.Drawing.Point(53, 353);
            this.submit_button.Name = "submit_button";
            this.submit_button.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.submit_button.Size = new System.Drawing.Size(122, 50);
            this.submit_button.TabIndex = 12;
            this.submit_button.Text = "Submit";
            this.submit_button.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.submit_button.UseVisualStyleBackColor = false;
            // 
            // cvv_code_tb
            // 
            this.cvv_code_tb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(209)))), ((int)(((byte)(209)))));
            // 
            // 
            // 
            this.cvv_code_tb.CustomButton.Image = null;
            this.cvv_code_tb.CustomButton.Location = new System.Drawing.Point(88, 1);
            this.cvv_code_tb.CustomButton.Name = "";
            this.cvv_code_tb.CustomButton.Size = new System.Drawing.Size(33, 33);
            this.cvv_code_tb.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.cvv_code_tb.CustomButton.TabIndex = 1;
            this.cvv_code_tb.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.cvv_code_tb.CustomButton.UseSelectable = true;
            this.cvv_code_tb.CustomButton.Visible = false;
            this.cvv_code_tb.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.cvv_code_tb.Lines = new string[0];
            this.cvv_code_tb.Location = new System.Drawing.Point(253, 284);
            this.cvv_code_tb.Margin = new System.Windows.Forms.Padding(4);
            this.cvv_code_tb.MaxLength = 32767;
            this.cvv_code_tb.Multiline = true;
            this.cvv_code_tb.Name = "cvv_code_tb";
            this.cvv_code_tb.PasswordChar = '\0';
            this.cvv_code_tb.PromptText = "⠀123";
            this.cvv_code_tb.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.cvv_code_tb.SelectedText = "";
            this.cvv_code_tb.SelectionLength = 0;
            this.cvv_code_tb.SelectionStart = 0;
            this.cvv_code_tb.ShortcutsEnabled = true;
            this.cvv_code_tb.Size = new System.Drawing.Size(122, 35);
            this.cvv_code_tb.TabIndex = 10;
            this.cvv_code_tb.Theme = MetroFramework.MetroThemeStyle.Light;
            this.cvv_code_tb.UseCustomBackColor = true;
            this.cvv_code_tb.UseSelectable = true;
            this.cvv_code_tb.WaterMark = "⠀123";
            this.cvv_code_tb.WaterMarkColor = System.Drawing.Color.DarkGray;
            this.cvv_code_tb.WaterMarkFont = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            // 
            // expiry_date_tb
            // 
            this.expiry_date_tb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(209)))), ((int)(((byte)(209)))));
            // 
            // 
            // 
            this.expiry_date_tb.CustomButton.Image = null;
            this.expiry_date_tb.CustomButton.Location = new System.Drawing.Point(88, 1);
            this.expiry_date_tb.CustomButton.Name = "";
            this.expiry_date_tb.CustomButton.Size = new System.Drawing.Size(33, 33);
            this.expiry_date_tb.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.expiry_date_tb.CustomButton.TabIndex = 1;
            this.expiry_date_tb.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.expiry_date_tb.CustomButton.UseSelectable = true;
            this.expiry_date_tb.CustomButton.Visible = false;
            this.expiry_date_tb.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.expiry_date_tb.Lines = new string[0];
            this.expiry_date_tb.Location = new System.Drawing.Point(53, 284);
            this.expiry_date_tb.Margin = new System.Windows.Forms.Padding(4);
            this.expiry_date_tb.MaxLength = 32767;
            this.expiry_date_tb.Multiline = true;
            this.expiry_date_tb.Name = "expiry_date_tb";
            this.expiry_date_tb.PasswordChar = '\0';
            this.expiry_date_tb.PromptText = "⠀06/23";
            this.expiry_date_tb.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.expiry_date_tb.SelectedText = "";
            this.expiry_date_tb.SelectionLength = 0;
            this.expiry_date_tb.SelectionStart = 0;
            this.expiry_date_tb.ShortcutsEnabled = true;
            this.expiry_date_tb.Size = new System.Drawing.Size(122, 35);
            this.expiry_date_tb.TabIndex = 9;
            this.expiry_date_tb.Theme = MetroFramework.MetroThemeStyle.Light;
            this.expiry_date_tb.UseCustomBackColor = true;
            this.expiry_date_tb.UseSelectable = true;
            this.expiry_date_tb.WaterMark = "⠀06/23";
            this.expiry_date_tb.WaterMarkColor = System.Drawing.Color.DarkGray;
            this.expiry_date_tb.WaterMarkFont = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.expiry_date_tb.TextChanged += new System.EventHandler(this.expiry_date_tb__TextChanged);
            // 
            // card_number_tb
            // 
            this.card_number_tb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(209)))), ((int)(((byte)(209)))));
            // 
            // 
            // 
            this.card_number_tb.CustomButton.Image = null;
            this.card_number_tb.CustomButton.Location = new System.Drawing.Point(288, 1);
            this.card_number_tb.CustomButton.Name = "";
            this.card_number_tb.CustomButton.Size = new System.Drawing.Size(33, 33);
            this.card_number_tb.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.card_number_tb.CustomButton.TabIndex = 1;
            this.card_number_tb.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.card_number_tb.CustomButton.UseSelectable = true;
            this.card_number_tb.CustomButton.Visible = false;
            this.card_number_tb.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.card_number_tb.Lines = new string[0];
            this.card_number_tb.Location = new System.Drawing.Point(53, 200);
            this.card_number_tb.Margin = new System.Windows.Forms.Padding(4);
            this.card_number_tb.MaxLength = 32767;
            this.card_number_tb.Multiline = true;
            this.card_number_tb.Name = "card_number_tb";
            this.card_number_tb.PasswordChar = '\0';
            this.card_number_tb.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.card_number_tb.SelectedText = "";
            this.card_number_tb.SelectionLength = 0;
            this.card_number_tb.SelectionStart = 0;
            this.card_number_tb.ShortcutsEnabled = true;
            this.card_number_tb.Size = new System.Drawing.Size(322, 35);
            this.card_number_tb.TabIndex = 7;
            this.card_number_tb.Theme = MetroFramework.MetroThemeStyle.Light;
            this.card_number_tb.UseCustomBackColor = true;
            this.card_number_tb.UseSelectable = true;
            this.card_number_tb.WaterMarkColor = System.Drawing.Color.DarkGray;
            this.card_number_tb.WaterMarkFont = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.card_number_tb.TextChanged += new System.EventHandler(this.card_number_tb_TextChanged);
            // 
            // card_holder_name_tb
            // 
            this.card_holder_name_tb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(209)))), ((int)(((byte)(209)))));
            // 
            // 
            // 
            this.card_holder_name_tb.CustomButton.Image = null;
            this.card_holder_name_tb.CustomButton.Location = new System.Drawing.Point(288, 1);
            this.card_holder_name_tb.CustomButton.Name = "";
            this.card_holder_name_tb.CustomButton.Size = new System.Drawing.Size(33, 33);
            this.card_holder_name_tb.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.card_holder_name_tb.CustomButton.TabIndex = 1;
            this.card_holder_name_tb.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.card_holder_name_tb.CustomButton.UseSelectable = true;
            this.card_holder_name_tb.CustomButton.Visible = false;
            this.card_holder_name_tb.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.card_holder_name_tb.Lines = new string[0];
            this.card_holder_name_tb.Location = new System.Drawing.Point(53, 125);
            this.card_holder_name_tb.Margin = new System.Windows.Forms.Padding(4);
            this.card_holder_name_tb.MaxLength = 32767;
            this.card_holder_name_tb.Multiline = true;
            this.card_holder_name_tb.Name = "card_holder_name_tb";
            this.card_holder_name_tb.PasswordChar = '\0';
            this.card_holder_name_tb.PromptText = "⠀Vovo";
            this.card_holder_name_tb.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.card_holder_name_tb.SelectedText = "";
            this.card_holder_name_tb.SelectionLength = 0;
            this.card_holder_name_tb.SelectionStart = 0;
            this.card_holder_name_tb.ShortcutsEnabled = true;
            this.card_holder_name_tb.Size = new System.Drawing.Size(322, 35);
            this.card_holder_name_tb.TabIndex = 6;
            this.card_holder_name_tb.Theme = MetroFramework.MetroThemeStyle.Light;
            this.card_holder_name_tb.UseCustomBackColor = true;
            this.card_holder_name_tb.UseSelectable = true;
            this.card_holder_name_tb.WaterMark = "⠀Vovo";
            this.card_holder_name_tb.WaterMarkColor = System.Drawing.Color.DarkGray;
            this.card_holder_name_tb.WaterMarkFont = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.card_holder_name_tb.TextChanged += new System.EventHandler(this.card_holder_name_tb__TextChanged);
            this.card_holder_name_tb.Click += new System.EventHandler(this.card_holder_name_tb_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Coral;
            this.label4.Location = new System.Drawing.Point(249, 261);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "CVV Code";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Coral;
            this.label3.Location = new System.Drawing.Point(49, 261);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Expiry Date";
            // 
            // expiry_date
            // 
            this.expiry_date.AutoSize = true;
            this.expiry_date.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(55)))), ((int)(((byte)(190)))));
            this.expiry_date.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.expiry_date.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.expiry_date.Location = new System.Drawing.Point(644, 245);
            this.expiry_date.Name = "expiry_date";
            this.expiry_date.Size = new System.Drawing.Size(38, 15);
            this.expiry_date.TabIndex = 3;
            this.expiry_date.Text = "06/23";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(55)))), ((int)(((byte)(190)))));
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label7.Location = new System.Drawing.Point(644, 230);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 15);
            this.label7.TabIndex = 3;
            this.label7.Text = "Expiry Date";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(55)))), ((int)(((byte)(190)))));
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label6.Location = new System.Drawing.Point(472, 230);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(110, 15);
            this.label6.TabIndex = 3;
            this.label6.Text = "Card Holder Name";
            // 
            // card_holder_name
            // 
            this.card_holder_name.AutoSize = true;
            this.card_holder_name.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(55)))), ((int)(((byte)(190)))));
            this.card_holder_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.card_holder_name.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.card_holder_name.Location = new System.Drawing.Point(472, 245);
            this.card_holder_name.Name = "card_holder_name";
            this.card_holder_name.Size = new System.Drawing.Size(33, 15);
            this.card_holder_name.TabIndex = 3;
            this.card_holder_name.Text = "Vovo";
            // 
            // card_number
            // 
            this.card_number.AutoSize = true;
            this.card_number.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(62)))), ((int)(((byte)(199)))));
            this.card_number.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.card_number.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.card_number.Location = new System.Drawing.Point(472, 200);
            this.card_number.Name = "card_number";
            this.card_number.Size = new System.Drawing.Size(109, 20);
            this.card_number.TabIndex = 3;
            this.card_number.Text = "Card Number";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Coral;
            this.label2.Location = new System.Drawing.Point(49, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Card Holder Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Coral;
            this.label1.Location = new System.Drawing.Point(49, 177);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Card Number";
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
            this.top_border_panel.Size = new System.Drawing.Size(762, 40);
            this.top_border_panel.TabIndex = 6;
            this.top_border_panel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.border_panel_MouseDown);
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
            this.label5.TabIndex = 2;
            this.label5.Text = "VOVO";
            // 
            // icon
            // 
            this.icon.Dock = System.Windows.Forms.DockStyle.Left;
            this.icon.Location = new System.Drawing.Point(0, 0);
            this.icon.Name = "icon";
            this.icon.Size = new System.Drawing.Size(45, 40);
            this.icon.TabIndex = 1;
            this.icon.TabStop = false;
            // 
            // minimize_btn
            // 
            this.minimize_btn.BackColor = System.Drawing.Color.Transparent;
            this.minimize_btn.Dock = System.Windows.Forms.DockStyle.Right;
            this.minimize_btn.FlatAppearance.BorderSize = 0;
            this.minimize_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSalmon;
            this.minimize_btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.minimize_btn.Image = global::VOVO.Properties.Resources.minimize_sign1;
            this.minimize_btn.Location = new System.Drawing.Point(506, 0);
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
            this.maximized_btn.BackColor = System.Drawing.Color.Transparent;
            this.maximized_btn.Dock = System.Windows.Forms.DockStyle.Right;
            this.maximized_btn.FlatAppearance.BorderSize = 0;
            this.maximized_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSalmon;
            this.maximized_btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.maximized_btn.Image = global::VOVO.Properties.Resources.squares;
            this.maximized_btn.Location = new System.Drawing.Point(570, 0);
            this.maximized_btn.Name = "maximized_btn";
            this.maximized_btn.Size = new System.Drawing.Size(64, 40);
            this.maximized_btn.TabIndex = 0;
            this.maximized_btn.UseVisualStyleBackColor = false;
            this.maximized_btn.Click += new System.EventHandler(this.maximized_btn_Click);
            this.maximized_btn.MouseEnter += new System.EventHandler(this.minimize_btn_MouseEnter);
            this.maximized_btn.MouseLeave += new System.EventHandler(this.maximized_btn_MouseLeave);
            // 
            // maximize_btn
            // 
            this.maximize_btn.BackColor = System.Drawing.Color.Transparent;
            this.maximize_btn.Dock = System.Windows.Forms.DockStyle.Right;
            this.maximize_btn.FlatAppearance.BorderSize = 0;
            this.maximize_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSalmon;
            this.maximize_btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.maximize_btn.Image = global::VOVO.Properties.Resources.maximize1;
            this.maximize_btn.Location = new System.Drawing.Point(634, 0);
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
            this.close_btn.BackColor = System.Drawing.Color.Transparent;
            this.close_btn.Dock = System.Windows.Forms.DockStyle.Right;
            this.close_btn.FlatAppearance.BorderSize = 0;
            this.close_btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.close_btn.Image = global::VOVO.Properties.Resources.reject;
            this.close_btn.Location = new System.Drawing.Point(698, 0);
            this.close_btn.Name = "close_btn";
            this.close_btn.Size = new System.Drawing.Size(64, 40);
            this.close_btn.TabIndex = 0;
            this.close_btn.UseVisualStyleBackColor = false;
            this.close_btn.Click += new System.EventHandler(this.close_btn_Click);
            this.close_btn.MouseEnter += new System.EventHandler(this.close_btn_MouseEnter);
            this.close_btn.MouseLeave += new System.EventHandler(this.close_btn_MouseLeave);
            // 
            // metroContextMenu1
            // 
            this.metroContextMenu1.Name = "metroContextMenu1";
            this.metroContextMenu1.Size = new System.Drawing.Size(61, 4);
            // 
            // VisaMasterCardPayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(762, 450);
            this.Controls.Add(this.top_border_panel);
            this.Controls.Add(this.panel1);
            this.Name = "VisaMasterCardPayment";
            this.Text = "VisaMasterCardPayment";
            this.Load += new System.EventHandler(this.VisaMasterCardPayment_Load);
            this.SizeChanged += new System.EventHandler(this.VisaMasterCardPayment_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.card_picture_box)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.top_border_panel.ResumeLayout(false);
            this.top_border_panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.icon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox card_picture_box;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label expiry_date;
        private System.Windows.Forms.Label card_number;
        private System.Windows.Forms.Label card_holder_name;
        private System.Windows.Forms.Panel top_border_panel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox icon;
        private System.Windows.Forms.Button minimize_btn;
        private System.Windows.Forms.Button maximized_btn;
        private System.Windows.Forms.Button maximize_btn;
        private System.Windows.Forms.Button close_btn;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private MetroFramework.Controls.MetroContextMenu metroContextMenu1;
        private MetroFramework.Controls.MetroTextBox card_holder_name_tb;
        private MetroFramework.Controls.MetroTextBox card_number_tb;
        private MetroFramework.Controls.MetroTextBox cvv_code_tb;
        private MetroFramework.Controls.MetroTextBox expiry_date_tb;
        private System.Windows.Forms.Button submit_button;
    }
}