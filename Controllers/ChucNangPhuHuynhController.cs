using QuanLyTruongMauGiao.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLyTruongMauGiao.Models;
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
        public ActionResult DangKiBuaAn(DateTime? startdate, DateTime? enddate, int? page)
        {
            IQueryable<THUCDONNGAY> thucdons = db.THUCDONNGAYs;

            if (startdate != null && enddate != null)
            {
                thucdons = thucdons.Where(td => td.Ngay >= startdate && td.Ngay <= enddate);
            }
            thucdons = thucdons.OrderBy(td => td.Ngay);
            return View(db.THUCDONNGAYs.ToList());
        }
        public ActionResult XemDanhGia()
        {
            return View(db.KETQUADANHGIAs.ToList());
        }
        public ActionResult DongHocPhi()
        {
            return View(db.DONGCHIPHIs.ToList());
        }
    }
}