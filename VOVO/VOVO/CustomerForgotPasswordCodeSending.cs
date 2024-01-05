using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.IO;
using System.Threading;
using System.IO.Ports;
using System.Runtime.InteropServices;
using System.Speech.Synthesis;

namespace VOVO
{
    public partial class CustomerForgotPasswordCodeSending : Form
    {
        private string id, name, email, phoneNumber, countryCode;

        public CustomerForgotPasswordCodeSending()
        {
            InitializeComponent();
            FormControlsUtility.ConfigureFormResize(this);
        }

        // Rounded Corners  


        public CustomerForgotPasswordCodeSending(string id, string name, string email, string countryCode, string phoneNumber) : this()
        {
            this.id = id;
            this.name = name;
            this.email = email;
            this.countryCode = countryCode;
            this.phoneNumber = phoneNumber;

            CustomDesign();
        }

        public void CustomDesign()
        {
            id_label.Text = this.id;

            Equipment equipment = new Equipment();
            icon.Image = equipment.ResizeImage(VOVO.Properties.Resources.Bus2, icon.Width, icon.Height);

            email_radio_button.Text = "Send an this.email to " + equipment.maskEmail(this.email);
            text_radio_button.Text = "Text a code to the phone number ending in " + equipment.phoneNumberLast(countryCode + this.phoneNumber);
        }


        private void border_panel_MouseDown(object sender, MouseEventArgs e)
        {
            FormControlsUtility.AttachDraggableTitleBar(top_border_panel);
        }


        private void nextButtonEvent(string way)
        {
            this.Hide();
            CustomerForgotPasswordVerifyCode customerForgotPasswordVerifyCode = new CustomerForgotPasswordVerifyCode(way, this.id, this.name, this.email, this.countryCode, this.phoneNumber);
            customerForgotPasswordVerifyCode.Show();
        }



        private void next_btn_Click(object sender, EventArgs e)
        {
            if (email_radio_button.Checked == true || text_radio_button.Checked == true)
            {
                if (text_radio_button.Checked == true)
                    nextButtonEvent("SMS");


                else if (email_radio_button.Checked == true)
                    nextButtonEvent("Email");

            }

            else if (email_radio_button.Checked == false && text_radio_button.Checked == false)
                MessageBox.Show("Selected a option");
        }

        private void back_button_Click(object sender, EventArgs e)
        {
            this.Hide();
            CustomerForgottenPaswordSearching customerForgottenPaswordSearching = new CustomerForgottenPaswordSearching();
            customerForgottenPaswordSearching.Show();
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

        private void minimize_btn_MouseEnter(object sender, EventArgs e)
        {
            FormControlsUtility.ConfigureMinimizeButton(minimize_btn);
        }



        private void minimize_btn_MouseLeave(object sender, EventArgs e)
        {
            FormControlsUtility.ConfigureMinimizeButton(minimize_btn);
        }

        int voiceButton = 0;
       
        private void CustomerForgotPasswordCodeSending_Resize(object sender, EventArgs e)
        {
            FormControlsUtility.ConfigureFormResize(this);
        }
    }
}
