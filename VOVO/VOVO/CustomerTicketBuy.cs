using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static iText.StyledXmlParser.Jsoup.Select.Evaluator;

namespace VOVO
{
    public partial class CustomerTicketBuy : Form
    {

        private int TotalSelectedSeat;
        private double totalPrice;
        private Label[] seat, fare, _class;
        private Label total_price;

        private void CustomerTicketBuy_SizeChanged(object sender, EventArgs e)
        {
          FormControlsUtility.ConfigureFormResize(this);
        }

        public CustomerTicketBuy()
        {
            InitializeComponent();
            FormControlsUtility.ConfigureFormResize(this);
        }

        // Rounded Corners  
      
        /*
        private void UnselectData(string seatNumber)
        {
            try
            {
                int i = 0;
                while (i < TotalSelectedSeat)
                {
                    // Check if the seatNumber matches the text of the label
                    if (seat[i].Text == seatNumber)
                    {
                        unselect = i;
                        info_panel.Controls.Remove(seat[i]);
                        info_panel.Controls.Remove(fare[i]);
                        info_panel.Controls.Remove(_class[i]);

                        // Decrement the TotalSelectedSeat count
                        TotalSelectedSeat--;

                        break; // Exit the loop after finding and removing the label
                    }
                    i++;
                }

                // Move the elements to the left to fill the gap after removing the label
                for (int j = unselect; j < TotalSelectedSeat; j++)
                {
                    seat[j] = seat[j + 1];
                    fare[j] = fare[j + 1];
                    _class[j] = _class[j + 1];
                }

                // Update the positions of the remaining labels
                int y = 30;
                for (int j = 0; j < TotalSelectedSeat; j++)
                {
                    seat[j].Location = new Point(19, y + j * 22);
                    fare[j].Location = new Point(122, y + j * 22);
                    _class[j].Location = new Point(225, y + j * 22);
                }

                // Calculate the total price by summing the fares for all selected seats
                int totalPrice = 0;
                for (int j = 0; j < TotalSelectedSeat; j++)
                {
                    totalPrice += int.Parse(fare[j].Text);
                }
                total_price.Text = "Total: " + totalPrice.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void selectedData(int totalSeats)
        {

            for (int i = 0; i < totalSelectedSeat+1 + 1; i++)
            {
                int x1 = 19, x2 = 122, x3 = 225;
                int y = 12;

                try
                {
                    seat[i] = new Label();
                    seat[i].Size = new Size(54, 16);
                    seat[i].Text = Seat;
                    seat[i].Font = new Font("Montserrat", 9.75f);
                    seat[i].Location = new Point(x1, (y + ((i - 1) * 22)));
                    info_panel.Controls.Add(seat[i]);


                    fare[i] = new Label();
                    fare[i].Size = new Size(54, 16);
                    fare[i].Text = Fare.ToString();
                    fare[i].Font = new Font("Montserrat", 9.75f);
                    fare[i].Location = new Point(x2, (y + ((i - 1) * 22)));
                    info_panel.Controls.Add(fare[i]);


                    _class[i] = new Label();
                    _class[i].Size = new Size(54, 16);
                    _class[i].Text = _Class;
                    _class[i].Font = new Font("Montserrat", 9.75f);
                    _class[i].Location = new Point(x3, (y + ((i - 1) * 22)));  //  positioned vertically with a spacing of 22 units between each row
                    info_panel.Controls.Add(_class[i]);

                    total_price.Texts = "Total: " + (Fare * i).ToString(); ;
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }
        */
    }
}
