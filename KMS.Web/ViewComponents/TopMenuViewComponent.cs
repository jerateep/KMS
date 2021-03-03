
using KMS.DB.Models;
using KMS.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KMS.Web.ViewComponents
{
    public class TopMenuViewComponent : ViewComponent
    {
        //private readonly DB_BackOfficeContext _Bkof;
        //public TopMenuViewComponent(DB_BackOfficeContext Bkof)
        //{
        //    _Bkof = Bkof;
        //}
        public async Task<IViewComponentResult> InvokeAsync()
        {
            string Username = HttpContext.Session.GetString("login");

            var UserData = new KMS_User();
            ViewBag.User = "ชื่อจริง" + " " + "นามสกุล";
            ViewBag.UserName = "UserName";
            ViewBag.Position = "ตำแหน่ง";
            ViewBag.BU = "หน่วยงาน";
            string ImageProfile = "";
            if (UserData.UserImage != null)
            {
                ImageProfile = GetImageProfile(UserData.UserImage);
            }
            ViewBag.UserImage = ImageProfile;
            var Menus = MenuItem.MenuItems();
            //foreach (var m in Menus)
            //{
            //    Menus.Add(new MenuItem { Id = m.MenuId, Title = m.Menu.MenuName.Trim(), Url = m.Menu.MenuUrl.Trim(), Icon = m.Menu.MenuIcon.Trim() });
            //}
            return await Task.FromResult((IViewComponentResult)View("Default", Menus));
        }

        public string GetImageProfile(byte[] _Image)
        {
            try
            {
                string base64String = "";
                base64String = Convert.ToBase64String(_Image);
                return base64String;
            }
            catch
            {
                return "";
            }
        }
    }
}
