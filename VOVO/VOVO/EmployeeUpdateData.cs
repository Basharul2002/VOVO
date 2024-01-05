using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VOVO
{
    public partial class EmployeeUpdateData : Form
    {
        private string userType, userID, password;
        public bool flag { private set; get; }
        public EmployeeUpdateData()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            FormControlsUtility.ConfigureFormResize(this);
        }

        public EmployeeUpdateData(string userType, string userID) : this()
        {
            this.userType = userType;
            this.userID = userID;

            Password();
        }

        private void Password()
        {
            DataBase dataBase = new DataBase();
            string query = $@"SELECT Password FROM [User Login Information] WHERE [User ID] = '{this.userID}'";
            password = dataBase.EmployeePassword(query);
           // MessageBox.Show(password);
        }

        private void top_border_panel_MouseDown(object sender, MouseEventArgs e)
        {
            FormControlsUtility.AttachDraggableTitleBar(top_border_panel);

        }



        // Window state
        // Close button 
        private void close_btn_Click(object sender, EventArgs e)
        {
            flag = true;
            this.Hide(); // Hide the form when the button is clicked
        }
        private void close_btn_MouseEnter(object sender, EventArgs e)
        {
          //  FormControlsUtility.ConfigureCloseButton(close_btn);

        }
        private void close_btn_MouseLeave(object sender, EventArgs e)
                              {
          //  FormControlsUtility.ConfigureCloseButton(close_btn);

        }



        private void current_password_show_button_Click(object sender, EventArgs e)
        {
            TogglePasswordVisibility(current_password_tb, current_password_show_button, current_password_hide_button, false);
        }                        

        private void current_password_hide_button_Click(object sender, EventArgs e)
        {
            TogglePasswordVisibility(current_password_tb, current_password_show_button, current_password_hide_button, true);

        }

        private void new_password_show_button_Click(object sender, EventArgs e)
        {
            TogglePasswordVisibility(new_password_tb, new_password_show_button, new_password_hide_button, false);
        }

        private void new_password_hide_button_Click(object sender, EventArgs e)
        {
            TogglePasswordVisibility(new_password_tb, new_password_show_button, new_password_hide_button, true);

        }

        private void re__enter_password_show_button_Click(object sender, EventArgs e)
        {
            TogglePasswordVisibility(re_type_password_tb, re_enter_password_show_button, re_type_password_hide_button, false);
        }

        private void re_type_password_hide_button_Click(object sender, EventArgs e)
        {
            TogglePasswordVisibility(re_type_password_tb, re_enter_password_show_button, re_type_password_hide_button, true);
        }


        private void TogglePasswordVisibility(TextBox textBox, Button showButton, Button hideButton, bool flag)
        {
            textBox.UseSystemPasswordChar = flag;

            textBox.Focus();

            if (!flag)
            {
                hideButton.Location = showButton.Location;
                showButton.Visible = false;
                hideButton.Visible = true;
                hideButton.BringToFront(); 
                return;
            }

            showButton.Location = hideButton.Location;
            hideButton.Visible = false;
            showButton.Visible = true;

        }

        private void search_btn_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(current_password_tb.Text)) 
            {
                wrong_password_warning_panel.Visible = true;
                current_password_warning_label.Text = "Enter your current password";
                current_password_tb.Focus();

                return;
            }

            wrong_password_warning_panel.Visible = false;
            if (string.IsNullOrWhiteSpace(new_password_tb.Text))
            {
                new_password_warning_panel.Visible = true;
                new_password_warning_label.Text = "Enter new password";
                new_password_tb.Focus();

                return;
            }


            new_password_warning_panel.Visible = false;
            if (string.IsNullOrWhiteSpace(re_type_password_tb.Text))
            {
                re_type_password_warning_panel.Visible = true;
                re_type_password_warning_label.Text = "Re-type password";
                re_type_password_tb.Focus();

                return;
            }


            re_type_password_warning_panel.Visible = false;
            if(password != current_password_tb.Text)
            {
                wrong_password_warning_panel.Visible = true;
                current_password_warning_label.Text = "Wrong password";
                current_password_tb.Focus();

                return;
            }

            wrong_password_warning_panel.Visible = false;
            if (password == new_password_tb.Text)
            {
                new_password_warning_panel.Visible = true;
                new_password_warning_label.Text = "This password is has been already used. \nTry something new";
                new_password_tb.Focus();

                return;
            }


            new_password_warning_panel.Visible = false;
            string message;
            if (!Equipment.IsStrongPassword(new_password_tb.Text, out message))
            {
                new_password_warning_panel.Visible = true;
                new_password_warning_label.Text = $"Choose a more secure password you don't use anywhere else. \n {message}";
                new_password_tb.Focus();

                return;
            }

            new_password_warning_panel.Visible = false;
            if (new_password_tb.Text != re_type_password_tb.Text)
            {
                re_type_password_warning_panel.Visible = true;
                re_type_password_warning_label.Text = "New password does not match. Enter new password again here.";
                re_type_password_tb.Focus();

                return;
            }


            DataBase dataBase = new DataBase();
            int flag = dataBase.UpdateEmployeePassword(this.userID, new_password_tb.Text, this.userType);

            if(flag<=0)
            {
                MessageBox.Show("Password not updated");
                return;
            }

            this.Hide();

        }
    }
}
