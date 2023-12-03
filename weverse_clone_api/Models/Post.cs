using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace weverse_clone_api.Models
{
    public class Post
    {
        public int id;
        public int user_id;
        public string user_nickname;
        public string user_profile_img;
        public string date;
        public string content;
        public int like;
        public string first_img_source= "";
        public int img_count = 0;

        public List<string> imgs_source = new List<string>();

        public override string ToString()
        {
            return "{" + 
                String.Format(
                "\"id\": {0}, " +
                "\"user_id\": {1}, " +
                "\"user_nickname\": \"{2}\", " +
                "\"user_profile_img\": \"{3}\", " +
                "\"date\": \"{4}\", " +
                "\"content\": \"{5}\", " +
                "\"like\": {6}," + 
                "\"first_img_source\": \"{7}\"," +
                "\"img_count\": {8}," +
                "\"imgs_source\" : [\"{9}\"]", this.id, this.user_id, this.user_nickname, this.user_profile_img, this.date, this.content, this.like, this.first_img_source, this.img_count, String.Join("\", \"", imgs_source) ) +
                "}";
        }
    }
}
