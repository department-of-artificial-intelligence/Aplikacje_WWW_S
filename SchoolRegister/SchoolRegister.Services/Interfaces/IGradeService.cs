using SchoolRegister.ViewModels.VM;
namespace SchoolRegister.Services.Interfaces;

public interface IGradeService
{
    Task<GradeVm> AddGradeToStudent(AddGradeToStudentVm addGradeToStudentVm);
    Task<GradesReportVm> GetGradesReportForStudent(GetGradesReportVm getGradesVm);
}