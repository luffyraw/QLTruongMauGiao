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
        // GET: ChucNangGiaoVien
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult DiemDanh()
        {
            return View(db.TREs.ToList());
        }
        public ActionResult XemDanhSachLop()
        {
            return View(db.TREs.ToList());
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
        public ActionResult DanhGiaTre(string id)
        {
            return View(db.KETQUADANHGIAs.ToList());
        }
    }
}