namespace VOVO
{
    partial class CustomAlertBox
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
            this.components = new System.ComponentModel.Container();
            this.message_text = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.icon_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // message_text
            // 
            this.message_text.AutoSize = true;
            this.message_text.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.message_text.Location = new System.Drawing.Point(30, 28);
            this.message_text.Name = "message_text";
            this.message_text.Size = new System.Drawing.Size(137, 25);
            this.message_text.TabIndex = 0;
            this.message_text.Text = "Message Text";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // icon_button
            // 
            this.icon_button.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.icon_button.FlatAppearance.BorderSize = 2;
            this.icon_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.icon_button.Location = new System.Drawing.Point(359, 12);
            this.icon_button.Name = "icon_button";
            this.icon_button.Size = new System.Drawing.Size(54, 48);
            this.icon_button.TabIndex = 2;
            this.icon_button.UseVisualStyleBackColor = true;
            // 
            // CustomAlertBox
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Coral;
            this.ClientSize = new System.Drawing.Size(436, 79);
            this.Controls.Add(this.icon_button);
            this.Controls.Add(this.message_text);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CustomAlertBox";
            this.Text = "CustomAlertBox";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label message_text;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button icon_button;
    }
}