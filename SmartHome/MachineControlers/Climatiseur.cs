using SmartHome.DataAdapter;
using SmartHome.Models;
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
    public partial class Climatiseur : UserControl
    {
        public Climatiseur()
        {
            InitializeComponent();
        }
        private int _id;
        private bool _status;
        private int degree = 24;
        Admin admin = AdminDA.Get_Connected_id();
        private int i = 0;

        public bool Status { get => guna2ToggleSwitch3.Checked; set => guna2ToggleSwitch3.Checked = value; }
        public int Id { get => _id; set => _id = value; }

        private void guna2ToggleSwitch3_CheckedChanged(object sender, EventArgs e)
        {

            String t = "Climatiseur";
           
            if (guna2ToggleSwitch3.Checked)
            {
                i++;
                guna2PictureBox3.Image = Properties.Resources.ac_on;
                degree = 24;
                guna2CircleProgressBar2.Value = degree;

                label10.Text = "+" + degree.ToString() + " C";
                guna2GradientButton3.Enabled = true;
                guna2GradientButton4.Enabled = true;
                guna2ImageRadioButton1.Enabled = true;
                guna2ImageRadioButton4.Enabled = true;
                guna2ImageRadioButton5.Enabled = true;

                MachineDA.Update_Status(Id.ToString(), 1.ToString());

                t += " Allumée par "+admin.Login;
                DateTime dateTime = DateTime.Now;
                if (i > 1)
                {
                    LogsDA.Insert_Logs(dateTime.ToString(), t);
                }

            }
            else
            {
                i++;
                guna2PictureBox3.Image = Properties.Resources.ac_off;
                degree = 0;
                guna2CircleProgressBar2.Value = degree;

                label10.Text = "+" + degree.ToString() + " C";
                guna2GradientButton3.Enabled = false;
                guna2GradientButton4.Enabled = false;
                guna2ImageRadioButton1.Enabled = false;
                guna2ImageRadioButton4.Enabled = false;
                guna2ImageRadioButton5.Enabled = false;

                MachineDA.Update_Status(Id.ToString(), 0.ToString());
                t += " Eteinte par " + admin.Login;
                DateTime dateTime = DateTime.Now;
                if (i > 1)
                {
                    LogsDA.Insert_Logs(dateTime.ToString(), t);
                }
            }
        }

        private void guna2GradientButton4_Click(object sender, EventArgs e)
        {
            degree += 1;
            guna2CircleProgressBar2.Value = degree;

            label10.Text = "+" + degree.ToString() + " C";
        }

        private void guna2GradientButton3_Click(object sender, EventArgs e)
        {
            degree--;
            guna2CircleProgressBar2.Value = degree;

            label10.Text = "+" + degree.ToString() + " C";
        }

        private void guna2ImageRadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            degree = 20;
            guna2CircleProgressBar2.Value = degree;

            label10.Text = "+" + degree.ToString() + " C";

            if (guna2ImageRadioButton1.Checked)
            {
                DateTime dateTime = DateTime.Now;
                String t = "Climatiseur est mode Cool par "+admin.Login;


                LogsDA.Insert_Logs(dateTime.ToString(), t);
            }
        }

        private void guna2ImageRadioButton4_CheckedChanged(object sender, EventArgs e)
        {
            degree = 27;
            guna2CircleProgressBar2.Value = degree;

            label10.Text = "+" + degree.ToString() + " C";

            if (guna2ImageRadioButton4.Checked)
            {
                DateTime dateTime = DateTime.Now;
                String t = "Climatiseur est mode Heat par "+admin.Login;


                LogsDA.Insert_Logs(dateTime.ToString(), t);
            }
        }

        private void guna2ImageRadioButton5_CheckedChanged(object sender, EventArgs e)
        {
            int min = 1;
            int max = 31;
            Random rnd = new Random();
            degree = rnd.Next(min, max);

            guna2CircleProgressBar2.Value = degree;
            label10.Text = "+" + degree.ToString() + " C";

            if (guna2ImageRadioButton5.Checked)
            {
                DateTime dateTime = DateTime.Now;
                String t = "Climatiseur est mode Automatique par "+admin.Login;


                LogsDA.Insert_Logs(dateTime.ToString(), t);
            }
        }

        private void m8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void m8_MouseDown(object sender, MouseEventArgs e)
        {
            this.DoDragDrop(this,DragDropEffects.Copy);

        }

        private void Climatiseur_Load(object sender, EventArgs e)
        {
            if (_status)
            {
                guna2PictureBox3.Image = Properties.Resources.ac_on;
                degree = 24;
                guna2CircleProgressBar2.Value = degree;

                label10.Text = "+" + degree.ToString() + " C";
                guna2GradientButton3.Enabled = true;
                guna2GradientButton4.Enabled = true;
                guna2ImageRadioButton1.Enabled = true;
                guna2ImageRadioButton4.Enabled = true;
                guna2ImageRadioButton5.Enabled = true;
            }
            else
            {
                guna2PictureBox3.Image = Properties.Resources.ac_off;
                degree = 0;
                guna2CircleProgressBar2.Value = degree;

                label10.Text = "+" + degree.ToString() + " C";
                guna2GradientButton3.Enabled = false;
                guna2GradientButton4.Enabled = false;
                guna2ImageRadioButton1.Enabled = false;
                guna2ImageRadioButton4.Enabled = false;
                guna2ImageRadioButton5.Enabled = false;
            }
        }
    }
}
