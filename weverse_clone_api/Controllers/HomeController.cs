using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace weverse_clone_api.Controllers
{
    public class HomeController : Controller
    {
        public String Index()
        {
            return "welcome. this is weverse clone api page.";
        }
    }
}
