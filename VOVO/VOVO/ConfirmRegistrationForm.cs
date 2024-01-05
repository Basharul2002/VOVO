using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;  // For printing

// For pdf
using System.IO; // For download
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.ComponentModel.Design;

namespace VOVO
{
    public partial class ConfirmRegistrationForm : UserControl
    {
        private string Id { get; set; }
        private string Name { get; set; }
        private string CompanyName { get; set; }
        private string Type { get; set; }
        private string Password { get; set; }


        public ConfirmRegistrationForm()
        {
            InitializeComponent();

            printDocument.PrintPage += PrintDocument_PrintPage;  // For print
        }
        //
        //Admin
        //
        // ConfirmRegistrationForm confirmRegistrationForm = new ConfirmRegistrationForm(Type, Id, Name, companyID, GenerateCustomPassword(10, true, true, true, true));

        public ConfirmRegistrationForm(string type, string id, string name, string companyName, string password)
        {
            InitializeComponent();

            printDocument.PrintPage += PrintDocument_PrintPage;  // Fro print
            Id = id;
            Name = name;
            CompanyName = companyName;
            Type = type;
            Password = password;
        }


        PrintDocument printDocument = new PrintDocument();

        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {

            // Draw the content to be printed using the Graphics object
            Graphics graphics = e.Graphics;
            // Print Name
            string text1 = string.Concat("Name: ", Name);
            graphics.DrawString(text1, new System.Drawing.Font("Arial", 12), Brushes.Black, new PointF(5, 5));

            // Print ID
            string text2 = string.Concat("ID: ", Id);
            graphics.DrawString(text2, new System.Drawing.Font("Arial", 12), Brushes.Black, new PointF(5, 15));

            // Print Password
            string text3 = string.Concat("Password: ", password_tb.Text);
            graphics.DrawString(text3, new System.Drawing.Font("Arial", 12), Brushes.Black, new PointF(5, 25));

        }


        private void PrintButton_Click(object sender, EventArgs e)
        {
            // Show the print dialog to allow the user to configure print settings
            PrintDialog printDialog = new PrintDialog();
            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                // Set the PrintDocument object as the document to be printed
                printDialog.Document = printDocument;

                // Start the printing process
                printDocument.Print();
            }
        }


        private void download_button_Click(object sender, EventArgs e)
        {
            string userId = Id;
            string name = Name;
            string companyName = CompanyName;
            string jobTitle = Type;
            string password = Password;
            PDFGenerate pdfGenerate = new PDFGenerate();

            byte[] pdf = pdfGenerate.EmployeePDF(userId, name, companyName, jobTitle, password);
            Equipment equipment = new Equipment();
            equipment.pdfDownload(pdf, userId + "(" + name + ")");
        }




        private void print_button_Click(object sender, EventArgs e)
        {
            string userId = Id;
            string name = Name;
            string companyName = CompanyName;
            string jobTitle = Type;
            string password = Password;
            PDFGenerate pdfGenerate = new PDFGenerate();

            byte[] pdf = pdfGenerate.EmployeePDF(userId, name, companyName, jobTitle, password);
            Equipment equipment = new Equipment();
            equipment.PrintPdf(pdf);
        }


        private void ConfirmRegistrationForm_Load(object sender, EventArgs e)
        {
            name_tb.Text = Name;
            id_tb.Text = Id;
            password_tb.Text = Password;
        }

        private void done_button_Click(object sender, EventArgs e)
        {
            if (!AdminForm.Instance.panelContainer.Controls.ContainsKey("AdminDashBoard"))
            {
                AdminForm.Instance.panelContainer.Controls.Clear();
                AdminDashBoard adminDashBoard = new AdminDashBoard(Id);
                adminDashBoard.Dock = DockStyle.Fill;
                AdminForm.Instance.panelContainer.Controls.Add(adminDashBoard);
            }
        }
    }
}
