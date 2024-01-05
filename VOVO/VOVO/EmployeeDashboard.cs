using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tensorflow.Operations.Activation;

namespace VOVO
{
    public partial class EmployeeDashboard : UserControl
    {
        private string EmployeeID { set; get; }
        public EmployeeDashboard()
        {
            InitializeComponent();
        }

        public EmployeeDashboard(string employeeID) : this()
        {
            EmployeeID = employeeID;
            Custom();
        }

        private void Custom()
        {
            string wishComment = GetTimeOfDayWish() + " Employee";
            wish.Text = wishComment;
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

    }
}
