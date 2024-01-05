using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using ZXing;

namespace VOVO
{
    public partial class HomePageForm : Form
    {
        private string windowSize = string.Empty;
        private Rectangle customerPictureRect, employeePictureRect, customerButtonRect, employeeButtonRect;
        private Size panelSize;


        public HomePageForm()
        {
            InitializeComponent();
            CustomDesign();
            FormControlsUtility.ConfigureFormResize(this);

        }

        


        private void border_panel_MouseDown(object sender, MouseEventArgs e)
        {
            FormControlsUtility.AttachDraggableTitleBar(top_border_panel);

        }



        private void CustomDesign()
        {
            Equipment equipment = new Equipment();
            icon.Image = equipment.ResizeImage(VOVO.Properties.Resources.Icon, 44, 37);

            homepage_panel.BackgroundImage = equipment.ResizeImage(VOVO.Properties.Resources.Home_Page_Logo_With_Main_Logo_, homepage_panel.Width, homepage_panel.Height);
        }

      

        private void close_btn_Click(object sender, EventArgs e)
        {
            FormControlsUtility.ConfigureCloseButton(close_btn);
        }

        private void close_btn_MouseEnter(object sender, EventArgs e)
        {
            FormControlsUtility.ConfigureCloseButton(close_btn);

        }

        private void close_btn_MouseLeave(object sender, EventArgs e)
        {
            FormControlsUtility.ConfigureCloseButton(close_btn);
        }

      
        private void minimize_btn_Click(object sender, EventArgs e)
        {
            FormControlsUtility.ConfigureMinimizeButton(minimize_btn);
        }




        private void employee_btn_Click(object sender, EventArgs e)
        {
            // MessageBox.Show("This Feature is not available right now");
            
           this.Hide();
            EmployeeLogin employeeLogin = new EmployeeLogin();
            employeeLogin.Show();

        }
            

        private void customer_btn_Click(object sender, EventArgs e)
        {
            
            this.Hide();
            CustomerLoginForm customerLoginForm = new CustomerLoginForm();
            customerLoginForm.Show();
        }

        private void employee_btn_MouseEnter(object sender, EventArgs e)
        {
            employee_btn.BackColor = Color.Coral;
            employee_btn.ForeColor = Color.White;
        }

        private void employee_btn_MouseLeave(object sender, EventArgs e)
        {
            employee_btn.BackColor = Color.Transparent;
            employee_btn.ForeColor = Color.OrangeRed;
        }

        private void customer_btn_MouseEnter(object sender, EventArgs e)
        {
            
        }

        private void customer_btn_MouseLeave(object sender, EventArgs e)
        {
           
        }


      


    }
}
