using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using weverse_clone_api.Models;
using MySql.Data.MySqlClient;

namespace weverse_clone_api.Databases
{
    public class PostDB
    {
        public Database Database;
        public PostDB(Database database)
        {
            this.Database = database;
        }

        public List<Post> GetPosts(bool is_artist)
        {
            int is_artist_num = is_artist == true ? 1 : 0;
            List<Post> posts = new List<Post>();
            string SQL = "SELECT p.id AS id, " +
                "u.id AS user_id, " +
                "u.nickname AS user_nickname, " +
                "u.profile_img AS user_profile_img, " +
                "p.updated_date AS `date`, " +
                "p.content AS content, " +
                "p.likes AS `like`, " +
                "p.first_img_source AS `first_img_source`, " +
                "p.img_count AS img_count " +
                "FROM ( " +
                "    SELECT p.id AS id, p.user_id AS user_id, p.content AS content, p.updated_date AS updated_date, p.likes AS likes, i.img_source AS first_img_source, COUNT(i.id) AS img_count " +
                "    FROM posts AS p " +
                "    LEFT JOIN imgs AS i " +
                "    ON p.id = i.post_id " +
                "    GROUP BY p.id " +
                ") AS p " +
                "JOIN users AS u " +
                "ON p.user_id = u.id " +
                "WHERE u.is_artist = " + is_artist_num.ToString() + "\n" +
                "ORDER BY p.id DESC";

            using (MySqlConnection conn = this.Database.GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(SQL, conn);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        posts.Add(new Post()
                        {
                            id = Convert.ToInt32(reader["id"]),

                            user_id = Convert.ToInt32(reader["user_id"]),
                            user_nickname = reader["user_nickname"].ToString().Replace("\n", "<br/>"),
                            user_profile_img = reader["user_profile_img"].ToString().Replace("\n", "<br/>"),
                            date = reader["date"].ToString().Replace("\n", "<br/>"),
                            content = reader["content"].ToString().Replace("\n", "<br/>"),
                            like = Convert.ToInt32(reader["like"]),
                            first_img_source = reader["first_img_source"].ToString().Replace("\n", "<br/>"),
                            img_count = Convert.ToInt32(reader["img_count"])
                        });
                    }

                }
                conn.Close();
            }
            return posts;
        }

        public Post GetPost(int id)
        {
            Post post = new Post();
            string SQL = "SELECT p.id AS id, " +
                "u.id AS user_id, " +
                "u.nickname AS user_nickname, " +
                "u.profile_img AS user_profile_img, " +
                "p.updated_date AS `date`, " +
                "p.content AS content, " +
                "p.likes AS `like` " +
                "FROM posts AS p " +
                "JOIN users AS u " +
                "ON p.user_id = u.id " +
                "WHERE p.id = " + id.ToString() + "\n" +
                "ORDER BY p.id DESC";

            using (MySqlConnection conn = this.Database.GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(SQL, conn);

                using (var reader = cmd.ExecuteReader())
                {
                    if(reader.Read())
                    {

                        post.id = Convert.ToInt32(reader["id"]);

                        post.user_id = Convert.ToInt32(reader["user_id"]);
                        post.user_nickname = reader["user_nickname"].ToString().Replace("\n", "<br/>");
                        post.user_profile_img = reader["user_profile_img"].ToString().Replace("\n", "<br/>");
                        post.date = reader["date"].ToString().Replace("\n", "<br/>");
                        post.content = reader["content"].ToString().Replace("\n", "<br/>");
                        post.like = Convert.ToInt32(reader["like"]);
                        
                    }

                }
                conn.Close();
            }
            return post;
        }

        public List<string> GetImgs(int postId)
        {
            List<string> imgs_source = new List<string>();
            string SQL = "SELECT img_source FROM imgs WHERE post_id = " + postId.ToString();

            using (MySqlConnection conn = this.Database.GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(SQL, conn);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        imgs_source.Add(reader["img_source"].ToString());

                    }

                }
                conn.Close();
            }
            return imgs_source;
        }
    }
}
