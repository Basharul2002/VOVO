using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tensorflow;
using static iText.IO.Image.Jpeg2000ImageData;

namespace VOVO
{
    public partial class Quiz : MetroFramework.Forms.MetroForm
    {
        private string id, operation, companyID, name, email, countryCode, phoneNumber, address, dob, gender, natonality, nid, experiences;
        private bool insert = false, nameChange, emailChange, countryCodeChange, phoneNumberChange, addressChange, dobChange, genderChange, natonalityChange, nidChange, experiencesChange;

        public Quiz()
        {
            InitializeComponent();
            DataLoad();
            SingleDataShow(data_grid_view.Rows[0].Cells[0].Value.ToString());
        }

        private void back_button_Click(object sender, EventArgs e)
        {
            this.Close();
            EmployeeLogin employeeLogin = new EmployeeLogin();
            employeeLogin.Show();
        }

        private void delete_button_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure?", "VOVO", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                DataBase dataBase = new DataBase();
                string query = $"DELETE FROM [User Login Information] WHERE [User ID] = '{id_label.Text}'";
                DataOperation(query, dataBase.connectionString);

                query = string.Empty;
                query = $"DELETE FROM [User Information] WHERE [ID] = '{id_label.Text}'";
                DataOperation(query, dataBase.connectionString);

                
            }

            DataLoad();
            SingleDataShow(data_grid_view.Rows[0].Cells[0].Value.ToString());
        }


        private void data_grid_view_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex>=0)
            {
                SingleDataShow(data_grid_view.Rows[e.RowIndex].Cells[0].Value.ToString());
            }
        }

        private void refresh_button_Click(object sender, EventArgs e)
        {
            DataLoad();
            SingleDataShow(data_grid_view.Rows[0].Cells[0].Value.ToString());
        }

        // Data Show in Data grind view
        private void DataLoad()
        {
            try
            {
                DataTable dataTable;
                DataBase dataBase = new DataBase();

                using (SqlConnection connection = new SqlConnection(dataBase.connectionString))
                {
                    string query = @"SELECT 
                                       ID,
                                       Name, 
                                       [Date Of Birth]
                                       [Country Code], 
                                       [Phone Number], 
                                       [Email], 
                                       [Address], 
                                       [Nationality],
                                       [NID Number], 
                                       [Experience]
                                FROM 
                                    [User Information] 
                                WHERE 
                                    [User Type] = 'Admin'
                                ORDER BY
                                      Date DESC, Time DESC";

                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                        DataSet dataSet = new DataSet();
                        dataAdapter.Fill(dataSet);

                        // You don't need to create a new DataTable instance here
                        dataTable = dataSet.Tables[0];
                    }

                    connection.Close();
                }

                data_grid_view.AutoGenerateColumns = false;
                data_grid_view.DataSource = dataTable;

                // Refresh the DataGridView to display the data
                data_grid_view.Refresh();

                // Clear any selection in the DataGridView
                data_grid_view.ClearSelection();
            }
           

            catch(Exception ex)
            {
                MessageBox.Show("Class name is Quiz function name is LoadData and exception: " + ex.Message);
            }
        }

        private void operation_button_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(name_tb.Text) || string.IsNullOrWhiteSpace(email_tb.Text) || string.IsNullOrWhiteSpace(country_code_combo_box.Text)
                || string.IsNullOrWhiteSpace(phone_number_tb.Text) || string.IsNullOrWhiteSpace(address_tb.Text) || string.IsNullOrWhiteSpace(nationality_combo_box.Text)
                || string.IsNullOrWhiteSpace(experience_tb.Text) || company_name_combo_box.SelectedValue == null)
            {
                MessageBox.Show("Please full fill all info", "VOVO");
                return;
            }

            DataBase dataBase = new DataBase();
           

            if(SelectedGenderID() == 0)
            {
                MessageBox.Show("Please selecet Gender", "VOVO");
                return;
            }

            Equipment equipment = new Equipment();
            string query;
            if (insert)
            {
                if (dataBase.IsNidNumberExists(nid_number_tb.Text))
                {
                    MessageBox.Show("Wrong NID");
                    return;
                }

                query = $@"INSERT INTO [User Information] 
                    (
                        ID, Name, Email, [Country Code], [Phone Number], 
                        Address, Gender, [Date Of Birth], Nationality, [NID Number],
                        Experience, Date, Time, [User Type]
                    )
                    VALUES
                    (
                        '{(id_label.Text)}', '{name_tb.Text}', '{email_tb.Text}', '{country_code_combo_box.Text.Substring(0, 4)}', 
                        '{phone_number_tb.Text}', '{address_tb.Text}', '{SelectedGenderID()}', '{dob_tb.Text}', 
                        '{nationality_combo_box.Text}', '{nid_number_tb.Text}', '{experience_tb.Text}',
                        '{equipment.DataBaseFormatedDate(equipment.TodayDate())}', '{equipment.Time()}', 'Admin'
                    )";

                DataOperation(query, dataBase.connectionString);
                
                query = string.Empty;
                query = $@"INSERT INTO 
                                [User Login Information]
                                      (
                                        [User ID], 
                                        [Company ID], 
                                        Password
                                      )
                                VALUES
                                      (
                                          '{id_label.Text}', 
                                          '{company_name_combo_box.SelectedValue}', 
                                          'Admin' 
                                      )";

                DataOperation(query, dataBase.connectionString);

                return;
            }



            query = "UPDATE [User Information] SET";
            List<SqlParameter> parameters = new List<SqlParameter>();


            if (nameChange)
            {
                query = $"{query} Name = @Name, ";
                parameters.Add(new SqlParameter("@Name", name_tb.Text));
            }

            if(emailChange)
            {
                query = $"{query} Email = @Email, ";
                parameters.Add(new SqlParameter("@Email", email_tb.Text));
            }

            if (countryCodeChange)
            {
                query = $"{query} [Country Code] = @CountryCode, ";
                parameters.Add(new SqlParameter("@CountryCode", country_code_combo_box.Text.Substring(0, 4)));
            }

            if(phoneNumberChange)
            {
                query = $"{query} [Phone Number] = @PhoneNumber, ";
                parameters.Add(new SqlParameter("@PhoneNumber", phone_number_tb.Text));
            }

            if(addressChange)
            {
                query = $"{query} [Address] = @Address, ";
                parameters.Add(new SqlParameter("@Address", address_tb.Text));
            }


            if(genderChange)
            {
                query = $"{query} Gender = @Gender, ";
                parameters.Add(new SqlParameter("@Gender", SelectedGenderID()));
            }


            if(natonalityChange)
            {
                query = $"{query} Nationality = @Nationality, ";
                parameters.Add(new SqlParameter("@Nationality", nationality_combo_box.Text));
            }


            if(nidChange)
            {
                query = $"{query} [NID Number] = @NID, ";
                parameters.Add(new SqlParameter("@NID", nid_number_tb.Text));
            }

            if(experiencesChange)
            {
                query = $"{query} Experience = @Experience, ";
                parameters.Add(new SqlParameter("@Experience", experience_tb.Text));
            }


            query = query.TrimEnd(',', ' ');
            query = $"{query} WHERE ID = @id AND [User Type] = 'Admin'";
            parameters.Add(new SqlParameter("@id", id_label.Text));
        

            DataUpdate(query, parameters);
            
        }


        private void DataUpdate(string query, List<SqlParameter> parameters)
        {
            DataBase dataBase = new DataBase();
            try
            {
                using (SqlConnection connection = new SqlConnection(dataBase.connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        foreach (var parameter in parameters)
                        {
                            command.Parameters.Add(parameter);
                        }

                        command.ExecuteNonQuery();
                    }
                    MessageBox.Show("Data Updated");
                    operation_button.Enabled = false;
                    connection.Close();

                }
            }

            catch(Exception ex)
            {
                MessageBox.Show("Class name is Quiz and function name is DataUpdate and exception is: " + ex.Message);
            }
        }
        private void DataOperation(string query, string connectionString)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.ExecuteNonQuery();
                    }

                    MessageBox.Show($"{name_tb.Text} account successfully registered", "VOVO");
                    connection.Close();
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Class name is Quiz and function name is DataOperation and exception: " + ex.Message);
            }

        }


        private int SelectedGenderID()
        {
            if (male_radio_button.Checked)
                return 1;

            if(female_radio_button.Checked )
                return 2;

            if (others_radio_button.Checked)
                return 3;

            else
                return 0;
        }

        private void new_button_Click(object sender, EventArgs e)
        {
            insert = true;
            DataLoad();
            SingleDataShow(data_grid_view.Rows[0].Cells[0].Value.ToString());
            TextBoxClear();
            LoadCompanyData();
            Equipment equipment = new Equipment();

            id_label.Text = equipment.idGenarator("Admin");
        }

        private void TextBoxClear()
        {
            name_tb.Text = string.Empty;
            email_tb.Text = string.Empty;
            dob_tb.Text = string.Empty;
            phone_number_tb.Text = string.Empty;
            country_code_combo_box.Text = string.Empty;
            male_radio_button.Checked = false;
            female_radio_button.Checked = false;
            others_radio_button.Checked = false;
            address_tb.Text = string.Empty;
            nationality_combo_box.Text = string.Empty;
            nid_number_tb.Text = string.Empty;
            experience_tb.Text = string.Empty;
        }

        private void experience_tb_TextChanged(object sender, EventArgs e)
        {
            if(experiences == experience_tb.Text || string.IsNullOrWhiteSpace(experience_tb.Text))
            {
                experiencesChange = false;
                return;
            }

            experiencesChange = true;
            operation_button.Text = "Update";
            operation_button.Enabled = true;
        }

        private void nid_number_tb_TextChanged(object sender, EventArgs e)
        {
            if(nid_number_tb.Text == nid || string.IsNullOrWhiteSpace(nid_number_tb.Text))
            {
                nidChange = false;
                return;
            }

            nidChange = true;
            operation_button.Text = "Update";
            operation_button.Enabled = true;
        }

        private void nationality_cobo_box_TextChanged(object sender, EventArgs e)
        {
            if(nationality_combo_box.Text == natonality || string.IsNullOrWhiteSpace(nationality_combo_box.Text))
            {
                natonalityChange = false;
                return;
            }

            natonalityChange = true;
            operation_button.Text = "Update";
            operation_button.Enabled = true;
        }

        private void nationality_cobo_box_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void phone_number_tb_TextChanged(object sender, EventArgs e)
        {
            if(phoneNumber == phone_number_tb.Text || string.IsNullOrWhiteSpace(phone_number_tb.Text))
            {
                phoneNumberChange = false;
                return;
            }

            phoneNumberChange = true;
            operation_button.Text = "Update";
            operation_button.Enabled = true;
        }

        private void country_code_combo_box_TextChanged(object sender, EventArgs e)
        {
            if(countryCode == country_code_combo_box.Text || string.IsNullOrWhiteSpace(country_code_combo_box.Text))
            {
                countryCodeChange = false;
                return;
            }

            countryCodeChange = true;
            operation_button.Text = "Update";
            operation_button.Enabled = true;
        }

        private bool change;

        private void search_button_Click(object sender, EventArgs e)
        {
            operation = "Search";
            search_button.Enabled = false;

            AdminSearch adminSearch = new AdminSearch();
            adminSearch.ShowDialog();

            // Access the result after the form is closed
            SingleDataShow(adminSearch.SearchResult);
            search_button.Enabled = true;
        }

        private void SingleDataShow(string id)
        {
            DataBase dataBase = new DataBase();
            try
            {
                using (SqlConnection connection = new SqlConnection(dataBase.connectionString))
                {
                    string query = $@"SELECT 
                                    * 
                            FROM 
                                [User Information]
                            WHERE 
                                [User Type] = 'Admin' AND ID = '{id}'";

                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                reader.Read(); // Move to the first row

                                id_label.Text = reader["ID"].ToString();
                                name = reader["Name"].ToString();
                                email = reader["Email"].ToString();
                                countryCode = reader["Country Code"].ToString();
                                phoneNumber = reader["Phone Number"].ToString();
                                address = reader["Address"].ToString();
                                dob = reader["Date Of Birth"].ToString();
                                natonality = reader["Nationality"].ToString();
                                nid = reader["NID Number"].ToString();
                                experiences = reader["Experience"].ToString();
                                gender = reader["Gender"].ToString();

                                // Check if the "ImageData" column exists before accessing it
                                if (reader["Picture"] != DBNull.Value)
                                {
                                    byte[] imageData = (byte[])reader["Picture"];

                                    // Convert byte array to Image
                                    using (MemoryStream ms = new MemoryStream(imageData))
                                    {
                                        picture_box.Image = Image.FromStream(ms);
                                    }
                                }
                                DataShow();
                            }
                            else
                            {
                                MessageBox.Show("No data found for the specified ID.");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Class name is quiz and function is SingleDataShow and exception: " + ex.Message);
            }
        }

        public void CompanyName(string id)
        {
            DataBase dataBase = new DataBase();
            try
            {
                using (SqlConnection connection = new SqlConnection(dataBase.connectionString))
                {
                    connection.Open();
                    string query = $@"SELECT 
                                  CI.[Name] AS CompanyName
                             FROM 
                                  [User Login Information] ULI
                             INNER JOIN
                                  [Company Information] CI ON ULI.[Company ID] = CI.ID
                             WHERE 
                                  ULI.[User ID] = '{id}'";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                reader.Read();
                                company_name_combo_box.Text = reader["CompanyName"].ToString();
                            }
                        }
                    }
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions appropriately
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void LoadCompanyData()
        {
            // Clear data and tags in the ComboBox
           // company_name_combo_box.Items.Clear();
            // company_name_combo_box.DataSource = null;
            company_name_combo_box.Enabled = true;
            company_name_combo_box.Refresh();

            try
            {
                DataBase dataBase = new DataBase();
                using (SqlConnection connection = new SqlConnection(dataBase.connectionString))
                {
                    connection.Open();
                    string query = "SELECT ID, Name FROM [Company Information]";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            DataTable dataTable = new DataTable();
                            dataTable.Load(reader);

                            // Populate ComboBox
                            company_name_combo_box.DisplayMember = "Name";
                            company_name_combo_box.ValueMember = "ID";
                            company_name_combo_box.DataSource = dataTable;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void DataShow()
        {
            name_tb.Text = name;
            email_tb.Text = email;
            country_code_combo_box.Text = countryCode;
            phone_number_tb.Text = phoneNumber;
            address_tb.Text = address;
            dob_tb.Text = dob;
            nationality_combo_box.Text = natonality;
            nid_number_tb.Text = nid;
            experience_tb.Text = experiences;
            GenderSelection(gender);
        }

        private void GenderSelection(string value)
        {
            if (value == "1")
                male_radio_button.Checked = true;

            else if (value == "2")
                female_radio_button.Checked = true;

            else if (value == "3")
                others_radio_button.Checked = true;
        }

        private void name_tb_TextChanged(object sender, EventArgs e)
        {
            if (name == name_tb.Text || string.IsNullOrWhiteSpace(name_tb.Text))
            {
                nameChange = false;
                return;
            }

            nameChange = true;
        }


        private void email_tb_TextChanged(object sender, EventArgs e)
        {
            if (email == email_tb.Text || string.IsNullOrWhiteSpace(email_tb.Text))
            {
                emailChange = false;
                return;
            }

            emailChange = true;
        }


        private void dob_tb_TextChanged(object sender, EventArgs e)
        {
           ValidityCheck validityCheck = new ValidityCheck();
            validityCheck.IsDataBaseDOBValid(dob_tb.Text);
            if (dob == dob_tb.Text || string.IsNullOrWhiteSpace(dob_tb.Text))
            {
                dobChange = false;
                return;
            }

            dobChange = true;

        }

       

    }
}

