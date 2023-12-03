using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace weverse_clone_api.Databases
{
    public class Database
    {
        public string ConnectionString;

        public Database(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        

        public MySqlConnection GetConnection()
        {
            return new MySqlConnection(this.ConnectionString);
        }
    }
}
