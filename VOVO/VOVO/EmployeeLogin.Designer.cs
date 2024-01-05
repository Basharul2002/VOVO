namespace VOVO
{
    partial class EmployeeLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EmployeeLogin));
            this.border_panel = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.icon = new System.Windows.Forms.PictureBox();
            this.minimize_btn = new System.Windows.Forms.Button();
            this.maximized_btn = new System.Windows.Forms.Button();
            this.maximize_btn = new System.Windows.Forms.Button();
            this.close_btn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.sub_panel = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel = new System.Windows.Forms.Panel();
            this.hide_button = new System.Windows.Forms.Button();
            this.show_button = new System.Windows.Forms.Button();
            this.metroPanel4 = new MetroFramework.Controls.MetroPanel();
            this.metroPanel3 = new MetroFramework.Controls.MetroPanel();
            this.metroPanel5 = new MetroFramework.Controls.MetroPanel();
            this.metroPanel2 = new MetroFramework.Controls.MetroPanel();
            this.metroPanel6 = new MetroFramework.Controls.MetroPanel();
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.password_tb = new MetroFramework.Controls.MetroTextBox();
            this.id_tb = new MetroFramework.Controls.MetroTextBox();
            this.password_icon_picture_box = new System.Windows.Forms.PictureBox();
            this.user_id_picture_box = new System.Windows.Forms.PictureBox();
            this.sign_in_button = new System.Windows.Forms.Button();
            this.back_button = new System.Windows.Forms.Button();
            this.border_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.icon)).BeginInit();
            this.panel1.SuspendLayout();
            this.sub_panel.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.password_icon_picture_box)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.user_id_picture_box)).BeginInit();
            this.SuspendLayout();
            // 
            // border_panel
            // 
            this.border_panel.BackColor = System.Drawing.Color.Coral;
            this.border_panel.Controls.Add(this.label5);
            this.border_panel.Controls.Add(this.icon);
            this.border_panel.Controls.Add(this.minimize_btn);
            this.border_panel.Controls.Add(this.maximized_btn);
            this.border_panel.Controls.Add(this.maximize_btn);
            this.border_panel.Controls.Add(this.close_btn);
            this.border_panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.border_panel.Location = new System.Drawing.Point(0, 0);
            this.border_panel.Name = "border_panel";
            this.border_panel.Size = new System.Drawing.Size(635, 40);
            this.border_panel.TabIndex = 5;
            this.border_panel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.border_panel_MouseDown);
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
            this.minimize_btn.Location = new System.Drawing.Point(379, 0);
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
            this.maximized_btn.Location = new System.Drawing.Point(443, 0);
            this.maximized_btn.Name = "maximized_btn";
            this.maximized_btn.Size = new System.Drawing.Size(64, 40);
            this.maximized_btn.TabIndex = 0;
            this.maximized_btn.UseVisualStyleBackColor = false;
            this.maximized_btn.Click += new System.EventHandler(this.maximized_btn_Click);
            this.maximized_btn.MouseEnter += new System.EventHandler(this.maximized_btn_MouseEnter);
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
            this.maximize_btn.Location = new System.Drawing.Point(507, 0);
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
            this.close_btn.Location = new System.Drawing.Point(571, 0);
            this.close_btn.Name = "close_btn";
            this.close_btn.Size = new System.Drawing.Size(64, 40);
            this.close_btn.TabIndex = 0;
            this.close_btn.UseVisualStyleBackColor = false;
            this.close_btn.Click += new System.EventHandler(this.close_btn_Click);
            this.close_btn.MouseEnter += new System.EventHandler(this.close_btn_MouseEnter);
            this.close_btn.MouseLeave += new System.EventHandler(this.close_btn_MouseLeave);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.sub_panel);
            this.panel1.Controls.Add(this.border_panel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(635, 506);
            this.panel1.TabIndex = 11;
            // 
            // sub_panel
            // 
            this.sub_panel.Controls.Add(this.panel3);
            this.sub_panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sub_panel.Location = new System.Drawing.Point(0, 40);
            this.sub_panel.Name = "sub_panel";
            this.sub_panel.Size = new System.Drawing.Size(635, 466);
            this.sub_panel.TabIndex = 11;
            // 
            // panel3
            // 
            this.panel3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel3.BackgroundImage")));
            this.panel3.Controls.Add(this.panel);
            this.panel3.Location = new System.Drawing.Point(130, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(350, 450);
            this.panel3.TabIndex = 10;
            // 
            // panel
            // 
            this.panel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel.AutoSize = true;
            this.panel.BackColor = System.Drawing.Color.White;
            this.panel.Controls.Add(this.hide_button);
            this.panel.Controls.Add(this.show_button);
            this.panel.Controls.Add(this.metroPanel4);
            this.panel.Controls.Add(this.metroPanel3);
            this.panel.Controls.Add(this.metroPanel5);
            this.panel.Controls.Add(this.metroPanel2);
            this.panel.Controls.Add(this.metroPanel6);
            this.panel.Controls.Add(this.metroPanel1);
            this.panel.Controls.Add(this.password_tb);
            this.panel.Controls.Add(this.id_tb);
            this.panel.Controls.Add(this.password_icon_picture_box);
            this.panel.Controls.Add(this.user_id_picture_box);
            this.panel.Controls.Add(this.sign_in_button);
            this.panel.Controls.Add(this.back_button);
            this.panel.Location = new System.Drawing.Point(0, 162);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(353, 230);
            this.panel.TabIndex = 10;
            this.panel.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_Paint);
            // 
            // hide_button
            // 
            this.hide_button.FlatAppearance.BorderSize = 0;
            this.hide_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.hide_button.Image = global::VOVO.Properties.Resources.hide1;
            this.hide_button.Location = new System.Drawing.Point(305, 142);
            this.hide_button.Name = "hide_button";
            this.hide_button.Size = new System.Drawing.Size(45, 39);
            this.hide_button.TabIndex = 11;
            this.hide_button.UseVisualStyleBackColor = true;
            this.hide_button.Click += new System.EventHandler(this.hide_button_Click);
            // 
            // show_button
            // 
            this.show_button.FlatAppearance.BorderSize = 0;
            this.show_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.show_button.Image = global::VOVO.Properties.Resources.show1;
            this.show_button.Location = new System.Drawing.Point(293, 97);
            this.show_button.Name = "show_button";
            this.show_button.Size = new System.Drawing.Size(45, 39);
            this.show_button.TabIndex = 11;
            this.show_button.UseVisualStyleBackColor = true;
            this.show_button.Click += new System.EventHandler(this.show_button_Click);
            // 
            // metroPanel4
            // 
            this.metroPanel4.HorizontalScrollbarBarColor = true;
            this.metroPanel4.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel4.HorizontalScrollbarSize = 10;
            this.metroPanel4.Location = new System.Drawing.Point(56, 88);
            this.metroPanel4.Name = "metroPanel4";
            this.metroPanel4.Size = new System.Drawing.Size(16, 60);
            this.metroPanel4.TabIndex = 17;
            this.metroPanel4.VerticalScrollbarBarColor = true;
            this.metroPanel4.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel4.VerticalScrollbarSize = 10;
            // 
            // metroPanel3
            // 
            this.metroPanel3.HorizontalScrollbarBarColor = true;
            this.metroPanel3.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel3.HorizontalScrollbarSize = 10;
            this.metroPanel3.Location = new System.Drawing.Point(53, 29);
            this.metroPanel3.Name = "metroPanel3";
            this.metroPanel3.Size = new System.Drawing.Size(19, 60);
            this.metroPanel3.TabIndex = 13;
            this.metroPanel3.VerticalScrollbarBarColor = true;
            this.metroPanel3.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel3.VerticalScrollbarSize = 10;
            // 
            // metroPanel5
            // 
            this.metroPanel5.HorizontalScrollbarBarColor = true;
            this.metroPanel5.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel5.HorizontalScrollbarSize = 10;
            this.metroPanel5.Location = new System.Drawing.Point(294, 88);
            this.metroPanel5.Name = "metroPanel5";
            this.metroPanel5.Size = new System.Drawing.Size(19, 60);
            this.metroPanel5.TabIndex = 16;
            this.metroPanel5.VerticalScrollbarBarColor = true;
            this.metroPanel5.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel5.VerticalScrollbarSize = 10;
            // 
            // metroPanel2
            // 
            this.metroPanel2.HorizontalScrollbarBarColor = true;
            this.metroPanel2.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel2.HorizontalScrollbarSize = 10;
            this.metroPanel2.Location = new System.Drawing.Point(294, 29);
            this.metroPanel2.Name = "metroPanel2";
            this.metroPanel2.Size = new System.Drawing.Size(19, 60);
            this.metroPanel2.TabIndex = 12;
            this.metroPanel2.VerticalScrollbarBarColor = true;
            this.metroPanel2.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel2.VerticalScrollbarSize = 10;
            // 
            // metroPanel6
            // 
            this.metroPanel6.HorizontalScrollbarBarColor = true;
            this.metroPanel6.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel6.HorizontalScrollbarSize = 10;
            this.metroPanel6.Location = new System.Drawing.Point(64, 88);
            this.metroPanel6.Name = "metroPanel6";
            this.metroPanel6.Size = new System.Drawing.Size(235, 10);
            this.metroPanel6.TabIndex = 14;
            this.metroPanel6.VerticalScrollbarBarColor = true;
            this.metroPanel6.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel6.VerticalScrollbarSize = 10;
            // 
            // metroPanel1
            // 
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Location = new System.Drawing.Point(64, 29);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(235, 10);
            this.metroPanel1.TabIndex = 11;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 10;
            // 
            // password_tb
            // 
            // 
            // 
            // 
            this.password_tb.CustomButton.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar;
            this.password_tb.CustomButton.FlatAppearance.BorderColor = System.Drawing.Color.Coral;
            this.password_tb.CustomButton.FlatAppearance.BorderSize = 2;
            this.password_tb.CustomButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.password_tb.CustomButton.Image = null;
            this.password_tb.CustomButton.Location = new System.Drawing.Point(195, 1);
            this.password_tb.CustomButton.Name = "";
            this.password_tb.CustomButton.Size = new System.Drawing.Size(39, 39);
            this.password_tb.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.password_tb.CustomButton.TabIndex = 1;
            this.password_tb.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.password_tb.CustomButton.UseSelectable = true;
            this.password_tb.CustomButton.Visible = false;
            this.password_tb.DisplayIcon = true;
            this.password_tb.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.password_tb.Lines = new string[0];
            this.password_tb.Location = new System.Drawing.Point(64, 97);
            this.password_tb.MaxLength = 32767;
            this.password_tb.Name = "password_tb";
            this.password_tb.PasswordChar = '●';
            this.password_tb.PromptText = "Password";
            this.password_tb.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.password_tb.SelectedText = "";
            this.password_tb.SelectionLength = 0;
            this.password_tb.SelectionStart = 0;
            this.password_tb.ShortcutsEnabled = true;
            this.password_tb.Size = new System.Drawing.Size(235, 41);
            this.password_tb.TabIndex = 15;
            this.password_tb.UseCustomBackColor = true;
            this.password_tb.UseCustomForeColor = true;
            this.password_tb.UseSelectable = true;
            this.password_tb.UseStyleColors = true;
            this.password_tb.UseSystemPasswordChar = true;
            this.password_tb.WaterMark = "Password";
            this.password_tb.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.password_tb.WaterMarkFont = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.password_tb.TextChanged += new System.EventHandler(this.password_tb_TextChanged);
            this.password_tb.Click += new System.EventHandler(this.password_tb_Click);
            this.password_tb.Validated += new System.EventHandler(this.password_tb_Validated);
            // 
            // id_tb
            // 
            // 
            // 
            // 
            this.id_tb.CustomButton.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar;
            this.id_tb.CustomButton.FlatAppearance.BorderColor = System.Drawing.Color.Coral;
            this.id_tb.CustomButton.FlatAppearance.BorderSize = 2;
            this.id_tb.CustomButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.id_tb.CustomButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.id_tb.CustomButton.Image = null;
            this.id_tb.CustomButton.Location = new System.Drawing.Point(195, 1);
            this.id_tb.CustomButton.Name = "";
            this.id_tb.CustomButton.Size = new System.Drawing.Size(39, 39);
            this.id_tb.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.id_tb.CustomButton.TabIndex = 1;
            this.id_tb.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.id_tb.CustomButton.UseSelectable = true;
            this.id_tb.CustomButton.Visible = false;
            this.id_tb.DisplayIcon = true;
            this.id_tb.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.id_tb.Lines = new string[0];
            this.id_tb.Location = new System.Drawing.Point(64, 38);
            this.id_tb.MaxLength = 20;
            this.id_tb.Name = "id_tb";
            this.id_tb.PasswordChar = '\0';
            this.id_tb.PromptText = "ID";
            this.id_tb.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.id_tb.SelectedText = "";
            this.id_tb.SelectionLength = 0;
            this.id_tb.SelectionStart = 0;
            this.id_tb.ShortcutsEnabled = true;
            this.id_tb.Size = new System.Drawing.Size(235, 41);
            this.id_tb.TabIndex = 11;
            this.id_tb.UseCustomBackColor = true;
            this.id_tb.UseCustomForeColor = true;
            this.id_tb.UseSelectable = true;
            this.id_tb.UseStyleColors = true;
            this.id_tb.WaterMark = "ID";
            this.id_tb.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.id_tb.WaterMarkFont = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            // 
            // password_icon_picture_box
            // 
            this.password_icon_picture_box.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.password_icon_picture_box.Image = ((System.Drawing.Image)(resources.GetObject("password_icon_picture_box.Image")));
            this.password_icon_picture_box.Location = new System.Drawing.Point(20, 95);
            this.password_icon_picture_box.Margin = new System.Windows.Forms.Padding(0);
            this.password_icon_picture_box.Name = "password_icon_picture_box";
            this.password_icon_picture_box.Size = new System.Drawing.Size(45, 41);
            this.password_icon_picture_box.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.password_icon_picture_box.TabIndex = 9;
            this.password_icon_picture_box.TabStop = false;
            // 
            // user_id_picture_box
            // 
            this.user_id_picture_box.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.user_id_picture_box.Image = ((System.Drawing.Image)(resources.GetObject("user_id_picture_box.Image")));
            this.user_id_picture_box.Location = new System.Drawing.Point(20, 38);
            this.user_id_picture_box.Margin = new System.Windows.Forms.Padding(0);
            this.user_id_picture_box.Name = "user_id_picture_box";
            this.user_id_picture_box.Size = new System.Drawing.Size(45, 41);
            this.user_id_picture_box.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.user_id_picture_box.TabIndex = 9;
            this.user_id_picture_box.TabStop = false;
            // 
            // sign_in_button
            // 
            this.sign_in_button.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.sign_in_button.BackColor = System.Drawing.Color.Transparent;
            this.sign_in_button.FlatAppearance.BorderColor = System.Drawing.Color.Coral;
            this.sign_in_button.FlatAppearance.BorderSize = 3;
            this.sign_in_button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Coral;
            this.sign_in_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sign_in_button.Font = new System.Drawing.Font("Montserrat", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sign_in_button.ForeColor = System.Drawing.Color.Coral;
            this.sign_in_button.Location = new System.Drawing.Point(168, 167);
            this.sign_in_button.Name = "sign_in_button";
            this.sign_in_button.Size = new System.Drawing.Size(101, 36);
            this.sign_in_button.TabIndex = 3;
            this.sign_in_button.Text = "SIGN IN";
            this.sign_in_button.UseVisualStyleBackColor = false;
            this.sign_in_button.Click += new System.EventHandler(this.sign_in_button_Click);
            this.sign_in_button.MouseEnter += new System.EventHandler(this.sign_in_button_MouseEnter);
            this.sign_in_button.MouseLeave += new System.EventHandler(this.sign_in_button_MouseLeave);
            // 
            // back_button
            // 
            this.back_button.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.back_button.BackColor = System.Drawing.Color.Transparent;
            this.back_button.FlatAppearance.BorderColor = System.Drawing.Color.Coral;
            this.back_button.FlatAppearance.BorderSize = 3;
            this.back_button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Coral;
            this.back_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.back_button.Font = new System.Drawing.Font("Montserrat", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.back_button.ForeColor = System.Drawing.Color.Coral;
            this.back_button.Location = new System.Drawing.Point(39, 166);
            this.back_button.Name = "back_button";
            this.back_button.Size = new System.Drawing.Size(101, 36);
            this.back_button.TabIndex = 3;
            this.back_button.Text = "Back";
            this.back_button.UseVisualStyleBackColor = false;
            this.back_button.Click += new System.EventHandler(this.back_button_Click);
            this.back_button.MouseEnter += new System.EventHandler(this.back_button_MouseEnter);
            this.back_button.MouseLeave += new System.EventHandler(this.back_button_MouseLeave);
            // 
            // EmployeeLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(209)))), ((int)(((byte)(209)))));
            this.ClientSize = new System.Drawing.Size(635, 506);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "EmployeeLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EmployeeLogin";
            this.Load += new System.EventHandler(this.EmployeeLogin_Load);
            this.SizeChanged += new System.EventHandler(this.EmployeeLogin_SizeChanged);
            this.Resize += new System.EventHandler(this.EmployeeLogin_Resize);
            this.border_panel.ResumeLayout(false);
            this.border_panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.icon)).EndInit();
            this.panel1.ResumeLayout(false);
            this.sub_panel.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.password_icon_picture_box)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.user_id_picture_box)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button minimize_btn;
        private System.Windows.Forms.Button maximized_btn;
        private System.Windows.Forms.Button maximize_btn;
        private System.Windows.Forms.Button close_btn;
        private System.Windows.Forms.Panel border_panel;
        private System.Windows.Forms.PictureBox icon;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel sub_panel;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.PictureBox password_icon_picture_box;
        private System.Windows.Forms.PictureBox user_id_picture_box;
        private System.Windows.Forms.Button sign_in_button;
        private System.Windows.Forms.Button back_button;
        private System.Windows.Forms.Panel panel3;
        private MetroFramework.Controls.MetroTextBox id_tb;
        private MetroFramework.Controls.MetroPanel metroPanel3;
        private MetroFramework.Controls.MetroPanel metroPanel2;
        private MetroFramework.Controls.MetroPanel metroPanel1;
        private MetroFramework.Controls.MetroPanel metroPanel4;
        private MetroFramework.Controls.MetroPanel metroPanel5;
        private MetroFramework.Controls.MetroPanel metroPanel6;
        private MetroFramework.Controls.MetroTextBox password_tb;
        private System.Windows.Forms.Button show_button;
        private System.Windows.Forms.Button hide_button;
    }
}