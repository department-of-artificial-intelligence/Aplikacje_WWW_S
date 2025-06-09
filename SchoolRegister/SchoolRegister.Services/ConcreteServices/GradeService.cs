using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Identity.Client;
using SchoolRegister.DAL.EF;
using SchoolRegister.Model.DataModels;
using SchoolRegister.Services.Interfaces;
using SchoolRegister.ViewModels.VM;
using Microsoft.EntityFrameworkCore;

namespace SchoolRegister.Services.ConcreteServices;

public class GradeService : BaseService, IGradeService
{
    protected readonly UserManager<User> UserManager;

    public GradeService(ApplicationDbContext dbContext, ILogger logger, IMapper mapper, UserManager<User> userManager) : base(dbContext, logger, mapper)
    {
        UserManager = userManager;
    }

    public async Task<GradeVm> AddGradeToStudent(AddGradeToStudentVm addGradeToStudentVm)
    {
        try
        {
            if (addGradeToStudentVm == null)
                throw new ArgumentNullException("addGradeToStudentVm is null");
            var teacher = await DbContext.Users.OfType<Teacher>()
                .FirstOrDefaultAsync(t => t.Id == addGradeToStudentVm.TeacherId);
            if (teacher == null)
                throw new InvalidOperationException("addGradeToStudentVm.teacher is null");

            bool isTeacher = await UserManager.IsInRoleAsync(teacher, "Teacher");

            if (!isTeacher)
                throw new ArgumentException("User is not in the 'Teacher' role");

            var grade = Mapper.Map<Grade>(addGradeToStudentVm);
            DbContext.Grades.Add(grade);
            await DbContext.SaveChangesAsync();

            var gradeVm = Mapper.Map<GradeVm>(grade);
            return gradeVm;
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, "Błąd na etapie save changes {message}", ex.Message);
            throw;
        }
    }

    public async Task<GradesReportVm> GetGradesReportForStudent(GetGradesReportVm getGradesVm)
    {
        if (getGradesVm == null)
            throw new ArgumentNullException("getGradesVm in null");

        var user = await DbContext.Users
        .FirstOrDefaultAsync(u => u.Id == getGradesVm.GetterUserId);
        if (user == null)
            throw new InvalidOperationException($"User with Id {getGradesVm.GetterUserId} is null");

        var student = await DbContext.Users.OfType<Student>()
            .FirstOrDefaultAsync(s => s.Id == getGradesVm.StudentId);
        if (student == null)
            throw new InvalidOperationException($"Student with Id {getGradesVm.StudentId} is null");

        var roles = await UserManager.GetRolesAsync(user);

        bool isTeacher = roles.Contains("Teacher");
        bool isStudent = roles.Contains("Student");
        bool isParent = roles.Contains("Parent");
        bool isAdmin = roles.Contains("Admin");

        if (!(isAdmin || isTeacher || (isStudent && getGradesVm.GetterUserId == getGradesVm.StudentId) || (isParent && student.ParentId == getGradesVm.GetterUserId)))
            throw new UnauthorizedAccessException($"User with Id {getGradesVm.GetterUserId} has no access to grades of student with Id {getGradesVm.StudentId}");

        var grades = await DbContext.Grades
            .Where(s => s.StudentId == getGradesVm.StudentId)
            .ToListAsync();

        var gradesVm = Mapper.Map<IList<GradeVm>>(grades);
        var gradesReportVm = new GradesReportVm()
        {
            StudentName = $"{student.FirstName} {student.LastName}",
            Grades = gradesVm
        };
        return gradesReportVm;
    }   
}