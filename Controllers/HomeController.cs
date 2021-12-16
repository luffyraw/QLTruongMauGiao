using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyTruongMauGiao.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult HomePageGV()
        {
            return View();
        }
        public ActionResult HomePagePH()
        {
            return View();
        }

    }
}