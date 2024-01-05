using MetroFramework.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VOVO
{
    public partial class EmployeeLogin : Form
    {
        private Rectangle subPanelRec, topLabelRec, userPictureRec, idTextBoxRec, passwordPictureRec, passwordTextBoxRec, hideButtonRec, showButtonRec, backButtonRec, signinButtonRec;
        private Size orginalFormSize;
        private bool passShow;

        public EmployeeLogin()
        {
            InitializeComponent();
            CustomDesign();
            FormControlsUtility.ConfigureFormResize(this);
        }

        // Rounded Corners  


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

            hide_button.Visible = false;

            id_tb.TabStop = false;
            password_tb.TabStop = false;
            sub_panel.BackgroundImage = equipment.ResizeImage(VOVO.Properties.Resources.EmployeeLoginWindowBackground, sub_panel.Width, sub_panel.Height);
         

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

            CustomDesign();
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
            CustomDesign();
        }

        private void maximized_btn_MouseEnter(object sender, EventArgs e)
        {
            FormControlsUtility.ConfigureMaximizeButton(maximize_btn, maximized_btn);

        }

        private void maximized_btn_MouseLeave(object sender, EventArgs e)
        {
            FormControlsUtility.ConfigureMaximizeButton(maximize_btn, maximized_btn);

        }

        private void EmployeeLogin_Load(object sender, EventArgs e)
        {
            //ResizeChildrenControls();
        }

        private void EmployeeLogin_Resize(object sender, EventArgs e)
        {
            // ResizeChildrenControls();
        }

        private void EmployeeLogin_SizeChanged(object sender, EventArgs e)
        {
            FormControlsUtility.ConfigureFormResize(this);
        }

        private void back_button_Click(object sender, EventArgs e)
        {
            this.Hide();
            HomePageForm homePageForm = new HomePageForm();
            homePageForm.Show();
        }

        private void panel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void sign_in_button_MouseEnter(object sender, EventArgs e)
        {
            sign_in_button.Font = new Font(sign_in_button.Font, FontStyle.Bold);
            sign_in_button.ForeColor = Color.FromArgb(215, 209, 209);
        }

        private void password_tb_Click(object sender, EventArgs e)
        {
            
        }

        private void password_tb_Validated(object sender, EventArgs e)
        {

        }

        private void password_tb_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(password_tb.Text))
                return;

            
            if (passShow)
            {
                //password_tb.PasswordChar = '';
                password_tb.UseSystemPasswordChar = false;
                return;
            }
          //  password_tb.PasswordChar = '●'; // Set the character to be displayed for password
            password_tb.UseSystemPasswordChar = true;
            
        }

        private void sign_in_button_MouseLeave(object sender, EventArgs e)
        {
            sign_in_button.Font = new Font(sign_in_button.Font, FontStyle.Regular);
            sign_in_button.ForeColor = Color.Coral;

        }

        private void back_button_MouseEnter(object sender, EventArgs e)
        {
            back_button.Font = new Font(back_button.Font, FontStyle.Bold);
            back_button.ForeColor = Color.FromArgb(215, 209, 209);
        }

        private void back_button_MouseLeave(object sender, EventArgs e)
        {
            back_button.Font = new Font(back_button.Font, FontStyle.Regular);
            back_button.ForeColor = Color.Coral;
        }

        private void TogglePasswordVisibility(bool showPassword, char show)
        {

           // password_tb.PasswordChar = show;

            show_button.Visible = !showPassword;
            hide_button.Visible = showPassword;

            if(showPassword)
            {
                hide_button.Location = show_button.Location;
                //   password_tb.PasswordChar = '*'; // Set the character to be displayed for password
                password_tb.UseSystemPasswordChar = true;
            }

            else
            {
                show_button.Location = hide_button.Location;
                password_tb.UseSystemPasswordChar = false;

            }
            
        }

        private void show_button_Click(object sender, EventArgs e)
        {
            TogglePasswordVisibility(showPassword: true, '\0');
            passShow = true;
        }

        private void hide_button_Click(object sender, EventArgs e)
        {
            TogglePasswordVisibility(showPassword: false, '*');
            passShow = false;
        }


        private string Position(string id)
        {
            if (id.Length >= 3)
            {
                string position = id.Substring(0, 3);
                if (position == "ADM")
                    return "Admin";

                else if (position == "EMP")
                    return "Employee";

                else if (position == "SUP")
                    return "Supervisor";

                else if (position == "CON")
                    return "Conductor";

                else if (position == "DRI")
                    return "Driver";

                else
                    return null;
            }

            else return null;
        }

        private void sign_in_button_Click(object sender, EventArgs e)
        {
            // Code for Basharul Metro
            if (id_tb.Text=="Basharul" && password_tb.Text == "Admin")
            {
                Quiz quiz = new Quiz();
                this.Hide();
                quiz.Show();
                return;
            }

            // Code for tanjim Metro
            if (id_tb.Text == "Tanjim" && password_tb.Text == "Employee")
            {
                
                EmployeeMetro employeeMetro = new EmployeeMetro();
                employeeMetro.Show();
                this.Hide();
                
            }


            SignIn();
        }

        private void SignIn()
        {
            string id = id_tb.Text;
            string password = password_tb.Text;

            string position = Position(id);
            // MessageBox.Show(position);


            if (string.IsNullOrWhiteSpace(id) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please fill in all required fields");
                return;
            }

            if (string.IsNullOrWhiteSpace(position))
            {
                MessageBox.Show("Wrong ID", "Ops!");
                return;
            }


            DataBase dataBase = new DataBase();
            string error;
            bool flag = dataBase.EmployeeLogin(id, password, out error);
            
            // Have exception from database
            if (!string.IsNullOrEmpty(error))
                return;

            // ID and password not match
            if (!flag)
            {
                MessageBox.Show("Invalied ID or Password", "Login Failed!");
                return;
            }

            // If id and pass match
            this.Hide();

            // When user is admin
            if (position == "Admin")
            {
                AdminForm AdminForm = new AdminForm(id);
                AdminForm.Show();
            }

            // When user is employee
            else if (position == "Employee")
            {
                EmployeeForm employeeForm = new EmployeeForm(id);
                employeeForm.Show();
            }
        }
    }
}