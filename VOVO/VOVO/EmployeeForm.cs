using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
//using System.Web.UI.WebControls;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace VOVO
{
    public partial class EmployeeForm : Form
    {
        private string EmployeeID { set; get; }
        public EmployeeForm()
        {
            InitializeComponent();
            FormControlsUtility.ConfigureFormResize(this);
         }

        public EmployeeForm(string employeeID) : this()
        {
            EmployeeID = employeeID;

            CustomizeDesign();
            ShowDashboard();
        }

        static EmployeeForm obj;
        public static EmployeeForm Instance
        {
            get
            {
                if (obj == null)
                {
                    obj = new EmployeeForm();
                }
                return obj;
            }
        }

        public System.Windows.Forms.Panel EmployeePanelContainer
        {
            get { return employee_panel; }
            set { employee_panel = value; }
        }

        private void EmployeeForm_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;

            obj = this;
        }


       
       
        private void border_panel_MouseDown(object sender, MouseEventArgs e)
        {
            FormControlsUtility.AttachDraggableTitleBar(border_panel);
        }

        private void CustomDesign()
        {
            this.FormBorderStyle = FormBorderStyle.None;

            maximized_btn.Visible = false;
            Equipment equipment = new Equipment();
            icon.Image = equipment.ResizeImage(VOVO.Properties.Resources.Bus2, icon.Width, icon.Height);
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


        private void maximize_btn_Click(object sender, EventArgs e)
        {
            FormControlsUtility.ConfigureMaximizeButton(maximize_btn, maximized_btn);
        }

        private void maximize_btn_MouseEnter(object sender, EventArgs e)
        {
            FormControlsUtility.ConfigureMaximizeButton(maximize_btn, maximized_btn);

        }

        private void maximize_btn_MouseLeave(object sender, EventArgs e)
        {
            FormControlsUtility.ConfigureMaximizeButton(maximize_btn, maximized_btn);

        }

        private void minimize_btn_Click(object sender, EventArgs e)
        {
            FormControlsUtility.ConfigureMinimizeButton(minimize_btn);

        }

        private void minimize_btn_MouseEnter(object sender, EventArgs e)
        {
            FormControlsUtility.ConfigureMinimizeButton(minimize_btn);

        }

        private void minimize_btn_MouseLeave(object sender, EventArgs e)
        {
            FormControlsUtility.ConfigureMinimizeButton(minimize_btn);

        }

        private void maximized_btn_Click(object sender, EventArgs e)
        {
            FormControlsUtility.ConfigureMaximizedButton(maximize_btn, maximized_btn);
        }

        private void maximized_btn_MouseEnter(object sender, EventArgs e)
        {
            FormControlsUtility.ConfigureMaximizeButton(maximize_btn, maximized_btn);

        }

        private void maximized_btn_MouseLeave(object sender, EventArgs e)
        {
            FormControlsUtility.ConfigureMaximizeButton(maximize_btn, maximized_btn);

        }


        private void CustomizeDesign()
        {
            ticket_sub_panel.Visible = false;
            route_sub_panel.Visible = false;
            advatagement_sub_panel.Visible = false;
            reporting_sub_panel.Visible = false;
            office_sub_panel.Visible = false;
        }


        private void hidePanel()
        {
            if (ticket_sub_panel.Visible == true)
                ticket_sub_panel.Visible = false;

            if (route_sub_panel.Visible == true)
                route_sub_panel.Visible = false;

            if (advatagement_sub_panel.Visible == true)
                advatagement_sub_panel.Visible = false;

            if(reporting_sub_panel.Visible == true)
                reporting_sub_panel.Visible = false;
        

            if(office_sub_panel.Visible == true)
                office_sub_panel.Visible = false;

        }

        private void showSubManu(System.Windows.Forms.Panel subManu)
        {
            if (subManu.Visible == false)
            {
                hidePanel();
                subManu.Visible = true;
            }

            else
            {
                subManu.Visible = false;
            }
        }


        private void new_route_button_Click(object sender, EventArgs e)
        {
            EmployeePanelContainer.Controls.Clear();
            Route route = new Route(EmployeeID);
            route.Dock = DockStyle.Fill;
            EmployeePanelContainer.Controls.Add(route);
        }

        private void ticket_button_Click(object sender, EventArgs e)
        {
            showSubManu(ticket_sub_panel);
        }

        private void route_button_Click(object sender, EventArgs e)
        {
            showSubManu(route_sub_panel);
        }

        private void advatagement_button_Click(object sender, EventArgs e)
        {
            showSubManu(advatagement_sub_panel);
        }

        private void reporting_button_Click(object sender, EventArgs e)
        {
            showSubManu(reporting_sub_panel);
        }

        private void office_button_Click(object sender, EventArgs e)
        {
            showSubManu(office_sub_panel);
        }

        private void new_ticket_button_Click(object sender, EventArgs e)
        {
            EmployeePanelContainer.Controls.Clear();
            CreateTicket createTicket = new CreateTicket(EmployeeID);
            createTicket.Dock = DockStyle.Fill;
            EmployeePanelContainer.Controls.Add(createTicket);
        }

        private void bus_reporting_button_Click(object sender, EventArgs e)
        {
            EmployeePanelContainer.Controls.Clear();
            BusReporting busReporting = new BusReporting(EmployeeID);
            busReporting.Dock = DockStyle.Fill;
            EmployeePanelContainer.Controls.Add(busReporting);
        }

        private void logout_button_Click(object sender, EventArgs e)
        {
            this.Hide();
            EmployeeLogin employeeLogin = new EmployeeLogin();
            employeeLogin.Show();
        }

        private void employee_profile_btn_Click(object sender, EventArgs e)
        {
            Profile();
        }

        private void Profile()
        {
            EmployeePanelContainer.Controls.Clear();
            EmployeeProfile employeeProfile = new EmployeeProfile(EmployeeID, "Employee");
            employeeProfile.Dock = DockStyle.Fill;
            EmployeePanelContainer.Controls.Add(employeeProfile);
        }

        private void EmployeeForm_SizeChanged(object sender, EventArgs e)
        {
            FormControlsUtility.ConfigureFormResize(this);


        }


        private void delete_office_button_Click(object sender, EventArgs e)
        {
            EmployeePanelContainer.Controls.Clear();
            Office office = new Office(EmployeeID, employee: true);
            office.Dock = DockStyle.Fill;
            EmployeePanelContainer.Controls.Add(office);
        }

        private void CollapseMenu()
        {
            try
            {
                if (left_side_panel.Width > 155)
                {
                    this.left_side_panel.Width = 100;
                    three_bar_button.Dock = DockStyle.Fill;

                    foreach (Button leftSideManuButton in left_side_panel.Controls.OfType<Button>())
                    {
                        leftSideManuButton.Text = "";
                        leftSideManuButton.ImageAlign = ContentAlignment.MiddleCenter;
                        leftSideManuButton.Padding = new Padding(0);
                    }


                    foreach (Button ticketSubPanelButtons in ticket_sub_panel.Controls.OfType<Button>())
                    {
                        ticketSubPanelButtons.Text = "";
                        ticketSubPanelButtons.ImageAlign = ContentAlignment.MiddleCenter;
                        ticketSubPanelButtons.Padding = new Padding(0);
                    }

                    foreach (Button routeSubPanelButton in route_sub_panel.Controls.OfType<Button>())
                    {
                        routeSubPanelButton.Text = "";
                        routeSubPanelButton.ImageAlign = ContentAlignment.MiddleCenter;
                        routeSubPanelButton.Padding = new Padding(0);
                    }

                    foreach (Button advertagmentSubManuPanelButton in advatagement_sub_panel.Controls.OfType<Button>())
                    {
                        advertagmentSubManuPanelButton.Text = "";
                        advertagmentSubManuPanelButton.ImageAlign = ContentAlignment.MiddleCenter;
                        advertagmentSubManuPanelButton.Padding = new Padding(0);
                    }


                    foreach (Button reportingSubPanelButton in reporting_sub_panel.Controls.OfType<Button>())
                    {
                        reportingSubPanelButton.Text = "";
                        reportingSubPanelButton.ImageAlign = ContentAlignment.MiddleCenter;
                        reportingSubPanelButton.Padding = new Padding(0);
                    }

                    foreach (Button officeSubPanelButton in reporting_sub_panel.Controls.OfType<Button>())
                    {
                        officeSubPanelButton.Text = "";
                        officeSubPanelButton.ImageAlign = ContentAlignment.MiddleCenter;
                        officeSubPanelButton.Padding = new Padding(0);
                    }

                }

                else
                {
                    this.left_side_panel.Width = 174;
                    three_bar_button.Dock = DockStyle.None;
                    foreach (Button menuButton in left_side_panel.Controls.OfType<Button>())
                    {
                        menuButton.Text = menuButton.Tag.ToString();
                        menuButton.ImageAlign = ContentAlignment.MiddleLeft;
                        menuButton.Padding = new Padding(0, 0, 0, 0);
                    }

                    foreach (Button ticketSubPanelButtons in ticket_sub_panel.Controls.OfType<Button>())
                    {
                        ticketSubPanelButtons.Text = ticketSubPanelButtons.Tag.ToString();
                        ticketSubPanelButtons.ImageAlign = ContentAlignment.MiddleLeft;
                        ticketSubPanelButtons.Padding = new Padding(10, 0, 0, 0);
                    }

                    foreach (Button routeSubPanelButton in route_sub_panel.Controls.OfType<Button>())
                    {
                        routeSubPanelButton.Text = routeSubPanelButton.Tag.ToString();
                        routeSubPanelButton.ImageAlign = ContentAlignment.MiddleLeft;
                        routeSubPanelButton.Padding = new Padding(10, 0, 0, 0);
                    }

                    foreach (Button advertagmentSubManuPanelButton in advatagement_sub_panel.Controls.OfType<Button>())
                    {
                        advertagmentSubManuPanelButton.Text = advertagmentSubManuPanelButton.Tag.ToString();
                        advertagmentSubManuPanelButton.ImageAlign = ContentAlignment.MiddleLeft;
                        advertagmentSubManuPanelButton.Padding = new Padding(10, 0, 0, 0);
                    }


                    foreach (Button reportingSubPanelButton in reporting_sub_panel.Controls.OfType<Button>())
                    {
                        reportingSubPanelButton.Text = reportingSubPanelButton.Tag.ToString();
                        reportingSubPanelButton.ImageAlign = ContentAlignment.MiddleLeft;
                        reportingSubPanelButton.Padding = new Padding(10, 0, 0, 0);
                    }

                    foreach (Button officeSubPanelButton in reporting_sub_panel.Controls.OfType<Button>())
                    {
                        officeSubPanelButton.Text = officeSubPanelButton.Tag.ToString();
                        officeSubPanelButton.ImageAlign = ContentAlignment.MiddleLeft;
                        officeSubPanelButton.Padding = new Padding(10, 0, 0, 0);
                    }
                }
            }

            catch(Exception ex) 
            {
                MessageBox.Show("Class name is EmployeeFrom and function name is CollapseMenu() and exception is : " + ex.Message);
            }
        }


        private void slide_bar_button_Click(object sender, EventArgs e)
        {
            CollapseMenu();
        }

        private void ShowDashboard()
        {
            EmployeePanelContainer.Controls.Clear();
            EmployeeDashboard adminDashBoard = new EmployeeDashboard(EmployeeID);
            adminDashBoard.Dock = DockStyle.Fill;
            EmployeePanelContainer.Controls.Add(adminDashBoard);
        }
        private void dashboard_button_Click(object sender, EventArgs e)
        {
            ShowDashboard();
        }

        private void route_update_button_Click(object sender, EventArgs e)
        {
            EmployeePanelContainer.Controls.Clear();
            RouteUpdate routeUpdate = new RouteUpdate(EmployeeID, update:true);
            routeUpdate.Dock = DockStyle.Fill;
            EmployeePanelContainer.Controls.Add(routeUpdate);
        }

        private void route_delete_button_Click(object sender, EventArgs e)
        {
            EmployeePanelContainer.Controls.Clear();
            RouteUpdate routeUpdate = new RouteUpdate(EmployeeID, delete: true);
            routeUpdate.Dock = DockStyle.Fill;
            EmployeePanelContainer.Controls.Add(routeUpdate);
        }
    }
}
