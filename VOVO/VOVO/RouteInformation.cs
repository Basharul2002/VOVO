using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Routing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace VOVO
{
    public partial class RouteInformation : UserControl
    {
        private string employeeID, routeID, from, to;
        private string[] boardingPoints, arrivalPoints;


        public RouteInformation()
        {
            InitializeComponent();
        }

        public RouteInformation(string employeeID, string routeID, string from, string to, string[] boardingPoints, string[] arrivalPoints) : this()
        {
            this.employeeID = employeeID;
            this.routeID = routeID;
            this.from = from;
            this.to = to;
            this.boardingPoints = boardingPoints;
            this.arrivalPoints = arrivalPoints;

            Data();
        }


        private void Data()
        {
            route_id_label.Text = "Route ID: " + this.routeID;
            from_label.Text = "From: " + this.from;
            to_label.Text = "To: " + this.to;
            select_button.Tag = new RouteInfo_Tag { RouteID = routeID, From = from, To = to };
            int y = 35;

            boarding_points_panel.Controls.Clear();


            Label boardingTitleLabel = new Label();
            boardingTitleLabel.Text = "Boarding Points";
            boardingTitleLabel.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Bold);
            boardingTitleLabel.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Underline);
            boardingTitleLabel.Location = new Point(5, 3);
            boarding_points_panel.Controls.Add(boardingTitleLabel);


            foreach (string data in boardingPoints)
            {
                Label boardingPointLabel = new Label();
                boardingPointLabel.Text = data;
                boardingPointLabel.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Regular);
                boardingPointLabel.Location = new Point(5, y);
                boarding_points_panel.Controls.Add(boardingPointLabel);
                y += 20;
            }

            arrival_points_panel.Controls.Clear();

            Label arivalPointsTitleLabel = new Label();
            arivalPointsTitleLabel.Text = "Arrival Points";
            arivalPointsTitleLabel.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Bold);
            arivalPointsTitleLabel.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Underline);
            arivalPointsTitleLabel.Location = new Point(5, 3);
            arrival_points_panel.Controls.Add(arivalPointsTitleLabel);

            y = 35;
            foreach (string data in arrivalPoints)
            {
                Label arrivalPointLabel = new Label();
                arrivalPointLabel.Text = data;
                arrivalPointLabel.Location = new Point(5, y);
                arrival_points_panel.Controls.Add(arrivalPointLabel);
                y += 20;
            }
        }

        private void select_button_Click(object sender, EventArgs e)
        {
            Form parentForm = this.FindForm();

            // Check if the parent form is not null and is of type Form
            if (parentForm is Form)
            {
                // Close the parent form
                parentForm.Close();
            }

            Button selectButton = (Button)sender;
            RouteInfo_Tag tag = (RouteInfo_Tag)selectButton.Tag;
            string routeID = tag.RouteID;
            string from = tag.From;
            string to = tag.To;
            string route = from + " - " + to + "(" + routeID + ")";

            CreateTicket createTicket = new CreateTicket(employeeID, route);
            createTicket.Show();

        }



    }
}
