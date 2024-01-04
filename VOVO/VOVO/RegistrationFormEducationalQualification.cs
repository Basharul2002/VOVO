using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Xml.Linq;

namespace VOVO
{
    public partial class RegistrationFormEducationalQualification : UserControl
    {
        // RegistrationPersonalInfo Form
        private string AdminID { set; get; }
        private string Type { set; get; }
        private Image Picture { get; set; }
        private string Id { get; set; }
        private string Name { get; set; }
        private string Email { get; set; }
        private string ContactNumber { get; set; }
        private string Address { get; set; }
        private string Gender { get; set; }
        private string Dob { get; set; }
        private string Nationality { get; set; }
        private string NidNumber { get; set; }
        private string Experience { get; set; }



        public RegistrationFormEducationalQualification(string adminID, string type, Image picture, string id, string name, string email, string contactNumber, string address, string gender, string dob, string nationality, string nidNumber, string experience)
        {
            InitializeComponent();

            // Assign parameter values to corresponding properties
            AdminID = adminID;
            Type = type;
            Picture = picture;
            Id = id;
            Name = name;
            Email = email;
            ContactNumber = contactNumber;
            Address = address;
            Gender = gender;
            Dob = dob;
            Nationality = nationality;
            NidNumber = nidNumber;
            Experience = experience;

            customizeDesign();
        }


        private void customizeDesign()
        {
            exam1_panel.Visible = false;
            exam2_panel.Visible = false;
            exam3_panel.Visible = false;

            if (Type == "Supervisor")
            {
                exam3_button.Visible = false;
            }

            else if (Type == "Driver")
            {
                exam2_button.Visible = false;
                exam3_button.Visible = false;
            }

            else if (Type == "Supervisor")
            {
                exam3_button.Visible = false;
            }
        }


        private void hidePanel()
        {
            if (exam1_panel.Visible == true)
            {
                exam1_panel.Visible = false;
            }

            if (exam2_panel.Visible == true)
            {
                exam2_panel.Visible = false;

            }

            if (exam3_panel.Visible == true)
            {
                exam3_panel.Visible = false;
            }
        }


        private void showSubManu(Panel subManu)
        {
            if (subManu.Visible == false)
            {
                hidePanel();
                subManu.Visible = true;
            }

            else
            {
                subManu.Visible = false;
            }
        }

  
        private void nextButtonEvent()
        {
            // SSC/Dakhil/Equivalent
            string exam1Name = exam1_name_tb.Texts;
            string exam1Board = exam1_board_name_tb.Texts;
            string exam1Result = exam1_result_tb.Texts;
            string exam1RegistrationNumber = exam1_reg_number_tb.Texts;
            string exam1RollNumber = exam1_roll_number_tb.Texts;
            //
            // HSC/Alim/Equivalent
            //
            string exam2Name = exam2_name_tb.Texts;
            string exam2Board = exam2_board_name_tb.Texts;
            string exam2Result = exam2_result_tb.Texts;
            string exam2RegistrationNumber = exam2_reg_number_tb.Texts;
            string exam2RollNumber = exam2_roll_number_tb.Texts;
            //
            // Honors/Diploma
            //
            string exam3InstitutionName = exam3_institution_name_tb.Texts;
            string exam3RollNumber = exam3_institution_roll_number_tb.Texts;
            string exam3DegreeName = exam3_degree_name_tb.Texts;
            string exam3Subject = exam3_subject_tb.Texts;
            string exam3Result = exam3_result_tb.Texts;
            

            if (Type == "Admin" || Type == "Employee")
            {
                if (exam3DegreeName == "Diploma")
                {
                    if (string.IsNullOrEmpty(exam1Name) || string.IsNullOrEmpty(exam1Board) || string.IsNullOrEmpty(exam1Result) || string.IsNullOrEmpty(exam1RegistrationNumber) || string.IsNullOrEmpty(exam1RollNumber) ||
                        string.IsNullOrEmpty(exam3InstitutionName) || string.IsNullOrEmpty(exam3RollNumber) || string.IsNullOrEmpty(exam3DegreeName) || string.IsNullOrEmpty(exam3Subject) || string.IsNullOrEmpty(exam3Result))
                    {
                        MessageBox.Show("Please fill in all required fields");
                    }


                    else if (!string.IsNullOrEmpty(exam1Name) || !string.IsNullOrEmpty(exam1Board) || !string.IsNullOrEmpty(exam1Result) || !string.IsNullOrEmpty(exam1RegistrationNumber) || !string.IsNullOrEmpty(exam1RollNumber) ||
                             !string.IsNullOrEmpty(exam3InstitutionName) || !string.IsNullOrEmpty(exam3RollNumber) || !string.IsNullOrEmpty(exam3DegreeName) || !string.IsNullOrEmpty(exam3Subject) || !string.IsNullOrEmpty(exam3Result))
                    {
                        if (!AdminForm.Instance.panelContainer.Controls.ContainsKey("RegistrationInformation") && (Type == "Admin" || Type == "Employee"))
                        {
                            AdminForm.Instance.panelContainer.Controls.Clear();
                            RegistrationInformation registrationInformation = new RegistrationInformation(adminID: AdminID, type: Type, picture: Picture, id: Id, name: Name, email: Email, contactNumber: ContactNumber, address: Address, gender: Gender, 
                                 Dob, Nationality, NidNumber, Experience, exam1Name, exam1Board, exam1RegistrationNumber, exam1RollNumber, exam1Result, 
                                 exam3InstitutionName: exam3InstitutionName, exam3RollNumber: exam3RollNumber, exam3DegreeName: exam3DegreeName, exam3SubjectName: exam3Subject, exam3Result: exam3Result); ;
                            registrationInformation.Dock = DockStyle.Fill;
                            AdminForm.Instance.panelContainer.Controls.Add(registrationInformation);
                        }
                    }

                }

                // Admin --> SSC/HSC/Degree
                else
                {
                    if (string.IsNullOrEmpty(exam1Name) || string.IsNullOrEmpty(exam1Board) || string.IsNullOrEmpty(exam1RegistrationNumber) || string.IsNullOrEmpty(exam1RollNumber) || string.IsNullOrEmpty(exam1Result) ||
                        string.IsNullOrEmpty(exam2Name) || string.IsNullOrEmpty(exam2Board) || string.IsNullOrEmpty(exam2RegistrationNumber) || string.IsNullOrEmpty(exam2RollNumber) || string.IsNullOrEmpty(exam2Result) ||
                        string.IsNullOrEmpty(exam3InstitutionName) || string.IsNullOrEmpty(exam3RollNumber) || string.IsNullOrEmpty(exam3DegreeName) || string.IsNullOrEmpty(exam3Subject) || string.IsNullOrEmpty(exam3Result))
                    {
                        MessageBox.Show("Please fill in all required fields");
                    }

                    else if (!string.IsNullOrEmpty(exam1Name) || !string.IsNullOrEmpty(exam1Board) || !string.IsNullOrEmpty(exam1RegistrationNumber) || !string.IsNullOrEmpty(exam1RollNumber) || !string.IsNullOrEmpty(exam1Result) ||
                             !string.IsNullOrEmpty(exam2Name) || !string.IsNullOrEmpty(exam2Board) || !string.IsNullOrEmpty(exam2RegistrationNumber) || !string.IsNullOrEmpty(exam2RollNumber) || !string.IsNullOrEmpty(exam2Result) ||
                             !string.IsNullOrEmpty(exam3InstitutionName) || !string.IsNullOrEmpty(exam3RollNumber) || !string.IsNullOrEmpty(exam3DegreeName) || !string.IsNullOrEmpty(exam3Subject) || !string.IsNullOrEmpty(exam3Result))
                    {
                        this.Hide();

                        if (!AdminForm.Instance.panelContainer.Controls.ContainsKey("RegistrationInformation") && (Type == "Admin" || Type == "Employee"))
                        {
                            AdminForm.Instance.panelContainer.Controls.Clear();
                            RegistrationInformation registrationInformation = new RegistrationInformation(AdminID, Type, Picture, Id, Name, Email, ContactNumber, Address, Gender, 
                                Dob, Nationality, NidNumber, Experience, exam1Name, exam1Board, exam1RegistrationNumber, exam1RollNumber, exam1Result, exam2Name, exam2Board, 
                                exam2RegistrationNumber, exam2RollNumber, exam2Result, exam3InstitutionName, exam3RollNumber, exam3DegreeName, exam3Subject, exam3Result);

                            registrationInformation.Dock = DockStyle.Fill;
                            AdminForm.Instance.panelContainer.Controls.Add(registrationInformation);
                        }
                    }
                }


            }
            

            else if (Type == "Driver")
            {
                if (string.IsNullOrEmpty(exam1Name) || string.IsNullOrEmpty(exam1Board) || string.IsNullOrEmpty(exam1RegistrationNumber) || string.IsNullOrEmpty(exam1RollNumber) || string.IsNullOrEmpty(exam1Result) )
                {
                    MessageBox.Show("Please fill in all required fields");

                }

                else if (!string.IsNullOrEmpty(exam1Name) || !string.IsNullOrEmpty(exam1Board) || !string.IsNullOrEmpty(exam1RegistrationNumber) || !string.IsNullOrEmpty(exam1RollNumber) || !string.IsNullOrEmpty(exam1Result))
                {
                    if (!AdminForm.Instance.panelContainer.Controls.ContainsKey("DriverRegistration") && Type == "Driver")
                    {
                        AdminForm.Instance.panelContainer.Controls.Clear();
                        DriverRegistration driverRegistration = new DriverRegistration(AdminID, Type, Picture, Id, Name, Email, ContactNumber, Address, Gender, Dob, Nationality, NidNumber, Experience, exam1Name, exam1Board, exam1RegistrationNumber, exam1RollNumber, exam1Result);
                        driverRegistration.Dock = DockStyle.Fill;
                        AdminForm.Instance.panelContainer.Controls.Add(driverRegistration);
                    }
                }
            }

            else if(Type == "Supervisor")
            {
                if (string.IsNullOrEmpty(exam1Name) || string.IsNullOrEmpty(exam1Board) || string.IsNullOrEmpty(exam1Result) || string.IsNullOrEmpty(exam1RegistrationNumber) || string.IsNullOrEmpty(exam1RollNumber) || string.IsNullOrEmpty(exam2Name) || string.IsNullOrEmpty(exam2Board) || string.IsNullOrEmpty(exam2Result) || string.IsNullOrEmpty(exam2RegistrationNumber) || string.IsNullOrEmpty(exam2RollNumber) )
                {
                    MessageBox.Show("Please fill in all required fields");

                }

                else if (!string.IsNullOrEmpty(exam1Name) || !string.IsNullOrEmpty(exam1Board) || !string.IsNullOrEmpty(exam1Result) || !string.IsNullOrEmpty(exam1RegistrationNumber) || !string.IsNullOrEmpty(exam1RollNumber) || !string.IsNullOrEmpty(exam2Name) || !string.IsNullOrEmpty(exam2Board) || !string.IsNullOrEmpty(exam2Result) || !string.IsNullOrEmpty(exam2RegistrationNumber) || !string.IsNullOrEmpty(exam2RollNumber))
                {
                    if (!AdminForm.Instance.panelContainer.Controls.ContainsKey("RegistrationInformation") && Type == "Supervisor")
                    {
                        AdminForm.Instance.panelContainer.Controls.Clear();
                        RegistrationInformation registrationInformation = new RegistrationInformation(AdminID, Type, Picture, Id, Name, Email, ContactNumber, Address, Gender, Dob, Nationality, NidNumber, Experience, exam1Name, exam1Board, exam1RegistrationNumber, exam1RollNumber, exam1Result, exam2Name, exam2Board, exam2RegistrationNumber, exam2RollNumber, exam2Result, "Supervisor", "Supervisor");
                        registrationInformation.Dock = DockStyle.Fill;
                        AdminForm.Instance.panelContainer.Controls.Add(registrationInformation);
                    }
                }
            }
        }


        private void exam1_button_Click(object sender, EventArgs e)
        {
            showSubManu(exam1_panel);
        }

        private void exam2_button_Click(object sender, EventArgs e)
        {
            showSubManu(exam2_panel);
        }

        private void exam3_button_Click(object sender, EventArgs e)
        {
            showSubManu(exam3_panel);
        }


        private void next_button_Click(object sender, EventArgs e)
        {
            nextButtonEvent();
        }

    }
}
