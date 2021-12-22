using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLyTruongMauGiao.Models;

namespace QuanLyTruongMauGiao.Controllers
{
    public class ThongKeController : Controller
    {
        private QLMauGiao db = new QLMauGiao();
        // GET: ThongKe
        public ActionResult Index()
        {
            if (Session["user"] != null)
            {
                ViewBag.Tre = db.TREs.Count();
                ViewBag.GiaoVien = db.GIAOVIENs.Count();
                ViewBag.PhieuThuTien = db.PHIEUTHUTIENs.Where(x => x.TrangThai == false).Count();
                ViewBag.AccountOL = db.TAIKHOANs.Where(x => x.TrangThaiHD == true).Count();
                ViewBag.NgayDiHoc = db.NGAYDIHOCs.ToList();

                var queryDSL = from tre in db.TREs
                               group tre by tre.MaLop into g
                               select new
                               {
                                   MaLop = g.Key,
                                   SoTre = g.Count()
                               };
                var query = from lop in db.LOPs
                            join x in queryDSL on lop.MaLop equals x.MaLop
                            select new
                            {
                                MaLop = lop.MaLop,
                                TenLop = lop.TenLop,
                                SoTre = x.SoTre
                            };

                Dictionary<string, int> list = new Dictionary<string, int>();
                foreach (var item in query.ToList())
                {
                    list.Add(item.TenLop, item.SoTre);
                }
                ViewBag.DSLop = list;
                return View(); 
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}