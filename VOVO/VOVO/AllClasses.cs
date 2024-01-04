using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VOVO
{
    public class CompanyInfo
    {
        public string ID { get; set; }
        public string Name { get; set; }
    }

    public class Branch
    {
        public string ID { get; set; }
        public string Name { get; set; }
    }

    public class CustomDataType_CustomerFound_CustomerIDNameEmailPhoneNumber
    {
        public bool Found { set; get; }
        public string ID { set; get; }
        public string Name { set; get; }
        public string Email { get; set;}
        public string CountryCode { get; set;}
        public string PhoneNumber { set; get; }

    }

    public class CustomerData
    {
        public string CustomerID { set; get; }
        public string Name { get; set; }
        public string CountryCode { get; set; } 
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }


    public class CustomerBusTicketPanelButtonPair
    {
        public Panel Panel { get; set; }
        public Button Button { get; set; }
    }

    public class TicketData
    {
        public string SeatNumber { get; set; }
        public bool Sold { get; set; }
    }

    public class BoardingLastPointPair
    {
        public int AxisX { get; set; }
        public int AxisY { get; set; }
    }
    //
    // Route Selection From
    //
    public class Route_PanelButtonPair
    {
        public Panel Panel { set; get; }
        public Button Button { get; set; }
        
    }
    //
    // Route Selection From
    //
    public class RouteInfo_Tag
    {
        public string RouteID { set; get; }
        public string From { set; get; }
        public string To { set; get; }
    }

    public class BusTypeTicketID_Tag
    {
        public string BusType { set; get; }
        public string ComapanyName { set; get; }
        public string TicketID { set; get; }
    }
    //
    // Class --> BusInfromation
    //Function --> showingData
    //
    public class BusData
    {
        public string Name { set; get; }
        public string RegistrationNumber { set; get; }
        public string CompanyName { set; get; }
    }
    //
    // EmployeeInformation
    // 
    public class EmployeeData
    {
        public string ID { set; get; }
        public Image Image { set; get; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }


}
