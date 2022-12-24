using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Guna.UI2.WinForms;
using Newtonsoft.Json;
using SmartHome.DataAdapter;
using SmartHome.Models;

namespace SmartHome
{
   
    public partial class dash : Form
    {
        private int degree = 24;
        private Form activeForm;
        public int admin_id;
        public dash()
        {
            InitializeComponent();
           
        }

        private void OpenChildForm(Form children, object sender)
        {
            
            activeForm?.Close();
            

            activeForm = children;
            children.TopLevel = false;
            children.FormBorderStyle = FormBorderStyle.None;
            children.Dock = DockStyle.Fill;
            this.guna2Panel2.Controls.Add(children);
            this.guna2Panel2.Tag = children;
            children.BringToFront();
            children.Show();
            //children.admin_id=admin_id;
            //label2.Text = AdminDA.Get_User_Name(admin_id);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        

        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void guna2CircleProgressBar2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void guna2VProgressBar1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }
       
        private void guna2Button2_Click(object sender, EventArgs e)
        {
            guna2Button1.Checked= false;
            guna2Button3.Checked = false;
            guna2Button4.Checked = false;
            OpenChildForm(new rooms(), sender);

        }

        private void label10_Click_1(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            guna2Button2.Checked = false;
            guna2Button3.Checked = false;
            guna2Button4.Checked = false;
            OpenChildForm(new home(), sender);

        }

        private void dash_Load(object sender, EventArgs e)
        {
            OpenChildForm(new home(), sender);
        }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            guna2Button2.Checked = false;
            guna2Button1.Checked = false;
            guna2Button4.Checked = false;
            OpenChildForm(new logs(), sender);
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            guna2Button2.Checked = false;
            guna2Button1.Checked = false;
            guna2Button3.Checked = false;
            Acc_creation a = new Acc_creation();
            a.Show();
            
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            Admin admin = AdminDA.Get_Connected_id();
            AdminDA.Disconnect(admin.Id);

            System.Windows.Forms.Application.Exit();
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            Admin admin = AdminDA.Get_Connected_id();
            AdminDA.Disconnect(admin.Id);

            DateTime date= DateTime.Now;

            LogsDA.Insert_Logs(date.ToString(), admin.Login + " Est Deconnecter");
            this.Hide();
            Form1 f = new Form1();
            f.Show();

        }
    }
    
}
