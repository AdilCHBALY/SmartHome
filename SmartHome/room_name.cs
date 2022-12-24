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
    public partial class room_name : Form
    {

        rooms parent;

        public room_name(rooms parent)
        {
            InitializeComponent();
            this.parent = parent;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            String name = guna2TextBox1.Text;


            ZoneDA.Add_Zone(name,1.ToString());
            parent.Display();
        }
    }
}
