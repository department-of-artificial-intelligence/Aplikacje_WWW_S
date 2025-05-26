using System.ComponentModel.DataAnnotations;

namespace SchoolRegister.ViewModels.VM;

public class AddGradeToStudentVm
{
    public int GradeId { get; set; }
    public int StudentId { get; set; }
}
