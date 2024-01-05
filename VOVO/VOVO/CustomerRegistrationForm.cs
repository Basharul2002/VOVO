using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Runtime.Remoting.Messaging;
using System.Windows.Input;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Web.UI.WebControls;
using System.Runtime.InteropServices;
using static VOVO.ENUM;
using System.Reflection;



namespace VOVO
{
    public partial class CustomerRegistrationForm : Form
    {
        private string gender;
        private bool isAdmin;
        //
        // Constructor
        //
        public CustomerRegistrationForm()
        {
            InitializeComponent();
            FormControlsUtility.ConfigureFormResize(this);
            CustomDesign();
        }


        public CustomerRegistrationForm(bool isAdmin = false) : this()
        {
            this.isAdmin = isAdmin;
        }

        // Rounded Corners  

        private void CustomDesign()
        {
            int alpha = (int)(255 * 0.9); // 10% transparency
            panel.BackColor = Color.FromArgb(alpha, 215, 209, 209);

            if(isAdmin)
            {
                this.minimize_btn.Visible = false;
                this.maximize_btn.Visible = false;
                this.maximized_btn.Visible = false;
            }
        }
        //
        // // Function to clear the form fields
        private void functionClearContext()
        {
            // Clear every text field
            this.name_tb.Clear();
            this.email_tb.Clear();
            this.country_code.SelectedItem = null;
            this.phn_num_tb.Clear();
            this.pass_tb.Clear();
            this.con_pass_tb.Clear();

            // Text Holder
            // Name Text holder
            name_tb.Text = "Vovo";
            name_tb.ForeColor = Color.Silver;

            // Email Text Holder
            //
            email_tb.Text = "email@gmail.com";
            email_tb.ForeColor = Color.Silver;

            // Phone Number text Holder
            phn_num_tb.Text = "xxxxxxxxxx";
            phn_num_tb.ForeColor = Color.Silver;

            // Country Combo Box Text
            this.country_code.Text = "Choose";

            // Password Hide
            pass_tb.UseSystemPasswordChar = true;
            pass_tb.PasswordChar = '*';

            // Confirm Pass Hide
            con_pass_tb.UseSystemPasswordChar = true;
            con_pass_tb.PasswordChar = '*';
        }

        
        // Event handler for when the mouse is pressed down on the border_panel.
        private void top_border_panel_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            FormControlsUtility.AttachDraggableTitleBar(top_border_panel);

        }
        // Event handler for the close button
        //
        private void close_btn_Click(object sender, EventArgs e)
        {
            if(isAdmin)
            {
                this.Close();
                return;
            }
            // Close the application
            Application.Exit();
        }


        private void close_btn_MouseEnter(object sender, EventArgs e)
        {
            if(isAdmin)
            {
                this.Hide();
            }
            FormControlsUtility.ConfigureCloseButton(close_btn);

        }

        private void close_btn_MouseLeave(object sender, EventArgs e)
        {
            close_btn.BackColor = Color.Transparent;
        }


        private void maximize_btn_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            maximize_btn.Visible = false;
            maximized_btn.Location = maximize_btn.Location;
            maximized_btn.Visible = true;
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


        // Event handler for the previous button
        private void previous_btn_Click(object sender, EventArgs e)
        {
            if(this.isAdmin)// Hide the current form and show the customer login form
            {
                this.Close();

            }

            else if(!this.isAdmin)
            {
                this.Hide();
                CustomerLoginForm customerLoginForm = new CustomerLoginForm();
                customerLoginForm.Show();

            }
            
        }

        // Event handler for the show password button
        private void pass_show_btn_Click(object sender, EventArgs e)
        {
            // Show the password in the password textbox
            pass_tb.UseSystemPasswordChar = false;
            // Password showing button is hide
            pass_show_btn.Visible = false;
            // The location of the Password hide button is moved to the location of the Password show button
            pass_hide_btn.Location = pass_show_btn.Location;
            // Password hideing button is show
            pass_hide_btn.Visible = true;
        }

        // Event handler for the hide password button
        private void pass_hide_btn_Click(object sender, EventArgs e)
        {
            // Hide the password in the password textbox and hide and show button respectivly show and hide
            pass_tb.UseSystemPasswordChar = true;
            pass_hide_btn.Visible = false;
            pass_show_btn.Visible = true;
        }

        // Event handler for the show confirm password button
        private void con_pass_show_btn_Click(object sender, EventArgs e)
        {
            // Show the password in the password textbox and show and hide button respectivly show and hide
            con_pass_tb.UseSystemPasswordChar = false;
            con_pass_show_btn.Visible = false;
            // The location of the Confirm Password hide button is moved to the location of the Confirm Password show button
            con_pass_hide_btn.Location = con_pass_show_btn.Location;
            con_pass_hide_btn.Visible = true;
        }

        // Event handler for the hide confirm password button
        private void con_pass_hide_btn_Click(object sender, EventArgs e)
        {
            // Hide the password in the confirm password textbox and hide and show button respectivly show and hide
            con_pass_tb.UseSystemPasswordChar = true;
            con_pass_hide_btn.Visible = false;
            con_pass_show_btn.Visible = true;
        }
        private void textBoxEnter(string boxName)
        {
            if (boxName == "Name")
            {
                // Change the name textbox text and color when it is focused
                if (name_tb.Text == "Vovo")
                {
                    name_tb.Text = "";
                    name_tb.ForeColor = Color.Black;
                }
            }

            if (boxName == "Email")
            {
                // Change the email textbox text and color when it is focused
                if (email_tb.Text == "email@gmail.com")
                {
                    email_tb.Text = "";
                    email_tb.ForeColor = Color.Black;
                }
            }

            if (boxName == "Phone Number")
            {
                // Change the phone number textbox text and color when it is focused
                if (phn_num_tb.Text == "xxxxxxxxxx")
                {
                    phn_num_tb.Text = "";
                    phn_num_tb.ForeColor = Color.Black;
                }
            }
        }


        private void textBoxLeave(string boxName)
        {
            if (boxName == "Name")
            {
                // Restore the name textbox text and color when it loses focus
                if (string.IsNullOrEmpty(name_tb.Text))
                {
                    name_tb.Text = "Vovo";
                    name_tb.ForeColor = Color.Silver;
                }
            }

            if (boxName == "Email")
            {
                // Restore the email textbox text and color when it loses focus
                if (string.IsNullOrEmpty(email_tb.Text))
                {
                    email_tb.Text = "email@gmail.com";
                    email_tb.ForeColor = Color.Silver;
                }
            }

            if (boxName == "Phone Number")
            {
                // Restore the phone number textbox text and color when it loses focus
                if (string.IsNullOrEmpty(phn_num_tb.Text))
                {
                    phn_num_tb.Text = "xxxxxxxxxx";
                    phn_num_tb.ForeColor = Color.Silver;
                }
            }
        }


        // Event handler for the name textbox enter event
        private void name_tb_Enter(object sender, EventArgs e)
        {
            textBoxEnter("Name");
        }

        // Event handler for the name textbox leave event
        private void name_tb_Leave(object sender, EventArgs e)
        {
            textBoxLeave("Name");
        }

        // Event handler for the email textbox enter event
        private void email_tb_Enter(object sender, EventArgs e)
        {
            textBoxEnter("Email");
        }

        // Event handler for the email textbox leave event
        private void email_tb_Leave(object sender, EventArgs e)
        {
            textBoxLeave("Email");
        }

        // Event handler for the phone number textbox enter event
        private void phn_num_tb_Enter(object sender, EventArgs e)
        {
            textBoxEnter("Phone Number");
        }

        // Event handler for the phone number textbox leave event
        private void phn_num_tb_Leave(object sender, EventArgs e)
        {
            textBoxLeave("Phone Number");
        }

        private string genderSelection()
        {
            if (male_radio_Button.Checked)
            {
                gender = "Male";
            }

            if (female_radio_button.Checked)
            {
                gender = "Female";
            }

            if (others_radio_button.Checked)
            {
                gender = "Others";
            }

            if(not_say_radio_button.Checked)
            {
                gender = "PreferNotToSay";
            }

            if(!male_radio_Button.Checked && !female_radio_button.Checked && !others_radio_button.Checked && !not_say_radio_button.Checked)
            {
                gender = "No Selected";
            }

            return gender;
        }

        private void createButtonEvent()
        {

            // Check if all required fields are filled
            if (string.IsNullOrEmpty(name_tb.Text) || string.IsNullOrEmpty(email_tb.Text) || country_code.Text == "Choose" || string.IsNullOrEmpty(phn_num_tb.Text) || genderSelection() == "No Selected" || string.IsNullOrEmpty(pass_tb.Text) || string.IsNullOrEmpty(con_pass_tb.Text))
            {
                MessageBox.Show("Please fill in all required fields");
            }
            // ...
            else if (!string.IsNullOrEmpty(name_tb.Text) && !string.IsNullOrEmpty(email_tb.Text) && country_code.SelectedItem.ToString() == "+880(BAN)" && !string.IsNullOrEmpty(phn_num_tb.Text) && genderSelection() != "No Selected" && !string.IsNullOrEmpty(pass_tb.Text) && !string.IsNullOrEmpty(con_pass_tb.Text))
            {
                // Check if password and confirm password match
                if (pass_tb.Text != con_pass_tb.Text)
                {
                    MessageBox.Show("Password does not match");
                }
                // ...
                else if (pass_tb.Text == con_pass_tb.Text)
                {
                    ValidityCheck validityCheck = new ValidityCheck();
                    // phone number and email formate validity check
                    // Function Call
                    bool phn = validityCheck.IsPhoneNumberValid(phn_num_tb.Text);
                    bool email = validityCheck.IsEmailValid(email_tb.Text);


                    // phone number and email formate are invalid
                    if (!phn && !email)
                    {
                        MessageBox.Show("Invalid Email and Phone Number", "Error");
                    }

                    // phone number formate is invalid
                    else if (!phn)
                    {
                        MessageBox.Show("Invalid Phone Number", "Error");
                    }

                    // email formate is invalid
                    else if (!email)
                    {
                        MessageBox.Show("Invalid Email", "Error");
                    }

                    // phone number and email formate are valid
                    else if (phn && email)
                    {
                        // Obtain the mobile number from user input
                        // If the flag is false, proceed with creating a new customer account
                        // Extract the country code from the country_code TextBox
                        string countryCode = country_code.Text.Substring(0, 4);

                        // Concatenate the country code with the phone number from phn_num_tb TextBox
                        GenderEnum enumGender;
                        string intGender = null;
                        string _gender = genderSelection();

                        if (Enum.TryParse(_gender, out enumGender))
                            intGender = ((int)enumGender).ToString();
                        

                        DataBase dataBase = new DataBase();
                        if (dataBase.CustomerRegistration(customer_id_tb.Text, name_tb.Text, email_tb.Text, countryCode, phn_num_tb.Text, intGender, pass_tb.Text))
                        {
                            // Hide the current form
                            this.Hide();

                            if(isAdmin)
                            {
                                this.Close();
                                return;
                            }

                            else if(!isAdmin)
                            {
                                // Create an instance of the CustomerLoginForm
                                CustomerLoginForm customerLoginForm = new CustomerLoginForm();

                                // Show the CustomerLoginForm
                                customerLoginForm.Show();
                            }
                            
                        }

                    }
                }
            }
        }

        // Event handler for the form load event
        private void CustomerRegistrationForm_Load(object sender, EventArgs e)
        {
            // Set the background color and generate a new customer ID
            // Set the background color of panel3 to a custom transparent color
            panel.BackColor = Color.FromArgb(0, 0, 100, 0);

            // Get the next customer serial number and generate a new customer ID
            Equipment equipment = new Equipment();
            customer_id_tb.Text = equipment.idGenarator("Customer");

            // Allow editing of the customer ID textbox
            customer_id_tb.ReadOnly = false;

            // Set the foreground color of the customer ID textbox to Coral
            customer_id_tb.ForeColor = Color.Coral;
        }


        // Event handler for the create account button
        private void create_account_btn_Click(object sender, EventArgs e)
        {
            createButtonEvent();
        }

        private void CustomerRegistrationForm_SizeChanged(object sender, EventArgs e)
        {
            FormControlsUtility.ConfigureFormResize(this);
        }

        private void clear_btn_Click(object sender, EventArgs e)
        {
            functionClearContext();
        }
    }
}
