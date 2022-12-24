using SmartHome.DataAdapter;
using SmartHome.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartHome.MachineControlers
{
    public partial class Wifi : UserControl
    {
        public Wifi()
        {
            InitializeComponent();
        }

        private int i = 0;

        private void guna2ToggleSwitch9_CheckedChanged(object sender, EventArgs e)
        {
            String t = "Wifi ";
            DateTime dateTime= DateTime.Now;
            Admin admin = AdminDA.Get_Connected_id();


            if (guna2ToggleSwitch9.Checked)
            {
                i++;
                label22.Text = "ON";
                HomaMachineDA.On_Off(2, "1");
                guna2PictureBox8.Image= Properties.Resources.wifi_on;
                t += "Allumée par " +admin.Login;
                if (i > 1)
                    LogsDA.Insert_Logs(dateTime.ToString(), t);
              //label24.Text= "Speed : " + Math.Round(Speed("https://fast.com/") / 1024 / 1024, 2)+"Mbs"; 

            }
            else
            {
                i++;
                label22.Text = "OFF";
                guna2PictureBox8.Image = Properties.Resources.wifi;
                label23.Text = "";
                HomaMachineDA.On_Off(2, "0");
                t += "Eteinte par " + admin.Login;
                if (i > 1)
                    LogsDA.Insert_Logs(dateTime.ToString(), t);
                //label24.Text = "";

            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (guna2ToggleSwitch9.Checked)
            {
                Ping pingClass = new Ping();
                PingReply pingReply = pingClass.Send("www.google.com", 10000);
                label23.Text = pingReply.RoundtripTime.ToString() + " ms";
            }
        }

        private void m3_MouseDown(object sender, MouseEventArgs e)
        {
            var control = sender as Control;

            control.DoDragDrop(control.Name, DragDropEffects.Move);
        }

        private void m3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Wifi_Load(object sender, EventArgs e)
        {
            HomeMachine Machine = HomaMachineDA.Get_Home_Machines(2);


            if (Machine != null)
            {
                if (Machine.Status)
                {
                    label22.Text = "ON";
                    guna2PictureBox8.Image = Properties.Resources.wifi_on;
                    guna2ToggleSwitch9.Checked = true;
                }
                else
                {
                    label22.Text = "OFF";
                    guna2PictureBox8.Image = Properties.Resources.wifi;
                    guna2ToggleSwitch9.Checked = false;
                }

            }
        }
    }
}
