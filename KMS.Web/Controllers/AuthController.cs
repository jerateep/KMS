using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Threading.Tasks;
using System.Web;
using KMS.DB.Data;
using KMS.DB.Models;
using KMS.Web.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Express.Web.Controllers
{
    public class AuthController : Controller
    {
        private readonly MySQLContext _ent;
        public AuthController(MySQLContext ent)
        {
            _ent = ent;
        }
        public IActionResult Index()
        {
            return View();
            //return RedirectToAction("Login", "Auth");

        }
        public IActionResult Login(string User, string Password)
        {
            try
            {
                string EncryPassword = HashPasswordAuth.EncryptString(Password);
                KMS_User UserData = _ent.KMS_User
                                    .Where(s => s.Username.Trim().ToLower() == User.Trim().ToLower()
                                        && s.Password == EncryPassword
                                        //&& s.Permission.Any(i => i.PermissionId == 3)
                                        )
                                    .FirstOrDefault();
                if (UserData != null)
                {
                    HttpContext.Session.SetString("login", UserData.Username);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return RedirectToAction("Index", "Auth");
                }
            }
            catch
            {
                return RedirectToAction("Index", "Auth");
            }
        }
        public IActionResult Logout()
        {
            foreach (var cookie in Request.Cookies.Keys)
            {
                Response.Cookies.Delete(cookie);
            }
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Auth");
        }
        public IActionResult ListUser()
        {
            List<KMS_User> LstUser = _ent.KMS_User.ToList();
            return View(LstUser);
        }
        public IActionResult Edit(string Username)
        {
            string UserName = HttpContext.Session.GetString("login");
            if (!string.IsNullOrEmpty(UserName))
            {
                KMS_User User = new KMS_User();
                User = _ent.KMS_User.Where(k => k.Username == Username).FirstOrDefault();
                return View(User);
            }
            else
            {
                return RedirectToAction("Index", "Auth");

            }
        }
        public IActionResult Save(KMS_User Data)
        {
            string UserName = HttpContext.Session.GetString("login");
            if (!string.IsNullOrEmpty(UserName))
            {
                string MessageResult = "";
                KMS_User uData = _ent.KMS_User.Where(w => w.Username == Data.Username).FirstOrDefault();
                if (uData != null)
                {
                    try
                    {
                        uData.Username = Data.Username;
                        //uData.Password = Extensions.HashPasswordAuth.EncryptString(Data.Password);
                        uData.FName = Data.FName;
                        uData.LName = Data.LName;
                        uData.Email = Data.Email;
                        uData.AddressL1 = Data.AddressL1;
                        uData.AddressL2 = Data.AddressL2;
                        uData.IsActive = Data.IsActive;
                        uData.Cod_update = UserName;
                        uData.Dtm_update = DateTime.Now;
                        _ent.SaveChanges();
                        MessageResult = "Update data success.";

                    }
                    catch (Exception ex)
                    {
                        MessageResult = ex.Message + "/ " + ex.InnerException.Message;
                    }
                }
                else
                {
                    //Insert
                    try
                    {
                        int RowId = _ent.KMS_User.OrderByDescending(o => o.UserId).Select(s => (int)s.UserId).FirstOrDefault() + 1;
                        _ent.KMS_User.Add(new KMS_User
                        {
                            UserId = RowId,
                            Username = Data.Username,
                            Password = HashPasswordAuth.EncryptString(Data.Password),
                            FName = Data.FName,
                            LName = Data.LName,
                            Email = Data.Email,
                            AddressL1 = Data.AddressL1,
                            AddressL2 = Data.AddressL2,
                            IsActive = Data.IsActive,
                            Cod_create = UserName,
                            Dtm_create = DateTime.Now
                        });
                        _ent.SaveChanges();
                        MessageResult = "Insert data success.";

                    }
                    catch (Exception ex)
                    {
                        MessageResult = ex.Message + "/ " + ex.InnerException.Message;
                    }
                    MessageResult = "Insert data complete.";
                }
                return RedirectToAction("ListUser", "Auth");
            }
            else
            {
                return RedirectToAction("Index", "Auth");
            }
        }
    }
}
