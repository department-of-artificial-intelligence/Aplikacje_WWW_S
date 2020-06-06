using AutoMapper;
using Microsoft.AspNetCore.Identity;
using SchoolRegister.BLL.Entities;
using SchoolRegister.DAL.EF;
using SchoolRegister.Services.Interfaces;
using SchoolRegister.ViewModels.DTOs;
using SchoolRegister.ViewModels.VMs;
using System;
using System.Linq;

namespace SchoolRegister.Services.Services
{
    public class GradeService : BaseService, IGradeService
    {
        private readonly UserManager<User> _userManager;
        public GradeService(ApplicationDbContext dbContext, UserManager<User> userManager) : base(dbContext)
        {
            _userManager = userManager;
        }

        public GradeVm AddGradeToStudent(AddGradeToStudentDto addGradeToStudentDto)
        {
            if (addGradeToStudentDto == null)
            {
                throw new ArgumentNullException($"GradingStudent Dto is null");
            }
            var teacher = _dbContext.Users.OfType<Teacher>().FirstOrDefault(t => t.Id == addGradeToStudentDto.TeacherId);
            var student = _dbContext.Users.OfType<Student>().FirstOrDefault(t => t.Id == addGradeToStudentDto.StudentId);
            var subject = _dbContext.Subjects.FirstOrDefault(s => s.Id == addGradeToStudentDto.SubjectId);
            if (teacher == null)
            {
                throw new ArgumentNullException("Teacher is null");
            }
            if (!_userManager.IsInRoleAsync(teacher, "Teacher").Result)
            {
                throw new InvalidOperationException("Given user provided as teacher is not teacher");
            }
            if (student == null)
            {
                throw new ArgumentNullException("Student is null");
            }
            if (subject == null)
            {
                throw new ArgumentNullException("Subject is null");
            }
            var gradeEntity = Mapper.Map<Grade>(addGradeToStudentDto);
            _dbContext.Grade.Add(gradeEntity);
            _dbContext.SaveChanges();
            var gradeVm = Mapper.Map<GradeVm>(gradeEntity);
            return gradeVm;
        }

        public GradesReportVm GetGradesReportForStudent(GetGradesDto getGradesDto)
        {
            if (getGradesDto == null)
            {
                throw new ArgumentNullException("Get grades dto is null");
            }
            var getterUser = _dbContext.Users.FirstOrDefault(x => x.Id == getGradesDto.GetterUserId);
            if (getterUser == null) throw new ArgumentNullException("getter user is null");
            if (!_userManager.IsInRoleAsync(getterUser, "Admin").Result &&
                !_userManager.IsInRoleAsync(getterUser, "Teacher").Result &&
                !_userManager.IsInRoleAsync(getterUser, "Student").Result &&
                !_userManager.IsInRoleAsync(getterUser, "Parent").Result)
            {
                throw new InvalidOperationException("The getter user don't have permissions to read.");
            }
            var student = _dbContext.Users.OfType<Student>().FirstOrDefault(s => s.Id == getGradesDto.StudentId);
            if (student == null) throw new InvalidOperationException("the given user is not student");
            var gradesReport = Mapper.Map<GradesReportVm>(student);
            return gradesReport;
        }
    }
}
