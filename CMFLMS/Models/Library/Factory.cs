using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CMFLMS.Models.Library
{
    public class Factory
    {
        [Key]
        [Required]
        [Display(Name = "Factory ID")]
        public int FactoryId { get; set; }
        [Required]
        [Display(Name = "Factory")]
        public string FactoryName { get; set; }
        public string Remarks { get; set; }
        //public List<Fabrics> Samples { get; set; }
       
    }
}