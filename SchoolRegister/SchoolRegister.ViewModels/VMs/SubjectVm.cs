using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolRegister.ViewModels.VMs
{
    public class SubjectVm
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public IList<GroupVm> Groups { get; set; }

        public string TeacherName { get; set; }
    }
}
