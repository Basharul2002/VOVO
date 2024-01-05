namespace VOVO
{
    partial class BusInformation
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.data_showing_panel = new System.Windows.Forms.FlowLayoutPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.update_button = new System.Windows.Forms.Button();
            this.delete_button = new System.Windows.Forms.Button();
            this.search_button = new System.Windows.Forms.Button();
            this.all_info_button = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.double_decker_bus = new System.Windows.Forms.Label();
            this.non_ac_bus = new System.Windows.Forms.Label();
            this.ac_bus = new System.Windows.Forms.Label();
            this.total_bus = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.title = new System.Windows.Forms.Label();
            this.busInformationBindingSource = new System.Windows.Forms.BindingSource(this.components);
           this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.busInformationBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.data_showing_panel);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(517, 423);
            this.panel1.TabIndex = 0;
            // 
            // data_showing_panel
            // 
            this.data_showing_panel.AutoSize = true;
            this.data_showing_panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.data_showing_panel.Location = new System.Drawing.Point(0, 193);
            this.data_showing_panel.Name = "data_showing_panel";
            this.data_showing_panel.Size = new System.Drawing.Size(517, 230);
            this.data_showing_panel.TabIndex = 4;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.update_button);
            this.panel3.Controls.Add(this.delete_button);
            this.panel3.Controls.Add(this.search_button);
            this.panel3.Controls.Add(this.all_info_button);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 131);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(517, 62);
            this.panel3.TabIndex = 3;
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
            this.update_button.Location = new System.Drawing.Point(377, 17);
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
            this.delete_button.Location = new System.Drawing.Point(263, 17);
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
            this.search_button.BackColor = System.Drawing.Color.OrangeRed;
            this.search_button.FlatAppearance.BorderSize = 0;
            this.search_button.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.search_button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.search_button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.search_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.search_button.ForeColor = System.Drawing.Color.White;
            this.search_button.Location = new System.Drawing.Point(160, 17);
            this.search_button.Margin = new System.Windows.Forms.Padding(2);
            this.search_button.Name = "search_button";
            this.search_button.Size = new System.Drawing.Size(68, 32);
            this.search_button.TabIndex = 4;
            this.search_button.Text = "Search";
            this.search_button.UseVisualStyleBackColor = false;
            this.search_button.Click += new System.EventHandler(this.search_button_Click);
            // 
            // all_info_button
            // 
            this.all_info_button.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.all_info_button.BackColor = System.Drawing.Color.OrangeRed;
            this.all_info_button.FlatAppearance.BorderSize = 0;
            this.all_info_button.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.all_info_button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.all_info_button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.all_info_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.all_info_button.ForeColor = System.Drawing.Color.White;
            this.all_info_button.Location = new System.Drawing.Point(61, 17);
            this.all_info_button.Margin = new System.Windows.Forms.Padding(2);
            this.all_info_button.Name = "all_info_button";
            this.all_info_button.Size = new System.Drawing.Size(68, 32);
            this.all_info_button.TabIndex = 4;
            this.all_info_button.Text = "All";
            this.all_info_button.UseVisualStyleBackColor = false;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.double_decker_bus);
            this.panel4.Controls.Add(this.non_ac_bus);
            this.panel4.Controls.Add(this.ac_bus);
            this.panel4.Controls.Add(this.total_bus);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 65);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(517, 66);
            this.panel4.TabIndex = 2;
            // 
            // double_decker_bus
            // 
            this.double_decker_bus.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.double_decker_bus.AutoSize = true;
            this.double_decker_bus.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.double_decker_bus.Location = new System.Drawing.Point(361, 32);
            this.double_decker_bus.Name = "double_decker_bus";
            this.double_decker_bus.Size = new System.Drawing.Size(128, 21);
            this.double_decker_bus.TabIndex = 0;
            this.double_decker_bus.Text = "Double Decker: 0";
            // 
            // non_ac_bus
            // 
            this.non_ac_bus.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.non_ac_bus.AutoSize = true;
            this.non_ac_bus.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.non_ac_bus.Location = new System.Drawing.Point(182, 32);
            this.non_ac_bus.Name = "non_ac_bus";
            this.non_ac_bus.Size = new System.Drawing.Size(86, 21);
            this.non_ac_bus.TabIndex = 0;
            this.non_ac_bus.Text = "NON AC: 0";
            // 
            // ac_bus
            // 
            this.ac_bus.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ac_bus.AutoSize = true;
            this.ac_bus.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ac_bus.Location = new System.Drawing.Point(17, 32);
            this.ac_bus.Name = "ac_bus";
            this.ac_bus.Size = new System.Drawing.Size(46, 21);
            this.ac_bus.TabIndex = 0;
            this.ac_bus.Text = "AC: 0";
            // 
            // total_bus
            // 
            this.total_bus.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.total_bus.AutoSize = true;
            this.total_bus.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.total_bus.Location = new System.Drawing.Point(13, 3);
            this.total_bus.Name = "total_bus";
            this.total_bus.Size = new System.Drawing.Size(109, 28);
            this.total_bus.TabIndex = 0;
            this.total_bus.Text = "Total Bus: 0";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.title);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(517, 65);
            this.panel2.TabIndex = 0;
            // 
            // title
            // 
            this.title.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.title.AutoSize = true;
            this.title.Font = new System.Drawing.Font("Microsoft Tai Le", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title.Location = new System.Drawing.Point(130, 12);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(256, 44);
            this.title.TabIndex = 0;
            this.title.Text = "Bus Information";
            // 
            // busInformationBindingSource
            // 
            this.busInformationBindingSource.DataMember = "Bus Information";
           // 
            // bus_InformationTableAdapter
            // 
            // 
            // BusInformation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "BusInformation";
            this.Size = new System.Drawing.Size(517, 423);
            this.Load += new System.EventHandler(this.BusInformation_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.busInformationBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label total_bus;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label title;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button update_button;
        private System.Windows.Forms.Button delete_button;
        private System.Windows.Forms.Button search_button;
        private System.Windows.Forms.Button all_info_button;
        private System.Windows.Forms.BindingSource busInformationBindingSource;
        private System.Windows.Forms.Label double_decker_bus;
        private System.Windows.Forms.Label non_ac_bus;
        private System.Windows.Forms.Label ac_bus;
        private System.Windows.Forms.FlowLayoutPanel data_showing_panel;
    }
}
