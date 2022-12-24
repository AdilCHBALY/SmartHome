using SmartHome.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartHome
{
    public partial class logs : Form
    {
        public logs()
        {
            InitializeComponent();
        }



        private void Display()
        {
            String q = "SELECT Date,Transaction FROM domitique.logs";
            DBHelper.DisplayInGrid(q,guna2DataGridView1);
        }

        private void logs_Load(object sender, EventArgs e)
        {
            Display();
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
