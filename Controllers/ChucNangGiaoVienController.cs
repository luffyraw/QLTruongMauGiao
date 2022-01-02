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

        public ActionResult DiemDanh(string id)
        {
            if (Session["user"] != null)
            {
                var account = Session["user"] as TAIKHOAN;
                var user = (from item in db.GIAOVIENs where item.TenTK == account.TenTK select item).FirstOrDefault();
                var MaLop = (from item in db.PHANCONGGIAOVIENs where item.MaGV == user.MaGV select item.MaLop).FirstOrDefault();
                var tre = from item in db.TREs where item.MaLop == MaLop select item;
                return View(tre.ToList());
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

        }

        public class ParamDiemDanh
        {
            public string MaTre { get; set; }
            public bool select { get; set; }
        }

        [HttpPost]
        public ActionResult DiemDanh(ParamDiemDanh[] data)
        {
            TAIKHOAN account = (TAIKHOAN)Session["user"];

            try
            {
                if (data != null)
                {
                    foreach (var item in data)
                    {
                        var query = (from x in db.DIEMDANHs
                                     where x.MaTre == item.MaTre && x.Ngay == DateTime.Now
                                     select x).FirstOrDefault();
                        if (query == null)
                        {
                            DIEMDANH diemDanh = new DIEMDANH();
                            diemDanh.MaTre = item.MaTre;
                            diemDanh.Ngay = DateTime.Now;
                            diemDanh.DiemDanh1 = item.select;
                            diemDanh.DangKiBuaAn = false;
                            db.DIEMDANHs.Add(diemDanh);
                        }
                        else
                        {
                            query.DiemDanh1 = item.select;
                        }
                        db.SaveChanges();

                    }
                    return Json("Điểm danh thành công", JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
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
        public ActionResult DanhGiaTre(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KETQUADANHGIA tRE = db.KETQUADANHGIAs.Find(id);
            if (tRE == null)
            {
                return HttpNotFound();
            }
            return View(tRE);
        }
    }
}