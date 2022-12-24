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
    public partial class Tlaja : UserControl
    {
        public Tlaja()
        {
            InitializeComponent();
        }
        private int _id;
        private bool _status;
        int degree = 6;

        public int Id { get => _id; set => _id = value; }
        public bool Status { get => _status; set => _status = value; }

        private void guna2ImageCheckBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void guna2ImageCheckBox3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void guna2GradientButton7_Click(object sender, EventArgs e)
        {
            degree--;
            guna2CircleProgressBar4.Value = degree;
            label26.Text = degree.ToString() + "°C";
        }

        private void guna2GradientButton8_Click(object sender, EventArgs e)
        {
            degree++;
            guna2CircleProgressBar4.Value = degree;
            label26.Text = degree.ToString() + "°C";
        }

        private void m9_MouseDown(object sender, MouseEventArgs e)
        {
            this.DoDragDrop(this, DragDropEffects.Copy);
        }

        private void m9_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
