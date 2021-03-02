using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace KMS.DB.Models
{
    public class KMS_Reclog
    {
        [Display(Name = "Active?")]
        public bool IsActive { get; set; }
        [StringLength(25)]
        public string Cod_create { get; set; }
        public DateTime? Dtm_create { get; set; }
        [StringLength(25)]
        public string Cod_update { get; set; }
        public DateTime? Dtm_update { get; set; }
    }
}
