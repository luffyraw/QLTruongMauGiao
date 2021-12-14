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
    public class ThucDonController : Controller
    {
        private QLMauGiao db = new QLMauGiao();

        // GET: ThucDon
        public ActionResult Index()
        {
            return View(db.THUCDONTUANs.ToList());
        }

        // GET: ThucDon/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            THUCDONTUAN tHUCDONTUAN = db.THUCDONTUANs.Find(id);
            if (tHUCDONTUAN == null)
            {
                return HttpNotFound();
            }
            return View(tHUCDONTUAN);
        }

        // GET: ThucDon/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ThucDon/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaTDT,NgayBD,NgayKT")] THUCDONTUAN tHUCDONTUAN)
        {
            if (ModelState.IsValid)
            {
                db.THUCDONTUANs.Add(tHUCDONTUAN);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tHUCDONTUAN);
        }

        // GET: ThucDon/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            THUCDONTUAN tHUCDONTUAN = db.THUCDONTUANs.Find(id);
            if (tHUCDONTUAN == null)
            {
                return HttpNotFound();
            }
            return View(tHUCDONTUAN);
        }

        // POST: ThucDon/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaTDT,NgayBD,NgayKT")] THUCDONTUAN tHUCDONTUAN)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tHUCDONTUAN).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tHUCDONTUAN);
        }

        // GET: ThucDon/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            THUCDONTUAN tHUCDONTUAN = db.THUCDONTUANs.Find(id);
            if (tHUCDONTUAN == null)
            {
                return HttpNotFound();
            }
            return View(tHUCDONTUAN);
        }

        // POST: ThucDon/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            THUCDONTUAN tHUCDONTUAN = db.THUCDONTUANs.Find(id);
            db.THUCDONTUANs.Remove(tHUCDONTUAN);
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
