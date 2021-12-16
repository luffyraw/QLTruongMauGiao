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
        public ActionResult CheckLogin(string username, string password)
        {
            var users = db.TAIKHOANs.Where(x => x.TenTK == username);
            if (users.Count() == 0)
            {
                ViewBag.Error = "Không tồn tại tài khoản này";
            }
            else
            {
                TAIKHOAN user = users.Single();
                if (user.MatKhau != password)
                {
                    ViewBag.Error = "Sai mật khẩu";
                }
                else if (user.PhanQuyen.Contains("Quản lý"))
                {
                    user.TrangThaiHD = true;
                    Session["user"] = user;
                    return RedirectToAction("Index", "Home");
                }
                else if (user.PhanQuyen.Contains("Giáo viên"))
                {
                    user.TrangThaiHD = true;
                    Session["user"] = user;
                    return RedirectToAction("HomePageGV", "Home");
                }
                else
                {
                    user.TrangThaiHD = true;
                    Session["user"] = user;
                    return RedirectToAction("HomePagePH", "Home");
                }
            }
            
            return View("Index");
        }
        public ActionResult Logout()
        {
            Session.Remove("user");
            return View("Index");
        }
    }
}