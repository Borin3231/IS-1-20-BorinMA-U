using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;

namespace ConnectBD
{
    public class Class1
    {
        string stringConnect;
        MySqlConnection conn;
        public MySqlConnection Connection()
        {
            conn = new MySqlConnection(stringConnect);
            return conn;
        }
        public string RecConnection()
        {
            return stringConnect;
        }
        public Class1(string connect)
        {
            stringConnect = connect;
        }


    }
}


