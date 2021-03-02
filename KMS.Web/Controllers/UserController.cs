using KMS.DB.Data;
using KMS.DB.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace KMS.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly MySQLContext _ent;
        public UserController(MySQLContext ent)
        {
            _ent = ent;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Profile()
        {
            string Username = HttpContext.Session.GetString("login");
            if (!string.IsNullOrEmpty(Username))
            {
                KMS_User User = new KMS_User();
                User = _ent.KMS_User.Where(k => k.Username == Username).FirstOrDefault();
                ViewBag.UserImage = User.UserImage != null ? Convert.ToBase64String(User.UserImage) : "";
                ViewBag.MsgBox = TempData["MsgResult"];
                return View(User);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        public IActionResult Save(KMS_User _user)
        {
            try
            {
                var Data = _ent.KMS_User.Where(j => j.Username == _user.Username).FirstOrDefault();
                Data.FName = _user.FName;
                Data.LName = _user.LName;
                Data.Email = _user.Email;
                Data.Cod_update = _user.Username;
                Data.Dtm_update = DateTime.Now;
                _ent.SaveChanges();
                TempData["MsgResult"] = "success,Update complete.";
            }
            catch (Exception ex)
            {
                TempData["MsgResult"] = "error," + ex.Message;
            }
            return RedirectToAction("Profile");
        }
        [HttpPost]
        public IActionResult UploadImageProfile(IFormFile _file, KMS_User _User)
        {
            try
            {
                if (_file != null && _file.Length > 0)
                {
                    using (var ms = new MemoryStream())
                    {
                        _file.CopyTo(ms);
                        var fileBytes = ms.ToArray();
                        var User = _ent.KMS_User.Where(j => j.Username == _User.Username).FirstOrDefault();
                        User.UserImage = fileBytes;
                        User.Cod_update = _User.Username;
                        User.Dtm_update = DateTime.Now;
                        _ent.SaveChanges();
                    }
                    TempData["MsgResult"] = "success,Upload image complete.";
                }
            }
            catch (Exception ex)
            {
                TempData["MsgResult"] = "error," + ex.Message;
            }
            return RedirectToAction("Profile");
        }
    }
}
