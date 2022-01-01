using QuanLyTruongMauGiao.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using System.Data.Entity;

namespace QuanLyTruongMauGiao.Controllers
{
    public class ChucNangPhuHuynhController : Controller
    {
        private QLMauGiao db = new QLMauGiao();

        // GET: ChucNangPhuHuynh
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult DangKiBuaAn()
        {
            if (Session["user"] != null)
            {
                return View(db.THUCDONNGAYs.ToList());
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        public ActionResult DangKiBuaAn(bool choice)
        {
            TAIKHOAN account = (TAIKHOAN)Session["user"];
            var users = (from item in db.DIEMDANHs where item.TRE.PHUHUYNH.TenTK == account.TenTK select item).FirstOrDefault();
            if (choice == true)
                users.DangKiBuaAn = true;
            else users.DangKiBuaAn = false;
            db.SaveChanges();
            ViewBag.msg = "Đăng kí thành công!!!";
            return View();
        }
        public ActionResult XemDanhGia()
        {
            return View();
        }
        public ActionResult DongHocPhi()
        {
            TAIKHOAN account = (TAIKHOAN)Session["user"];
            var user = (from item in db.PHIEUTHUTIENs where item.TRE.PHUHUYNH.TenTK == account.TenTK select item).FirstOrDefault();
            user.TrangThai = true;
            db.SaveChanges();
            return View(db.DONGCHIPHIs.ToList());
        }
    }
}