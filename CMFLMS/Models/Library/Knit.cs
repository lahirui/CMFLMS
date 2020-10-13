using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CMFLMS.Models.Library
{
    public class Knit
    {
        [Key]
        [Required]
        [Display(Name = "Knit ID")]
        public int KnitId { get; set; }
        [Required]
        [Display(Name = "Knit")]
        public string KnitType { get; set; }
        public string Remarks { get; set; }
        public List<Fabrics> Samples { get; set; }

    }
}