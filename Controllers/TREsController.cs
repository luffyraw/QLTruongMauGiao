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
    public class TREsController : Controller
    {
        private QLMauGiao db = new QLMauGiao();

        // GET: TREs
        public ActionResult Index(int? page)
        {
            var tREs = db.TREs.Include(t => t.LOP).Include(t => t.PHUHUYNH);
            tREs = tREs.OrderBy(tr => tr.TenTre);

            int pageSize = 7;
            int pageNumber = (page ?? 1);
            return View(tREs.ToPagedList(pageNumber,pageSize));
        }

        public PartialViewResult GetName(string name)
        {
            var contacts = db.TREs.Where(x => x.TenTre.Contains(name));
            
            return PartialView("Index", contacts);
        }
        // GET: TREs/Details/5
        public ActionResult Details(string id)
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

        // GET: TREs/Create
        public ActionResult Create()
        {
            ViewBag.MaLop = new SelectList(db.LOPs, "MaLop", "TenLop");
            ViewBag.MaPH = new SelectList(db.PHUHUYNHs, "MaPH", "TenPH");
            return View();
        }

        // POST: TREs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaTre,MaLop,MaPH,TenTre,NgaySinh,GioiTinh,QueQuan,DanToc,NgayNhapHoc,Anh")] TRE tRE)
        {
            if (ModelState.IsValid)
            {
                db.TREs.Add(tRE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaLop = new SelectList(db.LOPs, "MaLop", "TenLop", tRE.MaLop);
            ViewBag.MaPH = new SelectList(db.PHUHUYNHs, "MaPH", "TenPH", tRE.MaPH);
            return View(tRE);
        }

        // GET: TREs/Edit/5
        public ActionResult Edit(string id)
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
            ViewBag.MaLop = new SelectList(db.LOPs, "MaLop", "TenLop", tRE.MaLop);
            ViewBag.MaPH = new SelectList(db.PHUHUYNHs, "MaPH", "TenPH", tRE.MaPH);
            return View(tRE);
        }

        // POST: TREs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaTre,MaLop,MaPH,TenTre,NgaySinh,GioiTinh,QueQuan,DanToc,NgayNhapHoc,Anh")] TRE tRE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tRE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaLop = new SelectList(db.LOPs, "MaLop", "TenLop", tRE.MaLop);
            ViewBag.MaPH = new SelectList(db.PHUHUYNHs, "MaPH", "TenPH", tRE.MaPH);
            return View(tRE);
        }

        // GET: TREs/Delete/5
        public ActionResult Delete(string id)
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

        // POST: TREs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            TRE tRE = db.TREs.Find(id);
            db.TREs.Remove(tRE);
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
