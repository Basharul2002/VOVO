using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VOVO
{
    public partial class BusinessClassBusDialog : Form
    {
        private string BusID { get; set; }
        private string BusCompanyName { get; set; }
        private string TicketID { get; set; }
        private string CustomerID { get; set; }
        private string CustomerName { get; set; }
        private string CustomerEmail { get; set; }
        private string CustomerPhoneNumber { get; set; }
        private string From { get; set; }
        private string To { get; set; }
        private string Date { get; set; }



        private int totalSelectedSeat = 0;
        private int[] TicketPrice = new int[48];
        private string price, _Class = "Business";
        private string[] seatSelected = new string[48];


        private Label[] seat = new Label[48];
        private Label[] fare = new Label[48];
        private Label[] _class = new Label[48];

        public BusinessClassBusDialog()
        {
            InitializeComponent();
            FormControlsUtility.ConfigureFormResize(this);
        }

        // Rounded Corners  
        
        public BusinessClassBusDialog(string customerID, string customerName, string customerEmail, string customerPhoneNumber, string from, string to, string date, string busCompanyName, string ticketID) : this()
        {
            TicketID = ticketID;
            CustomerID = customerID;
            CustomerName = customerName;
            CustomerEmail = customerEmail;
            CustomerPhoneNumber = customerPhoneNumber;
            From = from;
            To = to;
            Date = date;
            BusCompanyName = busCompanyName;



            ticketPrice();
            Clear();
            // UpdateSeatButtonColors();
        }


        void ticketPrice()
        {
            // Initialize the array with a value of 1000
            for (int i = 0; i < 48; i++)
            {
                TicketPrice[i] = 1000;
            }
        }

        void Clear()
        {

            seat_panel.Controls.Clear();
            fare_panel.Controls.Clear();
            class_panel.Controls.Clear();

        }


        private string ButtonName(string seatNumber)
        {
            string buttonName = seatNumber[0].ToString().ToLower() + seatNumber.Substring(1) + "_button";
            return buttonName;
        }

        private string SeatNumber(string buttonName)
        {
            string seatNumber = buttonName[0].ToString().ToUpper() + buttonName.Substring(1);
            return seatNumber;
        }

        private void UpdateSeatButtonColors()
        {
            DataBase dataBase = new DataBase();
            try
            {
                using (SqlConnection connection = new SqlConnection(dataBase.connectionString))
                {
                    connection.Open();

                    string query = "SELECT [Seat Number], Price, Status FROM [Ticket Information] WHERE [ID] = @ID";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.Clear();
                        command.Parameters.AddWithValue("@ID", TicketID);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string seatNumber = reader["Seat Number"].ToString();
                                string Price = reader["Price"].ToString();
                                bool isSeatSold = Convert.ToBoolean(reader["Status"]);


                                if (isSeatSold)
                                {
                                    SetSeatColor(seatNumber, "Sold");
                                }

                                else
                                {
                                    SetSeatColor(seatNumber, "Unsold");

                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Class name is BusinessClassBusDialog function name is UpdateSeatButtonColors" +
                    " and exception : " + ex.Message);
            }
        }

        private void SetSeatColor(string seatNumber, string status)
        {

            string buttonName = ButtonName(seatNumber);
            System.Windows.Forms.Button button = Controls.Find(buttonName, true)[0] as System.Windows.Forms.Button;


            if (button != null)
            {
                if (status == "Sold")
                {
                    button.BackColor = Color.Coral;
                }

                else if (status == "Unsold")
                {
                    button.BackColor = Color.Orange;
                }

            }
        }


        private void SelectedSeat(int totalSelectedSeat, string Seat, int Fare, string _Class)
        {
            int i = totalSelectedSeat - 1;


            int x = 25;
            int y = 5;

            if (i == 0)
            {
                seatSelected[i] = Seat;
            }

            else
            {
                seatSelected[i] = ", " + Seat;
            }

            seat[i] = new Label();
            seat[i].Font = new Font("Montserrat", 12);
            seat[i].Text = Seat;
            seat[i].Location = new Point(x, (y + (i * 20)));
            seat_panel.Controls.Add(seat[i]);


            fare[i] = new Label();
            fare[i].Font = new Font("Montserrat", 12);
            fare[i].Text = Fare.ToString();
            fare[i].Location = new Point(x, (y + (i * 20)));
            fare_panel.Controls.Add(fare[i]);


            _class[i] = new Label();
            _class[i].Font = new Font("Montserrat", 12);
            _class[i].Text = _Class;
            _class[i].Location = new Point(x, (y + (i * 20)));
            class_panel.Controls.Add(_class[i]);



            setPrice("+", Fare);

        }

        private void setPrice(string update, int Fare)
        {
            // Extract the numeric part after the colon in total_price.Text
            string totalPrice = total_price.Text.Substring(6).Trim();
            Equipment equipment = new Equipment();

            if (update == "+")
            {
                if (string.IsNullOrEmpty(totalPrice))
                {
                    total_price.Text = "Total: " + Fare.ToString();
                }

                else if (!string.IsNullOrEmpty(totalPrice))
                {
                    total_price.Text = "Total: " + (equipment.StringToInt(totalPrice) + Fare).ToString();
                }
            }



            else if (update == "-")
            {
                total_price.Text = "Total: " + (equipment.StringToInt(totalPrice) - Fare).ToString();
            }

        }





        private void j2_button_Click(object sender, EventArgs e)
        {

        }


        private void cancel_button_Click(object sender, EventArgs e)
        {

        }


        private void boarding_point_time_OnSelectedIndexChanged(object sender, EventArgs e)
        {

        }

     

        private void a1_button_Click(object sender, EventArgs e)
        {

        }

        private void b1_button_Click(object sender, EventArgs e)
        {

        }

        private void a3_button_Click(object sender, EventArgs e)
        {

        }

        private void e1_button_Click(object sender, EventArgs e)
        {

        }

        private void b3_button_Click(object sender, EventArgs e)
        {

        }

        private void c1_button_Click(object sender, EventArgs e)
        {

        }

        private void e3_button_Click(object sender, EventArgs e)
        {

        }

        private void i1_button_Click(object sender, EventArgs e)
        {

        }

        private void c3_button_Click(object sender, EventArgs e)
        {

        }

        private void f1_button_Click(object sender, EventArgs e)
        {

        }

        private void i3_button_Click(object sender, EventArgs e)
        {

        }

        private void b2_button_Click(object sender, EventArgs e)
        {

        }

        private void f3_button_Click(object sender, EventArgs e)
        {

        }

        private void j1_button_Click(object sender, EventArgs e)
        {

        }

        private void g1_button_Click(object sender, EventArgs e)
        {

        }

        private void j3_button_Click(object sender, EventArgs e)
        {

        }

        private void d1_button_Click(object sender, EventArgs e)
        {

        }

        private void g3_button_Click(object sender, EventArgs e)
        {

        }

        private void k1_button_Click(object sender, EventArgs e)
        {

        }

        private void d3_button_Click(object sender, EventArgs e)
        {

        }

        private void f2_button_Click(object sender, EventArgs e)
        {

        }

        private void k3__button_Click(object sender, EventArgs e)
        {

        }

        private void d2_button_Click(object sender, EventArgs e)
        {

        }

        private void d4_button_Click(object sender, EventArgs e)
        {

        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void j4_button_Click(object sender, EventArgs e)
        {

        }

        private void h1_button_Click(object sender, EventArgs e)
        {

        }

        private void h3_button_Click(object sender, EventArgs e)
        {

        }

        private void h2_button_Click(object sender, EventArgs e)
        {

        }

        private void h4_button_Click(object sender, EventArgs e)
        {

        }

        private void l1_button_Click(object sender, EventArgs e)
        {

        }

        private void customButton41_Click(object sender, EventArgs e)
        {

        }

        private void l2_button_Click(object sender, EventArgs e)
        {

        }

        private void l4_button_Click(object sender, EventArgs e)
        {

        }

        private void a2_button_Click(object sender, EventArgs e)
        {

        }

        private void a4_button_Click(object sender, EventArgs e)
        {

        }

        private void e2_button_Click(object sender, EventArgs e)
        {

        }

        private void i2_button_Click(object sender, EventArgs e)
        {

        }

        private void countinue_button_Click(object sender, EventArgs e)
        {

        }

        private void c2_button_Click(object sender, EventArgs e)
        {

        }

        private void g2_button_Click(object sender, EventArgs e)
        {

        }

        private void k2_button_Click(object sender, EventArgs e)
        {

        }

        private void k4_button_Click(object sender, EventArgs e)
        {

        }

        private void i4_button_Click(object sender, EventArgs e)
        {

        }

        private void b4_button_Click(object sender, EventArgs e)
        {

        }

        private void f4_button_Click(object sender, EventArgs e)
        {

        }

        private void e4_button_Click(object sender, EventArgs e)
        {

        }

        private void c4_button_Click(object sender, EventArgs e)
        {

        }

        private void g4_button_Click(object sender, EventArgs e)
        {

        }

        private void BusinessClassBusDialog_SizeChanged(object sender, EventArgs e)
        {
          FormControlsUtility.ConfigureFormResize(this);
        }


        private void UnselectData(string seatNumber, int Fare)
        {
            int unselect = 0;
            int x = 25;
            int y = 5;

            try
            {
                int i = 0;
                while (i < totalSelectedSeat)
                {
                    // Check if the seatNumber matches the text of the label
                    if (seat[i].Text == seatNumber)
                    {
                        unselect = i;
                        seat_panel.Controls.Remove(seat[i]);
                        fare_panel.Controls.Remove(fare[i]);
                        class_panel.Controls.Remove(_class[i]);


                        break; // Exit the loop after finding and removing the seat
                    }
                    i++;
                }
                if (unselect < totalSelectedSeat)
                {
                    setPrice("-", Fare);

                    for (int j = unselect; j < totalSelectedSeat - 1; i++)
                    {
                        seat[i] = seat[i + 1];
                        fare[i] = fare[i + 1];
                        _class[i] = _class[i + 1];

                        totalSelectedSeat--;
                    }


                }

                else if (unselect == totalSelectedSeat - 1)
                {
                    setPrice("-", Fare);
                    totalSelectedSeat--;
                }

                // Update the positions of the remaining labels
                for (int j = 0; j < totalSelectedSeat; j++)
                {
                    seat[j].Location = new Point(x, y + j * 20);
                    fare[j].Location = new Point(x, y + j * 20);
                    _class[j].Location = new Point(x, y + j * 20);

                }
            }



            catch (Exception ex)
            {
                MessageBox.Show("Class name is BusinessClassBusDialog function name is UnselectData and exception : " + ex.Message);
            }
        }

    }
}
