using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using SchoolRegister.Model.DataModels;
namespace SchoolRegister.ViewModels.VM
{
    public class GetGradesReportVm
    {
        [Required]
        public int StudentId { get; set; }
        [Required]
        public int GetterUserId { get; set; }
    }
}