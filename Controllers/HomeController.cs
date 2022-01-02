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
            TAIKHOAN user = (TAIKHOAN)Session["user"];
            if (Session["user"] != null && user.PhanQuyen == "Quản lý")
            {
                return View(); 
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        public ActionResult HomePageGV()
        {
            TAIKHOAN user = (TAIKHOAN)Session["user"];
            if (Session["user"] != null && user.PhanQuyen == "Giáo viên")
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        public ActionResult HomePagePH()
        {
            TAIKHOAN user = (TAIKHOAN)Session["user"];
            if (Session["user"] != null && user.PhanQuyen == "Phụ huynh")
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
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

        public ActionResult ChangePassword()
        {
            if(Session["user"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        public ActionResult ChangePassword(string password_old,string password_new1,string password_new2)
        {
            if (password_old == "" || password_new1 == "" || password_new2 == "")
            {
                ViewBag.Error = "Không được để trống.";
            }
            else
            {
                TAIKHOAN user = (TAIKHOAN)Session["user"];
                if (password_old != user.MatKhau)
                {
                    ViewBag.Error = "Mật khẩu hiện tại không đúng.";
                }
                else
                {
                    if (password_new1 != password_new2)
                    {
                        ViewBag.Error = "Nhập lại mật khẩu mới phải trùng với mật khẩu mới.";
                    }
                    else
                    {
                        var users = db.TAIKHOANs.Where(x => x.TenTK == user.TenTK).FirstOrDefault();
                        users.MatKhau = password_new1;
                        db.SaveChanges();
                        ViewBag.msg = "Đổi mật khẩu thành công.";
                    }
                }
                
            }
            return View();
        }
    }
}