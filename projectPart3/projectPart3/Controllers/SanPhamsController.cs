﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using projectPart3.Models;

namespace projectPart3.Controllers
{
    public class SanPhamsController : Controller
    {
        private LTQLDBContext db = new LTQLDBContext();

        // GET: SanPhams
        public ActionResult Index()
        {
            var sanphams = db.sanphams.Include(s => s.danhmucs).Include(s => s.gias).Include(s => s.nhacungcaps).ToList();
            
            return View(sanphams);
        }

        // GET: SanPhams/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sanPham = db.sanphams.Find(id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }
            return View(sanPham);
        }

        // GET: SanPhams/Create
        public ActionResult Create()
        {
            ViewBag.ma_danh_muc = new SelectList(db.danhmucs, "ma_danh_muc", "ten_danh_muc");
            ViewBag.ma_gia = new SelectList(db.gias, "ma_gia", "ma_gia");
            ViewBag.ma_ncc = new SelectList(db.nhacungcaps, "ma_nha_cung_cap", "ten_nha_cung_cap");
            ViewBag.SP = db.sanphams.Include(s => s.danhmucs).Include(s => s.gias).Include(s => s.nhacungcaps).ToList();
            return View();
        }

        // POST: SanPhams/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ma_sp,ten_sp,ma_gia,ma_ncc,ma_danh_muc,trang_thai,ghi_chu,xuat_xu,mo_ta,hinh_anh")] SanPham sanPham, HttpPostedFileBase hinh_anh)
        {

            if (ModelState.IsValid)
            {
                var path = Path.Combine(Server.MapPath("~/Images/"), Path.GetFileName(hinh_anh.FileName));
                hinh_anh.SaveAs(path);
                db.sanphams.Add(new SanPham
                {
                    ma_sp = sanPham.ma_sp,
                    ten_sp = sanPham.ten_sp,
                    ma_gia = sanPham.ma_gia,
                    ma_ncc = sanPham.ma_ncc,
                    ma_danh_muc = sanPham.ma_danh_muc,
                    trang_thai = sanPham.trang_thai,
                    ghi_chu = sanPham.ghi_chu,
                    xuat_xu = sanPham.xuat_xu,
                    mo_ta = sanPham.mo_ta,
                    hinh_anh = "/Images/" + hinh_anh.FileName
                });
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            ViewBag.ma_danh_muc = new SelectList(db.danhmucs, "ma_danh_muc", "ten_danh_muc", sanPham.ma_danh_muc);
            ViewBag.ma_gia = new SelectList(db.gias, "ma_gia", "ma_gia", sanPham.ma_gia);
            ViewBag.ma_ncc = new SelectList(db.nhacungcaps, "ma_nha_cung_cap", "ten_nha_cung_cap", sanPham.ma_ncc);
            return View(sanPham);
        }

        // GET: SanPhams/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sanPham = db.sanphams.Find(id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }
            ViewBag.ma_danh_muc = new SelectList(db.danhmucs, "ma_danh_muc", "ten_danh_muc", sanPham.ma_danh_muc);
            ViewBag.ma_gia = new SelectList(db.gias, "ma_gia", "ma_gia", sanPham.ma_gia);
            ViewBag.ma_ncc = new SelectList(db.nhacungcaps, "ma_nha_cung_cap", "ten_nha_cung_cap", sanPham.ma_ncc);
            return View(sanPham);
        }

        // POST: SanPhams/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ma_sp,ten_sp,ma_gia,ma_ncc,ma_danh_muc,trang_thai,ghi_chu,xuat_xu,mo_ta,hinh_anh")] SanPham sanPham, HttpPostedFileBase hinh_anh)
        {
            if (ModelState.IsValid)
            {
                /*db.Entry(sanPham).State = EntityState.Modified;
                db.SaveChanges();*/
                try
                {
                    if (hinh_anh.ContentLength > 0)
                    {
                        string _FileName = Path.GetFileName(hinh_anh.FileName);
                        string _path = Path.Combine(Server.MapPath("~/Images"), _FileName);
                        hinh_anh.SaveAs(_path);
                        db.Entry(new SanPham
                        {
                            ma_sp = sanPham.ma_sp,
                            ten_sp = sanPham.ten_sp,
                            ma_gia = sanPham.ma_gia,
                            ma_ncc = sanPham.ma_ncc,
                            ma_danh_muc = sanPham.ma_danh_muc,
                            trang_thai = sanPham.trang_thai,
                            ghi_chu = sanPham.ghi_chu,
                            xuat_xu = sanPham.xuat_xu,
                            mo_ta = sanPham.mo_ta,
                            hinh_anh = "/Images/" + hinh_anh.FileName
                        }).State = EntityState.Modified;
                        ViewBag.Message = "Update Successfully!!";
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                    /*else
                    {
                        db.Entry(sanPham).State = EntityState.Modified;
                        db.SaveChanges();
                    }*/
                }
                catch
                {
                    ViewBag.Message = "Update Fail, Choose Image!!";
                }
                

                return RedirectToAction("Index");

            }
            ViewBag.ma_danh_muc = new SelectList(db.danhmucs, "ma_danh_muc", "ten_danh_muc", sanPham.ma_danh_muc);
            ViewBag.ma_gia = new SelectList(db.gias, "ma_gia", "ma_gia", sanPham.ma_gia);
            ViewBag.ma_ncc = new SelectList(db.nhacungcaps, "ma_nha_cung_cap", "ten_nha_cung_cap", sanPham.ma_ncc);
            return View(sanPham);
        }

        // GET: SanPhams/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sanPham = db.sanphams.Find(id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }
            return View(sanPham);
        }

        // POST: SanPhams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SanPham sanPham = db.sanphams.Find(id);
            db.sanphams.Remove(sanPham);
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
