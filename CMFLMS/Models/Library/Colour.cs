using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CMFLMS.Models.Library
{
    public class Colour
    {
        [Key]
        [Required]
        [Display(Name = "Colour ID")]
        public int ColourId { get; set; }
        [Required]
        [Display(Name = "Colour")]
        public string ColourName { get; set; }
        public string Remarks { get; set; }
        public List<Fabrics> Samples { get; set; }

    }
}