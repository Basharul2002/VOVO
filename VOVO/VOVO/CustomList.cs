using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace VOVO
{
    public partial class CustomList : UserControl
    {
        public CustomList()
        {
            InitializeComponent();
        }

        #region Properties
        private Image image;
        private string title;
        private string message;

        [Category("Behavior")]
        public Image Image
        {
            get { return image; }
            set { image = value; image_box.Image = value; }
        }

        [Category("Behavior")]
        public string Title
        {
            get { return title; }
            set { title = value; title_data.Text = value; }
        }

        [Category("Behavior")]
        public string Message
        {
            get { return message; }
            set { message = value; message_data.Text = value; }
        }
        #endregion

        #region Custom Event
        public event EventHandler CustomListClick;

        private void OnCustomListClick()
        {
            CustomListClick?.Invoke(this, EventArgs.Empty);
        }

        public void CustomList_Click(object sender, EventArgs e)
        {
            OnCustomListClick();
        }
        #endregion
    }
}
