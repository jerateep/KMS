using KMS.DB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KMS.Web.ViewModels
{
    public class ProfileViewModel
    {
        public KMS_User User { get; set; }
        public List<KMS_Menu> LstMenu { get; set; }
        public List<KMS_Permission> LstPermission { get; set; }

    }
}
