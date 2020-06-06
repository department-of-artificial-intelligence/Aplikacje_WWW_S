using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolRegister.ViewModels.VMs
{
    public class EmailVm
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Text { get; set; }

        public int TeacherID { get; set; }

        public int ParentID { get; set; }
    }
}
