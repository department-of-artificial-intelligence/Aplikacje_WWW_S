using SchoolRegister.Services.ConcreteServices;
using SchoolRegister.ViewModels.VM; 

namespace SchoolRegister.Services.Interfaces; 

public interface IGradeService {
    public Task<GradeVm> AddGradeToStudent(AddGradeToStudentVm addGradeToStudentVm); 
    public Task<GradesReportVm> GetGradesReportForStudent(GetGradesReportVm getGradesVm); 
}
