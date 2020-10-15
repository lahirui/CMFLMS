using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CMFLMS.Models.Library
{
    public class ProductCatagory
    {
        [Key]
        [Required]
        public int ProductCatagoryId { get; set; }
        public string ProductCatagoryName { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? DeletedDate { get; set; }
        public List<Fabrics> Samples { get; set; }
    }
}