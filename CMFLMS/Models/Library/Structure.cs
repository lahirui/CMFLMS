using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CMFLMS.Models.Library
{
    public class Structure
    {
        [Key]
        [Required]
        [Display(Name = "Structure ID")]
        public int StructureId { get; set; }
        [Required]
        [Display(Name = "Structure")]
        public string StructureValue { get; set; }
        public string Remarks { get; set; }
        public List<Fabrics> Samples { get; set; }
    }
}