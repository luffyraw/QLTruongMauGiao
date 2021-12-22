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
    public class ThuTienController : Controller
    {
        private QLMauGiao db = new QLMauGiao();

        // GET: ThuTien
        public ActionResult Index()
        {
            var pHIEUTHUTIENs = db.PHIEUTHUTIENs.Include(p => p.TRE);
            return View(pHIEUTHUTIENs.ToList());
        }

        // GET: ThuTien/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PHIEUTHUTIEN pHIEUTHUTIEN = db.PHIEUTHUTIENs.Find(id);
            if (pHIEUTHUTIEN == null)
            {
                return HttpNotFound();
            }
            return View(pHIEUTHUTIEN);
        }

        // GET: ThuTien/Create
        public ActionResult Create()
        {
            ViewBag.MaTre = new SelectList(db.TREs, "MaTre", "MaLop");
            return View();
        }

        // POST: ThuTien/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaPhieu,MaTre,NgayLapPhieu,TrangThai")] PHIEUTHUTIEN pHIEUTHUTIEN)
        {
            if (ModelState.IsValid)
            {
                db.PHIEUTHUTIENs.Add(pHIEUTHUTIEN);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaTre = new SelectList(db.TREs, "MaTre", "MaLop", pHIEUTHUTIEN.MaTre);
            return View(pHIEUTHUTIEN);
        }

        // GET: ThuTien/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PHIEUTHUTIEN pHIEUTHUTIEN = db.PHIEUTHUTIENs.Find(id);
            if (pHIEUTHUTIEN == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaTre = new SelectList(db.TREs, "MaTre", "MaLop", pHIEUTHUTIEN.MaTre);
            return View(pHIEUTHUTIEN);
        }

        // POST: ThuTien/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaPhieu,MaTre,NgayLapPhieu,TrangThai")] PHIEUTHUTIEN pHIEUTHUTIEN)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pHIEUTHUTIEN).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaTre = new SelectList(db.TREs, "MaTre", "MaLop", pHIEUTHUTIEN.MaTre);
            return View(pHIEUTHUTIEN);
        }

        // GET: ThuTien/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PHIEUTHUTIEN pHIEUTHUTIEN = db.PHIEUTHUTIENs.Find(id);
            if (pHIEUTHUTIEN == null)
            {
                return HttpNotFound();
            }
            return View(pHIEUTHUTIEN);
        }

        // POST: ThuTien/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            PHIEUTHUTIEN pHIEUTHUTIEN = db.PHIEUTHUTIENs.Find(id);
            db.PHIEUTHUTIENs.Remove(pHIEUTHUTIEN);
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
