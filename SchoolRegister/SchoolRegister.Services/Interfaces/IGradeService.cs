using System.Linq.Expressions;
using SchoolRegister.Model.DataModels;
using SchoolRegister.ViewModels.VM;

namespace SchoolRegister.Services.Interfaces
{
public interface IGradeService
{
    GradeVm AddGradeToStudent(AddGradeToStudentVm addGradeToStudentVm);
    GradesReportVm GetGradesReportForStudent(GetGradesReportVm getGradesVm);
}
}