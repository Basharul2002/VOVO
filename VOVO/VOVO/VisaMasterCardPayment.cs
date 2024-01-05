using CustomControls.CustomControls;
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
    public partial class VisaMasterCardPayment : Form
    {
        public VisaMasterCardPayment()
        {
            InitializeComponent();
            CustomDesign();
            TabStop();
            FormControlsUtility.ConfigureFormResize(this);
        }

        // Rounded Corners  




        private void border_panel_MouseDown(object sender, MouseEventArgs e)
        {

            FormControlsUtility.AttachDraggableTitleBar(top_border_panel);

        }

        private void CustomDesign()
        {
            this.FormBorderStyle = FormBorderStyle.None;

            maximized_btn.Visible = false;
            Equipment equipment = new Equipment();
            icon.Image = equipment.ResizeImage(VOVO.Properties.Resources.Bus2, icon.Width, icon.Height);
        }

        private void TabStop()
        {
            card_number_tb.TabStop = false;
            card_holder_name_tb.TabStop = false;
            expiry_date_tb.TabStop = false;
            cvv_code_tb.TabStop = false;
        }


        private void Surface_Click(object sender, EventArgs e)
        {
            // Set the focus on the internal TextBox control manually
            card_number_tb.Focus();
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
            FormControlsUtility.ConfigureMaximizeButton(maximize_btn, maximized_btn);
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

        private void VisaMasterCardPayment_Load(object sender, EventArgs e)
        {
            CustomDesign();
        }

        private void submit_button_Click(object sender, EventArgs e)
        {
            // Get the current TextBox text and remove any spaces.
            string cardNumber = card_number_tb.Text.Replace(" ", "");
        }

        private void card_number_tb_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check if the pressed key is a digit (0-9).
            if (char.IsDigit(e.KeyChar))
            {
                // Get the current TextBox text and remove any spaces.
                string text = card_number_tb.Text;

                // Insert a space after every 4 digits.
                if (text.Length % 5 == 0 && text.Length < 20)
                {
                    card_number_tb.Text += " ";
                    // Set the cursor position to the end of the TextBox.
                    card_number_tb.SelectionStart = card_number_tb.Text.Length;
                }
                card_number.Text = card_number_tb.Text;
            }

            // Allow only digits and the backspace key.
            else if (!char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Ignore the key press.
            }
        }


        private void card_holder_name_tb_TextChanged(object sender, KeyPressEventArgs e)
        {
            card_holder_name.Text = card_holder_name_tb.Text;
        }


        private void expiry_date_tb_TextChanged(object sender, KeyPressEventArgs e)
        {
            expiry_date.Text = expiry_date_tb.Text;
        }

        private void cvv_code_tb_TextChanged(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {

            }

            else
            {
                e.Handled = true;
            }
        }

        private void card_number_tb_TextChanged(object sender, EventArgs e)
        {

            card_number.Text = card_number_tb.Text;
        }

        private void card_holder_name_tb__TextChanged(object sender, EventArgs e)
        {
            card_holder_name.Text = card_holder_name_tb.Text;
        }

        private void expiry_date_tb__TextChanged(object sender, EventArgs e)
        {
            expiry_date.Text = expiry_date_tb.Text;
        }


        private void VisaMasterCardPayment_SizeChanged(object sender, EventArgs e)
        {
            FormControlsUtility.ConfigureFormResize(this);

        }

        private void card_holder_name_tb_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
