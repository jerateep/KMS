using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace KMS.DB.Models
{
    public class KMS_UserMenu : KMS_Reclog
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UmId { get; set; }
        [StringLength(50)]
        public string Username { get; set; }
        [ForeignKey("Username")]
        public virtual KMS_User User { get; set; }
        public int MenuId { get; set; }
        [ForeignKey("MenuId")]
        public virtual KMS_Menu Menu { get; set; }
    }
}
