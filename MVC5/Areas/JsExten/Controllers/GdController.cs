using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5.Areas.GdMap.Controllers
{
    /// <summary>
    /// 用于高德地图
    /// </summary>
    public class GdController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

    }
}