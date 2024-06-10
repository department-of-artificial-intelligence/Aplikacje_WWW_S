using SchoolRegister.Model.DataModels;

namespace SchoolRegister.ViewModels.VM
{
    public class GradeVm
    {
        public DateTime DateOfIssue { get; set; }
        public GradeScale GradeValue { get; set; }
        public SubjectVm Subject { get; set; } = null!;
        public StudentVm Student { get; set; } = null!;
    }
}
