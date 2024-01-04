﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VOVO
{
    public partial class CustomerSearch : Form
    {
        private string shareOption = "Name";

        private string Option { set; get; }

        public CustomerSearch()
        {
            InitializeComponent();
            customDesign();
            //FormControlsUtility.ConfigureFormResize(this);
        }

        

        public CustomerSearch(string option) : this()
        {
            Option = option;
        }

        private void customDesign()
        {
            name_button.Enabled = false;
            phone_number_button.Enabled = true;
            email_button.Enabled = true;
        }

        private int SearchResult(string columnName)
        {

            //MessageBox.Show(columnName);
            int matchCount = 0;
            string searchString = search_tb.Texts;
            DataBase dataBase = new DataBase();
            try
            {
                string query = "SELECT * FROM [Customer Information] WHERE [" + columnName + "] LIKE '%' + @SearchString + '%'";

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
                                string customerId = reader["ID"].ToString(); // Assuming the customer ID is in the first column of the result

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
                CustomMessageBox.Show(ex.Message);
                return -1;
            }
        }

        private void custom_textbox(string shareOption)
        {
            if(shareOption== "Name")
            {
                name_button.Enabled = false;
                phone_number_button.Enabled = true;
                email_button.Enabled = true;
                search_tb.PlaceholderText = "Enter Customer Name";
                
            }

            else if(shareOption=="Phone Number")
            {
                name_button.Enabled = true;
                phone_number_button.Enabled = false;
                email_button.Enabled = true;
                search_tb.PlaceholderText = "Enter Customer Phone Number";
                
            }

            else if( shareOption== "Email")
            {
                name_button.Enabled = true;
                phone_number_button.Enabled = true;
                email_button.Enabled = false;
                search_tb.PlaceholderText = "Enter Customer Email Address";
                
            }
        }

        private void name_button_Click(object sender, EventArgs e)
        {
           custom_textbox("Name");
            shareOption = "Name";
        }

        private void phone_number_button_Click(object sender, EventArgs e)
        {
            custom_textbox("Phone Number");
            shareOption = "Phone Number";
        }

        private void email_button_Click(object sender, EventArgs e)
        {
            custom_textbox("Email");
            shareOption = "Email";
        }




        private void search_button_Click(object sender, EventArgs e)
        {
            string search = search_tb.Texts;

            if(string.IsNullOrEmpty(search) )
            {
                CustomMessageBox.Show("Enter Customer name");
            }


            else if (!string.IsNullOrEmpty(search))
            {
                if(shareOption == "Name")
                {
                    int totalMatchCustomer = SearchResult("Name");
                    if (totalMatchCustomer > 0)
                    {
                        if (!AdminForm.Instance.panelContainer.Controls.ContainsKey("SearchingResult"))
                        {
                            // CustomMessageBox.Show("Total Match: " + totalMatchCustomer);
                            AdminForm.Instance.panelContainer.Controls.Clear();
                            SearchingResult searchingResult = new SearchingResult(search, totalMatchCustomer, "Name", "Customer", Option);
                            searchingResult.Dock = DockStyle.Fill;
                            AdminForm.Instance.panelContainer.Controls.Add(searchingResult);
                            this.Hide();
                        }
                    }

                    else if (totalMatchCustomer == 0)
                    {
                        CustomMessageBox.Show(search + " is not found");
                    }

                    else if (totalMatchCustomer == -1)
                    {
                        CustomMessageBox.Show("ERROR 404", "Error");

                    }
                }


                else if (shareOption == "Phone Number")
                {
                    int totalMatchCustomer = SearchResult("Phone Number");
                    if (totalMatchCustomer > 0)
                    {
                        if (!AdminForm.Instance.panelContainer.Controls.ContainsKey("SearchingResult"))
                        {
                            // MessageBox.Show("Total Match: " + totalMatchCustomer);
                            AdminForm.Instance.panelContainer.Controls.Clear();
                            SearchingResult searchingResult = new SearchingResult(search, totalMatchCustomer, "Phone Number", "Customer", Option);
                            searchingResult.Dock = DockStyle.Fill;
                            AdminForm.Instance.panelContainer.Controls.Add(searchingResult);
                            this.Hide();
                        }
                    }

                    else if (totalMatchCustomer == 0)
                    {
                        CustomMessageBox.Show(search + " is not found");
                    }

                    else if (totalMatchCustomer == -1)
                    {
                        CustomMessageBox.Show("ERROR 404", "Error");

                    }
                }

                else if (shareOption == "Email")
                {
                    int totalMatchCustomer = SearchResult("Email");
                    if (totalMatchCustomer > 0)
                    {
                        if (!AdminForm.Instance.panelContainer.Controls.ContainsKey("SearchingResult"))
                        {
                            // MessageBox.Show("Total Match: " + totalMatchCustomer);
                            AdminForm.Instance.panelContainer.Controls.Clear();
                            SearchingResult searchingResult = new SearchingResult(search, totalMatchCustomer, "Email", "Customer", Option);
                            searchingResult.Dock = DockStyle.Fill;
                            AdminForm.Instance.panelContainer.Controls.Add(searchingResult);
                            this.Hide();
                        }
                    }

                    else if (totalMatchCustomer == 0)
                    {
                        CustomMessageBox.Show(search + " is not found");
                    }

                    else if (totalMatchCustomer == -1)
                    {
                        CustomMessageBox.Show("ERROR 404", "Error");

                    }
                }
            }
        }

        private void CustomerSearch_SizeChanged(object sender, EventArgs e)
        {
        }
    }
}
