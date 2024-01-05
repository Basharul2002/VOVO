using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VOVO
{
    public partial class EmployeeProfile : UserControl
    {
        private string employeeID, employeeType;


        public EmployeeProfile()
        {
            InitializeComponent();
        }

        public EmployeeProfile(string employeeID, string employeeType) : this()
        {
            this.employeeType = employeeType;
            this.employeeID = employeeID;

            //MessageBox.Show("Employee ID: " + employeeID);
            DataShow();
        }

        private void DataShow()
        {
            DataBase dataBase = new DataBase();

            try
            {

                using (SqlConnection connection = new SqlConnection(dataBase.connectionString))
                {
                    string query = $"SELECT * FROM [User Information] WHERE ID = @ID AND [User Type] = '{this.employeeType}'";
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.Clear();
                        command.Parameters.AddWithValue("@ID", this.employeeID);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                Equipment equipment = new Equipment();
                                if (!Convert.IsDBNull(reader["Picture"]))
                                {
                                    byte[] imageData = (byte[])reader["Picture"];
                                    if (imageData != null && imageData.Length > 0)
                                    {
                                        using (MemoryStream ms = new MemoryStream(imageData))
                                        {
                                            picture.Image = equipment.ResizeImage(Image.FromStream(ms), 106, 106);
                                        }
                                    }
                                }

                                else
                                {
                                    picture.Image = equipment.ResizeImage(Properties.Resources.Customer, 106, 106);
                                }

                                name.Text = "Name: " + reader["Name"].ToString();
                                id.Text = "ID: " + reader["ID"].ToString();
                                email.Text = "Email: " + reader["Email"].ToString();
                                phonenumber.Text = "Phone Number: " + reader["Phone Number"].ToString();
                                dob.Text = "DOB: " + DateTime.Parse(reader["Date Of Birth"].ToString()).ToString("dd/MM/yyyy");
                                gender.Text = "Gender: " + reader["Gender"].ToString();
                                nationality.Text = "Nationality: " + reader["Nationality"].ToString();

                                picture.SizeMode = PictureBoxSizeMode.StretchImage;

                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void change_pasword_button_Click(object sender, EventArgs e)
        {
            EmployeeUpdateData employeeChangePassword = new EmployeeUpdateData(this.employeeType, this.employeeID);
            employeeChangePassword.ShowDialog();

            if (employeeChangePassword.flag == true)
                employeeChangePassword.Hide();


        }

     
    }
}
