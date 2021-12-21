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
            ViewBag.Tre = db.TREs.Count();
            ViewBag.GiaoVien = db.GIAOVIENs.Count();
            ViewBag.PhieuThuTien = db.PHIEUTHUTIENs.Where(x => x.TrangThai == false).Count();
            ViewBag.AccountOL = db.TAIKHOANs.Where(x => x.TrangThaiHD == true).Count();
            ViewBag.NgayDiHoc = db.NGAYDIHOCs.ToList();

            var queryDSL = from lop in db.LOPs
                           join tre in db.TREs on lop.MaLop equals tre.MaLop
                           group lop.MaLop by lop into g
                           select new
                           {
                               //MaLop = g.Key.MaLop,
                               TenLop = g.Key.TenLop,
                               SoTre = g.Count()
                            };
            Dictionary<string, int> list = new Dictionary<string, int>();
            foreach(var item in queryDSL.ToList())
            {
                list.Add(item.TenLop, item.SoTre);
            }
            ViewBag.DSLop = list;
            return View();
        }
    }
}