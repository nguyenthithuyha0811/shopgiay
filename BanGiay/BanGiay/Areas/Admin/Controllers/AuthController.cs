using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BanGiay.Models;

namespace BanGiay.Areas.Admin.Controllers
{
    public class AuthController : Controller
    {
        private GiayDBContext db = new GiayDBContext();
        // GET: Admin/Auth
        public ActionResult Login()
        {
            ViewBag.Error = "";
            return View();
        }
        [HttpPost]
        public ActionResult Login(FormCollection field)
        {
            string strerror = "";
            string username = field["username"];
            string password =field["password"].ToMD5();//Phải mã hóa

            User rowuser = db.User.Where(m => m.Status == 1 && m.Access == 1 &&(m.Username == username || m.Email == username)).FirstOrDefault();
            if (rowuser == null)
            {
                strerror = "Tên đăng nhập không tồn tại";
            }
            else
            {
                if (rowuser.Password.Equals(password))
                {
                    Session["UserAdmin"] = rowuser.Username;
                    Session["UserIdAdmin"] = rowuser.Id;
                    Session["UserFullnameAdmin"] = rowuser.FullName;
                    Session["UserImgAdmin"] = rowuser.Img;
                    return RedirectToAction("Index", "Dashboard");
                }
                else
                {
                    strerror = "Mật khẩu không đúng!";
                }
            }
            ViewBag.Error = "<span class = 'text-danger'>" +strerror+"</span>";
            return View();
        }
    }
}