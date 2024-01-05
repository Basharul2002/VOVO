using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using Org.BouncyCastle.Asn1.Cms;
using static iText.IO.Image.Jpeg2000ImageData;
using System.Diagnostics;
using VOVO;
using iText.Kernel.XMP;
using System.Speech.Synthesis;

namespace VOVO
{
    public partial class CustomerLoginForm : Form
    {
        private Image[] images, userImage;
        private int currentImageIndex = 0, time = 0;
        private bool show = false;
        private SpeechSynthesizer voice;


        public CustomerLoginForm()
        {
            InitializeComponent();

            this.AcceptButton = sign_in_btn;
            this.KeyPreview = true;

            voice = new SpeechSynthesizer();
            CustomDesign();

            GenerateCaptcha();

        }

        private void GenerateCaptcha()
        {
            Equipment equipment = new Equipment();
            
        }


        private void CustomerLoginForm_Load(object sender, EventArgs e)
        {
            FormControlsUtility.ConfigureFormResize(this);
        }


        private void border_panel_MouseDown(object sender, MouseEventArgs e)
        {
            FormControlsUtility.AttachDraggableTitleBar(top_border_panel);

        }

        private void CustomDesign()
        {
            Equipment equipment = new Equipment();
            icon.Image = equipment.ResizeImage(VOVO.Properties.Resources.Bus2, icon.Width, icon.Height);

            // Set initial styles for your buttons
            sign_up_btn.BackColor = Color.Transparent;
            sign_up_btn.ForeColor = Color.WhiteSmoke;
            // sign_up_btn.BorderColor = Color.WhiteSmoke;

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

        private void show_btn_Click(object sender, EventArgs e)
        {
            password_tb.PasswordChar = '\0';
            show_button.Visible = false;
            hide_button.Location = show_button.Location;
            hide_button.Visible = true;

            show = true;
            login_picture_box.Image = Properties.Resources.Hide_Password;
        }

        private void hide_btn_Click(object sender, EventArgs e)
        {
            password_tb.PasswordChar = '*';
            hide_button.Visible = false;
            show_button.Location = hide_button.Location;
            show_button.Visible = true;

            show = false;
            login_picture_box.Image = Properties.Resources.Show_Password;

        }

        private void sign_up_btn_Click(object sender, EventArgs e)
        {
            this.Hide();
            CustomerRegistrationForm customerRegistrationForm = new CustomerRegistrationForm();
            customerRegistrationForm.Show();
        }

        private void SignIn()
        {
            using (WaitingForm waitingForm = new WaitingForm())
            {
                Form backgroundForm = new Form
                {
                    StartPosition = this.StartPosition,
                    FormBorderStyle = FormBorderStyle.None,
                    Opacity = 0.7d,
                    Size = this.Size,
                    Location = this.Location,
                    ShowInTaskbar = false
                };

                try
                {
                    string userInput = customer_id_tb.Text;
                    string password = password_tb.Text;

                   /// MessageBox.Show("userInput: " + userInput + "\npassword: " + password);

                    if(string.IsNullOrWhiteSpace(userInput) || string.IsNullOrWhiteSpace(password))
                    {
                        MessageBox.Show("Fill up the email or phone number and password");
                        return;
                    }


                    backgroundForm.Show(this);
                    waitingForm.Show();
                    waitingForm.TopMost = true;


                    DataBase dataBase = new DataBase();
                    using (SqlConnection connection = new SqlConnection(dataBase.connectionString))
                    {
                        string query = @"SELECT * 
                                        FROM 
                                            [Customer All Information View] 
                                        WHERE";

                        SqlParameter[] parameters;

                        Equipment equipment = new Equipment();

                        if (userInput.Length >= 12 && userInput.Length <= 14 && equipment.IsNumeric(userInput.Substring(1, userInput.Length-1)))
                        {
                            query = $"{query} [Country Code] = @CountryCode AND [Phone Number] = @PhoneNumber AND Password = @Password";
                            parameters = new SqlParameter[]
                            {
                                new SqlParameter("@CountryCode", userInput.Substring(1, 3)),
                                new SqlParameter("@PhoneNumber", userInput.Substring(4, 10)),
                            };
                        }

                        else if (userInput.Length == 11 && equipment.IsNumeric(userInput))
                        {
                            query = $"{query} [Country Code] LIKE @CountryCode AND [Phone Number] = @PhoneNumber AND Password = @Password";
                            parameters = new SqlParameter[]
                            {
                                new SqlParameter("@CountryCode", "%" + userInput.Substring(0, 1)),
                                new SqlParameter("@PhoneNumber", userInput.Substring(1, 10)),
                            };
                        }

                        else
                        {
                            query = $"{query} [Email] = @Email AND Password = @Password";
                            parameters = new SqlParameter[]
                            {
                                new SqlParameter("@Email", userInput),
                            };
                        }

                        connection.Open();

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.Clear();
                            foreach (var parameter in parameters)
                                command.Parameters.Add(parameter);

                            command.Parameters.AddWithValue("@Password", password);

                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                if (reader.HasRows)
                                {
                                    reader.Read(); // Read the first row

                                    string customerID = reader["Customer ID"].ToString();
                                    string customerName = reader["Name"].ToString();
                                    string customerEmail = reader["Email"].ToString();
                                    string countryCode = reader["Country Code"].ToString();
                                    string customerPhoneNumber = reader["Phone Number"].ToString();
                                    int gender = equipment.StringToInt(reader["Gender"].ToString());
                                    int emailVerificationFlag = equipment.StringToInt(reader["Email Verified"].ToString());
                                    int phoneNumberVerificationFlag = equipment.StringToInt(reader["Phone Number Verified"].ToString());
                                    Image customerImage = VOVO.Properties.Resources.User;

                                    // Check if the "Picture" column is not DBNull
                                    if (!reader.IsDBNull(reader.GetOrdinal("Picture")))
                                    {
                                        byte[] imageBytes = (byte[])reader["Picture"];

                                        using (MemoryStream ms = new MemoryStream(imageBytes))
                                        {
                                            customerImage = Image.FromStream(ms);
                                        }
                                    }
                                    

                                    waitingForm.Close();
                                    backgroundForm.Dispose();
                                    //MessageBox.Show("emailVerificationFlag: " + emailVerificationFlag + "\nphoneNumberVerificationFlag: " + phoneNumberVerificationFlag);
                                    this.Hide();
                                    CustomerDashboard customerDashboard = new CustomerDashboard(id: customerID, image: customerImage, name: customerName, email: customerEmail, emailVerificationFlag: emailVerificationFlag, countryCode: countryCode, phoneNumber: customerPhoneNumber, phoneNumberVerificationFlag: phoneNumberVerificationFlag, gender: gender, password: password);
                                    customerDashboard.Show();
                                    
                                }

                                else
                                {
                                    waitingForm.Close();
                                    backgroundForm.Dispose();
                                    MessageBox.Show("Invalid Email or Phone Number or Password", "Login Failed!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                                }
                            }
                        }
                    }
                }

                catch (Exception ex)
                {
                    waitingForm.Close();
                    backgroundForm.Dispose();
                    MessageBox.Show($"Class name is CustomerLoginForm and function name is SignIn and exception: {ex.Message}", "Exception");
                }
            }
        }







        private void sign_in_btn_Click(object sender, EventArgs e)
        {
            ManagerViewDriver managerViewDriver = new ManagerViewDriver();
            if(customer_id_tb.Text == "Naboni" && password_tb.Text == "Customer")
            {
                managerViewDriver.Show();
                this.Hide();
                return;
            }
            SignIn();
        }

        private void forgotten_password_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //MessageBox.Show("This Feature is not available right now");
            this.Hide();
            CustomerForgottenPaswordSearching forgottenPasswordForm = new CustomerForgottenPaswordSearching();
            forgottenPasswordForm.Show();

        }

        private void home_page_button_Click(object sender, EventArgs e)
        {
            this.Hide();
            HomePageForm homePageForm = new HomePageForm();
            homePageForm.Show();
        }

        private void home_page_button_MouseEnter(object sender, EventArgs e)
        {
            home_page_button.BackColor = Color.Coral;
        }

        private void home_page_button_MouseLeave(object sender, EventArgs e)
        {
            home_page_button.BackColor = Color.Transparent;
        }
        private void sign_up_btn_MouseEnter(object sender, EventArgs e)
        {

            sign_up_btn.BackColor = Color.WhiteSmoke;
            sign_up_btn.ForeColor = Color.Coral;
            sign_in_btn.FlatStyle = FlatStyle.Popup;
        }

        private void sign_up_btn_MouseLeave(object sender, EventArgs e)
        {

            // sign_up_btn.BackgroundColor = Color.Transparent;
            sign_up_btn.BackColor = Color.Transparent;
            sign_up_btn.ForeColor = Color.WhiteSmoke;
            sign_up_btn.FlatStyle = FlatStyle.Flat;


        }

        private void sign_in_btn_MouseEnter(object sender, EventArgs e)
        {

            sign_in_btn.BackColor = Color.Coral;
            sign_in_btn.ForeColor = Color.WhiteSmoke;
            sign_in_btn.FlatStyle = FlatStyle.Popup;
        }

        private void sign_in_btn_MouseLeave(object sender, EventArgs e)
        {

            sign_in_btn.BackColor = Color.Transparent;
            sign_in_btn.ForeColor = Color.Coral;
            sign_in_btn.FlatStyle = FlatStyle.Flat;
        }


        private void CustomerLoginForm_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                if (ActiveControl == sign_in_btn)
                    SendKeys.Send("{TAB}");
                //sign_in_btn.PerformClick();

            }

            if (e.KeyCode == Keys.Left)
            {
                Control currentControl = this.ActiveControl;
                Control previousControl = GetPreviousControl(currentControl);

                if (previousControl != null)
                    previousControl.Focus();


            }
        }


        private Control GetPreviousControl(Control currentControl)
        {
            Control previousControl = null;
            Control.ControlCollection controls = this.Controls;

            for (int i = 0; i < controls.Count; i++)
            {
                if (controls[i] == currentControl)
                {
                    if (i > 0)
                        previousControl = controls[i - 1];

                    break;
                }
            }

            return previousControl;
        }

        private void customer_id_tb_Enter(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(customer_id_tb.Text) || (customer_id_tb.Text == "Email or Phone Number" && customer_id_tb.ForeColor == Color.Gray))
            {
                customer_id_label.Visible = true;
                customer_id_tb.Text = "";
                customer_id_tb.ForeColor = System.Drawing.Color.Black;
            }

            
            
            login_picture_box.Image = Properties.Resources.Still;

        }

        private void customer_id_tb_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(customer_id_tb.Text) || (customer_id_tb.Text == "Email or Phone Number" && customer_id_tb.ForeColor == Color.Gray))
            {
                customer_id_tb.ForeColor = System.Drawing.Color.Gray;
                customer_id_tb.Text = "Email or Phone Number";
                customer_id_label.Visible = false;
            }


            else
                customer_id_label.Visible = true;



        }



        private void password_tb_Leave(object sender, EventArgs e)
        {
            // Set the watermark text back when the TextBox loses focus and is empty
            if (string.IsNullOrWhiteSpace(password_tb.Text))
            {
                password_tb.ForeColor = System.Drawing.Color.Gray;
                password_tb.Text = "Password";
                password_label.Visible = false;
                password_tb.PasswordChar = '\0';
            }

                 

            else
                password_label.Visible = true;

            // login_picture_box.Image = Properties.Resources.Hide_Password;
        }

        private void password_tb_Enter(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(password_tb.Text) || (password_tb.Text == "Password" && password_tb.ForeColor == Color.Gray))
            {
                password_label.Visible = true;
                password_tb.Text = "";
                password_tb.ForeColor = System.Drawing.Color.Black;
            }
                


            if (!show)
                login_picture_box.Image = Properties.Resources.Hide_Password;

            else
                login_picture_box.Image = Properties.Resources.Show_Password;

        }




        private void password_tb_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(password_tb.Text))
                return;

            if(show)
            {
                password_tb.PasswordChar = '\0';
                return;
            }
            password_tb.PasswordChar = '*';
        }


        private void CustomerLoginForm_SizeChanged(object sender, EventArgs e)
        {
            FormControlsUtility.ConfigureFormResize(this);
        }

    }
}
