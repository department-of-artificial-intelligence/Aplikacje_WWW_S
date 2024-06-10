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
            if(addOrUpdateStudentVm == null) throw new ArgumentNullException($"{nameof(addOrUpdateStudentVm)} is null");
            Student studentEntity;
            if (addOrUpdateStudentVm.Id.HasValue && addOrUpdateStudentVm.Id > 0)
            {
                var studentEntityToEdit = DbContext.Students.FirstOrDefault(s => s.Id == addOrUpdateStudentVm.Id);
                if (studentEntityToEdit != null)
                {
                    studentEntity = Mapper.Map<AddOrUpdateStudentVm, Student>(addOrUpdateStudentVm, studentEntityToEdit);
                    DbContext.Students.Update(studentEntity);
                }
                else throw new Exception("Entity not exists");
                //var studentToEdit = DbContext.Students.Find(addOrUpdateStudentVm.Id); 
                //if(studentToEdit!= null){
                //    studentToEdit.FirstName = addOrUpdateStudentVm.FirstName; 
                //    studentToEdit.LastName = addOrUpdateStudentVm.LastName; 
                //    studentToEdit.Grades = addOrUpdateStudentVm.Grades; 
                //} 
            }
            else {
                studentEntity = Mapper.Map<Student>(addOrUpdateStudentVm);
                DbContext.Students.Add(studentEntity);
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