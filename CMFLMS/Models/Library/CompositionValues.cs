using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CMFLMS.Models.Library
{
    public class CompositionValues
    {
        [Key]
        [Column(Order = 0)]
        [Required]
        public int CompositionValuesId { get; set; }
        [Key]
        [Column(Order = 1)]
        [Required]
        public string FabricId { get; set; }
        public Fabrics Fabrics { get; set; }
        [Required]
        public int CompositionId { get; set; }
        public Composition compositions { get; set; }
        [Required]
        public double Value { get; set; }

    }
}