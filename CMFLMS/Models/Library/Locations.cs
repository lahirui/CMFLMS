using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CMFLMS.Models.Library
{
    public class Locations
    {
        [Key]
        [Required]
        [Display(Name = "Location ID")]
        public int LocationsId { get; set; }
        [Required]
        [Display(Name = "Location")]
        public string LocationName { get; set; }
        public string Remarks { get; set; }
        public List<Fabrics> Samples { get; set; }

    }
}