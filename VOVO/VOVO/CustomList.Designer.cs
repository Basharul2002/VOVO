namespace VOVO
{
    partial class CustomList
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
            this.custom_list = new System.Windows.Forms.Button();
            this.title_data = new System.Windows.Forms.Label();
            this.message_data = new System.Windows.Forms.Label();
            this.image_box = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.image_box)).BeginInit();
            this.SuspendLayout();
            // 
            // custom_list
            // 
            this.custom_list.AutoSize = true;
            this.custom_list.Dock = System.Windows.Forms.DockStyle.Fill;
            this.custom_list.Location = new System.Drawing.Point(0, 0);
            this.custom_list.Name = "custom_list";
            this.custom_list.Size = new System.Drawing.Size(749, 107);
            this.custom_list.TabIndex = 0;
            this.custom_list.UseVisualStyleBackColor = true;
            // 
            // title_data
            // 
            this.title_data.AutoSize = true;
            this.title_data.Font = new System.Drawing.Font("Montserrat", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title_data.Location = new System.Drawing.Point(141, 31);
            this.title_data.Name = "title_data";
            this.title_data.Size = new System.Drawing.Size(65, 24);
            this.title_data.TabIndex = 2;
            this.title_data.Text = "label1";
            // 
            // message_data
            // 
            this.message_data.AutoSize = true;
            this.message_data.Font = new System.Drawing.Font("Montserrat", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.message_data.Location = new System.Drawing.Point(142, 60);
            this.message_data.Name = "message_data";
            this.message_data.Size = new System.Drawing.Size(47, 18);
            this.message_data.TabIndex = 2;
            this.message_data.Text = "label1";
            // 
            // image_box
            // 
            this.image_box.Location = new System.Drawing.Point(15, 21);
            this.image_box.Name = "image_box";
            this.image_box.Size = new System.Drawing.Size(88, 69);
            this.image_box.TabIndex = 1;
            this.image_box.TabStop = false;
            // 
            // CustomList
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.message_data);
            this.Controls.Add(this.title_data);
            this.Controls.Add(this.image_box);
            this.Controls.Add(this.custom_list);
            this.Name = "CustomList";
            this.Size = new System.Drawing.Size(749, 107);
            this.Click += new System.EventHandler(this.CustomList_Click);
            ((System.ComponentModel.ISupportInitialize)(this.image_box)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button custom_list;
        private System.Windows.Forms.PictureBox image_box;
        private System.Windows.Forms.Label title_data;
        private System.Windows.Forms.Label message_data;
    }
}
