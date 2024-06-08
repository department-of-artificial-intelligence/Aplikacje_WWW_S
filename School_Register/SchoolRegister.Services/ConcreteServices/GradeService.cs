
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using SchoolRegister.DAL.EF;
using SchoolRegister.Model.DataModels;
using SchoolRegister.Services.ConcreteServices;
using SchoolRegister.ViewModels.VM;

namespace SchoolRegister.Services.Interfaces;

public class GradeService : BaseService, IGradeService
{
    private readonly UserManager<User> _userManager; 
    public GradeService(ApplicationDbContext dbContext, IMapper mapper, ILogger logger, UserManager<User> userManager) : base(dbContext, mapper, logger)
    {
        _userManager = userManager; 
    }

    public GradeVm AddGradeToStudent(AddGradeToStudentVm addGradeToStudentVm)
    {
        try {
            if(addGradeToStudentVm != null) throw new ArgumentNullException(); 

            var teacher = DbContext.Users.OfType<Teacher>().FirstOrDefault(t => t.Id == addGradeToStudentVm.TeacherId); 
            if(teacher.IsInRoleAsync(teacher, "Teacher")); 

        } catch (Exception ex){
            Logger.LogError(ex, ex.Message); 
            throw; 
        }
    }

    public GradesReportVm GetGradesReportForStudent(GetGradesReportVm getGradesVm)
    {
        throw new NotImplementedException();
    }
}