using AutoMapper;
using Microsoft.Extensions.Logging;
using SchoolRegister.DAL.EF;
using SchoolRegister.Services.ConcreteServices;
using SchoolRegister.Services.Interfaces;
using SchoolRegister.ViewModels.VM;

public class GradeService : BaseService, IGradeService
{
    public GradeService(ApplicationDbContext dbContext, IMapper mapper, ILogger logger) : base(dbContext, mapper, logger)
    {
    }

    public GradeVm AddGradeToStudent(AddGradeToStudentVm addGradeToStudentVm)
    {

        try
        {
            if (addGradeToStudentVm == null)
                throw new ArgumentNullException($"View model parameter is null");
            var gradeEntity = Mapper.Map<Grade>(addGradeToStudentVm);
            DbContext.Grades.Add(gradeEntity);
            DbContext.SaveChanges();
            var gradeVm = Mapper.Map<GradeVm>(gradeEntity);
            return gradeVm;
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, ex.Message);
            throw;
        }
    }

    public GradesReportVm GetGradesReportForStudent(GetGradesReportVm getGradesReportVm)
    {

        try
        {
            if (getGradesReportVm == null)
                throw new ArgumentNullException($"View model parameter is null");

            var grades = DbContext.Grades
                .Where(g => g.StudentId == getGradesReportVm.StudentId)


                .ToList();

            var gradesReport = new GradesReportVm
            {
                Grades = Mapper.Map<IEnumerable<GradeVm>>(grades)
            };

            return gradesReport;
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, ex.Message);
            throw;
        }
    }
}