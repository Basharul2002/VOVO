using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VOVO
{
    public partial class CustomerForgottenPaswordSearching : Form
    {
        public CustomerForgottenPaswordSearching()
        {
            InitializeComponent();
            IconSet();
            MainDesign();
            FormControlsUtility.ConfigureFormResize(this);

        }



        private void border_panel_MouseDown(object sender, MouseEventArgs e)
        {
            FormControlsUtility.AttachDraggableTitleBar(top_border_panel);

        }
        // string connectionString = "Data Source=BASHARUL\\SQLEXPRESS01;Initial Catalog=VOVO;Integrated Security=True";

        private void MainDesign()
        {
            title.Location = new Point(37, 34);
            message.Location = new Point(41, 87);
            search_tb.Location = new Point(44, 137);
            warning_message.Visible = false;

        }

        private void IconSet()
        {
            maximized_btn.Visible = false;
            Equipment equipment = new Equipment();
            icon.Image = equipment.ResizeImage(VOVO.Properties.Resources.Bus2, icon.Width, icon.Height);
        }
        private void CustomDesign()
        {
            message.Location = new Point(41, 119);
            search_tb.Location = new Point(44, 159);
            warning_message.Visible = true;
            warning_message.Location = new Point(44, 75);
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



        private void search_btn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(search_tb.Text))
            {
                CustomDesign();
            }


            else if (!string.IsNullOrEmpty(search_tb.Text))
            {

                DataBase dataBase = new DataBase();

                CustomDataType_CustomerFound_CustomerIDNameEmailPhoneNumber customerData = dataBase.CustomerForgotPasswordCustomerFound(search_tb.Text);

                if (customerData != null && customerData.Found == true)
                {
                    string customerID = customerData.ID;
                    string customerName = customerData.Name;
                    string customerEmail = customerData.Email;
                    string countryCode = customerData.CountryCode;
                    string customerPhoneNumber = customerData.PhoneNumber;

                    MessageBox.Show(customerPhoneNumber);
                    this.Hide();
                    CustomerForgotPasswordCodeSending customerForgotPasswordCodeSending = new CustomerForgotPasswordCodeSending(customerID, customerName, customerEmail, countryCode, customerPhoneNumber);
                    customerForgotPasswordCodeSending.Show();
                }

                else
                {
                    // Customer not found
                    MessageBox.Show("Customer not found", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            else
            {
                MessageBox.Show("Invalied Input", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }



        }


        private void CustomerForgottenPasword_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            CustomerLoginForm customerLoginForm = new CustomerLoginForm();
            this.Hide();
            customerLoginForm.Show();
        }


        string watermarkText = "Email address or mobile number";
        private void SetWatermark()
        {
            // Set the watermark text in a different color
            search_tb.ForeColor = System.Drawing.Color.Gray;
            search_tb.Text = watermarkText;
        }

        private void TextBox_Enter(object sender, EventArgs e)
        {
            // Clear the watermark text when the TextBox gets focus
            if (search_tb.Text == watermarkText)
            {
                search_tb.Text = "";
                search_tb.ForeColor = System.Drawing.Color.Black; // Set text color back to black
            }
        }

        private void TextBox_Leave(object sender, EventArgs e)
        {
            // Set the watermark text back when the TextBox loses focus and is empty
            if (string.IsNullOrWhiteSpace(search_tb.Text) || search_tb.Text == watermarkText)
            {
                SetWatermark();
            }
        }

    }
}
