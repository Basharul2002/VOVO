using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using Twilio.Types;
using System.Text.RegularExpressions;
using System.Web.UI.WebControls;

namespace VOVO
{
    public partial class CustomerInformation : UserControl
    {
        //  private string connectionString = "Data Source=BASHARUL\\SQLEXPRESS01;Initial Catalog=VOVO;Integrated Security=True";
        private int totalCustomersCount = 0, maleCustomersCount = 0, femaleCustomersCount = 0, otherCustomersCount = 0, CurrentPageNumber = 1, TotalPage = 0;
        private BackgroundWorker dataLoader = new BackgroundWorker();
        private List<CustomerData> customerDataList = new List<CustomerData>();
        private string AdminID { set; get; }

        public CustomerInformation()
        {
            InitializeComponent();
            InitializeDataLoader();
            CustomerData();
            PageNumber();
            PageNumberDesign();
        }

        public CustomerInformation(string adminID) : this()
        {
            AdminID = adminID;
        }

        // Somewhere in your code, like in a button click event or form load event, you initiate the background worker.
        private void StartDataLoading()
        {
            // Check if the background worker is not already running.
            if (!dataLoader.IsBusy)
            {
                // Start the background worker.
                dataLoader.RunWorkerAsync();
            }
        }

        private void InitializeDataLoader()
        {
            dataLoader.DoWork += DataLoad_DoWork;
            dataLoader.RunWorkerCompleted += DataLoad_Completed;
        }

        private void CustomerData()
        {
            // Total Customer: 205      Male: 120      Female: 70      Others: 35
            try
            {
                DataBase dataBase = new DataBase();
                using (SqlConnection connection = new SqlConnection(dataBase.connectionString))
                {
                    connection.Open();

                    string customersQuery = @"SELECT 
                                                COUNT(*) AS TotalCustomers,
                                            SUM
                                                (CASE WHEN Gender = '1' THEN 1 ELSE 0 END) AS MaleCustomers, 
                                            SUM
                                                (CASE WHEN Gender = '2' THEN 1 ELSE 0 END) AS FemaleCustomers,
                                            SUM
                                                (CASE WHEN Gender <> '1' AND Gender <> '2' THEN 1 ELSE 0 END) AS OtherCustomers 
                                            FROM 
                                                [Customer Information]";

                    using (SqlCommand customersCommand = new SqlCommand(customersQuery, connection))
                    {
                        using (SqlDataReader reader = customersCommand.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                totalCustomersCount = reader["TotalCustomers"] as int? ?? 0; ;
                                maleCustomersCount = reader["MaleCustomers"] as int? ?? 0; ;
                                femaleCustomersCount = reader["FemaleCustomers"] as int? ?? 0; ;
                                otherCustomersCount = reader["OtherCustomers"] as int? ?? 0; ;

                            }
                        }
                    }

                    connection.Close();
                }

                total_customer.Text = "Total Customer: " + totalCustomersCount.ToString() + "      Male: " + maleCustomersCount.ToString() + "      Female: " + femaleCustomersCount.ToString() + "      Others: " + otherCustomersCount.ToString();

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Customer Data Function in customer informationfunction");
            }
        }


        private void PageNumberDesign()
        {
            if (CurrentPageNumber == 1)
            {
                //previous_button.Enabled = false;
                previous_button.BackColor = Color.FromArgb(204, 138, 92);
                previous_button.Cursor = Cursors.No;
            }


            if (CurrentPageNumber == TotalPage)
            {
                // next_button.Enabled = false;
                next_button.BackColor = Color.FromArgb(204, 138, 92);
                next_button.Cursor = Cursors.No;
            }
                
            else if (CurrentPageNumber != 1 || CurrentPageNumber != TotalPage)
            {
                previous_button.Enabled = true;
                next_button.Enabled = true;
                previous_button.BackColor = Color.OrangeRed;
                next_button.BackColor = Color.OrangeRed;
                previous_button.Cursor = Cursors.Hand;
                next_button.Cursor = Cursors.Hand;

            }

            page_number.Text = $"Page Number {CurrentPageNumber.ToString()} of {TotalPage.ToString()}";

        }

        private void PageNumber()
        {
            int i = totalCustomersCount / 99;
            double d = (double)totalCustomersCount / 99;

            if (d > i)
            {
                TotalPage = i + 1;
            }

            else TotalPage = i;



            // MessageBox.Show("Total Page Number: " + TotalPage + "\nCurrent Page: " + CurrentPageNumber);
        }

        private void ShowLoadingSpinner()
        {
            // Check if an invoke is required (i.e., if not on the UI thread).
            if (loadingSpinnerPictureBox.InvokeRequired)
            {
                // Invoke the method on the UI thread.
                loadingSpinnerPictureBox.Invoke(new Action(() =>
                {
                    data_showing_panel.Visible = false;
                    loadingSpinnerPictureBox.Visible = true;
                }));
            }
            else
            {
                data_showing_panel.Visible = false;
                loadingSpinnerPictureBox.Visible = true;  // No invoke required, update the UI directly.
            }
        }

        private void HideLoadingSpinner()
        {
            try
            {
                // Check if an invoke is required (i.e., if not on the UI thread).
                if (loadingSpinnerPictureBox.InvokeRequired)
                {
                    // Invoke the method on the UI thread.
                    loadingSpinnerPictureBox.Invoke(new Action(() =>
                    {
                        loadingSpinnerPictureBox.Visible = false;
                        data_showing_panel.Visible = true;
                    }));
                }
                else
                {
                    // No invoke required, update the UI directly.
                    loadingSpinnerPictureBox.Visible = false;
                    data_showing_panel.Visible = true;
                }

                //
            }
            catch (Exception ex)
            {
                MessageBox.Show("Class name is customerInformation function namse is HideLoadingSpinner and excetion: " + ex.Message);
            }
        }


        private void nextPageButton_Click(object sender, EventArgs e)
        {
            if (TotalPage > CurrentPageNumber)
            {
                data_showing_panel.Controls.Clear();
                CurrentPageNumber++;
                PageNumberDesign();
                StartDataLoading();
            }
        }

        private void prevPageButton_Click(object sender, EventArgs e)
        {
            if (CurrentPageNumber > 1)
            {
                data_showing_panel.Controls.Clear();
                CurrentPageNumber--;
                PageNumberDesign();
                StartDataLoading();
            }
        }



        private void DataLoad_DoWork(object sender, DoWorkEventArgs e)
        { 
            try
            {
                // Show the loading spinner when data loading starts.
                ShowLoadingSpinner();

                // Simulate a database query
                Thread.Sleep(2000); // Replace this with your actual database query

                // Load data into the customerDataList
                customerDataList = LoadCustomerDataFromDatabase();

                e.Result = customerDataList;
            }
            catch (Exception ex)
            {
                e.Result = ex; // Pass any exception to RunWorkerCompleted
            }

            finally
            {
               //
            }
        }



        private void DataLoad_Completed(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                // Handle any errors
                MessageBox.Show("Class name is CustomerInformation function name is DataLoad_Completed exception is: " + e.Error.Message, "Error");
            }
            else
            {
                // Update the UI with the loaded data
                List<CustomerData> loadedData = (List<CustomerData>)e.Result;
                if(loadedData != null)
                UpdateUIWithData(loadedData);
                CustomerData();
            }
        }

        private List<CustomerData> LoadCustomerDataFromDatabase()
        {
            List<CustomerData> dataList = new List<CustomerData>();

            // Replace this with your actual database query
            try
            {
                DataBase dataBase = new DataBase();
                using(SqlConnection connection = new SqlConnection(dataBase.connectionString))
                {
                    string query = $@"SELECT 
                                        [ID], [Name], [Country Code], [Phone Number], [Email], [Gender] 
                                    FROM 
                                        [Customer Information] 
                                    ORDER BY 
                                        [ID]
                                    OFFSET 
                                        {(CurrentPageNumber - 1) * 99} ROWS
                                    FETCH 
                                        NEXT 
                                            99 ROWS ONLY";

                    // skips the first (PageNumber - 1) * 100 rows.
                    // FETCH NEXT 100 ROWS ONLY then retrieves the next 100 rows after the offset.
                    connection.Open();
                    using(SqlCommand command = new SqlCommand(query, connection))
                    {
                        int data = 0;
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string id = reader["ID"].ToString();
                                string name = reader["Name"].ToString();
                                string countryCode = reader["Country Code"].ToString();
                                string phoneNumber = reader["Phone Number"].ToString();
                                string email = reader["Email"].ToString();
                                string gender = ((GenderEnum)(Int32.Parse(reader["Gender"].ToString()))).ToString();

                                dataList.Add(new CustomerData { CustomerID = id, Name = name, CountryCode = countryCode, PhoneNumber = phoneNumber, Email = email});
                                data++;                                    
                            }
                        }
                    }
                }

                return dataList;
            }

            catch (Exception ex)
            {
                // Handle any errors
                MessageBox.Show("Class name is CustomerInformation function name is LoadCustomerDataFromDatabase exception is: " + ex.Message, "Error");
                return null;
            
            }

            
        }

        private void UpdateUIWithData(List<CustomerData> data)
        {
            int i = 0;
            foreach (var customer in data)
            {
                i++;
                if (i>0)
                    HideLoadingSpinner();

                System.Windows.Forms.Panel panel = CreateCustomerPanel(customer);
                panel.Click += PanelClick;
                foreach (System.Windows.Controls.Label label in panel.Controls.OfType<System.Windows.Controls.Label>())
                {
                    panel.Click += PanelClick;
                }

                data_showing_panel.Controls.Add(panel);  
            }
        }

        private System.Windows.Forms.Panel CreateCustomerPanel(CustomerData customer)
        {
            System.Windows.Forms.Panel panel = new System.Windows.Forms.Panel
            {
                Dock = DockStyle.Top,
                Width = 560,
                Height = 107,
                BackColor = Color.Gainsboro,
                BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle,
                Padding = new Padding(1)
            };

            PictureBox pictureBox = new PictureBox
            {
                Width = 80,
                Height = 80,
                Location = new Point(14, 10),
                Image = VOVO.Properties.Resources.Customer,
                SizeMode = PictureBoxSizeMode.CenterImage
            };
            panel.Controls.Add(pictureBox);

            System.Windows.Forms.Label nameLabel = new System.Windows.Forms.Label
            {
                Text = $"Name: {customer.Name}",
                Width = 470,
                Height = 35,
                Location = new Point(120, 10),
                Font = new Font("Microsoft Sans Serif", 20, FontStyle.Regular)
            };
            panel.Controls.Add(nameLabel);

            System.Windows.Forms.Label phoneLabel = new System.Windows.Forms.Label
            {
                
                Text = $"Phone Number: {customer.CountryCode} {customer.PhoneNumber}",
                Width = 300,
                Height = 20,
                Location = new Point(120, 45),
                Font = new Font("Microsoft Sans Serif", 12, FontStyle.Regular)
            };
            panel.Controls.Add(phoneLabel);

            System.Windows.Forms.Label emailLabel = new System.Windows.Forms.Label
            {
                Text = $"Email: {customer.Email}",
                Width = 360,
                Height = 20,
                Location = new Point(120, 70),
                Font = new Font("Microsoft Sans Serif", 12, FontStyle.Regular)
            };
            panel.Controls.Add(emailLabel);

            panel.Tag = customer; // Store the data in the Tag property

            return panel;
        }

        private void PanelClick(object sender, EventArgs e)
        {
            System.Windows.Forms.Panel panel = (System.Windows.Forms.Panel)sender;
            CustomerData data = (CustomerData)panel.Tag;

            // Use the data as needed
            MessageBox.Show($"Name: {data.Name}, Phone Number: {data.PhoneNumber}, Email: {data.Email}");

            if (!AdminForm.Instance.panelContainer.Controls.ContainsKey("CustomerProfile"))
            {
                AdminForm.Instance.panelContainer.Controls.Clear();
                CustomerProfile customerProfile = new CustomerProfile(data.Name, data.CountryCode, data.PhoneNumber, data.Email, way: "Data");
                customerProfile.Dock = DockStyle.Fill;
                AdminForm.Instance.panelContainer.Controls.Add(customerProfile);
                this.Hide();
            }
        }
    

    
        private void CustomerInformation_Load(object sender, EventArgs e)
        {
            dataLoader.RunWorkerAsync();
            StartDataLoading();
        }

        private void search_button_Click(object sender, EventArgs e)
        {
            CustomerSearch customerSearch = new CustomerSearch("Search");
            customerSearch.ShowDialog();
        }

        private void delete_button_Click(object sender, EventArgs e)
        {
            CustomerSearch customerSearch = new CustomerSearch("Delete");
            customerSearch.ShowDialog();
        }

        private void update_button_Click(object sender, EventArgs e)
        {
            CustomerSearch customerSearch = new CustomerSearch("Update");
            customerSearch.ShowDialog();
        }
    }    
}

