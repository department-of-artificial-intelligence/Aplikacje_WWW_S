using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using SchoolRegister.Model.DataModels;
namespace SchoolRegister.ViewModels.VM
{
    public class GradesReportVm
    {
        [Required]
        public int StudentId { get; set; }
        public IEnumerable<GradeVm> Grades { get; set; }
    }
}