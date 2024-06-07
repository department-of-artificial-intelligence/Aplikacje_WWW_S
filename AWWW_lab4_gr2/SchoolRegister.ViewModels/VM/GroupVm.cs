using SchoolRegister.Model.DataModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolRegister.ViewModels.VM
{
    public class GroupVm
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = null!;
        public IList<StudentVm> Students { get; set; } = null!;
        public IList<SubjectVm> Subjects { get; set; } = null!;
    }
}
