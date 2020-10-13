using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CMFLMS.Models.Library
{
    public class Supplier
    {
        [Key]
        [Required]
        [Display(Name = "Supplier ID")]
        public int SupplierId { get; set; }
        [Required]
        [Display(Name = "Supplier Name")]
        public string SupplierName { get; set; }
       // [Required]
        [Display(Name = "Contact Person")]
        public string ContactPerson { get; set; }
        [Required]
        public string Address { get; set; }
        // [Required]
        [Required(ErrorMessage = "You must provide a phone number")]
        [Display(Name = "Telephone")]
        [DataType(DataType.PhoneNumber)]
        //[RegularExpression(@"^\(?([0-9]{3})\)?([0-9]{3})?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public string Telephone { get; set; }
       // [Required]
        public string Email { get; set; }
        [Display(Name = "Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public string AddedDate { get; set; }
        [Required]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }
        public Category categories { get; set; }
        public List<Fabrics> Samples { get; set; }
    }
}