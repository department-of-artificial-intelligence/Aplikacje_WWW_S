using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using SchoolRegister.Model.DataModels;
namespace SchoolRegister.ViewModels.VM
{
    public class AttachDetachSubjectToGroupVm
    {
        [Required]
        public int SubjectId { get; set; }
        [Required]
        public int GroupId { get; set; }
    }
}