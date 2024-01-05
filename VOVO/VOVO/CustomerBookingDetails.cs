using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace VOVO
{
    public partial class CustomerBookingDetails : Form
    {
        private string CustomerID { set; get; }
        private string CustomerName { set; get; }
        private string CustomerEmail { set; get; }
        private string CustomerPhoneNumber { set; get; }
        private string TicketID { set; get; }
        private string Departure { set; get; }
        private string Bus { set; get; }
        private string DepartureDate { set; get; }
        private string BoardingPoint { set; get; }  
        private int TotalSelectedSeat { set; get; }
        private string Seat { set; get; }
        private double Fare { set; get; }


        private string[] mobileBank = new string[] { "bKash", "Nagad", "Rocket", "Islami Bank mCash" };
        private string[] card = new string[] { "DBBL Nexus", "Master Card", "Visa Card" };
        private string[] bank = new string[] { "BRAC Bank Limited", "Islami Bank Bangladesh Ltd.", "National Credit and Commerce Bank Limited(NCC Bank)", "Sonali Bank Limited" };
        private string banking, bankName;


        public CustomerBookingDetails()
        {
            InitializeComponent();

            Custom();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }

        // Rounded Corners  
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // height of ellipse
            int nHeightEllipse // width of ellipse
        );


        public CustomerBookingDetails(string customerID, string customerName, string customerEmail, string customerPhoneNumber, string ticketID, string departure, string busCompany, string departueDate, string boardingPoint, int totalSelectedSeat, string seat, double fare )
        {
            InitializeComponent();
            CustomerID = customerID;
            CustomerName = customerName;
            CustomerEmail = customerEmail;
            CustomerPhoneNumber =  customerPhoneNumber;
            TicketID = ticketID;
            Departure = departure;
            Bus = busCompany;
            DepartureDate = departueDate;
            BoardingPoint = boardingPoint;
            TotalSelectedSeat = totalSelectedSeat;
            Seat = seat;
            Fare = fare;


            Custom();
        }

        private void Custom()
        {
            Equipment equipment = new Equipment();
            icon.Image = equipment.ResizeImage(VOVO.Properties.Resources.Bus2, 45, 40);


            name_tb.Text = CustomerName;
            email_tb.Text = CustomerEmail;
            phone_number_tb.Text = CustomerPhoneNumber;

            departure.Text = Departure;
            bus_company_name.Text = Bus;
            departure_date.Text = DepartureDate;
            boarding_point_time.Text = BoardingPoint;

            ticket_price.Text = Fare.ToString();



            PaymentOptions("Mobile Banking");
            Guideline("English");
        }


        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr one, int two, int three, int four);


        private void border_panel_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, 0x112, 0xf012, 0);
        }

        private void PaymentOptions(string way)
        {
            payment_method_combo_box.Items.Clear();
            if (way == "Mobile Banking")
            {
                info_label.Text = "Experience the convenience of mobile banking payments as you seamlessly navigate to\r\nour secure payment gateway. Your " +
                                    "financial details are protected, ensuring a worry-free\r\n transaction. Upon successful payment, receive instant " +
                                    "confirmation for your booking.";

                BankingButton(mobile_banking_button, card_button, internet_banking_button);

                banking = way;

                for (int i = 0; i < mobileBank.Length; i++)
                {
                    payment_method_combo_box.Items.Add(mobileBank[i]);
                }
            }

            else if(way == "Card")
            {
                info_label.Text = "You would be redirected to a third party payment gateway where you can pay with your \r\ncredit or debit cards. Your payment " +
                                    "transactions are 100% secure. On successful \r\npayment, you would get a confirmed ticket.";

                BankingButton(card_button, mobile_banking_button, internet_banking_button);
                banking = way;

                for (int i = 0;i < card.Length; i++)
                {
                    payment_method_combo_box.Items.Add(card[i]);
                }
            }

            else if(way == "Internet Banking")
            {
                info_label.Text = "You would be redirected to a third party payment gateway where you can pay with \r\nyour internet banking accounts. " +
                                    "Your payment transactions are 100% secure. On \r\nsuccessful payment, you would get a confirmed ticket.";


                BankingButton(internet_banking_button, mobile_banking_button, card_button);
                banking = way;

                internet_banking_button.Enabled = false;
                for (int i = 0; i<bank.Length; i++) 
                {
                    payment_method_combo_box.Items.Add(bank[i]);
                }
            }

        }

        private void BankingButton(System.Windows.Forms.Button button1, System.Windows.Forms.Button button2, System.Windows.Forms.Button button3)
        {
            button1.Enabled = false; // Selected button
            button2.Enabled = true; // Unselected Button
            button3.Enabled = true;  // Unselected Button

            button1.BackColor = Color.Coral; // Selected button
            button2.BackColor = Color.DarkSalmon;  // Unselected Button
            button3.BackColor = Color.DarkSalmon;  // Unselected Button
        }



        private void Guideline(string type)
        {
            Font englishFont = new Font("Montserrat", 12, FontStyle.Regular);
            Font banglaFont = GetBengaliFont();

            try
            {
                if (type == "English")
                {
                    after_payment_guideline_english_button.Enabled = false;
                    after_payment_guideline_bangla_button.Enabled = true;
                    after_payment_guideline_english_button.BackColor = Color.Coral;
                    after_payment_guideline_bangla_button.BackColor = Color.DarkSalmon;


                    guideline_label1.Text = "1. Invoice and e-ticket in our site for print and view";
                    guideline_label2.Text = "2. Copy of e-ticket in your email address, that you have inputted here";
                    guideline_label3.Text = "3. SMS from VOVO as confirmation of your e-ticket";
                    guideline_label4.Text = "Show your e-ticket at boarding counter 15 min before your departure, to ensure your journey";

                    guideline_label1.Font = englishFont;
                    guideline_label2.Font = englishFont;
                    guideline_label3.Font = englishFont;
                    guideline_label4.Font = englishFont;
                }
                else if (type == "Bangla")
                {
                    after_payment_guideline_english_button.Enabled = true;
                    after_payment_guideline_bangla_button.Enabled = false;
                    after_payment_guideline_bangla_button.BackColor = Color.Coral;
                    after_payment_guideline_english_button.BackColor = Color.DarkSalmon;


                    guideline_label1.Text = "১) আমাদের সাইটে ই-টিকিট ও ইনভয়েস প্রিন্ট ও আপনার দেয়া তথ্য মিলিয়ে দেখার জন্য পাবেন।";
                    guideline_label2.Text = "২) আমাদের সাইট থেকে আপনার এখানে দেয়া ই-মেইল আইডিতে একটি ই-টিকিট ই-মেইল পাবেন।";
                    guideline_label3.Text = "৩) ভোঁভোঁ থেকে একটি এসএমএস এর মাধ্যমে ই-টিকিট কনফার্মেশন মেসেজ পাবেন।";
                    guideline_label4.Text = "ডিপার্চার টাইমের ১৫ মিনিট আগে বোর্ডিং কাউন্টারে ই-টিকিট দেখিয়ে বোর্ডিং পাশ সংগ্রহ করে, আপনার ভ্রমন নিশ্চিত করুন।";

                    guideline_label1.Font = banglaFont;
                    guideline_label2.Font = banglaFont;
                    guideline_label3.Font = banglaFont;
                    guideline_label4.Font = banglaFont;
                }
            }

            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private Font GetBengaliFont()
        {
            // Load the Siyam Rupali font from the resource file
            PrivateFontCollection fontCollection = new PrivateFontCollection();

            // Replace "YourNamespace.Properties.Resources" with the appropriate namespace for your project
            byte[] fontData = VOVO.Properties.Resources.Siyam_Rupali_Regular;

            IntPtr fontPtr = Marshal.AllocCoTaskMem(fontData.Length);
            Marshal.Copy(fontData, 0, fontPtr, fontData.Length);
            fontCollection.AddMemoryFont(fontPtr, fontData.Length);

            // Create and return the Siyam Rupali font
            FontFamily fontFamily = fontCollection.Families[0];
            Font banglaFont = new Font(fontFamily, 12, FontStyle.Regular);

            // Free the allocated memory
            Marshal.FreeCoTaskMem(fontPtr);

            return banglaFont;
        }

        private void mobile_banking_button_Click(object sender, EventArgs e)
        {
            PaymentOptions("Mobile Banking");
        }

        private void card_button_Click(object sender, EventArgs e)
        {
            PaymentOptions("Card");
        }

        private void internet_banking_button_Click(object sender, EventArgs e)
        {
            PaymentOptions("Internet Banking");
        }

        private void after_payment_guideline_english_button_Click(object sender, EventArgs e)
        {
            Guideline("English");
        }

        private void after_payment_guideline_bangla_button_Click(object sender, EventArgs e)
        {
            Guideline("Bangla");
        }

        private void CustomerBookingDetails_SizeChanged(object sender, EventArgs e)
        {
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }

        private void maximized_btn_Click(object sender, EventArgs e)
        {
            FormControlsUtility.ConfigureMaximizedButton(maximize_btn, maximized_btn);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pay_button_Click(object sender, EventArgs e)
        {
            bankName = payment_method_combo_box.Text;
            
            if(banking == "Internet Banking")
            {
                this.Hide();
                OnlineBankingPayment onlineBankingPayment = new OnlineBankingPayment(bankName, Fare);
                onlineBankingPayment.Show();
            }
        }
    }
}
