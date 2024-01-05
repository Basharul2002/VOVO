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
using System.Xml.Linq;
using System.Text.RegularExpressions;
using System.Data.SqlClient;
using System.Runtime.InteropServices;

namespace VOVO
{
    public partial class BusSearchAndUpdate : Form
    {

        // This is the searching way(bus registration number or bus company name) for database
        private string searchOption; // this is this class attribute its choose by user
        private string Option { set; get; }

        public BusSearchAndUpdate()
        {
            InitializeComponent();

            FormControlsUtility.ConfigureFormResize(this);
        }

        // Rounded Corners  


        public BusSearchAndUpdate(string option) : this()
        {
            searchOption = "Registration Number";
            Option = option;
        }

        private int SearchResult(string columnName)
        {
            int matchCount = 0;
            string searchString = search_tb.Text;

            try
            {
                string query = "SELECT * FROM [Bus Information] WHERE [columnName] LIKE '%' + @SearchString + '%'";
                DataBase dataBase = new DataBase();
                using (SqlConnection connection = new SqlConnection(dataBase.connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@SearchString", searchString);

                        // Execute the query and process the results
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Process each matching row from the database
                                string matchedString = reader.GetString(0); // Assuming the matched string is in the first column of the result
                                                                            // Do something with the matched string

                                matchCount++; // Increment the match count
                            }
                        }
                    }
                    connection.Close();
                }

                return matchCount; // Return the total number of matches
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return -1;
            }
        }


        private void registration_number_button_Click(object sender, EventArgs e)
        {
            search_tb.WaterMark = "Enter Bus Registration Number";
            registration_number_button.Enabled = false;
            company_name_button.Enabled = true;
            searchOption = "Registration Number";
        }

        private void company_name_button_Click(object sender, EventArgs e)
        {
            search_tb.WaterMark = "Enter Bus Company Name";
            company_name_button.Enabled = false;
            registration_number_button.Enabled = true;
            searchOption = "Company Name";
        }

        private void search_button_Click(object sender, EventArgs e)
        {
            int totalMatchBus = 0;
            Boolean found = false;
            bool error = false;
            string search = search_tb.Text;
            if (searchOption == "Registration Number")
            {
                if (string.IsNullOrEmpty(search))
                {
                    MessageBox.Show("Please enter registration number");
                }

                else if (!string.IsNullOrEmpty(search))
                {
                    if (search.Length >= 7)
                    {
                        totalMatchBus = SearchResult("Registration Number");
                        if (totalMatchBus >= 0)
                        {
                            if (totalMatchBus == 0)
                            {
                                found = false;
                            }

                            else if (totalMatchBus > 0)
                            {
                                found = true;
                            }
                        }


                        else if (totalMatchBus == -1)
                        {
                            error = true;
                        }
                    }

                    else if (search.Length > 7)
                    {
                        MessageBox.Show("Invalied Registration Number");
                    }

                }

            }

            else if (searchOption == "Company Name")
            {
                if (string.IsNullOrEmpty(search))
                {
                    MessageBox.Show("Please enter company name");
                }

                else if (!string.IsNullOrEmpty(search))
                {
                    totalMatchBus = SearchResult("Company Name");
                    if (totalMatchBus >= 0)
                    {
                        if (totalMatchBus == 0)
                        {
                            found = false;
                        }

                        else if (totalMatchBus > 0)
                        {
                            found = true;
                        }
                    }

                    else if (totalMatchBus == -1)
                    {
                        error = true;
                    }

                }
            }


            if (found == false && error == false && !string.IsNullOrEmpty(search))
            {
                MessageBox.Show("Bus not found");
            }

            else if (error == true && found == false && !string.IsNullOrEmpty(search))
            {
                MessageBox.Show("ERROR 404", "Error");
            }

            else if (found == true && error == false && !string.IsNullOrEmpty(search))
            {
                if (!AdminForm.Instance.panelContainer.Controls.ContainsKey("SearchingResult"))
                {
                    AdminForm.Instance.panelContainer.Controls.Clear();
                    // string search, int totalMatch, string searchOption, string searchingItem, string option
                    SearchingResult searchingResult = new SearchingResult(search, totalMatchBus, searchOption, "Bus", Option);
                    searchingResult.Dock = DockStyle.Fill;
                    AdminForm.Instance.panelContainer.Controls.Add(searchingResult);
                    this.Hide();
                }
            }

        }

        private void BusSearchAndUpdate_SizeChanged(object sender, EventArgs e)
        {
            FormControlsUtility.ConfigureFormResize(this);

        }
    }
}

