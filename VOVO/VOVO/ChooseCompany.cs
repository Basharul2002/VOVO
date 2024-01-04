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
using ZXing;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;


namespace VOVO
{
    public partial class ChooseCompany : UserControl
    {
        private string companyID, password, branchID;

        //
        /// RegistrationPersonalInfo Form
        //
        private string type, id, name;

        private Image picture;
        private string Name, email, contactNumber, address, gender, dob, nationality, nidNumber, experience, adminID;  
        //
        // RegistrationEdcation Form
        // For Employee and admin
        // SSC
        //
        private string exam1Name, exam1BoardName, exam1Result, exam1RegistrationNumber, exam1RollNumber;
        //
        // HSC
        //
        private string exam2Name,exam2BoardName, exam2Result,exam2RegistrationNumber, exam2RollNumber;
        //
        // Diploma / Honers
        //
        private string exam3InstitutionName, exam3RollNumber, exam3DegreeName, exam3SubjectName, exam3Result, licenceNumber, 
            licenceType, licenceExpDate, vechileType, registrationNumber, compilanceRecord, countryCode;

        private string Exam = string.Empty; 

        public ChooseCompany()
        {
            InitializeComponent();
            PopulateCompanyComboBox();

        }
        //
        // For Admin/Employee Registration --> 28 parrametters
        //
        public ChooseCompany(string adminID, string type, Image picture, string id, string name, string email, string countryCode,
         string contactNumber, string address, string gender, string dob, string nationality, string nidNumber,
         string experience, string exam1Name = "", string exam1Board = "", string exam1RegistrationNumber = "", 
         string exam1RollNumber = "",string exam1Result = "", string exam2Name = "", string exam2Board = "", 
         string exam2RegistrationNumber = "", string exam2RollNumber = "", string exam2Result = "", 
         string exam3InstitutionName = "", string exam3RollNumber = "", string exam3DegreeName = "",
         string exam3SubjectName = "", string exam3Result = "", string licenceNumber = "", string licenceType = "",
         string licenceExpDate = "", string vechicleType = "", string registrationNumber = "", string compilanceRecord = "")
         : this()
        {
            this.adminID = adminID;
            this.type = type;
            this.picture = picture;
            this.id = id;
            this.name = name;
            this.email = email;
            this.countryCode = countryCode;
            this.contactNumber = contactNumber;
            this.address = address;
            this.gender = gender;
            this.dob = dob;
            this.nationality = nationality;
            this.nidNumber = nidNumber;
            this.experience = experience;

            // Assign SSC/Dakhil Exam details if provided
            this.exam1Name = exam1Name;
            this.exam1BoardName = exam1Board;
            this.exam1RegistrationNumber = exam1RegistrationNumber;
            this.exam1RollNumber = exam1RollNumber;
            this.exam1Result = exam1Result;

            // Assign HSC/Alim Exam details if provided
            this.exam2Name = exam2Name;
            this.exam2BoardName = exam2Board;
            this.exam2RegistrationNumber = exam2RegistrationNumber;
            this.exam2RollNumber = exam2RollNumber;
            this.exam2Result = exam2Result;

            // Assign Diploma Exam details if provided
            Exam = string.IsNullOrEmpty(this.exam3DegreeName) ? "Diploma" : "";

            this.exam3InstitutionName = exam3InstitutionName;
            this.exam3RollNumber = exam3RollNumber;
            this.exam3DegreeName = exam3DegreeName;
            this.exam3SubjectName = exam3SubjectName;
            this.exam3Result = exam3Result;

            // Assign Driver-related details if provided
            this.licenceNumber = licenceNumber;
            this.licenceType = licenceType;
            this.licenceExpDate = licenceExpDate;
            this.vechileType = vechicleType;
            this.registrationNumber = registrationNumber;
            this.compilanceRecord = compilanceRecord;

            Design();
        }

        private void Design()
        {
            if(this.type == "Employee")
            {
                branch_panel.Visible = true;
                PopulateBranchNameComboBox();
            }
        }

        private void PopulateBranchNameComboBox()
        {
            DataBase dataBase = new DataBase();
            try
            {
                using (SqlConnection connection = new SqlConnection(dataBase.connectionString))
                {
                    string query = @"SELECT 
                                        [ID], [Brunch Name]
                                    FROM 
                                        [Office Information]";


                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string branchID = reader["ID"].ToString();
                                string branchName = reader["Brunch Name"].ToString();

                                Branch branch = new Branch { ID = branchID, Name = branchName };
                                branch_combo_box.Items.Add(branch);
                            }
                        }
                    }
                }

                // Set the DisplayMember and ValueMember outside the loop
                branch_combo_box.DisplayMember = "Name";
                branch_combo_box.ValueMember = "ID";
            }
            catch (Exception ex)
            {
                CustomMessageBox.Show("Class is ChooseCompany function name is PopulateBranchNameComboBox and exception is: " + ex.Message, "Error");
            }
        }

        private void branch_name_combo_box_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            if (comboBox.SelectedItem != null)
            {
                Branch selectedBranch = (Branch)comboBox.SelectedItem;
                branchID = selectedBranch.ID;
                // Use the selected company ID as needed
                //CustomMessageBox.Show("Selected Company ID: " + companyID);
            }
        }

        private void PopulateCompanyComboBox()
        {
            DataBase dataBase = new DataBase();
            try
            {
                using (SqlConnection connection = new SqlConnection(dataBase.connectionString))
                {
                    connection.Open();
                    string query = @"SELECT 
                                        ID, Name 
                                    FROM 
                                        [Company Information]";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string companyName = reader["Name"].ToString();
                                string companyId = reader["ID"].ToString();
                                // Create a new object to store company information
                                CompanyInfo company = new CompanyInfo { ID = companyId, Name = companyName };
                                // Add the company object to the ComboBox
                                company_name_combo_box.Items.Add(company);
                                // Set the DisplayMember and ValueMember properties of the ComboBox
                                company_name_combo_box.DisplayMember = "Name";
                                company_name_combo_box.ValueMember = "ID";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                CustomMessageBox.Show("Class is ChooseCompany function name is PopulateCompanyComboBox and exception is: " + ex.Message, "Error");
            }
        }

        private void Registration()
        {
            DataBase dataBase = new DataBase();
            using (SqlConnection connection = new SqlConnection(dataBase.connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;

                    PersonalInformationRegister(command);
                    EmployeeLoginInformation(command);
                    switch (this.type)
                    {
                        case "Admin":
                        case "Employee":
                            if (Exam != "Diploma")
                            {
                                Exam1InformationRegistration(command);
                                Exam2InformationRegistration(command);
                                DegreeInformationRegistration(command);
                            }
                            else if (Exam == "Diploma")
                            {
                                DiplomaInformationRegistration(command);
                            }
                            break;

                        case "Supervisor":
                            Exam1InformationRegistration(command);
                            Exam2InformationRegistration(command);
                            break;

                        case "Driver":
                            Exam1InformationRegistration(command);
                            DriverDrivingLicenseInformation(command);
                            DriverDrivingHistoryInformation(command);
                            break;

                        default:
                            break;
                    }

                    if (!AdminForm.Instance.panelContainer.Controls.ContainsKey("ConfirmRegistrationForm"))
                    {
                        Equipment equipment = new Equipment();
                        AdminForm.Instance.panelContainer.Controls.Clear();
                        ConfirmRegistrationForm confirmRegistrationForm = new ConfirmRegistrationForm(this.type, this.id, this.name, CompanyName, equipment.generateCustomPassword(10, true, true, true, true));
                        confirmRegistrationForm.Dock = DockStyle.Fill;
                        AdminForm.Instance.panelContainer.Controls.Add(confirmRegistrationForm);
                        CustomMessageBox.Show(this.name + " Registration Successful");
                    }
                }
            }
        }

        enum GenderEnum : int
        {
            PreferNotToSay,
            Male,
            Female,
            Others
        }

        private void PersonalInformationRegister(SqlCommand command)
        {
            GenderEnum gender;
            int intGender = -1;
            if (Enum.TryParse(this.gender, out gender))
                intGender = (int)gender;

            try
            {
                Equipment equipment = new Equipment();
                string query = $@"INSERT INTO 
                                    [{this.type} Information] 
                                    (
                                        ID, 
                                        Picture, 
                                        Name, 
                                        Email, 
                                        [Country Code], 
                                        [Phone Number], 
                                        [Address], 
                                        [Gender], 
                                        [Date Of Birth],
                                        [Nationality], 
                                        [NID Number], 
                                        [Experience], 
                                        [Date], 
                                        [Time], 
                                        [Added By]
                                    )
                                    VALUES
                                    (
                                        @ID, 
                                        @Picture, 
                                        @Name, 
                                        @Email, 
                                        @CountryCode, 
                                        @PhoneNumber, 
                                        @Address, 
                                        @Gender, 
                                        @Dob, 
                                        @Nationality, 
                                        @NidNumber, 
                                        @Experience, 
                                        @Date, 
                                        @Time,
                                        @AddedBy
                                    )";

                command.CommandText = query;
                command.Parameters.Clear();
                command.Parameters.AddWithValue("@ID", this.id);
                command.Parameters.AddWithValue("@Picture", equipment.ConvertImageToByteArray(this.picture));
                command.Parameters.AddWithValue("@Name", this.name);
                command.Parameters.AddWithValue("@Email", this.email);
                command.Parameters.AddWithValue("@CountryCode", this.countryCode);
                command.Parameters.AddWithValue("@PhoneNumber", this.contactNumber);
                command.Parameters.AddWithValue("@Address", this.address);
                command.Parameters.AddWithValue("@Gender", intGender);
                command.Parameters.AddWithValue("@Dob", this.dob);
                command.Parameters.AddWithValue("@Nationality", this.nationality);
                command.Parameters.AddWithValue("@NidNumber", this.nidNumber);
                command.Parameters.AddWithValue("@Experience", this.experience);
                command.Parameters.AddWithValue("@Date", equipment.DataBaseFormatDate(equipment.TodayDate()));
                command.Parameters.AddWithValue("@Time", equipment.Time());
                command.Parameters.AddWithValue("@AddedBy", this.adminID);

                // Execute the query to insert the data into the database
                command.ExecuteNonQuery();
            }

            catch(Exception ex)
            {
                CustomMessageBox.Show("Class name is ChooseCompany and function name is PersonalInformationRegister and  excprtion is: " + ex.Message);
            }

        }

        private void EmployeeLoginInformation(SqlCommand command)
        {
            try
            {
                string query = $@"INSERT INTO 
                                    [{this.type} Login Information] 
                                    (
                                        [{this.type} ID], 
                                        [Company ID], 
                                        [Password]";

                if (this.type == "Employee")
                    query += ", [Brunch ID]";
             

                query += ") VALUES (@ID, @CompanyID, @Password";

                if (this.type == "Employee")
                    query += ", @BranchID";

                query += ")";

                command.CommandText = query;
                command.Parameters.Clear();
                command.Parameters.AddWithValue("@ID", this.id);
                command.Parameters.AddWithValue("@CompanyID", companyID);
                command.Parameters.AddWithValue("@Password", password);

                if (this.type == "Employee")
                    command.Parameters.AddWithValue("@BranchID", branchID);


                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                CustomMessageBox.Show($"Class Name is ChooseName function name is EmployeeLoginInformation and exception is: {ex.Message}");
            }
        }

        private void Exam1InformationRegistration(SqlCommand command)
        {
          //  CustomMessageBox.Show("Exam: " + this.exam1Name);
            try
            {
                string queryExam1 = $@"INSERT INTO 
                                        [{this.type} Exam-1 Information] 
                                        (
                                            [{this.type} ID],
                                            [Exam Name], 
                                            [Board Name], 
                                            [Registration Number], 
                                            [Roll Number], 
                                            [Result]
                                        )
                                        VALUES
                                        (
                                            @ID, 
                                            @ExamName, 
                                            @Board, 
                                            @RegistrationNumber, 
                                            @RollNumber, 
                                            @Result
                                        )";

                command.CommandText = queryExam1;
                command.Parameters.Clear();
                command.Parameters.AddWithValue("@ID", this.id);
                command.Parameters.AddWithValue("@ExamName", this.exam1Name);
                command.Parameters.AddWithValue("@Board", this.exam1BoardName);
                command.Parameters.AddWithValue("@RegistrationNumber", this.exam1RegistrationNumber);
                command.Parameters.AddWithValue("@RollNumber", this.exam1RollNumber);
                command.Parameters.AddWithValue("@Result", this.exam1Result);

                // Execute the query to insert the data into the database
                command.ExecuteNonQuery();
            }

            catch (Exception ex)
            {
                CustomMessageBox.Show("Class name is ChooseCompany and function name is Exam1InformationRegistration and  excprtion is: " + ex.Message);
            }

        }

        private void Exam2InformationRegistration(SqlCommand command)
        {
            try
            {
                string queryExam2 = $@"INSERT INTO 
                                        [{this.type} Exam-2 Information]
                                        (
                                            [{this.type} ID], 
                                            [Exam Name], 
                                            [Board Name], 
                                            [Registration Number], 
                                            [Roll Number], 
                                            [Result]
                                        )
                                        VALUES
                                        (
                                            @ID, 
                                            @ExamName, 
                                            @Board, 
                                            @RegistrationNumber, 
                                            @RollNumber, 
                                            @Result
                                        )";

                command.CommandText = queryExam2;
                command.Parameters.Clear();
                command.Parameters.AddWithValue("@ID", this.id);
                command.Parameters.AddWithValue("@ExamName", this.exam2Name);
                command.Parameters.AddWithValue("@Board", this.exam2BoardName);
                command.Parameters.AddWithValue("@RegistrationNumber", this.exam2RegistrationNumber);
                command.Parameters.AddWithValue("@RollNumber", this.exam2RollNumber);
                command.Parameters.AddWithValue("@Result", this.exam2Result);

                // Execute the query to insert the data into the database
                command.ExecuteNonQuery();
            }


            catch (Exception ex)
            {
                CustomMessageBox.Show("Class name is ChooseCompany and function name is Exam2InformationRegistration and  excprtion is: " + ex.Message);
            }
        }

        private void DegreeInformationRegistration(SqlCommand command)
        {
            try
            {
                string queryDegree = $@"INSERT INTO 
                                            [{this.type} Degree Information] 
                                            (
                                                [{this.type} ID], 
                                                [Degree Name], 
                                                [Institution Name], 
                                                [Subject], 
                                                [Roll Number], 
                                                [Result]
                                            )
                                            VALUES
                                            (
                                                @ID, 
                                                @DegreeName,    
                                                @InstitutionName, 
                                                @Subject, 
                                                @RollNumber, 
                                                @Result
                                            )";

                command.CommandText = queryDegree;
                command.Parameters.Clear();
                command.Parameters.AddWithValue("@ID", this.id);
                command.Parameters.AddWithValue("@DegreeName", this.exam3DegreeName);
                command.Parameters.AddWithValue("@InstitutionName", this.exam3InstitutionName);
                command.Parameters.AddWithValue("@Subject", this.exam3SubjectName);
                command.Parameters.AddWithValue("@RollNumber", this.exam3RollNumber);
                command.Parameters.AddWithValue("@Result", this.exam3Result);

                // Execute the query to insert the data into the database
                command.ExecuteNonQuery();
            }
            

            catch (Exception ex)
            {
                CustomMessageBox.Show("Class name is ChooseCompany and function name is DegreeInformationRegistration and  excprtion is: " + ex.Message);
            }
        }

        private void DiplomaInformationRegistration(SqlCommand command)
        {
            try
            {
                string queryDiploma = $@"INSERT INTO 
                                            [{this.type} Diploma Information] 
                                            (
                                                [{this.type} ID], 
                                                [Degree Name], 
                                                [Institution Name], 
                                                [Subject], 
                                                [Roll Number], 
                                                [Result]
                                            )
                                            VALUES
                                            (
                                                @ID, 
                                                @DegreeName, 
                                                @InstitutionName, 
                                                @Subject, 
                                                @RollNumber, 
                                                @Result
                                            )";

                command.CommandText = queryDiploma;
                command.Parameters.Clear();
                command.Parameters.AddWithValue("@ID", this.id);
                command.Parameters.AddWithValue("@DegreeName", this.exam3DegreeName);
                command.Parameters.AddWithValue("@InstitutionName", this.exam3InstitutionName);
                command.Parameters.AddWithValue("@Subject", this.exam3SubjectName);
                command.Parameters.AddWithValue("@RollNumber", this.exam3RollNumber);
                command.Parameters.AddWithValue("@Result", this.exam3Result);

                // Execute the query to insert the data into the database
                command.ExecuteNonQuery();
            }
            

            catch (Exception ex)
            {
                CustomMessageBox.Show("Class name is ChooseCompany and function name is DiplomaInformationRegistration and  excprtion is: " + ex.Message);
            }
        }

        private void DriverDrivingLicenseInformation(SqlCommand command)
        {
            try
            {
                string query = $@"INSERT INTO 
                                    [Driver Driving License Information] 
                                    (
                                        [Driver ID], 
                                        [License Number], 
                                        [Licences Type], 
                                        [Exiration Date]
                                    )
                                    VALUES 
                                    (
                                        @DriverID, 
                                        @LicenseNumber, 
                                        @LicenseType, 
                                        @ExpirationDate
                                    )";

                command.CommandText = query;
                command.Parameters.Clear();
                command.Parameters.AddWithValue("@DriverID", this.id);
                command.Parameters.AddWithValue("@LicenseNumber", this.licenceNumber);
                command.Parameters.AddWithValue("@LicenseType", this.licenceType);
                command.Parameters.AddWithValue("@ExpirationDate", this.licenceExpDate);
            }

            catch (Exception ex)
            {
                CustomMessageBox.Show("Class name is ChooseCompany function name is DriverDrivingLicenseInformation and exception is " + ex.Message);
            }
        }

        private void DriverDrivingHistoryInformation(SqlCommand command)
        {
            try
            {
                string query = $@"INSERT INTO 
                                    [Driver Driving History Information] 
                                    (
                                        [Driver ID], 
                                        [Vehicle Type], 
                                        [Registration Number], 
                                        [Number Of Compliances]
                                    )
                                    VALUES 
                                    (
                                        @DriverID, 
                                        @VehicleType, 
                                        @RegistrationNumber, 
                                        @NumberOfCompliances
                                    )";

                command.CommandText = query;
                command.Parameters.Clear();
                command.Parameters.AddWithValue("@DriverID", this.id);
                command.Parameters.AddWithValue("@VehicleType", this.vechileType);
                command.Parameters.AddWithValue("@RegistrationNumber", this.registrationNumber);
                command.Parameters.AddWithValue("@NumberOfCompliances", this.compilanceRecord);
            }

            catch (Exception ex)
            {
                CustomMessageBox.Show("Class name is ChooseCompany function name is DriverDrivingHistoryInformation and exception is " + ex.Message);
            }
        }

        private void company_name_combo_box_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            if (comboBox.SelectedItem != null)
            {
                CompanyInfo selectedCompany = (CompanyInfo)comboBox.SelectedItem;
                companyID = selectedCompany.ID;
                // Use the selected company ID as needed
                //CustomMessageBox.Show("Selected Company ID: " + companyID);
            }
        }

        // Create a class to store company information
        
        private void next_button_Click(object sender, EventArgs e)
        {
            Equipment equipment = new Equipment();
            string companyName = company_name_combo_box.Text;
            password = equipment.generateCustomPassword(10, true, true, true, true);

            if (string.IsNullOrEmpty(companyName) )
            {
                CustomMessageBox.Show("Choose company name", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if(!string.IsNullOrEmpty(companyName))
            {
                Registration();
                if (!AdminForm.Instance.panelContainer.Controls.ContainsKey("ConfirmRegistrationForm"))
                {
                    AdminForm.Instance.panelContainer.Controls.Clear();
                    ConfirmRegistrationForm confirmRegistrationForm = new ConfirmRegistrationForm(this.type, this.id, this.name, companyName, password);
                    confirmRegistrationForm.Dock = DockStyle.Fill;
                    AdminForm.Instance.panelContainer.Controls.Add(confirmRegistrationForm);
                    CustomMessageBox.Show(this.name+" Registration Successful");
                }
            }
        }
    }
}
