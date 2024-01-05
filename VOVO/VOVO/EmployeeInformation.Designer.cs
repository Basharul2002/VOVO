namespace VOVO
{
    partial class EmployeeInformation
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.title = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.update_button = new System.Windows.Forms.Button();
            this.delete_button = new System.Windows.Forms.Button();
            this.search_button = new System.Windows.Forms.Button();
            this.page_number_panel = new System.Windows.Forms.Panel();
            this.page_number = new System.Windows.Forms.Label();
            this.total_employee = new System.Windows.Forms.Label();
            this.previous_button = new System.Windows.Forms.Button();
            this.next_button = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.data_showing_panel = new System.Windows.Forms.FlowLayoutPanel();
            this.no_data_panel = new System.Windows.Forms.Panel();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel6.SuspendLayout();
            this.page_number_panel.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.title);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(549, 65);
            this.panel2.TabIndex = 8;
            // 
            // title
            // 
            this.title.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.title.AutoSize = true;
            this.title.Font = new System.Drawing.Font("Microsoft Tai Le", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title.Location = new System.Drawing.Point(99, 12);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(349, 44);
            this.title.TabIndex = 0;
            this.title.Text = "Customer Information";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.panel6);
            this.panel4.Controls.Add(this.page_number_panel);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 100);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(549, 55);
            this.panel4.TabIndex = 10;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.update_button);
            this.panel6.Controls.Add(this.delete_button);
            this.panel6.Controls.Add(this.search_button);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Margin = new System.Windows.Forms.Padding(0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(369, 55);
            this.panel6.TabIndex = 1;
            // 
            // update_button
            // 
            this.update_button.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.update_button.BackColor = System.Drawing.Color.OrangeRed;
            this.update_button.FlatAppearance.BorderSize = 0;
            this.update_button.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.update_button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.update_button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.update_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.update_button.ForeColor = System.Drawing.Color.White;
            this.update_button.Location = new System.Drawing.Point(264, 11);
            this.update_button.Margin = new System.Windows.Forms.Padding(2);
            this.update_button.Name = "update_button";
            this.update_button.Size = new System.Drawing.Size(68, 32);
            this.update_button.TabIndex = 5;
            this.update_button.Text = "Update";
            this.update_button.UseVisualStyleBackColor = false;
            // 
            // delete_button
            // 
            this.delete_button.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.delete_button.BackColor = System.Drawing.Color.OrangeRed;
            this.delete_button.FlatAppearance.BorderSize = 0;
            this.delete_button.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.delete_button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.delete_button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.delete_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.delete_button.ForeColor = System.Drawing.Color.White;
            this.delete_button.Location = new System.Drawing.Point(152, 11);
            this.delete_button.Margin = new System.Windows.Forms.Padding(2);
            this.delete_button.Name = "delete_button";
            this.delete_button.Size = new System.Drawing.Size(68, 32);
            this.delete_button.TabIndex = 6;
            this.delete_button.Text = "Delete";
            this.delete_button.UseVisualStyleBackColor = false;
            // 
            // search_button
            // 
            this.search_button.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.search_button.AutoSize = true;
            this.search_button.BackColor = System.Drawing.Color.OrangeRed;
            this.search_button.FlatAppearance.BorderSize = 0;
            this.search_button.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.search_button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.search_button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.search_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.search_button.ForeColor = System.Drawing.Color.White;
            this.search_button.Location = new System.Drawing.Point(37, 11);
            this.search_button.Margin = new System.Windows.Forms.Padding(2);
            this.search_button.Name = "search_button";
            this.search_button.Size = new System.Drawing.Size(69, 32);
            this.search_button.TabIndex = 7;
            this.search_button.Text = "Search";
            this.search_button.UseVisualStyleBackColor = false;
            // 
            // page_number_panel
            // 
            this.page_number_panel.Controls.Add(this.page_number);
            this.page_number_panel.Dock = System.Windows.Forms.DockStyle.Right;
            this.page_number_panel.Location = new System.Drawing.Point(369, 0);
            this.page_number_panel.Name = "page_number_panel";
            this.page_number_panel.Size = new System.Drawing.Size(180, 55);
            this.page_number_panel.TabIndex = 0;
            // 
            // page_number
            // 
            this.page_number.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.page_number.AutoSize = true;
            this.page_number.Font = new System.Drawing.Font("Montserrat", 10F);
            this.page_number.Location = new System.Drawing.Point(17, 37);
            this.page_number.Margin = new System.Windows.Forms.Padding(0);
            this.page_number.Name = "page_number";
            this.page_number.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.page_number.Size = new System.Drawing.Size(163, 18);
            this.page_number.TabIndex = 1;
            this.page_number.Text = "Page Number 1 of 10";
            // 
            // total_employee
            // 
            this.total_employee.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.total_employee.AutoSize = true;
            this.total_employee.Font = new System.Drawing.Font("Montserrat", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.total_employee.Location = new System.Drawing.Point(-4, 3);
            this.total_employee.Margin = new System.Windows.Forms.Padding(0);
            this.total_employee.Name = "total_employee";
            this.total_employee.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.total_employee.Size = new System.Drawing.Size(608, 27);
            this.total_employee.TabIndex = 0;
            this.total_employee.Text = "Total Customer: 205      Male: 120      Female: 70      Others: 35";
            // 
            // previous_button
            // 
            this.previous_button.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.previous_button.AutoSize = true;
            this.previous_button.BackColor = System.Drawing.Color.OrangeRed;
            this.previous_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.previous_button.FlatAppearance.BorderSize = 0;
            this.previous_button.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.previous_button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.previous_button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.previous_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.previous_button.ForeColor = System.Drawing.Color.White;
            this.previous_button.Location = new System.Drawing.Point(176, 18);
            this.previous_button.Margin = new System.Windows.Forms.Padding(2);
            this.previous_button.Name = "previous_button";
            this.previous_button.Size = new System.Drawing.Size(81, 32);
            this.previous_button.TabIndex = 4;
            this.previous_button.Text = "Previous";
            this.previous_button.UseVisualStyleBackColor = false;
            this.previous_button.Click += new System.EventHandler(this.prevPageButton_Click);
            // 
            // next_button
            // 
            this.next_button.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.next_button.AutoSize = true;
            this.next_button.BackColor = System.Drawing.Color.OrangeRed;
            this.next_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.next_button.FlatAppearance.BorderSize = 0;
            this.next_button.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.next_button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.next_button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.next_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.next_button.ForeColor = System.Drawing.Color.White;
            this.next_button.Location = new System.Drawing.Point(284, 18);
            this.next_button.Margin = new System.Windows.Forms.Padding(2);
            this.next_button.Name = "next_button";
            this.next_button.Size = new System.Drawing.Size(69, 32);
            this.next_button.TabIndex = 4;
            this.next_button.Text = "Next";
            this.next_button.UseVisualStyleBackColor = false;
            this.next_button.Click += new System.EventHandler(this.nextPageButton_Click);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.previous_button);
            this.panel5.Controls.Add(this.next_button);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(0, 483);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(549, 70);
            this.panel5.TabIndex = 9;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.total_employee);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 65);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(549, 35);
            this.panel1.TabIndex = 10;
            // 
            // data_showing_panel
            // 
            this.data_showing_panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.data_showing_panel.Location = new System.Drawing.Point(0, 155);
            this.data_showing_panel.Margin = new System.Windows.Forms.Padding(0);
            this.data_showing_panel.Name = "data_showing_panel";
            this.data_showing_panel.Size = new System.Drawing.Size(549, 328);
            this.data_showing_panel.TabIndex = 11;
            // 
            // no_data_panel
            // 
            this.no_data_panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.no_data_panel.Location = new System.Drawing.Point(0, 155);
            this.no_data_panel.Name = "no_data_panel";
            this.no_data_panel.Size = new System.Drawing.Size(549, 328);
            this.no_data_panel.TabIndex = 0;
            // 
            // EmployeeInformation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.data_showing_panel);
            this.Controls.Add(this.no_data_panel);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel2);
            this.Name = "EmployeeInformation";
            this.Size = new System.Drawing.Size(549, 553);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.page_number_panel.ResumeLayout(false);
            this.page_number_panel.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label title;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label total_employee;
        private System.Windows.Forms.Button previous_button;
        private System.Windows.Forms.Button next_button;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel page_number_panel;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button update_button;
        private System.Windows.Forms.Button delete_button;
        private System.Windows.Forms.Button search_button;
        private System.Windows.Forms.Label page_number;
        private System.Windows.Forms.FlowLayoutPanel data_showing_panel;
        private System.Windows.Forms.Panel no_data_panel;
    }
}
