using System;
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
using ZXing;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace VOVO
{
    public partial class CustomerTicketSearchingResult : Form
    {
        private string CustomerID { set; get; }
        private string CustomerName { set; get; }
        private string CustomerEmail { set; get; }
        private string CustomerPhoneNumber { set; get; }
        private string From { set; get; }
        private string To { set; get; }
        private string Date { set; get; }

        private int totalAdvatagementPic = 0;

        private Image[] image;

        public CustomerTicketSearchingResult()
        {
            InitializeComponent();
            FormControlsUtility.ConfigureFormResize(this);
        }

   

        public CustomerTicketSearchingResult(string customerID, string customerName, string customerEmail, string customerPhoneNumber, string from, string to, string date) : this() 
        {
            CustomerID = customerID;
            CustomerName = customerName;
            CustomerEmail = customerEmail;
            CustomerPhoneNumber = customerPhoneNumber;
            From = from;
            To = to;
            Date = date;

            AdvatagementPic();
            TimerUpadate();
            Design();
            DataShow();
        }

        void AdvatagementPic()
        {
            try
            {
                DataBase dataBase = new DataBase();
                using (SqlConnection connection = new SqlConnection(dataBase.connectionString))
                {
                    string queryCount = @"SELECT 
                                            COUNT(*) 
                                        FROM 
                                            [Advatagement Information]";

                    string queryImages = @"SELECT 
                                                Advantagement 
                                            FROM 
                                                [Advatagement Information]";

                    connection.Open();

                    using (SqlCommand countCommand = new SqlCommand(queryCount, connection))
                    {
                        totalAdvatagementPic = (int)countCommand.ExecuteScalar();
                    }

                    using (SqlCommand imageCommand = new SqlCommand(queryImages, connection))
                    {
                        using (SqlDataReader reader = imageCommand.ExecuteReader())
                        {
                            int i = 0;
                            while (reader.Read() && i < totalAdvatagementPic)
                            {
                                byte[] imageBytes = (byte[])reader["Advantagement"]; // Assuming Advantagement column stores the image bytes
                                image[i] = ImageFromBytes(imageBytes);
                                i++;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Class name is CustomerTicketSearchingResult function name is AdvatagementPic and exception: {ex.Message}");
            }
        }

        Image ImageFromBytes(byte[] bytes)
        {
            using (MemoryStream memoryStream = new MemoryStream(bytes))
            {
                return Image.FromStream(memoryStream);
            }
        }

        private void CustomerTicketSearchingResult_Load(object sender, EventArgs e)
        {
            timer.Start();
        }


        private int time = 0;
        private void timer_Tick(object sender, EventArgs e)
        {
            time++;  
        }

        private void TimerUpadate()
        {
            int cycle = totalAdvatagementPic * 5;

            for (int i = 0; i < totalAdvatagementPic - 1; )
            {
                int step = (i + 1) * 5;
                
                if (time == step)
                {
                    i++;
                }
                if (i == (totalAdvatagementPic - 1))
                {
                    i = 0;
                }

                if(time == cycle)
                {
                    time = 0;
                }

                if(i == (totalAdvatagementPic -2))
                {
                    ShowAdvatagement(image[i], image[i+1], image[0]);
                }

                else if(i == (totalAdvatagementPic - 3))
                {
                    ShowAdvatagement(image[i], image[0], image[1]);
                }

                else
                {
                    ShowAdvatagement(image[i], image[i + 1], image[i + 2]);
                }
            }
        }

        private void ShowAdvatagement(Image image1, Image image2, Image image3)
        {
            pictureBox1.Image = image1;
            pictureBox2.Image = image2;
            pictureBox3.Image = image3;
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
            routeLabel.Text = "Route: " + From + " - " + To;
            routeLabel.Width = 360;
            routeLabel.Height = 20;
            routeLabel.Location = new Point(120, 70);
            routeLabel.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Regular); // Set the font size
            panel2.Controls.Add(routeLabel);

            Label date = new Label();
            date.Text = Date.ToString();
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

            System.Windows.Forms.Button viewSeatsButton = new System.Windows.Forms.Button();
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

                    string query = "SELECT " +
                                        "Bus.[Company Name] AS CompanyName, " +
                                        "Bus.[Name] BusName, " +
                                        "Bus.[Type] AS BusType, " +
                                        "Bus.[Total Seats] AS TotalSeats, " +
                                        "Route.[Departure Stop City] AS FromCity, " +
                                        "Route.[Arival Stop City] AS ToCity, " +
                                        "Ticket.[ID] AS TicketID, " +
                                        "Ticket.[Departure Time] AS DeptTime, " +
                                        "COUNT(Ticket.[ID]) AS UnsoldCount " +
                                        "Ticket.[Price] AS TIcketPrice, " +
                                    "FROM " +
                                        "[Bus Information] AS Bus " +
                                    "INNER JOIN " +
                                        "[Ticket Information] AS Ticket ON Bus.Number = Ticket.[Bus number] " +
                                    "INNER JOIN " +
                                        "[Route Information] AS Route ON Ticket.[Route ID] = Route.ID " +
                                    "WHERE " +
                                        "Route.[Departure Stop City] = @From OR " +
                                        "Route.[Arival Stop City]] = @To AND " +
                                        "Route.[Departure Stop City] = @To OR " +
                                        "Route.[Arival Stop City]] = @From AND" +
                                        "CONVERT(DATE, Ticket.[date]) = @Date AND " +
                                        "Ticket.Sold = 'Unsold' " +
                                    "GROUP BY " +
                                        "Bus.[Company Name], " +
                                        "Bus.[Type], " +
                                        "Bus.[Total Seats], " +
                                        "Route.[Departure Stop City], " +
                                        "Route.[Arival Stop City], " +
                                        "Ticket.[Departure Time] " +
                                        "Ticket.[Price]";


                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@From", From);
                        command.Parameters.AddWithValue("@To", To);
                        command.Parameters.AddWithValue("@Date", Date);

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
                            System.Windows.Forms.Button viewSeatsButton = pair.Button;
                            panel.Dock = DockStyle.Top;
                            //panel.Tag = new CustomerData { Name = name, PhoneNumber = phoneNumber, Email = email }; // Store the data in the Tag property
                            result_showing_panel.Controls.Add(panel);

                            viewSeatsButton.Tag = new BusTypeTicketID_Tag { BusType = busType, ComapanyName = companyName, TicketID = ticketID };
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
                MessageBox.Show("Class name is CustomerTicketSearchingResult function name is  DataShow() ans exception is " + ex.Message);
            }
        }

        private void ViewSeatsButton_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Button viewSeatsButton = (System.Windows.Forms.Button)sender;
            BusTypeTicketID_Tag tag = (BusTypeTicketID_Tag)viewSeatsButton.Tag;

            string BusType = tag.BusType;
            string TicketID = tag.TicketID;
            string BusCompanyName = tag.ComapanyName;
            if (BusType == "Economic Class AC" || BusType == "Economic Class NON-AC")
            {


                // Use the ticketId as needed
                // For example, you can pass it to another form or function
                // or use it in any way required.

                // Example of passing ticketId to another form:
                using (EconomicBusDialog economyBus = new EconomicBusDialog(CustomerID, CustomerName, CustomerEmail, CustomerPhoneNumber, From, To, Date, BusCompanyName, TicketID))
                {
                    DialogResult result = economyBus.ShowDialog();

                    if (result == DialogResult.OK)
                    {
                        this.Close();
                    }
                }

            }

            
            else if (BusType == "Business Class")
            {
                // Example of passing ticketId to another form:
                using (BusinessClassBusDialog businessClassBus = new BusinessClassBusDialog(CustomerID, CustomerName, CustomerEmail, CustomerPhoneNumber, From, To, Date, BusCompanyName, TicketID))
                {
                    DialogResult result = businessClassBus.ShowDialog();

                    if (result == DialogResult.OK)
                    {
                        this.Close();
                    }
                }
            }

            else if (BusType == "Double Decker")
            {
                // Example of passing ticketId to another form:
                using (DoubleDeckerBusDialog doubleDeckerBusDialog = new DoubleDeckerBusDialog(CustomerID, CustomerName, CustomerEmail, CustomerPhoneNumber, From, To, Date, BusCompanyName, TicketID))
                {
                    DialogResult result = doubleDeckerBusDialog.ShowDialog();

                    if (result == DialogResult.OK)
                    {
                        this.Close();
                    }
                }
            }

            else if (BusType == "Sleeper Coach")
            {
                // Example of passing ticketId to another form:
                using (SleeperCoachBusDialog sleeperCoach = new SleeperCoachBusDialog(CustomerID, CustomerName, CustomerEmail, CustomerPhoneNumber, From, To, Date, BusCompanyName, TicketID))
                {
                    DialogResult result = sleeperCoach.ShowDialog();

                    if (result == DialogResult.OK)
                    {
                        this.Close();
                    }
                }
            }
        
            
        }

        private void CustomerTicketSearchingResult_SizeChanged(object sender, EventArgs e)
        {
            FormControlsUtility.ConfigureFormResize(this);
        }
    }
}
