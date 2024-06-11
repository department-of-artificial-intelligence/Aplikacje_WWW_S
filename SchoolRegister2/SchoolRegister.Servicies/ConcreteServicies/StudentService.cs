using AutoMapper;
using Microsoft.Extensions.Logging;
using SchoolRegister.DAL.EF;
using SchoolRegister.Model.DataModels;
using SchoolRegister.Servicies.Interfaces;
using SchoolRegister.ViewModels.VM;
using System.Linq.Expressions;

namespace SchoolRegister.Servicies.ConcreteServicies
{
    public class StudentService : BaseService, IStudentService
    {
        public StudentService(ApplicationDbContext dbContext, IMapper mapper, ILogger logger) : base(dbContext, mapper, logger)
        {
        }

        public StudentVm GetStudent(Expression<Func<Student, bool>> filterExpression)
        {
            var student = DbContext.Users.OfType<Student>().FirstOrDefault(filterExpression);
            var studentVm = Mapper.Map<StudentVm>(student);
            return studentVm;
        }

        public IEnumerable<StudentVm> GetStudents(Expression<Func<Student, bool>>? filterExpression = null)
        {
            var students = DbContext.Users.OfType<Student>().AsQueryable();
            if (filterExpression != null)
            {
                students = students.Where(filterExpression);
            }
            var studentVms = Mapper.Map<IEnumerable<StudentVm>>(students);
            return studentVms;
        }
    }
}
