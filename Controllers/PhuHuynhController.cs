using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QuanLyTruongMauGiao.Models;
using PagedList;

namespace QuanLyTruongMauGiao.Controllers
{
    public class PhuHuynhController : Controller
    {
        private QLMauGiao db = new QLMauGiao();

        // GET: PhuHuynh
        public ActionResult Index(int? page)
        {
            TAIKHOAN user = (TAIKHOAN)Session["user"];
            if (Session["user"] != null && user.PhanQuyen == "Quản lý")
            {
                var phuHuynh = db.PHUHUYNHs.Include(p => p.TAIKHOAN);
                phuHuynh = phuHuynh.OrderBy(ph => ph.TenPH);
                int pageSize = 10;
                int pageNumber = (page ?? 1);
                return View(phuHuynh.ToPagedList(pageNumber, pageSize)); 
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        public PartialViewResult GetNamePH(string searchstr, int? page)
        {
            var phuHuynhs = db.PHUHUYNHs.Where(x => x.TenPH.Contains(searchstr));
            phuHuynhs = phuHuynhs.OrderBy(ph => ph.TenPH);

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return PartialView("Index", phuHuynhs.ToPagedList(pageNumber, pageSize));
        }

        // GET: PhuHuynh/Details/5
        public ActionResult Details(string id)
        {
            TAIKHOAN user = (TAIKHOAN)Session["user"];
            if (Session["user"] != null && user.PhanQuyen == "Quản lý")
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                PHUHUYNH pHUHUYNH = db.PHUHUYNHs.Find(id);
                if (pHUHUYNH == null)
                {
                    return HttpNotFound();
                }
                return View(pHUHUYNH); 
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        public string SinhMaPH()
        {
            var ph = from item in db.PHUHUYNHs
                      select item;
            int soPH = ph.Count() + 1;
            string maPH = "";
            if (soPH < 10)
            {
                maPH = String.Format("{0}00{1}", "ph", soPH);
            }
            else if (soPH < 100)
            {
                maPH = String.Format("{0}0{1}", "ph", soPH);
            }
            else if (soPH < 1000)
            {
                maPH = String.Format("{0}{1}", "ph", soPH);
            }
            else
            {
                maPH = soPH.ToString();
            }
            return maPH;
        }
        // GET: PhuHuynh/Create
        public ActionResult Create()
        {
            TAIKHOAN user = (TAIKHOAN)Session["user"];
            if (Session["user"] != null && user.PhanQuyen == "Quản lý")
            {
                var taiKhoanPH = (from ph in db.PHUHUYNHs
                                 select ph.TenTK).Distinct();
                ViewBag.TenTK = new SelectList(taiKhoanPH);
                ViewBag.MaPH = SinhMaPH();
                return View();               
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // POST: PhuHuynh/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaPH,TenPH,NamSinh,GioiTinh,DiaChi,DienThoai,TenTK")] PHUHUYNH pHUHUYNH)
        {
            
            if (ModelState.IsValid)
            {
                try
                {
                    var taiKhoan = db.TAIKHOANs.Find(pHUHUYNH.TenTK);
                    TAIKHOAN taiKhoanNew = new TAIKHOAN();
                    if (taiKhoan != null)
                    {
                        taiKhoan.MatKhau = "123456";
                        taiKhoan.PhanQuyen = "Phụ huynh";
                        taiKhoan.TrangThaiHD = false;
                    }
                    else
                    {
                        
                        taiKhoanNew.TenTK = pHUHUYNH.TenTK;
                        taiKhoanNew.MatKhau = "123456";
                        taiKhoanNew.PhanQuyen = "Phụ huynh";
                        taiKhoanNew.TrangThaiHD = false;
                        taiKhoanNew.AnhDaiDien = "default.png";
                        db.TAIKHOANs.Add(taiKhoanNew);
                    }
                    db.PHUHUYNHs.Add(pHUHUYNH);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ViewBag.msg = ex.Message;
                    
                }
            }
            var taiKhoanPH = (from ph in db.PHUHUYNHs
                              select ph.TenTK).Distinct();
            ViewBag.TenTK = new SelectList(taiKhoanPH);
            ViewBag.MaPH = SinhMaPH();
            return View(pHUHUYNH);
        }

        // GET: PhuHuynh/Edit/5
        public ActionResult Edit(string id)
        {
            TAIKHOAN user = (TAIKHOAN)Session["user"];
            if (Session["user"] != null && user.PhanQuyen == "Quản lý")
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                PHUHUYNH pHUHUYNH = db.PHUHUYNHs.Find(id);
                if (pHUHUYNH == null)
                {
                    return HttpNotFound();
                }
                var taiKhoanPH = (from ph in db.PHUHUYNHs
                                  select ph.TenTK).Distinct();
                ViewBag.TenTK = new SelectList(taiKhoanPH);
                return View(pHUHUYNH); 
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // POST: PhuHuynh/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaPH,TenPH,NamSinh,GioiTinh,DiaChi,DienThoai,TenTK")] PHUHUYNH pHUHUYNH)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pHUHUYNH).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TenTK = new SelectList(db.TAIKHOANs, "TenTK", "MatKhau", pHUHUYNH.TenTK);
            return View(pHUHUYNH);
        }

        // GET: PhuHuynh/Delete/5
        public ActionResult Delete(string id)
        {
            TAIKHOAN user = (TAIKHOAN)Session["user"];
            if (Session["user"] != null && user.PhanQuyen == "Quản lý")
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                PHUHUYNH pHUHUYNH = db.PHUHUYNHs.Find(id);
                if (pHUHUYNH == null)
                {
                    return HttpNotFound();
                }
                return View(pHUHUYNH); 
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // POST: PhuHuynh/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            PHUHUYNH pHUHUYNH = db.PHUHUYNHs.Find(id);
            try
            {
                db.PHUHUYNHs.Remove(pHUHUYNH);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Có lỗi khi xóa: " + ex.Message;
                return View("Delete", pHUHUYNH);
            }
            
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
