using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartHome.MachineControlers
{
    public partial class Zone_ico : UserControl
    {
        public Zone_ico()
        {
            InitializeComponent();
        }
        private int _id;
        private String _name;
        private string _image;


        public string Name1 { get => label4.Text; set => label4.Text = value; }
        public string Image { get => _image; set => _image = value; }
        public int Id { get => _id; set => _id = value; }

        private void m7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Zone_ico_Load(object sender, EventArgs e)
        {
            if (_image == "Kitchen")
            {
               guna2PictureBox1.Image = global::SmartHome.Properties.Resources.kitchen;
            }
            if (_image == "BedRoom")
            {
                guna2PictureBox1.Image = global::SmartHome.Properties.Resources.lit;
            }
            if (_image == "BathRoom")
            {
                guna2PictureBox1.Image = global::SmartHome.Properties.Resources.baignoire;
            }
            if (_image == "Foyer")
            {
                guna2PictureBox1.Image = global::SmartHome.Properties.Resources.hanger;
            }
            if (_image == "DiningRoom")
            {
                guna2PictureBox1.Image = global::SmartHome.Properties.Resources.dining_table;
            }
        }
    }
}
