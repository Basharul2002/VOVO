using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VOVO
{
    public partial class AdminSearch : MetroFramework.Forms.MetroForm
    {
        public string operation;
        public string SearchResult { get; private set; }

        public AdminSearch()
        {
            InitializeComponent();
        }

        public AdminSearch(string operation) : this()
        {
            this.operation = operation;
        }

        private void Operation_button_Click(object sender, EventArgs e)
        {
            string data = search_box_tb.Text;

            if(string.IsNullOrWhiteSpace(data))
            {
                MessageBox.Show("Please fill the box", "VOVO");
                return;
            }

            this.Hide();
            SearchResult = data;
        }
    }
}
