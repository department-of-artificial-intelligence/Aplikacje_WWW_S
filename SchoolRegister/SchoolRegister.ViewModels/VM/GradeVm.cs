using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using SchoolRegister.Model.DataModels;
namespace SchoolRegister.ViewModels.VM
{
    public class GradeVm
    {
        [Required]
        public string SubjectName { get; set; }
        public GradeScale GradeValue { get; set; }
    }
}