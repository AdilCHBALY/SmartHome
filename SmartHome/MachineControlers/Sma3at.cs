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

namespace SmartHome.MachineControlers
{
    public partial class Sma3at : UserControl
    {
        public Sma3at()
        {
            InitializeComponent();
        }

        private int _id;
        private bool _status;

        public int Id { get => _id; set => _id = value; }
        public bool Status { get => _status; set => _status = value; }

        private void guna2GradientButton6_Click(object sender, EventArgs e)
        {
            guna2CircleProgressBar3.Value++;
        }

        private void guna2GradientButton5_Click(object sender, EventArgs e)
        {
            guna2CircleProgressBar3.Value--;
        }

        private void guna2ToggleSwitch8_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2ToggleSwitch8.Checked)
            {
                guna2PictureBox7.Image = Properties.Resources.woofer_on;
                guna2GradientButton6.Enabled = true;
                guna2GradientButton5.Enabled = true;
                MachineDA.Update_Status(Id.ToString(), 1.ToString());


            }
            else
            {
                guna2PictureBox7.Image = Properties.Resources.woofer;
                guna2GradientButton6.Enabled = false;
                guna2GradientButton5.Enabled = false;
                MachineDA.Update_Status(Id.ToString(), 0.ToString());
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (guna2ImageCheckBox1.Checked  && guna2ToggleSwitch8.Checked)
            {
                bunifuProgressBar1.Value++;
            }
        }

        private void guna2ImageCheckBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void m2_MouseDown(object sender, MouseEventArgs e)
        {
            this.DoDragDrop(this, DragDropEffects.Copy);
        }

        private void Sma3at_Load(object sender, EventArgs e)
        {
            if (_status)
            {
                guna2PictureBox7.Image = Properties.Resources.woofer_on;
                guna2GradientButton6.Enabled = true;
                guna2GradientButton5.Enabled = true;
                guna2ToggleSwitch8.Checked= true;


            }
            else
            {
                guna2PictureBox7.Image = Properties.Resources.woofer;
                guna2GradientButton6.Enabled = false;
                guna2GradientButton5.Enabled = false;
                guna2ToggleSwitch8.Checked = false;
            }
        }
    }
}
