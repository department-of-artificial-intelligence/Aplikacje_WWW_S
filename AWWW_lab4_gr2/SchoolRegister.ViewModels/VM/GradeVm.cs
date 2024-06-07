using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolRegister.Model.DataModels;

namespace SchoolRegister.ViewModels.VM
{
    public class GradeVm
    {
        public string SubjectName { get; set; }

        public GradeScale GradeValue { get; set; }
    }
}
