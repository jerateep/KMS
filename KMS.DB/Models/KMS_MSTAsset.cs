using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace KMS.DB.Models
{
    public class KMS_MSTASSET : KMS_Reclog
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AssetId { get; set; }
        [StringLength(100)]
        [Display(Name = "Asset Code")]
        public string Asset_Code { get; set; }
        [StringLength(100)]
        [Display(Name = "Asset Description")]
        public string Asset_Desc { get; set; }
        public int TypeId { get; set; }
        public int LocationId { get; set; }
        public int KeyId { get; set; }
        [ForeignKey("KeyId")]
        public virtual KMS_MSTKey Key { get; set; }
        [ForeignKey("LocationId")]
        public virtual KMS_MSTLocation Location { get; set; }
        [ForeignKey("TypeId")]
        public virtual KMS_AssetType AssetType { get; set; }
    }
}
