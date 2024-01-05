using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Twilio.TwiML.Voice;
using static iText.StyledXmlParser.Jsoup.Select.Evaluator;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace VOVO
{
    public partial class CustomerDashboard : Form
    {
        /* string ticketNumber = "23", passengerName = "Basharul Alam", travelDate = "22 JANUARY 2023", travelTime = "12:00:00", departureCity = "Dhaka", arrivalCity = "Chitagong",
             busNumber ="123", busType = "Double Decker", seatNumber = "A1, A2, A3", fare = "3600", email = "basharulalammicrosoft@gmail.com", 
             passengerPasword = "123",  destinationCity="Dhaka", departureTime= "12:00:00";
        **/
        private string busCompanyName, boardingPoint, seatNumbers;
        private string id, name, email, countryCode, phoneNumber, password, date;
        private int emailVerificationFlag, phoneNumberVerificationFlag, gender;
        private Image image;


        public CustomerDashboard()
        {
            InitializeComponent();
            CustomDesign();

            FormControlsUtility.ConfigureFormResize(this);
        }

        // Rounded Corners  


        public CustomerDashboard(string id, Image image, string name, string email, int emailVerificationFlag, string countryCode, string phoneNumber, int phoneNumberVerificationFlag, int gender, string password) : this()
        {
            this.id = id;
            this.image = image;
            this.name = name;
            this.email = email;
            this.emailVerificationFlag = emailVerificationFlag;
            this.countryCode = countryCode;
            this.phoneNumber = phoneNumber;
            this.phoneNumberVerificationFlag = phoneNumberVerificationFlag;
            this.gender = gender;
            this.password = password;


            LoadComboBoxData();
            Data();
        }



        private void CustomDesign()
        {
            this.FormBorderStyle = FormBorderStyle.None;

            maximized_btn.Visible = false;
            Equipment equipment = new Equipment();
            icon.Image = equipment.ResizeImage(VOVO.Properties.Resources.Bus2, icon.Width, icon.Height);


            CalendarData();

        }

        private void Data()
        {
            Equipment equipment = new Equipment();
            user_picture_box.Image = equipment.ResizeImage(this.image, 84, 84);
            name_label.Text = this.name;

            //  MessageBox.Show("emailVerificationFlag: " + emailVerificationFlag + "\nphoneNumberVerificationFlag: " + phoneNumberVerificationFlag);

            if (emailVerificationFlag == 0 || phoneNumberVerificationFlag == 0)
            {
                warning_panel.Visible = true;
            }


            else if (emailVerificationFlag == 1 && phoneNumberVerificationFlag == 1)
            {
                warning_panel.Visible = false;
            }
        }

        private void CalendarData()
        {
            calendar.MinDate = DateTime.Now;
            calendar.MaxDate = DateTime.Now.AddMonths(1);
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

        private void LoadComboBoxData()
        {
            try
            {
                DataBase dataBase = new DataBase();
                using (SqlConnection connection = new SqlConnection(dataBase.connectionString))
                {
                    string query = @"SELECT 
                                        [From], 
                                        [To] 
                                    FROM 
                                        [Route Information] 
                                    ORDER BY 
                                        [From] ASC, 
                                        [To] ASC;";

                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string from = reader["From"].ToString();
                                string to = reader["To"].ToString();

                                from_combo_box.Items.Add(from);
                                from_combo_box.Items.Add(to);
                                to_combo_box.Items.Add(from);
                                to_combo_box.Items.Add(to);


                            }
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Customer Dashboard class loadComboBox: " + ex.Message);
            }
        }


        // Top Panel
        private void top_border_panel_MouseDown(object sender, MouseEventArgs e)
        {
            FormControlsUtility.AttachDraggableTitleBar(top_border_panel);

        }

        // Close button
        private void close_btn_MouseEnter(object sender, EventArgs e)
        {
            FormControlsUtility.ConfigureCloseButton(close_btn);

        }

        private void close_btn_MouseLeave(object sender, EventArgs e)
        {
            FormControlsUtility.ConfigureCloseButton(close_btn);

        }

        private void close_btn_Click(object sender, EventArgs e)
        {
            FormControlsUtility.ConfigureCloseButton(close_btn);

        }


        // Maximize button
        private void maximize_btn_MouseEnter(object sender, EventArgs e)
        {
            maximize_btn.ForeColor = Color.DarkSalmon;
            maximize_btn.BackColor = Color.DarkSalmon;
        }

        private void maximize_btn_MouseLeave(object sender, EventArgs e)
        {
            maximize_btn.BackColor = Color.Transparent;
        }

        private void maximize_btn_Click(object sender, EventArgs e)
        {
            FormControlsUtility.ConfigureMaximizeButton(maximize_btn, maximized_btn);

        }
        private void CustomerDashboard_Resize(object sender, EventArgs e)
        {
            FormControlsUtility.ConfigureFormResize(this);
        }


        private void profile_click(object sender, EventArgs e)
        {
            this.Hide();
            CustomerProfileForCustomer profileForCustomer = new CustomerProfileForCustomer(this.id, this.image, this.name, this.email, this.emailVerificationFlag, this.countryCode, this.phoneNumber, this.phoneNumberVerificationFlag, this.gender, this.password);
            profileForCustomer.Show();
        }

        // Maximized Button
        private void maximized_btn_MouseEnter(object sender, EventArgs e)
        {
            FormControlsUtility.ConfigureMaximizeButton(maximize_btn, maximized_btn);

        }

        private void maximized_btn_MouseLeave(object sender, EventArgs e)
        {
            FormControlsUtility.ConfigureMaximizeButton(maximize_btn, maximized_btn);

        }



        private void maximized_btn_Click(object sender, EventArgs e)
        {
            FormControlsUtility.ConfigureMaximizedButton(maximize_btn, maximized_btn);
        }


        // Minimize button
        private void minimize_btn_MouseEnter(object sender, EventArgs e)
        {
            FormControlsUtility.ConfigureMinimizeButton(minimize_btn);

        }

        private void minimize_btn_MouseLeave(object sender, EventArgs e)
        {
            FormControlsUtility.ConfigureMinimizeButton(minimize_btn);

        }

        private void minimize_btn_Click(object sender, EventArgs e)
        {
            FormControlsUtility.ConfigureMinimizeButton(minimize_btn);
        }

        private void calendar_tb_Enter(object sender, EventArgs e)
        {
            if (calendar_tb.Text == "Select a date")
            {
                calendar_tb.Text = "";
            }
        }

        private void calendar_tb_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(calendar_tb.Text))
            {
                calendar_tb.Text = "Select a date";
            }

            else if (!string.IsNullOrWhiteSpace(calendar_tb.Text) || calendar_tb.Text != "Select A Date")
            {
                DateTime? date = DateFormat(calendar_tb.Text); // Note the DateTime? (nullable DateTime)

                if (date != null)
                {
                    this.date = calendar_tb.Text;
                    calendar.Value = date.Value; // Set the calendar's value if date is not null
                }
            }
        }


        // Date textbix cursor leave
        private void date_tb_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(calendar_tb.Text) || calendar_tb.WaterMark != "Select A Date")
            {
                DateTime? date = DateFormat(calendar_tb.Text); // Note the DateTime? (nullable DateTime)

                if (date != null)
                {
                    this.date = calendar_tb.Text;
                    calendar.Value = date.Value; // Set the calendar's value if date is not null
                }
            }
        }

        private void calendar_ValueChanged(object sender, EventArgs e)
        {
            calendar_tb.Text = calendar.Value.Date.ToString("dd/MM/yyyy");
        }

        private void report_button_MouseEnter(object sender, EventArgs e)
        {
            report_button.Font = new Font(next_button.Font, FontStyle.Bold);
            report_button.ForeColor = Color.AntiqueWhite;
        }

        private void report_button_MouseLeave(object sender, EventArgs e)
        {
            report_button.Font = new Font(next_button.Font, FontStyle.Regular);
            report_button.ForeColor = Color.Transparent;
        }

        private void report_button_Click(object sender, EventArgs e)
        {

            //pdfDownload();
            /*
            CustomerReoprt customerReoprt = new CustomerReoprt(this.id);
            this.Hide();
            customerReoprt.Show();
            */

        }

        private void next_button_MouseEnter(object sender, EventArgs e)
        {
            next_button.Font = new Font(next_button.Font, FontStyle.Bold);
            next_button.ForeColor = Color.AntiqueWhite;
        }

        private void next_button_MouseLeave(object sender, EventArgs e)
        {
            next_button.Font = new Font(next_button.Font, FontStyle.Regular);
            next_button.ForeColor = Color.Transparent;
        }

        private void next_button_Click(object sender, EventArgs e)
        {
            string from = from_combo_box.Text;
            string to = to_combo_box.Text;
            //equipment.DataBaseFormatDate(equipment.DateTime_to_Date(departure_date.Value.ToString()));
            //  MessageBox.Show(date);
            date = calendar.Value.Date.ToString("dd/MM/yyyy");
            MessageBox.Show($"date: {date}");
            string date_tb = calendar_tb.Text;


            if (string.IsNullOrWhiteSpace(from))
                MessageBox.Show("Select your starting point");


            else if (string.IsNullOrWhiteSpace(to))
                MessageBox.Show("Select your destination");

            else if (string.IsNullOrWhiteSpace(date) || date_tb == "Select A Date")
                MessageBox.Show("Select your date");


            else if (!string.IsNullOrWhiteSpace(from) && !string.IsNullOrWhiteSpace(to) && !string.IsNullOrWhiteSpace(date) && date_tb != "Select A Date")
            {
                if (from == to)
                {
                    important_label.Visible = true;
                    return;
                }


                //CustomerTicketSearchingResult customerTicketSearchingResult = new CustomerTicketSearchingResult(this.id, this.name, this.email, this.countryCode, this.phoneNumber, from, to, date);
                MessageBox.Show("This is not avilable right now");
            }
            // else if(date)

        }

        private void log_out_button_Click(object sender, EventArgs e)
        {
            this.Hide();
            CustomerLoginForm customerLoginForm = new CustomerLoginForm();
            customerLoginForm.Show();
        }

        private void edit_button_Click(object sender, EventArgs e)
        {
            this.Hide();
            CustomerProfileForCustomer customerProfileForCustomer = new CustomerProfileForCustomer(this.id, this.image, this.name, this.email, this.emailVerificationFlag, this.countryCode, this.phoneNumber, this.phoneNumberVerificationFlag, gender, password, true);
            customerProfileForCustomer.Show();
        }

        /*
        // pdf store testing
        void pdfStore()
        {
            Equipment equipment = new Equipment();

            Image barcode = equipment.BarCode(ticketNumber, passengerName, boardingPoint, travelDate, travelTime, departureCity, arrivalCity, busNumber, busType, seatNumber, fare);
            // equipment.TicketEmailSend(Email, "Basharul Alam","22 January 2024", "Dhaka", "Feni", "12:30", "123", "A1, A2", barcode);
            //generateCustomPassword(int length, bool includeUpperCase, bool includeLowerCase, bool includeNumbers, bool includeSpecialCharacters)
            string password = equipment.generateCustomPassword(6, false, false, true, false);

            PDFGenerate pdfGenerate = new PDFGenerate();
            byte[] pdf = pdfGenerate.GenerateBusTicketPDF("Company Name", "22-359", "Double Decker (2023009)", "2023-09-21", "Leo Messi", "Dhaka", "Cox's Bazar", "Chottrogram (12:00:00)", "A1", barcode, password);

            // SoldTicketStoreData(string id, byte[] pdf, string password)

            DataBase dataBase = new DataBase();
            dataBase.SoldTicketStoreData("123", pdf, password);
        }


        void pdfDownload()
        {
            byte[] pdf = null;
            DataBase dataBase = new DataBase();
            string id = "123";
            try
            {
                using(SqlConnection connection = new SqlConnection(dataBase.connectionString))
                {
                    string query = "SELECT PDF FROM [Sold Ticket Information] WHERE ID = @ID";
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.Clear();
                        command.Parameters.AddWithValue("@ID", id);
                        using (SqlDataReader reader = command.ExecuteReader(CommandBehavior.Default))
                        {
                            if(reader.Read())
                            {
                                pdf = (byte[])reader.GetValue(0);

                            }
                        }
                    }
                }

                Equipment equipment = new Equipment();
                equipment.pdfDownload(pdf, "Bus Ticket");
            }

            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }



        //CustomerBookingDetails Testing
        void BookingDetails()
        {
            this.Close();
            CustomerBookingDetails customerBookingDetails = new CustomerBookingDetails();
            customerBookingDetails.Show();

        }

        */

    }



}

