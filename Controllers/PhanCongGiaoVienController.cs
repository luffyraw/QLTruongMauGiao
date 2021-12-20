using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QuanLyTruongMauGiao.Models;
using QuanLyTruongMauGiao.Models.NoDatabase;

namespace QuanLyTruongMauGiao.Controllers
{
    public class PhanCongGiaoVienController : Controller
    {
        private QLMauGiao db = new QLMauGiao();

        // GET: PhanCongGiaoVien
        public ActionResult Index()
        {
            var phanCong = db.PHANCONGGIAOVIENs.Include(p => p.GIAOVIEN).Include(p => p.LOP);

            var result = from p in phanCong
                         group p by new { p.MaLop, p.NamHoc } into g
                                      select new PCGiaoVien()
                                      {
                                          MaLop = g.Key.MaLop,
                                          NamHoc = g.Key.NamHoc,
                                          MaGV = g.Select(gv => gv.MaGV).ToList()
                                      };
            ViewBag.pHANCONGGIAOVIENs = phanCong.ToList();
            return View(result.ToList());
        }

        // GET: PhanCongGiaoVien/Details/5
        public ActionResult Details(string id1, string id2)
        {
            if (id1 == null || id2 == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            //PHANCONGGIAOVIEN pHANCONGGIAOVIEN = db.PHANCONGGIAOVIENs.Find(id);
            //if (pHANCONGGIAOVIEN == null)
            //{
            //    return HttpNotFound();
            //}
            var phanCong = db.PHANCONGGIAOVIENs.Include(p => p.GIAOVIEN).Include(p => p.LOP);

            var result = from p in phanCong
                         group p by new { p.MaLop, p.NamHoc } into g
                         select new PCGiaoVien()
                         {
                             MaLop = g.Key.MaLop,
                             NamHoc = g.Key.NamHoc,
                             MaGV = g.Select(gv => gv.MaGV).ToList()
                         };
            PCGiaoVien giaovien = null;
            foreach(var item in result)
            {
                if(item.MaLop.Equals(id1) && item.NamHoc.Equals(id2))
                {
                    giaovien = item;
                }
            }
            if(giaovien == null)
            {
                return HttpNotFound();
            }
            return View(giaovien);
        }

        // GET: PhanCongGiaoVien/Create
        public ActionResult Create()
        {
            ViewBag.MaGV = new SelectList(db.GIAOVIENs, "MaGV", "TenGV");
            ViewBag.MaLop = new SelectList(db.LOPs, "MaLop", "TenLop");
            return View();
        }

        // POST: PhanCongGiaoVien/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaGV,MaLop,NamHoc")] PHANCONGGIAOVIEN pHANCONGGIAOVIEN)
        {
            if (ModelState.IsValid)
            {
                db.PHANCONGGIAOVIENs.Add(pHANCONGGIAOVIEN);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaGV = new SelectList(db.GIAOVIENs, "MaGV", "TenGV", pHANCONGGIAOVIEN.MaGV);
            ViewBag.MaLop = new SelectList(db.LOPs, "MaLop", "TenLop", pHANCONGGIAOVIEN.MaLop);
            return View(pHANCONGGIAOVIEN);
        }

        // GET: PhanCongGiaoVien/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PHANCONGGIAOVIEN pHANCONGGIAOVIEN = db.PHANCONGGIAOVIENs.Find(id);
            if (pHANCONGGIAOVIEN == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaGV = new SelectList(db.GIAOVIENs, "MaGV", "TenGV", pHANCONGGIAOVIEN.MaGV);
            ViewBag.MaLop = new SelectList(db.LOPs, "MaLop", "TenLop", pHANCONGGIAOVIEN.MaLop);
            return View(pHANCONGGIAOVIEN);
        }

        // POST: PhanCongGiaoVien/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaGV,MaLop,NamHoc")] PHANCONGGIAOVIEN pHANCONGGIAOVIEN)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pHANCONGGIAOVIEN).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaGV = new SelectList(db.GIAOVIENs, "MaGV", "TenGV", pHANCONGGIAOVIEN.MaGV);
            ViewBag.MaLop = new SelectList(db.LOPs, "MaLop", "TenLop", pHANCONGGIAOVIEN.MaLop);
            return View(pHANCONGGIAOVIEN);
        }

        // GET: PhanCongGiaoVien/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PHANCONGGIAOVIEN pHANCONGGIAOVIEN = db.PHANCONGGIAOVIENs.Find(id);
            if (pHANCONGGIAOVIEN == null)
            {
                return HttpNotFound();
            }
            return View(pHANCONGGIAOVIEN);
        }

        // POST: PhanCongGiaoVien/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            PHANCONGGIAOVIEN pHANCONGGIAOVIEN = db.PHANCONGGIAOVIENs.Find(id);
            db.PHANCONGGIAOVIENs.Remove(pHANCONGGIAOVIEN);
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
