using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CMFLMS.Models.Library
{
    public class Yarn
    {
        [Key]
        [Required]
        [Display(Name = "Yarn ID")]
        public int YarnId { get; set; }
        [Required]
        [Display(Name = "Yarn Count")]
        public string YarnCount { get; set; }
        public string Remarks { get; set; }
        public List<Fabrics> Samples { get; set; }

    }
}