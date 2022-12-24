using SmartHome.DataAdapter;
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
    public partial class Acc_creation : Form
    {
        public Acc_creation()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            String Username = guna2TextBox1.Text;
            String Password = guna2TextBox2.Text;


            AdminDA.Add_User(Username, Password);
            this.Close();
        }
    }
}
