using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Logging;
using SchoolRegister.DAL.EF;
using SchoolRegister.Model.DataModels;
using SchoolRegister.Services.Interfaces;
using SchoolRegister.ViewModels.VM;

namespace SchoolRegister.Services.ConcreteServices
{
    public class StudentService : BaseService, IStudentService
    {
        public StudentService(ApplicationDbContext dbContext, IMapper mapper, ILogger logger) : base(dbContext, mapper, logger) { }
        public StudentVm GetStudent(Expression<Func<Student, bool>> predicate)
        {
            try
            {
                if (predicate == null)
                    throw new ArgumentNullException($" predicate is null");
                var studentEntity = DbContext.Users.OfType<Student>().FirstOrDefault(predicate);
                var studentVm = Mapper.Map<StudentVm>(studentEntity);
                return studentVm;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw;
            }
        }

        public IEnumerable<StudentVm> GetStudents(Expression<Func<Student, bool>>? predicate = null)
        {
            try
            {
                var studentEntities = DbContext.Users.OfType<Student>().AsQueryable();
                if (predicate != null)
                {
                    studentEntities = studentEntities.Where(predicate);
                }
                var studentVms = Mapper.Map<IEnumerable<StudentVm>>(studentEntities);
                return studentVms;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw;
            }
        }
    }
}
