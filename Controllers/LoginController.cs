using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QuanLyTruongMauGiao.Models;


namespace QuanLyTruongMauGiao.Controllers
{
    public class LoginController : Controller
    {
        private QLMauGiao db = new QLMauGiao();

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
       
    }
}