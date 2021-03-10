using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace KMS.DB.Models
{
    public class KMS_MSTKey : KMS_Reclog
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int KeyId { get; set; }
        [StringLength(100)]
        [Display(Name = "Key Code")]
        public string Key_Code { get; set; }
        [StringLength(100)]
        [Display(Name = "Key Description")]
        public string Key_Desc { get; set; }
        [StringLength(100)]
        [Display(Name = "Key Box")]
        public string Key_Box { get; set; }
    }
}
