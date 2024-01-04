using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.IO;

namespace VOVO
{
    public partial class SearchingResult : UserControl
    {

        
        private string Search { set; get; }
        private string SearchOption { set; get; }
        private int TotalMatch{ set; get; }
        private string SearchingItem { set; get; }
        private string Way { set; get; }
        private string Option { set; get; }



        public SearchingResult()
        {
            InitializeComponent();
            searchItem();
            total_match_result.Text = "Total Match Result: " + TotalMatch;
        }


        public SearchingResult(string search, int totalMatch, string searchOption, string searchingItem, string option)
        {
            InitializeComponent();
            Search = search; // search data
            TotalMatch = totalMatch; // Total match info
            SearchOption = searchOption; // name, email, phone number
            SearchingItem = searchingItem; // bus, customer, driver
            total_match_result.Text = "Total Match Result: " + TotalMatch;
            Option = option; //Search/delete/update
        }


        private void searchItem()
        {
            DataBase dataBase = new DataBase();
            if (SearchingItem == "Bus")
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(dataBase.connectionString))
                    {
                        connection.Open();
                        string query = "SELECT [Name], [Registration Number], [Company Name] FROM [Bus Information] WHERE [Name] LIKE '%' + @Search + '%'";

                        CustomList[] listItem = new CustomList[TotalMatch];
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@Search", Search);

                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                int i = 0;
                                while (reader.Read() && i < TotalMatch)
                                {
                                    listItem[i] = new CustomList();
                                    listItem[i].Title = reader["Name"].ToString();
                                    listItem[i].Message = "Registration Number: " + reader["Registration Number"].ToString() + "    Company Name: " + reader["Company Name"].ToString();
                                    showing_result_panel.Controls.Add(listItem[i]);
                                    i++;
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    CustomMessageBox.Show("Class name is SearchingResult function name is searchiteam [Bus] exception is: " + ex.Message, "Error");
                    return;
                }
            }
            else if (SearchingItem == "Customer")
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(dataBase.connectionString))
                    {
                        connection.Open();
                        string query = "SELECT ID, [Name], [Email], [Phone Number] FROM [Customer Information] WHERE [" + SearchOption + "] LIKE '%' + @Search + '%'";

                        Panel[] listItem = new Panel[TotalMatch];
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@Search", Search);

                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                int i = 0;
                                while (reader.Read() && i < TotalMatch)
                                {
                                    string id = reader["ID"].ToString();
                                    string name = reader["Name"].ToString();
                                    string countryCode = reader["Country Code"].ToString();
                                    string phoneNumber = reader["Phone Number"].ToString();
                                    string email = reader["Email"].ToString();
                                    Panel panel = addPanel(name, phoneNumber, email);
                                    panel.Dock = DockStyle.Top;
                                    panel.Tag = new CustomerData { CustomerID = id, Name = name, CountryCode = countryCode, PhoneNumber = phoneNumber, Email = email }; // Store the data in the Tag property
                                    showing_result_panel.Controls.Add(panel);
                                    panel.Click += new System.EventHandler(this.panelClick);
                                    i++;
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    CustomMessageBox.Show("Class name is SearchingResult function name is searchiteam [Customer] exception is: " + ex.Message, "Error");
                    return;
                }
            }

            else if (SearchingItem == "Employee")
            {
                try
                {
                    string query = "SELECT [ID], [Picutre], [Name], ";
                }

                catch (Exception ex) 
                {
                    CustomMessageBox.Show("Class name is SearchingResult function name is searchiteam [Employee] exception is: " + ex.Message, "Error");
                    return;
                }

            }
        }

        void panelClick(object sender, EventArgs e)
        {
            
            
        }


        Panel addPanel(string name, string phoneNumber, string email)
        {
            Panel panel = new Panel();
            panel.Dock = DockStyle.Top;
            panel.Width = 560;
            panel.Height = 107;
            panel.BackColor = Color.Gainsboro;
            panel.BorderStyle = BorderStyle.FixedSingle;
            panel.Padding = new Padding(1); // Optional: Add padding to adjust the border thickness

            PictureBox pictureBox = new PictureBox();
            pictureBox.Width = 80;
            pictureBox.Height = 80;
            pictureBox.Location = new Point(14, 10);
            pictureBox.Image = VOVO.Properties.Resources.Customer;
            pictureBox.SizeMode = PictureBoxSizeMode.CenterImage;
            panel.Controls.Add(pictureBox);

            Label nameLabel = new Label();
            nameLabel.Text = "Name: " + name;
            nameLabel.Width = 470;
            nameLabel.Height = 35;
            nameLabel.Location = new Point(120, 10);
            nameLabel.Font = new Font("Microsoft Sans Serif", 20, FontStyle.Regular); // Set the font size
            panel.Controls.Add(nameLabel);

            Label phoneLabel = new Label();
            phoneLabel.Text = "Phone Number: " + phoneNumber;
            phoneLabel.Width = 250;
            phoneLabel.Height = 20;
            phoneLabel.Location = new Point(120, 45);
            phoneLabel.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Regular); // Set the font size
            panel.Controls.Add(phoneLabel);

            Label emailLabel = new Label();
            emailLabel.Text = "Email: " + email;
            emailLabel.Width = 360;
            emailLabel.Height = 20;
            emailLabel.Location = new Point(120, 70);
            emailLabel.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Regular); // Set the font size
            panel.Controls.Add(emailLabel);

            return panel;
        }



        private void SearchingResult_Load(object sender, EventArgs e)
        {
            searchItem();
        }

    }
}
