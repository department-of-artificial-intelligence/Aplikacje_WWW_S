using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SchoolRegister.DAL.EF;
using SchoolRegister.Model.DataModels;
using SchoolRegister.Services.Interfaces;
using SchoolRegister.ViewModels.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Identity;
namespace SchoolRegister.Services.ConcreteServices
{
    
    public class TeacherService : BaseService, ITeacherService
    {
        protected UserManager<User> _userManager;
        public TeacherService(AppDbContext dbContext, IMapper mapper, ILogger logger, UserManager<User> user) : base(dbContext, mapper, logger) { _userManager = user;}
        public TeacherVm AddOrUpdateTeacher(AddOrUpdateTeacherVm addOrUpdateVm)
        {
            try
            {
                if (addOrUpdateVm == null)
                    throw new ArgumentNullException($"View model parameter is null");
                var TeacherEntity = Mapper.Map<Teacher>(addOrUpdateVm);
                if (!addOrUpdateVm.Id.HasValue || addOrUpdateVm.Id == 0)
                    DbContext.Users.Add(TeacherEntity);
                else
                    DbContext.Users.Update(TeacherEntity);
                DbContext.SaveChanges();
                var TeacherVm = Mapper.Map<TeacherVm>(TeacherEntity);
                return TeacherVm;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw;
            }
        }
        public TeacherVm GetTeacher(Expression<Func<Teacher, bool>> filterExpression)
        {
            try
            {
                if (filterExpression == null)
                    throw new ArgumentNullException($" FilterExpression is null");
                var TeacherEntity = DbContext.Users.OfType<Teacher>().FirstOrDefault(filterExpression);
                var TeacherVm = Mapper.Map<TeacherVm>(TeacherEntity);
                return TeacherVm;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw;
            }
        }
        public IEnumerable<TeacherVm> GetTeachers(Expression<Func<Teacher, bool>>? filterExpression = null)
        {
            try
            {
                var TeacherEntities = DbContext.Users.OfType<Teacher>().AsQueryable();
                if (filterExpression != null)
                    TeacherEntities = TeacherEntities.Where(filterExpression);
                var TeacherVms = Mapper.Map<IEnumerable<TeacherVm>>(TeacherEntities);
                return TeacherVms;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw;
            }
        }
        public IEnumerable<GroupVm> GetTeachersGroups(TeachersGroupsVm getTeachersGroup) {
            try
            {
                var teacher = DbContext.Users.OfType<Teacher>().FirstOrDefault(x=>x.Id== getTeachersGroup.TeacherId);
                var subjects = DbContext.Subjects.AsQueryable();
                var subjectTeachers = subjects.Where(x=>x.TeacherId == teacher.Id);
                var groupEntites = subjectTeachers.SelectMany(g=>g.SubjectGroups).Select(g=>g.Group);

                var GroupVms = Mapper.Map<IEnumerable<GroupVm>>(groupEntites);
                return GroupVms;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw;
            }
        }
    }

}