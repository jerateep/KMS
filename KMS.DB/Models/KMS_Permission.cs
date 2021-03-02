using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace KMS.DB.Models
{
    public class KMS_Permission : KMS_Reclog
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PermissionId { get; set; }
        [StringLength(50)]
        public string PermissionName { get; set; }
        public virtual ICollection<KMS_UserPermission> Users { get; set; } = new HashSet<KMS_UserPermission>();
    }
}
