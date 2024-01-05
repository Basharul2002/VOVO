namespace VOVO
{
    partial class AdminSearch
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
            this.search_box_tb = new MetroFramework.Controls.MetroTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Operation_button = new MetroFramework.Controls.MetroButton();
            this.SuspendLayout();
            // 
            // search_box_tb
            // 
            // 
            // 
            // 
            this.search_box_tb.CustomButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.search_box_tb.CustomButton.Image = null;
            this.search_box_tb.CustomButton.Location = new System.Drawing.Point(222, 2);
            this.search_box_tb.CustomButton.Name = "";
            this.search_box_tb.CustomButton.Size = new System.Drawing.Size(35, 35);
            this.search_box_tb.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.search_box_tb.CustomButton.TabIndex = 1;
            this.search_box_tb.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.search_box_tb.CustomButton.UseSelectable = true;
            this.search_box_tb.CustomButton.Visible = false;
            this.search_box_tb.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.search_box_tb.Lines = new string[0];
            this.search_box_tb.Location = new System.Drawing.Point(23, 72);
            this.search_box_tb.MaxLength = 32767;
            this.search_box_tb.Name = "search_box_tb";
            this.search_box_tb.PasswordChar = '\0';
            this.search_box_tb.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.search_box_tb.SelectedText = "";
            this.search_box_tb.SelectionLength = 0;
            this.search_box_tb.SelectionStart = 0;
            this.search_box_tb.ShortcutsEnabled = true;
            this.search_box_tb.Size = new System.Drawing.Size(260, 40);
            this.search_box_tb.TabIndex = 0;
            this.search_box_tb.UseSelectable = true;
            this.search_box_tb.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.search_box_tb.WaterMarkFont = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(18, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(173, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "Enter Admin ID";
            // 
            // Operation_button
            // 
            this.Operation_button.Location = new System.Drawing.Point(202, 123);
            this.Operation_button.Name = "Operation_button";
            this.Operation_button.Size = new System.Drawing.Size(75, 23);
            this.Operation_button.TabIndex = 2;
            this.Operation_button.Text = "Search";
            this.Operation_button.UseSelectable = true;
            this.Operation_button.Click += new System.EventHandler(this.Operation_button_Click);
            // 
            // AdminSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(324, 169);
            this.Controls.Add(this.Operation_button);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.search_box_tb);
            this.Name = "AdminSearch";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroTextBox search_box_tb;
        private System.Windows.Forms.Label label1;
        private MetroFramework.Controls.MetroButton Operation_button;
    }
}