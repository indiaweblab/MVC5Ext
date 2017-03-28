using IBLL.High;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5.Areas.IOC.Controllers
{
    public class AutoMvcController : Controller
    {
        readonly IStudentRepository repository;

        public AutoMvcController(IStudentRepository repository)
        {
            this.repository = repository;
        }

        // GET: IOC/AutoMvc
        public JsonResult Index()
        {
            var data = repository.Add(new Model.High.Student());
            return Json(data);
        }
    }
}