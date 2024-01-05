using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Net;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView;

namespace VOVO
{
    public partial class BusRegistration : UserControl
    {
        private string adminID, busType, ownerName;
        private int totalSeat;
        public BusRegistration()
        {
            InitializeComponent();
        }


        public BusRegistration(string adminID) : this()
        {
            this.adminID = adminID;

            PopulateCompanyComboBox();
        }

        private bool BusAlreadyRegister()
        {
            string busNumber = bus_number_tb.Text;
            string chechisNumber = bus_cechis_number_tb.Text;
            string engineNumber = bus_engine_number_tb.Text;

            DataBase dataBase = new DataBase();
            bool exists = dataBase.IsBusInfoExists(busNumber, chechisNumber, engineNumber);

            if(exists)
            {
                MessageBox.Show("This Bus already register");
                return true;
            }

            return false;
        }

        private void submit_button_Click(object sender, EventArgs e)
        {
            string number = bus_number_tb.Text;
            string name = bus_name_tb.Text;
            string cechisNumber = bus_cechis_number_tb.Text;
            string ownerName = ((CompanyInfo)bus_owner_name_combo_box.SelectedItem).ID;
            string engineNumber = bus_engine_number_tb.Text;
            string engineType = engine_type_combo_box.Text;
            string busType = bus_type_tb.Text;
            string companyName = bus_company_name_tb.Text;



            if (string.IsNullOrEmpty(number) || string.IsNullOrEmpty(name)  || string.IsNullOrEmpty(cechisNumber) || string.IsNullOrEmpty(engineNumber) || string.IsNullOrEmpty(engineType) || string.IsNullOrEmpty(busType) || string.IsNullOrEmpty(companyName) || string.IsNullOrEmpty(ownerName))
            {
                MessageBox.Show("Please fill in all required fields");
                return;
            }

            if (!BusAlreadyRegister())
            {
                DataBase dataBase = new DataBase();
                dataBase.BusRegistration(adminID, number, name, cechisNumber, engineNumber, engineType, busType, companyName, ownerName, totalSeat);
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
                    string query = "SELECT ID, Name FROM [Company Information]";

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
                                bus_owner_name_combo_box.Items.Add(company);
                            }
                        }
                    }

                    // Set the DisplayMember and ValueMember properties of the ComboBox
                    bus_owner_name_combo_box.DisplayMember = "Name";
                    bus_owner_name_combo_box.ValueMember = "ID";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Class is ChooseCompany function name is PopulateCompanyComboBox and exception is: " + ex.Message, "Error");
            }
        }

        private void BusRegistration_Load(object sender, EventArgs e)
        {

        }

        private void bus_owner_name_combo_box_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            if (comboBox.SelectedItem != null)
            {
                CompanyInfo selectedCompany = (CompanyInfo)comboBox.SelectedItem;
                ownerName = selectedCompany.ID;
                // Use the selected company ID as needed
                //MessageBox.Show("Selected Company ID: " + companyID);
            }
        }

        private void bus_type_tb_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            busType = bus_type_tb.SelectedItem.ToString();

            switch (busType)
            {
                case "Economic Non AC":
                case "Economic AC":
                    total_seat_tb.Text = "48";
                    totalSeat = 48;
                    break;

                case "Business Class":
                    total_seat_tb.Text = "36";
                    totalSeat = 36;
                    break;

                case "Double Decker":
                    total_seat_tb.Text = "47";
                    totalSeat = 47;
                    break;

                case "Sleeper Coach":
                    total_seat_tb.Text = "30";
                    totalSeat = 30;
                    break;

                default:
                    MessageBox.Show("Choose valid", "VOVO");
                    break;
            }
        }
    }
}
