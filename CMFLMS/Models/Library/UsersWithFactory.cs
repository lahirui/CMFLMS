using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CMFLMS.Models.Library
{
    public class UsersWithFactory
    {
       [Key]
       [Required]
        public int id { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string FactoryId { get; set; }
        [Required]
        public DateTime InsertedDate { get; set; }


    }
}