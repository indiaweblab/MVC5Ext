using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5.Controllers
{
    public class IOCController : Controller
    {
        // GET: IOC
        public ActionResult Index()
        {
            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterType<DBManager>();
            builder.RegisterModule(new Config ("autofac"));

            //var builder = new ContainerBuilder();
            //builder.RegisterType<DBManager>();
            //builder.RegisterType<SqlDAL>().As<IDAL>();
            //using (var container = builder.Build())
            //{
            //    var manager = container.Resolve<DBManager>();
            //    manager.Add("ffffffffffffffffff");
            //}
            return View();
        }
        public class DBManager
        {
            IDAL _dal;
            public DBManager(IDAL dal)
            {
                _dal = dal;
            }
            public void Add(string commandText)
            {
                _dal.Insert(commandText);
            }
        }

        public interface IDAL
        {
            void Insert(string commandText);
        }
        public class SqlDAL : IDAL
        {
            public void Insert(string commandText)
            {
                Console.WriteLine("使用sqlDAL添加相关信息");
            }
        }
        public class OracleDAL : IDAL
        {
            public void Insert(string commandText)
            {
                Console.WriteLine("使用OracleDAL添加相关信息");
            }
        }
    }
}