using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace VOVO
{
    public partial class RegistrationFromPersonalInfo : UserControl
    {
        //string connectionString = "Data Source=BASHARUL\\SQLEXPRESS01;Initial Catalog=VOVO;Integrated Security=True";
        private bool qualified;
        private string ID;
        private string AdminID { set; get; }
        private string Type { set; get; }

        public RegistrationFromPersonalInfo()
        {
            InitializeComponent();
            this.AutoScaleMode = AutoScaleMode.Font;

        }

        public RegistrationFromPersonalInfo(string adminID, string type) : this()
        {
            title.Text = type + " Personal Information";
            AdminID = adminID;
            Type = type;
        } 

        private void picure_choose_button_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "JPEG files (*.jpg)|*.jpg|PNG files (*.png)|*.png|All files (*.*)|*.*";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedFile = openFileDialog.FileName;

                    // Perform the necessary actions with the selected file here
                    // For example, you can display the file path in a TextBox:
                    // Load the image from the selected file
                    Image originalImage = Image.FromFile(selectedFile);

                    // Resize the image to fit the PictureBox size
                    Image resizedImage = new Bitmap(originalImage, new Size(130, 130));

                    // Display the resized image in the PictureBox
                    picture_box.Image = resizedImage;

                }
            }
            catch (Exception ex)
            {
                CustomMessageBox.Show(ex.Message, "Picture Error");
            }
        }

        private string GenderSelection()
        {
              string gender = string.Empty;

            if (male_radio_button.Checked == true)
            {
                gender = "Male";

                female_radio_button.Checked = false;
                others_radio_button.Checked = false;
            }

            if (female_radio_button.Checked == true)
            {
                gender = "Female";

                male_radio_button.Checked = false;
                others_radio_button.Checked = false;
            }

            if (others_radio_button.Checked == true)
            {
                gender = "Others";

                male_radio_button.Checked = false;
                female_radio_button.Checked = false;
            }

            if (male_radio_button.Checked == false && female_radio_button.Checked == false && others_radio_button.Checked == false)
            {
                gender = "No Selected";
            }

            return gender;
        }


        private void next_button_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(Type);
            string name = name_tb.Texts;
            string email = email_tb.Texts;
            string countryCode = country_code_combo_box.Text;
            string phoneNumber = phone_number_tb.Texts;
            string address = address_tb.Texts;
            string gender = GenderSelection();
            string dob = dob_tb.Texts;
            string nationality = nationality_tb.Texts;
            string nidNumber = nid_number_tb.Texts;
            string experience = experience_tb.Texts;
            string contactNumber = string.Concat(countryCode, phoneNumber);
            Image picture = picture_box.Image;
            

            ValidityCheck validityCheck = new ValidityCheck();

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(countryCode) || string.IsNullOrEmpty(phoneNumber) || string.IsNullOrEmpty(address) || string.IsNullOrEmpty(dob) || string.IsNullOrEmpty(nationality) || string.IsNullOrEmpty(nidNumber) || string.IsNullOrEmpty(experience))
            {
                CustomMessageBox.Show("Please fill in all required fields");
                return; // Exit the event handler early if any required field is empty
            }

            if (picture == null)
            {
                CustomMessageBox.Show("Please choose a picture");
                return; // Exit the event handler early if no picture is selected
            }

            if (!validityCheck.IsPhoneNumberValid(phoneNumber))
            {
                CustomMessageBox.Show("Phone number invalid");
                return; // Exit the event handler early if phone number is invalid
            }

            if (!validityCheck.IsEmailValid(email))
            {
                CustomMessageBox.Show("Email address invalid");
                return; // Exit the event handler early if email address is invalid
            }

            if (!validityCheck.IsDOBValid(dob))
            {
                CustomMessageBox.Show("Date of Birth invalid");
                return; // Exit the event handler early if Date of Birth is invalid
            }

            if (validityCheck.IsDOBValid(dob))
            {
                Equipment equipment = new Equipment();
                qualified = equipment.qualified(dob.ToString(), Type); // Convert dob to string
            }

            //
            // All validations passed, proceed to the next step
            // Admin Registration
            //
            if (!AdminForm.Instance.panelContainer.Controls.ContainsKey("RegistrationFormEducationalQualification") && (Type == "Admin" || Type == "Employee") && qualified == true)
            {
                // CustomMessageBox.Show(Type + " Registration Form");
                AdminForm.Instance.panelContainer.Controls.Clear();
                RegistrationFormEducationalQualification registrationFormEducationalQualification = new RegistrationFormEducationalQualification(AdminID, Type, picture, ID, name, email, contactNumber, address, gender, dob, nationality, nidNumber, experience);
                registrationFormEducationalQualification.Dock = DockStyle.Fill;
                AdminForm.Instance.panelContainer.Controls.Add(registrationFormEducationalQualification);
            }

            // Driver
            else if (!AdminForm.Instance.panelContainer.Controls.ContainsKey("RegistrationFormEducationalQualification") && Type == "Driver" && qualified == true)
            {
                // CustomMessageBox.Show(Type + " Registration Form");
                AdminForm.Instance.panelContainer.Controls.Clear();
                RegistrationFormEducationalQualification registrationFormEducationalQualification = new RegistrationFormEducationalQualification(AdminID, Type, picture, ID, name, email, contactNumber, address, gender, dob, nationality, nidNumber, experience);
                registrationFormEducationalQualification.Dock = DockStyle.Fill;
                AdminForm.Instance.panelContainer.Controls.Add(registrationFormEducationalQualification);
            }

            // Conductor
            else if (!AdminForm.Instance.panelContainer.Controls.ContainsKey("RegistrationInformation") && Type == "Conductor" && qualified == true)
            {
                // CustomMessageBox.Show(Type, "Registration Form");
                AdminForm.Instance.panelContainer.Controls.Clear();
                // Create an instance of the RegistrationInformation form
                RegistrationInformation registrationInformation = new RegistrationInformation(AdminID, Type, picture, ID, name, email, contactNumber, address, gender, dob, nationality, nidNumber, experience);

                // Set the Dock property to Fill and add it to the panelContainer of AdminForm
                registrationInformation.Dock = DockStyle.Fill;
                AdminForm.Instance.panelContainer.Controls.Add(registrationInformation);
            }
            
            // Supervisor
            else if (!AdminForm.Instance.panelContainer.Controls.ContainsKey("RegistrationFormEducationalQualification") && Type == "Supervisor" && qualified == true)
            {
                // CustomMessageBox.Show(Type + " Registration Form");
                AdminForm.Instance.panelContainer.Controls.Clear();
                RegistrationFormEducationalQualification registrationFormEducationalQualification = new RegistrationFormEducationalQualification(AdminID, Type, picture, ID, name, email, contactNumber, address, gender, dob, nationality, nidNumber, experience);
                registrationFormEducationalQualification.Dock = DockStyle.Fill;
                AdminForm.Instance.panelContainer.Controls.Add(registrationFormEducationalQualification);
            }


            else
            {
               // CustomMessageBox.Show(Type + " can't match");
            }
        }

        private void RegistrationFromPersonalInfo_Load(object sender, EventArgs e)
        {
            Equipment equipment = new Equipment();
            ID = equipment.idGenarator(Type);
            // CustomMessageBox.Show(ID);

            // Allow editing of the customer ID textbox
            id_tb.ReadOnly = false;

            // Set the foreground color of the customer ID textbox to Coral
            id_tb.ForeColor = Color.Coral;
            id_tb.Texts = ID;
        }

        private void clear_button_Click(object sender, EventArgs e)
        {
            // Clear the form fields by calling the function
            FunctionClearContext();
        }

        private void FunctionClearContext()
        {
            name_tb.Texts = "";
            phone_number_tb.Texts = "";
            email_tb.Texts = "";
            address_tb.Texts = "";
            dob_tb.Texts = "";
            nationality_tb.Texts = "";
            nid_number_tb.Texts = "";
            experience_tb.Texts = "";
            male_radio_button.Checked = false;
            female_radio_button.Checked = false;
            others_radio_button.Checked = false;
            picture_box.Image = null;
        }

        private void clear_button_MouseEnter(object sender, EventArgs e)
        {
            clear_button.ForeColor = Color.Black;
        }

        private void clear_button_MouseLeave(object sender, EventArgs e)
        {
            clear_button.ForeColor = Color.FromArgb(128, 255, 255);
        }

        private void next_button_MouseEnter(object sender, EventArgs e)
        {
            next_button.ForeColor = Color.White;
        }

        private void next_button_MouseLeave(object sender, EventArgs e)
        {
            next_button.ForeColor = Color.Black;
        }

    }
}
