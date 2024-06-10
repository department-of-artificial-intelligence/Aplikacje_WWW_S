using SchoolRegister.ViewModels.VM;

namespace SchoolRegister.Servicies.Interfaces
{
    public interface IGradeService
    {
        Task<GradeVm> AddGradeToStudentAsync(AddGradeToStudentVm addGradeToStudentVm);
        Task<GradesReportVm> GetGradesReportForStudentAsync(GetGradesReportVm getGradesVm);
    }
}
