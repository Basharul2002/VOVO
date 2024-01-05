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
using Tensorflow;
using static QRCoder.PayloadGenerator;

namespace VOVO
{
    public partial class VerifyCustomer : Form
    {
        private string id, name, email, countryCode, phoneNumber, password, component;
        private bool edit, verify, add, password_change, delete, nameUpdate, imageUpdate, genderUpdate;
        private Image image;
        private string newEmail, newCountryCode, newPhoneNumber, _password, otp;

        private DateTime OTPCreationTime = DateTime.Now; // Record the time when the OTP is generated
        private TimeSpan remainingTime;
        private int gender;
        private DialogResult result;

        public string VerifiedEmail { private set; get; }
        public string VerifiedCountryCode { private set; get; }
        public string VerifiedPhoneNumber { private set; get; }


        // Constructor
        public VerifyCustomer()
        {
            InitializeComponent();
            FormControlsUtility.ConfigureFormResize(this);
        }

        public VerifyCustomer(string id, Image image = null, string name = "", int gender = 0, string email = "", string countryCode = "", string phoneNumber = "", string password = "",
            bool verify = false, bool edit = false, bool add = false, bool password_change = false, bool delete = false, bool nameUpdate = false, bool imageUpdate = false,
            bool genderUpdate = false, string component = "") : this()
        {
            this.id = id;
            this.image = image;
            this.name = name;
            this.gender = gender;
            this.email = email;
            this.countryCode = countryCode;
            this.phoneNumber = phoneNumber;
            this.password = password;
            this.edit = edit;
            this.verify = verify;
            this.add = add;
            this.delete = delete;
            this.nameUpdate = nameUpdate;
            this.imageUpdate = imageUpdate;
            this.genderUpdate = genderUpdate;
            this.component = component;
            this.password_change = password_change;

            CustomDesign();
            Data();
        }




        // Window 
        // Rounded Corners  




        // Event handler for when the mouse is pressed down on the border_panel.
        private void top_border_panel_MouseDown(object sender, MouseEventArgs e)
        {
            FormControlsUtility.AttachDraggableTitleBar(top_border_panel);

        }



        // Window state
        // Close button 
        private void close_btn_Click(object sender, EventArgs e)
        {
            //FormControlsUtility.ConfigureCloseButton(close_btn);
            this.Hide();
        }
        private void close_btn_MouseEnter(object sender, EventArgs e)
        {
            //.ConfigureCloseButton(close_btn)
            

        }
        private void close_btn_MouseLeave(object sender, EventArgs e)
        {
           // FormControlsUtility.ConfigureCloseButton(close_btn);

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




        // Functions
        // Design
        private void CustomDesign()
        {
            this.FormBorderStyle = FormBorderStyle.None;
            if (!password_change)
            {
                password_verify_panel.Visible = true;
                email_confirm_panel.Visible = false;
                phone_number_confirm_code_panel.Visible = false;
                add_email_panel.Visible = false;
                add_phone_number_panel.Visible = false;
                change_password_panel.Visible = false;

                return;
            }


            password_verify_panel.Visible = false;
            change_password_panel.Visible = true;

        }
        private void Data()
        {
            email_label.Text = this.email;
            phone_number_label.Text = this.countryCode + " " + this.phoneNumber;
        }

        private void UpdateSubmitButtonState()
        {
            // Check if both textboxes have non-empty text
            if (!string.IsNullOrWhiteSpace(current_password_tb.Text) && !string.IsNullOrWhiteSpace(new_password_tb.Text) && !string.IsNullOrWhiteSpace(re_type_password_tb.Text))
            {
                if (new_password_tb.Text.Length < 6)
                {
                    new_password_warning_label.Visible = true;
                    return;
                }

                new_password_warning_label.Visible = false;
                if (new_password_tb.Text != re_type_password_tb.Text)
                {
                    re_type_password_warning_label.Visible = true;
                    return;
                }
                re_type_password_warning_label.Visible = false;
                change_password_button.Enabled = true; // Enable the button
                change_password_button.BackColor = Color.Coral;
            }


        }

        private void MailSent()
        {

            Equipment equipment = new Equipment();
            otp = equipment.GetOTP();

            Mail mail = new Mail();
            email_confirm_panel.Visible = true;
            if (verify)
                mail.EmailVerify(name, email, otp);

            else
                mail.EmailVerify(name, newEmail, otp);

        }
        private void StartTimer()
        {
            timer = new Timer();
            timer.Interval = 1000; // Update every 1 second
            timer.Tick += TimerTick;
            timer.Start();
        }



        // Action Event
        // TImer
        private void TimerTick(object sender, EventArgs e)
        {
            TimeSpan timeElapsed = DateTime.Now - OTPCreationTime;

            TimeSpan remainingTime = TimeSpan.FromMinutes(2) - timeElapsed;

            if (component == "Email")
            {
                HandleEmailTimerTick(remainingTime);
            }
            else if (component == "Phone Number")
            {
                HandlePhoneNumberTimerTick(remainingTime);
            }
        }

        private void HandleEmailTimerTick(TimeSpan remainingTime)
        {
            if (remainingTime.TotalSeconds > 0)
            {
                new_mail_request_label.Text = $"You can request verification code within {remainingTime:mm\\:ss} minutes";
                new_mail_request_label.Visible = true;
                resend_verfication_code_email_button.Enabled = false;
                resend_verfication_code_email_button.BackColor = Color.DarkSalmon;
            }

            else
            {
                new_mail_request_label.Text = "You can request verification";
                new_mail_request_label.Visible = true;
                resend_verfication_code_email_button.Enabled = true;
                resend_verfication_code_email_button.BackColor = Color.Coral;
                resend_verfication_code_email_button.Cursor = Cursors.Hand;
            }
        }

        private void HandlePhoneNumberTimerTick(TimeSpan remainingTime)
        {
            if (remainingTime.TotalSeconds > 0)
            {
                new_sms_request_label.Text = $"You can request verification code within {remainingTime:mm\\:ss} minutes";
                new_sms_request_label.Visible = true;
                resend_verfication_code_phone_number_button.Enabled = false;
                resend_verfication_code_phone_number_button.BackColor = Color.DarkSalmon;
            }
            else
            {
                new_sms_request_label.Text = "You can request verification";
                new_sms_request_label.Visible = true;
                resend_verfication_code_phone_number_button.Enabled = true;
                resend_verfication_code_phone_number_button.BackColor = Color.Coral;
                resend_verfication_code_phone_number_button.Cursor = Cursors.Hand;
            }
        }


        // Password Panel
        // Textbox focus Enter / Leave
        private void password_tb_Enter(object sender, EventArgs e)
        {
            password_label.Visible = true;
        }

        private void password_tb_Leave(object sender, EventArgs e)
        {
            password_label.Visible = string.IsNullOrWhiteSpace(password_tb.Text);
        }

        // Password hide or show
        private void TogglePasswordVisibility(bool showPassword)
        {
            password_tb.UseSystemPasswordChar = showPassword; // Set '\0' to show password, '*' to hide
            password_verify_show_button.Visible = !showPassword;
            password_verify_hide_button.Visible = showPassword;
            password_verify_hide_button.Location = password_verify_show_button.Location;
        }

        private void password_verify_show_button_Click(object sender, EventArgs e)
        {
            TogglePasswordVisibility(true);
        }

        private void password_verify_hide_button_Click(object sender, EventArgs e)
        {
            TogglePasswordVisibility(false);
        }

        // New window
        private void confirm_password_button_Click(object sender, EventArgs e)
        {
            if (password_tb.Text != password)
            {
                wrong_password_label.Visible = true;
                return;
            }

            password_verify_panel.Visible = false;
            DataBase dataBase = new DataBase();
            Equipment equipment = new Equipment();
            if (edit)
            {
                if (!string.IsNullOrWhiteSpace(name) && image != null)
                {
                    bool flag = dataBase.UpdateCustomerInformation(this.id, this.name, equipment.ResizeImage(this.image, 1000, 1000), this.gender, nameUpdate, imageUpdate, genderUpdate);
                    if (flag)
                    {
                        this.Hide();
                        this.DialogResult = DialogResult.OK;
                    }
                }
            }
            else if (verify)
            {
                if (component == "Email")
                {
                    bool flag = dataBase.EmailCheckExistsCheck(this.email);
                    if (flag)
                    {
                        email_confirm_panel.Visible = true;
                        MailSent();
                        StartTimer();
                    }
                }
                else if (component == "Phone Number")
                {
                    phone_number_confirm_code_panel.Visible = true;
                    phone_number_label.Text = this.countryCode + " " + this.phoneNumber;
                    StartTimer();
                }
            }
            else if (add)
            {
                if (component == "Email")
                {
                    add_email_panel.Visible = true;
                    StartTimer();
                }
                else if (component == "Phone Number")
                {
                    add_phone_number_panel.Visible = true;
                    StartTimer();
                }
            }

            else if (delete)
            {
                dataBase.DataDeleted(id, "Customer");
                this.DialogResult = DialogResult.Yes;
                this.Close();
                CustomerLoginForm customerLoginForm = new CustomerLoginForm();
                customerLoginForm.Show();
            }
        }





        // Email verfication code panel
        // Textbox foucs Enter / Leave
        private void email_confirmation_code_tb_Enter(object sender, EventArgs e)
        {
            email_verification_code_label.Visible = true;
        }
        private void email_confirmation_code_tb_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(email_confirmation_code_tb.Text))
            {
                email_verification_code_label.Visible = false;
                return;
            }
            email_verification_code_label.Visible = true;
        }

        // Action Event
        private void email_confirmation_code_button_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(email_confirmation_code_tb.Text))
            {
                if (otp != email_confirmation_code_tb.Text)
                {
                    email_conformation_code_warning_label.Visible = true;
                    email_conformation_code_warning_label.Text = "Invalid Verification Code";
                    return;
                }

                else
                {
                    email_conformation_code_warning_label.Visible = false;

                    if (verify && component == "Email")
                    {
                        this.Hide();
                        MessageBox.Show("Email Successfully verified", "VOVO", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        DataBase dataBase = new DataBase();
                        EmailPhoneNumberVerficationEnum gender = EmailPhoneNumberVerficationEnum.Verified;
                        int intValue = (int)gender;
                        dataBase.EmailVerificationUpdate(id, intValue.ToString());

                        DialogResult = DialogResult.OK;
                    }


                    else if (add && component == "Email")
                    {
                        this.Hide();
                        DataBase dataBase = new DataBase();
                        bool registerEmail = dataBase.EmailUpdate(this.id, newEmail);

                        // Set the VerifiedEmail property
                        VerifiedEmail = newEmail;

                        // Close the dialog
                        DialogResult = DialogResult.OK;
                        Close();

                        if (registerEmail)
                            MessageBox.Show("Email Successfully Added", "VOVO", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }

                }
            }

            else
            {
                email_conformation_code_warning_label.Visible = true;
                email_conformation_code_warning_label.Text = "Invalid Verification Code";
                return;
            }

        }



        private void resend_verfication_code_email_button_Click(object sender, EventArgs e)
        {
            OTPCreationTime = DateTime.Now;
            resend_verfication_code_email_button.Enabled = false;
            MailSent();
            StartTimer();
        }




        // Phone number verification code panel
        private void mobile_number_confirmation_code_tb_Enter(object sender, EventArgs e)
        {
            ShowPhoneNumberConfirmationCodeLabel(true);
        }

        private void mobile_number_confirmation_code_tb_Leave(object sender, EventArgs e)
        {
            ShowPhoneNumberConfirmationCodeLabel(!string.IsNullOrWhiteSpace(add_phone_number_tb.Text));
        }

        private void ShowPhoneNumberConfirmationCodeLabel(bool isVisible)
        {
            phone_number_confirmation_code_label.Visible = isVisible;
        }

        private void sms_confirmation_code_button_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(mobile_number_confirmation_code_tb.Text))
            {
                DataBase dataBase = new DataBase();
                string[] validCodes = { "1111", "2002", "2006", "2222", "3333" };

                if (validCodes.Contains(mobile_number_confirmation_code_tb.Text))
                {
                    if ((verify && component == "Phone Number") || (add && component == "Phone Number"))
                    {
                        HandlePhoneNumberVerification(dataBase);

                        // Close the dialog
                        DialogResult = result;
                        this.Close();
                        VerifiedCountryCode = newCountryCode;
                        VerifiedPhoneNumber = newPhoneNumber;
                    }
                }
                else
                {
                    ShowVerificationCodeError("Invalid Verification Code");
                }
            }
        }

        private void HandlePhoneNumberVerification(DataBase dataBase)
        {
            this.Hide();

            if (verify && component == "Phone Number")
            {
                ShowSuccessMessageAndVerifyPhoneNumber(dataBase);
            }
            else if (add && component == "Phone Number")
            {
                bool registerSuccess = dataBase.PhoneNumberUpdate(this.id, newCountryCode, newPhoneNumber);
                result = DialogResult.OK;
                if (registerSuccess)
                    ShowSuccessMessage("Phone Number Successfully Added");

            }
        }

        private void ShowVerificationCodeError(string message)
        {
            phone_number_conformation_code_warning_label.Visible = true;
            phone_number_conformation_code_warning_label.Text = message;
        }

        private void ShowSuccessMessageAndVerifyPhoneNumber(DataBase dataBase)
        {
            EmailPhoneNumberVerficationEnum gender = EmailPhoneNumberVerficationEnum.Verified;
            int intValue = (int)gender;
            dataBase.PhoneNumberVerificationUpdate(id, intValue.ToString());

            MessageBox.Show("Phone Number Successfully verified", "VOVO", MessageBoxButtons.OK, MessageBoxIcon.Information);

            result = DialogResult.OK;
        }

        private void ShowSuccessMessage(string message)
        {
            MessageBox.Show(message, "VOVO", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void resend_verfication_code_phone_number_button_Click(object sender, EventArgs e)
        {
            OTPCreationTime = DateTime.Now;
            resend_verfication_code_phone_number_button.Enabled = false;
            StartTimer();
        }




        //  Add new email address
        // Focus
        private void add_email_tb_Enter(object sender, EventArgs e)
        {
            add_email_label.Visible = true;
        }
        private void add_email_tb_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(add_email_tb.Text))
            {
                add_email_label.Visible = true;
                return;
            }

            add_email_label.Visible = false;
        }
        // Text Change
        private void add_email_tb__TextChanged(object sender, EventArgs e)
        {
            Equipment equipment = new Equipment();
            if (!equipment.IsEmail(add_email_tb.Text))
            {
                add_email_button.Enabled = false;
                add_email_button.BackColor = Color.DarkSalmon;
                return;
            }

            add_email_button.Enabled = true;
            add_email_button.BackColor = Color.Coral;

        }
        // Acttion Event
        private void add_email_button_Click(object sender, EventArgs e)
        {
            newEmail = add_email_tb.Text;

            if (string.IsNullOrWhiteSpace(newEmail))
            {
                ShowErrorAlert("Enter Email");
            }
            else if (email == newEmail)
            {
                ShowEmailError("Enter new email");
            }
            else
            {
                DataBase dataBase = new DataBase();
                bool flag = dataBase.EmailCheckExistsCheck(newEmail);
              //  MessageBox.Show(flag.ToString());
                if (flag)
                {
                    ShowEmailError("This email is already registered. Enter a new email.");
                }
                else
                {
                    add_email_label.Visible = true;
                    add_email_panel.Visible = false;
                    email_confirm_panel.Visible = true;
                    email_label.Text = newEmail;
                    MailSent();
                    StartTimer();
                }
            }
        }

        private void ShowErrorAlert(string message)
        {
            CustomAlertBox customAlertBox = new CustomAlertBox();
            customAlertBox.Alert(message, CustomAlertBox.enmType.Error);
        }

        private void ShowEmailError(string message)
        {
            add_email_label.Visible = true;
            add_email_warning_message_label.Text = message;
            add_email_warning_message_label.Visible = true;
        }




        // Add new phone number
        // Focus 
        private void add_phone_number_tb_Enter(object sender, EventArgs e)
        {
            add_phone_number_label.Visible = true;

        }
        private void add_phone_number_tb_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(add_phone_number_tb.Text))
            {
                add_phone_number_label.Visible = true;
                return;
            }

            add_phone_number_label.Visible = false;

        }
        private void add_phone_number_button_Click(object sender, EventArgs e)
        {
            newCountryCode = country_code_tb.Text;
            newPhoneNumber = add_phone_number_tb.Text;

            if (string.IsNullOrWhiteSpace(newCountryCode) && string.IsNullOrWhiteSpace(newPhoneNumber))
            {
                ShowPhoneNumberError("Choose your country code and enter a phone number");
            }
            else if (string.IsNullOrWhiteSpace(newCountryCode))
            {
                ShowPhoneNumberError("Choose your country code");
            }
            else if (string.IsNullOrWhiteSpace(newPhoneNumber))
            {
                ShowPhoneNumberError("Enter a phone number");
            }
            else
            {
                ValidityCheck validityCheck = new ValidityCheck();

                newCountryCode = newCountryCode.Substring(0, 4);

                string number = this.countryCode + this.phoneNumber;
                string newNumber = newCountryCode + newPhoneNumber;

              //  MessageBox.Show("number: " + number + "\nnewNumber: " + newNumber);
                if (number == newNumber)
                {
                    ShowPhoneNumberError("Enter a new phone number");
                }

                else if (!validityCheck.IsPhoneNumberValid(newPhoneNumber))
                {
                    ShowPhoneNumberError("Invalid phone number");
                }
                else
                {
                    DataBase dataBase = new DataBase();
                    if (dataBase.CheckExistingCustomerPhoneNumber(newCountryCode, newPhoneNumber))
                    {
                        ShowPhoneNumberError("This phone number already register");
                    }
                    else
                    {
                        add_phone_number_panel.Visible = false;
                        phone_number_confirm_code_panel.Visible = true;
                        phone_number_label.Text = newCountryCode + " " + newPhoneNumber;
                    }
                }
            }
        }

        private void ShowPhoneNumberError(string message)
        {
            add_phone_number_warning_message_label.Text = message;
            add_phone_number_warning_message_label.Visible = true;
        }




        // Update password Panel
        // Focus 
        private void current_password_tb_Enter(object sender, EventArgs e)
        {
            current_password_label.Visible = true;

        }

        private void add_email_tb_Click(object sender, EventArgs e)
        {

        }

        private void change_password_panel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void current_password_warning_label_Click(object sender, EventArgs e)
        {

        }

        private void re_type_password_label_Click(object sender, EventArgs e)
        {

        }

        private void new_password_label_Click(object sender, EventArgs e)
        {

        }

        private void re_type_password_warning_label_Click(object sender, EventArgs e)
        {

        }

        private void new_password_warning_label_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void add_phone_number_panel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void add_phone_number_label_Click(object sender, EventArgs e)
        {

        }

        private void add_phone_number_warning_message_label_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void add_email_panel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void add_email_label_Click(object sender, EventArgs e)
        {

        }

        private void add_email_warning_message_label_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void phone_number_confirm_code_panel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void phone_number_confirmation_code_label_Click(object sender, EventArgs e)
        {

        }

        private void phone_number_conformation_code_warning_label_Click(object sender, EventArgs e)
        {

        }

        private void phone_number_label_Click(object sender, EventArgs e)
        {

        }

        private void new_sms_request_label_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void email_confirm_panel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void email_verification_code_label_Click(object sender, EventArgs e)
        {

        }

        private void email_conformation_code_warning_label_Click(object sender, EventArgs e)
        {

        }

        private void new_mail_request_label_Click(object sender, EventArgs e)
        {

        }

        private void email_label_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void password_verify_panel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void password_label_Click(object sender, EventArgs e)
        {

        }

        private void wrong_password_label_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void top_border_panel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void icon_Click(object sender, EventArgs e)
        {

        }

        private void password_tb_Click(object sender, EventArgs e)
        {

        }

        private void re_type_password_tb_TextChanged(object sender, EventArgs e)
        {

        }

        private void email_confirmation_code_tb_Click(object sender, EventArgs e)
        {

        }

        private void mobile_number_confirmation_code_tb_Click(object sender, EventArgs e)
        {

        }

        private void add_phone_number_tb_Click(object sender, EventArgs e)
        {

        }

        private void country_code_tb_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void current_password_tb_Click(object sender, EventArgs e)
        {

        }

        private void new_password_tb_Click(object sender, EventArgs e)
        {

        }

        private void re_type_password_tb_Click(object sender, EventArgs e)
        {

        }

        private void current_password_tb_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(current_password_tb.Text))
            {
                current_password_label.Visible = true;
                return;
            }

            current_password_label.Visible = false;
        }
        private void new_password_tb_Enter(object sender, EventArgs e)
        {
            new_password_label.Visible = true;
        }



        private void new_password_tb_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(new_password_tb.Text))
            {
                new_password_label.Visible = false;
                return;
            }

            new_password_label.Visible = true;
        }
        private void re_type_password_tb_Enter(object sender, EventArgs e)
        {
            re_type_password_label.Visible = true;
        }
        private void re_type_password_tb_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(re_type_password_tb.Text))
            {
                re_type_password_label.Visible = false;
                return;
            }

            re_type_password_label.Visible = true;
        }




        // TextBox TextChanged
        private void current_password_tb__TextChanged(object sender, EventArgs e)
        {
            UpdateSubmitButtonState();
        }
        private void new_password_tb__TextChanged(object sender, EventArgs e)
        {
            UpdateSubmitButtonState();
        }
        private void re_type_password_tb__TextChanged(object sender, EventArgs e)
        {
            UpdateSubmitButtonState();
        }


        // Password show/hide
        private void current_password_show_button_Click(object sender, EventArgs e)
        {
            current_password_show_button.Visible = false;
            current_password_hide_button.Visible = true;
            current_password_hide_button.Location = current_password_show_button.Location;
            current_password_tb.UseSystemPasswordChar = false;
        }
        private void current_password_hide_button_Click(object sender, EventArgs e)
        {
            current_password_show_button.Visible = true;
            current_password_hide_button.Visible = false;
            current_password_show_button.Location = current_password_hide_button.Location;
            current_password_tb.UseSystemPasswordChar = true;
        }


        private void new_password_show_button_Click(object sender, EventArgs e)
        {
            new_password_show_button.Visible = false;
            new_password_hide_button.Visible = true;
            new_password_hide_button.Location = new_password_show_button.Location;
            new_password_tb.UseSystemPasswordChar = false;
        }
        private void new_password_hide_button_Click(object sender, EventArgs e)
        {
            new_password_show_button.Visible = true;
            new_password_hide_button.Visible = false;
            new_password_show_button.Location = new_password_hide_button.Location;
            new_password_tb.UseSystemPasswordChar = true;
        }

        private void re_type_password_show_button_Click(object sender, EventArgs e)
        {
            re_type_password_show_button.Visible = false;
            re_type_password_hide_button.Visible = true;
            re_type_password_hide_button.Location = re_type_password_show_button.Location;
            re_type_password_tb.UseSystemPasswordChar = false;
        }


        private void re_type_password_hide_button_Click(object sender, EventArgs e)
        {
            re_type_password_show_button.Visible = true;
            re_type_password_hide_button.Visible = false;
            re_type_password_show_button.Location = re_type_password_hide_button.Location;
            re_type_password_tb.UseSystemPasswordChar = true;
        }


        // Action Event
        private void change_password_button_Click(object sender, EventArgs e)
        {
            if (password != current_password_tb.Text)
            {
                current_password_warning_label.Visible = true;
                return;
            }

            DataBase dataBase = new DataBase();
            dataBase.UpdateCustomerPassword(this.id, new_password_tb.Text);
        }
        private void forget_password_link_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Hide();
            CustomerResetPassword customerResetPassword = new CustomerResetPassword();
            customerResetPassword.Show();
        }
        private void VerifyCustomer_SizeChanged(object sender, EventArgs e)
        {
            FormControlsUtility.ConfigureFormResize(this);

        }

    }
}
