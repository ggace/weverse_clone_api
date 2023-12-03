using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
using MySql.Data.MySqlClient;
using System;

using weverse_clone_api.Databases;
using weverse_clone_api.Models;

namespace weverse_clone_api.Controllers
{
    public class UserController : Controller
    {
        public UserDB userDb;
        public void CheckUserDB(Database database)
        {
            if(userDb == null)
            {
                this.userDb = new UserDB(database);
            }
        }
        public string GetUser(int id)
        {
            
            Database database = HttpContext.RequestServices.GetService(typeof(Database)) as Database;
            CheckUserDB(database);
            User user = userDb.GetUserInfo(id);
            return user.ToString();
        }

        public bool IsLogin()
        {
            Database database = HttpContext.RequestServices.GetService(typeof(Database)) as Database;
            CheckUserDB(database);
            return userDb.IsLogin(HttpContext.Connection.RemoteIpAddress?.ToString());
        }
    }
}