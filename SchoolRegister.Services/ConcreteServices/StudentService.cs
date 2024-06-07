using System.Linq.Expressions;
using AutoMapper;
using Microsoft.Extensions.Logging;
using SchoolRegister.DAL.EF;
using SchoolRegister.Model.DataModels;
using SchoolRegister.Services.ConcreteServices;
using SchoolRegister.ViewModels.VM;

public class StudentService : BaseService, IStudentService
{
    public StudentService(ApplicationDbContext dbContext, IMapper mapper, ILogger logger) : base(dbContext, mapper, logger)
    {
    }

    public StudentVm GetStudent(Expression<Func<Student, bool>> filterExpression)
    {
        try
        {
            if (filterExpression == null)
            {
                Logger.LogError("Filter expression is null");
                return null;
            }

            var student = DbContext.Users.OfType<Student>()

                .FirstOrDefault(filterExpression);

            if (student == null)
            {
                Logger.LogWarning("Student not found");
                return null;
            }

            return Mapper.Map<StudentVm>(student);
        }
        catch (Exception e)
        {
            Logger.LogError(e, e.Message);
            return null;
        }
    }

    public IEnumerable<StudentVm> GetStudents(Expression<Func<Student, bool>> filterExpression = null)
    {
        try
        {
            var students = DbContext.Users.OfType<Student>()

                .AsQueryable();

            if (filterExpression != null)
            {
                students = students.Where(filterExpression);
            }

            return Mapper.Map<IEnumerable<StudentVm>>(students);
        }
        catch (Exception e)
        {
            Logger.LogError(e, e.Message);
            return null;
        }
    }
}