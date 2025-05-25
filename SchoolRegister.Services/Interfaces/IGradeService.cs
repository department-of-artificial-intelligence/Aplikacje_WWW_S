using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using SchoolRegister.Model.DataModels;
using SchoolRegister.ViewModels.VM;

namespace SchoolRegister.Services.Interfaces
{
    public interface IGradeService
    {
        /*GradeVm AddOrUpdateGrade(AddOrUpdateGradeVm GradeVm);
        GradeVm GetGrade(Expression<Func<Grade, bool>> filterExpression);
        IEnumerable<GradeVm> GetGrades(Expression<Func<Grade, bool>> filterExpression = null);*/

        GradeVm AddGradeToStudent(AddGradeToStudentVm addGradeToStrudentVm);
        GradesReportVm GetGradesReportForStudent(GetGradesReportVm getGradesVm);
    }
}