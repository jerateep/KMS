using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace KMS.DB.Models
{
    public class KMS_Menu : KMS_Reclog
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MenuId { get; set; }
        [StringLength(50)]
        public string MenuName { get; set; }
        [StringLength(50)]
        public string MenuUrl { get; set; }
        [StringLength(50)]
        public string MenuIcon { get; set; }
        public virtual ICollection<KMS_UserMenu> Users { get; set; } = new HashSet<KMS_UserMenu>();

    }
}
