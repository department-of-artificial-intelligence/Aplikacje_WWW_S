using System.Linq.Expressions;
using AutoMapper;
using Microsoft.Extensions.Logging;
using SchoolRegister.DAL.EF;
using SchoolRegister.Model.DataModels;
using SchoolRegister.Services.Interfaces;
using SchoolRegister.ViewModels.VM;

namespace SchoolRegister.Services.ConcreteServices;
public class StudentService : BaseService, IStudentService
{
    public StudentService(ApplicationDbContext dbContext, ILogger logger, IMapper mapper) : base(dbContext, logger, mapper)
    {
    }

    public StudentVm GetStudent(Expression<Func<Student, bool>> filterPredicate)
    {
        if(filterPredicate == null)
            throw new ArgumentNullException("filterPredicate is null");
        
        var student = DbContext.Users.OfType<Student>().FirstOrDefault(filterPredicate);
        var  studentVm = Mapper.Map<StudentVm>(student);
        return studentVm;
    }

    public IEnumerable<StudentVm> GetStudents(Expression<Func<Student, bool>>? filterPredicate = null)
    {
        var students = DbContext.Users.OfType<Student>().AsQueryable();
        if(filterPredicate != null)
            students = students.Where(filterPredicate);
        
        var studentVms = Mapper.Map<IEnumerable<StudentVm>>(students);
        return studentVms;
    }
}