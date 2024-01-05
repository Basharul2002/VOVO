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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Xml.Linq;

namespace VOVO
{
    public partial class CustomerProfile : UserControl
    {
        private string Way, thisID, thisName, thisEmail, thisPhoneNumber, thisGender, thisPassword;
        private string name, phoneNumber, email, search, searchOption, countryCode;

        private int totalMatch; 

        public CustomerProfile()
        {
            InitializeComponent();
            DataCollection();
            UpdateButtonState();
        }
        //
        // Search/Delete/Update
        public CustomerProfile(string name, string countryCode, string phoneNumber, string email, string search = "", int totalMatch = 0, string searchOption = "", string way = "") : this()
        {
            this.name = name;
            this.countryCode = countryCode;
            this.phoneNumber = phoneNumber;
            this.email = email;
            this.search = search;
            this.totalMatch = totalMatch;
            this.searchOption = searchOption;
            Way = way;
            CustomDesign();

        }

        private void CustomDesign()
        {
            if(Way == "Delete")
            {
                delete_update_button.Visible = true;
                delete_update_button.Text = Way;
            }

            else if (Way == "Update")
            {
                delete_update_button.Visible = true;
                delete_update_button.Text = Way;
                delete_update_button.Enabled = false;

                name_tb.Enabled = true;
                name_tb.ReadOnly = false;
                email_tb.Enabled = true;
                email_tb.ReadOnly = false;
                phone_number_tb.Enabled = true;
                phone_number_tb.ReadOnly = false;
                password_tb.Enabled = true;
                password_tb.ReadOnly = false;

                male_radio_button.Enabled = true;
                female_radio_button.Enabled= true;
                others_radio_button.Enabled = true;


            }

            else if(Way =="Search" || Way == "Data")
                delete_update_button.Visible = false;
        
        }

        private void DataCollection()
        {
            thisID = id_tb.Texts;
            thisName = name_tb.Texts;
            thisEmail = email_tb.Texts;
            thisPhoneNumber = phone_number_tb.Texts;
            thisPassword = password_tb.Texts;
        }

        private void GenderSelection(string gender)
        {
            if (gender == "Male")
                male_radio_button.Checked = true;

            else if (gender == "Female")
                female_radio_button.Checked = true;

            else if (gender == "Others")
                others_radio_button.Checked = true;

            else if(gender == "PreferNotToSay")
                prefernottosay_radio_button.Checked = true; 
        }

        private void showCustomerDetails()
        {
            try
            {
                DataBase dataBase = new DataBase();
                using (SqlConnection connection = new SqlConnection(dataBase.connectionString))
                {
                    connection.Open();

                    string query = @"SELECT 
                                        ID, Name, Email, [Country Code], [Phone Number], Gender, Password 
                                    FROM 
                                        [Customer Information] 
                                    WHERE 
                                        Name = @Name 
                                        AND 
                                        Email = @Email 
                                        AND 
                                        [Country Code] = @CountryCode
                                        AND
                                        [Phone Number] = @PhoneNumber";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Name", this.name);
                        command.Parameters.AddWithValue("@Email", this.email);
                        command.Parameters.AddWithValue("@CountryCode", this.countryCode);
                        command.Parameters.AddWithValue("@PhoneNumber", this.phoneNumber);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                id_tb.Texts = reader["ID"].ToString();
                                name_tb.Texts = reader["Name"].ToString();
                                email_tb.Texts = reader["Email"].ToString();
                                phone_number_tb.Texts = $"+{reader["Country Code"].ToString()} {reader["Phone Number"].ToString()}";
                                GenderSelection(((GenderEnum)Int32.Parse(reader["Gender"].ToString())).ToString());
                                password_tb.Texts = reader["Password"].ToString();

                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Class name is CustomerProfile function name is showCustomerDetails and exception: {ex.Message}");
            }
        }

        private void DataDelete()
        {
            DataCollection();
            DataBase dataBase = new DataBase();
            // string id, string name, string email, string phoneNumber, string type
            dataBase.DataDeleted(thisID, "Customer");
        }

        private void DataUpdate()
        {
            DataCollection();

            DataBase dataBase = new DataBase();
            // string id, string name, string email, string phoneNumber, string password, string type
            dataBase.updateData(thisID, thisName, thisEmail, thisPhoneNumber.Substring(0, 4), thisPhoneNumber.Substring(4, 10), SelectedGender(), thisPassword, "Customer");
        }

        private string SelectedGender()
        {
            if (male_radio_button.Checked)
                return "1";

            if(female_radio_button.Checked ) return "2";

            if(others_radio_button.Checked) return "3";

            if (prefernottosay_radio_button.Checked) return "0";

            return "1";
        }

        private void tb_TextChanged(object sender, EventArgs e)
        {
            UpdateButtonState();
        }

        private void UpdateButtonState()
        {
            if(name_tb.Texts != thisName || email_tb.Texts != thisEmail || phone_number_tb.Texts != thisPhoneNumber || password_tb.Texts != thisPassword)
            {
                // Enable the button if the textbox data has changed, otherwise disable it
                delete_update_button.Enabled = true;
            }
        }
        private void CustomerProfile_Load(object sender, EventArgs e)
        {
            showCustomerDetails();
        }

        private void BackButonEvent()
        {
            if (Way == "Search" || Way == "Delete" || Way == "Update")
            {
                if (!AdminForm.Instance.panelContainer.Controls.ContainsKey("SearchingResult"))
                {
                    AdminForm.Instance.panelContainer.Controls.Clear();
                    // search, int totalMatch, string searchOption, string searchingItem, string option
                    SearchingResult searchingResult = new SearchingResult(this.search, this.totalMatch, this.searchOption, "Customer", "Search");
                    searchingResult.Dock = DockStyle.Fill;
                    AdminForm.Instance.panelContainer.Controls.Add(searchingResult);
                    this.Hide();
                }
            }


            else if (Way == "Data")
            {
                if (!AdminForm.Instance.panelContainer.Controls.ContainsKey("CustomerInformation"))
                {
                    AdminForm.Instance.panelContainer.Controls.Clear();
                    CustomerInformation customerInformation = new CustomerInformation();
                    customerInformation.Dock = DockStyle.Fill;
                    AdminForm.Instance.panelContainer.Controls.Add(customerInformation);
                    this.Hide();
                }
            }
        }

        private void back_button_Click(object sender, EventArgs e)
        {
            BackButonEvent();
        }


        private void delete_update_button_Click(object sender, EventArgs e)
        {
            if(Way == "Delete")
                DataDelete();
            
            else if(Way == "Update")
                DataUpdate();
        }
    }
}
