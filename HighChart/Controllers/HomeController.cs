using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HighChart.Controllers
{
    public class HomeController : Controller
    {
        Database1Entities context = new Database1Entities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetData()
        {
            int male = context.Tables.Where(x => x.gender == "Male").Count();
            int female = context.Tables.Where(x => x.gender == "Female").Count();
            int other = context.Tables.Where(x => x.gender == "Other").Count();
            Ratio obj = new Ratio();
            obj.Male = male;
            obj.Female = female;
            obj.Other = other;

            return Json(obj,JsonRequestBehavior.AllowGet);
        }
        public class Ratio
        {
            public int Male { get; set; }
            public int Female { get; set; }
            public int Other { get; set; }
        }
    }
}