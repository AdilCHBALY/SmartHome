using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace SmartHome.Helper
{
    internal class DBHelper
    {
        private static MySqlConnection cnx;
        private static MySqlCommand cmd = null;
        private static DataTable dt;
        private static MySqlDataAdapter sda;


        //Connecting to Database :)

        public static void EstablishCnx()
        {
            try
            {
                MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder
                {
                    Server = "127.0.0.1",
                    UserID = "root",
                    Password = "123456",
                    Database = "domitique",
                    SslMode = MySqlSslMode.None
                };
                cnx = new MySqlConnection(builder.ToString());

            }
            catch (Exception err)
            {
                MessageBox.Show("Connection to database has Failed!");
            }
        }


        //RUN QUERY FOR EACH QUERY GIVEN 

        //HOW IT WORKS:

        /*
         * String q="INSERT UR QUERY U WANT "EX : SELECT * FROM TABLE_NAME
         * 
         * FOR EACH ARGUMENT U HAVE U NEED TO PUT AN INCREMENTING FROM 0 TO HOW EVER VALUES-1 U HAVE
         * 
         * EX : INSERT INTO TABLE_NAME VALUES((@0),(@1));
         * 
         * runquery(q,values);
         */

        public static MySqlCommand RunQuery(string query, params string[] values)
        {
            try
            {
                if (cnx != null)
                {
                    cnx.Open();
                    cmd = cnx.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = query;
                    int count = 0;
                    foreach (String value in values)
                    {
                        cmd.Parameters.AddWithValue("@" + count, value);
                        count++;
                    }
                    cmd.ExecuteNonQuery();
                    cnx.Close();

                }
            }
            catch (Exception err)
            {
                cnx.Close();
                MessageBox.Show("RunQuery Failed");
            }

            return cmd;
        }

        /*
         * IF U HAVE A DATA GRID USE THIS FUNCTION U PUT THE QUERY U WANNA USE WITH DATAGRIDVIEW 
         */

        public static void DisplayInGrid(String q, DataGridView dvg)
        {
            cmd = RunQuery(q);

            if (cmd != null)
            {
                dt = new DataTable();
                sda = new MySqlDataAdapter(cmd);
                sda.Fill(dt);
                dvg.DataSource = dt;
            }
        }
    }
}
