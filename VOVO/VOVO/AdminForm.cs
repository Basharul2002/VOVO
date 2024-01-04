using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace VOVO
{
    public partial class AdminForm : MetroFramework.Forms.MetroForm
    {
        private string AdminID;
        static AdminForm obj;
        public static AdminForm Instance
        {
            get
            {
                if(obj== null)
                {
                    obj = new AdminForm();
                }
                return obj;
            }
        }

        public Panel panelContainer
        {
            get { return admin_panel; }
            set { admin_panel = value; } 
        }


        public AdminForm()
        {
            InitializeComponent();
            CustomizeDesign();
            IconSet();
        }

        // Rounded Corners  
    

        public AdminForm(string adminID) : this()
        {
            AdminID = adminID;
        }


        

        private void top_border_panel_MouseDown(object sender, MouseEventArgs e)
        {

        }

        //Private methods
        

        private void CollapseMenu()
        {
            try
            {
                if (this.side_menu_panel.Width > 160) //Collapse menu
                {
                    side_menu_panel.Width = 100;
                    label.Visible = false;
                    three_bar_button.Dock = DockStyle.Top;
                    foreach (Button menuButton in side_menu_panel.Controls.OfType<Button>())
                    {
                        menuButton.Text = "";
                        menuButton.ImageAlign = ContentAlignment.MiddleCenter;
                        menuButton.Padding = new Padding(0);
                    }

                    foreach(Button regSubPanelButton in registration_sub_panel.Controls.OfType<Button>())
                    {
                        regSubPanelButton.Text = "";
                        regSubPanelButton.ImageAlign = ContentAlignment.MiddleCenter;
                        regSubPanelButton.Padding = new Padding(0);
                    }

                    foreach(Button infoSubPanelButton in information_sub_panel.Controls.OfType<Button>())
                    {
                        infoSubPanelButton.Text = "";
                        infoSubPanelButton.ImageAlign = ContentAlignment.MiddleCenter;
                        infoSubPanelButton.Padding = new Padding(0);
                    }

                    foreach(Button messSubManuButton in message_sub_panel.Controls.OfType<Button>())
                    {
                        messSubManuButton.Text = "";
                        messSubManuButton.ImageAlign = ContentAlignment.MiddleCenter;
                        messSubManuButton.Padding = new Padding(0);
                    }

                    foreach(Button reportSubManuPanel in report_sub_panel.Controls.OfType<Button>())
                    {
                        reportSubManuPanel.Text = "";
                        reportSubManuPanel.ImageAlign = ContentAlignment.MiddleCenter;
                        reportSubManuPanel.Padding = new Padding(0);
                    }
                }

                //Expand menu
                else
                { 
                    this.side_menu_panel.Width = 174;
                    label.Visible = true;
                    three_bar_button.Dock = DockStyle.None;
                    foreach (Button menuButton in side_menu_panel.Controls.OfType<Button>())
                    {
                        menuButton.Text =  menuButton.Tag.ToString();
                        menuButton.ImageAlign = ContentAlignment.MiddleLeft;
                        menuButton.Padding = new Padding(10, 0, 0, 0);
                    }

                    foreach (Button regSubPanelButton in registration_sub_panel.Controls.OfType<Button>())
                    {
                        regSubPanelButton.Text =  regSubPanelButton.Tag.ToString();
                        regSubPanelButton.ImageAlign = ContentAlignment.MiddleLeft;
                        regSubPanelButton.Padding = new Padding(10, 0, 0, 0);
                    }

                    foreach (Button infoSubPanelButton in information_sub_panel.Controls.OfType<Button>())
                    {
                        infoSubPanelButton.Text =  infoSubPanelButton.Tag.ToString();
                        infoSubPanelButton.ImageAlign = ContentAlignment.MiddleLeft;
                        infoSubPanelButton.Padding = new Padding(10, 0, 0, 0);
                    }

                    foreach (Button messSubManuButton in message_sub_panel.Controls.OfType<Button>())
                    {
                        messSubManuButton.Text =  messSubManuButton.Tag.ToString();
                        messSubManuButton.ImageAlign = ContentAlignment.MiddleLeft;
                        messSubManuButton.Padding = new Padding(10, 0, 0, 0);
                    }

                    foreach (Button reportSubManuPanel in report_sub_panel.Controls.OfType<Button>())
                    {
                        reportSubManuPanel.Text = reportSubManuPanel.Tag.ToString();
                        reportSubManuPanel.ImageAlign = ContentAlignment.MiddleLeft;
                        reportSubManuPanel.Padding = new Padding(10, 0, 0, 0);
                    }


                }
            }

            catch(Exception ex)
            {
                CustomMessageBox.Show("Class name is Admin from function name is collapeManus and exception: " + ex.Message);
            }
            
        }
        private void admin_profile_btn_Click(object sender, EventArgs e)
        {
            Profile();
        }

        private void dashboard_button_Click(object sender, EventArgs e)
        {
            showDashboard();
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            obj = this;
            showDashboard();
        }

        private void IconSet()
        {
            Equipment equipment = new Equipment();
            icon.Image = equipment.ResizeImage(VOVO.Properties.Resources.Bus2, icon.Width, icon.Height);
        }

        private void CustomizeDesign()
        {
            message_sub_panel.Visible = false;
            information_sub_panel.Visible = false;
            registration_sub_panel.Visible = false;
            report_sub_panel.Visible = false;
        }


        private void HidePanel()
        {
            if (registration_sub_panel.Visible == true)
            {
                registration_sub_panel.Visible = false;
            }

            if (message_sub_panel.Visible == true)
            {
                message_sub_panel.Visible = false;

            }

            if (information_sub_panel.Visible == true)
            {
                information_sub_panel.Visible = false;
            }

            if (report_sub_panel.Visible == true)
            {
                report_sub_panel.Visible = false;
            }
        }


        private void ShowSubManu(Panel subManu)
        {
            if (subManu.Visible == false)
            {
                HidePanel();
                subManu.Visible = true;
            }

            else
            {
                subManu.Visible = false;
            }
        }

        private void registration_btn_Click(object sender, EventArgs e)
        {
            ShowSubManu(registration_sub_panel);
        }

        private void information_button_Click(object sender, EventArgs e)
        {
            ShowSubManu(information_sub_panel);
        }

        private void message_button_Click(object sender, EventArgs e)
        {
            ShowSubManu(message_sub_panel);
        }

        private void report_button_Click(object sender, EventArgs e)
        {
            ShowSubManu(report_sub_panel);
        }


        private void showDashboard()
        {
            panelContainer.Controls.Clear();
            AdminDashBoard adminDashBoard = new AdminDashBoard(AdminID);
            adminDashBoard.Dock = DockStyle.Fill;
            panelContainer.Controls.Add(adminDashBoard);
        }

        private void showBusRegistration()
        {
            panelContainer.Controls.Clear();    
            BusRegistration busRegistration = new BusRegistration(AdminID);
            busRegistration.Dock = DockStyle.Fill;  
            panelContainer.Controls.Add(busRegistration);
        }

        private void showEmployeeRegistrationForm(string type)
        {
            panelContainer.Controls.Clear();
            RegistrationFromPersonalInfo registrationFromPersonalInfo = new RegistrationFromPersonalInfo(AdminID, type);
            registrationFromPersonalInfo.Dock = DockStyle.Fill;
            panelContainer.Controls.Add(registrationFromPersonalInfo);
        }

        private void Profile()
        {
            /*
            panelContainer.Controls.Clear();
            EmployeeProfile employeeProfile = new EmployeeProfile(AdminID, "Admin");
            employeeProfile.Dock = DockStyle.Fill;
            panelContainer.Controls.Add(employeeProfile);
            */
        }

        private void showCompanyRegistrationForm()
        {
            panelContainer.Controls.Clear();
            CompanyRegistration companyRegistration = new CompanyRegistration(AdminID);
            companyRegistration.Dock = DockStyle.Fill;
            panelContainer.Controls.Add(companyRegistration);
        }


        private void close_button_Click(object sender, EventArgs e)
        {
        }

        private void close_button_MouseEnter(object sender, EventArgs e)
        {
        }

        private void close_button_MouseLeave(object sender, EventArgs e)
        {
        }

        private void minimized_button_Click(object sender, EventArgs e)
        {

        }

        private void maximized_button_Click(object sender, EventArgs e)
        {
        }

        private void maximize_button_Click(object sender, EventArgs e)
        {

        }




        private void bus_registation_button_Click(object sender, EventArgs e)
        {
            showBusRegistration();

        }

        private void admin_registration_button_Click(object sender, EventArgs e)
        {
            showEmployeeRegistrationForm("Admin");
        }

        private void company_registration_button_Click(object sender, EventArgs e)
        {
            showCompanyRegistrationForm();
        }

        private void driver_registration_button_Click(object sender, EventArgs e)
        {
            showEmployeeRegistrationForm("Driver");
        }

        private void conductor_registration_button_Click(object sender, EventArgs e)
        {
            showEmployeeRegistrationForm("Conductor");
        }

        private void supervisor_registration_button_Click(object sender, EventArgs e)
        {
            showEmployeeRegistrationForm("Supervisor");
        }

        private void employee_registration_button_Click(object sender, EventArgs e)
        {
            showEmployeeRegistrationForm("Employee");
        }

        private void bus_info_button_Click(object sender, EventArgs e)
        {
           
        }

        private void admin_info_button_Click(object sender, EventArgs e)
        {

        }

        private void logout_button_Click(object sender, EventArgs e)
        {

        }

        private void customer_info_button_Click(object sender, EventArgs e)
        {

        }


        private void employee_information_button_Click(object sender, EventArgs e)
        {
           
        }

        private void superivisor_info_button_Click(object sender, EventArgs e)
        {

        }

        private void driver_info_button_Click(object sender, EventArgs e)
        {

        }

        private void conductor_info_button_Click(object sender, EventArgs e)
        {

        }

        private void three_bar_button_Click(object sender, EventArgs e)
        {
            CollapseMenu();
        }

        private void office_add_button_Click(object sender, EventArgs e)
        {
            
        }
    }
}
