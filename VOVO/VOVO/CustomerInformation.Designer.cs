namespace VOVO
{
    partial class CustomerInformation
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
            this.total_customer = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.update_button = new System.Windows.Forms.Button();
            this.delete_button = new System.Windows.Forms.Button();
            this.search_button = new System.Windows.Forms.Button();
            this.panel6 = new System.Windows.Forms.Panel();
            this.page_number = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.data_showing_panel = new System.Windows.Forms.FlowLayoutPanel();
            this.loadingSpinnerPictureBox = new System.Windows.Forms.PictureBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.previous_button = new System.Windows.Forms.Button();
            this.next_button = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.loadingSpinnerPictureBox)).BeginInit();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.title);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(610, 65);
            this.panel2.TabIndex = 1;
            // 
            // title
            // 
            this.title.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.title.AutoSize = true;
            this.title.Font = new System.Drawing.Font("Microsoft Tai Le", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title.Location = new System.Drawing.Point(130, 12);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(349, 44);
            this.title.TabIndex = 0;
            this.title.Text = "Customer Information";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.total_customer);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 65);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(610, 32);
            this.panel4.TabIndex = 3;
            // 
            // total_customer
            // 
            this.total_customer.AutoSize = true;
            this.total_customer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.total_customer.Font = new System.Drawing.Font("Montserrat", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.total_customer.Location = new System.Drawing.Point(0, 0);
            this.total_customer.Margin = new System.Windows.Forms.Padding(0);
            this.total_customer.Name = "total_customer";
            this.total_customer.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.total_customer.Size = new System.Drawing.Size(608, 27);
            this.total_customer.TabIndex = 0;
            this.total_customer.Text = "Total Customer: 205      Male: 120      Female: 70      Others: 35";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel7);
            this.panel3.Controls.Add(this.panel6);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 97);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(610, 62);
            this.panel3.TabIndex = 4;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.update_button);
            this.panel7.Controls.Add(this.delete_button);
            this.panel7.Controls.Add(this.search_button);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Margin = new System.Windows.Forms.Padding(0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(448, 62);
            this.panel7.TabIndex = 6;
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
            this.update_button.Location = new System.Drawing.Point(332, 17);
            this.update_button.Margin = new System.Windows.Forms.Padding(2);
            this.update_button.Name = "update_button";
            this.update_button.Size = new System.Drawing.Size(68, 32);
            this.update_button.TabIndex = 4;
            this.update_button.Text = "Update";
            this.update_button.UseVisualStyleBackColor = false;
            this.update_button.Click += new System.EventHandler(this.update_button_Click);
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
            this.delete_button.Location = new System.Drawing.Point(220, 17);
            this.delete_button.Margin = new System.Windows.Forms.Padding(2);
            this.delete_button.Name = "delete_button";
            this.delete_button.Size = new System.Drawing.Size(68, 32);
            this.delete_button.TabIndex = 4;
            this.delete_button.Text = "Delete";
            this.delete_button.UseVisualStyleBackColor = false;
            this.delete_button.Click += new System.EventHandler(this.delete_button_Click);
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
            this.search_button.Location = new System.Drawing.Point(105, 17);
            this.search_button.Margin = new System.Windows.Forms.Padding(2);
            this.search_button.Name = "search_button";
            this.search_button.Size = new System.Drawing.Size(69, 32);
            this.search_button.TabIndex = 4;
            this.search_button.Text = "Search";
            this.search_button.UseVisualStyleBackColor = false;
            this.search_button.Click += new System.EventHandler(this.search_button_Click);
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.page_number);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel6.Location = new System.Drawing.Point(448, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(162, 62);
            this.panel6.TabIndex = 5;
            // 
            // page_number
            // 
            this.page_number.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.page_number.AutoSize = true;
            this.page_number.Font = new System.Drawing.Font("Montserrat", 10F);
            this.page_number.Location = new System.Drawing.Point(6, 41);
            this.page_number.Name = "page_number";
            this.page_number.Size = new System.Drawing.Size(153, 18);
            this.page_number.TabIndex = 0;
            this.page_number.Text = "Page Number 1 of 10";
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.data_showing_panel);
            this.panel1.Controls.Add(this.loadingSpinnerPictureBox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 159);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(610, 259);
            this.panel1.TabIndex = 6;
            // 
            // data_showing_panel
            // 
            this.data_showing_panel.AutoScroll = true;
            this.data_showing_panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.data_showing_panel.Location = new System.Drawing.Point(0, 0);
            this.data_showing_panel.Name = "data_showing_panel";
            this.data_showing_panel.Size = new System.Drawing.Size(610, 259);
            this.data_showing_panel.TabIndex = 2;
            // 
            // loadingSpinnerPictureBox
            // 
            this.loadingSpinnerPictureBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.loadingSpinnerPictureBox.Image = global::VOVO.Properties.Resources.Loading1;
            this.loadingSpinnerPictureBox.Location = new System.Drawing.Point(114, 50);
            this.loadingSpinnerPictureBox.Name = "loadingSpinnerPictureBox";
            this.loadingSpinnerPictureBox.Size = new System.Drawing.Size(350, 150);
            this.loadingSpinnerPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.loadingSpinnerPictureBox.TabIndex = 1;
            this.loadingSpinnerPictureBox.TabStop = false;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.previous_button);
            this.panel5.Controls.Add(this.next_button);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(0, 418);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(610, 70);
            this.panel5.TabIndex = 1;
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
            this.previous_button.Location = new System.Drawing.Point(207, 18);
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
            this.next_button.Location = new System.Drawing.Point(315, 18);
            this.next_button.Margin = new System.Windows.Forms.Padding(2);
            this.next_button.Name = "next_button";
            this.next_button.Size = new System.Drawing.Size(69, 32);
            this.next_button.TabIndex = 4;
            this.next_button.Text = "Next";
            this.next_button.UseVisualStyleBackColor = false;
            this.next_button.Click += new System.EventHandler(this.nextPageButton_Click);
            // 
            // CustomerInformation
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoScroll = true;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.Name = "CustomerInformation";
            this.Size = new System.Drawing.Size(610, 488);
            this.Load += new System.EventHandler(this.CustomerInformation_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.loadingSpinnerPictureBox)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label title;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label total_customer;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button update_button;
        private System.Windows.Forms.Button delete_button;
        private System.Windows.Forms.Button search_button;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button previous_button;
        private System.Windows.Forms.Button next_button;
        private System.Windows.Forms.Label page_number;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.PictureBox loadingSpinnerPictureBox;
        private System.Windows.Forms.FlowLayoutPanel data_showing_panel;
    }
}
