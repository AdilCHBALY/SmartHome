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
    internal class HomaMachineDA
    {


        private static MySqlConnection cnx;
        private static MySqlCommand cmd = null;
        private static DataTable dt;
        private static MySqlDataAdapter sda;






        public static HomeMachine Get_Home_Machines(int id)
        {
            HomeMachine Home_Machines=null;
            String q = "SELECT * FROM domitique.homemachine WHERE id_home_machine = (@0)";

            cmd = DBHelper.RunQuery(q,id.ToString()) ;

            if (cmd != null)
            {
                dt = new DataTable();
                sda = new MySqlDataAdapter(cmd);
                sda.Fill(dt);

                int _id;
                bool _status;

                foreach (DataRow dr in dt.Rows)
                {
                    _id = Convert.ToInt32(dr["id_home_machine"]);
                    _status = Convert.ToBoolean(dr["Status"]);

                    Home_Machines = new HomeMachine(_id, _status);  

                }
            }
            return Home_Machines;
        }

        public static void On_Off(int id,string status)
        {
            String q = "UPDATE domitique.homemachine SET Status = (@1) WHERE id_home_machine = (@0)";
            DBHelper.RunQuery(q,id.ToString(),status);
        }

    }
}
