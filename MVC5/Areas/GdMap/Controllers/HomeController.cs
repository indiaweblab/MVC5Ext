using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5.Areas.GdMap.Controllers
{
    public class HomeController : Controller
    {
        // GET: GdMap/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}