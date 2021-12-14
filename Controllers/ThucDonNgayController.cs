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
    public class ThucDonNgayController : Controller
    {
        private QLMauGiao db = new QLMauGiao();

        // GET: ThucDonNgay
        public ActionResult Index()
        {
            var tHUCDONNGAYs = db.THUCDONNGAYs.Include(t => t.THUCDONTUAN);
            return View(tHUCDONNGAYs.ToList());
        }

        // GET: ThucDonNgay/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            THUCDONNGAY tHUCDONNGAY = db.THUCDONNGAYs.Find(id);
            if (tHUCDONNGAY == null)
            {
                return HttpNotFound();
            }
            return View(tHUCDONNGAY);
        }

        // GET: ThucDonNgay/Create
        public ActionResult Create()
        {
            ViewBag.MaTDT = new SelectList(db.THUCDONTUANs, "MaTDT", "MaTDT");
            return View();
        }

        // POST: ThucDonNgay/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaTDN,MaTDT,Ngay,BuaSang,BuaTrua,BuaXe")] THUCDONNGAY tHUCDONNGAY)
        {
            if (ModelState.IsValid)
            {
                db.THUCDONNGAYs.Add(tHUCDONNGAY);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaTDT = new SelectList(db.THUCDONTUANs, "MaTDT", "MaTDT", tHUCDONNGAY.MaTDT);
            return View(tHUCDONNGAY);
        }

        // GET: ThucDonNgay/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            THUCDONNGAY tHUCDONNGAY = db.THUCDONNGAYs.Find(id);
            if (tHUCDONNGAY == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaTDT = new SelectList(db.THUCDONTUANs, "MaTDT", "MaTDT", tHUCDONNGAY.MaTDT);
            return View(tHUCDONNGAY);
        }

        // POST: ThucDonNgay/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaTDN,MaTDT,Ngay,BuaSang,BuaTrua,BuaXe")] THUCDONNGAY tHUCDONNGAY)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tHUCDONNGAY).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaTDT = new SelectList(db.THUCDONTUANs, "MaTDT", "MaTDT", tHUCDONNGAY.MaTDT);
            return View(tHUCDONNGAY);
        }

        // GET: ThucDonNgay/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            THUCDONNGAY tHUCDONNGAY = db.THUCDONNGAYs.Find(id);
            if (tHUCDONNGAY == null)
            {
                return HttpNotFound();
            }
            return View(tHUCDONNGAY);
        }

        // POST: ThucDonNgay/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            THUCDONNGAY tHUCDONNGAY = db.THUCDONNGAYs.Find(id);
            db.THUCDONNGAYs.Remove(tHUCDONNGAY);
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
