using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Threading.Tasks;
using System.Web;
using KMS.DB.Data;
using KMS.DB.Models;
using KMS.Web.Extensions;
using KMS.Web.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
            string Sessionlogin = HttpContext.Session.GetString("login");
            if (!string.IsNullOrEmpty(Sessionlogin))
            {
                ProfileViewModel Profile = new ProfileViewModel();
                Profile.User = _ent.KMS_User.Where(k => k.Username == Username).Include(o => o.Permission).FirstOrDefault();
                Profile.LstPermission = _ent.KMS_Permission.Where(k => k.IsActive == true).ToList();
                Profile.LstMenu = _ent.KMS_Menu.Where(k => k.IsActive == true).ToList();
                return View(Profile);
            }
            else
            {
                return RedirectToAction("Index", "Auth");
            }
        }
        public IActionResult Save(ProfileViewModel Data)
        {
            string UserName = HttpContext.Session.GetString("login");
            if (!string.IsNullOrEmpty(UserName))
            {
                string MessageResult = "";
                KMS_User uData = _ent.KMS_User.Where(w => w.Username == Data.User.Username).FirstOrDefault();
                if (uData != null)
                {
                    try
                    {

                        List<KMS_UserPermission> LstPermission = new List<KMS_UserPermission>();
                        List<KMS_UserMenu> LstMenu = new List<KMS_UserMenu>();
                        foreach (var p in Data.LstPermission.Where(o => o.IsActive))
                        {
                            LstPermission.Add(new KMS_UserPermission
                            {
                                Username = Data.User.Username,
                                PermissionId = p.PermissionId,
                                IsActive = p.IsActive
                            });
                        }
                        foreach (var m in Data.LstMenu.Where(o => o.IsActive))
                        {
                            LstMenu.Add(new KMS_UserMenu
                            {
                                Username = Data.User.Username,
                                MenuId = m.MenuId,
                                IsActive = m.IsActive
                            });
                        }
                        _ent.RemoveRange(uData.Permission);
                        _ent.RemoveRange(uData.Menus);
                        uData.Username = Data.User.Username;
                        //uData..Password = Extensions.HashPasswordAuth.EncryptString(Data.User.Password);
                        uData.FName = Data.User.FName;
                        uData.LName = Data.User.LName;
                        uData.Email = Data.User.Email;
                        uData.AddressL1 = Data.User.AddressL1;
                        uData.AddressL2 = Data.User.AddressL2;
                        uData.IsActive = Data.User.IsActive;
                        uData.Cod_update = UserName;
                        uData.Dtm_update = DateTime.Now;
                        uData.Permission = LstPermission;
                        uData.Menus = LstMenu;
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
                        List<KMS_UserPermission> LstPermission = new List<KMS_UserPermission>();
                        List<KMS_UserMenu> LstMenu = new List<KMS_UserMenu>();
                        foreach (var p in Data.LstPermission.Where(o => o.IsActive))
                        {
                            LstPermission.Add(new KMS_UserPermission
                            {
                                Username = Data.User.Username,
                                PermissionId = p.PermissionId,
                                IsActive = p.IsActive
                            });
                        }
                        foreach (var m in Data.LstMenu.Where(o => o.IsActive))
                        {
                            LstMenu.Add(new KMS_UserMenu
                            {
                                Username = Data.User.Username,
                                MenuId = m.MenuId,
                                IsActive = m.IsActive
                            });
                        }
                        _ent.KMS_User.Add(new KMS_User
                        {
                            UserId = RowId,
                            Username = Data.User.Username,
                            Password = HashPasswordAuth.EncryptString(Data.User.Password),
                            FName = Data.User.FName,
                            LName = Data.User.LName,
                            Email = Data.User.Email,
                            AddressL1 = Data.User.AddressL1,
                            AddressL2 = Data.User.AddressL2,
                            IsActive = Data.User.IsActive,
                            Cod_create = UserName,
                            Dtm_create = DateTime.Now,
                            Permission = LstPermission,
                            Menus = LstMenu
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
