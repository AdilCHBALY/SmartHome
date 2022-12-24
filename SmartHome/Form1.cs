using SmartHome.DataAdapter;
using SmartHome.Helper;
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
using static SmartHome.home.WeatherInfo;

namespace SmartHome
{
    public partial class Form1 : Form
    {
        private Form activeFrom;
        public Form1()
        {
            InitializeComponent();
            DBHelper.EstablishCnx();
        }

        private void guna2ControlBox2_Click(object sender, EventArgs e)
        {

        }
        /*private void OpenChildForm(Form children, object sender)
        {
            if (activeFrom != null)
            {
                activeFrom.Close();
            }

            activeFrom = children;
            children.TopLevel = false;
            children.FormBorderStyle = FormBorderStyle.None;
            children.Dock = DockStyle.Fill;
            this.panelDesktopPane.Controls.Add(children);
            this.panelDesktopPane.Tag = children;
            children.BringToFront();
            children.Show();
            labelHOME.Text = children.Text;
        }*/
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            String login = guna2TextBox1.Text;
            String mdp = guna2TextBox2.Text;

            

            if (login != "" && mdp != "")
            {
                Admin admin = AdminDA.Authentification(login);

               

                if (admin != null)
                {
                    if (admin.Password == mdp)
                    {
                        String t = login + " Est Connecter";
                        DateTime time= DateTime.Now;
                        LogsDA.Insert_Logs(time.ToString(),t);
                        AdminDA.Connect(admin.Id);

                        this.Hide();
                        dash d = new dash();
                        d.admin_id= admin.Id;
                        d.Show();

                    }
                    else
                    {
                        MessageBox.Show("The Password is Wrong !");
                    }
                }
                else
                {
                    MessageBox.Show("this User Doesnt Exist in the Database");
                }
            }
            else
            {
                MessageBox.Show("Champ Vide!");
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Opacity == 1)
            {
                timer1.Stop();
            }

            Opacity += .2;
        }
    }
}
