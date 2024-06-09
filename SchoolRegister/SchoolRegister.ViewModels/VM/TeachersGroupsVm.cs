using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SchoolRegister.Model.DataModels;
using System.ComponentModel.DataAnnotations;
namespace SchoolRegister.ViewModels.VM
{
    public class TeachersGroupsVm
    {
        [Required]
        public int TeacherId { get; set; }
        [Required]
        public int GroupId { get; set; }
    }
}