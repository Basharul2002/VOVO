namespace VOVO
{
    partial class SearchingResult
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
            this.total_match_result = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.showing_result_panel = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // total_match_result
            // 
            this.total_match_result.AutoSize = true;
            this.total_match_result.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.total_match_result.Location = new System.Drawing.Point(12, 38);
            this.total_match_result.Name = "total_match_result";
            this.total_match_result.Size = new System.Drawing.Size(196, 25);
            this.total_match_result.TabIndex = 1;
            this.total_match_result.Text = "Total Match Result: 0";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.total_match_result);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(634, 89);
            this.panel1.TabIndex = 3;
            // 
            // showing_result_panel
            // 
            this.showing_result_panel.AutoScroll = true;
            this.showing_result_panel.AutoSize = true;
            this.showing_result_panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.showing_result_panel.Location = new System.Drawing.Point(0, 89);
            this.showing_result_panel.Name = "showing_result_panel";
            this.showing_result_panel.Size = new System.Drawing.Size(634, 208);
            this.showing_result_panel.TabIndex = 2;
            // 
            // SearchingResult
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.showing_result_panel);
            this.Controls.Add(this.panel1);
            this.Name = "SearchingResult";
            this.Size = new System.Drawing.Size(634, 297);
            this.Load += new System.EventHandler(this.SearchingResult_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label total_match_result;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel showing_result_panel;
    }
}
