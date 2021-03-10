using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace KMS.DB.Models
{
    public class KMS_AssetType : KMS_Reclog
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TypeId { get; set; }
        [StringLength(100)]
        [Display(Name = "TypeName")]
        public string Type_Name { get; set; }
        [StringLength(100)]
        public string Type_Desc { get; set; }
    }
}
