using MySql.Data.MySqlClient;
using SmartHome.Helper;
using SmartHome.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.DataAdapter
{
    internal class MachineDetailsDA
    {

        private static MySqlConnection cnx;
        private static MySqlCommand cmd = null;
        private static DataTable dt;
        private static MySqlDataAdapter sda;


        public static MachineDetails Machine_Detail(int id)
        {
            MachineDetails machined=null;

            String q = "SELECT * FROM domitique.machine_details WHERE id_machine=(@0)";


            cmd = DBHelper.RunQuery(q, id.ToString());

            if (cmd != null)
            {
                dt = new DataTable();
                sda = new MySqlDataAdapter(cmd);
                sda.Fill(dt);
                int idm;
                String nom;
                String type;

                foreach (DataRow dr in dt.Rows)
                {
                    idm = Convert.ToInt32(dr["id_machine"]);
                    nom = dr["nom_machine"].ToString();
                    type = dr["type_machine"].ToString();

                    machined=new MachineDetails(idm, nom, type);

                }

            }


            return machined;
        }




        public static List<MachineDetails> List_Machine() {
            List<MachineDetails> all_list= new List<MachineDetails>();
            String q = "SELECT * FROM domitique.machine_details";

            cmd=DBHelper.RunQuery(q);

            int id;
            String nom;
            String type;

            if (cmd != null)
            {

                dt = new DataTable();
                sda = new MySqlDataAdapter(cmd);
                sda.Fill(dt);

                foreach (DataRow dr in dt.Rows)
                {
                    id = Convert.ToInt32(dr["id_machine"]);
                    nom = dr["nom_machine"].ToString();
                    type = dr["type_machine"].ToString();

                    all_list.Add(new MachineDetails(id, nom, type));

                }
            }
            return all_list;
        }

    }
}
