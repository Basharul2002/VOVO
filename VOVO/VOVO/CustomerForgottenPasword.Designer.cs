namespace VOVO
{
    partial class CustomerForgottenPaswordSearching
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomerForgottenPaswordSearching));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.search_tb = new System.Windows.Forms.TextBox();
            this.warning_message = new System.Windows.Forms.TextBox();
            this.cancel_btn = new System.Windows.Forms.Button();
            this.search_btn = new System.Windows.Forms.Button();
            this.message = new System.Windows.Forms.Label();
            this.title = new System.Windows.Forms.Label();
            this.top_border_panel = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.icon = new System.Windows.Forms.PictureBox();
            this.minimize_btn = new System.Windows.Forms.Button();
            this.maximized_btn = new System.Windows.Forms.Button();
            this.maximize_btn = new System.Windows.Forms.Button();
            this.close_btn = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.top_border_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.icon)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.top_border_panel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 450);
            this.panel1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(128)))), ((int)(((byte)(138)))));
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 40);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(800, 410);
            this.panel3.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel4.BackColor = System.Drawing.Color.Sienna;
            this.panel4.Controls.Add(this.search_tb);
            this.panel4.Controls.Add(this.warning_message);
            this.panel4.Controls.Add(this.cancel_btn);
            this.panel4.Controls.Add(this.search_btn);
            this.panel4.Controls.Add(this.message);
            this.panel4.Controls.Add(this.title);
            this.panel4.Location = new System.Drawing.Point(135, 60);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(514, 265);
            this.panel4.TabIndex = 0;
            // 
            // search_tb
            // 
            this.search_tb.BackColor = System.Drawing.Color.Sienna;
            this.search_tb.Font = new System.Drawing.Font("Microsoft Sans Serif", 19F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.search_tb.Location = new System.Drawing.Point(44, 156);
            this.search_tb.Name = "search_tb";
            this.search_tb.Size = new System.Drawing.Size(412, 36);
            this.search_tb.TabIndex = 2;
            this.search_tb.Enter += new System.EventHandler(this.TextBox_Enter);
            this.search_tb.Leave += new System.EventHandler(this.TextBox_Leave);
            // 
            // warning_message
            // 
            this.warning_message.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.warning_message.BackColor = System.Drawing.Color.Sienna;
            this.warning_message.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.warning_message.ForeColor = System.Drawing.Color.White;
            this.warning_message.Location = new System.Drawing.Point(44, 68);
            this.warning_message.Multiline = true;
            this.warning_message.Name = "warning_message";
            this.warning_message.Size = new System.Drawing.Size(354, 39);
            this.warning_message.TabIndex = 4;
            this.warning_message.Text = "Please fill in at least one field\r\nFill in at least one field to search for your " +
    "account";
            this.warning_message.Visible = false;
            // 
            // cancel_btn
            // 
            this.cancel_btn.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cancel_btn.BackColor = System.Drawing.Color.White;
            this.cancel_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancel_btn.Location = new System.Drawing.Point(272, 222);
            this.cancel_btn.Name = "cancel_btn";
            this.cancel_btn.Size = new System.Drawing.Size(75, 36);
            this.cancel_btn.TabIndex = 3;
            this.cancel_btn.Text = "Cancel";
            this.cancel_btn.UseVisualStyleBackColor = false;
            this.cancel_btn.Click += new System.EventHandler(this.cancel_btn_Click);
            // 
            // search_btn
            // 
            this.search_btn.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.search_btn.BackColor = System.Drawing.Color.Pink;
            this.search_btn.FlatAppearance.BorderSize = 0;
            this.search_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.search_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.search_btn.ForeColor = System.Drawing.Color.Red;
            this.search_btn.Location = new System.Drawing.Point(381, 222);
            this.search_btn.Name = "search_btn";
            this.search_btn.Size = new System.Drawing.Size(75, 36);
            this.search_btn.TabIndex = 3;
            this.search_btn.Text = "Search";
            this.search_btn.UseVisualStyleBackColor = false;
            this.search_btn.Click += new System.EventHandler(this.search_btn_Click);
            // 
            // message
            // 
            this.message.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.message.AutoSize = true;
            this.message.BackColor = System.Drawing.Color.Transparent;
            this.message.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.message.ForeColor = System.Drawing.Color.White;
            this.message.Location = new System.Drawing.Point(41, 119);
            this.message.Name = "message";
            this.message.Size = new System.Drawing.Size(452, 34);
            this.message.TabIndex = 1;
            this.message.Text = "Please enter your email address or mobile number to search \r\nfor your account";
            // 
            // title
            // 
            this.title.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.title.AutoSize = true;
            this.title.BackColor = System.Drawing.Color.Transparent;
            this.title.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title.ForeColor = System.Drawing.Color.White;
            this.title.Location = new System.Drawing.Point(37, 23);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(401, 39);
            this.title.TabIndex = 1;
            this.title.Text = "FIND YOUR ACCOUNT";
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
            this.minimize_btn.BackColor = System.Drawing.Color.Transparent;
            this.minimize_btn.Dock = System.Windows.Forms.DockStyle.Right;
            this.minimize_btn.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.minimize_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.minimize_btn.Image = global::VOVO.Properties.Resources.minimize_sign;
            this.minimize_btn.Location = new System.Drawing.Point(563, 0);
            this.minimize_btn.Name = "minimize_btn";
            this.minimize_btn.Size = new System.Drawing.Size(59, 40);
            this.minimize_btn.TabIndex = 0;
            this.minimize_btn.UseVisualStyleBackColor = false;
            this.minimize_btn.MouseEnter += new System.EventHandler(this.minimize_btn_MouseEnter);
            this.minimize_btn.MouseLeave += new System.EventHandler(this.minimize_btn_MouseLeave);
            // 
            // maximized_btn
            // 
            this.maximized_btn.BackColor = System.Drawing.Color.Transparent;
            this.maximized_btn.Dock = System.Windows.Forms.DockStyle.Right;
            this.maximized_btn.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.maximized_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.maximized_btn.Image = global::VOVO.Properties.Resources.squares;
            this.maximized_btn.Location = new System.Drawing.Point(622, 0);
            this.maximized_btn.Name = "maximized_btn";
            this.maximized_btn.Size = new System.Drawing.Size(57, 40);
            this.maximized_btn.TabIndex = 0;
            this.maximized_btn.UseVisualStyleBackColor = false;
            this.maximized_btn.Visible = false;
            this.maximized_btn.Click += new System.EventHandler(this.maximized_btn_Click);
            this.maximized_btn.MouseEnter += new System.EventHandler(this.maximized_btn_MouseEnter);
            this.maximized_btn.MouseLeave += new System.EventHandler(this.maximized_btn_MouseLeave);
            // 
            // maximize_btn
            // 
            this.maximize_btn.BackColor = System.Drawing.Color.Transparent;
            this.maximize_btn.Dock = System.Windows.Forms.DockStyle.Right;
            this.maximize_btn.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.maximize_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.maximize_btn.Image = global::VOVO.Properties.Resources.maximize;
            this.maximize_btn.Location = new System.Drawing.Point(679, 0);
            this.maximize_btn.Name = "maximize_btn";
            this.maximize_btn.Size = new System.Drawing.Size(60, 40);
            this.maximize_btn.TabIndex = 0;
            this.maximize_btn.UseVisualStyleBackColor = false;
            this.maximize_btn.Click += new System.EventHandler(this.maximize_btn_Click);
            this.maximize_btn.MouseEnter += new System.EventHandler(this.maximize_btn_MouseEnter);
            this.maximize_btn.MouseLeave += new System.EventHandler(this.maximize_btn_MouseLeave);
            // 
            // close_btn
            // 
            this.close_btn.BackColor = System.Drawing.Color.Transparent;
            this.close_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.close_btn.Dock = System.Windows.Forms.DockStyle.Right;
            this.close_btn.FlatAppearance.BorderSize = 0;
            this.close_btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.close_btn.Image = global::VOVO.Properties.Resources.reject;
            this.close_btn.Location = new System.Drawing.Point(739, 0);
            this.close_btn.Name = "close_btn";
            this.close_btn.Size = new System.Drawing.Size(61, 40);
            this.close_btn.TabIndex = 0;
            this.close_btn.UseVisualStyleBackColor = false;
            this.close_btn.Click += new System.EventHandler(this.close_btn_Click);
            this.close_btn.MouseEnter += new System.EventHandler(this.close_btn_MouseEnter);
            this.close_btn.MouseLeave += new System.EventHandler(this.close_btn_MouseLeave);
            // 
            // CustomerForgottenPaswordSearching
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CustomerForgottenPaswordSearching";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Customer Forgotten Pasword Searching";
            this.Load += new System.EventHandler(this.CustomerForgottenPasword_Load);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.top_border_panel.ResumeLayout(false);
            this.top_border_panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.icon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel top_border_panel;
        private System.Windows.Forms.Button minimize_btn;
        private System.Windows.Forms.Button maximized_btn;
        private System.Windows.Forms.Button maximize_btn;
        private System.Windows.Forms.Button close_btn;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label message;
        private System.Windows.Forms.Label title;
        private System.Windows.Forms.Button cancel_btn;
        private System.Windows.Forms.Button search_btn;
        private System.Windows.Forms.TextBox warning_message;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox icon;
        private System.Windows.Forms.TextBox search_tb;
    }
}