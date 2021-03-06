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
    public class GiaoVienController : Controller
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
        // GET: GiaoVien
        public ActionResult Index(int? page)
        {
            if (CheckLogin() == -1)
                return RedirectToAction("index", "Home");
            if (CheckLogin() == 1)
                return RedirectToAction("HomePagePH", "Home");
            if (CheckLogin() == 2)
                return RedirectToAction("HomePageGV", "Home");
            else
            {
                var gIAOVIENs = db.GIAOVIENs.Include(g => g.TAIKHOAN);
                gIAOVIENs = gIAOVIENs.OrderBy(gv => gv.TenGV);
                int pageNumber = (page ?? 1);
                int pageSize = 10;
                return View(gIAOVIENs.ToPagedList(pageNumber,pageSize));
            }
           
        }

        // GET: GiaoVien/Details/5
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
                GIAOVIEN gIAOVIEN = db.GIAOVIENs.Find(id);
                if (gIAOVIEN == null)
                {
                    return HttpNotFound();
                }
                return View(gIAOVIEN);
            }
           
        }

        // GET: GiaoVien/Create
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
                 ViewBag.TenTK = new SelectList(db.TAIKHOANs, "TenTK", "MatKhau");
                 return View();
            }
           
        }

        // POST: GiaoVien/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaGV,TenGV,NgaySinh,GioiTinh,QueQuan,DienThoai,Email,LoaiHopDong,Luong,KinhNghiem,TrinhDo,ChuyenNganh,LoaiTotNghiep,TenTK")] GIAOVIEN gIAOVIEN)
        {
            if (ModelState.IsValid)
            {
                TAIKHOAN tk = new TAIKHOAN();
                tk.TenTK = gIAOVIEN.TenTK;
                tk.MatKhau = "123456";
                tk.PhanQuyen = "Giáo viên";
                tk.TrangThaiHD = false;
                tk.AnhDaiDien = "Default.png";
                db.TAIKHOANs.Add(tk);
                db.GIAOVIENs.Add(gIAOVIEN); 
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TenTK = new SelectList(db.TAIKHOANs, "TenTK", "MatKhau", gIAOVIEN.TenTK);
            return View(gIAOVIEN);
        }

        // GET: GiaoVien/Edit/5
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
                GIAOVIEN gIAOVIEN = db.GIAOVIENs.Find(id);
                if (gIAOVIEN == null)
                {
                    return HttpNotFound();
                }
                ViewBag.TenTK = new SelectList(db.TAIKHOANs, "TenTK", "MatKhau", gIAOVIEN.TenTK);
                return View(gIAOVIEN);
            }
        }

        // POST: GiaoVien/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaGV,TenGV,NgaySinh,GioiTinh,QueQuan,DienThoai,Email,LoaiHopDong,Luong,KinhNghiem,TrinhDo,ChuyenNganh,LoaiTotNghiep,TenTK")] GIAOVIEN gIAOVIEN)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gIAOVIEN).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TenTK = new SelectList(db.TAIKHOANs, "TenTK", "MatKhau", gIAOVIEN.TenTK);
            return View(gIAOVIEN);
        }

        // GET: GiaoVien/Delete/5
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
                GIAOVIEN gIAOVIEN = db.GIAOVIENs.Find(id);
                if (gIAOVIEN == null)
                {
                    return HttpNotFound();
                }
                return View(gIAOVIEN);
            }

        }

        // POST: GiaoVien/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            GIAOVIEN gIAOVIEN = db.GIAOVIENs.Find(id);
            var pcGV = (from item in db.PHANCONGGIAOVIENs where item.MaGV == id select item).FirstOrDefault();
            if (pcGV != null)
                db.PHANCONGGIAOVIENs.Remove(pcGV);
            var pdg = from item in db.PHIEUDANHGIAs where item.MaGV == id select item;
            if (pdg != null)
            {
                foreach (var item in pdg)
                {
                    db.PHIEUDANHGIAs.Remove(item);
                }
            }
           
            db.GIAOVIENs.Remove(gIAOVIEN);
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
