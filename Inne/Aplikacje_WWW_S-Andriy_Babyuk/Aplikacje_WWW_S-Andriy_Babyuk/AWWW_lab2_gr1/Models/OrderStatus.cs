using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AWWW_lab2_gr1.Models
{
    public class OrderStatus
    {
        [Key]
        public int Id {get;set;}

        [Required]
        public string Status {get;set;} = "";
    }
}