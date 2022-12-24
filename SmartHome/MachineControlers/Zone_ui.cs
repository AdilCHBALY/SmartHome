using SmartHome.DataAdapter;
using SmartHome.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartHome.MachineControlers
{
    public partial class Zone_ui : UserControl
    {

        rooms _parent;


        public Zone_ui(rooms parent)
        {
            InitializeComponent();
            _parent = parent;
        }
        private int _zone_id;
        private int _id;
        private String _machinename;

        public string Machinename { get => label4.Text; set => label4.Text = value; }
        public int Id { get => _id; set => _id = value; }
        public int Zone_id { get => _zone_id; set => _zone_id = value; }

        private void Zone_Load(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();


            if (label4.Text == "Kitchen")
            {
                guna2PictureBox1.Image = global::SmartHome.Properties.Resources.kitchen;
            }
            if (label4.Text == "BedRoom")
            {
                guna2PictureBox1.Image = global::SmartHome.Properties.Resources.lit;
            }
            if (label4.Text == "BathRoom")
            {
                guna2PictureBox1.Image = global::SmartHome.Properties.Resources.baignoire;
            }
            if (label4.Text == "Foyer")
            {
                guna2PictureBox1.Image = global::SmartHome.Properties.Resources.hanger;
            }
            if (label4.Text == "DiningRoom")
            {
                guna2PictureBox1.Image = global::SmartHome.Properties.Resources.dining_table;
            }



            List<Machine> machines= new List<Machine>();

            machines = MachineDA.Get_Machine_ById(_zone_id);

            

            foreach(Machine machine in machines)
            {
                MachineDetails Machine_Details = MachineDetailsDA.Machine_Detail(machine.Id_details);


                if (Machine_Details.Type == "LAMP" || Machine_Details.Type == "ROBOT" || Machine_Details.Type == "CAMERA" || Machine_Details.Type == "RIDEAU" || Machine_Details.Type == "DOOR")
                {

                    SimpleMachine sm = new SimpleMachine
                    {
                        Id = machine.Id,
                        Lmp_ts = machine.Status1,
                        Lmp_lbl1 = Machine_Details.Name,
                        Image = Machine_Details.Type
                    };

                    flowLayoutPanel1.Controls.Add(sm);
                }
                else if (Machine_Details.Type == "TEMP")
                {
                    Climatiseur Clima = new Climatiseur();
                    Clima.Id= machine.Id;
                    Clima.Status = machine.Status1;
                    flowLayoutPanel1.Controls.Add(Clima);

                }
                else if (Machine_Details.Type == "FRGIDGE")
                {
                    Tlaja tlaja = new Tlaja();
                    tlaja.Id = machine.Id;
                    tlaja.Status = machine.Status1;
                    flowLayoutPanel1.Controls.Add(tlaja);

                }
                else if (Machine_Details.Type == "SPEAKER")
                {
                    Sma3at sma3A = new Sma3at();
                    sma3A.Id = machine.Id;
                    sma3A.Status = machine.Status1;
                    flowLayoutPanel1.Controls.Add(sma3A);

                }
                else if (Machine_Details.Type == "COFFEE")
                {
                    Coffee cfe = new Coffee();
                    cfe.Id = machine.Id;
                    cfe.Status = machine.Status1;
                    flowLayoutPanel1.Controls.Add(cfe);

                }
                else if (Machine_Details.Type == "TV")
                {
                    Tv tv = new Tv();
                    tv.Id = machine.Id;
                    tv.Status = machine.Status1;
                    flowLayoutPanel1.Controls.Add(tv);
                }           

            }

        }




        private void flowLayoutPanel1_DragEnter(object sender, DragEventArgs e)
        {
                e.Effect = DragDropEffects.Copy;     
        }

        private void flowLayoutPanel1_DragDrop(object sender, DragEventArgs e)
        {
            SimpleMachine Machine=(SimpleMachine)e.Data.GetData(typeof(SimpleMachine));
            Climatiseur Clima = (Climatiseur)e.Data.GetData(typeof(Climatiseur));
            Coffee cfe = (Coffee)e.Data.GetData(typeof(Coffee));
            Tlaja tlaja = (Tlaja)e.Data.GetData(typeof(Tlaja));
            Tv tv = (Tv)e.Data.GetData(typeof(Tv));
            Sma3at sma3a = (Sma3at)e.Data.GetData(typeof(Sma3at));



            Climatiseur Get_Clima = new Climatiseur();
            Coffee Get_cfe = new Coffee();
            Tlaja Get_tlaja = new Tlaja();
            Tv Get_tv = new Tv();
            Sma3at Get_sma3a = new Sma3at();
            SimpleMachine Get_Machine = new SimpleMachine();


            String transaction = "";
            Admin admin = AdminDA.Get_Connected_id();

            //Get_Machine.Zone
            if (Machine != null)
            {
                Get_Machine.Id = Machine.Id;
                Get_Machine.Lmp_lbl1 = Machine.Lmp_lbl1;
                Get_Machine.Lmp_ts = Machine.Lmp_ts;
                Get_Machine.Image = Machine.Image;

                //MessageBox.Show(Machine.Lmp_ts.ToString());
                char status;
                if (Machine.Lmp_ts)
                    status = '1';
                else
                    status = '0';

                MachineDA.Add_Machine(status.ToString(), Zone_id.ToString(), Machine.Id.ToString());
                flowLayoutPanel1.Controls.Add(Get_Machine);

                transaction = Machine.Lmp_lbl1+" Ajoutée dans la zone "+label4.Text+" par utilisateur "+admin.Login;

                
            }else if (Clima != null)
            {
               
                Get_Clima.Id= Clima.Id;
                Get_Clima.Status= Clima.Status;
                char status;
                if (Clima.Status)
                    status = '1';
                else
                    status = '0';


                MachineDA.Add_Machine(status.ToString(),Zone_id.ToString(),Clima.Id.ToString());
                flowLayoutPanel1.Controls.Add(Get_Clima);

                transaction = "Climatiseur Ajoutée dans la zone " + label4.Text + " par utilisateur " + admin.Login;
            }
            else if (cfe != null)
            {

                Get_cfe.Id = cfe.Id;
                Get_cfe.Status = cfe.Status;
                char status;
                if (cfe.Status)
                    status = '1';
                else
                    status = '0';


                MachineDA.Add_Machine(status.ToString(), Zone_id.ToString(), cfe.Id.ToString());
                flowLayoutPanel1.Controls.Add(Get_cfe);


                transaction = "Coffee Maker Ajoutée dans la zone " + label4.Text + " par utilisateur " + admin.Login;
            }
            else if (tlaja != null)
            {

                Get_tlaja.Id = tlaja.Id;
                Get_tlaja.Status = tlaja.Status;
                char status;
                if (tlaja.Status)
                    status = '1';
                else
                    status = '0';


                MachineDA.Add_Machine(status.ToString(), Zone_id.ToString(), tlaja.Id.ToString());
                flowLayoutPanel1.Controls.Add(Get_tlaja);

                transaction ="Tlaja Ajoutée dans la zone " + label4.Text + " par utilisateur " + admin.Login;
            }
            else if (tv != null)
            {

                Get_tv.Id = tv.Id;
                Get_tv.Status = tv.Status;
                char status;
                if (tv.Status)
                    status = '1';
                else
                    status = '0';


                MachineDA.Add_Machine(status.ToString(), Zone_id.ToString(), tv.Id.ToString());
                flowLayoutPanel1.Controls.Add(Get_tv);


                transaction = "Tv Ajoutée dans la zone " + label4.Text + " par utilisateur " + admin.Login;
            }
            else if (sma3a != null)
            {

                Get_sma3a.Id = sma3a.Id;
                Get_sma3a.Status = sma3a.Status;
                char status;
                if (sma3a.Status)
                    status = '1';
                else
                    status = '0';


                MachineDA.Add_Machine(status.ToString(), Zone_id.ToString(), sma3a.Id.ToString());
                flowLayoutPanel1.Controls.Add(Get_sma3a);

                transaction = "Woofer Ajoutée dans la zone " + label4.Text + " par utilisateur " + admin.Login;
            }

            DateTime dateTime= DateTime.Now;

            LogsDA.Insert_Logs(dateTime.ToString(), transaction);

        }

        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {
            ZoneDA.Delete_Zone(Zone_id.ToString());
            _parent.Display();
        }

        private void guna2ImageCheckBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2ImageCheckBox3.Checked)
            {
                ZoneDA.ShutDown(Zone_id.ToString());
                Zone_Load(sender, e);
                //_parent.Display();
            }
            else
            {
                ZoneDA.Ch3al(Zone_id.ToString());
                Zone_Load(sender, e);
                //_parent.Display();
            }
        }

        private void guna2ImageCheckBox1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect= DragDropEffects.Copy;
        }

        private void guna2ImageCheckBox1_DragDrop(object sender, DragEventArgs e)
        {
            SimpleMachine Machine = (SimpleMachine)e.Data.GetData(typeof(SimpleMachine));
            Climatiseur Clima = (Climatiseur)e.Data.GetData(typeof(Climatiseur));
            Coffee cfe = (Coffee)e.Data.GetData(typeof(Coffee));
            Tlaja tlaja = (Tlaja)e.Data.GetData(typeof(Tlaja));
            Tv tv = (Tv)e.Data.GetData(typeof(Tv));
            Sma3at sma3a = (Sma3at)e.Data.GetData(typeof(Sma3at));




            if(Machine!=null)
            {
                MachineDA.Delete_Machine(Machine.Id);

            }
            if (Clima != null)
            {
               


                MachineDA.Delete_Machine(Clima.Id);

            }
            if (cfe != null)
            {
                MachineDA.Delete_Machine(cfe.Id);

            }
            if (tlaja != null)
            {
                
                MachineDA.Delete_Machine(tlaja.Id);

            }
            if (tv != null)
            {
                MachineDA.Delete_Machine(tv.Id);

            }
            if (sma3a != null)
            {
                MachineDA.Delete_Machine(sma3a.Id);

            }

            _parent.Display();



        }
    }
}
