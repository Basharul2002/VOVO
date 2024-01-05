using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Globalization;


namespace VOVO
{
    // public Panel Data = DataShowpanel;
    public enum Gender_E : int
    {
        NotSay = 0,
        Male = 1,
        Female = 2,
        Others = 3


    }
    public partial class ManagerViewDriver : MetroFramework.Forms.MetroForm
    {

        private string Name, Id, Password, id, gender;

        public ManagerViewDriver()
        {
            InitializeComponent();
        }


        

        private int SerialNo(string type)
        {
            string lastID = string.Empty;
            DataBase dataBase = new DataBase();
            lastID = dataBase.LastID(type);
            int returnValue = 0;


            if (lastID == null)
            {
                returnValue = -1;
            }

            else
            {
                if (lastID == string.Empty)
                {
                    returnValue = 0;
                }

                else if (!string.IsNullOrEmpty(lastID))
                {
                    int year = Int32.Parse(lastID.Substring(4, 2));
                    int month = Int32.Parse(lastID.Substring(lastID.Length - 1, 1));
                    DateTime dateTime = DateTime.Now;
                    int yearNow = (dateTime.Year % 100);
                    int monthNow = ((dateTime.Month) / 5) + 1;


                    if (year != yearNow || month != monthNow)
                    {
                        returnValue = 0;
                    }

                    else if (year == yearNow || month == monthNow)
                    {

                        string numberPart = lastID.Substring(6, 10);
                        returnValue = Int32.Parse(numberPart);

                    }
                }
            }
            return returnValue;
        }

        ///validity
        public string pakhi { set; get; }
        public bool IsPhoneNumberValid(string phn_num)
        {
            if (phn_num.Length == 10)
            {
                string phnNumPattern = @"^\d{10}$";

                return Regex.IsMatch(phn_num, phnNumPattern);
            }
            return false;
        }


        public bool IsEmailValid(string email)
        {
            string emailFormatPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

            return Regex.IsMatch(email, emailFormatPattern);
        }


        private string IdGenarator(string type)
        {
            DateTime date = DateTime.Now;

            int year = date.Year;
            int month = (date.Month / 5) + 1;
            int day = date.Day;

            int serialNo = SerialNo(type) + 1;
            string id = string.Empty;

            if (type == "Customer")
            {
                return "CUS-" + (year % 100) + serialNo.ToString("D10") + "-" + month;
            }


            return string.Empty;
        }




        private string genderSelection()
        {
            if (Male_radio_button.Checked)
            {
                gender = "Male";
            }

            if (Female_radio_button.Checked)
            {
                gender = "Female";
            }

            if (Others_radio_button.Checked)
            {
                gender = "Others";
            }


            if (NotSay_Radiobutton.Checked)
            {
                gender = "NotSay";
            }

            if (!Male_radio_button.Checked && !Female_radio_button.Checked && !Others_radio_button.Checked && !NotSay_Radiobutton.Checked)
            {
                gender = "No Selected";
            }

            return gender;
        }




        private void Add_Click(object sender, EventArgs e)
        {
            DataShowpanel.Visible = false;
            if (Seach_panel.Visible == true)
            {
                Seach_panel.Visible = false;
                add_panel.Visible = true;
                return;
            }
            if (string.IsNullOrEmpty(name_tb.Text) || string.IsNullOrEmpty(email_tb.Text) || string.IsNullOrEmpty(PH_tb.Text) || string.IsNullOrEmpty(County_Code.Text = "Chosse") || string.IsNullOrEmpty(password_tb.Text) || string.IsNullOrEmpty(gender = "Not selected"))
            {

                MessageBox.Show("Please fill up all your information");
                return;

            }

            else if (!string.IsNullOrEmpty(name_tb.Text) && !string.IsNullOrEmpty(email_tb.Text) && County_Code.SelectedItem.ToString() == "+880(BAN)" && !string.IsNullOrEmpty(PH_tb.Text) && genderSelection() != "No Selected" && !string.IsNullOrEmpty(password_tb.Text))
            {

                string countryCode = County_Code.SelectedItem.ToString().Substring(1, 3);
                string id = ID_tb.Text;
                bool email = IsEmailValid(email_tb.Text);
                pakhi = PH_tb.Text;
                bool phone = IsPhoneNumberValid(pakhi);

                if (!email)
                {
                    MessageBox.Show("Invalid Email");
                    return;

                }
                else if (!phone)
                {
                    MessageBox.Show("Invalid Phone");
                    return;
                }
                
              
                    Gender_E enumGender;
                    string intGender = null;
                    string gender = genderSelection();

                    if (Enum.TryParse(gender, out enumGender))
                    {
                        intGender = ((int)enumGender).ToString();
                    }

                    //   MessageBox.Show($"gender{ intGender}");
                    DataBase DB = new DataBase();
                    DB.CustomerRegistration(id, name_tb.Text, email_tb.Text, countryCode, PH_tb.Text, intGender, password_tb.Text);

                
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ManagerViewDriver_Load(object sender, EventArgs e)
        {
            ID_tb.Text = IdGenarator("Customer");
            //DataShowpanel.Visible = false;

        }





        private void SHEARCH_Click_1(object sender, EventArgs e)
        {
            DataShowpanel.Visible = false;
            Seach_panel.Visible = true;
            Seach_panel.BringToFront(); ;
            ID_tb.Text = null;

        }

        bool flag = false;
        private void FindDatabtn_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Shearch_email_and_phone.Text))
            {
                //  Shearch_email_and_phone.Text = null;
                add_panel.Visible = true;
                Seach_panel.Visible = true;
                showCustomerDetails();
                DataShowpanel.Visible = true;
                Gridview_panel.Visible = false;
                if (flag)
                {
                    Shearch_email_and_phone.Text = null;
                }
            }
        }

        public bool found;
        private void showCustomerDetails()
        {

            string emailORphone = Shearch_email_and_phone.Text;
            try
            {
                if (!string.IsNullOrEmpty(Shearch_email_and_phone.Text))
                {

                    DataBase dataBase = new DataBase();
                    using (SqlConnection connection = new SqlConnection(dataBase.connectionString))
                    {
                        string query = @"SELECT * 
                                        FROM 
                                            [Customer All Information View] 
                                        WHERE";

                        SqlParameter[] parameters;



                        if (emailORphone.Length >= 12 && emailORphone.Length <= 14 && IsPhoneNumberValid(emailORphone.Substring(1, emailORphone.Length - 1)))
                        {
                            query = $"{query} [Country Code] = @CountryCode AND [Phone Number] = @PhoneNumber ";
                            parameters = new SqlParameter[]
                            {
                                new SqlParameter("@CountryCode", emailORphone.Substring(1, 3)),
                                new SqlParameter("@PhoneNumber", emailORphone.Substring(4, 10)),
                            };
                        }

                        else if (emailORphone.Length == 11 && IsPhoneNumberValid(emailORphone))
                        {
                            query = $"{query} [Country Code] LIKE @CountryCode AND [Phone Number] = @PhoneNumber ";
                            parameters = new SqlParameter[]
                            {
                                new SqlParameter("@CountryCode", "%" + emailORphone.Substring(0, 1)),
                                new SqlParameter("@PhoneNumber", emailORphone.Substring(1, 10)),
                            };
                        }

                        else
                        {
                            query = $"{query} [Email] = @Email ";
                            parameters = new SqlParameter[]
                            {
                                new SqlParameter("@Email", emailORphone),
                            };
                        }

                        connection.Open();

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.Clear();
                            foreach (var parameter in parameters)

                                command.Parameters.Add(parameter);

                            //  command.Parameters.AddWithValue("@Password", password);

                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                if (reader.HasRows)
                                {
                                    reader.Read(); // Read the first row
                                    {
                                        ID_button.Text = reader["Customer ID"].ToString();
                                        name.Text = reader["Name"].ToString();
                                        //  MessageBox.Show($"{ name.Text }");
                                        Email.Text = reader["Email"].ToString();
                                        // MessageBox.Show($"{email_tb.Text}");
                                        String num = $"{reader["Phone Number"].ToString()}";
                                        Phone.Text = "+880" + num;
                                        password.Text = reader["Password"].ToString();
                                        // MessageBox.Show($"{password.Text}");
                                        this.id = ID_button.Text;
                                        // Deletedatapass(this.id, "Customer");
                                        //  flag = true;
                                        // found = true;

                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)


            {
                MessageBox.Show($"Class name is ManagerViewDriver and function name is showCustomerDetails and exception: {ex.Message}");
            }
        }

        private void Add_MouseEnter(object sender, EventArgs e)
        {

            add_panel.Visible = true;
        }



        private void Load_Info()
        {

            DataTable dt;
            DataBase data = new DataBase(); 
            using (SqlConnection connection = new SqlConnection(data.connectionString))

            {
                string query = "Select * From [Customer Information]";

                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    SqlDataAdapter adp = new SqlDataAdapter(command);//data adapt er jnno
                    DataSet ds = new DataSet();// table rakhe 
                    adp.Fill(ds);
                    dt = new DataTable();//indiviual table
                    dt = ds.Tables[0];//onek gula table theke 1ta table nisi
                    connection.Close();

                }

                DataTable_Show.AutoGenerateColumns = false;//karon shob soe kortesi na
                DataTable_Show.DataSource = dt;
                DataTable_Show.Refresh();
                DataTable_Show.ClearSelection();
            }

        }


        private void Table_Click(object sender, EventArgs e)
        {
            DataShowpanel.Visible = true;
            Gridview_panel.Visible = true;
            Load_Info();
        }

        private void Delete_Click_1(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are You Sure Admin??", "VOVO", MessageBoxButtons.YesNo);
            if (result == DialogResult.No)
                return;
            DataBase database = new DataBase();
            database.DataDeleted(ID_button.Text, "Customer");
            add_panel.Visible = true;

        }



        private void Refresh_Click(object sender, EventArgs e)
        {
            DataShowpanel.Visible = true;
            Gridview_panel.Visible = true;
            Load_Info();
        }


        //ID_button ,name,Email,Phone,password


        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ID_button.Text) || string.IsNullOrEmpty(name.Text) || string.IsNullOrEmpty(password.Text) || string.IsNullOrEmpty(Email.Text) || string.IsNullOrEmpty(Phone.Text))
            {
                MessageBox.Show("Please fill the information");
                return;
            }
            //  // string s= Phone.Text.Substring(4, Phone.Text.Length - 1);
            // MessageBox.Show($"{s}");
            string query = $@"Update [Customer Information] set Name='{name.Text}', Password='{password.Text}', Email='{Email.Text}', [Phone Number]='{Phone.Text.Substring(4, 10)}'Where id='{ID_button.Text}'";
            dataopration(query);

        }


        private void Email_Click(object sender, EventArgs e)
        {
            Email.ReadOnly = false;
            Email.Enabled = true;
        }

        private void Phone_Click(object sender, EventArgs e)
        {
            Phone.ReadOnly = false;
            Phone.Enabled = true;
        }

        private void password_Click(object sender, EventArgs e)
        {
            password.ReadOnly = false;
            password.Enabled = true;
        }

        private void Change_Name_label_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            name.ReadOnly = false;
            name.Enabled = true;


        }

        private void back_button_Click(object sender, EventArgs e)
        {
            CustomerLoginForm form = new CustomerLoginForm();
            this.Hide();
            form.Show();
        }

        private void dataopration(string query)
        {

            try
            {
                DataBase dataBase = new DataBase();
                using (SqlConnection connection = new SqlConnection(dataBase.connectionString))

                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.ExecuteNonQuery();
                        MessageBox.Show("Data Update Sucessfully");

                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Class name is ManagerViewDriver and function name is dataopration and Execption: {ex}");
            }

        }
        private void Change_EmailLbl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Email.ReadOnly = false;
            Email.Enabled = true;
        }

        private void ChangePhone_labl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Phone.ReadOnly = false;
            Phone.Enabled = true;
        }

        private void changePassLbl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            password.ReadOnly = false;
            password.Enabled = true;
        }
    }

}






