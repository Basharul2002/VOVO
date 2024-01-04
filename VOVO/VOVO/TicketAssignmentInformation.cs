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

namespace VOVO
{
    public partial class TicketAssignmentInformation : UserControl
    {
        string driverID, conductorID, supervisorID;

        private string EmployeeID { set; get; }
        private string TicketID { set; get; }
        private string BusType { set; get; }
        private string BusNumber { set; get; }
        private string TicketPrice { set; get; }
        private string SleepingSeatPrice { set; get; }
        private string RouteID { set; get; }
        private string From { set; get; }
        private string Date { set; get; }
        private string Time { set; get; }

        public TicketAssignmentInformation()
        {
            InitializeComponent();
        }


        public TicketAssignmentInformation(string employeeID, string ticketID, string busNumber, string busType, string ticketPrice,
            string routeID, string from, string date, string time)
        {
            InitializeComponent();
            EmployeeID = employeeID;
            TicketID = ticketID;
            BusNumber = busNumber;
            BusType = busType;
            TicketPrice = ticketPrice;
            RouteID = routeID;
            Date = date;
            Time = time;
        }

        public TicketAssignmentInformation(string employeeID, string ticketID, string busNumber, string busType, string ticketPrice,
            string sleepingSeatPrice, string routeID, string from, string date, string time)
        {
            InitializeComponent();
            EmployeeID = employeeID;
            TicketID = ticketID;
            BusNumber = busNumber;
            BusType = busType;
            TicketPrice = ticketPrice;
            SleepingSeatPrice = sleepingSeatPrice;
            RouteID = routeID;
            From = from;
            Date = date;
            Time = time;
        }


        private void CreateBusTicket(SqlConnection connection)
        {
            try
            {

                string ticketQuery = "INSERT INTO [Ticket Information] ([Ticket ID], [Bus Number], [Seat Number], [Price], [Departure], [Arrival], [Departure Date], [Departure Time], [Sold], [Buyer ID], [Employee ID]) " +
                                     "VALUES (@TicketID, @BusNumber, @SeatNumber, @Price, @Departure, @Arrival, @DepartureDate, @DepartureTime, @Sold, @BuyerID, @EmployeeID)";

                using (SqlCommand ticketCommand = new SqlCommand(ticketQuery, connection))  // Iterate through each seat for the selected bus type
                {
                    foreach (var seat in GetSeatsForBusType(BusType))
                    {
                        string seatPrice = seat == "X" ? SleepingSeatPrice : TicketPrice;  // Check if the current seat is seat "X", and adjust the seat price accordingly

                        ticketCommand.Parameters.Clear();
                        ticketCommand.Parameters.AddWithValue("@TicketID", TicketID);
                        ticketCommand.Parameters.AddWithValue("@BusNumber", BusNumber);
                        ticketCommand.Parameters.AddWithValue("@SeatNumber", seat);
                        ticketCommand.Parameters.AddWithValue("@Price", TicketPrice);
                        ticketCommand.Parameters.AddWithValue("@RouteID", @RouteID);
                        ticketCommand.Parameters.AddWithValue("@DepartureDate", Date);
                        ticketCommand.Parameters.AddWithValue("@DepartureTime", Time);
                        ticketCommand.Parameters.AddWithValue("@Sold", "Unsold");
                        ticketCommand.Parameters.AddWithValue("@BuyerID", DBNull.Value);
                        ticketCommand.Parameters.AddWithValue("@EmployeeID", EmployeeID);
                        ticketCommand.ExecuteNonQuery();
                    }
                }

            }
            catch (Exception ex)
            {
                CustomMessageBox.Show("Class Name is TicketAssignmentInformation and fuction Name is CreateBusTicket: " + ex.Message);
            }
        }


        private List<string> GetSeatsForBusType(string busType)
        {
            List<string> seats = new List<string>();

            if (busType == "Economic Bus AC" || busType == "Economic Bus Non AC")
            {
                for (char ch = 'A'; ch <= 'L'; ch++)
                {
                    for (int j = 1; j <= 4; j++)
                    {
                        seats.Add(ch.ToString() + j.ToString());
                    }
                }
            }
            else if (busType == "Business Class")
            {
                for (char ch = 'A'; ch <= 'L'; ch++)
                {
                    for (int j = 1; j <= 3; j++)
                    {
                        seats.Add(ch.ToString() + j.ToString());
                    }
                }
            }
            else if (busType == "Double Decker")
            {
                for (char ch = 'A'; ch <= 'O'; ch++)
                {
                    for (int j = 1; j <= 3; j++)
                    {
                        if (!((ch == 'A' || ch == 'E' || ch == 'F') && j == 1))  // Add the seat (represented by concatenating character 'ch' and integer 'j') to the 'seats' list only if 'ch' is not 'A', 'E', or ('F' and j == 1)
                        {
                            seats.Add(ch.ToString() + j.ToString());
                        }
                    }
                }
                seats.Add("X");
                seats.Add("S1");
            }
            else if (busType == "Sleeper Coach")
            {
                for (char ch = 'A'; ch <= 'J'; ch++)
                {
                    for (int j = 1; j <= 3; j++)
                    {
                        seats.Add(ch.ToString() + j.ToString());
                    }
                }
            }

            return seats;
        }

        private void TicketAssignmentInformation_Load(object sender, EventArgs e)
        {

        }

        private void TicketAssignmentInformationInDataBase(SqlConnection connection)
        {
            try
            {
                string query = "INSERT INTO  [Ticket Assignment Information] ([Ticket Number], [Supervisor ID], [Driver ID], [Conductor ID]" +
                                "VALUES(@TicketNumber, @SupervisorID, @DriverID, @ConductorID)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@TicketNumber", TicketID);
                    command.Parameters.AddWithValue("@SupervisorID", supervisorID);
                    command.Parameters.AddWithValue("@DriverID", driverID);
                    command.Parameters.AddWithValue("@ConductorID", conductorID);

                    command.ExecuteNonQuery();
                }
            }

            catch(Exception ex)
            {
                CustomMessageBox.Show("Class Name is TicketAssignmentInformation and fuction Name is TicketAssignmentInformationInDataBase: " + ex.Message);
            }
        }
        private void register_button_Click(object sender, EventArgs e)
        {

            string driverID = driver_combo_box.Text;
            string conductorID = conductor_combo_box.Text;
            string supervisorID = superviosr_combo_box.Text;

            if(string.IsNullOrEmpty(driverID) || string.IsNullOrEmpty(conductorID) || string.IsNullOrEmpty(supervisorID))
            {
                CustomMessageBox.Show("Choose Driver, Conductor and Supervisor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else
            {
                DataBase dataBase = new DataBase();

                using (SqlConnection connection = new SqlConnection(dataBase.connectionString))
                {
                    connection.Open();
                    CreateBusTicket(connection);
                    TicketAssignmentInformationInDataBase(connection);
                    connection.Close();
                }
            }
            
        }
    }
}
