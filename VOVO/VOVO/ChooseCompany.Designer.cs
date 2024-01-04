namespace VOVO
{
    partial class ChooseCompany
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.company_name_combo_box = new System.Windows.Forms.ComboBox();
            this.next_button = new System.Windows.Forms.Button();
            this.back_button = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.branch_panel = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.branch_combo_box = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.branch_panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(61, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(326, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = "Choose a company";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(72, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(166, 25);
            this.label2.TabIndex = 0;
            this.label2.Text = "Company Name";
            // 
            // company_name_combo_box
            // 
            this.company_name_combo_box.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.company_name_combo_box.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.company_name_combo_box.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.company_name_combo_box.FormattingEnabled = true;
            this.company_name_combo_box.Location = new System.Drawing.Point(68, 48);
            this.company_name_combo_box.Name = "company_name_combo_box";
            this.company_name_combo_box.Size = new System.Drawing.Size(267, 32);
            this.company_name_combo_box.TabIndex = 1;
            this.company_name_combo_box.SelectedIndexChanged += new System.EventHandler(this.company_name_combo_box_SelectedIndexChanged);
            // 
            // next_button
            // 
            this.next_button.BackColor = System.Drawing.Color.OrangeRed;
            this.next_button.FlatAppearance.BorderSize = 0;
            this.next_button.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.next_button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.next_button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.next_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.next_button.ForeColor = System.Drawing.Color.White;
            this.next_button.Location = new System.Drawing.Point(231, 99);
            this.next_button.Margin = new System.Windows.Forms.Padding(2);
            this.next_button.Name = "next_button";
            this.next_button.Size = new System.Drawing.Size(68, 32);
            this.next_button.TabIndex = 4;
            this.next_button.Text = "Next";
            this.next_button.UseVisualStyleBackColor = false;
            this.next_button.Click += new System.EventHandler(this.next_button_Click);
            // 
            // back_button
            // 
            this.back_button.BackColor = System.Drawing.Color.LightCyan;
            this.back_button.FlatAppearance.BorderColor = System.Drawing.Color.LightCyan;
            this.back_button.FlatAppearance.BorderSize = 3;
            this.back_button.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.back_button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.back_button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.back_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.back_button.Location = new System.Drawing.Point(113, 99);
            this.back_button.Margin = new System.Windows.Forms.Padding(2);
            this.back_button.Name = "back_button";
            this.back_button.Size = new System.Drawing.Size(68, 32);
            this.back_button.TabIndex = 5;
            this.back_button.Text = "Back";
            this.back_button.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(448, 100);
            this.panel1.TabIndex = 6;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.back_button);
            this.panel2.Controls.Add(this.next_button);
            this.panel2.Controls.Add(this.company_name_combo_box);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 194);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(448, 150);
            this.panel2.TabIndex = 7;
            // 
            // branch_panel
            // 
            this.branch_panel.Controls.Add(this.branch_combo_box);
            this.branch_panel.Controls.Add(this.label3);
            this.branch_panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.branch_panel.Location = new System.Drawing.Point(0, 100);
            this.branch_panel.Name = "branch_panel";
            this.branch_panel.Size = new System.Drawing.Size(448, 94);
            this.branch_panel.TabIndex = 8;
            this.branch_panel.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(72, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(142, 25);
            this.label3.TabIndex = 0;
            this.label3.Text = "Branch Name";
            // 
            // branch_combo_box
            // 
            this.branch_combo_box.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.branch_combo_box.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.branch_combo_box.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.branch_combo_box.FormattingEnabled = true;
            this.branch_combo_box.Location = new System.Drawing.Point(68, 46);
            this.branch_combo_box.Name = "branch_combo_box";
            this.branch_combo_box.Size = new System.Drawing.Size(267, 32);
            this.branch_combo_box.TabIndex = 1;
            this.branch_combo_box.SelectedIndexChanged += new System.EventHandler(this.branch_name_combo_box_SelectedIndexChanged);
            // 
            // ChooseCompany
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.RosyBrown;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.branch_panel);
            this.Controls.Add(this.panel1);
            this.Name = "ChooseCompany";
            this.Size = new System.Drawing.Size(448, 346);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.branch_panel.ResumeLayout(false);
            this.branch_panel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox company_name_combo_box;
        private System.Windows.Forms.Button next_button;
        private System.Windows.Forms.Button back_button;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel branch_panel;
        private System.Windows.Forms.ComboBox branch_combo_box;
        private System.Windows.Forms.Label label3;
    }
}
