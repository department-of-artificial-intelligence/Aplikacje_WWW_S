// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Linq.Expressions;
// using AutoMapper;
// using Microsoft.EntityFrameworkCore;
// using Microsoft.Extensions.Logging;
// using SchoolRegister.DAL.EF;
// using SchoolRegister.Model.DataModels;
// using SchoolRegister.Services.Interfaces;
// using SchoolRegister.ViewModels.VM;
// namespace SchoolRegister.Services.ConcreteServices
// {
//     public class StudentService : BaseService, IStudentService
//     {
//         public StudentService(ApplicationDbContext dbContext, IMapper mapper, ILogger logger) : base(dbContext, mapper, logger) { }
//         public StudentVm GetStudent(Expression<Func<Student, bool>> filterPredicate)
//         {
//              try
//             {
//                 if (filterExpression == null)
//                     throw new ArgumentNullException($" FilterExpression is null");
//                 var studenyEntity = DbContext.Students.FirstOrDefault(filterExpression);
//                 var studentVm = Mapper.Map<StudentVm>(teacherEntity);
//                 return studentVm;
//             }
//             catch (Exception ex)
//             {
//                 Logger.LogError(ex, ex.Message);
//                 throw;
//             }
//         }

//         public IEnumerable<StudentVm> GetStudents(Expression<Func<Student, bool>> filterPredicate = null) {
//             try
//             {
//                 var studentsEntities = DbContext.Students.AsQueryable();
//                 if (filterPredicate != null)
//                     studentsEntities = studentsEntities.Where(filterPredicate);
//                 var studentsVms = Mapper.Map<IEnumerable<studentsVms>>(studentsVms);
//                 return studentVms;
//             }
//             catch (Exception ex)
//             {
//                 Logger.LogError(ex, ex.Message);
//                 throw;
//             }
//         }
        

//     }
// }