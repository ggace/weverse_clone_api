using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using weverse_clone_api.Databases;
using weverse_clone_api.Models;

namespace weverse_clone_api.Controllers
{
    public class PostController : Controller
    {
        public PostDB postDb;
        public void CheckUserDB(Database database)
        {
            if (postDb == null)
            {
                this.postDb = new PostDB(database);
            }
        }
        public String GetUserPosts()
        {
            Database database = HttpContext.RequestServices.GetService(typeof(Database)) as Database;
            CheckUserDB(database);
            List<Post> posts = postDb.GetPosts(false);
            return "[" + String.Join(", ", posts) + "]";
        }

        public String GetArtistPosts()
        {
            Database database = HttpContext.RequestServices.GetService(typeof(Database)) as Database;
            CheckUserDB(database);
            List<Post> posts = postDb.GetPosts(true);
            return "[" + String.Join(", ", posts) + "]";
        }

        public String GetPost(int id)
        {
            Database database = HttpContext.RequestServices.GetService(typeof(Database)) as Database;
            CheckUserDB(database);
            Post post = postDb.GetPost(id);
            post.imgs_source = postDb.GetImgs(id);
            return post.ToString();
        }
    }
}
