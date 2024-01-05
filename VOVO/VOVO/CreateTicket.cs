using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VOVO
{
    public partial class CreateTicket : UserControl
    {
        private string TicketID, SelectedBusNumber, SelectedBusType;


        private string employeeID, selectedRoute, from, to;

        public CreateTicket()
        {
            InitializeComponent();
        }


        public CreateTicket(string employeeID, string selectedRoute = "", string from = "", string to = "") : this()
        {
            this.employeeID = employeeID;
            this.selectedRoute = selectedRoute; // Add this line to store the selected route ID
            this.from = from;
            this.to = to;


            Design();
            PopulateComboBox();
            // MessageBox.Show("EmployeeID: " + this.employeeID + "this.selectedRoute: " + this.selectedRoute);

            //route_button.ResetText();
            DataStore();

            if (selectedRoute == null)
                return;

        }

        private void Design()
        {
            Equipment equipment = new Equipment();
            TicketID = equipment.idGenarator("Ticket");
            ticket_id_tb.Text = TicketID;
        }

        private void DataStore()
        {
            // MessageBox.Show("EmployeeID: " + this.employeeID + "this.selectedRoute: " + this.selectedRoute);
            if (string.IsNullOrWhiteSpace(this.selectedRoute))
            {
                MessageBox.Show("NULL");
                return;
            }
            // MessageBox.Show("this.selectedRoute: " + this.selectedRoute);


            // Corrected line to set the Text property of route_button
            route_button.Text = this.selectedRoute;

            string flag = route_button.Text;
            MessageBox.Show("flag: " + flag);
            MessageBox.Show("flag: " + this.selectedRoute);

        }



        private string GetFormattedTime()
        {
            // Parse the input strings to integers
            int hourInt = int.Parse(hour_combo_box.Text);
            int minuteInt = int.Parse(minute_combo_box.Text);
            int secondInt = int.Parse(second_combo_box.Text);


            // Create a TimeSpan object representing the departure time
            TimeSpan departureTimeSpan = new TimeSpan(hourInt, minuteInt, secondInt);

            // Format the TimeSpan as "hh:mm:ss"

            return (departureTimeSpan.ToString(@"hh\:mm\:ss"));
        }


        private void NextButton()
        {
            route_button.ResetText();
            string s = this.selectedRoute;
            route_button.Text = s;
            DateTime selectedDate = calendar.Value;
            string date = selectedDate.ToString("yyyy-MM-dd");
            string time = GetFormattedTime();

            string ticketPrice = ticket_price1_tb.Text;
            string sleepingSeatPrice = string.Empty;


            int startIndex = this.selectedRoute.IndexOf("(") + 1;
            int endIndex = this.selectedRoute.IndexOf(")");
            string route = this.selectedRoute.Substring(startIndex, endIndex - startIndex);

            if (SelectedBusType == "Double Decker")
            {
                double_decker_price_panel.Visible = true;
                sleepingSeatPrice = ticket_price2_tb.Text;

                if (string.IsNullOrEmpty(sleepingSeatPrice))
                {
                    MessageBox.Show("Fill al fields");
                    return;
                }
            }

            if (IsInputValid(time, date, route, ticketPrice, SelectedBusType))
            {
                if (SelectedBusType == "Double Decker")
                {
                    if (!EmployeeForm.Instance.EmployeePanelContainer.Controls.ContainsKey("TicketAssignmentInformation"))
                    {
                        Equipment equipment = new Equipment();
                        EmployeeForm.Instance.EmployeePanelContainer.Controls.Clear();
                        TicketAssignmentInformation ticketAssignmentInformation = new TicketAssignmentInformation(this.employeeID, TicketID, SelectedBusNumber, SelectedBusType, ticketPrice, this.selectedRoute, this.from, date, time);
                        ticketAssignmentInformation.Dock = DockStyle.Fill;
                        EmployeeForm.Instance.EmployeePanelContainer.Controls.Add(ticketAssignmentInformation);
                    }
                }

                else if (SelectedBusType == "Economic Bus")
                {
                    if (!EmployeeForm.Instance.EmployeePanelContainer.Controls.ContainsKey("TicketAssignmentInformation"))
                    {
                        Equipment equipment = new Equipment();
                        EmployeeForm.Instance.EmployeePanelContainer.Controls.Clear();
                        TicketAssignmentInformation ticketAssignmentInformation = new TicketAssignmentInformation(this.employeeID, TicketID, SelectedBusNumber, SelectedBusType, ticketPrice, sleepingSeatPrice, this.selectedRoute, this.from, date, time);
                        ticketAssignmentInformation.Dock = DockStyle.Fill;
                        EmployeeForm.Instance.EmployeePanelContainer.Controls.Add(ticketAssignmentInformation);
                    }
                }


                else if (SelectedBusType == "Economic AC" || SelectedBusType == "Economic Non AC")
                {

                }

                else if (SelectedBusType == "Sleeping Coach")
                {

                }

                else if (SelectedBusType == "Business Class")
                {

                }

                else
                    MessageBox.Show("Class name is Create ticket function name is Next and selected bus type " + SelectedBusType + " is not match");
            }
        }

        private void PopulateComboBox()
        {
            try
            {
                DataBase dataBase = new DataBase();
                using (SqlConnection connection = new SqlConnection(dataBase.connectionString))
                {
                    connection.Open();
                    string query = @"SELECT 
                                        b.[Bus Number], b.[Bus Type], b.[Bus Name], wzb.[Date], wzb.[Time]
                                     FROM 
                                        [Bus Information] b, [Waiting Zone Bus] wzb
                                    WHERE 
                                        b.[Bus Number] = wzb.[Bus Number]
                                    ORDER BY 
                                        wzb.Date ASC, wzb.Time ASC";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                DateTime date = Convert.ToDateTime(reader["Date"]);
                                TimeSpan time = TimeSpan.Parse(reader["Time"].ToString()); // Use TimeSpan.Parse to convert to TimeSpan
                                string busName = reader["Bus Name"].ToString();
                                string busNumber = reader["Bus Number"].ToString();
                                string busType = reader["Bus Type"].ToString();
                                string displayText = $"{busName} - {busNumber} ({busType} - {date.ToShortDateString()} {time})";

                                comboBoxBuses.Items.Add(displayText);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Class is Create Ticket and function is PopulateComboBox: " + ex.Message);
            }
        }

        private void comboBoxBuses_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxBuses.SelectedIndex != -1)
            {
                string selectedItem = comboBoxBuses.SelectedItem.ToString();
                // Parsing the selected bus number and type from the display text
                SelectedBusNumber = selectedItem.Split('-')[1].Trim();
                SelectedBusType = selectedItem.Split('(')[1].Split('-')[0].Trim();
            }

            else
            {
                MessageBox.Show("Please select a bus from the list.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private bool IsInputValid(params string[] inputs)
        {
            foreach (string input in inputs)
            {
                if (string.IsNullOrEmpty(input))
                {
                    MessageBox.Show("Fill all fields");
                    return false;
                }
            }
            return true;
        }

        private void metroTextBox2_Click(object sender, EventArgs e)
        {

        }

        private void date_tb_Click(object sender, EventArgs e)
        {

        }

        private void route_button_Click(object sender, EventArgs e)
        {
            RouteSelection routeSelection = new RouteSelection(this.employeeID);
            routeSelection.ShowDialog();
        }

        private void next_button_Click(object sender, EventArgs e)
        {
            NextButton();
        }

        private void calendar_ValueChanged(object sender, EventArgs e)
        {
            date_tb.Text = calendar.Value.Date.ToString("dd/MM/yyyy");
        }

        private void date_tb_Leave(object sender, EventArgs e)
        {
            DateTime? date = DateFormat(date_tb.Text); // Note the DateTime? (nullable DateTime)

            if (date != null)
            {
                calendar.Value = date.Value; // Set the calendar's value if date is not null
            }
        }


        private DateTime? DateFormat(string date)
        {
            string format = "dd/MM/yyyy"; // Specify the expected date format
            try
            {
                return DateTime.ParseExact(date, format, CultureInfo.InvariantCulture);
            }

            catch (FormatException)
            {
                // Parsing failed
                MessageBox.Show("Invalid date format. Please enter a valid date in the format dd/MM/yyyy.");
                return null; // Return null when parsing fails
            }
        }
    }
}
