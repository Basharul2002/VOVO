using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VOVO
{
    public partial class StartupForm : Form
    {
        public StartupForm()
        {
            InitializeComponent();
            FormControlsUtility.ConfigureFormResize(this);

        }



        private void startup_form_Load(object sender, EventArgs e)
        {
            progress_bar.ForeColor = Color.Coral;
            timer.Start();
        }


        private int startpoint = 0;
        private void timer_Tick(object sender, EventArgs e)
        {
            startpoint++;
            progress_bar.Value = startpoint;


            if (progress_bar.Value >= 0 && progress_bar.Value < 25)
            {
                label2.Visible = true;
            }
            if (progress_bar.Value >= 25 && progress_bar.Value < 50)
            {
                label2.Visible = false;
                label7.Location = new Point(308, 299);
                label7.Visible = true;
            }

            if (progress_bar.Value >= 50 && progress_bar.Value < 75)
            {
                label7.Visible = false;
                label4.Location = new Point(288, 299);
                label4.Visible = true;
            }

            if (progress_bar.Value >= 75 && progress_bar.Value < 100)
            {
                label4.Visible = false;
                label5.Location = new Point(308, 299);
                label5.Visible = true;
            }

            if (progress_bar.Value == 100)
            {
                progress_bar.Value = 0;
                timer.Stop();
                this.Hide();
                HomePageForm homeForm = new HomePageForm();
                homeForm.Show();
            }
        }

 
    }
}
