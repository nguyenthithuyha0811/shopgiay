using BanGiay.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Security.Cryptography.X509Certificates;

namespace BanGiay.Areas.Admin.Controllers
{
    public class PostController : BaseController
    {
        private GiayDBContext db = new GiayDBContext();
        // GET: Admin/Product
        public ActionResult Index()
        {
            var data = db.Post.Where(x => x.Status != 0).ToList();

            //Đổ ra view
            return View(data);
        }
        [HttpGet]
        public ActionResult Status(int id)
        {
            var row = db.Post.Find(id);
            row.Status = (row.Status == 1) ? 2 : 1;
            db.Entry(row).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("index", "Post");
        }

        [HttpGet]
        public ActionResult DeTrash(int id)
        {
            var row = db.Post.Find(id);
            row.Status = 0;
            db.Entry(row).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("index", "Post");
        }

        public ActionResult Trash()
        {
            return View(db.Post.Where(x => x.Status == 0).ToList());
        }

        public ActionResult Delete(int id)
        {
            var row = db.Post.Find(id);
            db.Post.Remove(row);
            db.SaveChanges();

            return RedirectToAction("Trash", "Post");
        }

        public ActionResult ReTrash(int id)
        {
            var row = db.Post.Find(id);
            row.Status = 2;
            db.Entry(row).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("index", "Post");
        }

        public ActionResult Edit(int id)
        {
            ViewBag.ListCat = new SelectList(db.Topic.Where(x => x.Status == 1).ToList(), "Id", "Name", 0);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post mpost = db.Post.Find(id);
            if (mpost == null)
            {
                return HttpNotFound();
            }
            return View(mpost);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Post mpost, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                string slug = Mystring.ToSlug(mpost.Title.ToString());
                file = Request.Files["img"];
                string filename = file.FileName.ToString();
                if (filename.Equals("") == false)
                {
                    String fileName = slug + file.FileName.Substring(file.FileName.LastIndexOf("."));
                    mpost.Img = fileName;
                    String Strpath = Path.Combine(Server.MapPath("~/Public/Images/Post/"), fileName);
                    file.SaveAs(Strpath);
                }
                mpost.Type = "post";
                mpost.Slug = slug;
                mpost.UpdatedAt = DateTime.Now;
                mpost.UpdatedBy = int.Parse(Session["UserIdAdmin"].ToString());
                db.Entry(mpost).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ListCat = new SelectList(db.Post.ToList(), "Id", "Name", 0);
            return View(mpost);
        }


        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.ListCat = new SelectList(db.Category.ToList(), "Id", "Name", 0);
            return View("Create");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Post modelpost)
        {
            if (ModelState.IsValid)
            {
                modelpost.Type = "post";
                string slug = Mystring.ToSlug(modelpost.Title.ToString());
                modelpost.Slug = slug;
                modelpost.CreatedAt = DateTime.Now;
                modelpost.UpdatedAt = DateTime.Now;
                modelpost.TopId = 0;
                modelpost.CreatedBy = int.Parse(Session["UserIdAdmin"].ToString());
                modelpost.UpdatedBy = int.Parse(Session["UserIdAdmin"].ToString());
                //Upload file
                var file = Request.Files["Img"];
                if (file != null && file.ContentLength > 0)
                {
                    String fileName = slug + file.FileName.Substring(file.FileName.LastIndexOf("."));
                    modelpost.Img = fileName;
                    String Strpath = Path.Combine(Server.MapPath("~/Public/Images/Post/"), fileName);
                    file.SaveAs(Strpath);
                }
                modelpost.CreatedBy = 1;
                modelpost.UpdatedBy = 1;
                db.Post.Add(modelpost);
                db.SaveChanges();
                return RedirectToAction("index");
            }
            ViewBag.ListCat = new SelectList(db.Post.ToList(), "Id", "Name", 0);
            return View();
        }
    }
}