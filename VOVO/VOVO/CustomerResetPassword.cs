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
    public partial class CustomerResetPassword : Form
    {
        private string CustomerID, CustomerName;

        public CustomerResetPassword()
        {
            InitializeComponent();
            FormControlsUtility.ConfigureFormResize(this);
        }

        // Rounded Corners  


        public CustomerResetPassword(string id, string name) : this()
        {
            CustomerID = id;
            CustomerName = name;

            CustomDesign();
        }




        private void top_border_panel_MouseDown(object sender, MouseEventArgs e)
        {
            FormControlsUtility.AttachDraggableTitleBar(top_border_panel);
        }

        private void CustomDesign()
        {
            this.FormBorderStyle = FormBorderStyle.None;

            maximized_btn.Visible = false;
            Equipment equipment = new Equipment();
            icon.Image = equipment.ResizeImage(VOVO.Properties.Resources.Bus2, icon.Width, icon.Height);

            password_tb.TabStop = false;
            confirm_password_tb.TabStop = false;

            name_label.Text = CustomerName;
            id_label.Text = CustomerID;
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
            this.WindowState = FormWindowState.Maximized;

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
            this.WindowState = FormWindowState.Minimized;
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

        private void reset_password_button_Click(object sender, EventArgs e)
        {
            string password = password_tb.Text;
            string confirmPassword = confirm_password_tb.Text;

            if (string.IsNullOrEmpty(password) || string.IsNullOrEmpty(password) && string.IsNullOrEmpty(password))
                MessageBox.Show("Please enter the password", "Alert");

            else if (string.IsNullOrEmpty(password))
                MessageBox.Show("Please enter the password more one time ", "Alert");


            else if (!string.IsNullOrEmpty(password) && !string.IsNullOrEmpty(password))
            {
                if (password != confirmPassword)
                    MessageBox.Show("Passwords do not match");

                else if (confirmPassword.Equals(password))
                {
                    DataBase dataBase = new DataBase();
                    int result = dataBase.CustomerResetPassword(CustomerID, password);

                    if (result == 1)
                    {
                        this.Hide();
                        CustomerLoginForm customerLoginForm = new CustomerLoginForm();
                        customerLoginForm.Show();
                    }
                }
            }
        }

        private void password_show_button_Click(object sender, EventArgs e)
        {
            password_tb.PasswordChar = '\0';
            password_hide_button.Visible = false;
            password_hide_button.Location = password_show_button.Location;
            password_hide_button.Visible = true;

        }

        private void password_hide_button_Click(object sender, EventArgs e)
        {
            password_tb.PasswordChar = '*';
            password_show_button.Visible = false;
            password_show_button.Location = password_hide_button.Location;
            password_show_button.Visible = true;
        }

        private void confirm_password_show_button_Click(object sender, EventArgs e)
        {
            confirm_password_tb.PasswordChar = '\0';
            confirm_password_show_button.Visible = false;
            confirm_password_hide_button.Location = confirm_password_show_button.Location;
            confirm_password_hide_button.Visible = true;
        }

        private void confirm_password_hide_button_Click(object sender, EventArgs e)
        {
            confirm_password_tb.PasswordChar = '*';
            confirm_password_hide_button.Visible = false;
            confirm_password_show_button.Location = confirm_password_hide_button.Location;
            confirm_password_show_button.Visible = true;

        }
        private void CustomerResetPassword_SizeChanged(object sender, EventArgs e)
        {
            FormControlsUtility.ConfigureFormResize(this);
        }

        private void password_tb_TextChanged(object sender, EventArgs e)
        {

        }

        private void confirm_password_tb_TextChanged(object sender, EventArgs e)
        {

        }

       


    }
}
