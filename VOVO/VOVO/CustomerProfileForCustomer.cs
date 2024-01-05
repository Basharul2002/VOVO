using Org.BouncyCastle.Crypto;
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
using Twilio.TwiML.Voice;

namespace VOVO
{
    public partial class CustomerProfileForCustomer : Form
    {
        private string id, name, email, countryCode, phoneNumber, password;
        private Image image;
        private bool edit, picChange, nameUpdate, genderUpdate;
        private int emailVerificationFlag, phoneNumberVerificationFlag, gender, emailVerify, phoneNumberVerfiy, update_Gender_Flag;



        // Constructor
        public CustomerProfileForCustomer()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            FormControlsUtility.ConfigureFormResize(this);
        }
        public CustomerProfileForCustomer(string id, Image image, string name, string email, int emailVerificationFlag, string countryCode, string phoneNumber, int phoneNumberVerificationFlag, int gender, string password, bool edit = false) : this()
        {
            this.id = id;
            this.image = image;
            this.name = name;
            this.email = email;
            this.emailVerificationFlag = emailVerificationFlag;
            this.countryCode = countryCode;
            this.phoneNumber = phoneNumber;
            this.phoneNumberVerificationFlag = phoneNumberVerificationFlag;
            this.gender = gender;
            this.password = password;
            this.edit = edit;

            CustomDesign();
            ShowCustomerDetails();
            Verified_Button(emailVerificationFlag, phoneNumberVerificationFlag);

        }


        // Window
        // Window resize
        private void CustomerProfileForCustomer_SizeChanged(object sender, EventArgs e)
        {
            FormControlsUtility.ConfigureFormResize(this);

        }



        // Rounded Corners  


        // Top Panel
        private void top_border_panel_MouseDown(object sender, MouseEventArgs e)
        {
            FormControlsUtility.AttachDraggableTitleBar(top_border_panel);

        }



        // Window state
        // Close button 
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

        // Maximize Button
        private void maximize_btn_Click(object sender, EventArgs e)
        {
            FormControlsUtility.ConfigureMaximizeButton(maximize_btn, maximized_btn);

        }

        // Maximized button
        private void maximized_btn_Click(object sender, EventArgs e)
        {
            FormControlsUtility.ConfigureMaximizedButton(maximize_btn, maximized_btn);

        }

        // Minimized button
        private void minimize_btn_Click(object sender, EventArgs e)
        {
            FormControlsUtility.ConfigureMinimizeButton(minimize_btn);

        }





        // Function
        private void CustomDesign()
        {
            change_email_button.Enabled = false;
            change_phone_number_button.Enabled = false;
            change_picture_button.Visible = false;
            change_password_button.Visible = false;
            delete_update_button.Enabled = true;

            // VerficationCheck();

            if (edit)
            {
                change_password_button.Visible = true;
                name_tb.Enabled = true;
                name_tb.ReadOnly = false;

                change_picture_button.Visible = true;
                change_email_button.Visible = true;
                change_phone_number_button.Visible = true;

                change_email_button.Enabled = true;
                change_phone_number_button.Enabled = true;

                not_say_radio_button.Enabled = true;
                male_radio_button.Enabled = true;
                female_radio_button.Enabled = true;
                others_radio_button.Enabled = true;

                delete_update_button.Visible = true;
                delete_update_button.Text = "Update";
                delete_update_button.BackColor = Color.DarkSalmon;
                delete_update_button.Enabled = false;

                delete_update_button.Refresh(); // Force the button to refresh its appearance
            }



            // Email Verification
            string verification = ((EmailPhoneNumberVerficationEnum)emailVerify).ToString();
            if (verification == "Verify")
            {
                email_verify_button.Enabled = true;
                email_verify_button.Text = verification;
            }

            else
            {
                email_verify_button.Enabled = false;
                email_verify_button.Text = verification;
            }

            // Phone Number Verfication
            verification = ((EmailPhoneNumberVerficationEnum)phoneNumberVerfiy).ToString();
            if (verification == "Verify")
            {
                phone_number_verify_button.Enabled = true;
                phone_number_verify_button.Text = verification;
            }

            else
            {
                phone_number_verify_button.Enabled = false;
                phone_number_verify_button.Text = verification;
            }

            // MessageBox.Show("Custom Design Called");
            Button_Cursor();
        }
        private void ShowCustomerDetails()
        {
            Equipment equipment = new Equipment();
            id_tb.Text = id;
            picture_box.Image = equipment.ResizeImage(this.image, picture_box.Width, picture_box.Height);
            name_tb.Text = name;
            email_tb.Text = email;
            phone_number_tb.Text = countryCode + phoneNumber;

            GenderSelection();

        }


        private void VerficationCheck()
        {
            DataBase dataBase = new DataBase();
            try
            {
                using (SqlConnection connection = new SqlConnection(dataBase.connectionString))
                {
                    string query = "SELECT * FROM [Customer Verify Information] WHERE [Customer ID] = @ID";
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.Clear();
                        command.Parameters.AddWithValue("@ID", id);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Equipment equipment = new Equipment();
                                string email = reader["Email Verified"].ToString();
                                string phoneNumber = reader["Phone Number Verified"].ToString();
                                emailVerify = equipment.StringToInt(email);
                                phoneNumberVerfiy = equipment.StringToInt(phoneNumber);
                            }
                        }
                    }
                }
                /* MessageBox.Show("emailVerify: " + emailVerify + "\nphoneNumberVerfiy: " + phoneNumberVerfiy +
                     "\nEmail Enum: " + ((EmailPhoneNumberVerficationEnum)emailVerify).ToString() + "\nPhone Number enum: "
                     + ((EmailPhoneNumberVerficationEnum)phoneNumberVerfiy).ToString());
                */
                Verified_Button(emailVerify, phoneNumberVerfiy);


            }

            catch (Exception ex)
            {
                MessageBox.Show("Class name is CustomerProfileForCustomer function name is VerficationCheck() and exception: " + ex.Message, "Exception");
            }
        }

        private void Verified_Button(int emailVerify = 0, int phoneNumberVerfiy = 0)
        {
            string message = ((EmailPhoneNumberVerficationEnum)emailVerify).ToString();
            if (message == "Verified")
            {
                email_verify_button.Text = message;
                email_verify_button.Enabled = false;
                email_verify_button.ForeColor = Color.Coral;
            }

            message = ((EmailPhoneNumberVerficationEnum)phoneNumberVerfiy).ToString();
            if (message == "Verified")
            {
                phone_number_verify_button.Text = message;
                phone_number_verify_button.Enabled = false;
                phone_number_verify_button.ForeColor = Color.Coral;
            }


        }
        private void UpdateButton()
        {
            string nameWithoutSpaces = new string(this.name.Where(c => !char.IsWhiteSpace(c)).ToArray());
            string inputNameWithoutSpace = new string(name_tb.Text.Where(c => !char.IsWhiteSpace(c)).ToArray());

            if ((picChange && picture_box.Image != null) || (!string.IsNullOrWhiteSpace(name_tb.Text) &&
                nameWithoutSpaces != inputNameWithoutSpace))
                UpdateButtonEnable();
            

            else if (gender != update_Gender_Flag)
                UpdateButtonEnable();



            else if (gender == update_Gender_Flag)
                if(edit)
                    UpdateButtonDisable();


        }


        private void UpdateButtonEnable()
        {

            delete_update_button.Enabled = true;
            delete_update_button.BackColor = Color.Coral;
            delete_update_button.Cursor = Cursors.Hand;
        }

        private void UpdateButtonDisable()
        {
            delete_update_button.BackColor = Color.DarkSalmon;
            delete_update_button.Enabled = false;
            nameUpdate = false;
        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void GenderSelection()
        {
            if (gender == 0)
                not_say_radio_button.Checked = true;


            else if (gender == 1)
                male_radio_button.Checked = true;


            else if (gender == 2)

                female_radio_button.Checked = true;

            else if (gender == 3)
                others_radio_button.Checked = true;

        }


        // Button
        private void Button_Cursor()
        {
            change_picture_button.Cursor = Cursors.Hand;
            change_email_button.Cursor = Cursors.Hand;
            change_password_button.Cursor = Cursors.Hand;
            delete_update_button.Cursor = Cursors.Hand;
            back_button.Cursor = Cursors.Hand;
            email_verify_button.Cursor = Cursors.Hand;
            phone_number_verify_button.Cursor = Cursors.Hand;

            if (email_verify_button.Text == "Verified")
            {
                email_verify_button.Cursor = Cursors.No;
                email_verify_button.ForeColor = Color.Coral;
            }

            if (phone_number_verify_button.Text == "Verified")
            {
                phone_number_verify_button.Cursor = Cursors.No;
                phone_number_verify_button.ForeColor = Color.Coral;
            }

            if (!delete_update_button.Enabled)
                delete_update_button.Cursor = Cursors.No;
            

        }



        // Textbox Text Changed
        private void name_tb__TextChanged(object sender, EventArgs e)
        {

            if (edit && (name == name_tb.Text || string.IsNullOrWhiteSpace(name_tb.Text)))
            {
                UpdateButtonDisable();
                return;
            }

            nameUpdate = true;
            UpdateButton();
        }





        // Action Event
        // Picture Change
        private void change_picture_button_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "JPEG files (*.jpg)|*.jpg|PNG files (*.png)|*.png|All files (*.*)|*.*";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedFile = openFileDialog.FileName;

                    // Perform the necessary actions with the selected file here
                    // For example, you can display the file path in a TextBox:
                    // Load the image from the selected file
                    Image originalImage = Image.FromFile(selectedFile);

                    // Resize the image to fit the PictureBox size
                    Image resizedImage = new Bitmap(originalImage, new Size(195, 195));

                    // Display the resized image in the PictureBox
                    picture_box.Image = resizedImage;
                    picChange = true;
                    UpdateButton();
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Class name is CustomerProfileForCustomer() function name is change_picture_button_Click() and exception: " + ex.Message, "Picture Error");
                picChange = false;
            }

        }


        // Password Change
        private void change_password_button_Click(object sender, EventArgs e)
        {
            using (VerifyCustomer verifyCustomer = new VerifyCustomer(id, name: name, password: password, password_change: true))
            {
                DialogResult result = verifyCustomer.ShowDialog();
                if (result == DialogResult.OK)
                {
                    this.Hide();
                }
            }

        }


        // Phone Number
        private void phone_number_verify_button_Click(object sender, EventArgs e)
        {
            // public VerifyCustomer(string id, string email = "",  string phoneNumber = "", bool verify = false, bool add = false, string component ="") : this()
            using (VerifyCustomer verifyCustomer = new VerifyCustomer(id, name: name, countryCode: countryCode, phoneNumber: phoneNumber, password: password, verify: true, component: "Phone Number"))
            {
                DialogResult dialogResult = verifyCustomer.ShowDialog();

                if (dialogResult == DialogResult.OK)
                {
                    Verified_Button(phoneNumberVerfiy: 1);
                }

            }
        }

        private void change_phone_number_button_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (VerifyCustomer verifyCustomer = new VerifyCustomer(id, name: name, password: password, countryCode: this.countryCode, phoneNumber: this.phoneNumber, add: true, component: "Phone Number"))
            {
                DialogResult dialogResult = verifyCustomer.ShowDialog();

                if (dialogResult == DialogResult.OK)
                {
                    this.countryCode = verifyCustomer.VerifiedCountryCode;
                    this.phoneNumber = verifyCustomer.VerifiedPhoneNumber;
                    phone_number_tb.Text = this.countryCode + this.phoneNumber;
                    email_tb.Text = this.email;
                }
            }
        }


        // Email
        private void email_verify_button_Click(object sender, EventArgs e)
        {
            using (VerifyCustomer verifyCustomer = new VerifyCustomer(id, name: name, email: email, password: password, verify: true, component: "Email"))
            {
                DialogResult dialogResult = verifyCustomer.ShowDialog();

                if (dialogResult == DialogResult.OK)
                {
                    Verified_Button(emailVerify: 1);
                }
            }
        }
        private void change_email_button_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (VerifyCustomer verifyCustomer = new VerifyCustomer(id, name: name, email: email, password: password, add: true, component: "Email"))
            {
                DialogResult result = verifyCustomer.ShowDialog();
                if (result == DialogResult.OK)
                {
                    this.email = verifyCustomer.VerifiedEmail;
                    email_tb.Text = this.email;
                }

            }
        }

        //  Gender
        private void radio_button_CheckedChanged(object sender, EventArgs e)
        {
            if (male_radio_button.Checked)
            {
                update_Gender_Flag = 1;
            }

            else if (female_radio_button.Checked)
            {
                update_Gender_Flag = 2;
            }

            else if (others_radio_button.Checked)
            {
                update_Gender_Flag = 3;
            }

            else if (not_say_radio_button.Checked)
            {
                update_Gender_Flag = 0;
            }

            if (this.gender != update_Gender_Flag)
            {
                genderUpdate = true;
                UpdateButton();

            }

            else
            {
                genderUpdate = false;
                UpdateButton();
            }

        }



        // Delete account
        private void delete_update_button_Click(object sender, EventArgs e)
        {
            VerifyCustomer verifyCustomer;
            DialogResult result;
            if (!edit)
            {
                result = MessageBox.Show("Are you sure?", "VOVO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    using (verifyCustomer = new VerifyCustomer(this.id, password: this.password, delete: true))
                    {
                        result = verifyCustomer.ShowDialog();
                        {
                            if (result == DialogResult.Yes)
                            {
                                this.Hide();
                                CustomerLoginForm customerLoginForm = new CustomerLoginForm();
                                customerLoginForm.Show();
                                return;
                            }
                        }
                    }

                }
            }

            // Update 
            // MessageBox.Show("gender" + update_Gender_Flag);
            // MessageBox.Show("genderUpdate: " + genderUpdate);
            verifyCustomer = new VerifyCustomer(id, image: picture_box.Image, name: name_tb.Text, gender: update_Gender_Flag, password: password, edit: true, nameUpdate: nameUpdate, imageUpdate: picChange, genderUpdate: genderUpdate);

            result = verifyCustomer.ShowDialog();
            if (result == DialogResult.OK)
            {
                delete_update_button.Enabled = false;
                delete_update_button.BackColor = Color.DarkSalmon;

                RestoreData();
            }
        }

        private void RestoreData()
        {
            if (edit)
            {
                this.name = name_tb.Text;
                this.image = picture_box.Image;
                this.gender = update_Gender_Flag;
            }
        }

        private void back_button_Click(object sender, EventArgs e)
        {
            this.Hide();
            CustomerDashboard customerDashboard = new CustomerDashboard(this.id, this.image, this.name, this.email, this.emailVerificationFlag, this.countryCode, this.phoneNumber, this.phoneNumberVerificationFlag, this.gender, this.password);
            customerDashboard.Show();
        }
    }
}
