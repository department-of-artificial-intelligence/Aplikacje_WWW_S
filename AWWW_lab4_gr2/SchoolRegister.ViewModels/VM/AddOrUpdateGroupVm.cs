using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolRegister.ViewModels.VM
{
    public class AddOrUpdateGroupVm
    {
        [Required]
        public int UserId { get; set; }
        public int? Id { get; set;}
        
        [Required]
        public string Name { get; set; } = null!;
    }
}
