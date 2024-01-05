using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using Twilio.Types;

namespace VOVO
{
    public partial class CompanyRegistration : UserControl
    {
        private string AdminID { set; get; }
        private byte[] pdf;
        private string Id;
        public CompanyRegistration()
        {
            InitializeComponent();
            ID();
        }

        public CompanyRegistration(string adminID)
        {
            InitializeComponent();
            AdminID = adminID;

            ID();
        }

        private void ID()
        {
            Equipment equipment = new Equipment();
            Id = equipment.idGenarator("Company");
            id_tb.Text = Id;
        }


        private void submit_button_Click(object sender, EventArgs e)
        {
            try
            {
                string companyName = owner_ship_tb.Text;
                string legalStructure = browse_button.Text;
                string businessStructure = business_structure_combo_box.Text;
                string address = owner_ship_tb.Text;
                string countryCode = country_code_combo_box.Text.Substring(0, 4);
                string phoneNumber = phone_number_tb.Text;
                string email = email_tb.Text;
                string ownerShip = owner_ship_tb.Text;
                string licensesNumber = licences_number_tb.Text;
                string permitNumber = permit_number_tb.Text;

                if (AnyRequiredFieldEmpty(companyName, businessStructure, address, phoneNumber, email, ownerShip, licensesNumber, permitNumber))
                {
                    MessageBox.Show("Please fill in all required fields");
                    return;
                }

                if(legalStructure == "Browse")
                {
                    MessageBox.Show("Please select legal structure");
                }

                ValidityCheck validityCheck = new ValidityCheck();
                if (!validityCheck.IsPhoneNumberValid(phoneNumber))
                {
                    MessageBox.Show("Invalid Phone Number");
                    return;
                }


                if (!validityCheck.IsEmailValid(email))
                {
                    MessageBox.Show("Invalid Email Address");
                    return;
                }

                if (CheckIfValueExists("Name", companyName) || CheckIfValueExists("Email", email) || CheckIfValueExists("Phone Number", countryCode, phoneNumber))
                {
                    return;
                }

                bool flag = InsertCompanyIntoDatabase(Id, companyName, pdf, businessStructure, address, countryCode, phoneNumber, email, ownerShip, licensesNumber, permitNumber, AdminID);

                if(flag)
                {
                    MessageBox.Show("Company Added Successfully", "Successful");

                    if (!AdminForm.Instance.panelContainer.Controls.ContainsKey("AdminDashBoard"))
                    {
                        AdminForm.Instance.panelContainer.Controls.Clear();
                        AdminDashBoard adminDashBoard = new AdminDashBoard(AdminID);
                        adminDashBoard.Dock = DockStyle.Fill;
                        AdminForm.Instance.panelContainer.Controls.Add(adminDashBoard);
                        this.Hide();
                    }
                }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show("Class is Company registration function is submit_button_Click and exception is " + ex.Message + "'", "Exception Database");
            }
        }

        private bool AnyRequiredFieldEmpty(params string[] fields)
        {
            return fields.Any(string.IsNullOrEmpty);

            
        }

        private bool CheckIfValueExists(string columnName, string value, string value2 = null)
        {
            string query = "SELECT * FROM [Company Information] WHERE ";
            bool exists = false;
            SqlParameter[] parameters = null;


            if(value2 != null)
            {
                query = query + " [Country Code] = @CountryCode AND [" + columnName + "] = @PhoneNumber";
                parameters = new SqlParameter[]
                {
                    new SqlParameter("@CountryCode", value2),
                    new SqlParameter("@PhoneNumber", value)

                };
            }

            else
            {
                query = query + "[" + columnName + "] = @Value";
                parameters = new SqlParameter[]
                {
                    new SqlParameter("@Value", value)
                };
            }



            try
            {
                DataBase dataBase = new DataBase();
                using (SqlConnection connection = new SqlConnection(dataBase.connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        foreach (var parameter in parameters)
                        {
                            command.Parameters.Add(parameter);
                        }

                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.HasRows)
                        {
                            exists = true;
                            MessageBox.Show("This " + columnName.ToLower() + " already registered", "Error");
                        }

                        reader.Close();
                    }
                }


                return exists;
            }

            catch (Exception ex) 
            {
                MessageBox.Show("Class is Company registration function is CheckIfValueExists and exception is " + ex.Message + "'", "Exception Database");
                return false;
            }

        }

        private bool InsertCompanyIntoDatabase(string id, string companyName, byte[] legalStructure, string businessStructure, string address, string countryCode, string phoneNumber, string email, string ownerShip, string licensesNumber, string permitNumber, string addedBy)
        {
            try
            {
                
                Equipment equipment = new Equipment();
                DataBase dataBase = new DataBase();
                using (SqlConnection connection = new SqlConnection(dataBase.connectionString))
                {
                    connection.Open();

                    string query = "INSERT INTO [Company Information] (ID, Name, [Legal Structure], [Business Structure], Address, [Country Code], [Phone Number], Email, OwnerShip, [Licenses Number], [Permit Number], Date, Time, [Added By(Admin)])" +
                                    "VALUES(@ID, @Name, @LegalStructure, @BusinessStructure, @Address, @CountryCode, @PhoneNumber, @Email, @OwnerShip, @LicensesNumber, @PermitNumber, @Date, @Time, @AddedBy)";

                    // MessageBox.Show("@ID " +  id + "\n@LegalStructure: " + legalStructure + "\nDate: " + equipment.DataBaseFormatDate(equipment.TodayDate()) + "\nTime: " + equipment.Time());
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ID", id);
                        command.Parameters.AddWithValue("@Name", companyName);
                        command.Parameters.AddWithValue("@LegalStructure", legalStructure);
                        command.Parameters.AddWithValue("@BusinessStructure", businessStructure);
                        command.Parameters.AddWithValue("@Address", address);
                        command.Parameters.AddWithValue("@CountryCode", countryCode);
                        command.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                        command.Parameters.AddWithValue("@Email", email);
                        command.Parameters.AddWithValue("@OwnerShip", ownerShip);
                        command.Parameters.AddWithValue("@LicensesNumber", licensesNumber);
                        command.Parameters.AddWithValue("@PermitNumber", permitNumber);
                        command.Parameters.AddWithValue("@Date", equipment.DataBaseFormatDate(equipment.TodayDate()));
                        command.Parameters.AddWithValue("@Time", equipment.Time());
                        command.Parameters.AddWithValue("@AddedBy", addedBy);

                        command.ExecuteNonQuery();


                    }

                }
            }

            catch(Exception ex)
            {
                MessageBox.Show("Class name is CompanyRegistration, function name is InsertCompanyIntoDatabase and excption is " + ex.Message);

                return false;
            }
            
            return true;
            
        }

        private void browse_button_Click(object sender, EventArgs e)
        {
            Equipment equipment = new Equipment();
            string newText = "Browse";  // Default text

            if (browse_button.Text == "Browse")
            {
                pdf = equipment.PdfUpload();
                if (pdf != null)
                {
                    newText = "Uploaded";
                }
            }

            else if (browse_button.Text == "Uploaded")
            {
                DialogResult dialogResult = MessageBox.Show("Do you want to change?", "VOVO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    pdf = equipment.PdfUpload();
                    if (pdf != null)
                    {
                        newText = "Uploaded";
                    }
                }
            }

            browse_button.Text = newText;
        }

        private void CompanyRegistration_Load(object sender, EventArgs e)
        {

        }
    }
}
