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
    public class XemDanhGiaController : Controller
    {
        private QLMauGiao db = new QLMauGiao();

        // GET: XemDanhGia
        public ActionResult Index()
        {
            var kETQUADANHGIAs = db.KETQUADANHGIAs.Include(k => k.NOIDUNGDANHGIA).Include(k => k.PHIEUDANHGIA);
            return View(kETQUADANHGIAs.ToList());
        }

        // GET: XemDanhGia/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KETQUADANHGIA kETQUADANHGIA = db.KETQUADANHGIAs.Find(id);
            if (kETQUADANHGIA == null)
            {
                return HttpNotFound();
            }
            return View(kETQUADANHGIA);
        }

        // GET: XemDanhGia/Create
        public ActionResult Create()
        {
            ViewBag.MaNDDG = new SelectList(db.NOIDUNGDANHGIAs, "MaNDDG", "NoiDungDanhGia1");
            ViewBag.MaPhieu = new SelectList(db.PHIEUDANHGIAs, "MaPhieu", "MaTre");
            return View();
        }

        // POST: XemDanhGia/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaPhieu,MaNDDG,kq")] KETQUADANHGIA kETQUADANHGIA)
        {
            if (ModelState.IsValid)
            {
                db.KETQUADANHGIAs.Add(kETQUADANHGIA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaNDDG = new SelectList(db.NOIDUNGDANHGIAs, "MaNDDG", "NoiDungDanhGia1", kETQUADANHGIA.MaNDDG);
            ViewBag.MaPhieu = new SelectList(db.PHIEUDANHGIAs, "MaPhieu", "MaTre", kETQUADANHGIA.MaPhieu);
            return View(kETQUADANHGIA);
        }

        // GET: XemDanhGia/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KETQUADANHGIA kETQUADANHGIA = db.KETQUADANHGIAs.Find(id);
            if (kETQUADANHGIA == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaNDDG = new SelectList(db.NOIDUNGDANHGIAs, "MaNDDG", "NoiDungDanhGia1", kETQUADANHGIA.MaNDDG);
            ViewBag.MaPhieu = new SelectList(db.PHIEUDANHGIAs, "MaPhieu", "MaTre", kETQUADANHGIA.MaPhieu);
            return View(kETQUADANHGIA);
        }

        // POST: XemDanhGia/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaPhieu,MaNDDG,kq")] KETQUADANHGIA kETQUADANHGIA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kETQUADANHGIA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaNDDG = new SelectList(db.NOIDUNGDANHGIAs, "MaNDDG", "NoiDungDanhGia1", kETQUADANHGIA.MaNDDG);
            ViewBag.MaPhieu = new SelectList(db.PHIEUDANHGIAs, "MaPhieu", "MaTre", kETQUADANHGIA.MaPhieu);
            return View(kETQUADANHGIA);
        }

        // GET: XemDanhGia/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KETQUADANHGIA kETQUADANHGIA = db.KETQUADANHGIAs.Find(id);
            if (kETQUADANHGIA == null)
            {
                return HttpNotFound();
            }
            return View(kETQUADANHGIA);
        }

        // POST: XemDanhGia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            KETQUADANHGIA kETQUADANHGIA = db.KETQUADANHGIAs.Find(id);
            db.KETQUADANHGIAs.Remove(kETQUADANHGIA);
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
