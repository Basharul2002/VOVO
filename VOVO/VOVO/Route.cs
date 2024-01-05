using CustomControls.CustomControls;
using iText.Layout.Properties;
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
using Twilio.TwiML.Voice;
using static iText.Kernel.Pdf.Colorspace.PdfShading;
using static iText.StyledXmlParser.Jsoup.Select.Evaluator;

namespace VOVO
{
    public partial class Route : UserControl
    {
        private bool totalBoardingPoint = false, totalArrivalPoint = false;
        private string routeID;
        private TextBox[] boardingPoint_tb, boardingTime_tb, arrivalPoint_tb, arrivalTime_tb;
        private int numberOfBoardingPoints, numberOfArrivalPoints;
        private Label boardingTitle, arrivalTitle;
        private Label[] boardingPointsTitle, boardingPoints, boardingTimes, arrivalPointsTitle, arrivalPoints, arrivalTimes;
        private string EmployeeID { set; get; }

        public Route()
        {
            InitializeComponent();
        }

        public Route(string employeeID) : this()
        {
            EmployeeID = employeeID;
            points_panel.Visible = false;

            Design();
        }


        private void Design()
        {
            Equipment equipment = new Equipment();
            routeID = equipment.idGenarator("Route");
            route_id_tb.Text = routeID;
        }
        private void number_of_boarding_point_tb_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                // Check if the pressed key is a digit or a control key (e.g., Backspace)
                if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true; // Prevent the character from being entered
                    MessageBox.Show("Only digits are allowed.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ((TextBox)sender).Clear(); // Clear the textbox
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Class name is Route function name is number_of_boarding_point_tb_KeyPress and excetion: " + ex.Message);
            }
        }

        private void number_of_arrival_point_tb_KeyPress(object sender, KeyPressEventArgs e)
        {

            try
            {
                // Check if the pressed key is a digit or a control key (e.g., Backspace)
                if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true; // Prevent the character from being entered
                    MessageBox.Show("Only digits are allowed.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ((TextBox)sender).Clear(); // Clear the textbox
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Class name is Route and function name is number_of_arrival_point_tb_KeyPress and exception is: " + ex.Message);
            }
        }

        private void Registration(string from, string to)
        {
            try
            {
                DataBase dataBase = new DataBase();
                Equipment equipment = new Equipment();
                using (SqlConnection connection = new SqlConnection(dataBase.connectionString))
                {
                    string query = "INSERT INTO [Route Information] (ID, [From], [To], Date, Time, [Create Employee ID]) " +
                                   "VALUES (@ID, @From, @To, @Date, @Time, @EmployeeID)";
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.Clear();
                        command.Parameters.AddWithValue("@ID", routeID);
                        command.Parameters.AddWithValue("@From", from);
                        command.Parameters.AddWithValue("@To", to);
                        command.Parameters.AddWithValue("@Date", equipment.DataBaseFormatedDate(equipment.TodayDate()));
                        command.Parameters.AddWithValue("@Time", equipment.Time());
                        command.Parameters.AddWithValue("@EmployeeID", EmployeeID);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Route Class [Registration]: " + ex.Message);
            }
        }

        private void BoardingPointRegister(string pointName, string time)
        {

            try
            {
                DataBase dataBase = new DataBase();
                Equipment equipment = new Equipment();
                using (SqlConnection connection = new SqlConnection(dataBase.connectionString))
                {
                    string query = "INSERT INTO [Boarding Points Information] ([Point Name], [Time], [Route ID])" +
                                    "VALUES(@PointName, @Time, @RouteID)";
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.Clear();
                        command.Parameters.AddWithValue("@PointName", pointName);
                        command.Parameters.AddWithValue("@Time", time);
                        command.Parameters.AddWithValue("@RouteID", routeID);
                        command.ExecuteNonQuery();
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Class is Route and function is BoardingPointRegister]: " + ex.Message);
            }
        }

        private void ArrivalPointRegister(string pointName, string time)
        {

            try
            {
                DataBase dataBase = new DataBase();
                Equipment equipment = new Equipment();
                using (SqlConnection connection = new SqlConnection(dataBase.connectionString))
                {
                    string query = "INSERT INTO [Arrival Points Information] ( [Point Name], [Time], [Route ID])" +
                                    "VALUES(@PointName, @Time, @RouteID)";
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.Clear();
                        command.Parameters.AddWithValue("@PointName", pointName);
                        command.Parameters.AddWithValue("@Time", time);
                        command.Parameters.AddWithValue("@RouteID", routeID);
                        command.ExecuteNonQuery();
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Route Class [ArrivalPointRegister]: " + ex.Message);
            }
        }

        private void register_button_Click(object sender, EventArgs e)
        {
            string from = from_tb.Text;
            string to = to_tb.Text;
            bool isValidInput = true;
            bool boardingFlag = true;
            bool arrivalFlag = true;
            ValidityCheck validityCheck = new ValidityCheck(); // Create this instance once to reuse

            if (string.IsNullOrEmpty(from) || string.IsNullOrEmpty(to))
            {
                MessageBox.Show("Please fill up", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                isValidInput = false;
            }
            else
            {
                for (int i = 0; i < numberOfBoardingPoints; i++)
                {
                    string point = boardingPoint_tb[i].Text;
                    string time = boardingTime_tb[i].Text;

                    if (string.IsNullOrEmpty(point) || string.IsNullOrEmpty(time))
                    {
                        MessageBox.Show($"Fill up the Boarding point - {i + 1}", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        isValidInput = false;
                        boardingFlag = false;
                        break; // No need to continue checking after the first invalid point
                    }

                    if (!validityCheck.IsTimeValid(time))
                    {
                        MessageBox.Show("Invalid time format", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        isValidInput = false;
                        boardingFlag = false;
                        break;
                    }
                }

                if (boardingFlag) // Only proceed to arrival checks if boarding is valid
                {
                    for (int i = 0; i < numberOfArrivalPoints; i++)
                    {
                        string point = arrivalPoint_tb[i].Text;
                        string time = arrivalTime_tb[i].Text;

                        if (string.IsNullOrEmpty(point) || string.IsNullOrEmpty(time))
                        {
                            MessageBox.Show($"Fill up the Arrival point - {i + 1}", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            isValidInput = false;
                            arrivalFlag = false;
                            break;
                        }

                        if (!validityCheck.IsTimeValid(time))
                        {
                            MessageBox.Show("Invalid time format", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            isValidInput = false;
                            arrivalFlag = false;
                            break;
                        }
                    }
                }

                if (isValidInput && boardingFlag && arrivalFlag)
                {
                    Registration(from, to);

                    for (int i = 0; i < numberOfBoardingPoints; i++)
                    {
                        string point = boardingPoint_tb[i].Text;
                        string time = boardingTime_tb[i].Text;
                        BoardingPointRegister(point, time);
                    }

                    for (int i = 0; i < numberOfArrivalPoints; i++)
                    {
                        string point = arrivalPoint_tb[i].Text;
                        string time = arrivalTime_tb[i].Text;
                        ArrivalPointRegister(point, time);
                    }


                    DialogResult result = MessageBox.Show("Registration is successfull", "Success", MessageBoxButtons.OK);
                    if (result == DialogResult.OK)
                    {
                        DialogResult dialog = MessageBox.Show("Do you want to add another road?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (dialog == DialogResult.Yes)
                        {
                            if (EmployeeForm.Instance.EmployeePanelContainer.Controls.ContainsKey("Route"))
                            {
                                EmployeeForm.Instance.EmployeePanelContainer.Controls.Clear();
                                Route route = new Route(EmployeeID);
                                route.Dock = DockStyle.Fill;
                                EmployeeForm.Instance.EmployeePanelContainer.Controls.Add(route);
                            }
                        }

                        else if (dialog == DialogResult.No)
                        {
                            if (!EmployeeForm.Instance.EmployeePanelContainer.Controls.ContainsKey("EmployeeDashboard"))
                            {
                                Equipment equipment = new Equipment();
                                EmployeeForm.Instance.EmployeePanelContainer.Controls.Clear();
                                EmployeeDashboard employeeDashboard = new EmployeeDashboard(EmployeeID);
                                employeeDashboard.Dock = DockStyle.Fill;
                                EmployeeForm.Instance.EmployeePanelContainer.Controls.Add(employeeDashboard);
                            }
                        }

                    }
                }

                if (!EmployeeForm.Instance.EmployeePanelContainer.Controls.ContainsKey("EmployeeDashboard"))
                {
                    Equipment equipment = new Equipment();
                    EmployeeForm.Instance.EmployeePanelContainer.Controls.Clear();
                    EmployeeDashboard employeeDashboard = new EmployeeDashboard(EmployeeID);
                    employeeDashboard.Dock = DockStyle.Fill;
                    EmployeeForm.Instance.EmployeePanelContainer.Controls.Add(employeeDashboard);
                }
            }
        }


        private void click_button_Click(object sender, EventArgs e)
        {
            click_button.Visible = false;
            if (string.IsNullOrEmpty(number_of_boarding_point_tb.Text) && string.IsNullOrEmpty(number_of_arrival_point_tb.Text))
            {
                MessageBox.Show("Enter Number of boarding and arrival points", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            register_button.Visible = true;
            points_panel.Visible = true;
            Equipment equipment = new Equipment();
            numberOfBoardingPoints = equipment.StringToInt(number_of_boarding_point_tb.Text);
            numberOfArrivalPoints = equipment.StringToInt(number_of_arrival_point_tb.Text);

            BoardingLastPointPair pair = BoardingPointsDesign(numberOfBoardingPoints);
            ArrivalPointsDesign(numberOfArrivalPoints, pair);

        }

        private BoardingLastPointPair BoardingPointsDesign(int numberOfBoardingPoints)
        {
            totalBoardingPoint = true;
            points_panel.Controls.Clear();

            // Boarding Title
            boardingTitle = new Label();
            boardingTitle.Location = new Point(points_panel.Width / 2 - 30, 5);
            boardingTitle.Text = "Boarding Points";
            boardingTitle.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Underline);
            boardingTitle.Size = new Size(152, 20);
            points_panel.Controls.Add(boardingTitle);


            int labelX = 40, textBoxX = 205;
            int y = 45; // Update in loop

            boardingPointsTitle = new Label[numberOfBoardingPoints];
            boardingPoints = new Label[numberOfBoardingPoints];
            boardingTimes = new Label[numberOfBoardingPoints];
            boardingPoint_tb = new TextBox[numberOfBoardingPoints];
            boardingTime_tb = new TextBox[numberOfBoardingPoints];

            for (int i = 0; i < numberOfBoardingPoints; i++)
            {
                boardingPointsTitle[i] = new Label();
                boardingPointsTitle[i].Text = "Boarding Point " + (i + 1).ToString();
                boardingPointsTitle[i].Location = new Point(labelX, y);
                boardingPointsTitle[i].Font = new Font("Microsoft Sans Serif", 12, FontStyle.Underline);
                boardingPointsTitle[i].Size = new Size(135, 20);
                points_panel.Controls.Add(boardingPointsTitle[i]);

                y = y + 40;
                boardingPoints[i] = new Label();
                boardingPoints[i].Text = "Boarding Point Name: ";
                boardingPoints[i].Font = new Font("Microsoft Sans Serif", 12);
                boardingPoints[i].Size = new Size(163, 20);
                boardingPoints[i].Location = new Point(labelX, y);
                points_panel.Controls.Add(boardingPoints[i]);

                y = y - 11;
                boardingPoint_tb[i] = new TextBox();
                boardingPoint_tb[i].Size = new Size(235, 30);
                boardingPoint_tb[i].Font = new Font("Microsoft Sans Serif", 12);
                boardingPoint_tb[i].Location = new Point(textBoxX, y);
                points_panel.Controls.Add(boardingPoint_tb[i]);


                y = y + 60;
                boardingTimes[i] = new Label();
                boardingTimes[i].Text = "Boarding Time: ";
                boardingTimes[i].Font = new Font("Microsoft Sans Serif", 12);
                boardingTimes[i].Size = new Size(150, 31);
                boardingTimes[i].Location = new Point(labelX, y);
                points_panel.Controls.Add(boardingTimes[i]);

                y = y - 11;
                boardingTime_tb[i] = new TextBox();
                boardingTime_tb[i].Font = new Font("Microsoft Sans Serif", 12);
                boardingTime_tb[i].Size = new Size(234, 31);
                boardingTime_tb[i].Location = new Point(textBoxX, y);
                points_panel.Controls.Add(boardingTime_tb[i]);

                y = y + 80; // Update for next sub title

            }



            BoardingLastPointPair boardingLastPointPair = new BoardingLastPointPair
            {
                AxisX = boardingTimes[numberOfBoardingPoints - 1].Location.X,
                AxisY = boardingTimes[numberOfBoardingPoints - 1].Location.Y
            };

            return boardingLastPointPair;

        }

        private void ArrivalPointsDesign(int numberOfArrivalPoints, BoardingLastPointPair axis)
        {
            totalArrivalPoint = true;

            int axisX = axis.AxisX;
            int axisY = axis.AxisY + 60;

            // Boarding Title
            arrivalTitle = new Label();
            arrivalTitle.Location = new Point(points_panel.Width / 2 - 30, axisY);
            arrivalTitle.Text = "Arrival Points";
            arrivalTitle.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Underline);
            points_panel.Controls.Add(arrivalTitle);

            arrivalPointsTitle = new Label[numberOfArrivalPoints];
            arrivalPoints = new Label[numberOfArrivalPoints];
            arrivalTimes = new Label[numberOfArrivalPoints];
            arrivalPoint_tb = new TextBox[numberOfArrivalPoints];
            arrivalTime_tb = new TextBox[numberOfArrivalPoints];

            // 35, 145
            // 35, 175
            // 197, 168
            int labelX = 40, textBoxX = 205, y = axisY + 40;

            for (int i = 0; i < numberOfArrivalPoints; i++)
            {
                arrivalPointsTitle[i] = new Label();
                arrivalPointsTitle[i].Text = "Arrival Point - " + (i + 1);
                arrivalPointsTitle[i].Location = new Point(labelX, y);
                arrivalPointsTitle[i].Font = new Font("Microsoft Sans Serif", 12, FontStyle.Underline);
                arrivalPointsTitle[i].Size = new Size(200, 20);
                points_panel.Controls.Add(arrivalPointsTitle[i]);

                y = y + 40;
                arrivalPoints[i] = new Label();
                arrivalPoints[i].Text = "Arrival Point Name";
                arrivalPoints[i].Font = new Font("Microsoft Sans Serif", 12);
                arrivalPoints[i].Size = new Size(163, 20);
                arrivalPoints[i].Location = new Point(labelX, y);
                points_panel.Controls.Add(arrivalPoints[i]);

                y = y - 11;
                arrivalPoint_tb[i] = new TextBox();
                arrivalPoint_tb[i].Size = new Size(235, 30);
                arrivalPoint_tb[i].Font = new Font("Microsoft Sans Serif", 12);
                arrivalPoint_tb[i].Location = new Point(textBoxX, y);
                points_panel.Controls.Add(arrivalPoint_tb[i]);


                y = y + 60;
                arrivalTimes[i] = new Label();
                arrivalTimes[i].Text = "Arrival Time";
                arrivalTimes[i].Size = new Size(126, 20);
                arrivalTimes[i].Font = new Font("Microsoft Sans Serif", 12);
                arrivalTimes[i].Location = new Point(labelX, y);
                points_panel.Controls.Add(arrivalTimes[i]);

                y = y - 11;
                arrivalTime_tb[i] = new TextBox();
                arrivalTime_tb[i].Size = new Size(235, 30);
                arrivalTime_tb[i].Font = new Font("Microsoft Sans Serif", 12);
                arrivalTime_tb[i].Location = new Point(textBoxX, y);


                points_panel.Controls.Add(arrivalTime_tb[i]);

                y = y + 80; // Update for next sub title

            }

        }
    }
}
