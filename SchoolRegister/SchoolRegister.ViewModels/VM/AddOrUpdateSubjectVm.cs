using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace SchoolRegister.ViewModels.VM
{
    public class AddOrUpdateSubjectVm
    {
        public int? Id { get; set; }
        [Required]
        public string Name { get; set; } = null!;
        [Required]
        public string Description { get; set; } = null!;
        [Required]
        public int TeacherId { get; set; }
    }
}