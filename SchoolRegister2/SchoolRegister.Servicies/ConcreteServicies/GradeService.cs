using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using SchoolRegister.DAL.EF;
using SchoolRegister.Model.DataModels;
using SchoolRegister.Servicies.Interfaces;
using SchoolRegister.ViewModels.VM;

namespace SchoolRegister.Servicies.ConcreteServicies
{
    public class GradeService : BaseService, IGradeService
    {
        private readonly UserManager<User> _userManager;
        public GradeService(ApplicationDbContext dbContext, IMapper mapper, ILogger logger, UserManager<User> userManager)
            : base(dbContext, mapper, logger)
        {
            _userManager = userManager;
        }

        public async Task<GradeVm> AddGradeToStudent(AddGradeToStudentVm addGradeToStudentVm)
        {
            var user = DbContext.Users
                .FirstOrDefault(u => u.Id == addGradeToStudentVm.TeacherId);

            if (user == null
                || !await _userManager.IsInRoleAsync(user, nameof(RoleValue.Teacher)))
            {
                throw new InvalidOperationException("User is not a teacher!");
            }

            var teacher = DbContext.Users.OfType<Teacher>().FirstOrDefault(t => t.Id == addGradeToStudentVm.TeacherId);
            if (teacher == null)
            {
                throw new InvalidOperationException("Teacher not found");
            }

            var grade = new Grade
            {
                DateOfIssue = DateTime.UtcNow,
                GradeValue = addGradeToStudentVm.GradeValue,
                SubjectId = addGradeToStudentVm.SubjectId,
                StudentId = addGradeToStudentVm.StudentId
            };

            DbContext.Add(grade);
            await DbContext.SaveChangesAsync();

            var gradeVm = Mapper.Map<GradeVm>(grade);
            return gradeVm;
        }

        public async Task<GradesReportVm> GetGradesReportForStudent(GetGradesReportVm getGradesVm)
        {
            var user = DbContext.Users.FirstOrDefault(u => u.Id == getGradesVm.GetterUserId);

            if (user == null
               || !(await _userManager.IsInRoleAsync(user, nameof(RoleValue.Parent))
                    || await _userManager.IsInRoleAsync(user, nameof(RoleValue.Student))
                    )
               )
            {
                throw new InvalidOperationException("User is not a parent or student!");
            }

            var student = DbContext.Users.OfType<Student>()
                .FirstOrDefault(s => s.Id == getGradesVm.StudentId);
            if (student == null)
            {
                throw new InvalidOperationException("Student does not exists");
            }

            var gradeReportVm = Mapper.Map<GradesReportVm>(student);
            return gradeReportVm;
        }
    }
}
