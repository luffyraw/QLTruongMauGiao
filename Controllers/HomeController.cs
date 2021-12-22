using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLyTruongMauGiao.Models;

namespace QuanLyTruongMauGiao.Controllers
{
    public class HomeController : Controller
    {
        private QLMauGiao db = new QLMauGiao();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult HomePageAdmin()
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
                    db.SaveChanges();
                    Session["user"] = user;
                    return RedirectToAction("HomePageAdmin");
                }
                else if (user.PhanQuyen.Contains("Giáo viên"))
                {
                    user.TrangThaiHD = true;
                    db.SaveChanges();
                    Session["user"] = user;
                    return RedirectToAction("HomePageGV");
                }
                else
                {
                    user.TrangThaiHD = true;
                    db.SaveChanges();
                    Session["user"] = user;
                    return RedirectToAction("HomePagePH");
                }
            }

            return View("Index");
        }
        public ActionResult Logout()
        {
            TAIKHOAN user =(TAIKHOAN) Session["user"];

            var users = db.TAIKHOANs.Where(x => x.TenTK == user.TenTK).FirstOrDefault();
            users.TrangThaiHD = false;
            db.SaveChanges();
            Session.Remove("user");
            return View("Index");
        }

    }
}