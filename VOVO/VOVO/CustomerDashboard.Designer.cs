namespace VOVO
{
    partial class CustomerDashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomerDashboard));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.log_out_button = new System.Windows.Forms.Button();
            this.user_picture_box = new System.Windows.Forms.PictureBox();
            this.edit_button = new System.Windows.Forms.Label();
            this.name_label = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.top_border_panel = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.icon = new System.Windows.Forms.PictureBox();
            this.minimize_btn = new System.Windows.Forms.Button();
            this.maximized_btn = new System.Windows.Forms.Button();
            this.maximize_btn = new System.Windows.Forms.Button();
            this.close_btn = new System.Windows.Forms.Button();
            this.important_label = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.warning_panel = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.calendar_tb = new MetroFramework.Controls.MetroTextBox();
            this.calendar = new MetroFramework.Controls.MetroDateTime();
            this.to_combo_box = new System.Windows.Forms.ComboBox();
            this.next_button = new System.Windows.Forms.Button();
            this.report_button = new System.Windows.Forms.Button();
            this.from_combo_box = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.user_picture_box)).BeginInit();
            this.top_border_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.icon)).BeginInit();
            this.warning_panel.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 40);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 95);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(199)))), ((int)(((byte)(199)))));
            this.panel2.Controls.Add(this.log_out_button);
            this.panel2.Controls.Add(this.user_picture_box);
            this.panel2.Controls.Add(this.edit_button);
            this.panel2.Controls.Add(this.name_label);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(800, 95);
            this.panel2.TabIndex = 1;
            // 
            // log_out_button
            // 
            this.log_out_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(199)))), ((int)(((byte)(199)))));
            this.log_out_button.FlatAppearance.BorderSize = 0;
            this.log_out_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.log_out_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.log_out_button.ForeColor = System.Drawing.Color.Coral;
            this.log_out_button.Location = new System.Drawing.Point(701, 18);
            this.log_out_button.Name = "log_out_button";
            this.log_out_button.Size = new System.Drawing.Size(96, 40);
            this.log_out_button.TabIndex = 18;
            this.log_out_button.Text = "Log Out";
            this.log_out_button.UseVisualStyleBackColor = false;
            this.log_out_button.Click += new System.EventHandler(this.log_out_button_Click);
            // 
            // user_picture_box
            // 
            this.user_picture_box.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.user_picture_box.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.user_picture_box.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.user_picture_box.Location = new System.Drawing.Point(0, 0);
            this.user_picture_box.Name = "user_picture_box";
            this.user_picture_box.Size = new System.Drawing.Size(95, 95);
            this.user_picture_box.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.user_picture_box.TabIndex = 11;
            this.user_picture_box.TabStop = false;
            this.user_picture_box.Click += new System.EventHandler(this.profile_click);
            // 
            // edit_button
            // 
            this.edit_button.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.edit_button.AutoSize = true;
            this.edit_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.edit_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edit_button.ForeColor = System.Drawing.Color.Coral;
            this.edit_button.Location = new System.Drawing.Point(98, 50);
            this.edit_button.Name = "edit_button";
            this.edit_button.Size = new System.Drawing.Size(37, 20);
            this.edit_button.TabIndex = 1;
            this.edit_button.Text = "Edit";
            this.edit_button.Click += new System.EventHandler(this.edit_button_Click);
            // 
            // name_label
            // 
            this.name_label.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.name_label.AutoSize = true;
            this.name_label.Cursor = System.Windows.Forms.Cursors.Hand;
            this.name_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.name_label.ForeColor = System.Drawing.Color.Coral;
            this.name_label.Location = new System.Drawing.Point(98, 28);
            this.name_label.Name = "name_label";
            this.name_label.Size = new System.Drawing.Size(112, 20);
            this.name_label.TabIndex = 1;
            this.name_label.Text = "Basharul Alam";
            this.name_label.Click += new System.EventHandler(this.profile_click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Modern No. 20", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Coral;
            this.label1.Location = new System.Drawing.Point(242, 28);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(394, 41);
            this.label1.TabIndex = 0;
            this.label1.Text = "WELCOME TO VOVO";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Coral;
            this.label2.Location = new System.Drawing.Point(29, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "LEAVING FROM";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Coral;
            this.label3.Location = new System.Drawing.Point(29, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "GOING TO";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Coral;
            this.label6.Location = new System.Drawing.Point(503, 48);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(195, 58);
            this.label6.TabIndex = 1;
            this.label6.Text = "For any problem \r\nreport here";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Coral;
            this.label7.Location = new System.Drawing.Point(452, 109);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(280, 85);
            this.label7.TabIndex = 1;
            this.label7.Text = resources.GetString("label7.Text");
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Coral;
            this.label4.Location = new System.Drawing.Point(29, 211);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(262, 20);
            this.label4.TabIndex = 1;
            this.label4.Text = "DEPARTING DATE(DD/MM/YYYY)";
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
            this.top_border_panel.TabIndex = 6;
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
            this.maximized_btn.BackColor = System.Drawing.Color.Transparent;
            this.maximized_btn.Dock = System.Windows.Forms.DockStyle.Right;
            this.maximized_btn.FlatAppearance.BorderSize = 0;
            this.maximized_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSalmon;
            this.maximized_btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.maximized_btn.Image = global::VOVO.Properties.Resources.squares;
            this.maximized_btn.Location = new System.Drawing.Point(608, 0);
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
            this.close_btn.BackColor = System.Drawing.Color.Transparent;
            this.close_btn.Dock = System.Windows.Forms.DockStyle.Right;
            this.close_btn.FlatAppearance.BorderSize = 0;
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
            // important_label
            // 
            this.important_label.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.important_label.AutoSize = true;
            this.important_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.important_label.ForeColor = System.Drawing.Color.Red;
            this.important_label.Location = new System.Drawing.Point(126, 118);
            this.important_label.Name = "important_label";
            this.important_label.Size = new System.Drawing.Size(141, 17);
            this.important_label.TabIndex = 1;
            this.important_label.Text = "Choose Different City";
            this.important_label.Visible = false;
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Red;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(20, 5);
            this.label8.Margin = new System.Windows.Forms.Padding(0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(746, 18);
            this.label8.TabIndex = 1;
            this.label8.Text = "If you are unable to verify your email and phone number, you will not be able to " +
    "purchase the ticket";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // warning_panel
            // 
            this.warning_panel.BackColor = System.Drawing.Color.Red;
            this.warning_panel.Controls.Add(this.label8);
            this.warning_panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.warning_panel.Location = new System.Drawing.Point(0, 135);
            this.warning_panel.Name = "warning_panel";
            this.warning_panel.Size = new System.Drawing.Size(800, 30);
            this.warning_panel.TabIndex = 10;
            this.warning_panel.Visible = false;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.calendar_tb);
            this.panel4.Controls.Add(this.calendar);
            this.panel4.Controls.Add(this.to_combo_box);
            this.panel4.Controls.Add(this.next_button);
            this.panel4.Controls.Add(this.report_button);
            this.panel4.Controls.Add(this.from_combo_box);
            this.panel4.Controls.Add(this.label6);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.important_label);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.label7);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 165);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(800, 356);
            this.panel4.TabIndex = 11;
            // 
            // calendar_tb
            // 
            // 
            // 
            // 
            this.calendar_tb.CustomButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.calendar_tb.CustomButton.Image = null;
            this.calendar_tb.CustomButton.Location = new System.Drawing.Point(253, 2);
            this.calendar_tb.CustomButton.Name = "";
            this.calendar_tb.CustomButton.Size = new System.Drawing.Size(25, 25);
            this.calendar_tb.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.calendar_tb.CustomButton.TabIndex = 1;
            this.calendar_tb.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.calendar_tb.CustomButton.UseSelectable = true;
            this.calendar_tb.CustomButton.Visible = false;
            this.calendar_tb.Lines = new string[0];
            this.calendar_tb.Location = new System.Drawing.Point(33, 240);
            this.calendar_tb.MaxLength = 32767;
            this.calendar_tb.Name = "calendar_tb";
            this.calendar_tb.PasswordChar = '\0';
            this.calendar_tb.PromptText = "Select A Date";
            this.calendar_tb.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.calendar_tb.SelectedText = "";
            this.calendar_tb.SelectionLength = 0;
            this.calendar_tb.SelectionStart = 0;
            this.calendar_tb.ShortcutsEnabled = true;
            this.calendar_tb.Size = new System.Drawing.Size(281, 30);
            this.calendar_tb.TabIndex = 16;
            this.calendar_tb.UseCustomBackColor = true;
            this.calendar_tb.UseCustomForeColor = true;
            this.calendar_tb.UseSelectable = true;
            this.calendar_tb.UseStyleColors = true;
            this.calendar_tb.WaterMark = "Select A Date";
            this.calendar_tb.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.calendar_tb.WaterMarkFont = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.calendar_tb.Leave += new System.EventHandler(this.date_tb_Leave);
            // 
            // calendar
            // 
            this.calendar.CustomFormat = "DD/MM/YYYY";
            this.calendar.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.calendar.Location = new System.Drawing.Point(34, 240);
            this.calendar.MinimumSize = new System.Drawing.Size(0, 29);
            this.calendar.Name = "calendar";
            this.calendar.Size = new System.Drawing.Size(305, 29);
            this.calendar.TabIndex = 17;
            this.calendar.UseCustomForeColor = true;
            this.calendar.UseStyleColors = true;
            this.calendar.ValueChanged += new System.EventHandler(this.calendar_ValueChanged);
            // 
            // to_combo_box
            // 
            this.to_combo_box.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.to_combo_box.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.to_combo_box.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.to_combo_box.FormattingEnabled = true;
            this.to_combo_box.Location = new System.Drawing.Point(33, 141);
            this.to_combo_box.Name = "to_combo_box";
            this.to_combo_box.Size = new System.Drawing.Size(306, 33);
            this.to_combo_box.TabIndex = 15;
            // 
            // next_button
            // 
            this.next_button.BackColor = System.Drawing.Color.Coral;
            this.next_button.FlatAppearance.BorderSize = 0;
            this.next_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.next_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.next_button.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.next_button.Location = new System.Drawing.Point(129, 295);
            this.next_button.Name = "next_button";
            this.next_button.Size = new System.Drawing.Size(107, 37);
            this.next_button.TabIndex = 13;
            this.next_button.Text = "Next";
            this.next_button.UseVisualStyleBackColor = false;
            this.next_button.Click += new System.EventHandler(this.next_button_Click);
            // 
            // report_button
            // 
            this.report_button.BackColor = System.Drawing.Color.Coral;
            this.report_button.FlatAppearance.BorderSize = 0;
            this.report_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.report_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.report_button.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.report_button.Location = new System.Drawing.Point(554, 229);
            this.report_button.Name = "report_button";
            this.report_button.Size = new System.Drawing.Size(104, 40);
            this.report_button.TabIndex = 11;
            this.report_button.Text = "Report";
            this.report_button.UseVisualStyleBackColor = false;
            this.report_button.Click += new System.EventHandler(this.report_button_Click);
            // 
            // from_combo_box
            // 
            this.from_combo_box.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.from_combo_box.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.from_combo_box.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.from_combo_box.FormattingEnabled = true;
            this.from_combo_box.Location = new System.Drawing.Point(33, 54);
            this.from_combo_box.Name = "from_combo_box";
            this.from_combo_box.Size = new System.Drawing.Size(306, 33);
            this.from_combo_box.TabIndex = 10;
            // 
            // CustomerDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(209)))), ((int)(((byte)(209)))));
            this.ClientSize = new System.Drawing.Size(800, 521);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.warning_panel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.top_border_panel);
            this.Name = "CustomerDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CustomerDashboard";
            this.Resize += new System.EventHandler(this.CustomerDashboard_Resize);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.user_picture_box)).EndInit();
            this.top_border_panel.ResumeLayout(false);
            this.top_border_panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.icon)).EndInit();
            this.warning_panel.ResumeLayout(false);
            this.warning_panel.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel top_border_panel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox icon;
        private System.Windows.Forms.Button minimize_btn;
        private System.Windows.Forms.Button maximized_btn;
        private System.Windows.Forms.Button maximize_btn;
        private System.Windows.Forms.Button close_btn;
        private System.Windows.Forms.Label important_label;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label name_label;
        private System.Windows.Forms.Label edit_button;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel warning_panel;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.PictureBox user_picture_box;
        private MetroFramework.Controls.MetroTextBox calendar_tb;
        private System.Windows.Forms.ComboBox to_combo_box;
        private System.Windows.Forms.Button next_button;
        private System.Windows.Forms.Button report_button;
        private System.Windows.Forms.ComboBox from_combo_box;
        private MetroFramework.Controls.MetroDateTime calendar;
        private System.Windows.Forms.Button log_out_button;
    }
}