using Guna.UI2.WinForms;
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
    public partial class Tv : UserControl
    {
        public Tv()
        {
            InitializeComponent();
        }
        int volume = 0;
        private int _id;
        private bool _status;

        public int Id { get => _id; set => _id = value; }
        public bool Status { get => _status; set => _status = value; }

        private void guna2ToggleSwitch2_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2ToggleSwitch2.Checked)
            {
                label5.Text = "ON";
                guna2PictureBox2.Image = Properties.Resources.tv_on;
                volume = 24;
                guna2CircleProgressBar1.Value = volume;

                label8.Text = volume.ToString();
                guna2GradientButton1.Enabled = true;
                guna2GradientButton2.Enabled = true;
              


                MachineDA.Update_Status(Id.ToString(), 1.ToString());
            }
            else
            {
                label5.Text = "OFF";
                guna2PictureBox2.Image = Properties.Resources.tv;
                volume = 0;
                guna2CircleProgressBar1.Value = volume;

                label8.Text = volume.ToString();
                guna2GradientButton1.Enabled = false;
                guna2GradientButton2.Enabled = false;
                MachineDA.Update_Status(Id.ToString(), 0.ToString());

            }
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            volume++;
            label8.Text = volume.ToString();
            guna2CircleProgressBar1.Value = volume;
        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            volume--;
            label8.Text = volume.ToString();
            guna2CircleProgressBar1.Value = volume;
        }

        private void m7_MouseDown(object sender, MouseEventArgs e)
        {
            this.DoDragDrop(this, DragDropEffects.Copy);
        }

        private void Tv_Load(object sender, EventArgs e)
        {
            if (_status)
            {
                label5.Text = "ON";
                guna2PictureBox2.Image = Properties.Resources.tv_on;
                volume = 24;
                guna2CircleProgressBar1.Value = volume;

                label8.Text = volume.ToString();
                guna2GradientButton1.Enabled = true;
                guna2GradientButton2.Enabled = true;
                guna2ToggleSwitch2.Checked= true;

            }
            else
            {
                label5.Text = "OFF";
                guna2PictureBox2.Image = Properties.Resources.tv;
                volume = 0;
                guna2CircleProgressBar1.Value = volume;

                label8.Text = volume.ToString();
                guna2GradientButton1.Enabled = false;
                guna2GradientButton2.Enabled = false;
                guna2ToggleSwitch2.Checked = false;
              

            }
        }
    }
}
