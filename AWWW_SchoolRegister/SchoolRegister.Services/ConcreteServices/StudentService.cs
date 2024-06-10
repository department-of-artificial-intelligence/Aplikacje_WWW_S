using System.Linq.Expressions;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using SchoolRegister.DAL.EF;
using SchoolRegister.Model.DataModels;
using SchoolRegister.Services.Interfaces;
using SchoolRegister.ViewModels.VM;

namespace SchoolRegister.Services.ConcreteServices;

public class StudentService : BaseService, IStudentService
{
  public StudentService(ApplicationDbContext dbContext, IMapper mapper, ILogger logger, UserManager<User> manager) : base(dbContext, mapper, logger, manager)
  {
  }

  public StudentVm GetStudent(Expression<Func<Student, bool>> filterPredicate)
  {
    try
    {
      if (filterPredicate == null)
        throw new ArgumentNullException("Filter is null");


      var student = DbContext.Users.OfType<Student>().FirstOrDefault(filterPredicate);
      var studentVm = Mapper.Map<StudentVm>(student);

      return studentVm;
    }
    catch (Exception ex)
    {
      Logger.LogError(ex, ex.Message);
      throw;
    }
  }

  public IEnumerable<Student> GetStudents(Expression<Func<Student, bool>> filterPredicate = null)
  {
    try
    {
      var students = DbContext.Users.OfType<Student>().AsQueryable();

      if (filterPredicate != null)
        students = students.Where(filterPredicate);

      var studentsVm = Mapper.Map<IEnumerable<StudentVm>>(students);

      return students;
    }
    catch (Exception ex)
    {
      Logger.LogError(ex, ex.Message);
      throw;
    }
  }
}