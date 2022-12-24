using SmartHome.DataAdapter;
using SmartHome.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;
using static SmartHome.home.WeatherInfo;

namespace SmartHome.MachineControlers
{
    public partial class SimpleMachine : UserControl
    {
        public SimpleMachine()
        {
            InitializeComponent();
        }
        private int _id;
        private String Lmp_lbl;
        private bool lmp_ts;
        private String image;
        private String ON_OFF_lbl;

        private int i = 0;

        public string Lmp_lbl1 { get => label16.Text; set => label16.Text = value; }
        public bool Lmp_ts { get => guna2ToggleSwitch5.Checked; set => guna2ToggleSwitch5.Checked = value; }
        public String Image { get => image; set => image = value; }
        public string ON_OFF_lbl1 { get => lampe_lab.Text; set => lampe_lab.Text = value; }
        public int Id { get => _id; set => _id = value; }

        private void guna2ToggleSwitch5_CheckedChanged(object sender, EventArgs e)
        {
            
            String transaction = "";
            Admin admin = AdminDA.Get_Connected_id();

            
            

            if (guna2ToggleSwitch5.Checked)
            {

                i++;
                lampe_lab.Text = "ON";

                if (Image == "LAMP")
                {
                    lampe.Image = global::SmartHome.Properties.Resources.lampe_on;
                   
                    transaction = "Lampe Allumée par "+admin.Login;
                }
                else if (Image == "ROBOT")
                {
                    lampe.Image = global::SmartHome.Properties.Resources.Robot_asp_on;
                    transaction = "Robot Aspirateur Allumée par " + admin.Login;
                }
                else if (Image == "RIDEAU")
                {
                    lampe.Image = global::SmartHome.Properties.Resources.window_blind_on;
                    transaction = "Rideau Allumée par " + admin.Login;
                }
                else if (Image == "DOOR")
                {
                    lampe.Image = global::SmartHome.Properties.Resources.door_open;
                    transaction = "Porte Allumée par " + admin.Login;
                }
                DateTime dateTime = DateTime.Now;

                MachineDA.Update_Status(Id.ToString(),1.ToString());
                if (i > 2)
                {
                    LogsDA.Insert_Logs(dateTime.ToString(), transaction);
                }
               



               


                //LogsDA.Insert_Logs(dateTime.ToString(), transaction);


            }
            else
            {

                i++;
                lampe_lab.Text = "OFF";
                if (Image == "LAMP")
                {
                    lampe.Image = global::SmartHome.Properties.Resources.lampe;
                    transaction = "Lampe Eteinte par " + admin.Login;
                }
                else if (Image == "ROBOT")
                {
                    lampe.Image = global::SmartHome.Properties.Resources.Robot_asp;
                    transaction = "Robot Aspirateur Eteinte par " + admin.Login;
                }
                else if (Image == "RIDEAU")
                {
                    lampe.Image = global::SmartHome.Properties.Resources.window_blind;
                    transaction = "Rideau Eteinte par " + admin.Login;
                }
                else if (Image == "DOOR")
                {
                    lampe.Image = global::SmartHome.Properties.Resources.door;
                    transaction = "Porte Eteinte par " + admin.Login;
                }
                MachineDA.Update_Status(Id.ToString(), 0.ToString());

                DateTime dateTime = DateTime.Now;

                if (i > 2)
                {
                    LogsDA.Insert_Logs(dateTime.ToString(), transaction);
                }


                //LogsDA.Insert_Logs(dateTime.ToString(), transaction);
            }

            //MessageBox.Show(transaction);


        }

        private void SimpleMachine_Load(object sender, EventArgs e)
        {
            if (lmp_ts)
            {
                lampe_lab.Text = "ON";

                if (Image == "LAMP")
                {
                    lampe.Image = global::SmartHome.Properties.Resources.lampe_on;
                }
                else if (Image == "ROBOT")
                {
                    lampe.Image = global::SmartHome.Properties.Resources.Robot_asp_on;
                }
                else if (Image == "RIDEAU")
                {
                    lampe.Image = global::SmartHome.Properties.Resources.window_blind_on;
                }
                else if (Image == "DOOR")
                {
                    lampe.Image = global::SmartHome.Properties.Resources.door_open;
                }
               /* guna2ToggleSwitch5.Checked = true;*/
               

            }
            else
            {
                lampe_lab.Text = "OFF";
                if (Image == "LAMP")
                {
                    lampe.Image = global::SmartHome.Properties.Resources.lampe;
                }
                else if (Image == "ROBOT")
                {
                    lampe.Image = global::SmartHome.Properties.Resources.Robot_asp;
                }
                else if (Image == "RIDEAU")
                {
                    lampe.Image = global::SmartHome.Properties.Resources.window_blind;
                }
                else if (Image == "DOOR")
                {
                    lampe.Image = global::SmartHome.Properties.Resources.door;
                }

                /*guna2ToggleSwitch5.Checked = false;*/
                
            }


            guna2ToggleSwitch5_CheckedChanged(sender, e);
            //ControlExtension.Draggable(m4, true);
            //lampe_lab.Text = "TEST";
            //lampe_lab.Text = Lmp_lbl;
        }

        private void m4_MouseDown(object sender, MouseEventArgs e)
        {
            this.DoDragDrop(this, DragDropEffects.Copy);
        }

        /*private void m4_MouseDown(object sender, MouseEventArgs e)
        {
            var control = sender as Control;

            control.DoDragDrop(control.Name, DragDropEffects.Move);
        }*/
    }
}
