using BanGiay.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace BanGiay.Areas.Admin.Controllers
{
    public class CategoryController : BaseController
    {
        private GiayDBContext db = new GiayDBContext();
        // GET: Admin/Category
        public ActionResult Index()
        {
            // Lấy dữ liệu từ DB
            var data = db.Category.Where(x => x.Status != 0).ToList();

            //Đổ ra view
            return View(data);
        }
        [HttpGet]
        public ActionResult Status(int id)
        {
            var row= db.Category.Find(id);
            row.Status = (row.Status == 1) ? 2 : 1;
            db.Entry(row).State =System.Data.Entity.EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("index","Category");
        }

        [HttpGet]
        public ActionResult DeTrash(int id)
        {
            var row = db.Category.Find(id);
            row.Status = 0;
            db.Entry(row).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("index", "Category");
        }

        public ActionResult Trash()
        {
            return View(db.Category.Where(x => x.Status == 0).ToList());
        }

        public ActionResult Delete(int id)
        {
            var row = db.Category.Find(id);
            db.Category.Remove(row);
            db.SaveChanges();

            return RedirectToAction("Trash", "Category");
        }

        public ActionResult ReTrash(int id)
        {
            var row = db.Category.Find(id);
            row.Status = 2;
            db.Entry(row).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("index", "Category");
        }

        public ActionResult Edit(int id)
        {
            ViewBag.listCate = db.Category.Where(m => m.Status != 0).ToList();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category mcategory = db.Category.Find(id);
            if (mcategory == null)
            {
                return HttpNotFound();
            }
            return View(mcategory);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Category mcategory)
        {
            if (ModelState.IsValid)
            {
                string slug = Mystring.ToSlug(mcategory.Name.ToString());
                mcategory.Slug = slug;
                mcategory.UpdatedAt = DateTime.Now;
                mcategory.UpdatedBy = int.Parse(Session["UserIdAdmin"].ToString());
                db.Entry(mcategory).State = System.Data.Entity.EntityState.Modified;
               
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mcategory);
        }


        [HttpGet]
        public ActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category mcategory)
        {
            if (ModelState.IsValid)
            {
                string slug = Mystring.ToSlug(mcategory.Name.ToString());
                mcategory.Slug = slug;
                mcategory.CreatedAt = DateTime.Now;
                mcategory.UpdatedAt = DateTime.Now;
                mcategory.CreatedBy = int.Parse(Session["UserIdAdmin"].ToString());
                mcategory.UpdatedBy = int.Parse(Session["UserIdAdmin"].ToString());
                mcategory.CreatedBy = 1;
                mcategory.UpdatedBy = 1;
                db.Category.Add(mcategory);
                db.SaveChanges();
                return RedirectToAction("index");
            }
            return View();
        }
    }
}