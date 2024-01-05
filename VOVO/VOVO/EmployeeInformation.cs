using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VOVO
{
    public partial class EmployeeInformation : UserControl
    {
        private int totalCount = 0, maleCount = 0, femaleCount = 0, otherCount = 0, CurrentPageNumber = 1, TotalPage = 0;
        private BackgroundWorker dataLoader = new BackgroundWorker();
        private List<EmployeeData> EmployeeDataList = new List<EmployeeData>();
        private string AdminID { set; get; }
        private string Type { set; get; }


        public EmployeeInformation()
        {
            InitializeComponent();
            
        }

        public EmployeeInformation(string adminID, string type) : this()
        {
            AdminID = adminID;
            Type = type;

            InitializeDataLoader();
            EmployeeData();
            PageNumber();
            PageNumberDesign();
            StartDataLoading();
        }

        // Somewhere in your code, like in a button click event or form load event, you initiate the background worker.
        private void StartDataLoading()
        {
            title.Text = Type + " Information";
            if(totalCount == 0)
            {
                data_showing_panel.Visible = false;
                no_data_panel.Visible = true;
                page_number_panel.Visible = false;

                // Create a Label and add it to the Panel
                Label label = new Label
                {
                    Text = "No " + Type,
                    Anchor = AnchorStyles.None,
                    Font = new Font("Montserrat", 30, FontStyle.Bold),
                    AutoSize = true,
                    ForeColor = Color.Coral,
                    Margin = new Padding(0),   // Set margin to zero
                    Padding = new Padding(0)  // Set padding to zero
                };

                no_data_panel.Controls.Add(label);


            }

            else
            {
                data_showing_panel.Visible = true;
                no_data_panel.Visible = false;

                // Check if the background worker is not already running.
                if (!dataLoader.IsBusy)
                {
                    // Start the background worker.
                    dataLoader.RunWorkerAsync();
                }

                else
                {
                    MessageBox.Show("Data can not sho3");
                }
            }
            
        }

        private void InitializeDataLoader()
        {
            dataLoader.DoWork += DataLoad_DoWork;
            dataLoader.RunWorkerCompleted += DataLoad_Completed;
        }

        private void EmployeeData()
        {
            // Total Employee: 205      Male: 120      Female: 70      Others: 35
            try
            {
                DataBase dataBase = new DataBase();
                using (SqlConnection connection = new SqlConnection(dataBase.connectionString))
                {
                    connection.Open();

                    string query = $@"SELECT COUNT(*) AS Total, 
                                            SUM(CASE WHEN Gender = 1 THEN 1 ELSE 0 END) AS Male,
                                            SUM(CASE WHEN Gender = 2 THEN 1 ELSE 0 END) AS Female,
                                            SUM(CASE WHEN Gender <> 1 AND Gender <> 2 THEN 1 ELSE 0 END) AS Other 
                                            FROM [User Information]
                                            WHERE [User Type] = '{Type}'";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                totalCount = reader["Total"] as int? ?? 0; // Handle null by providing a default value (0 in this case)
                                maleCount = reader["Male"] as int? ?? 0;
                                femaleCount = reader["Female"] as int? ?? 0;
                                otherCount = reader["Other"] as int? ?? 0;
                            }
                        }
                    }

                    connection.Close();
                }

                total_employee.Text = "Total " + Type + ": " + totalCount.ToString() + "      Male: " + maleCount.ToString() + "      Female: " + femaleCount.ToString() + "      Others: " + otherCount.ToString();

            }

            catch (Exception ex)
            {
                MessageBox.Show($"Class: Employeeinformation function: EmployeeData and exception is: {ex.Message}", "Error");
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

            if (CurrentPageNumber != 1)
            {
                previous_button.Enabled = true;
                previous_button.BackColor = Color.OrangeRed;
                previous_button.Cursor = Cursors.Hand;

            }

            if (CurrentPageNumber != TotalPage)
            {
                next_button.Enabled = true;
                next_button.BackColor = Color.OrangeRed;
                next_button.Cursor = Cursors.Hand;

            }

            page_number.Text = "Page Number " + CurrentPageNumber.ToString() + " of " + TotalPage.ToString();
        }

        private void PageNumber()
        {
            int i = totalCount / 99;
            double d = (double)totalCount / 99;
            TotalPage = (d > i) ? i : i + 1;
            if(TotalPage == 0)
            {
                TotalPage++;
            }

            // MessageBox.Show("Total Page: " + TotalPage + "\nCurrent Page: " + CurrentPageNumber);
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
                // Simulate a database query
                Thread.Sleep(2000); // Replace this with your actual database query

                // Load data into the EmployeeDataList
                EmployeeDataList = LoadEmployeeDataFromDatabase();

                e.Result = EmployeeDataList;
            }
            catch (Exception ex)
            {
                e.Result = ex; // Pass any exception to RunWorkerCompleted
            }
        }

        private void DataLoad_Completed(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                // Handle any errors
                MessageBox.Show("Class name is EmployeeInformation function name is DataLoad_Completed exception is: " + e.Error.Message, "Error");
            }
            else
            {
                // Update the UI with the loaded data
                List<EmployeeData> loadedData = (List<EmployeeData>)e.Result;
                if (loadedData != null)
                {
                    UpdateUIWithData(loadedData);
                    EmployeeData();
                }
                    
            }
        }

        private List<EmployeeData> LoadEmployeeDataFromDatabase()
        {
            List<EmployeeData> dataList = new List<EmployeeData>();

            // Replace this with your actual database query
            try
            {
                DataBase dataBase = new DataBase();
                Equipment equipment = new Equipment();
                using (SqlConnection connection = new SqlConnection(dataBase.connectionString))
                {
                    string query = $@"SELECT 
                                        [ID], [Picture], [Name], [Country Code], [Phone Number], [Email], [Gender]
                                    FROM 
                                        [User Information] 
                                    WHERE 
                                        [User Type] = '{Type}' -- Specify the condition here
                                    ORDER BY 
                                        [ID]
                                    OFFSET 
                                        {(CurrentPageNumber - 1) * 99} ROWS
                                    FETCH 
                                        NEXT 99 ROWS ONLY";


                    // skips the first (PageNumber - 1) * 100 rows.
                    // FETCH NEXT 100 ROWS ONLY then retrieves the next 100 rows after the offset.
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string id = reader["ID"].ToString();
                                Image image = equipment.ConvertByteArrayToImage((byte[])reader["Picture"]);
                                string name = reader["Name"].ToString();
                                string countryCode = reader["Country Code"].ToString();
                                string phoneNumber = reader["Phone Number"].ToString();
                                string email = reader["Email"].ToString();
                                string gender = reader["Gender"].ToString();

                                if (gender == "Male")
                                {
                                    maleCount++;
                                }

                                else if (gender == "Female")
                                {
                                    femaleCount++;
                                }

                                else { otherCount++; }
                                dataList.Add(new EmployeeData { ID = id, Image = image, Name = name, PhoneNumber = countryCode+phoneNumber, Email = email });
                            }

                        }
                    }
                }

                return dataList;
            }

            catch (Exception ex)
            {
                // Handle any errors
                MessageBox.Show("Class: EmployeeInformation function: LoadEmployeeDataFromDatabase exception is: " + ex.Message, "Error");
                return null;

            }


        }

        private void UpdateUIWithData(List<EmployeeData> data)
        {
            foreach (var emloyee in data)
            {
                System.Windows.Forms.Panel panel = CreateEmployeePanel(emloyee);
                panel.Click += PanelClick;
                data_showing_panel.Controls.Add(panel);
            }
        }

        // DP
        private System.Windows.Forms.Panel CreateEmployeePanel(EmployeeData data)
        {
            System.Windows.Forms.Panel panel = new System.Windows.Forms.Panel
            {
                Dock = DockStyle.Top,
                Width = 560,
                Height = 107,
                BackColor = Color.FromArgb(255, 150, 125),
                BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle,
                Padding = new Padding(1)
            };

            PictureBox pictureBox = new PictureBox
            {
                Width = 80,
                Height = 80,
                Location = new Point(14, 10),
                Image = data.Image,
                SizeMode = PictureBoxSizeMode.CenterImage
            };
            panel.Controls.Add(pictureBox);

            System.Windows.Forms.Label nameLabel = new System.Windows.Forms.Label
            {
                Text = "Name: " + data.Name,
                Width = 470,
                Height = 35,
                Location = new Point(120, 10),
                Font = new Font("Microsoft Sans Serif", 20, FontStyle.Regular)
            };
            panel.Controls.Add(nameLabel);

            System.Windows.Forms.Label phoneLabel = new System.Windows.Forms.Label
            {
                Text = "ID: " + data.ID,
                Width = 250,
                Height = 20,
                Location = new Point(120, 45),
                Font = new Font("Microsoft Sans Serif", 12, FontStyle.Regular)
            };
            panel.Controls.Add(phoneLabel);

            System.Windows.Forms.Label emailLabel = new System.Windows.Forms.Label
            {
                Text = "Email: " + data.Email,
                Width = 360,
                Height = 20,
                Location = new Point(120, 70),
                Font = new Font("Microsoft Sans Serif", 12, FontStyle.Regular)
            };
            panel.Controls.Add(emailLabel);

            panel.Tag = data; // Store the data in the Tag property

            return panel;
        }

        private void PanelClick(object sender, EventArgs e)
        {
            System.Windows.Forms.Panel panel = (System.Windows.Forms.Panel)sender;
            EmployeeData data = (EmployeeData)panel.Tag;

            // Use the data as needed
//            MessageBox.Show($"Name: {data.Name}, Phone Number: {data.PhoneNumber}, Email: {data.Email}");

            if (!AdminForm.Instance.panelContainer.Controls.ContainsKey("EmployeeProfile"))
            {
                
                AdminForm.Instance.panelContainer.Controls.Clear();
                EmployeeProfile employeeProfile = new EmployeeProfile(data.ID, "Employee");
                employeeProfile.Dock = DockStyle.Fill;
                AdminForm.Instance.panelContainer.Controls.Add(employeeProfile);
                this.Hide();
                
            }
        }
    }

}
