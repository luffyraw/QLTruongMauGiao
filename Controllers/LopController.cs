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
    public class LopController : Controller
    {
        private QLMauGiao db = new QLMauGiao();
        public Boolean CheckLogin()
        {
            var user = Session["user"] as TAIKHOAN;
            if (user != null && user.PhanQuyen == "Quản lý")
                return true;
            else return false;

        }
        // GET: Lop
        public ActionResult Index(int? page)
        {
            if (CheckLogin())
            {
                var dslop = from item in db.LOPs select item;
                dslop = dslop.OrderBy(lop => lop.MaLop);
                int pagenumber = (page ?? 1);
                int pagesize = 10;
                return View(dslop.ToPagedList(pagenumber,pagesize));
            }
            else return RedirectToAction("index", "Home");
 
        }

        // GET: Lop/Details/5
        public ActionResult Details(string id)
        {
            if (CheckLogin())
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                LOP lOP = db.LOPs.Find(id);
                if (lOP == null)
                {
                    return HttpNotFound();
                }
                return View(lOP);
            }
            else return RedirectToAction("index", "Home");
 
        }

        // GET: Lop/Create
        public ActionResult Create()
        {
            if (CheckLogin())
            {
                return View();
            }
            return RedirectToAction("Index", "Home");
        }

        // POST: Lop/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaLop,TenLop,SiSo,DoTuoi,Khoi")] LOP lOP)
        {
            if (ModelState.IsValid)
            {
                db.LOPs.Add(lOP);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(lOP);
        }

        // GET: Lop/Edit/5
        public ActionResult Edit(string id)
        {
            if(CheckLogin())
            {  
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                LOP lOP = db.LOPs.Find(id);
                if (lOP == null)
                {
                    return HttpNotFound();
                }
                return View(lOP);
            }
            return RedirectToAction("Index", "Home");
          
        }

        // POST: Lop/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaLop,TenLop,SiSo,DoTuoi,Khoi")] LOP lOP)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lOP).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lOP);
        }

        // GET: Lop/Delete/5
        public ActionResult Delete(string id)
        {
            if (CheckLogin())
            { 
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                LOP lOP = db.LOPs.Find(id);
                if (lOP == null)
                {
                    return HttpNotFound();
                }
                return View(lOP);
            }
            return RedirectToAction("Index", "Home");
           
        }

        // POST: Lop/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            LOP lOP = db.LOPs.Find(id);
            db.LOPs.Remove(lOP);
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
