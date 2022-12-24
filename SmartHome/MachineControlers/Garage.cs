using Guna.UI2.WinForms;
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
    public partial class Garage : UserControl
    {
        public Garage()
        {
            InitializeComponent();
        }

        private int i = 0;

        private void guna2ToggleSwitch9_CheckedChanged(object sender, EventArgs e)
        {
            String t = "Garage";
            DateTime date= DateTime.Now;
            Admin admin = AdminDA.Get_Connected_id();

            if (guna2ToggleSwitch9.Checked)
            {
                i++;
                guna2PictureBox8.Image = Properties.Resources.garage_on;
                label22.Text = "ON";
                HomaMachineDA.On_Off(4, "1");


                t += " Ouvert par "+admin.Login;
                if (i > 1)
                    LogsDA.Insert_Logs(date.ToString(), t);

            }
            else
            {
                i++;
                guna2PictureBox8.Image = Properties.Resources.garage;
                label22.Text = "OFF";
                HomaMachineDA.On_Off(4, "0");

                t += " Fermé par "+admin.Login;
                if(i>1)
                    LogsDA.Insert_Logs(date.ToString(), t);
            }
        }

        private void m3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Garage_Load(object sender, EventArgs e)
        {
            HomeMachine Machine = HomaMachineDA.Get_Home_Machines(4);


            if (Machine != null)
            {
                if (Machine.Status)
                {
                    guna2PictureBox8.Image = Properties.Resources.garage_on;
                    label22.Text = "ON";
                    guna2ToggleSwitch9.Checked = true;
                }
                else
                {
                    guna2PictureBox8.Image = Properties.Resources.garage;
                    label22.Text = "OFF";
                    guna2ToggleSwitch9.Checked = false;
                }

            }
        }
    }
}
