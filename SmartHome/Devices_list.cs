using Bunifu.Framework.UI;
using Guna.UI2.WinForms;
using Microsoft.VisualBasic.ApplicationServices;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using SmartHome.DataAdapter;
using SmartHome.Helper;
using SmartHome.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace SmartHome
{
    public partial class Devices_list : Form
    {
        int volume = 24;
        int degree = 24;
        private static MySqlConnection cnx;
        private static MySqlCommand cmd = null;
        private static DataTable dt;
        private static MySqlDataAdapter sda;


        public List<String> Selected_Machines= new List<String>();
        public Devices_list()
        {
            InitializeComponent();
        }

        private void _Clicked(object sender, EventArgs e)
        {
            var control = sender as Control;
            var name = control.Name;

            Selected_Machines.Add(name);

        }









        //Tv
        private void guna2ToggleSwitch2_CheckedChanged_1(object sender, EventArgs e)
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

            }
        }
        private void guna2GradientButton1_Click_1(object sender, EventArgs e)
        {
            volume++;
            label8.Text = volume.ToString();
            guna2CircleProgressBar1.Value = volume;
        }

        private void guna2GradientButton2_Click_1(object sender, EventArgs e)
        {
            volume--;
            label8.Text = volume.ToString();
            guna2CircleProgressBar1.Value = volume;
        }
        //Lampe
        private void guna2ToggleSwitch5_CheckedChanged_1(object sender, EventArgs e)
        {
            if (guna2ToggleSwitch5.Checked)
            {
                lampe_lab.Text = "ON";
                lampe.Image = Properties.Resources.lampe_on;
            }
            else
            {
                lampe_lab.Text = "OFF";
                lampe.Image = Properties.Resources.lampe;

            }
        }

       

        //AIR COND
        private void guna2ToggleSwitch3_CheckedChanged_1(object sender, EventArgs e)
        {
            if (guna2ToggleSwitch3.Checked)
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

        private void guna2GradientButton4_Click_1(object sender, EventArgs e)
        {
            degree += 1;
            guna2CircleProgressBar2.Value = degree;

            label10.Text = "+" + degree.ToString() + " C";
        }

        private void guna2GradientButton3_Click_1(object sender, EventArgs e)
        {
            degree --;
            guna2CircleProgressBar2.Value = degree;

            label10.Text = "+" + degree.ToString() + " C";
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void guna2ImageRadioButton1_CheckedChanged_1(object sender, EventArgs e)
        {
            degree = 20;
            guna2CircleProgressBar2.Value = degree;

            label10.Text = "+" + degree.ToString() + " C";
        }

        private void guna2ImageRadioButton4_CheckedChanged_1(object sender, EventArgs e)
        {
            degree = 27;
            guna2CircleProgressBar2.Value = degree;

            label10.Text = "+" + degree.ToString() + " C";
        }


        
        private void guna2ImageRadioButton5_CheckedChanged_1(object sender, EventArgs e)
        {
            int min = 1;
            int max = 31;
            Random rnd = new Random();
            degree = rnd.Next(min, max);

            guna2CircleProgressBar2.Value = degree;
            label10.Text = "+" + degree.ToString() + " C";
        }
        //Camera
        private void guna2ToggleSwitch1_CheckedChanged_1(object sender, EventArgs e)
        {
            if(guna2ToggleSwitch1.Checked)
            {
                guna2PictureBox1.Image = Properties.Resources.cam_on;
            }
            else
            {
                guna2PictureBox1.Image = Properties.Resources.cam;
            }
        }

        // Porte
        private void guna2ToggleSwitch4_CheckedChanged_1(object sender, EventArgs e)
        {
            if(guna2ToggleSwitch4.Checked)
            {
                guna2PictureBox4.Image = Properties.Resources.door_open;
                label2.Text = "ON";
            }
            else
            {
                guna2PictureBox4.Image = Properties.Resources.door;
                label2.Text = "OFF";
            }
        }
        //robot aspirateur
        private void guna2ToggleSwitch6_CheckedChanged_1(object sender, EventArgs e)
        {
            if (guna2ToggleSwitch6.Checked)
            {
                guna2PictureBox5.Image = Properties.Resources.Robot_asp_on;
                label17.Text = "ON";
            }
            else
            {
                guna2PictureBox5.Image = Properties.Resources.Robot_asp;
                label17.Text = "OFF";
            }
        }
        // window blinds
        private void guna2ToggleSwitch7_CheckedChanged_1(object sender, EventArgs e)
        {
            if (guna2ToggleSwitch7.Checked)
            {
                guna2PictureBox6.Image = Properties.Resources.window_blind_on;
                label19.Text = "ON";
            }
            else
            {
                guna2PictureBox6.Image = Properties.Resources.window_blind;
                label19.Text = "OFF";
            }
        }

        // woofer
        private void guna2ToggleSwitch8_CheckedChanged_1(object sender, EventArgs e)
        {
            if (guna2ToggleSwitch8.Checked)
            {
                guna2PictureBox7.Image = Properties.Resources.woofer_on;
                guna2GradientButton6.Enabled = true;
                guna2GradientButton5.Enabled = true;
                


            }
            else
            {
                guna2PictureBox7.Image = Properties.Resources.woofer;
                guna2GradientButton6.Enabled = false;
                guna2GradientButton5.Enabled = false;

            }
        }

        private void guna2ImageRadioButton3_CheckedChanged(object sender, EventArgs e)
        {
            






        }

        private void guna2GradientButton6_Click_1(object sender, EventArgs e)
        {
            
            
               guna2CircleProgressBar3.Value++;
            
        }

        private void guna2GradientButton5_Click_1(object sender, EventArgs e)
        {


            guna2CircleProgressBar3.Value--;

        }

        private void bunifuProgressBar1_progressChanged_1(object sender, EventArgs e)
        {

        }

        private void guna2ImageCheckBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            
            }
        //wifi
        private void guna2ToggleSwitch9_CheckedChanged(object sender, EventArgs e)
        {
            if(guna2ToggleSwitch9.Checked) { 
            label22.Text = "ON";
           /* guna2PictureBox8.Image= Properties.Resources.wifi_on;
            Ping pingClass = new Ping();
            PingReply pingReply = pingClass.Send("www.google.com", 10000);
            label23.Text = pingReply.RoundtripTime.ToString() + " ms";
            label24.Text= "Speed : " + Math.Round(Speed("https://fast.com/") / 1024 / 1024, 2)+"Mbs"; */

            }
            else
            {
            label22.Text = "OFF";
            guna2PictureBox8.Image = Properties.Resources.wifi;
                label23.Text = "";
               // label24.Text = "";

            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            guna2ToggleSwitch9_CheckedChanged( sender, e);
            guna2ToggleSwitch10_CheckedChanged(sender, e);
            
        }
        public static double Speed(String url)
        {
            WebClient wc = new WebClient();
            DateTime dt = DateTime.Now;
            byte[] data = wc.DownloadData(url);
            DateTime dt2 = DateTime.Now;
            return (data.Length * 8) / (dt2 - dt).TotalSeconds;
        }

        private void guna2ShadowPanel9_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        int degree1 = 5;
        private void Devices_list_Load(object sender, EventArgs e)
        {
            label26.Text = degree1.ToString()+ "°C";
            guna2CircleProgressBar4.Value = degree1;

            String q = "SELECT * FROM domitique.zone WHERE id_appr = (@0)";
            //List<Zone> all_fetched_zone = null;
            cmd = DBHelper.RunQuery(q, 1.ToString());
            int id;
            String nom;
            int id_apprt;

            if (cmd != null)
            {
                dt = new DataTable();
                sda = new MySqlDataAdapter(cmd);
                sda.Fill(dt);

                guna2ComboBox1.DataSource= dt;
                guna2ComboBox1.DisplayMember="nom_zone";
                guna2ComboBox1.ValueMember = "id_zone";
                guna2ComboBox1.Text = "Select a Zone";




            }
            


         
                        m6.Click += _Clicked;
                        m5.Click += _Clicked;
                        m7.Click += _Clicked;
                        m8.Click += _Clicked;
                        m11.Click += _Clicked;
                        m4.Click += _Clicked;
                        m1.Click += _Clicked;
                        m9.Click += _Clicked;
                        m2.Click += _Clicked;
                        m3.Click += _Clicked;
                        m10.Click += _Clicked;


        }

        private void guna2GradientButton8_Click(object sender, EventArgs e)
        {
            degree1++;
            guna2CircleProgressBar4.Value = degree1;
            label26.Text = degree1.ToString() + "°C";
        }

        private void guna2GradientButton7_Click(object sender, EventArgs e)
        {
            degree1--;
            guna2CircleProgressBar4.Value = degree1;
            label26.Text = degree1.ToString() + "°C";
        }
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
        int time = 300;
        private void guna2ToggleSwitch10_CheckedChanged(object sender, EventArgs e)
        {
            if(guna2ToggleSwitch10.Checked)
            {
                
                guna2PictureBox10.Image = Properties.Resources.cofee_on;
                label27.Text = "Making...";
                label29.Text = CountDown(time);

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
                time = 300;
                

            }
        }

        private void flowLayoutPanel1_DragEnter(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent(typeof(string)))
                return;

            var name = e.Data.GetData(typeof(string)) as string;
            var control = this.Controls.Find(name, true).FirstOrDefault();
            if (control != null)
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void flowLayoutPanel1_DragDrop(object sender, DragEventArgs e)
        {

        }

        private void _MouseDown(object sender, MouseEventArgs e)
        {
            var control = sender as Control;

            this.DoDragDrop(control.Name, DragDropEffects.Copy);
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            String zone_name = guna2ComboBox1.GetItemText(guna2ComboBox1.SelectedValue);
            
            foreach (String Machine in Selected_Machines)
            {
                MachineDA.Add_Machine(Machine[1].ToString(), zone_name);
            }

            this.Hide();

        }

        private void m9_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2ImageCheckBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void guna2ImageCheckBox3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label26_Click(object sender, EventArgs e)
        {

        }

        private void guna2CircleProgressBar4_ValueChanged(object sender, EventArgs e)
        {

        }

        private void guna2ImageCheckBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void guna2ToggleSwitch9_CheckedChanged_1(object sender, EventArgs e)
        {

        }
    }
    }

