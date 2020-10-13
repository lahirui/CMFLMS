using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CMFLMS.Models.Library
{
    public class Category
    {
        [Key]
        [Required]
        [Display(Name = "Category ID")]
        public int CategoryId { get; set; }
        [Required]
        [Display(Name = "Category Name")]
        public string CategoryName { get; set; }
        public string Remarks { get; set; }
        public List<Supplier> Suppliers { get; set; }
    }
}