namespace VOVO
{
    partial class HomePageForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HomePageForm));
            this.top_border_panel = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.icon = new System.Windows.Forms.PictureBox();
            this.minimize_btn = new System.Windows.Forms.Button();
            this.close_btn = new System.Windows.Forms.Button();
            this.homepage_panel = new System.Windows.Forms.Panel();
            this.employee_btn = new System.Windows.Forms.Button();
            this.customer_btn = new System.Windows.Forms.Button();
            this.employee_picture_box = new System.Windows.Forms.PictureBox();
            this.customer_picture_box = new System.Windows.Forms.PictureBox();
            this.top_border_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.icon)).BeginInit();
            this.homepage_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.employee_picture_box)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customer_picture_box)).BeginInit();
            this.SuspendLayout();
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
            this.top_border_panel.Margin = new System.Windows.Forms.Padding(0);
            this.top_border_panel.Name = "top_border_panel";
            this.top_border_panel.Size = new System.Drawing.Size(730, 37);
            this.top_border_panel.TabIndex = 0;
            this.top_border_panel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.border_panel_MouseDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(44, 0);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(0, 12, 0, 0);
            this.label2.Size = new System.Drawing.Size(52, 29);
            this.label2.TabIndex = 3;
            this.label2.Text = "VOVO";
            // 
            // icon
            // 
            this.icon.BackColor = System.Drawing.Color.Transparent;
            this.icon.BackgroundImage = global::VOVO.Properties.Resources.Home_Page_Text_BG;
            this.icon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.icon.Dock = System.Windows.Forms.DockStyle.Left;
            this.icon.Image = global::VOVO.Properties.Resources.Icon;
            this.icon.Location = new System.Drawing.Point(0, 0);
            this.icon.Margin = new System.Windows.Forms.Padding(0);
            this.icon.Name = "icon";
            this.icon.Size = new System.Drawing.Size(44, 37);
            this.icon.TabIndex = 0;
            this.icon.TabStop = false;
            // 
            // minimize_btn
            // 
            this.minimize_btn.BackColor = System.Drawing.Color.Transparent;
            this.minimize_btn.Dock = System.Windows.Forms.DockStyle.Right;
            this.minimize_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.minimize_btn.ForeColor = System.Drawing.Color.DimGray;
            this.minimize_btn.Image = global::VOVO.Properties.Resources.minimize_sign;
            this.minimize_btn.Location = new System.Drawing.Point(628, 0);
            this.minimize_btn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.minimize_btn.Name = "minimize_btn";
            this.minimize_btn.Size = new System.Drawing.Size(51, 37);
            this.minimize_btn.TabIndex = 0;
            this.minimize_btn.UseVisualStyleBackColor = false;
            this.minimize_btn.Click += new System.EventHandler(this.minimize_btn_Click);
            // 
            // close_btn
            // 
            this.close_btn.BackColor = System.Drawing.Color.Transparent;
            this.close_btn.Dock = System.Windows.Forms.DockStyle.Right;
            this.close_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.close_btn.ForeColor = System.Drawing.Color.DarkRed;
            this.close_btn.Image = global::VOVO.Properties.Resources.reject;
            this.close_btn.Location = new System.Drawing.Point(679, 0);
            this.close_btn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.close_btn.Name = "close_btn";
            this.close_btn.Size = new System.Drawing.Size(51, 37);
            this.close_btn.TabIndex = 0;
            this.close_btn.UseVisualStyleBackColor = false;
            this.close_btn.Click += new System.EventHandler(this.close_btn_Click);
            this.close_btn.MouseEnter += new System.EventHandler(this.close_btn_MouseEnter);
            this.close_btn.MouseLeave += new System.EventHandler(this.close_btn_MouseLeave);
            // 
            // homepage_panel
            // 
            this.homepage_panel.BackColor = System.Drawing.Color.MistyRose;
            this.homepage_panel.Controls.Add(this.employee_btn);
            this.homepage_panel.Controls.Add(this.customer_btn);
            this.homepage_panel.Controls.Add(this.employee_picture_box);
            this.homepage_panel.Controls.Add(this.customer_picture_box);
            this.homepage_panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.homepage_panel.Location = new System.Drawing.Point(0, 37);
            this.homepage_panel.Margin = new System.Windows.Forms.Padding(0);
            this.homepage_panel.Name = "homepage_panel";
            this.homepage_panel.Size = new System.Drawing.Size(730, 392);
            this.homepage_panel.TabIndex = 0;
            // 
            // employee_btn
            // 
            this.employee_btn.BackColor = System.Drawing.Color.Transparent;
            this.employee_btn.FlatAppearance.BorderColor = System.Drawing.Color.Coral;
            this.employee_btn.FlatAppearance.BorderSize = 4;
            this.employee_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.employee_btn.Font = new System.Drawing.Font("Microsoft YaHei UI", 20F, System.Drawing.FontStyle.Bold);
            this.employee_btn.ForeColor = System.Drawing.Color.OrangeRed;
            this.employee_btn.Location = new System.Drawing.Point(398, 251);
            this.employee_btn.Name = "employee_btn";
            this.employee_btn.Size = new System.Drawing.Size(187, 55);
            this.employee_btn.TabIndex = 3;
            this.employee_btn.Text = "Employee";
            this.employee_btn.UseVisualStyleBackColor = false;
            this.employee_btn.Click += new System.EventHandler(this.employee_btn_Click);
            this.employee_btn.MouseEnter += new System.EventHandler(this.employee_btn_MouseEnter);
            this.employee_btn.MouseLeave += new System.EventHandler(this.employee_btn_MouseLeave);
            // 
            // customer_btn
            // 
            this.customer_btn.BackColor = System.Drawing.Color.Transparent;
            this.customer_btn.FlatAppearance.BorderColor = System.Drawing.Color.Coral;
            this.customer_btn.FlatAppearance.BorderSize = 4;
            this.customer_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.customer_btn.Font = new System.Drawing.Font("Microsoft YaHei UI", 20F, System.Drawing.FontStyle.Bold);
            this.customer_btn.ForeColor = System.Drawing.Color.OrangeRed;
            this.customer_btn.Location = new System.Drawing.Point(103, 251);
            this.customer_btn.Name = "customer_btn";
            this.customer_btn.Size = new System.Drawing.Size(187, 55);
            this.customer_btn.TabIndex = 2;
            this.customer_btn.Text = "Customer";
            this.customer_btn.UseVisualStyleBackColor = false;
            this.customer_btn.Click += new System.EventHandler(this.customer_btn_Click);
            this.customer_btn.MouseEnter += new System.EventHandler(this.customer_btn_MouseEnter);
            this.customer_btn.MouseLeave += new System.EventHandler(this.customer_btn_MouseLeave);
            // 
            // employee_picture_box
            // 
            this.employee_picture_box.Image = global::VOVO.Properties.Resources.Employee_Icon;
            this.employee_picture_box.Location = new System.Drawing.Point(412, 96);
            this.employee_picture_box.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.employee_picture_box.Name = "employee_picture_box";
            this.employee_picture_box.Size = new System.Drawing.Size(155, 137);
            this.employee_picture_box.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.employee_picture_box.TabIndex = 0;
            this.employee_picture_box.TabStop = false;
            // 
            // customer_picture_box
            // 
            this.customer_picture_box.Image = global::VOVO.Properties.Resources.Customer_icon;
            this.customer_picture_box.Location = new System.Drawing.Point(120, 96);
            this.customer_picture_box.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.customer_picture_box.Name = "customer_picture_box";
            this.customer_picture_box.Size = new System.Drawing.Size(155, 137);
            this.customer_picture_box.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.customer_picture_box.TabIndex = 0;
            this.customer_picture_box.TabStop = false;
            // 
            // HomePageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(730, 429);
            this.Controls.Add(this.homepage_panel);
            this.Controls.Add(this.top_border_panel);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "HomePageForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HomeForm";
            this.top_border_panel.ResumeLayout(false);
            this.top_border_panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.icon)).EndInit();
            this.homepage_panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.employee_picture_box)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customer_picture_box)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel homepage_panel;
        private System.Windows.Forms.Panel top_border_panel;
        private System.Windows.Forms.Button close_btn;
        private System.Windows.Forms.Button minimize_btn;
        private System.Windows.Forms.PictureBox icon;
        private System.Windows.Forms.PictureBox customer_picture_box;
        private System.Windows.Forms.PictureBox employee_picture_box;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button customer_btn;
        private System.Windows.Forms.Button employee_btn;
    }
}