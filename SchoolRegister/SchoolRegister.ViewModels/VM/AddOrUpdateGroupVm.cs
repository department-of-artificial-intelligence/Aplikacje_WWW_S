using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace SchoolRegister.ViewModels.VM
{
    public class AddOrUpdateGroupVm
    {
         public int? Id { get; set; }

        [Required]
        public required string Name { get; set; }
    }
}