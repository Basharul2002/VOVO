using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VOVO
{
    public partial class TicketCustomer : Form
    {
        private string customerID, from, to, date;


        public TicketCustomer()
        {
            InitializeComponent();
            FormControlsUtility.ConfigureFormResize(this);
        }

       

        public TicketCustomer(string customerID, string from, string to, string date) : this()
        {
            this.customerID = customerID;
            this.from = from;
            this.to = to;
            this.date = date;

            // DateTime = equipment.convertDateFormat(dateTime.ToString());

            Design();
            DataShow();
        }


        private void Design()
        {
            this.Controls.Clear();

            Panel panel1 = new Panel();
            panel1.Dock = DockStyle.Top;

            Panel panel2 = new Panel();
            panel2.Dock = DockStyle.Top;

            PictureBox picture = new PictureBox();
            picture.Width = 100;
            picture.Height = 50;
            picture.Location = new Point(24, 25);
            picture.Image = VOVO.Properties.Resources.Customer;
            picture.SizeMode = PictureBoxSizeMode.CenterImage;

            Label routeLabel = new Label();
            routeLabel.Text = "Route: " + this.from + " - " + this.to;
            routeLabel.Width = 360;
            routeLabel.Height = 20;
            routeLabel.Location = new Point(120, 70);
            routeLabel.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Regular); // Set the font size
            panel2.Controls.Add(routeLabel);

            Label date = new Label();
            date.Text = (this.date).ToString();
            date.Width = 102;
            date.Height = 20;
            date.Location = new Point(120, 50);
            panel2.Controls.Add(date);
        }

        private CustomerBusTicketPanelButtonPair addPanel(string companyName, string busName, string busType, int totalSeats, string PassengerFrom, string PassengerTo, string deptTime, int unsoldCount, int ticketPrice)
        {
            Panel panel = new Panel();
            panel.Dock = DockStyle.Top;
            panel.Width = 560;
            panel.Height = 107;
            panel.BackColor = Color.Gainsboro;
            panel.BorderStyle = BorderStyle.FixedSingle;
            panel.Padding = new Padding(1); // Optional: Add padding to adjust the border thickness

            TableLayoutPanel tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel1.Dock = DockStyle.Top;
            tableLayoutPanel1.ColumnCount = 4;
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 40F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));


            panel1.Dock = DockStyle.Top;
            panel.Controls.Add(panel1);

            Label operatorLabel = new Label();
            operatorLabel.Text = "Operator";
            operatorLabel.TextAlign = ContentAlignment.MiddleCenter;
            operatorLabel.Dock = DockStyle.Fill;
            tableLayoutPanel1.Controls.Add(operatorLabel, 0, 0);

            Label deptTimeLabel = new Label();
            deptTimeLabel.Text = "Dept. Time";
            deptTimeLabel.TextAlign = ContentAlignment.MiddleCenter;
            deptTimeLabel.Dock = DockStyle.Fill;
            tableLayoutPanel1.Controls.Add(deptTimeLabel, 1, 0);

            Label seatsAvailableLabel = new Label();
            seatsAvailableLabel.Text = "Seats Available";
            seatsAvailableLabel.TextAlign = ContentAlignment.MiddleCenter;
            seatsAvailableLabel.Dock = DockStyle.Fill;
            tableLayoutPanel1.Controls.Add(seatsAvailableLabel, 2, 0);

            Label fareLabel = new Label();
            fareLabel.Text = "Fare";
            fareLabel.TextAlign = ContentAlignment.MiddleCenter;
            fareLabel.Dock = DockStyle.Fill;
            tableLayoutPanel1.Controls.Add(fareLabel, 3, 0);

            TableLayoutPanel tableLayoutPanel2 = new TableLayoutPanel();
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.RowCount = 4;
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 1);

            Label companyNameLabel = new Label();
            companyNameLabel.Text = companyName;
            companyNameLabel.TextAlign = ContentAlignment.MiddleCenter;
            companyNameLabel.Dock = DockStyle.Fill;
            tableLayoutPanel2.Controls.Add(companyNameLabel, 0, 0);

            Label busNameLabel = new Label();
            busNameLabel.Text = busName;
            busNameLabel.TextAlign = ContentAlignment.MiddleCenter;
            busNameLabel.Dock = DockStyle.Fill;
            tableLayoutPanel2.Controls.Add(busNameLabel, 0, 1);

            Label startingPointLabel = new Label();
            startingPointLabel.Text = PassengerFrom;
            startingPointLabel.TextAlign = ContentAlignment.MiddleCenter;
            startingPointLabel.Dock = DockStyle.Fill;
            tableLayoutPanel2.Controls.Add(startingPointLabel, 0, 2);

            Label endingPointLabel = new Label();
            endingPointLabel.Text = PassengerTo;
            endingPointLabel.TextAlign = ContentAlignment.MiddleCenter;
            endingPointLabel.Dock = DockStyle.Fill;
            tableLayoutPanel2.Controls.Add(endingPointLabel, 0, 3);

            Label deptTimeLabelData = new Label();
            deptTimeLabelData.Text = deptTime;
            deptTimeLabelData.TextAlign = ContentAlignment.MiddleCenter;
            deptTimeLabelData.Dock = DockStyle.Fill;
            tableLayoutPanel1.Controls.Add(deptTimeLabelData, 1, 1);


            Label seatsAvailableDataLabel = new Label();
            seatsAvailableDataLabel.Text = unsoldCount.ToString();
            seatsAvailableDataLabel.TextAlign = ContentAlignment.MiddleCenter;
            seatsAvailableDataLabel.Dock = DockStyle.Fill;
            tableLayoutPanel1.Controls.Add(seatsAvailableDataLabel, 1, 2);


            Label fareDataLabel = new Label();
            fareDataLabel.Text = ticketPrice.ToString();
            fareDataLabel.TextAlign = ContentAlignment.MiddleCenter;
            fareDataLabel.Dock = DockStyle.Fill;
            tableLayoutPanel1.Controls.Add(fareDataLabel, 1, 3);



            TableLayoutPanel tableLayoutPanel3 = new TableLayoutPanel();
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.ColumnCount = 6;
            tableLayoutPanel3.RowCount = 1;

            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 15F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 15F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 15F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 15F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 33F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 17F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            panel.Controls.Add(tableLayoutPanel3);

            LinkLabel cancellationPolicylabel = new LinkLabel();
            cancellationPolicylabel.Text = "Cancellation Policy";
            cancellationPolicylabel.LinkColor = Color.Coral;
            cancellationPolicylabel.Dock = DockStyle.Fill;
            tableLayoutPanel3.Controls.Add(cancellationPolicylabel, 0, 0);

            LinkLabel boardingPointLabel = new LinkLabel();
            boardingPointLabel.Text = "Boarding Point";
            boardingPointLabel.LinkColor = Color.Coral;
            boardingPointLabel.Dock = DockStyle.Fill;
            tableLayoutPanel3.Controls.Add(boardingPointLabel, 1, 0);

            LinkLabel dropingPointLabel = new LinkLabel();
            dropingPointLabel.Text = "Droping Point";
            dropingPointLabel.LinkColor = Color.Coral;
            dropingPointLabel.Dock = DockStyle.Fill;
            tableLayoutPanel3.Controls.Add(dropingPointLabel, 2, 0);

            LinkLabel facilitiesLabel = new LinkLabel();
            facilitiesLabel.Text = "Facilities";
            facilitiesLabel.LinkColor = Color.Coral;
            facilitiesLabel.Dock = DockStyle.Fill;
            tableLayoutPanel3.Controls.Add(facilitiesLabel, 3, 0);

            Button viewSeatsButton = new Button();
            viewSeatsButton.Dock = DockStyle.Fill;
            viewSeatsButton.Text = "View Seat";
            viewSeatsButton.BackColor = Color.Coral;
            viewSeatsButton.ForeColor = Color.White;
            viewSeatsButton.Font = new Font("Montserrat", 12, FontStyle.Regular); // Set the font size
            tableLayoutPanel3.Controls.Add(viewSeatsButton, 5, 0);


            // Create an instance of the PanelButtonPair class and set the Panel and Button properties
            CustomerBusTicketPanelButtonPair pair = new CustomerBusTicketPanelButtonPair
            {
                Panel = panel,
                Button = viewSeatsButton
            };

            return pair;

        }

        private void DataShow()
        {
            try
            {
                DataBase dataBase = new DataBase();
                using (SqlConnection connection = new SqlConnection(dataBase.connectionString))
                {
                    connection.Open();

                    string query = @"SELECT 
                                        Bus.[Company Name] AS CompanyName, 
                                        Bus.[Name] BusName, 
                                        Bus.[Type] AS BusType, 
                                        Bus.[Total Seats] AS TotalSeats, 
                                        Route.[Departure Stop City] AS FromCity, 
                                        Route.[Arival Stop City] AS ToCity, 
                                        Ticket.[ID] AS TicketID, 
                                        Ticket.[Departure Time] AS DeptTime, 
                                        COUNT(Ticket.[ID]) AS UnsoldCount 
                                        Ticket.[Price] AS TIcketPrice, 
                                   FROM 
                                        [Bus Information] AS Bus 
                                    INNER JOIN 
                                        [Ticket Information] AS Ticket ON Bus.Number = Ticket.[Bus number] 
                                    INNER JOIN 
                                        [Route Information] AS Route ON Ticket.[Route ID] = Route.ID 
                                    WHERE 
                                        Route.[Departure Stop City] = @From OR 
                                        Route.[Arival Stop City]] = @To AND 
                                        Route.[Departure Stop City] = @To OR 
                                        Route.[Arival Stop City]] = @From AND
                                        CONVERT(DATE, Ticket.[date]) = @Date AND 
                                        Ticket.Sold = 'Unsold'
                                    GROUP BY 
                                        Bus.[Company Name], 
                                        Bus.[Type], 
                                        Bus.[Total Seats], 
                                        Route.[Departure Stop City], 
                                        Route.[Arival Stop City], 
                                        Ticket.[Departure Time], 
                                        Ticket.[Price]";


                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@From", this.from);
                        command.Parameters.AddWithValue("@To", this.to);
                        command.Parameters.AddWithValue("@Date", this.date);

                        SqlDataReader reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            string companyName = reader["CompanyName"].ToString();
                            string busName = reader["BusName"].ToString();
                            string busType = reader["BusType"].ToString();
                            int totalSeats = Convert.ToInt32(reader["TotalSeats"]);
                            string fromCity = reader["FromCity"].ToString();
                            string toCity = reader["ToCity"].ToString();
                            string deptTime = reader["DeptTIme"].ToString();
                            string ticketID = reader["TicketID"].ToString();
                            int unsoldCount = Convert.ToInt32(reader["UnsoldCount"]);
                            int ticketPrice = Convert.ToInt32(reader["TicketPrice"]);

                            CustomerBusTicketPanelButtonPair pair = addPanel(companyName, busName, busType, totalSeats, fromCity, toCity, deptTime, unsoldCount, ticketPrice);
                            Panel panel = pair.Panel;
                            Button viewSeatsButton = pair.Button;
                            panel.Dock = DockStyle.Top;
                            //panel.Tag = new CustomerData { Name = name, PhoneNumber = phoneNumber, Email = email }; // Store the data in the Tag property
                            result_showing_panel.Controls.Add(panel);

                            viewSeatsButton.Tag = new BusTypeTicketID_Tag { BusType = busType, TicketID = ticketID};
                            viewSeatsButton.Click += ViewSeatsButton_Click;


                        }

                        reader.Close();
                    }

                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions that may occur during the database operation
                CustomMessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void ViewSeatsButton_Click(object sender, EventArgs e)
        {
            Button viewSeatsButton = (Button)sender;
            BusTypeTicketID_Tag tag = (BusTypeTicketID_Tag)viewSeatsButton.Tag;

            string BusType = tag.BusType;
            string TicketID = tag.TicketID;
            /*
            if (BusType == "Economic Class AC" || BusType == "Economic Class NON-AC")
            {


                // Use the ticketId as needed
                // For example, you can pass it to another form or function
                // or use it in any way required.

                // Example of passing ticketId to another form:
                using (EconomicBusDialog economyBus = new EconomicBusDialog(CustomerID, TicketID))
                {
                    DialogResult result = economyBus.ShowDialog();

                    if (result == DialogResult.OK)
                    {
                        this.Close();
                    }
                }

            }

            /*
            else if (BusType == "Business Class")
            {
                // Get the TicketID from the Tag property of the clicked button
                Button clickedButton = (Button)sender;
                string ticketId = clickedButton.Tag.ToString();

                // Use the ticketId as needed
                // For example, you can pass it to another form or function
                // or use it in any way required.

                // Example of passing ticketId to another form:
                BusinessClass businessClass = new BusinessClass(CustomerID, ticketId);
                businessClass.ShowDialog();
            }

            else if (BusType == "Double Decker")
            {
                // Get the TicketID from the Tag property of the clicked button
                Button clickedButton = (Button)sender;
                string ticketId = clickedButton.Tag.ToString();

                // Use the ticketId as needed
                // For example, you can pass it to another form or function
                // or use it in any way required.

                // Example of passing ticketId to another form:
                DoubleDeckerBus doubleDecker = new DoubleDeckerBus(CustomerID, ticketId);
                doubleDecker.ShowDialog();
            }

            else if (BusType == "Sleeper Bus")
            {
                // Get the TicketID from the Tag property of the clicked button
                Button clickedButton = (Button)sender;
                string ticketId = clickedButton.Tag.ToString();

                // Use the ticketId as needed
                // For example, you can pass it to another form or function
                // or use it in any way required.

                // Example of passing ticketId to another form:
                SleeperCoach sleeperCoach = new SleeperCoach(CustomerID, ticketId);
                sleeperCoach.ShowDialog();
            }
        }
            */
            }

        private void TicketCustomer_SizeChanged(object sender, EventArgs e)
        {
            FormControlsUtility.ConfigureFormResize(this);

        }
    }
}
