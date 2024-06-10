using SchoolRegister.Model.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolRegister.ViewModels.VM
{
    public class GradeVm
    {
        public string Subjectname {  get; set; }
        public GradeScale GradeValue { get; set; }
    }
}
