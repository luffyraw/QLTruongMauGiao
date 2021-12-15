using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QuanLyTruongMauGiao.Models;

namespace QuanLyTruongMauGiao.Controllers
{
    public class GiaoVienController : Controller
    {
        private QLMauGiao db = new QLMauGiao();

        // GET: GiaoVien
        public ActionResult Index()
        {
            var gIAOVIENs = db.GIAOVIENs.Include(g => g.TAIKHOAN);
            return View(gIAOVIENs.ToList());
        }

        // GET: GiaoVien/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GIAOVIEN gIAOVIEN = db.GIAOVIENs.Find(id);
            if (gIAOVIEN == null)
            {
                return HttpNotFound();
            }
            return View(gIAOVIEN);
        }

        // GET: GiaoVien/Create
        public ActionResult Create()
        {
            ViewBag.TenTK = new SelectList(db.TAIKHOANs, "TenTK", "MatKhau");
            return View();
        }

        // POST: GiaoVien/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaGV,TenGV,NgaySinh,GioiTinh,QueQuan,DienThoai,Email,LoaiHopDong,Luong,KinhNghiem,TrinhDo,ChuyenNganh,LoaiTotNghiep,TenTK")] GIAOVIEN gIAOVIEN)
        {
            if (ModelState.IsValid)
            {
                db.GIAOVIENs.Add(gIAOVIEN);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TenTK = new SelectList(db.TAIKHOANs, "TenTK", "MatKhau", gIAOVIEN.TenTK);
            return View(gIAOVIEN);
        }

        // GET: GiaoVien/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GIAOVIEN gIAOVIEN = db.GIAOVIENs.Find(id);
            if (gIAOVIEN == null)
            {
                return HttpNotFound();
            }
            ViewBag.TenTK = new SelectList(db.TAIKHOANs, "TenTK", "MatKhau", gIAOVIEN.TenTK);
            return View(gIAOVIEN);
        }

        // POST: GiaoVien/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaGV,TenGV,NgaySinh,GioiTinh,QueQuan,DienThoai,Email,LoaiHopDong,Luong,KinhNghiem,TrinhDo,ChuyenNganh,LoaiTotNghiep,TenTK")] GIAOVIEN gIAOVIEN)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gIAOVIEN).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TenTK = new SelectList(db.TAIKHOANs, "TenTK", "MatKhau", gIAOVIEN.TenTK);
            return View(gIAOVIEN);
        }

        // GET: GiaoVien/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GIAOVIEN gIAOVIEN = db.GIAOVIENs.Find(id);
            if (gIAOVIEN == null)
            {
                return HttpNotFound();
            }
            return View(gIAOVIEN);
        }

        // POST: GiaoVien/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            GIAOVIEN gIAOVIEN = db.GIAOVIENs.Find(id);
            db.GIAOVIENs.Remove(gIAOVIEN);
            db.SaveChanges();
            return RedirectToAction("Index");
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
