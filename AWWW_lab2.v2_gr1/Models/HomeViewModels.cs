using System.Collections.Generic;
using AWWW_lab2.v2_gr1.Models;

namespace AWWW_lab2.v2_gr1.Models
{
    public class HomeViewModel
    {
        public ICollection<Category>? Categories { get; set; }
        public ICollection<Address>? Addresses { get; set; }
        public ICollection<Tag>? Tags { get; set; }
    }
}