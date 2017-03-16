using BLL;
using Model;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using WebControl;

namespace MVC5.Controllers
{
    #region :Controller
    //public class HomeController : Controller
    //{
    //    // GET: Home
    //    public ActionResult Index()
    //    {
    //        IList<CONFIG_TYPE> model = com.CONFIG_TYPE.ToList();
    //        return View(model);
    //    }
    //    public ActionResult Edit(int Id)
    //    {
    //        var tem = com.CONFIG_TYPE.Find(Id);
    //        return View(tem);
    //    }

    //    [HttpPost]
    //    public ActionResult Edit(CONFIG_TYPE model)
    //    {
    //        com.Entry<CONFIG_TYPE>(model).State = EntityState.Modified;
    //        com.SaveChanges();
    //        return View(model);
    //    }

    //    public ActionResult Details(CONFIG_TYPE model)
    //    {
    //        com.CONFIG_TYPE.Find(model.Id);
    //        return View(model);
    //    }
    //    public ActionResult Delete(CONFIG_TYPE model)
    //    {
    //        var removeModel = com.CONFIG_TYPE.Find(model.Id);
    //        com.CONFIG_TYPE.Remove(removeModel);
    //        com.SaveChanges();
    //        return View("index", "");
    //    }
    //    public ActionResult Create()
    //    {
    //        return View();
    //    }
    //    [HttpPost]
    //    public ActionResult Create(CONFIG_TYPE model)
    //    {
    //        com.CONFIG_TYPE.Add(model);
    //        com.SaveChanges();
    //        return View("details", model);
    //    }
    //}
    #endregion

    public class HomeController : Controller
    {
        private MyContext com = new MyContext();           
        // GET: Home
        public ActionResult Index()
        {
            IList<CONFIG_TYPE> model = com.CONFIG_TYPE.ToList();
            return View(model);
        }
        public ActionResult Edit(int Id)
        {
            var tem = com.CONFIG_TYPE.Find(Id);
            return View(tem);
        }

        [HttpPost]
        public ActionResult Edit(CONFIG_TYPE model)
        {
            com.Entry<CONFIG_TYPE>(model).State = EntityState.Modified;
            com.SaveChanges();
            return View(model);
        }

        public ActionResult Details(CONFIG_TYPE model)
        {
            com.CONFIG_TYPE.Find(model.Id);
            return View(model);
        }
        public ActionResult Delete(CONFIG_TYPE model)
        {
            var removeModel = com.CONFIG_TYPE.Find(model.Id);
            com.CONFIG_TYPE.Remove(removeModel);
            com.SaveChanges();
            return View("index","");
        }     
       public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(CONFIG_TYPE model)
        {
            com.CONFIG_TYPE.Add(model);
            com.SaveChanges();
            return View("details" , model);
        }
    }
}