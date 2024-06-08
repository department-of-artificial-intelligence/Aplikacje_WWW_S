using SchoolRegister.Services.ConcreteServices;
using SchoolRegister.ViewModels.VM; 

namespace SchoolRegister.Services.Interfaces; 

public interface IGradeService {
    public GradeVm AddGradeToStudent(AddGradeToStudentVm addGradeToStudentVm); 
    public GradesReportVm GetGradesReportForStudent(GetGradesReportVm getGradesVm); 
}
