using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace KMS.DB.Models
{
    public class KMS_UserPermission : KMS_Reclog
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UpId { get; set; }
        [StringLength(50)]
        public string Username { get; set; }
        public virtual KMS_User User { get; set; }
        public int PermissionId { get; set; }
        [ForeignKey("PermissionId")]
        public virtual KMS_Permission Permission { get; set; }

    }
}
