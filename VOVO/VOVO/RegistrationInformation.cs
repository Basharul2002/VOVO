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
        private string AdminID { set; get; }
        private string Type { set; get; }
        private Image Picture { set; get; }
        private string Id { set; get; }
        private string Name { set; get; }
        private string Email { set; get; }
        private string ContactNumber { set; get; }
        private string Address { set; get; }
        private string Gender { set; get; }
        private string Dob { set; get; }
        private string Nationality { set; get; }
        private string NidNumber { set; get; }
        private string Experience { set; get; }
        /// <summary>
        /// RegistrationEdcation Form
        /// </summary>
        private string Exam1Name { set; get; }
        private string Exam1BoardName { set; get; }
        private string Exam1Result { set; get; }
        private string Exam1RegistrationNumber { set; get; }
        private string Exam1RollNumber { set; get; }
        private string Exam2Name { set; get; }
        private string Exam2BoardName { set; get; }
        private string Exam2Result { set; get; }
        private string Exam2RegistrationNumber { set; get; }
        private string Exam2RollNumber { set; get; }
        private string Exam3InstitutionName { set; get; }
        private string Exam3RollNumber { set; get; }
        private string Exam3DegreeName { set; get; }
        private string Exam3SubjectName { set; get; }
        private string Exam3Result { set; get; }
        private string LicenceNumber { set; get; }
        private string LicenceType { set; get; }
        private string LicenceExpDate { set; get; }
        private string VechileType { set; get; }
        private string RegistrationNumber { set; get; }
        private string CompilanceRecord { set; get; }


        private string userName, userEmail, userCountryCode, userPhoneNumber, userConatctNumber, userAddress, userGender, userDob, userNationality, userNidNumber, userExperience;

        private Image userPicture;

        private string userExam1Name, userExam1Board, userExam1RegistrationNumber, userExam1RollNumber, userExam1Result;

        private string userExam2Name, userExam2Board, userExam2RegistrationNumber, userExam2RollNumber, userExam2Result;

        private string userExam3InstitutionName, userExam3DegreeName, userExam3RollNumber, userExam3SubjectName, userExam3Result;

        private string driverLicenceNumber, driverLicenceType, driverLicenceExpDate, driverVechicleType, driverRegistrationNumber, driverCompilanceRecord;
        private int genderInt;

        public RegistrationInformation()
        {
            InitializeComponent();
        }

        public RegistrationInformation(string adminID, string type, Image picture, string id, string name, string email,
            string contactNumber, string address, string gender, string dob, string nationality, string nidNumber,
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
            ContactNumber = contactNumber;
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
            name_tb.Texts = Name;
            email_tb.Texts = Email;
            phone_number_tb.Texts = ContactNumber;
            address_tb.Texts = Address;
            dob_tb.Texts = Dob;
            nationality_tb.Texts = Nationality;
            nid_number_tb.Texts = NidNumber;
            experience_tb.Texts = Experience;

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
                    licence_number_tb.Texts = LicenceNumber;
                    licence_type_tb.Texts = LicenceType;
                    licence_expire_date_tb.Texts = LicenceExpDate;
                    vechicle_type_tb.Texts = VechileType;
                    registration_number_tb.Texts = RegistrationNumber;
                    compilance_record_tb.Texts = CompilanceRecord;
                    break;

                default:
                    CustomMessageBox.Show(Type + " does not match. Class name is RegistrationInformation and function name is showInformation.");
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
            exam1_name_tb.Texts = Exam1Name;
            exam1_board_name_tb.Texts = Exam1BoardName;
            exam1_roll_number_tb.Texts = Exam1RollNumber;
            exam1_result_tb.Texts = Exam1Result;
            exam1_registration_number_tb.Texts = Exam1RegistrationNumber;

            if (Type == "Admin" || Type == "Employee" || Type == "Supervisor")
            {
                // HSC/Alim/Equivalent
                exam2_name_tb.Texts = Exam2Name;
                exam2_board_name_tb.Texts = Exam2BoardName;
                exam2_roll_number_tb.Texts = Exam2RollNumber;
                exam2_result_tb.Texts = Exam2Result;
                exam2_registration_number_tb.Texts = Exam2RegistrationNumber;
            }

            if (Type == "Admin" || Type == "Employee")
            {
                // Honors/Diploma/Equivalent
                exam3_institution_name_tb.Texts = Exam3InstitutionName;
                exam3_roll_number_tb.Texts = Exam3RollNumber;
                exam3_degree_name_tb.Texts = Exam3DegreeName;
                exam3_result_tb.Texts = Exam3Result;
            }
        }

        private void CustomizeDesign()
        {
            if(Type == "Admin" || Type == "Employee")
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
                CustomMessageBox.Show(Type+ " doesn't match,  Class name is Registration Information funtion name is CustomizeDesign");
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
            }

            return gender;
        }

        private string ValidateUserData(ValidityCheck validityCheck)
        {
            userName = name_tb.Texts;
            userEmail = email_tb.Texts;
            userCountryCode = country_code_combo_box.Text.Substring(0, 4);
            userPhoneNumber = phone_number_tb.Texts;
            userAddress = address_tb.Texts;
            userGender = GenderSelection();
            userDob = dob_tb.Texts;
            userNationality = nationality_tb.Texts;
            userNidNumber = nid_number_tb.Texts;
            userExperience = experience_tb.Texts;
            userPicture = picture_box.Image;

            string errorMessage = string.Empty;

            if (string.IsNullOrWhiteSpace(userName) || string.IsNullOrWhiteSpace(userEmail) || string.IsNullOrWhiteSpace(userCountryCode) || string.IsNullOrWhiteSpace(userPhoneNumber) || string.IsNullOrWhiteSpace(userAddress) || string.IsNullOrWhiteSpace(userGender) || string.IsNullOrWhiteSpace(userDob) || string.IsNullOrWhiteSpace(userNationality) || string.IsNullOrWhiteSpace(userNidNumber) || string.IsNullOrWhiteSpace(userExperience))
            {
                errorMessage = "Please fill in all the personal information fields";

                if (Type == "Admin" || Type == "Employee")
                {
                    if (Exam3DegreeName == "Diploma" && (!string.IsNullOrEmpty(Exam1EmptyOrNull()) || !string.IsNullOrEmpty(Exam3EmptyOrNull())))
                    {
                        return errorMessage;
                    }
                    else if (!string.IsNullOrEmpty(Exam1EmptyOrNull()) || !string.IsNullOrEmpty(Exam2EmptyOrNull()) || !string.IsNullOrEmpty(Exam3EmptyOrNull()))
                    {
                        return errorMessage;
                    }
                }
                else if (Type == "Supervisor" && (!string.IsNullOrEmpty(Exam1EmptyOrNull()) || !string.IsNullOrEmpty(Exam2EmptyOrNull())))
                {
                    return errorMessage;
                }
                else if (Type == "Driver" && (!string.IsNullOrEmpty(Exam1EmptyOrNull()) || !string.IsNullOrEmpty(DrivingInfoEmptyOrNull())))
                {
                    return errorMessage;
                }

                if (userPicture == null)
                {
                    return "Please choose a picture";
                }
            }
            else
            {
                if (!validityCheck.IsPhoneNumberValid(userPhoneNumber))
                {
                    return "Phone Number is invalid";
                }

                if (!validityCheck.IsEmailValid(userEmail))
                {
                    return "Email is invalid";
                }
                else if (!validityCheck.IsDOBValid(userDob))
                {
                    return "Date of birth is invalid";
                }
            }

            return errorMessage;
        }

        private string Exam1EmptyOrNull()
        {
            userExam1Name = exam1_name_tb.Texts;
            userExam1Board = exam1_board_name_tb.Texts;
            userExam1Result = exam1_result_tb.Texts;
            userExam1RegistrationNumber = exam1_registration_number_tb.Texts;
            userExam1RollNumber = exam1_roll_number_tb.Texts;

            if (string.IsNullOrEmpty(userExam1Name) || string.IsNullOrEmpty(userExam1Board) || string.IsNullOrEmpty(userExam1Result) || string.IsNullOrEmpty(userExam1RegistrationNumber) || string.IsNullOrEmpty(userExam1RollNumber))
            {
                return "Please fill in all the fields";
            }

            return string.Empty;
        }

        private string Exam2EmptyOrNull()
        {
            userExam2Name = exam2_name_tb.Texts;
            userExam2Board = exam2_board_name_tb.Texts;
            userExam2RegistrationNumber = exam2_registration_number_tb.Texts;
            userExam2RollNumber = exam2_roll_number_tb.Texts;
            userExam2Result = exam2_result_tb.Texts;

            if (string.IsNullOrEmpty(userExam2Name) || string.IsNullOrEmpty(userExam2Board) || string.IsNullOrEmpty(userExam2Result) || string.IsNullOrEmpty(userExam2RegistrationNumber) || string.IsNullOrEmpty(userExam2RollNumber))
            {
                return "Please fill in all the fields";
            }

            return string.Empty;
        }

        private string Exam3EmptyOrNull()
        {
            userExam3InstitutionName = exam3_institution_name_tb.Texts;
            userExam3RollNumber = exam3_roll_number_tb.Texts;
            userExam3DegreeName = exam3_degree_name_tb.Texts;
            userExam3SubjectName = exam3_subject_tb.Texts;
            userExam3Result = exam3_result_tb.Texts;

            if (string.IsNullOrEmpty(userExam3InstitutionName) || string.IsNullOrEmpty(userExam3RollNumber) || string.IsNullOrEmpty(userExam3DegreeName) || string.IsNullOrEmpty(userExam3SubjectName) || string.IsNullOrEmpty(userExam3Result))
            {
                return "Please fill in all the fields";
            }

            return string.Empty;
        }

        private string DrivingInfoEmptyOrNull()
        {
            driverLicenceNumber = licence_number_tb.Texts;
            driverLicenceType = licence_type_tb.Texts;
            driverLicenceExpDate = licence_expire_date_tb.Texts;
            driverVechicleType = vechicle_type_tb.Texts;
            driverRegistrationNumber = registration_number_tb.Texts;
            driverCompilanceRecord = compilance_record_tb.Texts;

            if (string.IsNullOrEmpty(driverLicenceNumber) || string.IsNullOrEmpty(driverLicenceType) || string.IsNullOrEmpty(driverLicenceExpDate) 
                || string.IsNullOrEmpty(driverVechicleType) || string.IsNullOrEmpty(driverRegistrationNumber) || string.IsNullOrEmpty(driverCompilanceRecord))
            {
                return "Please fill in all the fields";
            }

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
                    CustomMessageBox.Show(errorMessage);
                    return;
                }

                if (Type == "Admin" || Type == "Employee")
                {
                    // CustomMessageBox.Show(userExam1Name + " " + userExam1Board + " " + userExam1RegistrationNumber + " " + userExam1RollNumber + " " + userExam1Result);
                    if (!AdminForm.Instance.panelContainer.Controls.ContainsKey("ChooseCompany"))
                    {
                        CustomMessageBox.Show("Successful");
                        AdminForm.Instance.panelContainer.Controls.Clear();

                        if (userExam3DegreeName == "Diploma")
                        {
                            // To store data I will check its not empty
                            Exam1EmptyOrNull();
                            Exam3EmptyOrNull();

                            ChooseCompany chooseCompany = new ChooseCompany(AdminID, Type, userPicture, Id, userName, userEmail, userCountryCode, userPhoneNumber, 
                                userAddress, userGender, userDob, userNationality, userNidNumber, userExperience, userExam1Name, userExam1Board, 
                                userExam1RegistrationNumber, userExam1RollNumber, userExam1Result, exam3InstitutionName:  userExam3InstitutionName,
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
                        CustomMessageBox.Show("Successful");
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

                else if(Type == "Driver")
                {
                    Exam1EmptyOrNull();
                    DrivingInfoEmptyOrNull();

                    CustomMessageBox.Show("Successful");
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

                else if(Type == "Conductor")
                {
                    CustomMessageBox.Show("Successful");
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
                CustomMessageBox.Show("An error occurred: " + ex.Message);
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
                CustomMessageBox.Show(ex.Message, "Picture Error");
            }
        }

        private void register_button_Click(object sender, EventArgs e)
        {
            register_button_event();
        }
    }

}
