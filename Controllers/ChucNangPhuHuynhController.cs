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
                return RedirectToAction("Index","Home");
            }
        }

        public class ParamDangKyBuaAn
        {
            public DateTime date { get; set; }
            public bool select { get; set; }
        }

        [HttpPost]
        public ActionResult DangKiBuaAn(ParamDangKyBuaAn[] data)
        {
            TAIKHOAN account = (TAIKHOAN)Session["user"];
            var phuhuynh = (from ph in db.PHUHUYNHs
                            where ph.TenTK == account.TenTK
                            select ph).FirstOrDefault();
            var MaTre = (from t in db.TREs

                       where t.MaPH == phuhuynh.MaPH
                       select t).FirstOrDefault().MaTre;
            try
            {
                if (data != null)
                {
                    foreach (var item in data)
                    {
                        var query = (from x in db.DIEMDANHs
                                     where x.MaTre == MaTre && x.Ngay == item.date
                                     select x).FirstOrDefault();
                        if (query == null)
                        {
                            DIEMDANH diemDanh = new DIEMDANH();
                            diemDanh.MaTre = MaTre;
                            diemDanh.Ngay = item.date;
                            diemDanh.DiemDanh1 = false;
                            diemDanh.DangKiBuaAn = item.select;
                            db.DIEMDANHs.Add(diemDanh);
                        }
                        else
                        {
                            query.DangKiBuaAn = item.select;
                        }
                        db.SaveChanges();
                    }
                    return Json("Đăng kí thành công", JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {

                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }

            return View(db.THUCDONNGAYs.ToList());

            //IQueryable<THUCDONNGAY> thucdons = db.THUCDONNGAYs;
            //if (startdate != null && enddate != null)
            //{
            //    thucdons = thucdons.Where(td => td.Ngay >= startdate && td.Ngay <= enddate);
            //}
            //thucdons = thucdons.OrderBy(td => td.Ngay);


            //var users = (from item in db.DIEMDANHs where item.TRE.PHUHUYNH.TenTK == account.TenTK select item).FirstOrDefault();
            //if (param != null)
            //{
            //    foreach (ParamDangKyBuaAn i in param)
            //    {
            //        Console.WriteLine(i.Date);
            //        Console.WriteLine(i.Select);
            //        if (i.Date == users.Ngay)
            //        {
            //            if (i.Select == true)
            //                users.DangKiBuaAn = true;
            //            else users.DangKiBuaAn = false;
            //            db.SaveChanges();
            //        }
            //        else
            //        {
            //            DIEMDANH diemDanh = new DIEMDANH();
            //            diemDanh.MaTre = users.MaTre;
            //            diemDanh.Ngay = (DateTime)i.Date;
            //            diemDanh.DiemDanh1 = true;
            //            if (i.Select == true)
            //                diemDanh.DangKiBuaAn = true;
            //            else diemDanh.DangKiBuaAn = false;
            //            db.DIEMDANHs.Add(diemDanh);
            //            db.SaveChanges();
            //        }
            //    }
            //}
            //return View();
        }




        //[HttpPost]
        //public ActionResult DangKiBuaAn(List<ParamDangKyBuaAn> param, DateTime? startdate, DateTime? enddate)
        //{
        //    IQueryable<THUCDONNGAY> thucdons = db.THUCDONNGAYs;
        //    if (startdate != null && enddate != null)
        //    {
        //        thucdons = thucdons.Where(td => td.Ngay >= startdate && td.Ngay <= enddate);
        //    }
        //    thucdons = thucdons.OrderBy(td => td.Ngay);

        //    TAIKHOAN account = (TAIKHOAN)Session["user"];
        //    var users = (from item in db.DIEMDANHs where item.TRE.PHUHUYNH.TenTK == account.TenTK select item).FirstOrDefault();
        //    if (param != null)
        //    {
        //        foreach (ParamDangKyBuaAn i in param)
        //        {
        //            Console.WriteLine(i.Date);
        //            Console.WriteLine(i.Select);
        //            if (i.Date == users.Ngay)
        //            {
        //                if (i.Select == true)
        //                    users.DangKiBuaAn = true;
        //                else users.DangKiBuaAn = false;
        //                db.SaveChanges();
        //            }
        //            else
        //            {
        //                DIEMDANH diemDanh = new DIEMDANH();
        //                diemDanh.MaTre = users.MaTre;
        //                diemDanh.Ngay = (DateTime)i.Date;
        //                diemDanh.DiemDanh1 = true;
        //                if (i.Select == true)
        //                    diemDanh.DangKiBuaAn = true;
        //                else diemDanh.DangKiBuaAn = false;
        //                db.DIEMDANHs.Add(diemDanh);
        //                db.SaveChanges();
        //            }
        //        }
        //    }
        //    return View();
        //}




        public ActionResult XemDanhGia()
        {
            return View(db.KETQUADANHGIAs.ToList());
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