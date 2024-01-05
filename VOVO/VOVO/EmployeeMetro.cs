using MetroFramework.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static iText.IO.Image.Jpeg2000ImageData;

namespace VOVO
{
    public partial class EmployeeMetro : MetroFramework.Forms.MetroForm
    {


        private string id, operation, companyID, name, email, countryCode, phoneNumber, address, dob, gender, natonality, nid, experiences;
        private bool insert = false, nameChange, emailChange, countryCodeChange, phoneNumberChange, addressChange, dobChange, genderChange, natonalityChange, nidChange, experiencesChange;




        public EmployeeMetro()
        {
            InitializeComponent();
            DataLoad();
        }




        private void personal_information_panel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void metroLabel10_Click(object sender, EventArgs e)
        {

        }

        private void metroTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void personal_information_button_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void id_label_Click(object sender, EventArgs e)
        {

        }



        private void metroLabel8_Click(object sender, EventArgs e)
        {

        }


        private void experience_tb_Click(object sender, EventArgs e)
        {

        }











        private void update_button_Click(object sender, EventArgs e)
        {
            DataBase database = new DataBase();

            operation_button.Visible = false;
            operation_button.Text = "Update";

            if (data_grid_view.SelectedRows.Count == 0 && data_grid_view.SelectedColumns.Count == 0)
            {
                MessageBox.Show("No rows or columns selected.", "Info", MessageBoxButtons.OK);
                return;
            }

            string query =
                            $@"UPDATE [User Information] SET Name = '{name_tb.Text}', Email = '{email_tb.Text}', [Country Code] = '{country_code_combo_box.Text}',
                                    [Phone Number] = '{phone_number_tb.Text}',[Address] = '{address_tb.Text}', 
                                    [Date Of Birth] = '{dob_tb.Text}', 
                                    Gender = '{SelectedGenderID()}', Nationality = '{nationality_tb.Text}', 
                                    [NID Number] = '{nid_number_tb.Text}', 
                                    Experience = '{experience_tb.Text}'         
                                                            
                                                        WHERE ID = '{id_label.Text}'";
            DataOperation(query, database.connectionString);
            MessageBox.Show($"{name_tb.Text} your account successfully Updated");
        }





        private void back_button_click(object sender, EventArgs e)
        {
            EmployeeLogin employeeLoginForm = new EmployeeLogin();
            employeeLoginForm.Show();
            this.Close();

        }

        private void country_code_combo_box_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void delete_button_Click(object sender, EventArgs e)
        {
            if (data_grid_view.SelectedRows.Count == 0 && data_grid_view.SelectedColumns.Count == 0)
            {
                MessageBox.Show("No rows or columns selected.", "Info", MessageBoxButtons.OK);
                return;
            }

            DeleteAction();
            DataLoad();
            data_grid_view.Refresh();
            data_grid_view.ClearSelection();


            MessageBox.Show($"{name_tb.Text} your account has been Deleted");

        }







        private void refresh_button_Click(object sender, EventArgs e)
        {
            DataLoad();
            data_grid_view.ClearSelection();
            TextBoxClear();

        }

        private int RowsNumber;

        private void data_grid_view_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            RowsNumber = e.RowIndex;
            if (e.RowIndex >= 0)
            {
                string query = $@"SELECT * FROM [User Information]  
                                            WHERE ID = '{data_grid_view.Rows[e.RowIndex].Cells[0].Value.ToString()}'";

                DataShowing(query);
            }
        }

        private void data_grid_view_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }





        private void DataLoad()
        {
            DataTable dataTable;
            DataBase dataBase = new DataBase();

            using (SqlConnection connection = new SqlConnection(dataBase.connectionString))
            {
                string query = @"SELECT 
                            ID,
                            Name, 
                            [Email], 
                            [Country Code], 
                            [Phone Number], 
                            [Address], 
                            [NID Number] 
                         FROM 
                             [User Information] 
                         WHERE 
                             [User Type] = 'Employee'
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









 



        private void DeleteAction()
        {
            DialogResult result = MessageBox.Show("Are you sure you ?", "Warning", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                DataBase dataBase = new DataBase();
                string query = $"DELETE FROM [User Information] WHERE [ID] = '{id_label.Text}'";
                DataOperation(query, dataBase.connectionString);
            }




            else
            {

            }
        }






        private void operation_button_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(name_tb.Text) || string.IsNullOrWhiteSpace(email_tb.Text)
                || string.IsNullOrWhiteSpace(phone_number_tb.Text) || string.IsNullOrWhiteSpace(address_tb.Text)
                || string.IsNullOrWhiteSpace(nationality_tb.Text)
                || string.IsNullOrWhiteSpace(experience_tb.Text))
            {
                MessageBox.Show("Please full fill all info", "VOVO");
                return;
            }

            DataBase dataBase = new DataBase();


            if (SelectedGenderID() == 0)
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
                                           (ID, Name, Email,  [Country Code], [Phone Number],
                                           Address, Gender, [Date Of Birth], Nationality, [NID Number], 
                                           Experience, Date, Time, [User Type])
                                          VALUES
                                             (
                                                '{id_label.Text}', '{name_tb.Text}', '{email_tb.Text}', '{country_code_combo_box.Text.Substring(0, 4)}',
                                                '{phone_number_tb.Text}', '{address_tb.Text}', '{SelectedGenderID()}', '{dob_tb.Text}', 
                                                '{nationality_tb.Text}', '{nid_number_tb.Text}', '{experience_tb.Text}',
                                                '{equipment.DataBaseFormatedDate(equipment.TodayDate())}', '{equipment.Time()}', 'Employee'
                                             )";

                DataOperation(query, dataBase.connectionString);
                return;
            }


            query = $@"UPDATE [User Information] SET Name = '{name_tb.Text}', Email = '{email_tb.Text}', Country Code = '{country_code_combo_box.Text}',
            [Phone Number] = '{phone_number_tb.Text}',[Address] = '{address_tb.Text}', [Date Of Birth] = '{dob_tb.Text}', 
            Gender = '{SelectedGenderID()}', Nationality = '{nationality_tb.Text}', [NID Number] = '{nid_number_tb.Text}', 
            Experience = '{experience_tb.Text}'         WHERE ID = '{id_label.Text}'";


            query = query.TrimEnd(',', ' ');
            query = $"{query}";

            DataOperation(query, dataBase.connectionString);
            MessageBox.Show($"{name_tb.Text} successfully registered");

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


                    connection.Close();
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Class name is EmployeeMetro and function name is DataOperation and exception: " + ex.Message);
            }

        }







        private int SelectedGenderID()
        {
            if (male_radio_button.Checked)
                return 1;

            if (female_radio_button.Checked)
                return 2;

            if (others_radio_button.Checked)
                return 3;

            else
                return 0;
        }






        private void new_button_Click(object sender, EventArgs e)
        {
            DataBase dataBase = new DataBase();
            insert = true;
            Equipment equipment = new Equipment();
            id_label.Text = equipment.idGenarator("Employee");
            operation_button.Visible = true;

            TextBoxClear();

            /* string query = $@"INSERT INTO [User Information] 
                                            (ID, Name, Email, [Phone Number], 
                                            Address, Gender, [Date Of Birth], Nationality, [NID Number], 
                                            Experience, Date, Time)
                                       VALUES
                                           (
                                                 '{id_label.Text}', '{name_tb.Text}', '{email_tb.Text}',  
                                                 '{phone_number_tb.Text}', '{address_tb.Text}', '{SelectedGenderID()}', '{dob_tb.Text}', 
                                                 '{nationality_tb.Text}', '{nid_number_tb.Text}', '{experience_tb.Text}',
                                                 '{equipment.DataBaseFormatedDate(equipment.TodayDate())}', '{equipment.Time()}'
                                           )";

             DataOperation(query, dataBase.connectionString);*/
            return;
        }






        private void TextBoxClear()
        {
            name_tb.Text = string.Empty;
            email_tb.Text = string.Empty;
            dob_tb.Text = string.Empty;
            country_code_combo_box.Text = string.Empty;
            phone_number_tb.Text = string.Empty;
            male_radio_button.Checked = false;
            female_radio_button.Checked = false;
            others_radio_button.Checked = false;
            address_tb.Text = string.Empty;
            nationality_tb.Text = string.Empty;
            nid_number_tb.Text = string.Empty;
            experience_tb.Text = string.Empty;
        }







        private bool change;


        private void search_button_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Searchbar_tb.Text))
            {
                MessageBox.Show("Insert your ID");
                return;
            }

            string query = $"Select * From [User Information] Where ID = '{Searchbar_tb.Text}'";
            DataShowing(query);


        }








        private void DataShowing(string query)
        {
            DataBase dataBase = new DataBase();
            try
            {
                using (SqlConnection connection = new SqlConnection(dataBase.connectionString))
                {


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


                                ShowData();
                            }
                            else
                            {
                                MessageBox.Show("No data found");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Class name is EmployeeMetro and function is ShowDataing and exception: " + ex.Message);
            }
        }









        private void ShowData()
        {
            name_tb.Text = name;
            email_tb.Text = email;
            country_code_combo_box.Text = countryCode;
            phone_number_tb.Text = phoneNumber;
            address_tb.Text = address;
            dob_tb.Text = dob;
            nationality_tb.Text = natonality;
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
            if (name != name_tb.Text || string.IsNullOrWhiteSpace(name_tb.Text))
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








        private void TextBoxeFromGrid()
        {

            /*if (data_grid_view.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = data_grid_view.SelectedRows[0];

                
                id_label.Text = selectedRow.Cells["ID"].Value.ToString();
                name_tb.Text = selectedRow.Cells["Name"].Value.ToString();
                email_tb.Text = selectedRow.Cells["Email"].Value.ToString();
                country_code_combo_box.Text = selectedRow.Cells["Country Code"].Value.ToString();
                phone_number_tb.Text = selectedRow.Cells["Phone Number"].Value.ToString();
                address_tb.Text = selectedRow.Cells["Address"].Value.ToString();
                nid_number_tb.Text = selectedRow.Cells["NID Number"].Value.ToString();
            }*/
        }








        private void Disable(string operation)
        {
            /*
            switch(operation)
            {
                case "Search":
                    name_tb.Enabled = false;
                    email_tb.Enabled = false;
                    country_code_combo_box.Enabled = false;
                    phone_number_tb.Enabled = false;
                    address_tb.Enabled = false;
                    male_radio_button.Enabled = false;
                    female_radio_button.Enabled = false;
                    others_radio_button.Enabled = false;
                    na
            }
            */
        }

    }
}

