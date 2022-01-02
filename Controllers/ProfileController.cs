using QuanLyTruongMauGiao.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace QuanLyTruongMauGiao.Controllers
{
    public class ProfileController : Controller
    {
        // GET: Profile
        QLMauGiao db = new QLMauGiao();
        public ActionResult Index()
        {
            var user = Session["user"] as TAIKHOAN;
            if (user == null)
            {
                return RedirectToAction("Index", "home");
            }
            else if (user.PhanQuyen == "Quản lý")
                return View("ProfileAdmin");
            else if (user.PhanQuyen == "Giáo viên")
                return View("ProfileGV");
            else
                return View("ProfilePH");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditAdmin()
        {
            string magv = Request.Form["MaGV"];
            var user = (from item in db.GIAOVIENs where item.MaGV == magv select item).FirstOrDefault();
            user.DienThoai = Request.Form["DienThoai"];
            user.Email = Request.Form["Email"];

            var f = Request.Files["inputimg"];
            var account = (from item in db.TAIKHOANs where item.TenTK == user.TenTK select item).FirstOrDefault();
            string filename = magv + ".jpg";

            if (f != null)
            {
                string uploadPath = Server.MapPath("~/Image/GiaoVien/") + filename;
                if (System.IO.File.Exists(uploadPath))
                    System.IO.File.Delete(uploadPath);
                account.AnhDaiDien = filename;
                f.SaveAs(uploadPath);

            }
            db.SaveChanges();
            Session["user"] = account;

            return RedirectToAction("Index", "Profile");

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditGV()
        {
            string magv = Request.Form["MaGV"];
            var user = (from item in db.GIAOVIENs where item.MaGV == magv select item).FirstOrDefault();
            user.DienThoai = Request.Form["DienThoai"];
            user.Email = Request.Form["Email"];


            var f = Request.Files["inputimg"];
            string filename = magv + ".png";
            var account = (from item in db.TAIKHOANs where item.TenTK == user.TenTK select item).FirstOrDefault();

            if (f != null)
            {
                string uploadPath = Server.MapPath("~/Image/GiaoVien/") + filename;
                if (System.IO.File.Exists(uploadPath))
                    System.IO.File.Delete(uploadPath);
                account.AnhDaiDien = filename;
                f.SaveAs(uploadPath);

            }
            db.SaveChanges();
            Session["user"] = account;
            return RedirectToAction("Index", "Profile");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditPH()
        {
            string maph = Request.Form["MaPH"];
            var user = (from item in db.PHUHUYNHs where item.MaPH == maph select item).FirstOrDefault();
            user.DienThoai = Request.Form["DienThoai"];

            var f = Request.Files["inputimg"];
            string filename = maph + ".png";
            var account = (from item in db.TAIKHOANs where item.TenTK == user.TenTK select item).FirstOrDefault();

            if (f != null)
            {
                string uploadPath = Server.MapPath("~/Image/PhuHuynh/") + filename;
                if (System.IO.File.Exists(uploadPath))
                    System.IO.File.Delete(uploadPath);
                account.AnhDaiDien = filename;
                f.SaveAs(uploadPath);

            }
            db.SaveChanges();
            Session["user"] = account;
            return RedirectToAction("Index", "Profile");

        }

    }
}