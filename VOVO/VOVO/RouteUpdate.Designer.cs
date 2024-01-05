namespace VOVO
{
    partial class RouteUpdate
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.to_tb = new System.Windows.Forms.TextBox();
            this.from_tb = new System.Windows.Forms.TextBox();
            this.route_id_tb = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.data_grid_view = new MetroFramework.Controls.MetroGrid();
            this.route_id_gdb = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.from_gdb = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.to_gdv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.update_button = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.metroPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.data_grid_view)).BeginInit();
            this.SuspendLayout();
            // 
            // to_tb
            // 
            this.to_tb.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.to_tb.Location = new System.Drawing.Point(139, 131);
            this.to_tb.Name = "to_tb";
            this.to_tb.Size = new System.Drawing.Size(227, 26);
            this.to_tb.TabIndex = 11;
            // 
            // from_tb
            // 
            this.from_tb.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.from_tb.Location = new System.Drawing.Point(139, 94);
            this.from_tb.Name = "from_tb";
            this.from_tb.Size = new System.Drawing.Size(227, 26);
            this.from_tb.TabIndex = 10;
            // 
            // route_id_tb
            // 
            this.route_id_tb.Enabled = false;
            this.route_id_tb.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.route_id_tb.Location = new System.Drawing.Point(139, 62);
            this.route_id_tb.Name = "route_id_tb";
            this.route_id_tb.ReadOnly = true;
            this.route_id_tb.Size = new System.Drawing.Size(227, 26);
            this.route_id_tb.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(32, 63);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 20);
            this.label7.TabIndex = 6;
            this.label7.Text = "Route ID";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(33, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "From";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(32, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = "To";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.metroPanel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(437, 469);
            this.tableLayoutPanel1.TabIndex = 12;
            // 
            // metroPanel1
            // 
            this.metroPanel1.Controls.Add(this.update_button);
            this.metroPanel1.Controls.Add(this.to_tb);
            this.metroPanel1.Controls.Add(this.from_tb);
            this.metroPanel1.Controls.Add(this.route_id_tb);
            this.metroPanel1.Controls.Add(this.label2);
            this.metroPanel1.Controls.Add(this.label7);
            this.metroPanel1.Controls.Add(this.label1);
            this.metroPanel1.Controls.Add(this.label3);
            this.metroPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Location = new System.Drawing.Point(3, 3);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(431, 194);
            this.metroPanel1.TabIndex = 0;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(113, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Route Update";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.data_grid_view);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 203);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(431, 263);
            this.panel1.TabIndex = 1;
            // 
            // data_grid_view
            // 
            this.data_grid_view.AllowUserToAddRows = false;
            this.data_grid_view.AllowUserToDeleteRows = false;
            this.data_grid_view.AllowUserToResizeRows = false;
            this.data_grid_view.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.data_grid_view.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.data_grid_view.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.data_grid_view.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.data_grid_view.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.data_grid_view.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.data_grid_view.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.route_id_gdb,
            this.from_gdb,
            this.to_gdv});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.data_grid_view.DefaultCellStyle = dataGridViewCellStyle5;
            this.data_grid_view.Dock = System.Windows.Forms.DockStyle.Fill;
            this.data_grid_view.EnableHeadersVisualStyles = false;
            this.data_grid_view.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.data_grid_view.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.data_grid_view.Location = new System.Drawing.Point(0, 0);
            this.data_grid_view.Name = "data_grid_view";
            this.data_grid_view.ReadOnly = true;
            this.data_grid_view.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.data_grid_view.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.data_grid_view.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.data_grid_view.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.data_grid_view.Size = new System.Drawing.Size(431, 263);
            this.data_grid_view.TabIndex = 0;
            this.data_grid_view.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.data_grid_view_CellClick);
            // 
            // route_id_gdb
            // 
            this.route_id_gdb.DataPropertyName = "Route ID";
            this.route_id_gdb.HeaderText = "Route ID";
            this.route_id_gdb.Name = "route_id_gdb";
            this.route_id_gdb.ReadOnly = true;
            // 
            // from_gdb
            // 
            this.from_gdb.DataPropertyName = "From";
            this.from_gdb.HeaderText = "From";
            this.from_gdb.Name = "from_gdb";
            this.from_gdb.ReadOnly = true;
            // 
            // to_gdv
            // 
            this.to_gdv.DataPropertyName = "To";
            this.to_gdv.HeaderText = "To";
            this.to_gdv.Name = "to_gdv";
            this.to_gdv.ReadOnly = true;
            // 
            // update_button
            // 
            this.update_button.Location = new System.Drawing.Point(308, 163);
            this.update_button.Name = "update_button";
            this.update_button.Size = new System.Drawing.Size(75, 23);
            this.update_button.TabIndex = 12;
            this.update_button.Text = "Update";
            this.update_button.UseVisualStyleBackColor = true;
            this.update_button.Click += new System.EventHandler(this.update_button_Click);
            // 
            // RouteUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "RouteUpdate";
            this.Size = new System.Drawing.Size(437, 469);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.metroPanel1.ResumeLayout(false);
            this.metroPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.data_grid_view)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox to_tb;
        private System.Windows.Forms.TextBox from_tb;
        private System.Windows.Forms.TextBox route_id_tb;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private MetroFramework.Controls.MetroPanel metroPanel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private MetroFramework.Controls.MetroGrid data_grid_view;
        private System.Windows.Forms.DataGridViewTextBoxColumn route_id_gdb;
        private System.Windows.Forms.DataGridViewTextBoxColumn from_gdb;
        private System.Windows.Forms.DataGridViewTextBoxColumn to_gdv;
        private System.Windows.Forms.Button update_button;
    }
}
