using SchoolRegister.Model.DataModels;
using SchoolRegister.ViewModels.VM;

namespace SchoolRegister.ViewModels.VM;
public class GradesReportVm
{
  public int StudentId { get; set; }
  public IList<Grade> Grades { get; set; }
}