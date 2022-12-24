using MySql.Data.MySqlClient;
using SmartHome.Helper;
using SmartHome.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static SmartHome.home.WeatherInfo;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace SmartHome.DataAdapter
{
    internal class AdminDA
    {
        private static MySqlConnection cnx;
        private static MySqlCommand cmd = null;
        private static DataTable dt;
        private static MySqlDataAdapter sda;


        public static String Get_User_Name(int User_id)
        {
            String aUser = null;

            String q = "SELECT login FROM domitique.utilisateur WHERE iduser=(@0)";

            cmd = DBHelper.RunQuery(q, User_id.ToString());
            
            if (cmd != null)
            {
               
                dt = new DataTable();
                sda = new MySqlDataAdapter(cmd);
                sda.Fill(dt);

                foreach (DataRow dr in dt.Rows)
                {
                    aUser = dr["login"].ToString();
                }
            }

            return aUser;
        }



        public static Admin Authentification(String username)
        {

            String q = "SELECT * FROM domitique.utilisateur WHERE login = (@0) LIMIT 1";


            cmd = DBHelper.RunQuery(q, username);

            Admin admin = null;
            //MessageBox.Show(cmd.ToString());

            if (cmd != null)
            {
                dt = new DataTable();
                sda = new MySqlDataAdapter(cmd);
                sda.Fill(dt);

                foreach (DataRow dr in dt.Rows)
                {
                    int id = Convert.ToInt32(dr["iduser"]);
                    String login = dr["login"].ToString();
                    String mdp = dr["mdp"].ToString();
                    bool isAdmin = Convert.ToBoolean(dr["isAdmin"]);
                    admin = new Admin(id, login, mdp, isAdmin);

                    


                }

            }

            return admin;
        }


        public static void Add_User(params String[] Values)
        {
            String q = "INSERT INTO domitique.utilisateur (login,mdp) VALUES ((@0),(@1))";

            DBHelper.RunQuery(q, Values);
        }

        public static Admin Get_Connected_id()
        {
            String q = "SELECT * FROM domitique.utilisateur WHERE isConnceted = '1' LIMIT 1";


            cmd = DBHelper.RunQuery(q);

            Admin admin = null;
            //MessageBox.Show(cmd.ToString());

            if (cmd != null)
            {
                dt = new DataTable();
                sda = new MySqlDataAdapter(cmd);
                sda.Fill(dt);

                foreach (DataRow dr in dt.Rows)
                {
                    int id = Convert.ToInt32(dr["iduser"]);
                    String login = dr["login"].ToString();
                    String mdp = dr["mdp"].ToString();
                    bool isAdmin = Convert.ToBoolean(dr["isAdmin"]);
                    admin = new Admin(id, login, mdp, isAdmin);

                }

            }

            return admin;
        }
        public static void Connect(int id)
        {
            String q = "UPDATE domitique.utilisateur SET isConnceted = '1' WHERE iduser = (@0)";


            DBHelper.RunQuery(q,id.ToString());
        }
        public static void Disconnect(int id)
        {
            String q = "UPDATE domitique.utilisateur SET isConnceted = '0' WHERE iduser = (@0)";
           

            DBHelper.RunQuery(q, id.ToString());
        }

        public static void Change_Password(params String[] Values)
        {
            String q = "UPDATE domitique.utilisateur SET mdp = (@1) WHERE login = (@0)";

            DBHelper.RunQuery(q, Values);
        }
    }
}
