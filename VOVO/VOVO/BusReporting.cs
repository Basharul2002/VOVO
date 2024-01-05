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
using Twilio.Rest.Trunking.V1;

namespace VOVO
{
    public partial class BusReporting : UserControl
    {
        private string selectedTravelID, reportingID, busNumber, supervisorID, driverID, conductorID, branchID;
        private int totalTravel = 0;
        private string employeeID;
        public BusReporting()
        {
            InitializeComponent();
        }

        public BusReporting(string employeeID) : this()
        {
            this.employeeID = employeeID;
            DataBaseData();
        }

        private void DataBaseData()
        {
            Equipment equipment = new Equipment();
            reportingID = equipment.idGenarator("Bus Reporting");
            reporting_id_tb.Text = reportingID;
            DataBase dataBase = new DataBase();
            using (SqlConnection connection = new SqlConnection(dataBase.connectionString))
            {
                connection.Open();
                TicketNumberComboBoxData(connection);
                if (this.selectedTravelID != "-1" && totalTravel != 0)
                    TicketAssignment(connection);

            }
        }

        private void TicketNumberComboBoxData(SqlConnection connection)
        {
            try
            {
                string query = "SELECT [Travel Number] " +
                                "FROM [Travel Information] " +
                                "WHERE  Date >= DATEADD(DAY, -2, GETDATE())";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string ticketNumber = reader["Travel Number"].ToString();
                            ticket_number_combo_box.Items.Add(ticketNumber);
                            totalTravel++;
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Class is BusReporting and function is TicketNumberComboBoxData: " + ex.Message);
            }
        }

        private void ticket_number_combo_box_SelectedIndexChanged(object sender, EventArgs e)
        {


            if (ticket_number_combo_box.SelectedIndex != -1) // Check if an item is selected
            {
                this.selectedTravelID = ticket_number_combo_box.SelectedItem.ToString();
            }
            else
            {
                this.selectedTravelID = "-1";
                MessageBox.Show("Please select ticket number");
            }
        }


        private void TicketAssignment(SqlConnection connection)
        {
            try
            {
                string query = "SELECT [Travel Number], [Supervisor ID], [Driver ID], [Conductor ID] " +
                               "FROM [Travel Number] " +
                               "WHERE [Travel Number] = @TicketNumber";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@TicketNumber", this.selectedTravelID);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            busNumber = reader["Bus Number"].ToString();
                            supervisorID = reader["Supervisor ID"].ToString();
                            driverID = reader["Driver ID"].ToString();
                            conductorID = reader["Conductor ID"].ToString();

                            DataShow();
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Class is BusReporting and function is TicketAssignment: " + ex.Message);
            }
        }

        private void DataShow()
        {
            bus_number_tb.Text = busNumber;
            supervisor_id_tb.Text = supervisorID;
            driver_id_tb.Text = driverID;
            conductor_id_tb.Text = conductorID;
        }

        private void EmployeeOffice(SqlConnection connection)
        {
            try
            {
                string query = "SELECT [Brunch ID] FROM [Employee Login Information] WHERE [Employee ID] = @EmployeeID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@EmployeeID", this.employeeID);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Check if there are any rows before trying to read
                        if (reader.HasRows)
                        {
                            reader.Read(); // Read the first row

                            branchID = reader["Brunch ID"].ToString();
                        }
                        else
                        {
                            // Handle the case where no data is present
                            branchID = "No Data Found";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Class name is BusReporting function name is EmployeeOffice and exception: " + ex.Message);
            }
        }
        private void Register()
        {
            Equipment equipment = new Equipment();
            DataBase dataBase = new DataBase();

            using (SqlConnection connection = new SqlConnection(dataBase.connectionString))
            {
                connection.Open();
                EmployeeOffice(connection);
                Reporting(connection, equipment);
                BusWating(connection, equipment);
                DriverWating(connection, equipment);
                ConductorWating(connection, equipment);
                SupervisorWating(connection, equipment);

                connection.Close();
            }

        }

        private void Reporting(SqlConnection connection, Equipment equipment)
        {
            if (string.IsNullOrWhiteSpace(this.selectedTravelID))
            {
                this.selectedTravelID = null; // Now selectedTicketID is nullable
            }

            try
            {
                string query = "INSERT INTO [Bus Reporting Information] ([Reporting ID], [Travel Number], [Supervisor ID], [Driver ID], [Conductor ID], [Branch ID], [Date], [Time]) " +
                               "VALUES(@ReportingID, @TravelNumber, @SupervisorID, @DriverID, @ConductorID, @BranchID, @Date, @Time)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@ReportingID", reportingID);
                    command.Parameters.AddWithValue("@TravelNumber", string.IsNullOrWhiteSpace(this.selectedTravelID) ? (object)DBNull.Value : this.selectedTravelID);
                    command.Parameters.AddWithValue("@SupervisorID", supervisorID); // Make sure supervisorID is not null here
                    command.Parameters.AddWithValue("@DriverID", driverID);
                    command.Parameters.AddWithValue("@ConductorID", conductorID);
                    command.Parameters.AddWithValue("@BranchID", branchID);
                    command.Parameters.AddWithValue("@Date", equipment.DataBaseFormatDate(equipment.TodayDate()));
                    command.Parameters.AddWithValue("@Time", equipment.Time());

                    command.ExecuteNonQuery();
                }

                MessageBox.Show("Reported Successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Class is BusReporting and function is Reporting: " + ex.Message);
            }
        }

        private void BusWating(SqlConnection connection, Equipment equipment)
        {
            try
            {
                string query = "INSERT INTO [Waiting Zone Bus] ([Bus Number], [Branch ID], [Date], Time) " +
                                "VALUES(@BusNumber, @BrunchID, @Date, @Time)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@BusNumber", busNumber);
                    command.Parameters.AddWithValue("@BrunchID", branchID);
                    command.Parameters.AddWithValue("@Date", equipment.DataBaseFormatDate(equipment.TodayDate()));
                    command.Parameters.AddWithValue("@Time", equipment.Time());

                    command.ExecuteNonQuery();
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Class name is BusReporting function name is Bus Wating and exception: " + ex.Message);
            }
        }

        private void DriverWating(SqlConnection connection, Equipment equipment)
        {
            try
            {
                string query = "INSERT INTO [Waiting Zone Driver] ([Driver ID], [Branch ID], [Date], Time) " +
                                "VALUES(@DriverID, @BrunchID, @Date, @Time)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@DriverID", driverID);
                    command.Parameters.AddWithValue("@BrunchID", branchID);
                    command.Parameters.AddWithValue("@Date", equipment.DataBaseFormatDate(equipment.TodayDate()));
                    command.Parameters.AddWithValue("@Time", equipment.Time());

                    command.ExecuteNonQuery();
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Class name is BusReporting function name is DriverWating and exception: " + ex.Message);
            }
        }

        private void ConductorWating(SqlConnection connection, Equipment equipment)
        {
            try
            {
                string query = "INSERT INTO [Waiting Zone Conductor] ([Conductor ID], [Branch ID], [Date], Time) " +
                                "VALUES(@ConductorID, @BrunchID, @Date, @Time)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@ConductorID", conductorID);
                    command.Parameters.AddWithValue("@BrunchID", branchID);
                    command.Parameters.AddWithValue("@Date", equipment.DataBaseFormatDate(equipment.TodayDate()));
                    command.Parameters.AddWithValue("@Time", equipment.Time());

                    command.ExecuteNonQuery();
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Class name is BusReporting function name is ConductorWating and exception: " + ex.Message);
            }
        }

        private void SupervisorWating(SqlConnection connection, Equipment equipment)
        {
            try
            {
                string query = "INSERT INTO [Waiting Zone Supervisor] ([Supervisor ID], [Branch ID], [Date], Time) " +
                                "VALUES(@SupervisorID, @BrunchID, @Date, @Time)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@SupervisorID", supervisorID);
                    command.Parameters.AddWithValue("@BrunchID", branchID);
                    command.Parameters.AddWithValue("@Date", equipment.DataBaseFormatDate(equipment.TodayDate()));
                    command.Parameters.AddWithValue("@Time", equipment.Time());

                    command.ExecuteNonQuery();
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Class name is BusReporting function name is SupervisorWating and exception: " + ex.Message);
            }
        }

        private void Register_button_Click(object sender, EventArgs e)
        {
            this.reportingID = reporting_id_tb.Text;
            this.selectedTravelID = ticket_number_combo_box.Text;
            this.busNumber = bus_number_tb.Text;
            this.driverID = driver_id_tb.Text;
            this.conductorID = conductor_id_tb.Text;
            this.supervisorID = supervisor_id_tb.Text;
            Register();
        }

    }
}
