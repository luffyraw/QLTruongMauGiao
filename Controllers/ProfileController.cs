using QuanLyTruongMauGiao.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyTruongMauGiao.Controllers
{
    public class ProfileController : Controller
    {
        // GET: Profile
        QLMauGiao db = new QLMauGiao();
        public ActionResult Index()
        {
            var user = Session["user"] as TAIKHOAN;
            if (user == null)
            {
                return RedirectToAction("Index", "home");
            }
            else if (user.PhanQuyen == "Quản lý")
                return RedirectToAction("ProfileAdmin", "Profile");
            else if (user.PhanQuyen == "Giáo viên")
                return RedirectToAction("ProfileGV", "Profile");
            else
                return RedirectToAction("ProfilePH", "Profile");
        }

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

    }
}