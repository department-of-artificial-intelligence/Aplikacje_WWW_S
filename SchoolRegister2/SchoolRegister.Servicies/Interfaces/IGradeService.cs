using SchoolRegister.ViewModels.VM;

namespace SchoolRegister.Servicies.Interfaces
{
    public interface IGradeService
    {
        Task<GradeVm> AddGradeToStudent(AddGradeToStudentVm addGradeToStudentVm);
        Task<GradesReportVm> GetGradesReportForStudent(GetGradesReportVm getGradesVm);
    }
}
