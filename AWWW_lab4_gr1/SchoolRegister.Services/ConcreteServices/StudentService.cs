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
    private readonly UserManager<User> _userManager; 
    public StudentService(ApplicationDbContext dbContext, IMapper mapper, ILogger logger, UserManager<User> userManager) : base(dbContext, mapper, logger)
    {
        _userManager = userManager;
    }

    public StudentVm GetStudent(Expression<Func<Student, bool>> filterPredicate)
    {
        try {
            var studentEntity = DbContext.Students.FirstOrDefault(filterPredicate); 
            var studentVm = Mapper.Map<StudentVm>(studentEntity); 

            return studentVm; 

        } catch(Exception ex){
            Logger.LogError(ex, ex.Message); 
            throw; 
        }
    }

    public IEnumerable<StudentVm> GetStudents(Expression<Func<Student, bool>> filterPredicate = null)
    {
        try {
            var studentQuery = DbContext.Students.AsQueryable(); 
            if(filterPredicate != null){
                studentQuery = studentQuery.Where(filterPredicate); 
            }
            var studentVms = Mapper.Map<IEnumerable<StudentVm>>(studentQuery); 
            return studentVms; 
        } catch (Exception ex){
            Logger.LogError(ex, ex.Message); 
            throw; 
        }
    }
}