using Newtonsoft.Json;
using SmartHome.DataAdapter;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;
using Guna.UI2.WinForms;
using SmartHome.Models;

namespace SmartHome
{
    public partial class home : Form
    {
        MJPEGStream streamvideo;
        MJPEGStream streamvideo2;
        MJPEGStream streamvideo3;
        MJPEGStream streamvideo4;

        
        public int admin_id;
        public home()
        {
            InitializeComponent();
            streamvideo = new MJPEGStream("http://50.248.1.46:8000/mjpg/video.mjpg");
            streamvideo2 = new MJPEGStream("http://72.132.255.68:80/mjpg/video.mjpg");
            streamvideo3 = new MJPEGStream("http://213.140.218.213:9000/mjpg/video.mjpg");
            streamvideo4 = new MJPEGStream("http://78.244.161.33:88/mjpg/video.mjpg");
            streamvideo.NewFrame += GetNewFram;
            streamvideo2.NewFrame += GetNewFram2;
            streamvideo3.NewFrame += GetNewFram3;
            streamvideo4.NewFrame += GetNewFram4;



        }

        private void GetNewFram(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap bmp = (Bitmap)eventArgs.Frame.Clone();
            guna2PictureBox3.Image = bmp;
          
        }
        private void GetNewFram2(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap bmp = (Bitmap)eventArgs.Frame.Clone();
           
            guna2PictureBox4.Image = bmp;
        }
        private void GetNewFram3(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap bmp = (Bitmap)eventArgs.Frame.Clone();

            guna2PictureBox5.Image = bmp;
        }
        private void GetNewFram4(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap bmp = (Bitmap)eventArgs.Frame.Clone();

            guna2PictureBox6.Image = bmp;
        }

        public static string temp()
        {
            using (WebClient web = new WebClient())
            {
                string url = "https://api.openweathermap.org/data/2.5/weather?q=marrakech&appid=8c1e6756d2a0b9529ddfbcb000e2bbde";
                var json = web.DownloadString(url);
                WeatherInfo.root info = JsonConvert.DeserializeObject<WeatherInfo.root>(json);
                double mo3adala = info.main.temp - 273.15;
                int degr = (int)mo3adala;

                return degr.ToString();
            }

      
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        internal class WeatherInfo
        {

            public class coord
            {
                public double lon { get; set; }
                public double lat { get; set; }
            }

            public class weather
            {
                public string main { get; set; }
                public string icon { get; set; }
                public string description { get; set; }
            }

            public class main
            {
                public double temp { get; set; }
                public double pressure { get; set; }

                public double humidity { get; set; }
            }

            public class wind
            {
                public double speed { get; set; }
            }

            public class sys
            {
                public long sunrise { get; set; }

                public long sunset { get; set; }
            }

            public class root
            {

                public sys sys { get; set; }
                public wind wind { get; set; }
                public List<weather> weather { get; set; }
                public coord coord { get; set; }

                public main main { get; set; }
            }
        }

        private void home_Load(object sender, EventArgs e)
        {
            TimeSpan currentTime = DateTime.Now.TimeOfDay;
            label3.Text=currentTime.Hours+":"+currentTime.Minutes+":"+currentTime.Seconds;


            Admin admin = AdminDA.Get_Connected_id();


            label2.Text = admin.Login;

            HomeMachine Machine = HomaMachineDA.Get_Home_Machines(3);
            HomeMachine Machine5=HomaMachineDA.Get_Home_Machines(5);
            HomeMachine Machine6 = HomaMachineDA.Get_Home_Machines(6);
            HomeMachine Machine7 = HomaMachineDA.Get_Home_Machines(7);
          

             if (Machine5.Status)
             {
                guna2ToggleSwitch1.Checked = true;
                guna2PictureBox1.Image = Properties.Resources.night_on;
                
                //this.BackColor= Color.Black;
            }
            else
            {
                guna2ToggleSwitch1.Checked = false;
                guna2PictureBox1.Image = Properties.Resources.night;
            }

             


            if (Machine != null)
            {
                if (Machine.Status)
                {

                    cam.Image = Properties.Resources.cam_on;
                    cam_lab.Text = "ON";
                    streamvideo.Start();
                    streamvideo2.Start();
                    streamvideo3.Start();
                    streamvideo4.Start();
                    guna2ToggleSwitch5.Checked = true;
                }
                else
                {
                    cam.Image = Properties.Resources.cam;
                    cam_lab.Text = "OFF";
                    streamvideo.Stop();
                    streamvideo2.Stop();
                    streamvideo3.Stop();
                    streamvideo4.Stop();
                    guna2PictureBox3.Image = Properties.Resources.no_signal_cctv_1024x576;
                    guna2PictureBox4.Image = Properties.Resources.no_signal_cctv_1024x576;
                    guna2PictureBox5.Image = Properties.Resources.no_signal_cctv_1024x576;
                    guna2PictureBox6.Image = Properties.Resources.no_signal_cctv_1024x576;
                    guna2ToggleSwitch5.Checked = false;
                }

            }

            if (Machine6.Status)
            {
                guna2PictureBox7.Image = Properties.Resources.smoke_detector_on;
                guna2ToggleSwitch2.Checked = true;

            }
            else {
                guna2PictureBox7.Image = Properties.Resources.smoke_detector;

                guna2ToggleSwitch2.Checked = false;
            }

 

            if (Machine7.Status)
            {
                    guna2PictureBox8.Image = Properties.Resources.fire_detector_on;
                    guna2ToggleSwitch3.Checked = true;

            }
            else
            {
                guna2PictureBox8.Image = Properties.Resources.fire_detector;

                guna2ToggleSwitch3.Checked = false;
            }

            //label2.Text = AdminDA.Get_User_Name(admin_id);

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            TimeSpan currentTime = DateTime.Now.TimeOfDay;
            label3.Text = currentTime.Hours + ":" + currentTime.Minutes + ":" + currentTime.Seconds;
            string degr = temp();

            label10.Text = "+" + degr+ " C";
            guna2CircleProgressBar2.Value = Convert.ToInt32(degr);
            guna2VProgressBar1.Value = Convert.ToInt32(degr);
            //guna2ToggleSwitch9_CheckedChanged(sender, e);
        }

        private void guna2ShadowPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void wifi1_Load(object sender, EventArgs e)
        {

        }

        private void guna2ToggleSwitch9_CheckedChanged(object sender, EventArgs e)
        {

        }

        int i = 0;
        Admin admin = AdminDA.Get_Connected_id();
        DateTime date= DateTime.Now;

        private void guna2ToggleSwitch1_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2ToggleSwitch1.Checked)
            {
                i++;
                guna2PictureBox1.Image = Properties.Resources.night_on;
                MachineDA.activateNightMode();
                String t = "Night Mode Activated Par " + admin.Login;
                if (i > 1)
                    LogsDA.Insert_Logs(date.ToString(), t);
               // this.BackColor=Color.Black;
                HomaMachineDA.On_Off(5, "1");
               
            }
            else
            {
                i++;
                guna2PictureBox1.Image = Properties.Resources.night;
                HomaMachineDA.On_Off(5, "0");

                String t = "Night Mode Activated Par " + admin.Login;
                if (i > 1)
                    LogsDA.Insert_Logs(date.ToString(), t);
                //MachineDA.deactivateNightMode();
                //this.BackColor = Color.White;
            }
        }

        private void m4_Paint(object sender, PaintEventArgs e)
        {

        }
        int j = 0;
        private void guna2ToggleSwitch5_CheckedChanged(object sender, EventArgs e)
        {

            if (guna2ToggleSwitch5.Checked)
            {
                j++;
                cam.Image = Properties.Resources.cam_on;
                cam_lab.Text = "ON";
                streamvideo.Start();
                streamvideo2.Start();
                streamvideo3.Start();
                streamvideo4.Start();
                HomaMachineDA.On_Off(3, "1");
                String t = "Camera ON Par " + admin.Login;
                if (j > 1)
                    LogsDA.Insert_Logs(date.ToString(), t);
            }
            else
            {
                j++;
                cam.Image = Properties.Resources.cam;
                cam_lab.Text = "OFF";
                streamvideo.Stop();
                streamvideo2.Stop();
                streamvideo3.Stop();
                streamvideo4.Stop();
                guna2PictureBox3.Image=Properties.Resources.no_signal_cctv_1024x576;
                guna2PictureBox4.Image = Properties.Resources.no_signal_cctv_1024x576;
                guna2PictureBox5.Image = Properties.Resources.no_signal_cctv_1024x576;
                guna2PictureBox6.Image = Properties.Resources.no_signal_cctv_1024x576;
                HomaMachineDA.On_Off(3, "0");
                String t = "Camera OFF Par " + admin.Login;
                if (j > 1)
                    LogsDA.Insert_Logs(date.ToString(), t);


            }

        }

        private void guna2PictureBox3_Click(object sender, EventArgs e)
        {

        }
        int z = 0;

        private void guna2ToggleSwitch2_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2ToggleSwitch2.Checked)
            {
                z++;
                guna2PictureBox7.Image = Properties.Resources.smoke_detector_on;
                HomaMachineDA.On_Off(6, "1");
                String t = "Smoke Detector ON Par " + admin.Login;
                if (z > 1)
                    LogsDA.Insert_Logs(date.ToString(), t);
            }
            else
            {
                z++;
                guna2PictureBox7.Image = Properties.Resources.smoke_detector;

                HomaMachineDA.On_Off(6, "0");
                String t = "Smoke Detector OFF Par " + admin.Login;
                if (z > 1)
                    LogsDA.Insert_Logs(date.ToString(), t);
            }
        }

        int k =0;
        private void guna2ToggleSwitch3_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2ToggleSwitch3.Checked)
            {
                k++;
                guna2PictureBox8.Image = Properties.Resources.fire_detector_on;
                HomaMachineDA.On_Off(7, "1");

                String t = "Fire Detector ON Par " + admin.Login;
                if (k > 1)
                    LogsDA.Insert_Logs(date.ToString(), t);

            }
            else
            {
                k++;
                guna2PictureBox8.Image = Properties.Resources.fire_detector;
                HomaMachineDA.On_Off(7, "0");

                String t = "Fire Detector OFF Par " + admin.Login;
                if (k > 1)
                    LogsDA.Insert_Logs(date.ToString(), t);


            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
