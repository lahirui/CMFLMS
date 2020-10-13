using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CMFLMS.Models.Library
{
    public class FinishCato
    {
        [Key]
        [Required]
        public int FinishCatoId { get; set; }
        [Required]
        [Display(Name = "Finishing Category")]
        public string FinishCat { get; set; }
        public string Remarks { get; set; }
        public List<Fabrics> Samples { get; set; }
    }
}