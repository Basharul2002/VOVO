using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using Twilio.Rest.Messaging.V1.Service;

namespace VOVO
{
    

    public static class FormControlsUtility
    {
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(IntPtr one, int two, int three, int four);

        public static void AttachDraggableTitleBar(Control control)
        {
            control.MouseDown += (sender, e) =>
            {
                ReleaseCapture();
                SendMessage(control.FindForm().Handle, 0x112, 0xf012, 0);
            };
        }
/*
        private void closeButton_Click(Object sender, EventArgs e)
        {
            Application.Exit();
        }
*/
        public static void ConfigureCloseButton(Button closeButton)
        {
            closeButton.Click += (sender, e) => Application.Exit();

            closeButton.MouseEnter += (sender, e) =>
            {
                closeButton.ForeColor = Color.White;
                closeButton.BackColor = Color.Red;
            };
            closeButton.MouseLeave += (sender, e) => closeButton.BackColor = Color.Transparent;
        }

        public static void ConfigureMaximizeButton(Button maximizeButton, Button maximizedButton)
        {
            maximizeButton.Click += (sender, e) =>
            {
                var form = maximizeButton.FindForm();
                form.WindowState = FormWindowState.Maximized;
                CustomDesign(form);

                maximizeButton.Visible = false;
                maximizedButton.Location = maximizeButton.Location;
                maximizedButton.Visible = true;
            };

            maximizeButton.MouseEnter += (sender, e) =>
            {
                maximizeButton.ForeColor = Color.DarkSalmon;
                maximizeButton.BackColor = Color.DarkSalmon;
            };

            maximizeButton.MouseLeave += (sender, e) => maximizeButton.BackColor = Color.Transparent;
        }

        public static void ConfigureMinimizeButton(Button minimizeButton)
        {
            minimizeButton.Click += (sender, e) => minimizeButton.FindForm().WindowState = FormWindowState.Minimized;

            minimizeButton.MouseEnter += (sender, e) =>
            {
                minimizeButton.ForeColor = Color.DarkSalmon;
                minimizeButton.BackColor = Color.DarkSalmon;
            };

            minimizeButton.MouseLeave += (sender, e) => minimizeButton.BackColor = Color.Transparent;
        }


        public static void ConfigureMaximizedButton(Button maximizeButton, Button maximizedButton)
        {
            maximizedButton.Click += (sender, e) =>
            {
                var form = maximizedButton.FindForm();
                form.WindowState = FormWindowState.Normal;
                CustomDesign(form);

                maximizeButton.Visible = true;
                maximizedButton.Visible = false;
            };

            maximizedButton.MouseEnter += (sender, e) =>
            {
                maximizedButton.ForeColor = Color.DarkSalmon;
                maximizedButton.BackColor = Color.DarkSalmon;
            };

            maximizedButton.MouseLeave += (sender, e) => maximizedButton.BackColor = Color.Transparent;
        }

        public static void ConfigureFormResize(Form form)
        {
            form.Resize += (sender, e) =>
            {
                form.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, form.Width, form.Height, 20, 20));
            };
        }

        private static void CustomDesign(Form form)
        {
            // Custom design logic here
        }

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private extern static IntPtr CreateRoundRectRgn(int left, int top, int right, int bottom, int width, int height);

    }

}
