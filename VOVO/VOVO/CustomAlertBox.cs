using System;
using System.Drawing;
using System.Windows.Forms;
using VOVO.Properties;

namespace VOVO
{
    public partial class CustomAlertBox : Form
    {
        public CustomAlertBox()
        {
            InitializeComponent();
        }

        public enum enmAction
        {
            wait,
            start,
            close
        }

        public enum enmType
        {
            Success,
            Warning,
            Error,
            Info
        }

        private CustomAlertBox.enmAction action;
        private int x, y;

        public void ShowAlert(string msg, enmType type)
        {
            this.Opacity = 0.0;
            this.StartPosition = FormStartPosition.Manual;
            string fname;

            for (int i = 1; i < 10; i++)
            {
                fname = "alert" + i.ToString();
                CustomAlertBox frm = (CustomAlertBox)Application.OpenForms[fname];

                if (frm == null)
                {
                    this.Name = fname;
                    this.x = Screen.PrimaryScreen.WorkingArea.Width - this.Width + 15;
                    this.y = Screen.PrimaryScreen.WorkingArea.Height - this.Height * i - 5 * i;
                    this.Location = new Point(this.x, this.y);
                    break;
                }
            }

            this.x = Screen.PrimaryScreen.WorkingArea.Width - base.Width - 5;

            switch (type)
            {
                /*case enmType.Success:
                    this.icon_button.Image = Resources.;
                    this.BackColor = Color.SeaGreen;
                    break;*/
                case enmType.Error:
                    this.icon_button.Image = Resources.error;
                    this.BackColor = Color.DarkRed;
                    break;

                case enmType.Info:
                    this.icon_button.Image = Resources.info;
                    this.BackColor = Color.RoyalBlue;
                    break;

                case enmType.Warning:
                    this.icon_button.Image = Resources.home;
                    this.BackColor = Color.DarkOrange;
                    break;
            }

            this.message_text.Text = msg;
            this.Show();
            this.action = enmAction.start;
            this.timer1.Interval = 1;
            this.timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            switch (this.action)
            {
                case enmAction.wait:
                    timer1.Interval = 5000;
                    action = enmAction.close;
                    break;
                case CustomAlertBox.enmAction.start:
                    this.timer1.Interval = 1;
                    this.Opacity += 0.1;
                    if (this.x < this.Location.X)
                    {
                        this.Left--;
                    }

                    else
                    {
                        if (this.Opacity == 1.0)
                        {
                            action = CustomAlertBox.enmAction.wait;
                        }
                    }
                    break;

                case enmAction.close:
                    timer1.Interval = 1;
                    this.Opacity -= 0.1;
                    this.Left -= 3;
                    if (base.Opacity == 0.0)
                    {
                        base.Close();
                    }
                    break;
            }
        }

        public void Alert(string msg, CustomAlertBox.enmType type)
        {
            CustomAlertBox customAlertBox = new CustomAlertBox();
            customAlertBox.ShowAlert(msg, type);
        }
    }
}
