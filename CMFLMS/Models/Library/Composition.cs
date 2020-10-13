using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CMFLMS.Models.Library
{
    public class Composition
    {
        [Key]
        [Required]
        public int CompositionId { get; set; }
        [Required]
        [Display(Name = "Composition")]
        public string CompositionName { get; set; }
        public string Remarks { get; set; }
       
    }
}