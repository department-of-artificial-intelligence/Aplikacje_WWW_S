using System.ComponentModel.DataAnnotations;

namespace SchoolRegister.ViewModels.VM;

public class GradesReportVm
{
    public IList<GradeVm> Grades { get; set; }
}