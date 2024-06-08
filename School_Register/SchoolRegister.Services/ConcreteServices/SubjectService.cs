using System.Linq.Expressions;
using AutoMapper;
using Microsoft.Extensions.Logging;
using SchoolRegister.DAL.EF;
using SchoolRegister.Model.DataModels;
using SchoolRegister.Services.Interfaces;
using SchoolRegister.ViewModels.VM;

namespace SchoolRegister.Services.ConcreteServices;

public class SubjectService : BaseService, ISubjectService
{
    public SubjectService(ApplicationDbContext dbContext, IMapper mapper, ILogger logger) : base(dbContext, mapper, logger)
    {
    
    }

    public SubjectVm AddOrUpdateSubject(AddOrUpdateSubjectVm addOrUpdateSubjectVm)
    {
        try {
            if(addOrUpdateSubjectVm == null){
                throw new ArgumentNullException($"View model parameter is null"); 
            }
            var subjectEntity = Mapper.Map<Subject>(addOrUpdateSubjectVm); 

            if(!addOrUpdateSubjectVm.Id.HasValue || addOrUpdateSubjectVm.Id == 0){
                DbContext.Subjects.Add(subjectEntity); 
            } else {
                DbContext.Subjects.Update(subjectEntity); 
            }
            
            DbContext.SaveChanges(); 
            var subjectVm = Mapper.Map<SubjectVm>(subjectEntity); 
            return subjectVm; 

        } catch (Exception ex) {
            Logger.LogError(ex, ex.Message); 
            throw; 
        }

    }


    public SubjectVm GetSubject(Expression<Func<Subject, bool>> fitlerExpression) 
    {
        try {
            if(fitlerExpression == null) {
                throw new ArgumentNullException($"FilterExpression is null"); 
            }
            var subjectEntity = DbContext.Subjects.FirstOrDefault(fitlerExpression); 
            var subjectVm = Mapper.Map<SubjectVm>(subjectEntity); 
            return subjectVm; 
        } catch (Exception ex) {
            Logger.LogError(ex, ex.Message); 
            throw; 
        }
    }

    public IEnumerable<SubjectVm> GetSubjects(Expression<Func<Subject, bool>>? filterExpression = null)
    {
        try {
            var subjectEntities = DbContext.Subjects.AsQueryable(); 
            if(filterExpression != null) {
                subjectEntities = subjectEntities.Where(filterExpression); 
            }
            var subjectVms = Mapper.Map<IEnumerable<SubjectVm>>(subjectEntities); 
            return subjectVms;  

        } catch (Exception ex) {
            Logger.LogError(ex, ex.Message); 
            throw; 
        }
    }
}