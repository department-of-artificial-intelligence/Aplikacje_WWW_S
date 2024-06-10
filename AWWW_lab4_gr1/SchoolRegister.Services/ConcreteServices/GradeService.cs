
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Identity.Client;
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

    public async Task<GradeVm> AddGradeToStudent(AddGradeToStudentVm addGradeToStudentVm)
    {
        try {
            if(addGradeToStudentVm == null) throw new ArgumentNullException(nameof(addGradeToStudentVm)); 

            var teacher = DbContext.Users.OfType<Teacher>().FirstOrDefault(t => t.Id == addGradeToStudentVm.TeacherId); 
            // popraw
            if (teacher == null) throw new Exception(); 

            if( await _userManager.IsInRoleAsync(teacher, "Teacher")){
                var gradeVm = addGradeToStudentVm.Grade; 
                var gradeEntity = Mapper.Map<Grade>(gradeVm); 
                DbContext.Grades.Add(gradeEntity); 
                DbContext.SaveChanges(); 
                return gradeVm; 
            } else {
                throw new UnauthorizedAccessException("User does not have sufficient permissions"); 
            }

        } catch (Exception ex){
            Logger.LogError(ex, ex.Message); 
            throw; 
        }
    }

    public async Task<GradesReportVm> GetGradesReportForStudent(GetGradesReportVm getGradesVm)
    {
        try {
            if (getGradesVm == null) throw new ArgumentNullException(); 

            var student = DbContext.Users.OfType<Student>().FirstOrDefault(s => s.Id == getGradesVm.StudentId); 

            var parent = DbContext.Parents.OfType<Parent>().FirstOrDefault(p => p.Id == getGradesVm.ParentId); 

            if(student == null) throw new Exception(); 

            if (await _userManager.IsInRoleAsync(student, "Student") || (await _userManager.IsInRoleAsync(parent, "Parent") && parent.Students.Contains(student) )) {
                var gradesEntity = student;  
                
                var gradesReportVm = Mapper.Map<GradesReportVm>(gradesEntity); 

                return gradesReportVm; 
            }   
            throw new Exception(); 

        } catch (Exception ex) {
            Logger.LogError(ex, ex.Message); 
            throw; 
        }
    }
}