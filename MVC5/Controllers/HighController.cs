using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5.Controllers
{
    public class HighController : Controller
    {
        // GET: High
        public ActionResult Index()
        {
            return View();
        }
    }
}