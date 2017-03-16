using Model.toobar.Monely;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5.Areas.toobar.Controllers
{
    /// <summary>
    /// 用于理财的小工具
    /// </summary>
    public class MonelyController : Controller
    {

        // GET: toobar/Monely
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult FacGetPar(int type)
        {
            string viewName = "";
            switch ( (MonelyModel)type)
            {
                case MonelyModel.利率对比: viewName = "GetRate";break;
                case MonelyModel.分期收益: viewName = "GetTest";break;
            }
            return PartialView(viewName);
        }


        #region 金融组件
        public ActionResult GetRate()
        {
            return PartialView();
        }
        #endregion

        private ContentResult GetTest()
        {
            return  Content("this is test    ");
        }

        public ActionResult GetChart()
        {
            return View();
        }
    }
}