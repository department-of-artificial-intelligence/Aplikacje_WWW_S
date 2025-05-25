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
    public class GradeService : BaseService, IGradeService
    {
        protected UserManager<User> _userManager;
        public GradeService(AppDbContext dbContext, IMapper mapper, ILogger logger, UserManager<User> user) : base(dbContext, mapper, logger) { _userManager = user;}
        
        public GradeVm AddGradeToStudent(AddGradeToStudentVm addGradeToStudentVm) {
            try
            {
                if (addGradeToStudentVm == null)
                    throw new ArgumentNullException($"View model parameter is null");
                var GradeEntity = Mapper.Map<Grade>(addGradeToStudentVm);
                if (!addGradeToStudentVm.Id.HasValue || addGradeToStudentVm.Id == 0)
                    DbContext.Grades.Add(GradeEntity);
                DbContext.SaveChanges();
                var GradeVm = Mapper.Map<GradeVm>(GradeEntity);
                return GradeVm;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw;
            }
        } 

        public GradesReportVm GetGradesReportForStudent(GetGradesReportVm getGradesVm) {
            try
            {
                if (getGradesVm == null)
                    throw new ArgumentNullException($" FilterExpression is null");
                var gradeEntities = DbContext.Grades
                    .Where(g => g.StudentId == getGradesVm.StudentId)
                    .ToList();

                var gradeVms = Mapper.Map<List<GradeVm>>(gradeEntities);
                
                var gradeVm = new GradesReportVm
                {
                    StudentId = getGradesVm.StudentId,
                    Grades = gradeVms
                };
                return gradeVm;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw;
            }
        }
        
        /*public GradeVm AddOrUpdateGrade(AddOrUpdateGradeVm addOrUpdateVm)
        {
            try
            {
                if (addOrUpdateVm == null)
                    throw new ArgumentNullException($"View model parameter is null");
                var GradeEntity = Mapper.Map<Grade>(addOrUpdateVm);
                if (!addOrUpdateVm.Id.HasValue || addOrUpdateVm.Id == 0)
                    DbContext.Grades.Add(GradeEntity);
                else
                    DbContext.Grades.Update(GradeEntity);
                DbContext.SaveChanges();
                var GradeVm = Mapper.Map<GradeVm>(GradeEntity);
                return GradeVm;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw;
            }
        }
        public GradeVm GetGrade(Expression<Func<Grade, bool>> filterExpression)
        {
            try
            {
                if (filterExpression == null)
                    throw new ArgumentNullException($" FilterExpression is null");
                var GradeEntity = DbContext.Grades.FirstOrDefault(filterExpression);
                var GradeVm = Mapper.Map<GradeVm>(GradeEntity);
                return GradeVm;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw;
            }
        }
        public IEnumerable<GradeVm> GetGrades(Expression<Func<Grade, bool>> filterExpression = null)
        {
            try
            {
                var GradeEntities = DbContext.Grades.AsQueryable();
                if (filterExpression != null)
                    GradeEntities = GradeEntities.Where(filterExpression);
                var GradeVms = Mapper.Map<IEnumerable<GradeVm>>(GradeEntities);
                return GradeVms;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw;
            }
        }*/
    }
}