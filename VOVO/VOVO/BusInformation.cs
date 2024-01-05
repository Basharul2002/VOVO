using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Twilio.TwiML.Voice;

namespace VOVO
{
    public partial class BusInformation : UserControl
    {
        private int totalNumberOfBus;
        public BusInformation()
        {
            InitializeComponent();
            BusInfo();
        }

        
        void panelClick(object sender, EventArgs e)
        {
            Panel panel = (Panel)sender;
            BusData data = (BusData)panel.Tag;
            string name = data.Name;
            string registrationNumber = data.RegistrationNumber;
            string companyName = data.CompanyName;

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

        private void BusInfo()
        {
            totalNumberOfBus = totalBus("Total");
            total_bus.Text = "Total Bus: " + totalNumberOfBus;
            ac_bus.Text = "AC: " + totalBus("AC");
            non_ac_bus.Text = "NON AC: " + totalBus("Non AC");
            double_decker_bus.Text = "Double Decker: " + totalBus("Double Decker");
        }

        private int totalBus(string type)
        {
            try
            {
                DataBase dataBase = new DataBase();
                string tableName = "[Bus Information]";
                string columnName = "[Bus Number]";
                string query = $"SELECT MAX({columnName}) FROM {tableName}";

                if (type != "Total")
                {
                    query += $" WHERE [Bus Type] = '{type}'";
                }

                using (SqlConnection connection = new SqlConnection(dataBase.connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        object result = command.ExecuteScalar();

                        if (result != null && result != DBNull.Value)
                        {
                            int maxValue = Convert.ToInt32(result);
                            return maxValue;
                        }
                        else
                        {
                            return 0;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Class name is BusInformation function name is totalBus exception is: " + ex.Message, "Error");
                return 0;
            }
        }


        private void showingData()
        {
            DataBase dataBase = new DataBase();

            try
            {
                using (SqlConnection connection = new SqlConnection(dataBase.connectionString))
                {
                    connection.Open();
                    string query = "SELECT [Bus Name], [Bus Number], [Company Name] FROM [Bus Information]";

                    Panel[] listItem = new Panel[totalNumberOfBus];
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            int i = 0;
                            while (reader.Read() && i < totalNumberOfBus)
                            {
                                string name = reader["Bus Name"].ToString();
                                string registrationNumber = reader["Bus Number"].ToString();
                                string companyName = reader["Company Name"].ToString();
                                Panel panel = addPanel(name, registrationNumber, companyName);
                                panel.Dock = DockStyle.Top;
                                panel.Tag = new BusData { Name = name, RegistrationNumber = registrationNumber, CompanyName = companyName }; // Store the data in the Tag property
                                data_showing_panel.Controls.Add(panel);
                                panel.Click += new System.EventHandler(this.panelClick);
                                i++;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Class name is BusInformation function name is showingData exception is: " + ex.Message, "Error");
                return;
            }
        
        }

        private void search_button_Click(object sender, EventArgs e)
        {
            BusSearchAndUpdate busSearchAndUpdate = new BusSearchAndUpdate("Search");
            busSearchAndUpdate.ShowDialog();
        }

        private void delete_button_Click(object sender, EventArgs e)
        {
            BusSearchAndUpdate busSearchAndUpdate = new BusSearchAndUpdate("Delete");
            busSearchAndUpdate.ShowDialog();

        }

        private void BusInformation_Load(object sender, EventArgs e)
        {
            showingData();
        }

        private void update_button_Click(object sender, EventArgs e)
        {
            BusSearchAndUpdate busSearchAndUpdate = new BusSearchAndUpdate("Update");
            busSearchAndUpdate.ShowDialog();
        }
    }
}
