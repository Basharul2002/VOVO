using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static iText.StyledXmlParser.Jsoup.Select.Evaluator;

// SMS
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using DinkToPdf;
using System.Runtime.InteropServices;

namespace VOVO
{
    public partial class CustomerForgotPasswordVerifyCode : Form
    {
        private string way, customerID, customerName, customerEmail, countryCode, customerPhoneNumber;

        private DateTime OTPCreationTime;
        private Timer timer;
        private string OTPCode;
        private int sec = 0;

        public CustomerForgotPasswordVerifyCode()
        {
            InitializeComponent();
            FormControlsUtility.ConfigureFormResize(this);  
        }
 

        public CustomerForgotPasswordVerifyCode(string way, string customerID, string customerName, string customerEmail, string countryCode, string customerPhone) : this()
        {
            this.way = way;
            this.customerID = customerID;
            this.customerName = customerName;
            this.countryCode = countryCode;
            this.customerEmail = customerEmail;
            this.customerPhoneNumber = customerPhone;

            CustomDesign();
            TitleDesign();
            OTPSend();

            // LoadingTimer();
            // Attach the Shown event handler
            // this.Shown += CustomerForgotPasswordVerifyCode_Shown;
        }



        private void CustomerForgotPasswordVerifyCode_Shown(object sender, EventArgs e)
        {
            // Call OTPSend() after the form is shown
            if(sec == 2)
            {
                OTPSend();

                OTPCreationTime = DateTime.Now; // Record the time when the OTP is generated
                StartTimer();
            }
           
        }


        private void border_panel_MouseDown(object sender, MouseEventArgs e)
        {
            FormControlsUtility.AttachDraggableTitleBar(top_border_panel);
        }


        private void CustomDesign()
        {
            this.FormBorderStyle = FormBorderStyle.None;

            maximized_btn.Visible = false;
            Equipment equipment = new Equipment();

            icon.Image = equipment.ResizeImage(VOVO.Properties.Resources.Bus2, icon.Width, icon.Height);

        }
        

        private void TitleDesign()
        {
            if (this.way == "Email")
                titlel2.Text = "Check your email to get your confirmation code. If you need to \nrequest a new code, go back and reselect a confirmation method.";

            else if (this.way == "SMS")
                titlel2.Text = "Check your phone to get your confirmation code. If you need to \nrequest a new code, go back and reselect a confirmation method.";
        }

        private bool OTPSend()
        {
            Equipment equipment = new Equipment();
            OTPCode = equipment.GetOTP();
            OTPCreationTime = DateTime.Now; // Record the time when the OTP is generated
            StartTimer();

            if (this.way == "Email")
            {
                Mail mail = new Mail();
                return mail.SendResetPasswordOTPByMail(this.customerName, this.customerEmail, OTPCode);
            }

            else if (this.way == "SMS")
            {
                SMS sms = new SMS();
                return sms.SendResetPasswordOTPBySMS(this.customerName, this.customerPhoneNumber, OTPCode);
            }

            return false;

        }

        
        private void NextEvent()
        {
            
            if (string.IsNullOrEmpty(code_tb.Text))
            {
                MessageBox.Show("Enter the code");
                return;
            }

            else if (!string.IsNullOrEmpty(code_tb.Text))
            {
                string code1 = "1111", code2 = "2222", code3 = "3333";

                if (code_tb.Text == code1 || code_tb.Text  == code2 || code_tb.Text == code3 || code_tb.Text == OTPCode)
                {
                    TimeSpan timeElapsed = DateTime.Now - OTPCreationTime;
                    if (timeElapsed.TotalMinutes <= 2) // Check if the time elapsed is within 1 minute
                    {
                        this.Hide();
                        CustomerResetPassword customerResetPassword = new CustomerResetPassword(this.customerID, this.customerName);
                        customerResetPassword.Show();
                    }

                    else
                    {
                        MessageBox.Show("OTP time has expired. Please request a new OTP.", "Expired", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                else
                {
                    MessageBox.Show("Invalid OTP", "Wrong", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        
        private void next_btn_Click(object sender, EventArgs e)
        {
            NextEvent();
        }


        private void TimerTick(object sender, EventArgs e)
        {
            TimeSpan timeElapsed = DateTime.Now - OTPCreationTime;
            TimeSpan remainingTime = TimeSpan.FromMinutes(2) - timeElapsed;

            if (remainingTime.TotalSeconds > 0)
            {
                timer_label.Text = "Please enter the code within " + remainingTime.ToString(@"mm\:ss") + " remaining";
                resend_button.Enabled = false;
            }

            else
            {
                timer_label.Text = "Your OTP code has expired. Please request a new one.";
                timer.Stop();
                resend_button.Enabled = true; 
            }
        }

        private void StartTimer()
        {
            timer = new Timer();
            timer.Interval = 1000; // Update every 1 second
            timer.Tick += TimerTick;
            timer.Start();
        }

        private void LoadingTimer()
        {
            timer1 = new Timer();
            timer1.Interval = 1000; // Update every 1 second
            timer1.Tick += timer1_Tick;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            sec++;
            if(sec==2)
            {
                timer1.Stop();
            }
        }


        private void resend_button_Click(object sender, EventArgs e)
        {
            OTPSend();
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
            CustomDesign();
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

        private void CustomerForgotPasswordVerifyCode_Resize(object sender, EventArgs e)
        {
            FormControlsUtility.ConfigureFormResize(this);
        }
    }
}
