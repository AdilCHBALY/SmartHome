using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartHome
{
    public partial class Notif : Form
    {
        public Notif()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(Opacity==1) {
                Opacity -= .2;

               
            }
            if(Opacity == 0) {
                timer1.Stop();
                Close();
            }


            Opacity += .2;
        }

        private void Notif_Load(object sender, EventArgs e)
        {

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            
        }
    }
}
