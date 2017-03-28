using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5.Areas.APIExten.Controllers
{
    public class indexController : Controller
    {
        // GET: APIExten/index
        public ActionResult Index()
        {
            return View();
        }
    }
}