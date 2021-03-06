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
    public class TreController : Controller
    {
        private QLMauGiao db = new QLMauGiao();
        public int CheckLogin()
        {
            var user = Session["user"] as TAIKHOAN; 
            if (user != null && user.PhanQuyen == "Quản lý")
                return 0;
            if (user != null && user.PhanQuyen == "Phụ huynh")
                return 1;
            if (user != null && user.PhanQuyen == "Giáo viên")
                return 2;
            return -1;
        }
        
        // GET: Tre
        public ActionResult Index(int? page)
        {
            if(CheckLogin() == -1)
                return RedirectToAction("index", "Home");
            if (CheckLogin() == 1)
                return RedirectToAction("HomePagePH", "Home");
            if (CheckLogin() == 2)
                return RedirectToAction("HomePageGV", "Home");
            else
            {
                var tREs = db.TREs.Include(t => t.LOP).Include(t => t.PHUHUYNH);

                tREs = tREs.OrderBy(tr => tr.TenTre);
                int pageSize = 7;
                int pageNumber = (page ?? 1);
                return View(tREs.ToPagedList(pageNumber, pageSize));
            }
        }

        public PartialViewResult GetName(string name, int? page)
        {
            var contacts = db.TREs.Where(x => x.TenTre.Contains(name));
            contacts = contacts.OrderBy(tr => tr.TenTre);

            int pageSize = 7;
            int pageNumber = (page ?? 1);
            return PartialView("Index", contacts.ToPagedList(pageNumber, pageSize));
        }
        // GET: Tre/Details/5
        public ActionResult Details(string id)
        {
            if (CheckLogin() == -1)
                return RedirectToAction("index", "Home");
            if (CheckLogin() == 1)
                return RedirectToAction("HomePagePH", "Home");
            if (CheckLogin() == 2)
                return RedirectToAction("HomePageGV", "Home");
            else
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
        }

        // GET: Tre/Create
        public ActionResult Create()
        {
            if (CheckLogin() == -1)
                return RedirectToAction("index", "Home");
            if (CheckLogin() == 1)
                return RedirectToAction("HomePagePH", "Home");
            if (CheckLogin() == 2)
                return RedirectToAction("HomePageGV", "Home");
            else
            {
                ViewBag.MaLop = new SelectList(db.LOPs, "MaLop", "TenLop");
                ViewBag.MaPH = new SelectList(db.PHUHUYNHs, "MaPH", "TenPH");
                return View();
            }
        }

        // POST: Tre/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
       public ActionResult Create([Bind(Include = "MaTre,MaLop,MaPH,TenTre,NgaySinh,GioiTinh,QueQuan,DanToc,NgayNhapHoc,Anh")] TRE tRE)
        {
            if (ModelState.IsValid)
            {
                var lop = (from item in db.LOPs where item.MaLop == tRE.MaLop select item).FirstOrDefault();
                lop.SiSo++;
                var f = Request.Files["inputimg"];
                if (f!=null)
                {
                    string uploadPath = Server.MapPath("~/Image/Tre/") + tRE.MaTre.ToString() + ".png";
                    tRE.Anh = tRE.MaTre + ".png";
                    if (System.IO.File.Exists(uploadPath))
                        System.IO.File.Delete(uploadPath);
                    f.SaveAs(uploadPath);
                }



                db.TREs.Add(tRE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaLop = new SelectList(db.LOPs, "MaLop", "TenLop", tRE.MaLop);
            ViewBag.MaPH = new SelectList(db.PHUHUYNHs, "MaPH", "TenPH", tRE.MaPH);
            return View(tRE);
        }

        // GET: Tre/Edit/5
        public ActionResult Edit(string id)
        {
            if (CheckLogin() == -1)
                return RedirectToAction("index", "Home");
            if (CheckLogin() == 1)
                return RedirectToAction("HomePagePH", "Home");
            if (CheckLogin() == 2)
                return RedirectToAction("HomePageGV", "Home");
            else
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
        }

        // POST: Tre/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaTre,MaLop,MaPH,TenTre,NgaySinh,GioiTinh,QueQuan,DanToc,NgayNhapHoc,Anh")] TRE tRE)
        {
            if (ModelState.IsValid)
            {

                var f = Request.Files["inputimg"];
                string filename;
                
                if (f != null)
                {
                    filename = System.IO.Path.GetFileName(f.FileName);
                    string uploadPath = Server.MapPath("~/Image/Tre/") + tRE.MaTre.ToString() + ".png";
                    if (System.IO.File.Exists(uploadPath))
                        System.IO.File.Delete(uploadPath);
                    tRE.Anh = tRE.MaTre + ".png";
                    f.SaveAs(uploadPath);
                }

                db.Entry(tRE).State = EntityState.Modified;

                db.SaveChanges();

                return RedirectToAction("Index");
            }
            ViewBag.MaLop = new SelectList(db.LOPs, "MaLop", "TenLop", tRE.MaLop);
            ViewBag.MaPH = new SelectList(db.PHUHUYNHs, "MaPH", "TenPH", tRE.MaPH);
            return View(tRE);
        }

        // GET: Tre/Delete/5
        public ActionResult Delete(string id)
        {
            if (CheckLogin() == -1)
                return RedirectToAction("index", "Home");
            if (CheckLogin() == 1)
                return RedirectToAction("HomePagePH", "Home");
            if (CheckLogin() == 2)
                return RedirectToAction("HomePageGV", "Home");
            else
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
        }

        // POST: Tre/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            TRE tRE = db.TREs.Find(id);
            var lop = (from item in db.LOPs where item.MaLop == tRE.MaLop select item).FirstOrDefault();
            db.TREs.Remove(tRE);
            lop.SiSo = lop.SiSo - 1;
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
