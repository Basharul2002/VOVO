using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VOVO
{
    public partial class OnlineBankingPayment : Form
    {
        private string BankName { set; get; }
        private double Fare { set; get; }


        public OnlineBankingPayment()
        {
            InitializeComponent();
            FormControlsUtility.ConfigureFormResize(this);
        }

       

        public OnlineBankingPayment(string bankNam, double fare) : this()
        {
            BankName = bankNam;
            Fare = fare;

            Design();
        }

        private void Design()
        {
            Equipment equipment = new Equipment();
            if(BankName == "BRAC Bank Limited")
            {
                bank_logo.Image = equipment.ResizeImage(Properties.Resources.BracBank, 450, 110);
                bank_logo.SizeMode = PictureBoxSizeMode.CenterImage;
            }
        }

        private void OnlineBankingPayment_SizeChanged(object sender, EventArgs e)
        {
            FormControlsUtility.ConfigureFormResize(this);
        }
    }
}
