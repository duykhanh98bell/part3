using projectPart3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace projectPart3.Controllers
{
    public class HomeController : Controller
    {
        private LTQLDBContext db = new LTQLDBContext();
        public ActionResult Index()
        {
            var sanphams = db.sanphams.Include(s => s.danhmucs).Include(s => s.gias).Include(s => s.nhacungcaps).ToList();
            ViewBag.DanhMuc = db.danhmucs.ToList();
            return View(sanphams);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            ViewBag.DanhMuc = db.danhmucs.ToList();
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            ViewBag.DanhMuc = db.danhmucs.ToList();
            return View();
        }
        public ActionResult ShowProduct(int page =1, int pageSize = 6)
        {
            ViewBag.Message = "Your application description page.";
            int totalRecord = db.sanphams.Count();
            ViewBag.sanphams = db.sanphams.Include(s => s.danhmucs).Include(s => s.gias).Include(s => s.nhacungcaps).OrderByDescending(s => s.ma_sp).Skip((page-1)*pageSize).Take(pageSize).ToList();
            ViewBag.DanhMuc = db.danhmucs.ToList();
            ViewBag.TakeProduct = db.sanphams.ToList();
            ViewBag.total = totalRecord;
            ViewBag.page = page;

            int maxPage = 5;
            int totalPage = 0;

            totalPage = (int)Math.Ceiling((double)(totalRecord / pageSize));
            ViewBag.totalPage = totalPage;
            ViewBag.maxPage = maxPage;
            ViewBag.first = 1;
            ViewBag.last = totalPage;
            ViewBag.next = page + 1;
            ViewBag.prev = page - 1;
            
            return View();
        }
        public ActionResult Detail(long id)
        {
            ViewBag.Message = "Your contact page.";
            ViewBag.sanphams = db.sanphams.Find(id);
            ViewBag.DanhMuc = db.danhmucs.ToList();
            return View();
        }
        public ActionResult Cart()
        {
            ViewBag.Message = "Your contact page.";
            ViewBag.DanhMuc = db.danhmucs.ToList();
            return View();
        }
        public ActionResult Checkout()
        {
            ViewBag.Message = "Your contact page.";
            ViewBag.DanhMuc = db.danhmucs.ToList();
            return View();
        }
    }
}