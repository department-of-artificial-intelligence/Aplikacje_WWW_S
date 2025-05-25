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
namespace SchoolRegister.Services.ConcreteServices
{
    public class StudentService : BaseService, IStudentService
    {
        public StudentService(AppDbContext dbContext, IMapper mapper, ILogger logger) : base(dbContext, mapper, logger) {}
        /*public StudentVm AddOrUpdateStudent(AddOrUpdateStudentVm addOrUpdateVm)
        {
            try
            {
                if (addOrUpdateVm == null)
                    throw new ArgumentNullException($"View model parameter is null");
                var StudentEntity = Mapper.Map<Student>(addOrUpdateVm);
                if (!addOrUpdateVm.Id.HasValue || addOrUpdateVm.Id == 0)
                    DbContext.Students.Add(StudentEntity);
                else
                    DbContext.Students.Update(StudentEntity);
                DbContext.SaveChanges();
                var StudentVm = Mapper.Map<StudentVm>(StudentEntity);
                return StudentVm;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw;
            }
        }*/
        public StudentVm GetStudent(Expression<Func<Student, bool>> filterExpression)
        {
            try
            {
                if (filterExpression == null)
                    throw new ArgumentNullException($" FilterExpression is null");
                var StudentEntity = DbContext.Students.FirstOrDefault(filterExpression);
                var StudentVm = Mapper.Map<StudentVm>(StudentEntity);
                return StudentVm;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw;
            }
        }
        public IEnumerable<StudentVm> GetStudents(Expression<Func<Student, bool>> filterExpression = null)
        {
            try
            {
                var StudentEntities = DbContext.Students.AsQueryable();
                if (filterExpression != null)
                    StudentEntities = StudentEntities.Where(filterExpression);
                var StudentVms = Mapper.Map<IEnumerable<StudentVm>>(StudentEntities);
                return StudentVms;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw;
            }
        }
    }
}