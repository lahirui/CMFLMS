using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using CMFLMS.Data;
using System.Data;

namespace CMFLMS.Models.Library
{
    
    public class Fabrics
    {

        [Key]
        [Required]
        public int FabricsId { get; set; }
        [Required]
        [Display(Name = "Fabric ID")]
        public string FabricId { get; set; }
        [Required]
        [Display(Name = "Supplier")]
        public int SupplierId { get; set; }
        public Supplier Suppliers { get; set; }
        [Required]
        public string Compisition1 { get; set; }
        public string Compisition2 { get; set; }
        public string Compisition3 { get; set; }
        public string Compisition4 { get; set; }
        public string Compisition5 { get; set; }
        
        [Required]
        [Display(Name = "Quality")]
        public string Quality { get; set; }
        [Required]
        [Display(Name = "Construction")]
       
        public int ConstructionId { get; set; }
        public Construction Constructions { get; set; }
        [Required]
        [Display(Name = "Yarn Count")]
      
        public int YarnId { get; set; }
        public Yarn Yarns { get; set; }
        [Required]
        [Display(Name = "Width (Inches)")]
        [Range(0, int.MaxValue, ErrorMessage = "Enter Positive Numbers Only")]
        public double WidthInches { get; set; }   
        [Display(Name = "Width (CM)")]
        public double WidthCm { get; set; }       
        [Display(Name = "Date")]
        public string AddedDate { get; set; }
        [Required]
        [Display(Name = "Weight (GSM)")]
        [Range(0, int.MaxValue, ErrorMessage = "Enter Positive Numbers Only")]
        public double Weight { get; set; }
        [Required]
        [Display(Name = "Price (USD)")]
        [Range(0, int.MaxValue, ErrorMessage = "Enter Positive Numbers Only")]
        public double Price { get; set; }
        [Required]
        [Display(Name = "Location")]
        public int LocationsId { get; set; }
        public Locations Locationss { get; set; }
        [Required]
        [Display(Name = "Knit")]
        public int KnitId { get; set; }
        public Knit Knits { get; set; }
        [Required]
        [Display(Name = "Structure")]
        public int StructureId { get; set; }
        public Structure Structures { get; set; }
        [Required]
        [Display(Name = "Colour")]
        public int ColourId { get; set; }
        public Colour Colours { get; set; }
        [Required]
        [Display(Name= "Factory")]
        public int FactoryId { get; set; }
        public Factory Factories { get; set; }
        [Required]
        [Display(Name = "Fab Category")]
        public int FabCatoId { get; set; }
        public FabCato FabCats { get; set; }

        [Display(Name = "Finishing Category")]
        public int FinishCatoId { get; set; }
        public FinishCato FinCategory { get; set; }
        //public FinishingCategory FinishingCategory { get; set; }
        public string Remarks { get; set; }


    }
}