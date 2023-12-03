using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace weverse_clone_api.Models
{
    public class User
    {
        public int id;
        public string nickname;
        public string profile_img;
        public string sql;
        
        public override string ToString()
        {
            return "{" +
                "\"id\": " + this.id.ToString() + "," +
                "\"nickname\" : \"" + nickname + "\"," +
                "\"profile_img\" : \"" + profile_img + "\", " +
                "\"sql\": \"" + sql + "\"" +
            "}";
        }
    }

    
}
