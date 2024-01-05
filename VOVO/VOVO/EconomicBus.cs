using Org.BouncyCastle.Asn1.Crmf;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace VOVO
{
    public partial class EconomicBus : UserControl
    {
        private string BusID { get; set; }
        private string TicketID { get; set; }
        private string CustomerID { get; set; }

        private int totalSelectedSeat = 0, TicketPrice = 0;
        private string price, _Class = "Economic";


        private Label[] seat = new Label[48];
        private Label[] fare = new Label[48];
        private Label[] _class = new Label[48];


        public EconomicBus()
        {
            InitializeComponent();
        }

        public EconomicBus(string busID, string ticketID, string customerID)
        {
            InitializeComponent();
            BusID = busID;
            TicketID = ticketID;
            CustomerID = customerID;

            UpdateSeatButtonColors();
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

        private void SelectedSeat()
        {

            info_panel.Controls.Clear();

            for (int i = 0; i < totalSelectedSeat; i++)
            {
                int x1 = 20, x2 = 145, x3 = 280;
                int y = 20;

                seat[i] = new Label();
                seat[i].Font = new Font("Montserrat", 12);
                seat[i].Location = new Point(x1, (y + (i * 20)));
                info_panel.Controls.Add(seat[i]);


                fare[i] = new Label();
                fare[i].Font = new Font("Montserrat", 12);
                fare[i].Location = new Point(x2, (y + (i * 20)));
                info_panel.Controls.Add(fare[i]);


                _class[i] = new Label();
                _class[i].Font = new Font("Montserrat", 12);
                _class[i].Location = new Point(x3, (y + (i * 20)));
                info_panel.Controls.Add(_class[i]);

            }

            total_price.Text = String.Empty;
            Equipment equipment = new Equipment();
            total_price.Text = "Total: " + (equipment.StringToInt(price) * totalSelectedSeat).ToString();

        }

        private void UnselectData(string seatNumber)
        {
            int unselect = 0;
            try
            {
                int i = totalSelectedSeat - 1;
                while (i < totalSelectedSeat)
                {
                    if (seat[i].Text == seatNumber)
                    {
                        unselect = i;
                        info_panel.Controls.Remove(seat[i]);
                        info_panel.Controls.Remove(fare[i]);
                        info_panel.Controls.Remove(_class[i]);
                        i--;
                    }
                }

                if (unselect < totalSelectedSeat)
                {
                    for (int j = unselect; j < totalSelectedSeat - 1; i++)
                    {
                        seat[i] = seat[i + 1];
                        fare[i] = fare[i + 1];
                        _class[i] = _class[i + 1];
                    }

                    totalSelectedSeat--;
                }

                else if (unselect == totalSelectedSeat - 1)
                {
                    totalSelectedSeat--;
                }

                total_price.Text = String.Empty;
                Equipment equipment = new Equipment();
                total_price.Text = "Total: " + (equipment.StringToInt(price) * totalSelectedSeat).ToString();
            }



            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
                    button.BackColor = Color.YellowGreen;
                }

            }
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
                MessageBox.Show("Error while updating seat button colors: " + ex.Message);
            }
        }

        private void Data(string seatNumber)
        {
            seat[totalSelectedSeat].Text = seatNumber;
            fare[totalSelectedSeat].Text = price;
            _class[totalSelectedSeat].Text = _Class;
        }

        private void a1_button_Click(object sender, EventArgs e)
        {
            if (a1_button.BackColor == Color.YellowGreen)
            {
                a1_button.BackColor = Color.Coral;
                totalSelectedSeat++;
                Data("A1");
                SelectedSeat();
            }

            else if (a1_button.BackColor == Color.Coral)
            {
                a1_button.BackColor = Color.YellowGreen;
                totalSelectedSeat--;
                UnselectData("a1_button");
            }

            else if(a1_button.BackColor == Color.IndianRed)
            {
                MessageBox.Show("This is already sold", "VOVO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void a2_button_Click(object sender, EventArgs e)
        {
            if (a2_button.BackColor == Color.YellowGreen)
            {
                a2_button.BackColor = Color.Coral;
                totalSelectedSeat++;
                Data("A2");
                SelectedSeat();
            }

            else if (a2_button.BackColor == Color.Coral)
            {
                a2_button.BackColor = Color.YellowGreen;
                totalSelectedSeat--;
                UnselectData("a2_button");
            }

            else if (a2_button.BackColor == Color.IndianRed)
            {
                MessageBox.Show("This is already sold", "VOVO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void a3_button_Click(object sender, EventArgs e)
        {
            if (a3_button.BackColor == Color.YellowGreen)
            {
                a3_button.BackColor = Color.Coral;
                totalSelectedSeat++;
                Data("A3");
                SelectedSeat();
            }

            else if (a3_button.BackColor == Color.Coral)
            {
                a3_button.BackColor = Color.YellowGreen;
                totalSelectedSeat--;
                UnselectData("a3_button");
            }

            else if (a3_button.BackColor == Color.IndianRed)
            {
                MessageBox.Show("This is already sold", "VOVO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void a4_button_Click(object sender, EventArgs e)
        {
            if (a4_button.BackColor == Color.YellowGreen)
            {
                a4_button.BackColor = Color.Coral;
                totalSelectedSeat++;
                Data("A4");
                SelectedSeat();
            }

            else if (a4_button.BackColor == Color.Coral)
            {
                a4_button.BackColor = Color.YellowGreen;
                totalSelectedSeat--;
                UnselectData("a4_button");
            }

            else if (a4_button.BackColor == Color.IndianRed)
            {
                MessageBox.Show("This is already sold", "VOVO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void b1_button_Click(object sender, EventArgs e)
        {
            if (b1_button.BackColor == Color.YellowGreen)
            {
                b1_button.BackColor = Color.Coral;
                totalSelectedSeat++;
                Data("B1");
                SelectedSeat();
            }

            else if (b1_button.BackColor == Color.Coral)
            {
                b1_button.BackColor = Color.YellowGreen;
                totalSelectedSeat--;
                UnselectData("b1_button");
            }

            else if (b1_button.BackColor == Color.IndianRed)
            {
                MessageBox.Show("This is already sold", "VOVO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void b2_button_Click(object sender, EventArgs e)
        {
            if (b2_button.BackColor == Color.YellowGreen)
            {
                b2_button.BackColor = Color.Coral;
                totalSelectedSeat++;
                Data("B2");
                SelectedSeat();
            }

            else if (b2_button.BackColor == Color.Coral)
            {
                b2_button.BackColor = Color.YellowGreen;
                totalSelectedSeat--;
                UnselectData("b2_button");
            }

            else if (b2_button.BackColor == Color.IndianRed)
            {
                MessageBox.Show("This is already sold", "VOVO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void b3_button_Click(object sender, EventArgs e)
        {
            if (b3_button.BackColor == Color.YellowGreen)
            {
                b3_button.BackColor = Color.Coral;
                totalSelectedSeat++;
                Data("B3");
                SelectedSeat();
            }

            else if (b3_button.BackColor == Color.Coral)
            {
                b3_button.BackColor = Color.YellowGreen;
                totalSelectedSeat--;
                UnselectData("b3_button");
            }

            else if (b3_button.BackColor == Color.IndianRed)
            {
                MessageBox.Show("This is already sold", "VOVO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void b4_button_Click(object sender, EventArgs e)
        {
            if (b4_button.BackColor == Color.YellowGreen)
            {
                b4_button.BackColor = Color.Coral;
                totalSelectedSeat++;
                Data("B4");
                SelectedSeat();
            }

            else if (b4_button.BackColor == Color.Coral)
            {
                b4_button.BackColor = Color.YellowGreen;
                totalSelectedSeat--;
                UnselectData("b4_button");
            }

            else if (b4_button.BackColor == Color.IndianRed)
            {
                MessageBox.Show("This is already sold", "VOVO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void c1_button_Click(object sender, EventArgs e)
        {
            if (c1_button.BackColor == Color.YellowGreen)
            {
                c1_button.BackColor = Color.Coral;
                totalSelectedSeat++;
                Data("C1");
                SelectedSeat();
            }

            else if (c1_button.BackColor == Color.Coral)
            {
                c1_button.BackColor = Color.YellowGreen;
                totalSelectedSeat--;
                UnselectData("c1_button");
            }

            else if (c1_button.BackColor == Color.IndianRed)
            {
                MessageBox.Show("This is already sold", "VOVO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void c2_button_Click(object sender, EventArgs e)
        {
            if (c2_button.BackColor == Color.YellowGreen)
            {
                c2_button.BackColor = Color.Coral;
                totalSelectedSeat++;
                Data("C2");
                SelectedSeat();
            }

            else if (c2_button.BackColor == Color.Coral)
            {
                c2_button.BackColor = Color.YellowGreen;
                totalSelectedSeat--;
                UnselectData("c2_button");
            }

            else if (c2_button.BackColor == Color.IndianRed)
            {
                MessageBox.Show("This is already sold", "VOVO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void c3_button_Click(object sender, EventArgs e)
        {
            if (c3_button.BackColor == Color.YellowGreen)
            {
                c3_button.BackColor = Color.Coral;
                totalSelectedSeat++;
                Data("C3");
                SelectedSeat();
            }

            else if (c3_button.BackColor == Color.Coral)
            {
                c3_button.BackColor = Color.YellowGreen;
                totalSelectedSeat--;
                UnselectData("c3_button");
            }

            else if (c3_button.BackColor == Color.IndianRed)
            {
                MessageBox.Show("This is already sold", "VOVO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void c4_button_Click(object sender, EventArgs e)
        {
            if (c4_button.BackColor == Color.YellowGreen)
            {
                c4_button.BackColor = Color.Coral;
                totalSelectedSeat++;
                Data("C4");
                SelectedSeat();
            }

            else if (c4_button.BackColor == Color.Coral)
            {
                c4_button.BackColor = Color.YellowGreen;
                totalSelectedSeat--;
                UnselectData("c4_button");
            }

            else if (c4_button.BackColor == Color.IndianRed)
            {
                MessageBox.Show("This is already sold", "VOVO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void d1_button_Click(object sender, EventArgs e)
        {
            if (d1_button.BackColor == Color.YellowGreen)
            {
                d1_button.BackColor = Color.Coral;
                totalSelectedSeat++;
                Data("D1");
                SelectedSeat();
            }

            else if (d1_button.BackColor == Color.Coral)
            {
                d1_button.BackColor = Color.YellowGreen;
                totalSelectedSeat--;
                UnselectData("d1_button");
            }

            else if (d1_button.BackColor == Color.IndianRed)
            {
                MessageBox.Show("This is already sold", "VOVO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void d2_button_Click(object sender, EventArgs e)
        {
            if (d2_button.BackColor == Color.YellowGreen)
            {
                d2_button.BackColor = Color.Coral;
                totalSelectedSeat++;
                Data("D2");
                SelectedSeat();
            }

            else if (d2_button.BackColor == Color.Coral)
            {
                d2_button.BackColor = Color.YellowGreen;
                totalSelectedSeat--;
                UnselectData("d2_button");
            }

            else if (d2_button.BackColor == Color.IndianRed)
            {
                MessageBox.Show("This is already sold", "VOVO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void d3_button_Click(object sender, EventArgs e)
        {
            if (d3_button.BackColor == Color.YellowGreen)
            {
                d3_button.BackColor = Color.Coral;
                totalSelectedSeat++;
                Data("D3");
                SelectedSeat();
            }

            else if (d3_button.BackColor == Color.Coral)
            {
                d3_button.BackColor = Color.YellowGreen;
                totalSelectedSeat--;
                UnselectData("d3_button");
            }

            else if (d3_button.BackColor == Color.IndianRed)
            {
                MessageBox.Show("This is already sold", "VOVO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void d4_button_Click(object sender, EventArgs e)
        {
            if (d4_button.BackColor == Color.YellowGreen)
            {
                d4_button.BackColor = Color.Coral;
                totalSelectedSeat++;
                Data("D4");
                SelectedSeat();
            }

            else if (d4_button.BackColor == Color.Coral)
            {
                d4_button.BackColor = Color.YellowGreen;
                totalSelectedSeat--;
                UnselectData("d4_button");
            }

            else if (d4_button.BackColor == Color.IndianRed)
            {
                MessageBox.Show("This is already sold", "VOVO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void e1_button_Click(object sender, EventArgs e)
        {
            if (e1_button.BackColor == Color.YellowGreen)
            {
                e1_button.BackColor = Color.Coral;
                totalSelectedSeat++;
                Data("E1");
                SelectedSeat();
            }

            else if (e1_button.BackColor == Color.Coral)
            {
                e1_button.BackColor = Color.YellowGreen;
                totalSelectedSeat--;
                UnselectData("e1_button");
            }

            else if (e1_button.BackColor == Color.IndianRed)
            {
                MessageBox.Show("This is already sold", "VOVO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void e2_button_Click(object sender, EventArgs e)
        {
            if (e2_button.BackColor == Color.YellowGreen)
            {
                e2_button.BackColor = Color.Coral;
                totalSelectedSeat++;
                Data("E2");
                SelectedSeat();
            }

            else if (e2_button.BackColor == Color.Coral)
            {
                e2_button.BackColor = Color.YellowGreen;
                totalSelectedSeat--;
                UnselectData("e2_button");
            }

            else if (e2_button.BackColor == Color.IndianRed)
            {
                MessageBox.Show("This is already sold", "VOVO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void e3_button_Click(object sender, EventArgs e)
        {
            if (e3_button.BackColor == Color.YellowGreen)
            {
                e3_button.BackColor = Color.Coral;
                totalSelectedSeat++;
                Data("E3");
                SelectedSeat();
            }

            else if (e3_button.BackColor == Color.Coral)
            {
                e3_button.BackColor = Color.YellowGreen;
                totalSelectedSeat--;
                UnselectData("e3_button");
            }

            else if (e3_button.BackColor == Color.IndianRed)
            {
                MessageBox.Show("This is already sold", "VOVO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void e4_button_Click(object sender, EventArgs e)
        {
            if (e4_button.BackColor == Color.YellowGreen)
            {
                e4_button.BackColor = Color.Coral;
                totalSelectedSeat++;
                Data("E4");
                SelectedSeat();
            }

            else if (e4_button.BackColor == Color.Coral)
            {
                e4_button.BackColor = Color.YellowGreen;
                totalSelectedSeat--;
                UnselectData("e4_button");
            }

            else if (e4_button.BackColor == Color.IndianRed)
            {
                MessageBox.Show("This is already sold", "VOVO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void f1_button_Click(object sender, EventArgs e)
        {
            if (f1_button.BackColor == Color.YellowGreen)
            {
                f1_button.BackColor = Color.Coral;
                totalSelectedSeat++;
                Data("F1");
                SelectedSeat();
            }

            else if (f1_button.BackColor == Color.Coral)
            {
                f1_button.BackColor = Color.YellowGreen;
                totalSelectedSeat--;
                UnselectData("f1_button");
            }

            else if (f1_button.BackColor == Color.IndianRed)
            {
                MessageBox.Show("This is already sold", "VOVO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void f2_button_Click(object sender, EventArgs e)
        {
            if (f2_button.BackColor == Color.YellowGreen)
            {
                f2_button.BackColor = Color.Coral;
                totalSelectedSeat++;
                Data("F2");
                SelectedSeat();
            }

            else if (f2_button.BackColor == Color.Coral)
            {
                f2_button.BackColor = Color.YellowGreen;
                totalSelectedSeat--;
                UnselectData("f2_button");
            }

            else if (f2_button.BackColor == Color.IndianRed)
            {
                MessageBox.Show("This is already sold");
            }
        }

        private void f3_button_Click(object sender, EventArgs e)
        {
            if (f3_button.BackColor == Color.YellowGreen)
            {
                f3_button.BackColor = Color.Coral;
                totalSelectedSeat++;
                Data("F3");
                SelectedSeat();
            }

            else if (f3_button.BackColor == Color.Coral)
            {
                f3_button.BackColor = Color.YellowGreen;
                totalSelectedSeat--;
                UnselectData("f3_button");
            }

            else if (f3_button.BackColor == Color.IndianRed)
            {
                MessageBox.Show("This is already sold", "VOVO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void f4_button_Click(object sender, EventArgs e)
        {
            if (f4_button.BackColor == Color.YellowGreen)
            {
                f4_button.BackColor = Color.Coral;
                totalSelectedSeat++;
                Data("F4");
                SelectedSeat();
            }

            else if (f4_button.BackColor == Color.Coral)
            {
                f4_button.BackColor = Color.YellowGreen;
                totalSelectedSeat--;
                UnselectData("f4_button");
            }

            else if (f4_button.BackColor == Color.IndianRed)
            {
                MessageBox.Show("This is already sold", "VOVO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void g1_button_Click(object sender, EventArgs e)
        {
            if (g1_button.BackColor == Color.YellowGreen)
            {
                g1_button.BackColor = Color.Coral;
                totalSelectedSeat++;
                Data("G1");
                SelectedSeat();
            }

            else if (g1_button.BackColor == Color.Coral)
            {
                g1_button.BackColor = Color.YellowGreen;
                totalSelectedSeat--;
                UnselectData("g1_button");
            }

            else if (g1_button.BackColor == Color.IndianRed)
            {
                MessageBox.Show("This is already sold", "VOVO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void g2_button_Click(object sender, EventArgs e)
        {
            if (g2_button.BackColor == Color.YellowGreen)
            {
                g2_button.BackColor = Color.Coral;
                totalSelectedSeat++;
                Data("G2");
                SelectedSeat();
            }

            else if (g2_button.BackColor == Color.Coral)
            {
                g2_button.BackColor = Color.YellowGreen;
                totalSelectedSeat--;
                UnselectData("g2_button");
            }

            else if (g2_button.BackColor == Color.IndianRed)
            {
                MessageBox.Show("This is already sold", "VOVO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void g3_button_Click(object sender, EventArgs e)
        {
            if (g3_button.BackColor == Color.YellowGreen)
            {
                g3_button.BackColor = Color.Coral;
                totalSelectedSeat++;
                Data("G3");
                SelectedSeat();
            }

            else if (g3_button.BackColor == Color.Coral)
            {
                g3_button.BackColor = Color.YellowGreen;
                totalSelectedSeat--;
                UnselectData("g3_button");
            }

            else if (g3_button.BackColor == Color.IndianRed)
            {
                MessageBox.Show("This is already sold", "VOVO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void g4_button_Click(object sender, EventArgs e)
        {
            if (g4_button.BackColor == Color.YellowGreen)
            {
                g4_button.BackColor = Color.Coral;
                totalSelectedSeat++;
                Data("G4");
                SelectedSeat();
            }

            else if (g4_button.BackColor == Color.Coral)
            {
                g4_button.BackColor = Color.YellowGreen;
                totalSelectedSeat--;
                UnselectData("g4_button");
            }

            else if (g4_button.BackColor == Color.IndianRed)
            {
                MessageBox.Show("This is already sold", "VOVO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void h1_button_Click(object sender, EventArgs e)
        {
            if (h1_button.BackColor == Color.YellowGreen)
            {
                h1_button.BackColor = Color.Coral;
                totalSelectedSeat++;
                Data("H1");
                SelectedSeat();
            }

            else if (h1_button.BackColor == Color.Coral)
            {
                h1_button.BackColor = Color.YellowGreen;
                totalSelectedSeat--;
                UnselectData("h1_button");
            }

            else if (h1_button.BackColor == Color.IndianRed)
            {
                MessageBox.Show("This is already sold", "VOVO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void h2_button_Click(object sender, EventArgs e)
        {
            if (h2_button.BackColor == Color.YellowGreen)
            {
                h2_button.BackColor = Color.Coral;
                totalSelectedSeat++;
                Data("H2");
                SelectedSeat();
            }

            else if (h2_button.BackColor == Color.Coral)
            {
                h2_button.BackColor = Color.YellowGreen;
                totalSelectedSeat--;
                UnselectData("h2_button");
            }

            else if (h2_button.BackColor == Color.IndianRed)
            {
                MessageBox.Show("This is already sold", "VOVO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void h3_button_Click(object sender, EventArgs e)
        {
            if (h3_button.BackColor == Color.YellowGreen)
            {
                h3_button.BackColor = Color.Coral;
                totalSelectedSeat++;
                Data("H3");
                SelectedSeat();
            }

            else if (h3_button.BackColor == Color.Coral)
            {
                h3_button.BackColor = Color.YellowGreen;
                totalSelectedSeat--;
                UnselectData("h3_button");
            }

            else if (h3_button.BackColor == Color.IndianRed)
            {
                MessageBox.Show("This is already sold", "VOVO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void h4_button_Click(object sender, EventArgs e)
        {
            if (h4_button.BackColor == Color.YellowGreen)
            {
                h4_button.BackColor = Color.Coral;
                totalSelectedSeat++;
                Data("H4");
                SelectedSeat();
            }

            else if (h4_button.BackColor == Color.Coral)
            {
                h4_button.BackColor = Color.YellowGreen;
                totalSelectedSeat--;
                UnselectData("h4_button");
            }

            else if (h4_button.BackColor == Color.IndianRed)
            {
                MessageBox.Show("This is already sold", "VOVO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void i1_button_Click(object sender, EventArgs e)
        {
            if (i1_button.BackColor == Color.YellowGreen)
            {
                i1_button.BackColor = Color.Coral;
                totalSelectedSeat++;
                Data("I1");
                SelectedSeat();
            }

            else if (i1_button.BackColor == Color.Coral)
            {
                i1_button.BackColor = Color.YellowGreen;
                totalSelectedSeat--;
                UnselectData("i1_button");
            }

            else if (i1_button.BackColor == Color.IndianRed)
            {
                MessageBox.Show("This is already sold", "VOVO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void i2_button_Click(object sender, EventArgs e)
        {
            if (i2_button.BackColor == Color.YellowGreen)
            {
                i2_button.BackColor = Color.Coral;
                totalSelectedSeat++;
                Data("I2");
                SelectedSeat();
            }

            else if (i2_button.BackColor == Color.Coral)
            {
                i2_button.BackColor = Color.YellowGreen;
                totalSelectedSeat--;
                UnselectData("i2_button");
            }

            else if (i2_button.BackColor == Color.IndianRed)
            {
                MessageBox.Show("This is already sold", "VOVO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void k4_button_Click(object sender, EventArgs e)
        {

        }

        private void g4_button_Click_1(object sender, EventArgs e)
        {

        }

        private void i4_button_Click_1(object sender, EventArgs e)
        {

        }

        private void l4_button_Click(object sender, EventArgs e)
        {

        }

        private void h4_button_Click_1(object sender, EventArgs e)
        {

        }

        private void j4_button_Click(object sender, EventArgs e)
        {

        }

        private void i3_button_Click(object sender, EventArgs e)
        {
            if (i3_button.BackColor == Color.YellowGreen)
            {
                i3_button.BackColor = Color.Coral;
                totalSelectedSeat++;
                Data("I3");
                SelectedSeat();
            }

            else if (i3_button.BackColor == Color.Coral)
            {
                i3_button.BackColor = Color.YellowGreen;
                totalSelectedSeat--;
                UnselectData("i3_button");
            }

            else if (i3_button.BackColor == Color.IndianRed)
            {
                MessageBox.Show("This is already sold", "VOVO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void i4_button_Click(object sender, EventArgs e)
        {
            if (i4_button.BackColor == Color.YellowGreen)
            {
                i4_button.BackColor = Color.Coral;
                totalSelectedSeat++;
                Data("I4");
                SelectedSeat();
            }

            else if (i4_button.BackColor == Color.Coral)
            {
                i4_button.BackColor = Color.YellowGreen;
                totalSelectedSeat--;
                UnselectData("i4_button");
            }

            else if (i4_button.BackColor == Color.IndianRed)
            {
                MessageBox.Show("This is already sold", "VOVO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


    }
}

