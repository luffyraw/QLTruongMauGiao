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
    public class ChiPhiController : Controller
    {
        private QLMauGiao db = new QLMauGiao();

        // GET: ChiPhi
        public ActionResult Index()
        {
            return View(db.CHIPHIs.ToList());
        }

        // GET: ChiPhi/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CHIPHI cHIPHI = db.CHIPHIs.Find(id);
            if (cHIPHI == null)
            {
                return HttpNotFound();
            }
            return View(cHIPHI);
        }

        // GET: ChiPhi/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ChiPhi/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaChiPhi,NoiDung,DonGia")] CHIPHI cHIPHI)
        {
            if (ModelState.IsValid)
            {
                db.CHIPHIs.Add(cHIPHI);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cHIPHI);
        }

        // GET: ChiPhi/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CHIPHI cHIPHI = db.CHIPHIs.Find(id);
            if (cHIPHI == null)
            {
                return HttpNotFound();
            }
            return View(cHIPHI);
        }

        // POST: ChiPhi/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaChiPhi,NoiDung,DonGia")] CHIPHI cHIPHI)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cHIPHI).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cHIPHI);
        }

        // GET: ChiPhi/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CHIPHI cHIPHI = db.CHIPHIs.Find(id);
            if (cHIPHI == null)
            {
                return HttpNotFound();
            }
            return View(cHIPHI);
        }

        // POST: ChiPhi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            CHIPHI cHIPHI = db.CHIPHIs.Find(id);
            db.CHIPHIs.Remove(cHIPHI);
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
