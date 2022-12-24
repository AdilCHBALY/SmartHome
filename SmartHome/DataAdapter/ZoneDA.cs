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
    internal class ZoneDA
    {
        private static MySqlConnection cnx;
        private static MySqlCommand cmd = null;
        private static DataTable dt;
        private static MySqlDataAdapter sda;


        /*public static int Get_Zone_Id(String nom_appartement)
        {
            int id = 0;

            String q = "SELECT id_zone FROM domitique.zone WHERE nom_appartement = (@0)";

            cmd = DBHelper.RunQuery(q, nom_appartement);


            if (cmd != null)
            {
                dt = new DataTable();
                sda = new MySqlDataAdapter(cmd);
                sda.Fill(dt);

                foreach (DataRow dr in dt.Rows)
                {
                    id = Convert.ToInt32(dr["id_appartement"]);

                }
            }
            return id;
        }*/

        public static Zone Get_Single_Zone(params String[] Values)
        {
            Zone aZone = null;

            String q = "SELECT * FROM domitique.zone WHERE id_appr = (@0) AND id_zone = (@1) LIMIT 1";

            cmd = DBHelper.RunQuery(q, Values);

            if (cmd != null)
            {

                dt = new DataTable();
                sda = new MySqlDataAdapter(cmd);
                sda.Fill(dt);

                foreach (DataRow dr in dt.Rows)
                {
                    int id = Convert.ToInt32(dr["id_zone"]);
                    int id_zdetails = Convert.ToInt32(dr["id_zdetails"]);
                    int id_apprt = Convert.ToInt32(dr["id_appr"]);

                    aZone = new Zone(id, id_zdetails, id_apprt);

                }
            }
            return aZone;
        }


        public static void ShutDown(params String[] Values)
        {
            String q = "UPDATE domitique.machine SET Status = '0' WHERE id_zone = (@0)";

            DBHelper.RunQuery(q, Values);
        }

        public static void Ch3al(params String[] Values)
        {
            String q = "UPDATE domitique.machine SET Status = '1' WHERE id_zone = (@0)";

            DBHelper.RunQuery(q, Values);
        }


        public static int Count_Zone(int id_appr)
        {
            int i = 0;

            String q = " SELECT count(*) as cnt FROM domitique.zone";

            cmd = DBHelper.RunQuery(q);
           

            if (cmd != null)
            {
                dt = new DataTable();
                sda = new MySqlDataAdapter(cmd);
                sda.Fill(dt);

                foreach (DataRow dr in dt.Rows)
                {
                    i = Convert.ToInt32(dr["cnt"]);            

                }
            }
            return i;
        }

        public static Zone Get_Last_Item()
        {
            Zone aZone = null;
            String q = "SELECT * FROM domitique.zone ORDER BY id_zone DESC LIMIT 1";
            cmd=DBHelper.RunQuery(q);

            if(cmd!= null)
            {
                dt = new DataTable();
                sda = new MySqlDataAdapter(cmd);
                sda.Fill(dt);
                int id;
                int id_zdetails;
                int id_apprt;

                foreach (DataRow dr in dt.Rows)
                {

                    id = Convert.ToInt32(dr["id_zone"]);
                    id_zdetails = Convert.ToInt32(dr["id_zdetails"]);
                    id_apprt = Convert.ToInt32(dr["id_appr"]);

                    aZone = new Zone(id, id_zdetails, id_apprt);

                }

            }
            return aZone;
        }
   


        public static List<Zone> Get_Zone_for_appart(int id_appr)
        {
            List<Zone> all_zones=new List<Zone>();

            String q = "SELECT * FROM domitique.zone WHERE id_appr = (@0)";

            cmd = DBHelper.RunQuery(q, id_appr.ToString());
            int id;
            int id_zdetails;
            int id_apprt;

            if (cmd != null)
            {
                dt = new DataTable();
                sda = new MySqlDataAdapter(cmd);
                sda.Fill(dt);
                

                foreach (DataRow dr in dt.Rows)
                {
                    id = Convert.ToInt32(dr["id_zone"]);
                    id_zdetails = Convert.ToInt32(dr["id_zdetails"]);
                    id_apprt = Convert.ToInt32(dr["id_appr"]);

                    all_zones.Add(new Zone(id, id_zdetails, id_apprt));

                }
            }
            return all_zones;
        }


        public static void Add_Zone(params String[] Values)
        {
            String q = "INSERT INTO domitique.zone ( id_appr,id_zdetails) VALUES ((@0),(@1))";

            DBHelper.RunQuery(q, Values);

        }

        public static void Delete_Zone(String id)
        {
            String q = "DELETE FROM domitique.zone WHERE id_zone = (@0)";
            DBHelper.RunQuery(q, id);
        }


        public static void Edit_Zone(params String[] Values)
        {
            String q = "UPDATE domitique.zone SET nom_zone = (@1) , id_appr = (@2) WHERE id_zone = (@0)";
            DBHelper.RunQuery(q, Values);
        }
    }
}
