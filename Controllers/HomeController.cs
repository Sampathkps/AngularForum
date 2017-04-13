using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AngularForum.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
                
        }

        public ActionResult Forum()
        {
            return Redirect("http://localhost:56984/#/forum");
        }
    }
}