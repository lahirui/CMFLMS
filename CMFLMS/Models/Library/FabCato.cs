using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CMFLMS.Models.Library
{
    public class FabCato
    {
        [Key]
        [Required]
        public int FabCatoId { get; set; }
        [Required]
        [Display(Name = "Fabric Category")]
        public string FabricCat { get; set; }
        public string Remarks { get; set; }
        public List<Fabrics> Samples { get; set; }
    }
}