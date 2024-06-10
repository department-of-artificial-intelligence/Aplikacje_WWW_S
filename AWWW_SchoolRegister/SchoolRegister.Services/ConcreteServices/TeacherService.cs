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

namespace SchoolRegister.Services.ConcreteServices;

public class TeacherService : BaseService, ITeacherService
{
  public TeacherService(ApplicationDbContext dbContext, IMapper mapper, ILogger logger, UserManager<User> manager) : base(dbContext, mapper, logger, manager)
  {
  }

  public TeacherVM GetTeacher(Expression<Func<Teacher, bool>> filterPredicate)
  {
    try
    {
      if (filterPredicate == null)
        throw new ArgumentNullException($" FilterExpression is null");

      var teacherEntity = DbContext.Users.OfType<Teacher>().FirstOrDefault(filterPredicate);
      var teacherVm = Mapper.Map<TeacherVM>(teacherEntity);
      return teacherVm;
    }
    catch (Exception ex)
    {
      Logger.LogError(ex, ex.Message);
      throw;
    }
  }

  public IEnumerable<TeacherVM> GetTeachers(Expression<Func<Teacher, bool>> filterPredicate = null)
  {
    try
    {
      var teachersEntities = DbContext.Users.OfType<Teacher>().AsQueryable();
      if (filterPredicate != null)
        teachersEntities = teachersEntities.Where(filterPredicate);

      var teachersVM = Mapper.Map<IEnumerable<TeacherVM>>(teachersEntities);
      return teachersVM;
    }
    catch (Exception ex)
    {
      Logger.LogError(ex, ex.Message);
      throw;
    }
  }

  public IEnumerable<GroupVm> GetTeachersGroups(TeachersGroupsVm getTeachersGroups)
  {
    try
    {

      var subjectIds = DbContext.Subjects.Where(s => s.TeacherId == getTeachersGroups.TeacherId).Select(s => s.Id).ToList();
      var teacherGroups = DbContext.SubjectGroups.Where(sg => subjectIds.Contains(sg.SubjectId)).Select(sg => sg.Group).ToList();

      var teacherGroupsVm = Mapper.Map<IEnumerable<GroupVm>>(teacherGroups);
      return teacherGroupsVm;

    }
    catch (Exception ex)
    {
      Logger.LogError(ex, ex.Message);
      throw;
    }
  }
}