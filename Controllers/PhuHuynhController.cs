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
        public ActionResult Index(string searchstr, int? page)
        {
            var phuHuynh = db.PHUHUYNHs.Include(p => p.TAIKHOAN);
            if (!String.IsNullOrEmpty(searchstr))
            {
                phuHuynh = phuHuynh.Where(ph => ph.TenPH == searchstr);
            }
            phuHuynh = phuHuynh.OrderBy(ph => ph.TenPH);
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(phuHuynh.ToPagedList(pageNumber, pageSize));
        }

        // GET: PhuHuynh/Details/5
        public ActionResult Details(string id)
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

        // GET: PhuHuynh/Create
        public ActionResult Create()
        {
            var taiKhoanPH = from ph in db.PHUHUYNHs
                             select ph.TenTK;
            ViewBag.TenTK = new SelectList(taiKhoanPH);
            return View();
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
                db.PHUHUYNHs.Add(pHUHUYNH);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TenTK = new SelectList(db.TAIKHOANs, "TenTK", "MatKhau", pHUHUYNH.TenTK);
            return View(pHUHUYNH);
        }

        // GET: PhuHuynh/Edit/5
        public ActionResult Edit(string id)
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
            var taiKhoanPH = from ph in db.PHUHUYNHs
                             select ph.TenTK;
            ViewBag.TenTK = new SelectList(taiKhoanPH);
            return View(pHUHUYNH);
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
