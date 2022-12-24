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
    public partial class Coffee : UserControl
    {
        public Coffee()
        {
            InitializeComponent();
        }

        private int _id;
        private bool _status;
        private int i = 0;

        public static String CountDown(int time)
        {
            String min;
            String s;

            int mtime = time / 60;

            min = mtime.ToString();

            time %= 60;


            s = time.ToString();


            return min + ":" + s;

        }
        int time = 10;

        public int Id { get => _id; set => _id = value; }
        public bool Status { get => _status; set => _status = value; }

        private void guna2ToggleSwitch10_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2ToggleSwitch10.Checked)
            {
                i++;
                guna2PictureBox10.Image = Properties.Resources.cofee_on;
                label27.Text = "Making...";
                label29.Text = CountDown(time);
                MachineDA.Update_Status(Id.ToString(), 1.ToString());

              


                time--;

                if (time == -1)
                {
                  //  Notif n = new Notif();
                 //   n.Show();
                    time = 10;
                    guna2ToggleSwitch10.Checked = false;

                    String t = "Coffee Maker Ready";
                    DateTime dateTime = DateTime.Now;


                    LogsDA.Insert_Logs(dateTime.ToString(),t);

                }
            }

            else
            {
                i++;
                guna2PictureBox10.Image = Properties.Resources.cofee;
                label27.Text = "Done";
                MachineDA.Update_Status(Id.ToString(), 0.ToString());
                time = 10;
                

            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            guna2ToggleSwitch10_CheckedChanged(sender, e);
        }

        private void m10_MouseDown(object sender, MouseEventArgs e)
        {
            this.DoDragDrop(this, DragDropEffects.Copy);
        }

        private void Coffee_Load(object sender, EventArgs e)
        {
            if (_status)
            {

                guna2PictureBox10.Image = Properties.Resources.cofee_on;
                label27.Text = "Making...";
                label29.Text = CountDown(time);
                guna2ToggleSwitch10.Checked = true;

                time--;

                if (time == -1)
                {
                    time = 300;
                    guna2ToggleSwitch10.Checked = false;
                }
            }

            else
            {
                guna2PictureBox10.Image = Properties.Resources.cofee;
                label27.Text = "Done";
                guna2ToggleSwitch10.Checked= false;
                time = 300;


            }
        }
    }
}
