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
    public class ThucDonController : Controller
    {
        private QLMauGiao db = new QLMauGiao();

        // GET: ThucDon
        public ActionResult Index(DateTime? startdate, DateTime? enddate, int? page)
        {
            if (Session["user"] != null)
            {
                IQueryable<THUCDONNGAY> thucdons = db.THUCDONNGAYs;

                if (startdate != null && enddate != null)
                {
                    thucdons = thucdons.Where(td => td.Ngay >= startdate && td.Ngay <= enddate);
                }
                thucdons = thucdons.OrderBy(td => td.Ngay);
                int pageSize = 10;
                int pageNumber = (page ?? 1);
                return View(thucdons.ToPagedList(pageNumber, pageSize)); 
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

        }

        // GET: ThucDon/Details/5
        public ActionResult Details(string id)
        {
            if (Session["user"] != null)
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
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // GET: ThucDon/Create
        public ActionResult Create()
        {
            if (Session["user"] != null)
            {
                return View(); 
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // POST: ThucDon/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaTDN,Ngay,BuaSang,BuaTrua,BuaXe")] THUCDONNGAY tHUCDONNGAY)
        {
            if (ModelState.IsValid)
            {
                db.THUCDONNGAYs.Add(tHUCDONNGAY);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tHUCDONNGAY);
        }

        // GET: ThucDon/Edit/5
        public ActionResult Edit(string id)
        {
            if (Session["user"] != null)
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
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // POST: ThucDon/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaTDN,Ngay,BuaSang,BuaTrua,BuaXe")] THUCDONNGAY tHUCDONNGAY)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tHUCDONNGAY).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tHUCDONNGAY);
        }

        // GET: ThucDon/Delete/5
        public ActionResult Delete(string id)
        {
            if (Session["user"] != null)
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
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // POST: ThucDon/Delete/5
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
