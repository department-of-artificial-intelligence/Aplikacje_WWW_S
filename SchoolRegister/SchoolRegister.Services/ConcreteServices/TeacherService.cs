using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SchoolRegister.DAL.EF;
using SchoolRegister.Model.DataModels;
using SchoolRegister.Services.Interfaces;
using SchoolRegister.ViewModels.VM;

namespace SchoolRegister.Services.ConcreteServices
{
    public class TeacherService : BaseService, ITeacherService
    {
        protected UserManager<User> _userManager;

        public TeacherService(
            ApplicationDbContext dbContext,
            IMapper mapper,
            ILogger logger,
            UserManager<User> userManager
        )
            : base(dbContext, mapper, logger)
        {
            _userManager = userManager;
        }

        public TeacherVm GetTeacher(Expression<Func<Teacher, bool>> filterPredicate)
        {
            try
            {
                if (filterPredicate == null)
                    throw new ArgumentNullException($" FilterExpression is null");
                var teacherEntity = DbContext
                    .Users.OfType<Teacher>()
                    .FirstOrDefault(filterPredicate);
                var teacherVm = Mapper.Map<TeacherVm>(teacherEntity);
                return teacherVm;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw;
            }
        }

        public IEnumerable<TeacherVm> GetTeachers(
            Expression<Func<Teacher, bool>> filterPredicate = null
        )
        {
            try
            {
                var teachersEntities = DbContext.Users.OfType<Teacher>().AsQueryable();
                if (filterPredicate != null)
                    teachersEntities = teachersEntities.Where(filterPredicate);
                var teachersVms = Mapper.Map<IEnumerable<TeacherVm>>(teachersEntities);
                return teachersVms;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw;
            }
        }

        public IEnumerable<GroupVm> GetTeachersGroups(TeacherGroupsVm getTeachersGroups)
        {
            try
            {
                // Selektujesz teachera -> SelectMany na subject -> Wyciągasz z nich grupy
                // https://cezarywalenciuk.pl/blog/programing/wszystko-o-selectmany-w-linq-w-c
                var teacherEntity = DbContext
                    .Users.OfType<Teacher>()
                    .FirstOrDefault(x => x.Id == getTeachersGroups.TeacherId);
                //var subs = DbContext.Subjects.SelectMany(s => s.Subjects).Where(x => x.TeacherId == teacherEntity.Id).SelectMany(s => s.SubjectId);

                var groupEntities = teacherEntity
                    .Subjects.SelectMany(s => s.SubjectGroups)
                    .Select(g => g.Group);

                var groupVms = Mapper.Map<IEnumerable<GroupVm>>(groupEntities);
                return groupVms;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw;
            }
        }
    }
}