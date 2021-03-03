using System;
using System.Collections.Generic;
using System.Text;

namespace KMS.ViewModels
{
    public class MenuItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public string Icon { get; set; }
        public bool OpenInNewWindow { get; set; }
        public static IEnumerable<MenuItem> MenuItems()
        {
            IEnumerable<MenuItem> Data = new List<MenuItem> 
            {
                new MenuItem { Title = "Home", Url = "~/",Icon ="fa fa-home" },
                new MenuItem { Title = "User", Url = "~/Auth/ListUser",Icon ="fa fa-user" },

             };
            return Data;
        }
    }

}
