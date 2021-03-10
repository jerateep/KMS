using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace KMS.DB.Models
{
    public class KMS_MSTLocation : KMS_Reclog
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LocationId { get; set; }
        [StringLength(100)]
        public string LocationId_Code { get; set; }
        [StringLength(100)]
        [Display(Name = "Location")]
        public string LocationId_Desc { get; set; }
    }
}
