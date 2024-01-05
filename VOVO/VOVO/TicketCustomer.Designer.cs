namespace VOVO
{
    partial class TicketCustomer
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.result_showing_panel = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 153);
            this.panel1.TabIndex = 0;
            // 
            // result_showing_panel
            // 
            this.result_showing_panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.result_showing_panel.Location = new System.Drawing.Point(0, 153);
            this.result_showing_panel.Name = "result_showing_panel";
            this.result_showing_panel.Size = new System.Drawing.Size(800, 297);
            this.result_showing_panel.TabIndex = 1;
            // 
            // TicketCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.result_showing_panel);
            this.Controls.Add(this.panel1);
            this.Name = "TicketCustomer";
            this.Text = "TicketCustomer";
            this.SizeChanged += new System.EventHandler(this.TicketCustomer_SizeChanged);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel result_showing_panel;
    }
}