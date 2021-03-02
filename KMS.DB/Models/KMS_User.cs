using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace KMS.DB.Models
{
    public class KMS_User : KMS_Reclog
    {
        [Key]
        [StringLength(50)]
        [Required]
        public string Username { get; set; }
        public int? UserId { get; set; }
        [StringLength(200)]
        [Required]
        public string Password { get; set; }
        [StringLength(50)]
        [Display(Name = "Firstname")]
        public string FName { get; set; }
        [StringLength(50)]
        [Display(Name = "Lastname")]
        public string LName { get; set; }
        [EmailAddress]
        [StringLength(100)]
        public string Email { get; set; }
        public byte[] UserImage { get; set; }
        [StringLength(100)]
        [Display(Name = "Address Line 1.")]
        public string AddressL1 { get; set; }
        [StringLength(100)]
        [Display(Name = "Address Line 2.")]
        public string AddressL2 { get; set; }
        [StringLength(10)]
        public string AddressCode { get; set; }
        public virtual ICollection<KMS_UserMenu> Menus { get; set; } = new HashSet<KMS_UserMenu>();
        public virtual ICollection<KMS_UserPermission> Permission { get; set; } = new HashSet<KMS_UserPermission>();

    }
}
