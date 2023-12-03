using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using weverse_clone_api.Models;
using MySql.Data.MySqlClient;

namespace weverse_clone_api.Databases
{
    public class UserDB
    {
        public Database Database;
        public UserDB(Database database)
        {
            this.Database = database;
        }
        public bool IsLogin(string ip)
        {
            string SQL = "SELECT IF(COUNT(id) > 0, 1, 0) AS islogin \n" +
                "FROM islogin \n" +
                "WHERE ip=\"" + ip.ToString() + "\"" + "\n" +
                "ORDER BY id DESC";

            using (MySqlConnection conn = this.Database.GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(SQL, conn);

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        if (Convert.ToInt32(reader["islogin"]) == 1)
                        {
                            conn.Close();
                            return true;
                        }
                        else
                        {
                            
                            
                        }
                    }

                }
                conn.Close();
                return false;
            }
        }
        public User GetUserInfo(int id)
        {
            User user = new User();
            string SQL = "SELECT id, nickname, profile_img \n" +
                "FROM users \n" +
                "where id=" + id.ToString() +"\n"+ 
                "ORDER BY id DESC";
            
            using(MySqlConnection conn = this.Database.GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(SQL, conn);

                using(var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        user.id = Convert.ToInt32(reader["id"]);
                        user.nickname = reader["nickname"].ToString();
                        user.profile_img = reader["profile_img"].ToString();
                        user.sql = SQL;
                    }
                    
                }
                conn.Close();
            }
            return user;
        }
    }
}
