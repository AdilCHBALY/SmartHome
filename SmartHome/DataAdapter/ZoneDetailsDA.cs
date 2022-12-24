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
    internal class ZoneDetailsDA
    {
        private static MySqlConnection cnx;
        private static MySqlCommand cmd = null;
        private static DataTable dt;
        private static MySqlDataAdapter sda;




        public static ZoneDetails Get_Zone_Details(int zoneId)
        {
            ZoneDetails ZoneD=null;

            String q = "SELECT * FROM domitique.zone_details WHERE idzone_details=(@0)";


            cmd = DBHelper.RunQuery(q, zoneId.ToString());

            if (cmd != null)
            {
                dt = new DataTable();
                sda = new MySqlDataAdapter(cmd);
                sda.Fill(dt);

                int _id_zone;
                string _nom_zone;

                foreach (DataRow dr in dt.Rows)
                {
                    _id_zone = Convert.ToInt32(dr["idzone_details"]);
                    _nom_zone = dr["nom_zone"].ToString();


                    ZoneD = new ZoneDetails(_id_zone,_nom_zone);

                }

            }



            return ZoneD;


        }

    }
}
