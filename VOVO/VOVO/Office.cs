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
using static iText.StyledXmlParser.Jsoup.Select.Evaluator;
using static OneOf.Types.TrueFalseOrNull;

namespace VOVO
{
    public partial class Office : UserControl
    {
        private string id;
        private bool admin, employee;

        private string officeID;
        public Office()
        {
            InitializeComponent();
        }

        public Office(string id, bool admin = false, bool employee = false) : this()
        {
            this.id = id;
            this.admin = admin;
            this.employee = employee;
            DataShow();
        }

        private void DataShow()
        {
            Equipment equipment = new Equipment();
            officeID = equipment.idGenarator("Office");
            id_tb.Text = officeID;

        }

        private void register_button_Click(object sender, EventArgs e)
        {
            string name = name_tb.Text;
            string email = email_tb.Text;
            string countryCode = country_code_tb.Text;
            string phoneNumber = phone_number_tb.Text;
            string address = address_tb.Text;

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(countryCode) || string.IsNullOrWhiteSpace(phoneNumber) || string.IsNullOrWhiteSpace(address))
            {
                MessageBox.Show("Fill up the all ");
                return;
            }

            ValidityCheck validityCheck = new ValidityCheck();
            if (!validityCheck.IsEmailValid(email))
            {
                MessageBox.Show("Invalid Email", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!validityCheck.IsPhoneNumberValid(phoneNumber))
            {
                MessageBox.Show("Invalid phone Number", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool flag = NewOffice(name, email, countryCode, phoneNumber, address);
            if (admin)
                Admin(flag);

            else if (employee)
                Employee(flag);


        }


        private void Admin(bool flag)
        {
            if (flag)
            {
                DialogResult result = MessageBox.Show("Registration is successfull", "Success", MessageBoxButtons.OK);
                if (result == DialogResult.OK)
                {
                    DialogResult dialog = MessageBox.Show("Do you want to add another office?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (dialog == DialogResult.Yes)
                    {
                        if (AdminForm.Instance.panelContainer.Controls.ContainsKey("Office"))
                        {
                            AdminForm.Instance.panelContainer.Controls.Clear();
                            Office office = new Office(this.id);
                            office.Dock = DockStyle.Fill;
                            AdminForm.Instance.panelContainer.Controls.Add(office);
                        }
                    }

                    else if (dialog == DialogResult.No)
                    {
                        if (!AdminForm.Instance.panelContainer.Controls.ContainsKey("AdminDashBoard"))
                        {
                            AdminForm.Instance.panelContainer.Controls.Clear();
                            AdminDashBoard adminDashBoard = new AdminDashBoard(this.id);
                            adminDashBoard.Dock = DockStyle.Fill;
                            AdminForm.Instance.panelContainer.Controls.Add(adminDashBoard);
                        }
                    }
                }
            }
        }

        private void Employee(bool flag)
        {
            if (flag)
            {
                DialogResult result = MessageBox.Show("Registration is successfull", "Success", MessageBoxButtons.OK);
                if (result == DialogResult.OK)
                {
                    DialogResult dialog = MessageBox.Show("Do you want to add another office?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (dialog == DialogResult.Yes)
                    {
                        if (EmployeeForm.Instance.EmployeePanelContainer.Controls.ContainsKey("Office"))
                        {
                            EmployeeForm.Instance.EmployeePanelContainer.Controls.Clear();
                            Office office = new Office(this.id);
                            office.Dock = DockStyle.Fill;
                            EmployeeForm.Instance.EmployeePanelContainer.Controls.Add(office);
                        }
                    }

                    else if (dialog == DialogResult.No)
                    {
                        if (!EmployeeForm.Instance.EmployeePanelContainer.Controls.ContainsKey("EmployeeDashboard"))
                        {
                            Equipment equipment = new Equipment();
                            EmployeeForm.Instance.EmployeePanelContainer.Controls.Clear();
                            EmployeeDashboard employeeDashboard = new EmployeeDashboard(this.id);
                            employeeDashboard.Dock = DockStyle.Fill;
                            EmployeeForm.Instance.EmployeePanelContainer.Controls.Add(employeeDashboard);

                        }
                    }
                }
            }
        }


        private bool NewOffice(string name, string email, string countryCode, string phoneNumber, string address)
        {
            try
            {
                DataBase dataBase = new DataBase();
                Equipment equipment = new Equipment();
                using (SqlConnection connection = new SqlConnection(dataBase.connectionString))
                {
                    string query = @"INSERT INTO [Office Information] (ID, [Brunch Name], [Address], [Email], [Country Code], [Phone Number], [Admin ID], [Employee ID], Date, Time)
                                    VALUES(@ID, @BranceName, @Address, @Email, @CountryCode, @PhoneNumber, @AdminID, @EmployeeID, @Date, @Time)";

                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.Clear();
                        command.Parameters.AddWithValue("@ID", officeID);
                        command.Parameters.AddWithValue("@BranceName", name);
                        command.Parameters.AddWithValue("@Address", address);
                        command.Parameters.AddWithValue("@Email", email);
                        command.Parameters.AddWithValue("@CountryCode", countryCode);
                        command.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                        command.Parameters.AddWithValue("AdminID", (this.admin == true) ? (object)this.id : DBNull.Value);
                        command.Parameters.AddWithValue("EmployeeID", (this.employee == true) ? (object)this.id : DBNull.Value);
                        command.Parameters.AddWithValue("@Date", equipment.DataBaseFormatDate(equipment.TodayDate()));
                        command.Parameters.AddWithValue("@Time", equipment.Time());

                        command.ExecuteNonQuery();
                        connection.Close();
                        return true;
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Class name is office and function name is NewOffice and exception: " + ex.Message);
                return false;
            }
        }
    }
}
