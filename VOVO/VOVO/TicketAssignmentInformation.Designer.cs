namespace VOVO
{
    partial class TicketAssignmentInformation
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
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.superviosr_combo_box = new System.Windows.Forms.ComboBox();
            this.driver_combo_box = new System.Windows.Forms.ComboBox();
            this.conductor_combo_box = new System.Windows.Forms.ComboBox();
            this.register_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(49, 260);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "Conductor";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(49, 197);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 20);
            this.label3.TabIndex = 9;
            this.label3.Text = "Driver";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(49, 136);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 20);
            this.label1.TabIndex = 10;
            this.label1.Text = "Supervisor";
            // 
            // superviosr_combo_box
            // 
            this.superviosr_combo_box.BackColor = System.Drawing.SystemColors.ControlLight;
            this.superviosr_combo_box.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.superviosr_combo_box.FormattingEnabled = true;
            this.superviosr_combo_box.Location = new System.Drawing.Point(176, 130);
            this.superviosr_combo_box.Name = "superviosr_combo_box";
            this.superviosr_combo_box.Size = new System.Drawing.Size(267, 32);
            this.superviosr_combo_box.TabIndex = 13;
            // 
            // driver_combo_box
            // 
            this.driver_combo_box.BackColor = System.Drawing.SystemColors.ControlLight;
            this.driver_combo_box.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.driver_combo_box.FormattingEnabled = true;
            this.driver_combo_box.Location = new System.Drawing.Point(176, 194);
            this.driver_combo_box.Name = "driver_combo_box";
            this.driver_combo_box.Size = new System.Drawing.Size(267, 32);
            this.driver_combo_box.TabIndex = 14;
            // 
            // conductor_combo_box
            // 
            this.conductor_combo_box.BackColor = System.Drawing.SystemColors.ControlLight;
            this.conductor_combo_box.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.conductor_combo_box.FormattingEnabled = true;
            this.conductor_combo_box.Location = new System.Drawing.Point(176, 255);
            this.conductor_combo_box.Name = "conductor_combo_box";
            this.conductor_combo_box.Size = new System.Drawing.Size(267, 32);
            this.conductor_combo_box.TabIndex = 15;
            // 
            // register_button
            // 
            this.register_button.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.register_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.register_button.ForeColor = System.Drawing.Color.White;
            this.register_button.Location = new System.Drawing.Point(299, 359);
            this.register_button.Name = "register_button";
            this.register_button.Size = new System.Drawing.Size(144, 43);
            this.register_button.TabIndex = 16;
            this.register_button.Text = "Register";
            this.register_button.UseVisualStyleBackColor = false;
            this.register_button.Click += new System.EventHandler(this.register_button_Click);
            // 
            // TicketAssignmentInformation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.register_button);
            this.Controls.Add(this.conductor_combo_box);
            this.Controls.Add(this.driver_combo_box);
            this.Controls.Add(this.superviosr_combo_box);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Name = "TicketAssignmentInformation";
            this.Size = new System.Drawing.Size(510, 467);
            this.Load += new System.EventHandler(this.TicketAssignmentInformation_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox superviosr_combo_box;
        private System.Windows.Forms.ComboBox driver_combo_box;
        private System.Windows.Forms.ComboBox conductor_combo_box;
        private System.Windows.Forms.Button register_button;
    }
}
