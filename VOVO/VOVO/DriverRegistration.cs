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
        private string AdminID { set; get; }
        private string Type { set; get; }
        private Image UserPicture { set; get; }
        private string Id { set; get; }
        private string UserName { set; get; }
        private string UserEmail { set;  get; }
        private string UserPhoneNumber { set; get; }
        private string UserAddress { set; get; }
        private string Gender { set; get; }
        private string UserDob { set; get; }
        private string UserNationality { set; get; }
        private string UserNidNumber { set; get; }
        private string UserExperience { set; get; }
        private string Exam1Name { set; get; }
        private string Exam1Board { set; get; }
        private string Exam1RegistrationNumber { set; get; }
        private string Exam1RollNumber { set; get; }
        private string Exam1Result { set; get; }


        public DriverRegistration()
        {
            InitializeComponent();
        }


        public DriverRegistration(string adminID, string type, Image userPicture, string id, string userName, string userEmail, string userPhoneNumber, string userAddress, string gender, string userDob, string userNationality, string userNidNumber, string userExperience, string exam1Name, string exam1Board, string exam1RegistrationNumber, string exam1RollNumber, string exam1Result)
        {
            InitializeComponent();
            AdminID = adminID;
            Type = type;
            UserPicture = userPicture;
            Id = id;
            UserName = userName;
            UserEmail = userEmail;
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
            string licenceNumber = licence_number_tb.Texts;
            string licenceType = licence_type_tb.Texts;
            string lincenceExpDate = licence_expiration_date_tb.Texts;

            string vechicleType = driving_history_vehicle_type.Texts;
            string registrationNumber = driving_history_registration_number.Texts;
            string compilance_record = driving_history_compilance_record_tb.Texts;

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
                    RegistrationInformation registrationInformation = new RegistrationInformation(AdminID, Type, UserPicture, Id, UserName, UserEmail, UserPhoneNumber, UserAddress, Gender, UserDob, UserNationality, UserNidNumber, UserExperience, Exam1Name, Exam1Board, Exam1RegistrationNumber, Exam1RollNumber, Exam1Result, licenceNumber: licenceNumber, licenceType: licenceType, licenceExpDate: lincenceExpDate, vechileType: vechicleType, registrationNumber: registrationNumber, compilanceRecord: compilance_record);
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
