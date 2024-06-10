
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using SchoolRegister.DAL.EF;
using SchoolRegister.Model.DataModels;
using SchoolRegister.Services.ConcreteServices;
using SchoolRegister.Services.Interfaces;
using SchoolRegister.ViewModels.VM;

public class GradeService : BaseService, IGradeService
{
  public GradeService(ApplicationDbContext dbContext, IMapper mapper, ILogger logger, UserManager<User> manager) : base(dbContext, mapper, logger, manager)
  {
  }

  public GradeVm AddGradeToStudent(AddGradeToStudentVm addGradeToStudentVm)
  {
    try
    {
      var grade = Mapper.Map<Grade>(addGradeToStudentVm);
      grade.DateOfIssue = DateTime.Now;

      DbContext.Grades.Add(grade);
      DbContext.SaveChanges();

      var gradeVm = Mapper.Map<GradeVm>(grade);
      return gradeVm;

    }
    catch (Exception ex)
    {
      Logger.LogError(ex, ex.Message);
      throw;
    }
  }

  public GradesReportVm GetGradesReportForStudent(GetGradesReportVm getGradesVm)
  {
    try
    {
      var user = DbContext.Users.FirstOrDefault(u => u.Id == getGradesVm.GetterUserId);
      if (user != null && UserManager.IsInRoleAsync(user, "Teacher").Result && user is Teacher)
      {
        var grades = DbContext.Grades.Where(g => g.StudentId == getGradesVm.StudentId);
        var gradesReport = new GradesReportVm
        {
          StudentId = getGradesVm.StudentId,
          Grades = grades.ToList()
        };

        return gradesReport;
      }
      throw new Exception("");
    }
    catch (Exception ex)
    {
      Logger.LogError(ex, ex.Message);
      throw;
    }
  }
}