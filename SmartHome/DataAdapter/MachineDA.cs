using MySql.Data.MySqlClient;
using SmartHome.Helper;
using SmartHome.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.DataAdapter
{
    internal class MachineDA
    {
        private static MySqlConnection cnx;
        private static MySqlCommand cmd = null;
        private static DataTable dt;
        private static MySqlDataAdapter sda;


        public static void activateNightMode()
        {
            String q = "UPDATE domitique.machine SET Status = '0' WHERE id_mdetails = 4";

            DBHelper.RunQuery(q);   
        }

        /*public static void deactivateNightMode()
        {
            String q = "UPDATE domitique.machine SET Status = '1' WHERE id_mdetails = 4";

            DBHelper.RunQuery(q);
        }*/


        public static List<Machine> Get_Machine_ById(int id)
        {
            List<Machine> machines = new List<Machine>();

            String q = "SELECT * FROM domitique.machine WHERE id_zone=(@0)";

            cmd=DBHelper.RunQuery(q,id.ToString());

            if(cmd != null)
            {
                dt = new DataTable();
                sda = new MySqlDataAdapter(cmd);
                sda.Fill(dt);


                int id_machine;
                bool status;
                int id_zone;
                int id_mdetails;


                foreach (DataRow dr in dt.Rows)
                {
                    id_machine = Convert.ToInt32(dr["id_machine"]);
                    id_zone = Convert.ToInt32(dr["id_zone"]);
                    id_mdetails = Convert.ToInt32(dr["id_mdetails"]);
                    status = Convert.ToBoolean(dr["Status"]);

                    machines.Add(new Machine(id_machine, status,id_zone,id_mdetails));

                }

            }


            return machines;
        }






        public static void Add_Machine(params String[] Values)
        {
            String q = "INSERT INTO domitique.machine (Status,id_zone,id_mdetails) VALUES ((@0),(@1),(@2))";

            DBHelper.RunQuery(q, Values);
        }

        public static void Delete_Machine(int id)
        {
            String q = "DELETE FROM domitique.machine WHERE id_machine = (@0)";

            DBHelper.RunQuery(q, id.ToString());
        }

        //TO CHANGE LATER 

        public static void Update_Status(params String[] Values)
        {
            String q = "UPDATE domitique.machine SET Status = (@1) WHERE id_machine = (@0)";

            DBHelper.RunQuery(q, Values);
        }
    }
}
