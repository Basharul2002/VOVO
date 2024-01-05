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

namespace VOVO
{
    public partial class DriverRegistration : UserControl
    {
        private string AdminID, Type, Id, UserName, UserEmail, UserPhoneNumber, UserAddress, Gender, UserDob, UserNationality, UserNidNumber, UserExperience, UserCountryCode;

        private string Exam1Name, Exam1Board, Exam1RegistrationNumber, Exam1RollNumber, Exam1Result;

        private Image UserPicture;


        public DriverRegistration()
        {
            InitializeComponent();
        }


        public DriverRegistration(string adminID, string type, Image userPicture, string id, string userName, string userEmail, string userCoutryCode, string userPhoneNumber, string userAddress, string gender, string userDob, string userNationality, string userNidNumber, string userExperience, string exam1Name, string exam1Board, string exam1RegistrationNumber, string exam1RollNumber, string exam1Result)
        {
            InitializeComponent();
            AdminID = adminID;
            Type = type;
            UserPicture = userPicture;
            Id = id;
            UserName = userName;
            UserEmail = userEmail;
            UserCountryCode = userCoutryCode;
            UserPhoneNumber = userPhoneNumber;
            UserAddress = userAddress;
            Gender = gender;
            UserDob = userDob;
            UserNationality = userNationality;
            UserNidNumber = userNidNumber;
            UserExperience = userExperience;
            
            // SSC
            Exam1Name = exam1Name;
            Exam1Board = exam1Board;
            Exam1RegistrationNumber = exam1RegistrationNumber;
            Exam1RollNumber = exam1RollNumber;
            Exam1Result = exam1Result;
        }


        private void nextButtonEvent()
        {
            string licenceNumber = licence_number_tb.Text;
            string licenceType = licence_type_tb.Text;
            string lincenceExpDate = licence_expiration_date_tb.Text;

            string vechicleType = driving_history_vehicle_type.Text;
            string registrationNumber = driving_history_registration_number.Text;
            string compilance_record = driving_history_compilance_record_tb.Text;

            if (string.IsNullOrEmpty(licenceNumber) || string.IsNullOrEmpty(licenceType) || string.IsNullOrEmpty(lincenceExpDate) || string.IsNullOrEmpty(vechicleType) || string.IsNullOrEmpty(registrationNumber) || string.IsNullOrEmpty(compilance_record))
            {
                MessageBox.Show("Fill up all fields");
            }

            else if (!string.IsNullOrEmpty(licenceNumber) && !string.IsNullOrEmpty(licenceType) && !string.IsNullOrEmpty(lincenceExpDate) && !string.IsNullOrEmpty(vechicleType) && !string.IsNullOrEmpty(registrationNumber) && !string.IsNullOrEmpty(compilance_record))
            {
                if (!AdminForm.Instance.panelContainer.Controls.ContainsKey("RegistrationInformation") && Type == "Driver")
                {
                    MessageBox.Show("Successful");
                    AdminForm.Instance.panelContainer.Controls.Clear();
                    RegistrationInformation registrationInformation = new RegistrationInformation(AdminID, Type, UserPicture, Id, UserName, UserEmail, UserCountryCode, UserPhoneNumber, UserAddress, Gender, UserDob, UserNationality, UserNidNumber, UserExperience, Exam1Name, Exam1Board, Exam1RegistrationNumber, Exam1RollNumber, Exam1Result, licenceNumber: licenceNumber, licenceType: licenceType, licenceExpDate: lincenceExpDate, vechileType: vechicleType, registrationNumber: registrationNumber, compilanceRecord: compilance_record);
                    registrationInformation.Dock = DockStyle.Fill;
                    AdminForm.Instance.panelContainer.Controls.Add(registrationInformation);
                }
            }
        }


        private void next_button_Click(object sender, EventArgs e)
        {
           nextButtonEvent();
        }
    }
}
