using Guna.UI2.WinForms;
using MySql.Data.MySqlClient;
using SmartHome.DataAdapter;
using SmartHome.Helper;
using SmartHome.MachineControlers;
using SmartHome.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartHome
{
    public partial class rooms : Form
    {
        int volume = 24;
        int degree = 24;
        private MySqlCommand cmd;
        private DataTable dt;
        private MySqlDataAdapter sda;

        public rooms()
        {
            InitializeComponent();
        }

        public static void CheckedChanged(Object sender, EventArgs e)
        {
            Guna2ToggleSwitch tg;
            System.Windows.Forms.Label l1;
            Guna2CircleProgressBar pb;
            System.Windows.Forms.Label l2;
            Guna2PictureBox picb;
            Guna2GradientButton gb;

            /* for (int i = 1; i <= 11; i++)
             {
                 tg= new Guna2ToggleSwitch();
                 l1=new Label();
                 l2=new Label();




                 if (tg.Checked)
                 {
                     l1.Text = "ON";
                     picb.Image = Properties.Resources.tv_on;
                     volume = 24;
                     pb.Value = volume;

                     l2.Text = volume.ToString();
                     gb.Enabled = true;
                     gb.Enabled = true;
                 }
                 else
                 {
                     l1.Text = "OFF";
                     picb.Image = Properties.Resources.tv;
                     volume = 0;
                     pb.Value = volume;

                     l2.Text = volume.ToString();
                     gb.Enabled = false;
                     gb.Enabled = false;

                 }
             }*/


            /*if (tg.Checked)
            {
                l1.Text = "ON";
                picb.Image = Properties.Resources.tv_on;
                volume = 24;
                pb.Value = volume;

                l2.Text = volume.ToString();
                gb.Enabled = true;
                gb.Enabled = true;
            }
            else
            {
                l1.Text = "OFF";
                picb.Image = Properties.Resources.tv;
                volume = 0;
                pb.Value = volume;

                l2.Text = volume.ToString();
                gb.Enabled = false;
                gb.Enabled = false;

            }*/
        }


        Guna2PictureBox Picb(String type)
        {
            Guna2PictureBox picb = new Guna2PictureBox();


            picb.FillColor = System.Drawing.Color.Blue;
            if (type == "LAMP")
            {
                picb.Image = global::SmartHome.Properties.Resources.lampe;
            }
            else if (type == "ROBOT")
            {
                picb.Image = global::SmartHome.Properties.Resources.Robot_asp;
            }
            else if (type == "CAMERA")
            {
                picb.Image = global::SmartHome.Properties.Resources.cam;
            }
            else if (type == "RIDEAU")
            {
                picb.Image = global::SmartHome.Properties.Resources.window_blind;
            }
            else if (type == "DOOR")
            {
                picb.Image = global::SmartHome.Properties.Resources.door;
            }

            picb.Location = new System.Drawing.Point(3, 3);
            picb.Name = "lampe";
            picb.ShadowDecoration.Parent = picb;
            picb.Size = new System.Drawing.Size(65, 67);
            picb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            picb.TabIndex = 0;
            picb.TabStop = false;

            return picb;
        }

        Guna2ToggleSwitch Add_Toggle()
        {
            Guna2ToggleSwitch TglSwt = new Guna2ToggleSwitch();


            TglSwt.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(6)))), ((int)(((byte)(123)))));
            TglSwt.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(6)))), ((int)(((byte)(123)))));
            TglSwt.CheckedState.InnerBorderColor = System.Drawing.Color.White;
            TglSwt.CheckedState.InnerColor = System.Drawing.Color.White;
            TglSwt.CheckedState.Parent = TglSwt;
            TglSwt.Location = new System.Drawing.Point(90, 22);
            TglSwt.Name = "guna2ToggleSwitch5";
            TglSwt.ShadowDecoration.Parent = TglSwt;
            TglSwt.Size = new System.Drawing.Size(42, 23);
            TglSwt.TabIndex = 15;
            TglSwt.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            TglSwt.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            TglSwt.UncheckedState.InnerBorderColor = System.Drawing.Color.White;
            TglSwt.UncheckedState.InnerColor = System.Drawing.Color.White;
            TglSwt.UncheckedState.Parent = TglSwt;
            TglSwt.CheckedChanged += CheckedChanged;

            return TglSwt;
        }

        System.Windows.Forms.Label Add_ONOFF_Label()
        {
            System.Windows.Forms.Label lmp = new System.Windows.Forms.Label();

            lmp.AutoSize = true;
            lmp.Font = new System.Drawing.Font("Montserrat SemiBold", 7.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lmp.Location = new System.Drawing.Point(97, 54);
            lmp.Name = "lampe_lab";
            lmp.Size = new System.Drawing.Size(27, 14);
            lmp.TabIndex = 2;
            lmp.Text = "OFF";

            return lmp;
        }

        System.Windows.Forms.Label Add_Machine_Label(String name)
        {
            System.Windows.Forms.Label lbl = new System.Windows.Forms.Label();

            lbl.AutoSize = true;
            lbl.Font = new System.Drawing.Font("Montserrat SemiBold", 7.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lbl.Location = new System.Drawing.Point(18, 109);
            lbl.Name = name;
            lbl.Size = new System.Drawing.Size(100, 14);
            lbl.TabIndex = 16;
            lbl.Text = name;

            return lbl;
        }

       Guna2ShadowPanel Add_Mechine_Panel(String name, String type)
        {
            Guna2ShadowPanel ShdwPanel = new Guna2ShadowPanel();
            System.Windows.Forms.Label lbl = Add_Machine_Label(name);
            System.Windows.Forms.Label lmp = Add_ONOFF_Label();
            Guna2ToggleSwitch ts = Add_Toggle();
            Guna2PictureBox picb = Picb(type);


            ShdwPanel.BackColor = System.Drawing.Color.Transparent;
            ShdwPanel.Controls.Add(lbl);
            ShdwPanel.Controls.Add(lmp);
            ShdwPanel.Controls.Add(ts);
            ShdwPanel.Controls.Add(picb);
            ShdwPanel.FillColor = System.Drawing.Color.White;
            ShdwPanel.Location = new System.Drawing.Point(315, 153);
            ShdwPanel.Name = type;
            ShdwPanel.Radius = 12;
            ShdwPanel.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(4)))), ((int)(((byte)(83)))));
            ShdwPanel.ShadowDepth = 70;
            ShdwPanel.Size = new System.Drawing.Size(147, 144);
            ShdwPanel.TabIndex = 33;
            ShdwPanel.MouseDown += DoMouseDown;


            return ShdwPanel;
        }

        private void DoMouseDown(Object sender, MouseEventArgs e)
        {
            var control = sender as Control;
            
            this.DoDragDrop(control.Name, DragDropEffects.Copy);
        }

        //Guna2ToggleSwitch tg, Label l1, Guna2CircleProgressBar pb,Label l2,Guna2PictureBox picb,Guna2GradientButton gb

        /*public static Guna2ShadowPanel Add_Temp_Panel(String name, String type)
        {
            Guna2ShadowPanel ShdwPanel = new Guna2ShadowPanel();
            /*System.Windows.Forms.Label lbl = Add_Machine_Label(name);
            System.Windows.Forms.Label lmp = Add_ONOFF_Label();
            Guna2ToggleSwitch ts = Add_Toggle();
            Guna2PictureBox picb = Picb(type);
            ShdwPanel.BackColor = System.Drawing.Color.Transparent;
            ShdwPanel.Controls.Add(this.guna2ToggleSwitch3);
            ShdwPanel.Controls.Add(this.guna2PictureBox3);
            ShdwPanel.Controls.Add(this.guna2GradientButton3);
            ShdwPanel.Controls.Add(this.guna2GradientButton4);
            ShdwPanel.Controls.Add(this.label9);
            ShdwPanel.Controls.Add(this.guna2CircleProgressBar2);
            ShdwPanel.Controls.Add(this.guna2ImageRadioButton5);
            ShdwPanel.Controls.Add(this.label11);
            ShdwPanel.Controls.Add(this.guna2ImageRadioButton2);
            ShdwPanel.Controls.Add(this.label12);
            ShdwPanel.Controls.Add(this.guna2ImageRadioButton4);
            ShdwPanel.Controls.Add(this.label13);
            ShdwPanel.Controls.Add(this.guna2ImageRadioButton1);
            ShdwPanel.FillColor = System.Drawing.Color.White;
            ShdwPanel.Location = new System.Drawing.Point(3, 453);
            ShdwPanel.Name = "guna2ShadowPanel4";
            ShdwPanel.Radius = 12;
            ShdwPanel.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(4)))), ((int)(((byte)(83)))));
            ShdwPanel.ShadowDepth = 50;
            ShdwPanel.ShadowShift = 6;
            ShdwPanel.Size = new System.Drawing.Size(459, 144);
            ShdwPanel.TabIndex = 38;




            return ShdwPanel;
        }*/





        Guna2ShadowPanel Add_spanel(Label lbl, FlowLayoutPanel flow)
        {
            Guna2ShadowPanel Panel = new Guna2ShadowPanel();

            Panel.AutoScroll = true;
            Panel.BackColor = System.Drawing.Color.Transparent;
            Panel.Controls.Add(lbl);
            Panel.FillColor = System.Drawing.Color.White;
            Panel.Location = new System.Drawing.Point(3, 3);
            Panel.Name = "guna2ShadowPanel1";
            Panel.Radius = 12;
            Panel.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(4)))), ((int)(((byte)(83)))));
            Panel.ShadowShift = 6;
            Panel.Size = new System.Drawing.Size(540, 187);
            Panel.TabIndex = 0;
            Panel.Controls.Add(flow);
            return Panel;
        }


        Label add_Label(string Room_Name)
        {
            Label lbl = new Label();
            lbl.AutoSize = true;
            lbl.Font = new System.Drawing.Font("Roboto Light", 12F);
            lbl.Location = new System.Drawing.Point(19, 9);
            lbl.Name = Room_Name;
            lbl.Size = new System.Drawing.Size(75, 24);
            lbl.TabIndex = 0;
            lbl.Text = Room_Name;

            return lbl;
        }
        FlowLayoutPanel add_flowlayout(int id)
        {
            FlowLayoutPanel flow = new FlowLayoutPanel();
            flow.AutoScroll = true;
            flow.Location = new System.Drawing.Point(3, 3);
            flow.Name = "Layout"+id;
            flow.Size = new System.Drawing.Size(540, 150);
            flow.TabIndex = 1;
            flow.AllowDrop=true;
            flow.DragDrop += _DragDrop;
            flow.DragEnter += _DragEnter;

            return flow;
        }


        private void _DragEnter(object sender, DragEventArgs e)
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

        private void _DragDrop(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent(typeof(string)))
                return;

            var name = e.Data.GetData(typeof(string)) as string;
            var control = this.Controls.Find(name, true).FirstOrDefault();
            if (control != null)
            {
                //control.Parent.Controls.Remove(control);
                var panel = sender as FlowLayoutPanel;
                ((FlowLayoutPanel)sender).Controls.Add(control);
            }
        }



        


        public void Display()
        {
            flowLayoutPanel1.Controls.Clear();
            flowLayoutPanel2.Controls.Clear();
            flowLayoutPanel3.Controls.Clear();


            List<Models.Zone> List_Zones = new List<Models.Zone>();



            List_Zones = ZoneDA.Get_Zone_for_appart(1);



            foreach(Models.Zone zone in List_Zones )
            {
                Zone_ui Zone = new Zone_ui(this);

                ZoneDetails ZoneD= ZoneDetailsDA.Get_Zone_Details(zone.Id_zdetails);

                //MessageBox.Show(zone.Id_zone.ToString());


                Zone.Zone_id = zone.Id_zone; 
                Zone.Id=ZoneD.Id;
                Zone.Machinename = ZoneD.Name;



                flowLayoutPanel1.Controls.Add(Zone);

            }


           
            String q = "SELECT * FROM domitique.zone_details";

            cmd = DBHelper.RunQuery(q);
            int id;
            String nom;

           

            if (cmd != null)
            {
                dt = new DataTable();
                sda = new MySqlDataAdapter(cmd);
                sda.Fill(dt);

                Zone_ico[] list_zone = new Zone_ico[5];
                int j = 0;

                foreach (DataRow dr in dt.Rows)
                {
                    id = Convert.ToInt32(dr["idzone_details"]);
                    nom = dr["nom_zone"].ToString();
                    list_zone[j] = new Zone_ico();
                    list_zone[j].Id=id;
                    list_zone[j].Name1= nom;
                    list_zone[j].Image = nom;


                    flowLayoutPanel3.Controls.Add(list_zone[j]);

                    list_zone[j].DoubleClick += HandleDblClick;
                    j++;
                }
                
            }


            String query = "SELECT * FROM domitique.machine_details";


            cmd = DBHelper.RunQuery(query);

            int id_machine;
            String nom_machine;
            String type_machine;

            if(cmd != null) { 
                dt = new DataTable();
                sda = new MySqlDataAdapter(cmd);
                sda.Fill(dt);


                SimpleMachine[] list_machine= new SimpleMachine[12];
                Climatiseur Clima= new Climatiseur();
                Tlaja tlaja=new Tlaja();
                Sma3at sma3A = new Sma3at();
                Coffee cfe = new Coffee();
                Tv tv= new Tv();
               
                int i = 0;

                foreach(DataRow dr in dt.Rows)
                {
                    id_machine = Convert.ToInt32(dr["id_machine"]);
                    nom_machine = dr["nom_machine"].ToString();
                    type_machine = dr["type_machine"].ToString();


                    list_machine[i] = new SimpleMachine();

                    if (type_machine == "LAMP" || type_machine == "ROBOT" || type_machine == "RIDEAU" || type_machine == "DOOR")
                    {

                        list_machine[i].Id= id_machine;
                        list_machine[i].Lmp_lbl1 = nom_machine;
                        list_machine[i].Lmp_ts = false;
                        list_machine[i].Image= type_machine;

                        flowLayoutPanel2.Controls.Add(list_machine[i]);
                    }else if (type_machine == "TEMP")
                    {
                        Clima.Id= id_machine;
                        flowLayoutPanel2.Controls.Add(Clima);
                    }else if(type_machine=="FRGIDGE")
                    {
                        tlaja.Id= id_machine;
                        flowLayoutPanel2.Controls.Add(tlaja);
                    }
                    else if (type_machine == "SPEAKER")
                    {
                        sma3A.Id= id_machine;   
                        flowLayoutPanel2.Controls.Add(sma3A);
                    }else if (type_machine == "COFFEE")
                    {
                        cfe.Id = id_machine;
                        flowLayoutPanel2.Controls.Add(cfe);
                    }
                    else if(type_machine=="TV")
                    {
                        tv.Id = id_machine;
                        flowLayoutPanel2.Controls.Add(tv);
                    }
                 

                    i++;
                }
            }




            /*List<MachineDetails> list_machine = new List<MachineDetails>();

            list_machine = MachineDetailsDA.List_Machine();


            foreach(MachineDetails machine in list_machine)
            {
                if (machine.Type == "LAMP" || machine.Type=="ROBOT" || machine.Type=="CAMERA" || machine.Type=="RIDEAU" || machine.Type=="DOOR")
                {
                    Guna2ShadowPanel Shdwpnl = Add_Mechine_Panel(machine.Name,machine.Type);
                    flowLayoutPanel2.Controls.Add(Shdwpnl);
                }
            }




            /*foreach(Zone zone in All_Zone_perApr)
            {
                Label lbl = add_Label(zone.Nom_zone);
                FlowLayoutPanel flow = add_flowlayout();
                Guna2ShadowPanel Panel = Add_spanel(lbl, flow);
                flowLayoutPanel1.Controls.Add(Panel);
            }*/
        }

        void HandleDblClick(object sender, EventArgs e)
        {
            Zone_ico machine = (Zone_ico)sender;
            Zone_ui zone = new Zone_ui(this);
            zone.Machinename= machine.Name1;
            zone.Id= machine.Id;

            ZoneDA.Add_Zone(1.ToString(),machine.Id.ToString());
            Models.Zone Last_Zone = ZoneDA.Get_Last_Item();


            zone.Zone_id = Last_Zone.Id_zone;


            flowLayoutPanel1.Controls.Add(zone);

        }

        private void rooms_Load(object sender, EventArgs e)
        {
            Display();
        }

        

        private void guna2GradientCircleButton1_Click(object sender, EventArgs e)
        {
            
        }

        private void guna2GradientButton2_Click_1(object sender, EventArgs e)
        {
            Devices_list d = new Devices_list();
            d.Show();
        }
        
        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {


            int cnt = ZoneDA.Count_Zone(1);

            

           if(cnt < 5) {
                room_name r = new room_name(this);
                r.Show();
            }
            else
            {
                MessageBox.Show("U have Reached the Max Zone ");
            }
            


            /*Label lbl = add_Label();
            FlowLayoutPanel flow=add_flowlayout();
            Guna2ShadowPanel Panel = Add_spanel(lbl,flow);
            flowLayoutPanel1.Controls.Add(Panel);*/
        }

        /*private void flowLayoutPanel1_DragEnter(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent(typeof(string)))
                return;

            var name = e.Data.GetData(typeof(string)) as string;
            var control = this.Controls.Find(name, true).FirstOrDefault();
            if (control != null)
            {
                e.Effect = DragDropEffects.Move;
            }
        }

        private void flowLayoutPanel1_DragDrop(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent(typeof(string)))
                return;

            var name = e.Data.GetData(typeof(string)) as string;
            var control = this.Controls.Find(name, true).FirstOrDefault();
            if (control != null)
            {
                //control.Parent.Controls.Remove(control);
                var panel = sender as FlowLayoutPanel;
                ((FlowLayoutPanel)sender).Controls.Add(control);
            }
        }*/

        private void flowLayoutPanel2_DragEnter(object sender, DragEventArgs e)
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

        private void flowLayoutPanel2_DragDrop(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent(typeof(string)))
                return;

            var name = e.Data.GetData(typeof(string)) as string;
            var control = this.Controls.Find(name, true).FirstOrDefault();
            if (control != null)
            {
                //control.Parent.Controls.Remove(control);
                var panel = sender as FlowLayoutPanel;
                ((FlowLayoutPanel)sender).Controls.Add(control);
            }
        }

       /* private void flowLayoutPanel2_DragDrop_1(object sender, DragEventArgs e)
        {
            if(!e.Data.GetDataPresent(typeof(string)))
                return;

            var name = e.Data.GetData(typeof(string)) as string;
            var control = this.Controls.Find(name, true).FirstOrDefault();
            if (control != null)
            {
                control.Parent.Controls.Remove(control);
                var panel = sender as FlowLayoutPanel;
                ((FlowLayoutPanel)sender).Controls.Add(control);
            }
        }

        private void flowLayoutPanel2_DragEnter_1(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent(typeof(string)))
                return;

            var name = e.Data.GetData(typeof(string)) as string;
            var control = this.Controls.Find(name, true).FirstOrDefault();
            if (control != null)
            {
                e.Effect = DragDropEffects.Copy;
            }
        }*/
    }
}
