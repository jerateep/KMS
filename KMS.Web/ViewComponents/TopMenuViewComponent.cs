
using KMS.DB.Data;
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
        private readonly MySQLContext _ent;
        public TopMenuViewComponent(MySQLContext ent)
        {
            _ent = ent;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            string strUsername = HttpContext.Session.GetString("login");

            KMS_User UserData = _ent.KMS_User.Where(o => o.Username == strUsername && o.IsActive == true).FirstOrDefault();
            ViewBag.User = UserData.FName + " " + UserData.LName;
            ViewBag.UserName = strUsername;
            ViewBag.Position = "ยังไม่เพิ่มฟิลล์";
            ViewBag.BU = "ยังไม่เพิ่มฟิลล์";
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
