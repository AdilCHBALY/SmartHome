using MySql.Data.MySqlClient;
using Org.BouncyCastle.Utilities.Collections;
using SmartHome.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace SmartHome.DataAdapter
{
    internal class LogsDA
    {
        private static MySqlConnection cnx;
        private static MySqlCommand cmd = null;
        private static DataTable dt;
        private static MySqlDataAdapter sda;



        public static void Insert_Logs(params String[] args)
        {
            String q = "INSERT INTO domitique.logs ( `Date`, `Transaction`) VALUES((@0),(@1))";


            DBHelper.RunQuery(q,args);

        }
    }
}
