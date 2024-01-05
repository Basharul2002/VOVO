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
using ZXing;
using static iText.StyledXmlParser.Jsoup.Select.Evaluator;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace VOVO
{
    public partial class AdminDashBoard : UserControl
    {
        private string AdminID;

        private int maleAdmin, femaleAdmin, othersAdmin, maleEmployee, femaleEmployee, othersEmployee, maleDriver, femaleDriver, othersDriver,
                maleConductor, femaleConductor, othersConductor, maleSupervisor, femaleSupervisor, othersSupervisor;
        public AdminDashBoard()
        {
            InitializeComponent();
        }


        public AdminDashBoard(string adminID) : this()
        {
            AdminID = adminID;

            CustomizeDesign();

        }

        private int DateAndTime()
        {
            // string dateAndTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            // 2023-06-14 01:53:39
            DateTime dateAndTimeNow = DateTime.Now;
            int hour = dateAndTimeNow.Hour;

            return hour;
        }

        private string GetTimeOfDayWish()
        {
            int hour = DateAndTime();

            if (hour >= 5 && hour < 12)
                return "Good Morning";

            else if (hour >= 12 && hour < 17)
                return "Good Afternoon";

            else if (hour >= 17 && hour < 20)
                return "Good Evening";

            else
                return "Good Night";
        }

        private void AdminDashBoard_Load(object sender, EventArgs e)
        {
            string wishComment = GetTimeOfDayWish() + " Admin";
            wish.Text = wishComment;
            Custom();

        }


        private void showSubManu(Panel subManu)
        {
            if (subManu.Visible == false)
            { 
                subManu.Visible = true;
                DataPanel(subManu);
            }

            else
                subManu.Visible = false;
        }

        private void DataPanel(Panel panel)
        {
            if(panel.Name.ToString() == "customer_panel" || customer_panel.Visible)
            {
                customer_panel.Visible = true;
                employee_data_panel.Visible = false;
                return;
            }

            else if(panel.Name.ToString() == "employee_data_panel" && employee_data_panel.Visible)
            {
                employee_data_panel.Visible = true;
                customer_panel.Visible = false;
            }
            


        }
        private void Custom()
        {
            DataBase dataBase = new DataBase();
            using (SqlConnection connection = new SqlConnection(dataBase.connectionString))
            {
                connection.Open();

                CustomerBarChartData(connection);
                //CustomerGenderPieChart(connection);
                //CustomerGenderLineChart(connection);
                CustomerData(connection);
               // Bar(connection);
                //EmployeeData(connection);

                connection.Close();
            }

            // AdminPieChart();
            // EmployeePieChart();

        }

        private void CustomerData(SqlConnection connection)
        {
            try
            {
                int totalCustomers = 0, maleCount = 0, femaleCount = 0, othersCount = 0, totalMaleBeforeToday = 0, 
                    totalFemaleBeforeToday = 0, totalOthersBeforeToday = 0, totalPrevious = 0;
                double malePercentage = 0.0, femalePercentage = 0.0, othersPercentage = 0.0, totalCustomersGrowth = 0.0;
                string maleGrowth = string.Empty, femaleGrowth = string.Empty, othersGrowth = string.Empty;


                // Calculate total number of customers and their gender distribution
                string query = "SELECT Gender FROM [Customer Information]";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            totalCustomers++;

                            string gender = ((GenderEnum)(Int32.Parse(reader["Gender"].ToString()))).ToString();
                            if (gender == "Male")
                                maleCount++;
                            else if (gender == "Female")
                                femaleCount++;
                            else if(gender == "Others")
                                othersCount++;
                        }
                    }
                }

                Equipment equipment = new Equipment();  
                // Calculate gender growth percentages based on customers before today's date
                string query1 = "SELECT Gender FROM [Customer Information] WHERE Date < @Today";
                using (SqlCommand command = new SqlCommand(query1, connection))
                {
                    command.Parameters.AddWithValue("@Today", equipment.DataBaseFormatedDate(equipment.TodayDate()));

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string gender = ((GenderEnum)(Int32.Parse(reader["Gender"].ToString()))).ToString();
                            if (gender == "Male")
                                totalMaleBeforeToday++;
           

                            else if (gender == "Female")
                                totalFemaleBeforeToday++;

                            else
                                totalOthersBeforeToday++;
                        }
                    }
                }

                totalCustomers = maleCount + femaleCount + othersCount;
                totalPrevious = totalMaleBeforeToday + totalFemaleBeforeToday + totalOthersBeforeToday;


                // Today Customer Information
                male_customer.Text = "Male: " + (maleCount - totalMaleBeforeToday);
                female_customer.Text = "Female: " + (femaleCount -  totalFemaleBeforeToday);
                others_customer.Text = "Others: " + (othersCount - totalOthersBeforeToday);
                total_customer.Text = "Total: " + (totalCustomers - totalPrevious);

                // CustomMessageBox.Show("Male: " + maleCount + " B: " + totalMaleBeforeToday + "\nFemale: " + femaleCount + " B: " + totalFemaleBeforeToday + "\nOthers: " + othersCount + " B: " + totalOthersBeforeToday);
                number_of_user_label.Text = totalCustomers.ToString();
                if(totalPrevious != 0)
                    totalCustomersGrowth = Math.Round((double) (((totalCustomers - totalPrevious) / totalPrevious) * 100), 2);

                else
                    totalCustomersGrowth = 0;

                GetFormattedPercentageText(user_growth_label, totalCustomersGrowth);

                // Update UI elements with calculated values
                number_of_male.Text = maleCount.ToString();
                number_of_female.Text = femaleCount.ToString();
                number_of_others.Text = othersCount.ToString();


                if (totalMaleBeforeToday != 0)
                    malePercentage = Math.Round((double)((double)((maleCount - totalMaleBeforeToday) / totalMaleBeforeToday) * 100), 5);

                else if (totalMaleBeforeToday == 0)
                    ApplyTextAndColorToLabelForUncountableData(male_growth);

                if (totalFemaleBeforeToday != 0)
                    femalePercentage = Math.Round((double)((double)((femaleCount - totalFemaleBeforeToday) / totalFemaleBeforeToday) * 100), 5);
                else if (totalOthersBeforeToday == 0)
                    ApplyTextAndColorToLabelForUncountableData(female_growth);

                if (totalOthersBeforeToday != 0)
                    othersPercentage = Math.Round((double)((double)((othersCount - totalOthersBeforeToday) / totalOthersBeforeToday) * 100), 5);
                else if (othersCount == 0)
                    ApplyTextAndColorToLabelForUncountableData(others_growth);

               /* CustomMessageBox.Show("number_of_male: " + maleCount + "\ntotalMaleBeforeToday: " + totalMaleBeforeToday + "\nfemaleCount: " + femaleCount + "\ntotalFemaleBeforeToday: " + totalFemaleBeforeToday
                    + "\nothersCount: " + othersCount + "\ntotalOthersBeforeToday: " + totalOthersBeforeToday + "\nmalePercentage: " + malePercentage
                    + "\nfemalePercentage: " + femalePercentage + "\nothersPercentage: " + othersPercentage);
               */
                GetFormattedPercentageText(male_growth, malePercentage);
                GetFormattedPercentageText(female_growth, femalePercentage);
                GetFormattedPercentageText(others_growth, othersPercentage);


            }
            catch (Exception ex)
            {
                MessageBox.Show("Class is Admin Dashboard and function is CustomerData: " + ex.Message, "Exception");
            }
        }

        private void GetFormattedPercentageText(Label label, double percentage)
        {
            Color color = Color.White;
            string formattedText = "";

            if (percentage > 0.00)
            {
                formattedText = $"+{percentage.ToString()}%";
                color = Color.Lime;
            }

            else if (percentage < 0.00)
            {
                formattedText = $"-{percentage.ToString()}%";
                color = Color.FromArgb(0xF60000);
            }

            else if(percentage == 0)
            {
                formattedText = $"{percentage.ToString()}%";
                color = Color.Yellow;
            }

            ApplyTextAndColorToLabel(label, color, formattedText);
        }

        private void ApplyTextAndColorToLabel(Label label, Color colorCode, string formattedText)
        {
            label.Text = formattedText;
            label.ForeColor = colorCode;
        }

        private void ApplyTextAndColorToLabelForUncountableData(Label label)
        {
            label.Text = "N/A";
            label.ForeColor = Color.Cyan;
        }


        private void CustomerBarChartData(SqlConnection connection)
        {
            string[] months = new string[14];
            int[] maleCounts = new int[14];
            int[] femaleCounts = new int[14];
            int[] othersCounts = new int[14];

            DateTime startDate = DateTime.Today.AddYears(-1);

            // Manually populate the months array with month names for the last year
            for (int i = 0; i < 14; i++)
            {
                DateTime monthDate = startDate.AddMonths(i);
                months[i] = monthDate.ToString("MMM yyyy");
                maleCounts[i] = 0;
                femaleCounts[i] = 0;
                othersCounts[i] = 0;
            }

            string query = @"SELECT 
                                Gender, 
                                Date 
                            FROM 
                                [Customer Information] 
                            WHERE 
                                date >= @StartDate";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@StartDate", startDate);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string gender = ((GenderEnum)(Int32.Parse(reader["Gender"].ToString()))).ToString();
                        DateTime date = Convert.ToDateTime(reader["Date"]);
                        int monthIndex = Array.IndexOf(months, date.ToString("MMM yyyy"));

                        if (monthIndex >= 0 && monthIndex < 14)
                        {
                            if (gender == "Male")
                                maleCounts[monthIndex]++;
                            else if (gender == "Female")
                                femaleCounts[monthIndex]++;
                            else if (gender == "Others")
                                othersCounts[monthIndex]++;
                        }
                    }
                }
            }


            for (int i = 0; i < 14; i++)
            {
                barChartGenderDistribution.Series["Male"].Points.AddXY(months[i], maleCounts[i]);
                barChartGenderDistribution.Series["Male"].Points[i].Color = Color.Blue;

                barChartGenderDistribution.Series["Female"].Points.AddXY(months[i], femaleCounts[i]);
                barChartGenderDistribution.Series["Female"].Points[i].Color = Color.Orange;

                barChartGenderDistribution.Series["Others"].Points.AddXY(months[i], othersCounts[i]);
                barChartGenderDistribution.Series["Others"].Points[i].Color = Color.Red;
            }
        }

        private void CustomerGenderPieChart(SqlConnection connection)
        {
            int maleCount = 0;
            int femaleCount = 0;
            int othersCount = 0;

            string query = @"SELECT 
                                Gender 
                            FROM 
                                [Customer Information]";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string gender = ((GenderEnum)(Int32.Parse(reader["Gender"].ToString()))).ToString();
                        if (gender == "Male")
                            maleCount++;
                        else if (gender == "Female")
                            femaleCount++;
                        else
                            othersCount++;
                    }
                }
            }


            int totalCount = maleCount + femaleCount + othersCount;
            double malePercentages, femalePercentages, othersPercentages;

            malePercentages = Math.Round((double)maleCount / totalCount * 100, 2);
            femalePercentages = Math.Round((double)femaleCount / totalCount * 100, 2);
            othersPercentages = Math.Round((double)othersCount / totalCount * 100, 2);



            pieChartGenderDistribution.Series.Clear();
            pieChartGenderDistribution.Series.Add("Gender");
            pieChartGenderDistribution.Series["Gender"].Points.AddXY("Male \n " + malePercentages + "%", maleCount);
            pieChartGenderDistribution.Series["Gender"].Points.AddXY("Female \n" + femalePercentages + "%", femaleCount);
            pieChartGenderDistribution.Series["Gender"].Points.AddXY("Others \n" + othersPercentages + "%", othersCount);

            pieChartGenderDistribution.Series["Gender"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            pieChartGenderDistribution.Series["Gender"].IsVisibleInLegend = false;

            pieChartGenderDistribution.Series["Gender"].Points[0].Color = Color.Blue;
            pieChartGenderDistribution.Series["Gender"].Points[1].Color = Color.Pink;
            pieChartGenderDistribution.Series["Gender"].Points[2].Color = Color.Gray;

            pieChartGenderDistribution.ChartAreas[0].Area3DStyle.Enable3D = true;
            pieChartGenderDistribution.ChartAreas[0].Area3DStyle.Inclination = 0;
            pieChartGenderDistribution.ChartAreas[0].Area3DStyle.Rotation = 0;
            // pieChartGenderDistribution.ChartAreas[0].AxisY.Title = "Number Of Customer";
           // pieChartGenderDistribution.ChartAreas[0].AxisX.Title = "Date";

            pieChartGenderDistribution.Titles.Add("Total Number Of Customer");

            pieChartGenderDistribution.Legends.Clear();
        }

        private void CustomerGenderLineChart(SqlConnection connection)
        {

            DateTime startDate = DateTime.MaxValue.Date;
            int maleCount = 0;
            int femaleCount = 0;
            int othersCount = 0;

            // Create series for Male, Female, and Others
            lineChartGenderDistribution.Series.Clear();
            lineChartGenderDistribution.Series.Add("Male");
            lineChartGenderDistribution.Series.Add("Female");
            lineChartGenderDistribution.Series.Add("Others");
            
            string query = @"SELECT 
                                Gender, 
                                Date 
                            FROM 
                                [Customer Information]";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string gender = ((GenderEnum)(Int32.Parse(reader["Gender"].ToString()))).ToString();
                        DateTime date = Convert.ToDateTime(reader["Date"]);
                        startDate = date;
                        // Update the counts based on gender
                        if (gender == "Male")
                            maleCount++;
                        else if (gender == "Female")
                            femaleCount++;
                        else
                            othersCount++;

                        // Add data points for each gender's series in the chart
                        lineChartGenderDistribution.Series["Male"].Points.AddXY(date, maleCount);
                        lineChartGenderDistribution.Series["Female"].Points.AddXY(date, femaleCount);
                        lineChartGenderDistribution.Series["Others"].Points.AddXY(date, othersCount);
                    }
                }
            }

            // Add a final data point for today if needed
            DateTime todayDate = DateTime.Now.Date;
            if (todayDate > startDate)
            {
                // Update the counts for the final day
                lineChartGenderDistribution.Series["Male"].Points.AddXY(startDate, maleCount);
                lineChartGenderDistribution.Series["Female"].Points.AddXY(startDate, femaleCount);
                lineChartGenderDistribution.Series["Others"].Points.AddXY(startDate, othersCount);
            }



            for (int i = 0; i < lineChartGenderDistribution.Series.Count; i++)
            {
                lineChartGenderDistribution.Series[i].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            }

            lineChartGenderDistribution.ChartAreas[0].AxisY.Title = "Number Of Customer";
            lineChartGenderDistribution.ChartAreas[0].AxisX.Title = "Time";

            // Add a legend
            lineChartGenderDistribution.Legends.Add(new System.Windows.Forms.DataVisualization.Charting.Legend("GenderLegend"));

            // Set titles if needed
            lineChartGenderDistribution.Titles.Clear();
            lineChartGenderDistribution.Titles.Add("Customer Gender Distribution Over Time");
        }


       /*

        private void Bar(SqlConnection connection)
        {
            string query = @"SELECT 'Admin' AS Role FROM [User Information] [User Type] = Admin 
                            UNION ALL
                                SELECT 'Conductor' AS Role FROM [User Information] [User Type] = Conductor
                            UNION ALL
                                SELECT 'Driver' AS Role FROM [User Information] [User Type] = Driver
                            UNION ALL 
                                SELECT 'Employee' AS Role FROM [User Information] [User Type] = Employee
                            UNION ALL
                                SELECT 'Supervisor' AS Role FROM [User Information] WHERE [User Type] = Supervisor";

            // Create an array to store the role counts
            int[] roleCounts = new int[Enum.GetNames(typeof(UserRoleEnum)).Length];

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string role = reader["Role"].ToString();

                        // Map the role string to the enum value
                        if (Enum.TryParse(role, out UserRoleEnum userRole))
                        {
                            // Increment the count for the corresponding role
                            roleCounts[(int)userRole]++;
                        }
                    }
                }
            }

            // Now, roleCounts array contains the counts for each role
            int adminCount = roleCounts[(int)UserRoleEnum.Admin];
            int conductorCount = roleCounts[(int)UserRoleEnum.Conductor];
            int driverCount = roleCounts[(int)UserRoleEnum.Driver];
            int employeeCount = roleCounts[(int)UserRoleEnum.Employee];
            int supervisorCount = roleCounts[(int)UserRoleEnum.Supervisor];

            int totalCount = adminCount + employeeCount + driverCount + conductorCount + supervisorCount;    
            double adminPercentage = 100 - ((double)(totalCount - adminCount) / totalCount) * 100; 
            double employeePercentage = 100 - ((double)(totalCount - employeeCount) / totalCount) * 100; 
            double supervisorPercentage = 100 - ((double)(totalCount - supervisorCount) / totalCount) * 100; 
            double driverPercentage = 100 - ((double)(totalCount - driverCount) / totalCount) * 100; 
            double conductorPercentage = 100 - ((double)(totalCount - conductorCount) / totalCount) * 100;

            // Bar value adjust
            admin_bar.Value = (int)adminPercentage;
            employee_bar.Value = (int)employeePercentage;
            driver_bar.Value = (int)driverPercentage;
            conductor_bar.Value = (int)conductorPercentage;
            supervisor_bar.Value = (int)supervisorPercentage;

            // Bar persentage adjust
            admin_persentage.Text = Math.Round(adminPercentage, 2) + "%";
            employee_persentage.Text = Math.Round(employeePercentage, 2) + "%";
            driver_persentage.Text = Math.Round(driverPercentage, 2) + "%";
            conductor_persentage.Text = Math.Round(conductorPercentage, 2) + "%";
            supervisor_persentage.Text = Math.Round(supervisorPercentage, 2) + "%";

        }
        */

        private void AdminPieChart()
        { 
            int totalCount = maleAdmin + femaleAdmin + othersAdmin;
            double maleAdminPercentages, femaleAdminPercentages, othersAdminPercentages;

            maleAdminPercentages = Math.Round((double)maleAdmin / totalCount * 100, 2);
            femaleAdminPercentages = Math.Round((double)femaleAdmin / totalCount * 100, 2);
            othersAdminPercentages = Math.Round((double)othersAdmin / totalCount * 100, 2);



            pieChartAdminGenderDistribution.Series.Clear();
            pieChartAdminGenderDistribution.Series.Add("Gender");
            pieChartAdminGenderDistribution.Series["Gender"].Points.AddXY("Male \n " + maleAdminPercentages + "%", maleAdmin);
            pieChartAdminGenderDistribution.Series["Gender"].Points.AddXY("Female \n" + femaleAdminPercentages + "%", femaleAdmin);
            pieChartAdminGenderDistribution.Series["Gender"].Points.AddXY("Others \n" + othersAdminPercentages + "%", othersAdmin);

            pieChartAdminGenderDistribution.Series["Gender"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            pieChartAdminGenderDistribution.Series["Gender"].IsVisibleInLegend = false;

            pieChartAdminGenderDistribution.Series["Gender"].Points[0].Color = Color.Blue;
            pieChartAdminGenderDistribution.Series["Gender"].Points[1].Color = Color.Pink;
            pieChartAdminGenderDistribution.Series["Gender"].Points[2].Color = Color.Gray;

            pieChartAdminGenderDistribution.ChartAreas[0].Area3DStyle.Enable3D = true;
            pieChartAdminGenderDistribution.ChartAreas[0].Area3DStyle.Inclination = 0;
            pieChartAdminGenderDistribution.ChartAreas[0].Area3DStyle.Rotation = 0;
            // pieChartGenderDistribution.ChartAreas[0].AxisY.Title = "Number Of Customer";
            // pieChartGenderDistribution.ChartAreas[0].AxisX.Title = "Date";

            pieChartAdminGenderDistribution.Titles.Add("Total Number Of Customer");

            pieChartAdminGenderDistribution.Legends.Clear();
        }

        private void EmployeePieChart()
        {
            int totalCount = maleEmployee + femaleEmployee + othersEmployee;
            double maleEmployeePercentages, femaleEmployeePercentages, othersPercentages;

            maleEmployeePercentages = Math.Round((double)maleEmployee / totalCount * 100, 2);
            femaleEmployeePercentages = Math.Round((double)femaleEmployee / totalCount * 100, 2);
            othersPercentages = Math.Round((double)othersEmployee / totalCount * 100, 2);



            pieChartEmployeeGenderDistribution.Series.Clear();
            pieChartEmployeeGenderDistribution.Series.Add("Gender");
            pieChartEmployeeGenderDistribution.Series["Gender"].Points.AddXY("Male \n " + maleEmployeePercentages + "%", maleEmployee);
            pieChartEmployeeGenderDistribution.Series["Gender"].Points.AddXY("Female \n" + femaleEmployeePercentages + "%", femaleEmployee);
            pieChartEmployeeGenderDistribution.Series["Gender"].Points.AddXY("Others \n" + othersPercentages + "%", othersEmployee);

            pieChartEmployeeGenderDistribution.Series["Gender"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            pieChartEmployeeGenderDistribution.Series["Gender"].IsVisibleInLegend = false;

            pieChartEmployeeGenderDistribution.Series["Gender"].Points[0].Color = Color.Blue;
            pieChartEmployeeGenderDistribution.Series["Gender"].Points[1].Color = Color.Pink;
            pieChartEmployeeGenderDistribution.Series["Gender"].Points[2].Color = Color.Gray;

            pieChartEmployeeGenderDistribution.ChartAreas[0].Area3DStyle.Enable3D = true;
            pieChartEmployeeGenderDistribution.ChartAreas[0].Area3DStyle.Inclination = 0;
            pieChartEmployeeGenderDistribution.ChartAreas[0].Area3DStyle.Rotation = 0;
            // pieChartGenderDistribution.ChartAreas[0].AxisY.Title = "Number Of Customer";
            // pieChartGenderDistribution.ChartAreas[0].AxisX.Title = "Date";

            pieChartEmployeeGenderDistribution.Titles.Add("Total Number Of Customer");

            pieChartEmployeeGenderDistribution.Legends.Clear();
        }

        private void EmployeeData(SqlConnection connection)
        {
            // Call the function for different tables
            GetGenderStatistics(connection, "Admin Information", out maleAdmin, out femaleAdmin, out othersAdmin);
            GetGenderStatistics(connection, "Employee Information", out maleEmployee, out femaleEmployee, out othersEmployee);
            GetGenderStatistics(connection, "Driver Information", out maleDriver, out femaleDriver, out othersDriver);
            GetGenderStatistics(connection, "Conductor Information", out maleConductor, out femaleConductor, out othersConductor);
            GetGenderStatistics(connection, "Supervisor Information", out maleSupervisor, out femaleSupervisor, out othersSupervisor);

            total_admin.Text = "Total \n" + (maleAdmin + femaleAdmin + othersAdmin).ToString();
            male_admin.Text = "Male \n" + maleAdmin.ToString();
            female_admin.Text= "Female \n" + femaleAdmin.ToString();
            others_admin.Text= "Others \n" + othersAdmin.ToString();

            total_employee.Text = "Total \n" + (maleEmployee + femaleEmployee + othersEmployee).ToString();
            male_employee.Text= "Male \n" + maleEmployee.ToString();
            female_employee.Text = "Female \n" + femaleEmployee.ToString();
            others_employee.Text= "Others \n" + othersEmployee.ToString();

            total_driver.Text = "Total: " + (maleDriver + femaleDriver + othersDriver).ToString();
            driver_male.Text = "Male: " + maleDriver.ToString();
            driver_female.Text = "Female: " + femaleDriver.ToString();
            driver_others.Text = "Others: " + othersDriver.ToString();

            total_conductor.Text = "Total: " + (maleConductor + femaleConductor + othersConductor).ToString();
            male_conductor.Text = "Male: " + maleConductor.ToString();
            female_conductor.Text = "Female: " + femaleConductor.ToString();
            others_conductor.Text = "Others: " + othersConductor.ToString();

            total_supervisor.Text = "Total: " + (maleSupervisor + femaleSupervisor + othersSupervisor).ToString();
            male_supervisor.Text = "Male: " + maleSupervisor.ToString();
            female_supervisor.Text = "Female: " + femaleSupervisor.ToString();
            others_supervisor.Text = "Others: " + othersSupervisor.ToString();

        }

        private void GetGenderStatistics(SqlConnection connection, string tableName, out int male, out int female, out int others)
        {
            int maleCount = 0, femaleCount = 0, othersCount = 0;
            int totalCustomers = 0;

            string query = $"SELECT Gender FROM [{tableName}]";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        totalCustomers++;
                        string gender = reader["Gender"].ToString();
                        if (gender == "Male")
                            maleCount++;
                        else if (gender == "Female")
                            femaleCount++;
                        else if (gender == "Others")
                            othersCount++;
                    }
                }
            }

            male = maleCount;
            female = femaleCount;
            others = othersCount;
        }

        private void CustomizeDesign()
        {
            customer_panel.Visible = false;
        }

        private void customer_data_button_Click(object sender, EventArgs e)
        {
            showSubManu(customer_panel);
        }

        private void employee_data_button_Click(object sender, EventArgs e)
        {
            if(employee_data_panel.Visible == false) 
            {
                employee_data_panel.Visible = true;
            }

            else if (employee_data_panel.Visible == true)
            {
                employee_data_panel.Visible = false;
            }
        }

        private void customer_information_button_Click(object sender, EventArgs e)
        {
            if (!AdminForm.Instance.panelContainer.Controls.ContainsKey("CustomerInformation"))
            {
                AdminForm.Instance.panelContainer.Controls.Clear();
                CustomerInformation customerInformation = new CustomerInformation(AdminID);
                customerInformation.Dock = DockStyle.Fill;
                AdminForm.Instance.panelContainer.Controls.Add(customerInformation);
            }
        }
    


        private void driver_button_Click(object sender, EventArgs e)
        {
            if (!AdminForm.Instance.panelContainer.Controls.ContainsKey("RegistrationFormEducationalQualification"))
            {
                // MessageBox.Show(Type + " Registration Form");
                AdminForm.Instance.panelContainer.Controls.Clear();
                EmployeeInformation employeeInformation = new EmployeeInformation(AdminID, "Driver");
                employeeInformation.Dock = DockStyle.Fill;
                AdminForm.Instance.panelContainer.Controls.Add(employeeInformation);
            }
        }

        private void conductor_button_Click(object sender, EventArgs e)
        {
            if (!AdminForm.Instance.panelContainer.Controls.ContainsKey("RegistrationFormEducationalQualification"))
            {
                // MessageBox.Show(Type + " Registration Form");
                AdminForm.Instance.panelContainer.Controls.Clear();
                EmployeeInformation employeeInformation = new EmployeeInformation(AdminID, "Conductor");
                employeeInformation.Dock = DockStyle.Fill;
                AdminForm.Instance.panelContainer.Controls.Add(employeeInformation);
            }
        }

        private void supervisor_button_Click(object sender, EventArgs e)
        {
            if (!AdminForm.Instance.panelContainer.Controls.ContainsKey("RegistrationFormEducationalQualification"))
            {
                // MessageBox.Show(Type + " Registration Form");
                AdminForm.Instance.panelContainer.Controls.Clear();
                EmployeeInformation employeeInformation = new EmployeeInformation(AdminID, "Supervisor");
                employeeInformation.Dock = DockStyle.Fill;
                AdminForm.Instance.panelContainer.Controls.Add(employeeInformation);
            }
        }
    }
}



