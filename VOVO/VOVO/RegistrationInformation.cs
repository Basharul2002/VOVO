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
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace VOVO
{
    public partial class RegistrationInformation : UserControl
    {
        // RegistrationPersonalInfo Form
        private string AdminID, Type, Id, Name, Email, countryCode, phoneNumber, Address, Gender, Dob, Nationality, NidNumber, Experience;
        private Image Picture;
        //
        // Exam1
        //
        private string Exam1Name, Exam1BoardName, Exam1Result, Exam1RegistrationNumber, Exam1RollNumber;
        //
        // Exam2
        //
        private string Exam2Name, Exam2BoardName, Exam2Result, Exam2RegistrationNumber, Exam2RollNumber;
        //
        // Exam3
        //
        private string Exam3InstitutionName, Exam3RollNumber, Exam3DegreeName, Exam3SubjectName, Exam3Result;
        //
        // Driver
        //
        private string LicenceNumber, LicenceType, LicenceExpDate, VechileType, RegistrationNumber, CompilanceRecord;
        //
        // For new data
        //
        private string userName, userEmail, userCountryCode, userPhoneNumber, userConatctNumber, userAddress, userGender, userDob, userNationality, userNidNumber, userExperience;

        private Image userPicture;

        private string userExam1Name, userExam1Board, userExam1RegistrationNumber, userExam1RollNumber, userExam1Result;

        private string userExam2Name, userExam2Board, userExam2RegistrationNumber, userExam2RollNumber, userExam2Result;

        private string userExam3InstitutionName, userExam3DegreeName, userExam3RollNumber, userExam3SubjectName, userExam3Result;

        private string driverLicenceNumber, driverLicenceType, driverLicenceExpDate, driverVechicleType, driverRegistrationNumber, driverCompilanceRecord;



        private void country_code_combo_box_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void others_radio_button_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void female_radio_button_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void male_radio_button_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void subject_Click(object sender, EventArgs e)
        {

        }


        private void vechicle_type_tb_TextChanged(object sender, EventArgs e)
        {

        }


        private void name_tb_TextChanged(object sender, EventArgs e)
        {

        }

        private void nid_number_tb_TextChanged(object sender, EventArgs e)
        {

        }

        private void experience_tb_TextChanged(object sender, EventArgs e)
        {

        }

        private void email_tb_TextChanged(object sender, EventArgs e)
        {

        }

        private void phone_number_tb_Click(object sender, EventArgs e)
        {

        }

        private void dob_tb_TextChanged(object sender, EventArgs e)
        {

        }

        private void nationality_tb_TextChanged(object sender, EventArgs e)
        {

        }

        private void address_tb_TextChanged(object sender, EventArgs e)
        {

        }


     


        private int genderInt;

        public RegistrationInformation()
        {
            InitializeComponent();
        }

        public RegistrationInformation(string adminID, string type, Image picture, string id, string name, string email,
            string countryCode, string phoneNumber, string address, string gender, string dob, string nationality, string nidNumber,
            string experience, string exam1Name = "", string exam1Board = "", string exam1RegistrationNumber = "",
            string exam1RollNumber = "", string exam1Result = "", string exam2Name = "", string exam2Board = "",
            string exam2RegistrationNumber = "", string exam2RollNumber = "", string exam2Result = "",
            string exam3InstitutionName = "", string exam3RollNumber = "", string exam3DegreeName = "",
            string exam3SubjectName = "", string exam3Result = "", string licenceNumber = "", string licenceType = "",
            string licenceExpDate = "", string vechileType = "", string registrationNumber = "",
            string compilanceRecord = "") : this()
        {
            AdminID = adminID;
            Type = type;
            Picture = picture;
            Id = id;
            Name = name;
            Email = email;
            this.countryCode = countryCode;
            this.phoneNumber = phoneNumber;
            Address = address;
            Gender = gender;
            Dob = dob;
            Nationality = nationality;
            NidNumber = nidNumber;
            Experience = experience;

            // Assign the remaining parameters to their respective properties
            // SSC
            Exam1Name = exam1Name;
            Exam1BoardName = exam1Board;
            Exam1RegistrationNumber = exam1RegistrationNumber;
            Exam1RollNumber = exam1RollNumber;
            Exam1Result = exam1Result;

            // Hsc/ Alim
            Exam2Name = exam2Name;
            Exam2BoardName = exam2Board;
            Exam2RegistrationNumber = exam2RegistrationNumber;
            Exam2RollNumber = exam2RollNumber;
            Exam2Result = exam2Result;

            // Degree or Diploma
            Exam3InstitutionName = exam3InstitutionName;
            Exam3RollNumber = exam3RollNumber;
            Exam3DegreeName = exam3DegreeName;
            Exam3SubjectName = exam3SubjectName;
            Exam3Result = exam3Result;

            // Driving Information
            LicenceNumber = licenceNumber;
            LicenceType = licenceType;
            LicenceExpDate = licenceExpDate;
            VechileType = vechileType;
            RegistrationNumber = registrationNumber;
            CompilanceRecord = compilanceRecord;

            CustomizeDesign();
        }

        private void ShowInformation()
        {
            name_tb.Text = Name;
            email_tb.Text = Email;
            country_code_combo_box.Text = countryCode;
            phone_number_tb.Text = phoneNumber;
            address_tb.Text = Address;
            dob_tb.Text = Dob;
            nationality_tb.Text = Nationality;
            nid_number_tb.Text = NidNumber;
            experience_tb.Text = Experience;

            // Set gender radio button
            SetGenderRadioButton(Gender);

            picture_box.Image = Picture;

            switch (Type)
            {
                case "Admin":
                case "Employee":
                case "Supervisor":
                    ShowCommonQualificationInfo();
                    break;

                case "Driver":
                    ShowCommonQualificationInfo();
                    licence_number_tb.Text = LicenceNumber;
                    licence_type_tb.Text = LicenceType;
                    licence_expire_date_tb.Text = LicenceExpDate;
                    vechicle_type_tb.Text = VechileType;
                    registration_number_tb.Text = RegistrationNumber;
                    compilance_record_tb.Text = CompilanceRecord;
                    break;

                default:
                    MessageBox.Show(Type + " does not match. Class name is RegistrationInformation and function name is showInformation.");
                    break;
            }
        }

        private void SetGenderRadioButton(string gender)
        {
            male_radio_button.Checked = gender == "Male";
            female_radio_button.Checked = gender == "Female";
            others_radio_button.Checked = gender == "Others";
        }

        private void ShowCommonQualificationInfo()
        {
            // SSC/Dakhil/Equivalent
            exam1_name_tb.Text = Exam1Name;
            exam1_board_name_tb.Text = Exam1BoardName;
            exam1_roll_number_tb.Text = Exam1RollNumber;
            exam1_result_tb.Text = Exam1Result;
            exam1_registration_number_tb.Text = Exam1RegistrationNumber;

            if (Type == "Admin" || Type == "Employee" || Type == "Supervisor")
            {
                // HSC/Alim/Equivalent
                exam2_name_tb.Text = Exam2Name;
                exam2_board_name_tb.Text = Exam2BoardName;
                exam2_roll_number_tb.Text = Exam2RollNumber;
                exam2_result_tb.Text = Exam2Result;
                exam2_registration_number_tb.Text = Exam2RegistrationNumber;
            }

            if (Type == "Admin" || Type == "Employee")
            {
                // Honors/Diploma/Equivalent
                exam3_institution_name_tb.Text = Exam3InstitutionName;
                exam3_roll_number_tb.Text = Exam3RollNumber;
                exam3_degree_name_tb.Text = Exam3DegreeName;
                exam3_result_tb.Text = Exam3Result;
            }
        }

        private void CustomizeDesign()
        {
            if (Type == "Admin" || Type == "Employee")
            {
                personal_information_panel.Visible = false;
                educaional_information_panel.Visible = false;
                driving_informtion_button.Visible = false;
                driving_information_panel.Visible = false;
            }

            else if (Type == "Driver")
            {
                personal_information_panel.Visible = false;
                educaional_information_panel.Visible = false;
                exam2_panel.Visible = false;
                exam3_panel.Visible = false;
                driving_information_panel.Visible = false;
            }

            else if (Type == "Conductor")
            {
                personal_information_panel.Visible = false;
                educational_information_button.Visible = false;
                educaional_information_panel.Visible = false;
                driving_informtion_button.Visible = false;
                driving_information_panel.Visible = false;
            }

            else if (Type == "Supervisor")
            {
                personal_information_panel.Visible = false;
                educaional_information_panel.Visible = false;

                exam3_panel.Visible = false;
                driving_informtion_button.Visible = false;
                driving_information_panel.Visible = false;
            }
            else
            {
                MessageBox.Show(Type + " doesn't match,  Class name is Registration Information funtion name is CustomizeDesign");
            }

        }

        private void HidePanel()
        {
            if (personal_information_panel.Visible == true)
            {
                personal_information_panel.Visible = false;
            }

            else if (educaional_information_panel.Visible == true)
            {
                educaional_information_panel.Visible = false;
            }

            else if (driving_information_panel.Visible == true)
            {
                driving_information_panel.Visible = false;
            }
        }

        private void ShowSubManu(Panel subManu)
        {
            if (subManu.Visible == false)
            {
                HidePanel();
                subManu.Visible = true;
            }

            else
            {
                subManu.Visible = false;
            }
        }

        private string GenderSelection()
        {
            string gender = string.Empty;
            if (male_radio_button.Checked == true)
            {
                gender = "Male";
                genderInt = 1;
            }

            if (female_radio_button.Checked == true)
            {
                gender = "Female";
                genderInt = 2;

            }

            if (others_radio_button.Checked == true)
            {
                gender = "Others";
                genderInt = 3;

            }

            if (male_radio_button.Checked == false && female_radio_button.Checked == false && others_radio_button.Checked == false)
            {
                gender = null;
                genderInt = -1;
            }

            return gender;
        }

        private string ValidateUserData(ValidityCheck validityCheck)
        {
            userName = name_tb.Text;
            userEmail = email_tb.Text;
            userCountryCode = country_code_combo_box.Text.Substring(0, 4);
            userPhoneNumber = phone_number_tb.Text;
            userAddress = address_tb.Text;
            userGender = GenderSelection();
            userDob = dob_tb.Text;
            userNationality = nationality_tb.Text;
            userNidNumber = nid_number_tb.Text;
            userExperience = experience_tb.Text;
            userPicture = picture_box.Image;

            string errorMessage = string.Empty;

            if (string.IsNullOrWhiteSpace(userName) || string.IsNullOrWhiteSpace(userEmail) || string.IsNullOrWhiteSpace(userCountryCode) || string.IsNullOrWhiteSpace(userPhoneNumber) || string.IsNullOrWhiteSpace(userAddress) || string.IsNullOrWhiteSpace(userGender) || string.IsNullOrWhiteSpace(userDob) || string.IsNullOrWhiteSpace(userNationality) || string.IsNullOrWhiteSpace(userNidNumber) || string.IsNullOrWhiteSpace(userExperience))
            {
                errorMessage = "Please fill in all the personal information fields";

                if (Type == "Admin" || Type == "Employee")
                {
                    if (Exam3DegreeName == "Diploma" && (!string.IsNullOrEmpty(Exam1EmptyOrNull()) || !string.IsNullOrEmpty(Exam3EmptyOrNull())))
                        return errorMessage;


                    else if (!string.IsNullOrEmpty(Exam1EmptyOrNull()) || !string.IsNullOrEmpty(Exam2EmptyOrNull()) || !string.IsNullOrEmpty(Exam3EmptyOrNull()))
                        return errorMessage;

                }

                else if (Type == "Supervisor" && (!string.IsNullOrEmpty(Exam1EmptyOrNull()) || !string.IsNullOrEmpty(Exam2EmptyOrNull())))
                    return errorMessage;

                else if (Type == "Driver" && (!string.IsNullOrEmpty(Exam1EmptyOrNull()) || !string.IsNullOrEmpty(DrivingInfoEmptyOrNull())))
                    return errorMessage;


                if (userPicture == null)
                    return "Please choose a picture";

            }
            else
            {
                if (!validityCheck.IsPhoneNumberValid(userPhoneNumber))
                    return "Phone Number is invalid";


                if (!validityCheck.IsEmailValid(userEmail))
                    return "Email is invalid";


                else if (!validityCheck.IsDOBValid(userDob))
                    return "Date of birth is invalid";

            }

            return errorMessage;
        }

        private string Exam1EmptyOrNull()
        {
            userExam1Name = exam1_name_tb.Text;
            userExam1Board = exam1_board_name_tb.Text;
            userExam1Result = exam1_result_tb.Text;
            userExam1RegistrationNumber = exam1_registration_number_tb.Text;
            userExam1RollNumber = exam1_roll_number_tb.Text;

            if (string.IsNullOrEmpty(userExam1Name) || string.IsNullOrEmpty(userExam1Board) || string.IsNullOrEmpty(userExam1Result) || string.IsNullOrEmpty(userExam1RegistrationNumber) || string.IsNullOrEmpty(userExam1RollNumber))
                return "Please fill in all the fields";

            return string.Empty;
        }

        private string Exam2EmptyOrNull()
        {
            userExam2Name = exam2_name_tb.Text;
            userExam2Board = exam2_board_name_tb.Text;
            userExam2RegistrationNumber = exam2_registration_number_tb.Text;
            userExam2RollNumber = exam2_roll_number_tb.Text;
            userExam2Result = exam2_result_tb.Text;

            if (string.IsNullOrEmpty(userExam2Name) || string.IsNullOrEmpty(userExam2Board) || string.IsNullOrEmpty(userExam2Result) || string.IsNullOrEmpty(userExam2RegistrationNumber) || string.IsNullOrEmpty(userExam2RollNumber))
                return "Please fill in all the fields";


            return string.Empty;
        }

        private string Exam3EmptyOrNull()
        {
            userExam3InstitutionName = exam3_institution_name_tb.Text;
            userExam3RollNumber = exam3_roll_number_tb.Text;
            userExam3DegreeName = exam3_degree_name_tb.Text;
            userExam3SubjectName = exam3_subject_tb.Text;
            userExam3Result = exam3_result_tb.Text;

            if (string.IsNullOrEmpty(userExam3InstitutionName) || string.IsNullOrEmpty(userExam3RollNumber) || string.IsNullOrEmpty(userExam3DegreeName) || string.IsNullOrEmpty(userExam3SubjectName) || string.IsNullOrEmpty(userExam3Result))
                return "Please fill in all the fields";

            return string.Empty;
        }

        private string DrivingInfoEmptyOrNull()
        {
            driverLicenceNumber = licence_number_tb.Text;
            driverLicenceType = licence_type_tb.Text;
            driverLicenceExpDate = licence_expire_date_tb.Text;
            driverVechicleType = vechicle_type_tb.Text;
            driverRegistrationNumber = registration_number_tb.Text;
            driverCompilanceRecord = compilance_record_tb.Text;

            if (string.IsNullOrEmpty(driverLicenceNumber) || string.IsNullOrEmpty(driverLicenceType) || string.IsNullOrEmpty(driverLicenceExpDate)
                || string.IsNullOrEmpty(driverVechicleType) || string.IsNullOrEmpty(driverRegistrationNumber) || string.IsNullOrEmpty(driverCompilanceRecord))
                return "Please fill in all the fields";

            return string.Empty;
        }

        private void register_button_event()
        {
            try
            {

                ValidityCheck validityCheck = new ValidityCheck();
                string errorMessage = ValidateUserData(validityCheck);

                if (!string.IsNullOrEmpty(errorMessage))
                {
                    MessageBox.Show(errorMessage);
                    return;
                }

                if (Type == "Admin" || Type == "Employee")
                {
                    // MessageBox.Show(userExam1Name + " " + userExam1Board + " " + userExam1RegistrationNumber + " " + userExam1RollNumber + " " + userExam1Result);
                    if (!AdminForm.Instance.panelContainer.Controls.ContainsKey("ChooseCompany"))
                    {
                        // MessageBox.Show("Successful");
                        AdminForm.Instance.panelContainer.Controls.Clear();

                        if (userExam3DegreeName == "Diploma")
                        {
                            // To store data I will check its not empty
                            Exam1EmptyOrNull();
                            Exam3EmptyOrNull();

                            ChooseCompany chooseCompany = new ChooseCompany(AdminID, Type, userPicture, Id, userName, userEmail, userCountryCode, userPhoneNumber,
                                userAddress, userGender, userDob, userNationality, userNidNumber, userExperience, userExam1Name, userExam1Board,
                                userExam1RegistrationNumber, userExam1RollNumber, userExam1Result, exam3InstitutionName: userExam3InstitutionName,
                                exam3RollNumber: userExam3RollNumber, exam3DegreeName: userExam3DegreeName, exam3SubjectName: userExam3SubjectName,
                                exam3Result: userExam3Result);

                            chooseCompany.Dock = DockStyle.Fill;
                            AdminForm.Instance.panelContainer.Controls.Add(chooseCompany);
                        }

                        else
                        {
                            Exam1EmptyOrNull();
                            Exam2EmptyOrNull();
                            Exam3EmptyOrNull();

                            ChooseCompany chooseCompany = new ChooseCompany(AdminID, Type, userPicture, Id, userName, userEmail, userCountryCode, userPhoneNumber,
                                userAddress, userGender, userDob, userNationality, userNidNumber, userExperience, userExam1Name, userExam1Board,
                                userExam1RegistrationNumber, userExam1RollNumber, userExam1Result, userExam2Name, userExam2Board,
                                userExam2RegistrationNumber, userExam2RollNumber, userExam2Result, userExam3InstitutionName, userExam3RollNumber,
                                userExam3DegreeName, userExam3SubjectName, userExam3Result);
                            // 28
                            chooseCompany.Dock = DockStyle.Fill;
                            AdminForm.Instance.panelContainer.Controls.Add(chooseCompany);
                        }
                    }

                }
                else if (Type == "Supervisor")
                {
                    Exam1EmptyOrNull();
                    Exam2EmptyOrNull();

                    if (!AdminForm.Instance.panelContainer.Controls.ContainsKey("ChooseCompany"))
                    {
                      //  MessageBox.Show("Successful");
                        AdminForm.Instance.panelContainer.Controls.Clear();
                        ChooseCompany chooseCompany = new ChooseCompany(AdminID, Type, userPicture, Id, userName, userEmail, userCountryCode, userPhoneNumber,
                            userAddress, userGender, userDob, userNationality, userNidNumber, userExperience, userExam1Name, userExam1Board,
                            userExam1RegistrationNumber, userExam1RollNumber, userExam1Result, userExam2Name, userExam2Board,
                            userExam2RegistrationNumber, userExam2RollNumber, userExam2Result);
                        // 24 parameters
                        chooseCompany.Dock = DockStyle.Fill;
                        AdminForm.Instance.panelContainer.Controls.Add(chooseCompany);
                    }
                }

                else if (Type == "Driver")
                {
                    Exam1EmptyOrNull();
                    DrivingInfoEmptyOrNull();

                 //   MessageBox.Show("Successful");
                    AdminForm.Instance.panelContainer.Controls.Clear();
                    ChooseCompany chooseCompany = new ChooseCompany(AdminID, Type, userPicture, Id, userName, userEmail, userCountryCode, userPhoneNumber,
                        userAddress, userGender, userDob, userNationality, userNidNumber, userExperience, userExam1Name, userExam1Board,
                        userExam1RegistrationNumber, userExam1RollNumber, userExam1Result, licenceNumber: driverLicenceNumber,
                        licenceType: driverLicenceType, licenceExpDate: driverLicenceExpDate, vechicleType: driverVechicleType,
                        registrationNumber: driverRegistrationNumber, compilanceRecord: driverCompilanceRecord);
                    // 24 Parameters
                    chooseCompany.Dock = DockStyle.Fill;
                    AdminForm.Instance.panelContainer.Controls.Add(chooseCompany);
                }

                else if (Type == "Conductor")
                {
                   // MessageBox.Show("Successful");
                    AdminForm.Instance.panelContainer.Controls.Clear();
                    ChooseCompany chooseCompany = new ChooseCompany(AdminID, Type, userPicture, Id, userName, userEmail, userCountryCode, userPhoneNumber,
                        userAddress, userGender, userDob, userNationality, userNidNumber, userExperience);
                    //13 parameters
                    chooseCompany.Dock = DockStyle.Fill;
                    AdminForm.Instance.panelContainer.Controls.Add(chooseCompany);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void RegistrationInformation_Load(object sender, EventArgs e)
        {
            ShowInformation();
        }

        private void personal_info_button_Click(object sender, EventArgs e)
        {
            ShowSubManu(personal_information_panel);
        }

        private void educational_information_button_Click(object sender, EventArgs e)
        {
            ShowSubManu(educaional_information_panel);
        }

        private void driving_informtion_button_Click(object sender, EventArgs e)
        {
            ShowSubManu(driving_information_panel);
        }

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
                    picture_box.Image = Image.FromFile(selectedFile);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Picture Error");
            }
        }

        private void register_button_Click(object sender, EventArgs e)
        {
            register_button_event();
        }
    }

}
