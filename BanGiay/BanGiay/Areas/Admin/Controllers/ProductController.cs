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
    public class ProductController : BaseController
    {
        private GiayDBContext db = new GiayDBContext();
        // GET: Admin/Product
        public ActionResult Index()
        {
            var data = db.Product.Where(x => x.Status != 0).ToList();

            //Đổ ra view
            return View(data);
        }
        [HttpGet]
        public ActionResult Status(int id)
        {
            var row = db.Product.Find(id);
            row.Status = (row.Status == 1) ? 2 : 1;
            db.Entry(row).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("index", "Product");
        }

        [HttpGet]
        public ActionResult DeTrash(int id)
        {
            var row = db.Product.Find(id);
            row.Status = 0;
            db.Entry(row).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("index", "Product");
        }

        public ActionResult Trash()
        {
            return View(db.Product.Where(x => x.Status == 0).ToList());
        }

        public ActionResult Delete(int id)
        {
            var row = db.Product.Find(id);
            db.Product.Remove(row);
            db.SaveChanges();

            return RedirectToAction("Trash", "Product");
        }

        public ActionResult ReTrash(int id)
        {
            var row = db.Product.Find(id);
            row.Status = 2;
            db.Entry(row).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("index", "Product");
        }

        public ActionResult Edit(int id)
        {
            ViewBag.ListCat = new SelectList(db.Category.Where(x=>x.Status == 1).ToList(), "Id", "Name", 0);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product mproduct = db.Product.Find(id);
            if (mproduct == null)
            {
                return HttpNotFound();
            }
            return View(mproduct);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product mproduct, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                string slug = Mystring.ToSlug(mproduct.Name.ToString());
                file = Request.Files["img"];
                string filename = file.FileName.ToString();
                if (filename.Equals("") == false)
                {
                    String fileName = slug + file.FileName.Substring(file.FileName.LastIndexOf("."));
                    mproduct.Img = fileName;
                    String Strpath = Path.Combine(Server.MapPath("~/Public/Images/Product/"), fileName);
                    file.SaveAs(Strpath);
                }

                mproduct.Slug = slug;
                mproduct.UpdatedAt = DateTime.Now;
                mproduct.UpdatedBy = int.Parse(Session["UserIdAdmin"].ToString());
                db.Entry(mproduct).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ListCat = new SelectList(db.Product.ToList(), "Id", "Name", 0);
            return View(mproduct);
        }


        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.ListCat = new SelectList(db.Category.ToList(), "Id", "Name", 0);
            return View("Create");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product modelproduct)
        {
            if (ModelState.IsValid)
            {
                string slug = Mystring.ToSlug(modelproduct.Name.ToString());
                modelproduct.Slug = slug;
                modelproduct.CreatedAt = DateTime.Now;
                modelproduct.UpdatedAt = DateTime.Now;
                modelproduct.Sold = 0;
                modelproduct.CreatedBy = int.Parse(Session["UserIdAdmin"].ToString());
                modelproduct.UpdatedBy = int.Parse(Session["UserIdAdmin"].ToString());
                //Upload file
                var f = Request.Files["Img"];
                if (f != null && f.ContentLength > 0)
                {
                    String fileName = slug + f.FileName.Substring(f.FileName.LastIndexOf("."));
                    modelproduct.Img = fileName;
                    String Strpath = Path.Combine(Server.MapPath("~/Public/Images/Product/"), fileName);
                    f.SaveAs(Strpath);
                }
                modelproduct.CreatedBy = 1;
                modelproduct.UpdatedBy = 1;
                db.Product.Add(modelproduct);
                db.SaveChanges();
                return RedirectToAction("index");
            }
            ViewBag.ListCat = new SelectList(db.Product.ToList(), "Id", "Name", 0);
            return View();
        }
    }
}