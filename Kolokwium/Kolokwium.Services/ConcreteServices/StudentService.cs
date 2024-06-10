using System.Linq.Expressions;
using AutoMapper;
using Kolokwium.DAL;
using Kolokwium.Model.DataModels;
using Kolokwium.Services.Interfaces;
using Kolokwium.ViewModel.VM;
using Microsoft.Extensions.Logging;

namespace Kolokwium.Services.ConcreteServices;

public class StudentService : BaseService, IStudentService
{
    public StudentService(ApplicationDbContext dbContext, IMapper mapper, ILogger logger) : base(dbContext, mapper, logger)
    {
    }

    public StudentVm AddOrUpdateStudent(AddOrUpdateStudentVm addOrUpdateStudentVm)
    {
        try {
            if(addOrUpdateStudentVm == null) throw new ArgumentNullException(); 

            var studentEntity = Mapper.Map<Student>(addOrUpdateStudentVm); 
            if(!addOrUpdateStudentVm.Id.HasValue || addOrUpdateStudentVm.Id == 0){
                DbContext.Students.Add(studentEntity); 
            } else {
                var studentToEdit = DbContext.Students.Find(addOrUpdateStudentVm.Id); 
                if(studentToEdit!= null){
                    studentToEdit.FirstName = addOrUpdateStudentVm.FirstName; 
                    studentToEdit.LastName = addOrUpdateStudentVm.LastName; 
                    studentToEdit.Grades = addOrUpdateStudentVm.Grades; 
                } 
            }
            DbContext.SaveChanges(); 

            var studentVm = Mapper.Map<StudentVm>(studentEntity); 
            return studentVm; 

        } catch(Exception ex){
            Logger.LogError(ex, ex.Message); 
            throw; 
        }
    }

    public void DeleteStudent(int id)
    {
        throw new NotImplementedException();
    }

    public StudentVm GetStudent(Expression<Func<Student, bool>> predicate)
    {
        try {
            var studentEntity = DbContext.Students.FirstOrDefault(predicate); 
            var studentVm = Mapper.Map<StudentVm>(studentEntity); 
            return studentVm; 
        } catch(Exception ex){
            Logger.LogError(ex, ex.Message); 
            throw; 
        }
    }

    public IEnumerable<StudentVm> GetStudents(Expression<Func<Student, bool>>? predicate = null)
    {
        try {
            var studentQuery = DbContext.Students.AsQueryable();
            if(predicate != null){
                studentQuery = studentQuery.Where(predicate); 
            }

            var studentVms = Mapper.Map<IEnumerable<StudentVm>>(studentQuery); 

            return studentVms; 
        }catch (Exception ex){
            Logger.LogError(ex, ex.Message); 
            throw; 
        }
    }


}