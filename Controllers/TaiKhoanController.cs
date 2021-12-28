using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PagedList;
using QuanLyTruongMauGiao.Models;

namespace QuanLyTruongMauGiao.Controllers
{
    public class TaiKhoanController : Controller
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
        // GET: TaiKhoan
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
                var taikhoan = from item in db.TAIKHOANs select item;
                //var taikhoan = from item in db.TAIKHOANs select item;

                taikhoan = taikhoan.OrderBy(tr => tr.TenTK);
                int pageSize = 10;
                int pageNumber = (page ?? 1);

                return View(taikhoan.ToPagedList(pageNumber,pageSize));
            }
           

        }
        public PartialViewResult GetQuyen(string quyen, int? page)
        {
            //var taikhoan = db.TAIKHOANs.Where(x => x.PhanQuyen.Contains(quyen));
            var taikhoan = from item in db.TAIKHOANs 
                           where item.PhanQuyen.Contains(quyen) 
                           orderby item.TenTK
                           select item;

            int pageSize = 7;
            int pageNumber = (page ?? 1);
            return PartialView("Index", taikhoan.ToPagedList(pageNumber, pageSize));
        }
        // GET: TaiKhoan/Details/5
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
                TAIKHOAN tAIKHOAN = db.TAIKHOANs.Find(id);
                if (tAIKHOAN == null)
                {
                    return HttpNotFound();
                }
                return View(tAIKHOAN);
            }
            
        }

        // GET: TaiKhoan/Create
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
            return View();

            }
        }

        // POST: TaiKhoan/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TenTK,MatKhau,PhanQuyen,TrangThaiHD,AnhDaiDien")] TAIKHOAN tAIKHOAN)
        {
            if (ModelState.IsValid)
            {
                db.TAIKHOANs.Add(tAIKHOAN);
                try
                {
                    db.SaveChanges();
                    ViewBag.Message = "Thêm tài khoản " + tAIKHOAN.TenTK + " thành công";
                    return View("Create");
                }
                catch
                {
                    ViewBag.Message = "Tên tài khoản " + tAIKHOAN.TenTK + "đã tồn tại";
                    return View("Create");
                }
               
            }

            return View(tAIKHOAN);
        }

        // GET: TaiKhoan/Edit/5
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
                TAIKHOAN tAIKHOAN = db.TAIKHOANs.Find(id);
                if (tAIKHOAN == null)
                {
                    return HttpNotFound();
                }
                return View(tAIKHOAN);
            }
           
        }

        // POST: TaiKhoan/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TenTK,MatKhau,PhanQuyen,TrangThaiHD,AnhDaiDien")] TAIKHOAN tAIKHOAN)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tAIKHOAN).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tAIKHOAN);
        }

        // GET: TaiKhoan/Delete/5
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
                TAIKHOAN tAIKHOAN = db.TAIKHOANs.Find(id);
                if (tAIKHOAN == null)
                {
                    return HttpNotFound();
                }
                return View(tAIKHOAN);
            }
          
        }

        // POST: TaiKhoan/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            TAIKHOAN tAIKHOAN = db.TAIKHOANs.Find(id);
            db.TAIKHOANs.Remove(tAIKHOAN);
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
