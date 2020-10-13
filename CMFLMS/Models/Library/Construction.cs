using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CMFLMS.Models.Library
{
    public class Construction
    {
        [Key]
        [Required]
        [Display(Name = "Construction ID")]
        public int ConstructionId{ get; set; }
        [Required]
        [Display(Name = "Construction")]
        public string ConstructionType { get; set; }
        public string Remarks { get; set; }
        public List<Fabrics> Samples { get; set; }


    }
}