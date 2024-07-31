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
    public class TopicController : BaseController
    {
        private GiayDBContext db = new GiayDBContext();
        // GET: Admin/Topic
        public ActionResult Index()
        {
            // Lấy dữ liệu từ DB
            var data = db.Topic.Where(x => x.Status != 0).ToList();

            //Đổ ra view
            return View(data);
        }
        [HttpGet]
        public ActionResult Status(int id)
        {
            var row = db.Topic.Find(id);
            row.Status = (row.Status == 1) ? 2 : 1;
            db.Entry(row).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("index", "Topic");
        }

        [HttpGet]
        public ActionResult DeTrash(int id)
        {
            var row = db.Topic.Find(id);
            row.Status = 0;
            db.Entry(row).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("index", "Topic");
        }

        public ActionResult Trash()
        {
            return View(db.Topic.Where(x => x.Status == 0).ToList());
        }

        public ActionResult Delete(int id)
        {
            var row = db.Topic.Find(id);
            db.Topic.Remove(row);
            db.SaveChanges();

            return RedirectToAction("Delete", "Topic");
        }

        public ActionResult ReTrash(int id)
        {
            var row = db.Topic.Find(id);
            row.Status = 2;
            db.Entry(row).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("index", "Topic");
        }

        public ActionResult Edit(int id)
        {
            ViewBag.listCate = db.Topic.Where(m => m.Status != 0).ToList();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Topic mtopic = db.Topic.Find(id);
            if (mtopic == null)
            {
                return HttpNotFound();
            }
            return View(mtopic);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Topic mtopic)
        {
            if (ModelState.IsValid)
            {
                string slug = Mystring.ToSlug(mtopic.Name.ToString());
                mtopic.Slug = slug;
                mtopic.UpdatedAt = DateTime.Now;
                mtopic.UpdatedBy = int.Parse(Session["UserIdAdmin"].ToString());
                db.Entry(mtopic).State = System.Data.Entity.EntityState.Modified;

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mtopic);
        }


        [HttpGet]
        public ActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Topic mtopic)
        {
            if (ModelState.IsValid)
            {
                string slug = Mystring.ToSlug(mtopic.Name.ToString());
                mtopic.Slug = slug;
                mtopic.CreatedAt = DateTime.Now;
                mtopic.UpdatedAt = DateTime.Now;
                mtopic.UpdatedBy = int.Parse(Session["UserIdAdmin"].ToString());
                mtopic.CreatedBy = 1;
                mtopic.UpdatedBy = 1;
                db.Topic.Add(mtopic);
                db.SaveChanges();
                return RedirectToAction("index");
            }
            return View();
        }
    }
}
