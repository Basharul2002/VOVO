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
    public partial class RouteSelection : Form
    {
        private string routeID, from, to, boardingPoint, arrivalPoint;

        private string EmployeeID { set; get; }

        private int routeCount, boardingPointCount, arrivalPointCount;

        static RouteSelection obj;


        public static RouteSelection Instance
        {
            get
            {
                if (obj == null)
                {
                    obj = new RouteSelection();
                }
                return obj;
            }
        }

        public FlowLayoutPanel panelContainer
        {
            get { return result_panel; }
            set { result_panel = value; }
        }


        public RouteSelection()
        {
            InitializeComponent();
            result_panel.Controls.Clear();
            FormControlsUtility.ConfigureFormResize(this);
        }



        public RouteSelection(string employeeID) : this()
        {
            EmployeeID = employeeID;
            DataShow();
            CustomDesign();
        }




        private void border_panel_MouseDown(object sender, MouseEventArgs e)
        {
            FormControlsUtility.AttachDraggableTitleBar(border_panel);

        }


        private void close_btn_Click(object sender, EventArgs e)
        {
            FormControlsUtility.ConfigureCloseButton(close_btn);

        }

        private void close_btn_MouseEnter(object sender, EventArgs e)
        {
            FormControlsUtility.ConfigureCloseButton(close_btn);

        }

        private void close_btn_MouseLeave(object sender, EventArgs e)
        {
            FormControlsUtility.ConfigureCloseButton(close_btn);

        }


        private void maximize_btn_Click(object sender, EventArgs e)
        {
            FormControlsUtility.ConfigureMaximizeButton(maximize_btn, maximized_btn);

        }

        private void maximize_btn_MouseEnter(object sender, EventArgs e)
        {
            FormControlsUtility.ConfigureMaximizeButton(maximize_btn, maximized_btn);

        }

        private void maximize_btn_MouseLeave(object sender, EventArgs e)
        {
            maximize_btn.BackColor = Color.Transparent;
        }
        private void minimize_btn_Click(object sender, EventArgs e)
        {
            FormControlsUtility.ConfigureMinimizeButton(minimize_btn);
        }

        private void minimize_btn_MouseEnter(object sender, EventArgs e)
        {
            FormControlsUtility.ConfigureMinimizeButton(minimize_btn);

        }

        private void minimize_btn_MouseLeave(object sender, EventArgs e)
        {
            FormControlsUtility.ConfigureMinimizeButton(minimize_btn);

        }

        private void maximized_btn_Click(object sender, EventArgs e)
        {
            FormControlsUtility.ConfigureMaximizedButton(maximize_btn, maximized_btn);
        }

        private void maximized_btn_MouseEnter(object sender, EventArgs e)
        {
            FormControlsUtility.ConfigureMaximizeButton(maximize_btn, maximized_btn);

        }

        private void maximized_btn_MouseLeave(object sender, EventArgs e)
        {
            FormControlsUtility.ConfigureMaximizeButton(maximize_btn, maximized_btn);

        }

        private void RouteSelection_SizeChanged(object sender, EventArgs e)
        {
            FormControlsUtility.ConfigureFormResize(this);
        }

        private void customButton1_Click(object sender, EventArgs e)
        {

        }

        private void CustomDesign()
        {
            this.FormBorderStyle = FormBorderStyle.None;

            maximized_btn.Visible = false;
            Equipment equipment = new Equipment();
            icon.Image = equipment.ResizeImage(VOVO.Properties.Resources.Bus2, icon.Width, icon.Height);

        }


        private void DataShow()
        {
            try
            {
                DataBase dataBase = new DataBase();
                using (SqlConnection connection = new SqlConnection(dataBase.connectionString))
                {
                    string query = @"SELECT 
                                            R.[ID], R.[From], R.[To], 
                                            BPI.[Point Name] AS [Boarding Point], 
                                            API.[Point Name] AS [Arrival Point],
                                            (SELECT COUNT(ID) FROM [Route Information]) AS [Route Count],
                                            (SELECT COUNT(ID) FROM [Boarding Points Information] WHERE [Route ID] = R.ID) AS [Boarding Point Count],
                                            (SELECT COUNT(ID) FROM [Arrival Points Information] WHERE [Route ID] = R.ID) AS [Arrival Point Count]
                                        FROM 
                                            [Route Information] R
                                        INNER JOIN 
                                            [Boarding Points Information] BPI ON R.ID = BPI.[Route ID]
                                        INNER JOIN 
                                            [Arrival Points Information] API ON R.ID = API.[Route ID];";

                    SqlCommand command = new SqlCommand(query, connection);

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        routeID = reader["ID"].ToString();
                        from = reader["From"].ToString();
                        to = reader["To"].ToString();
                        boardingPoint = reader["Boarding Point"].ToString();
                        arrivalPoint = reader["Arrival Point"].ToString();
                        routeCount = Convert.ToInt32(reader["Boarding Point Count"]);
                        boardingPointCount = Convert.ToInt32(reader["Boarding Point Count"]);
                        arrivalPointCount = Convert.ToInt32(reader["Arrival Point Count"]);

                        MessageBox.Show("routeID: " + routeID + "\nboardingPointCount: " + boardingPointCount + "\narrivalPointCount: " + arrivalPointCount);
                        string[] boardingPoints = new string[boardingPointCount];
                        for (int i = 0; i < boardingPointCount; i++)
                        {
                            boardingPoints[i] = reader["Boarding Point"].ToString();
                            // reader.Read();
                        }

                        string[] arrivalPoints = new string[arrivalPointCount];
                        for (int i = 0; i < arrivalPointCount; i++)
                        {
                            arrivalPoints[i] = reader["Arrival Point"].ToString();
                            // reader.Read();
                        }

                        //  MessageBox.Show("routeID: " + routeID + "\nboardingPointCount: " + boardingPointCount + "\narrivalPointCount: " + arrivalPointCount);

                        result_panel.Controls.Clear();
                        RouteInformation office = new RouteInformation(EmployeeID, routeID, from, to, boardingPoints, arrivalPoints);
                        office.Dock = DockStyle.Top;
                        panelContainer.Controls.Add(office);
                        Route_PanelButtonPair pair = addPanel(routeID, from, to, boardingPoints, arrivalPoints);
                        Button selectButton = pair.Button;
                        //Panel panel = pair.Panel;

                        //result_panel.Controls.Add(panel);
                        //selectButton.Tag = new RouteInfo_Tag { RouteID = routeID, From = from, To = to };
                        selectButton.Click += new System.EventHandler(this.selectButton_Click);

                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Class name is Route Selection function name is DataShow and exception: " + ex.Message);
            }

        }

        private void selectButton_Click(object sender, EventArgs e)
        {
            Button selectButton = (Button)sender;
            RouteInfo_Tag tag = (RouteInfo_Tag)selectButton.Tag;
            string routeID = tag.RouteID;
            string from = tag.From;
            string to = tag.To;
            string route = from + " - " + to + "(" + routeID + ")";

            MessageBox.Show("Called");
            this.Hide();
            CreateTicket createTicket = new CreateTicket(EmployeeID, route, from);
            createTicket.Show();
        }


        Route_PanelButtonPair addPanel(string routeID, string from, string to, string[] boardingPoints, string[] arrivalPoints)
        {
            MessageBox.Show("routeID: " + routeID + "\nboardingPointCount: " + boardingPointCount + "\narrivalPointCount: " + arrivalPointCount);

            Panel mainPanel = new Panel();
            mainPanel.Size = new Size(653, 168);
            mainPanel.Dock = DockStyle.Top;
            result_panel.Controls.Add(mainPanel);


            Panel panelTitle = new Panel();
            panelTitle.Size = new Size(653, 46);
            panelTitle.Dock = DockStyle.Top;
            mainPanel.Controls.Add(panelTitle);


            Label routeIDLabel = new Label();
            routeIDLabel.Text = "Route ID: " + routeID;
            routeIDLabel.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Regular);
            routeIDLabel.Size = new Size(200, 20);
            routeIDLabel.Location = new Point(12, 12);
            panelTitle.Controls.Add(routeIDLabel);

            Label fromLabel = new Label();
            fromLabel.Text = "From:" + from;
            fromLabel.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Regular);
            fromLabel.Location = new Point(285, 12);
            panelTitle.Controls.Add(fromLabel);

            Label toLabel = new Label();
            toLabel.Text = "To: " + to;
            toLabel.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Regular);
            toLabel.Location = new Point(425, 12);
            panelTitle.Controls.Add(toLabel);

            Button button = new Button();
            button.Text = "Select";
            button.Location = new Point(550, 9);
            button.Font = new Font("Montserrat", 10, FontStyle.Underline);
            panelTitle.Controls.Add(button);

            TableLayoutPanel tableLayoutPanel = new TableLayoutPanel();
            tableLayoutPanel.ColumnCount = 2;
            tableLayoutPanel.RowCount = 1;
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50)); // 50% width for column 1
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50)); // 50% width for column 2

            Panel boardingPanel = new Panel();
            boardingPanel.Dock = DockStyle.Fill;
            boardingPanel.AutoScroll = true;
            tableLayoutPanel.Controls.Add(boardingPanel, 0, 0); // (control, column, row)


            Label boardingTitle = new Label();
            boardingTitle.Text = "Boarding Points";
            boardingTitle.Location = new Point(12, 3);
            boardingTitle.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Underline);
            boardingPanel.Controls.Add(boardingTitle);

            Label[] boardingPoint = new Label[boardingPointCount];

            for (int i = 0; i < boardingPointCount; i++)
            {
                int x = 12, y = 35 + (25 * i);

                boardingPoint[i] = new Label();
                boardingPoint[i].Text = (i + 1) + ". " + boardingPoints[i];
                boardingPoint[i].Location = new Point(x, y);
                boardingPanel.Controls.Add(boardingPoint[i]);
            }

            Panel arrivalPointPanel = new Panel();
            arrivalPointPanel.Dock = DockStyle.Fill;
            arrivalPointPanel.AutoScroll = true;
            tableLayoutPanel.Controls.Add(arrivalPointPanel, 1, 0);


            Label arrivalTitle = new Label();
            arrivalTitle.Text = "Arrival Points";
            arrivalTitle.Location = new Point(12, 3);
            arrivalTitle.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Underline);
            arrivalPointPanel.Controls.Add(boardingTitle);

            Label[] arrivalPoint = new Label[arrivalPointCount];

            for (int i = 0; i < arrivalPointCount; i++)
            {
                int x = 12, y = 35 + (25 * i);

                arrivalPoint[i] = new Label();
                arrivalPoint[i].Text = (i + 1) + ". " + arrivalPoints[i];
                arrivalPoint[i].Location = new Point(x, y);
                arrivalPointPanel.Controls.Add(arrivalPoint[i]);
            }




            Route_PanelButtonPair pair = new Route_PanelButtonPair
            {
                Panel = mainPanel,
                Button = button
            };

            return pair;

        }

        private void Design()
        {
            Panel titlePanel = new Panel();
            titlePanel.Size = new Size(655, 70);
            titlePanel.Dock = DockStyle.Top;
            panel.Controls.Add(titlePanel);

            Label title = new Label();
            title.Text = "Route Information";
            title.Font = new Font("Montserrat", 20);
            title.Location = new Point(titlePanel.Size.Width / 2, titlePanel.Size.Height / 2);
            titlePanel.Controls.Add(title);

            for (int i = 1; i <= routeCount; i++)
            {
                Panel panel1 = new Panel();
                panel1.Size = new Size(656, 45);
                panel1.Dock = DockStyle.Top;
                panel.Controls.Add(panel1);

                Label idLabel = new Label();
                idLabel.Text = "Route ID: " + routeID;
                idLabel.Size = new Size(200, 20);
                idLabel.Font = new Font("Montserrat", 12);
                idLabel.Location = new Point(12, 12);
                panel1.Controls.Add(idLabel);

                Label fromLabel = new Label();
                fromLabel.Text = "From: " + from;
                fromLabel.Font = new Font("Montserrat", 12);
                fromLabel.Location = new Point(300, 12);
                panel1.Controls.Add(fromLabel);

                Label toLabel = new Label();
                toLabel.Text = "To: " + to;
                toLabel.Font = new Font("Montserrat", 12);
                toLabel.Location = new Point(12, 12);
                panel1.Controls.Add(toLabel);

                Button button = new Button();
                button.Text = "Select";
                button.Size = new Size(75, 30);
                button.Tag = routeID; // Store route ID in the button's Tag property
                button.Click += SelectButton_Click;
                panel1.Controls.Add(button);

                TableLayoutPanel tableLayoutPanel = new TableLayoutPanel();
                tableLayoutPanel.Size = new Size(656, 140);
                tableLayoutPanel.Dock = DockStyle.Top;
                tableLayoutPanel.ColumnCount = 2;
                tableLayoutPanel.RowCount = 1;

                Panel boardingPanel = new Panel();
                boardingPanel.Dock = DockStyle.Fill;
                boardingPanel.AutoScroll = true;
                tableLayoutPanel.Controls.Add(boardingPanel, 0, 0); // Adding to row 0, column 1


                Label boardingPointTitle = new Label();
                boardingPointTitle.Text = "Boarding Points";
                boardingPointTitle.Font = new Font("Montserrat", 12, FontStyle.Underline);
                boardingPointTitle.Location = new Point(10, 3);
                boardingPanel.Controls.Add(boardingPointTitle);

                int axisX = 15, axisY = 35;
                for (int j = 1; j <= boardingPointCount; j++)
                {
                    Label boardingPointLabel = new Label();
                    boardingPointLabel.Text = j + ". " + boardingPoint;
                    boardingPointLabel.Location = new Point(axisX, axisY);
                    boardingPanel.Controls.Add(boardingPointLabel);

                }


                Panel arrivalPanel = new Panel();
                arrivalPanel.Dock = DockStyle.Fill;
                arrivalPanel.AutoScroll = true;
                tableLayoutPanel.Controls.Add(arrivalPanel, 0, 1); // Adding to row 0, column 1


                Label arrivalPointTitle = new Label();
                arrivalPointTitle.Text = "Arrival Points";
                arrivalPointTitle.Font = new Font("Montserrat", 12, FontStyle.Underline);
                arrivalPointTitle.Location = new Point(10, 3);
                arrivalPanel.Controls.Add(arrivalPointTitle);

                for (int j = 1; j <= arrivalPointCount; j++)
                {
                    Label arrivalPointLabel = new Label();
                    arrivalPointLabel.Text = j + ". " + arrivalPoint;
                    arrivalPointLabel.Location = new Point(axisX, axisY);
                    arrivalPanel.Controls.Add(arrivalPointLabel);

                }

            }

        }

        private void SelectButton_Click(object sender, EventArgs e)
        {
            if (sender is Button selectButton)
            {
                // Retrieve the stored route ID from the Tag property of the button
                string selectedRouteID = selectButton.Tag.ToString();
                MessageBox.Show($"Selected Route ID: {selectedRouteID}");

            }
        }
    }
}
