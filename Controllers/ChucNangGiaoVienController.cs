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
    public class ChucNangGiaoVienController : Controller
    {
        private QLMauGiao db = new QLMauGiao();
        public int CheckLogin()
        {
            var user = Session["user"] as TAIKHOAN;
            if (user != null && user.PhanQuyen == "Quản lý")
                return 0;
            if (user != null && user.PhanQuyen == "Phụ huynh")
                return 1;
            if (user != null && user.PhanQuyen == "Giáo viên")
                return 2;
            return -1;
        }

        // GET: ChucNangGiaoVien
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult DiemDanh()
        {
            return View(db.TREs.ToList());
        }
        public ActionResult XemDanhSachLop(string maLop)
        {
            if (CheckLogin() == -1)
                return RedirectToAction("index", "Home");
            if (CheckLogin() == 1)
                return RedirectToAction("HomePagePH", "Home");
            if (CheckLogin() == 2)
            {
                return View(db.TREs.ToList());
            }
            return View();
        }
        public ActionResult Xemchitiet(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TRE tRE = db.TREs.Find(id);
            if (tRE == null)
            {
                return HttpNotFound();
            }
            return View(tRE);
        }
        public ActionResult DanhSachDanhGia()
        {
            return View(db.TREs.ToList());
        }
        public ActionResult DanhGiaTre(string maGV, string ngayLap, string namHoc, string theChat, string sucKhoe, string hoaDong)
        {
            TAIKHOAN account = (TAIKHOAN)Session["user"];
            var user = (from item in db.KETQUADANHGIAs where item.PHIEUDANHGIA.TRE.PHUHUYNH.TenTK == account.TenTK select item).FirstOrDefault();
            KETQUADANHGIA kq = new KETQUADANHGIA();
            return View(db.KETQUADANHGIAs.ToList());
        }
    }
}