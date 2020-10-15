using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CMFLMS.Models.Library
{
    public class SourcingType
    {
        [Key]
        [Required]
        public int SourcingTypeId { get; set; }
        public string SourcingTypeName { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? DeletedDate { get; set; }
        public List<Fabrics> Samples { get; set; }
    }
}