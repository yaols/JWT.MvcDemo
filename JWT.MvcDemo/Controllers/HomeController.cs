using JWT.Common;
using JWT.MvcDemo.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JWT.MvcDemo.Controllers
{

  
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Log4Help.Info("1111");
            Log4Help.Error("12345",null);
            return View();
        }

        [MyAuthorize]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return Json("Your application description page.",JsonRequestBehavior.AllowGet);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        public ActionResult Error()
        {
            return Json("权限不足", JsonRequestBehavior.AllowGet);
        }

    }
}