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
using ZXing;
using static iText.StyledXmlParser.Jsoup.Select.Evaluator;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace VOVO
{
    public partial class AdminDashBoard : UserControl
    {
        private string AdminID;

        private int maleAdmin, femaleAdmin, othersAdmin, maleEmployee, femaleEmployee, othersEmployee, maleDriver, femaleDriver, othersDriver,
                maleConductor, femaleConductor, othersConductor, maleSupervisor, femaleSupervisor, othersSupervisor;
        public AdminDashBoard()
        {
            InitializeComponent();
        }


        public AdminDashBoard(string adminID) : this()
        {
            AdminID = adminID;

            CustomizeDesign();

        }

        private int DateAndTime()
        {
            // string dateAndTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            // 2023-06-14 01:53:39
            DateTime dateAndTimeNow = DateTime.Now;
            int hour = dateAndTimeNow.Hour;

            return hour;
        }

        private string GetTimeOfDayWish()
        {
            int hour = DateAndTime();

            if (hour >= 5 && hour < 12)
                return "Good Morning";

            else if (hour >= 12 && hour < 17)
                return "Good Afternoon";

            else if (hour >= 17 && hour < 20)
                return "Good Evening";

            else
                return "Good Night";
        }

        private void AdminDashBoard_Load(object sender, EventArgs e)
        {
            string wishComment = string.Concat(GetTimeOfDayWish(), " Admin");
            wish.Text = wishComment;
            

        }

      
        private void showSubManu(Panel subManu)
        {
            if (subManu.Visible == false)
                subManu.Visible = true;

            else
                subManu.Visible = false;
        }

        private void CustomizeDesign()
        {
            customer_panel.Visible = false;
        }

        private void customer_data_button_Click(object sender, EventArgs e)
        {
            showSubManu(customer_panel);
        }

        private void employee_data_button_Click(object sender, EventArgs e)
        {
            if(employee_data_panel.Visible == false) 
            {
                employee_data_panel.Visible = true;
            }

            else if (employee_data_panel.Visible == true)
            {
                employee_data_panel.Visible = false;
            }
        }

        private void customer_information_button_Click(object sender, EventArgs e)
        {
            
        }
    


        private void driver_button_Click(object sender, EventArgs e)
        {
            
        }

        private void conductor_button_Click(object sender, EventArgs e)
        {
            
        }

        private void supervisor_button_Click(object sender, EventArgs e)
        {
            
        }
    }
}



