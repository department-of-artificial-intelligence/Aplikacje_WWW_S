using System.Linq.Expressions;
using AutoMapper;
using Microsoft.Extensions.Logging;
using SchoolRegister.DAL.EF;
using SchoolRegister.Model.DataModels;
using SchoolRegister.Services.Interfaces;
using SchoolRegister.ViewModels.VM;
using Microsoft.AspNetCore.Identity;

namespace SchoolRegister.Services.ConcreteServices;

public class SubjectService : BaseService, ISubjectService
{

    private readonly UserManager<User> UserManager;

    public SubjectService(ApplicationDbContext dbContext, ILogger logger, IMapper mapper, UserManager<User> userManager) : base(dbContext, logger, mapper)
    {
        UserManager = userManager;
    }

    public SubjectVm AddOrUpdateSubject(AddOrUpdateSubjectVm addOrUpdateVm)
    {
        try
        {
            if(addOrUpdateVm == null)
                throw new ArgumentNullException($"View model parametr is null");
            
            var subjectEntity = Mapper.Map<Subject>(addOrUpdateVm);

            if(!addOrUpdateVm.Id.HasValue || addOrUpdateVm.Id == 0)
                DbContext.Subjects.Add(subjectEntity);
            else
                DbContext.Subjects.Update(subjectEntity);
            DbContext.SaveChanges();

            var subjectVm = Mapper.Map<SubjectVm>(subjectEntity);
            return subjectVm;
        }catch(Exception ex)
        {
            Logger.LogError(ex, ex.Message);
            throw;
        }
    }

    public SubjectVm GetSubject(Expression<Func<Subject, bool>> filterExpression)
    {
        try
        {
            if(filterExpression == null)
                throw new ArgumentNullException($"Filter expression is null");
            var subjectEntity = DbContext.Subjects.FirstOrDefault(filterExpression);
            var subjectVm = Mapper.Map<SubjectVm>(subjectEntity);
            return subjectVm;
        }catch(Exception ex)
        {
            Logger.LogError(ex, ex.Message);
            throw;
        }
    }

    public IEnumerable<SubjectVm> GetSubjects(Expression<Func<Subject, bool>>? filterExpression = null)
    {
        try
        {
            var subjectEntites = DbContext.Subjects.AsQueryable();
            if(filterExpression != null)
                subjectEntites = subjectEntites.Where(filterExpression);
            var subjectVms = Mapper.Map<IEnumerable<SubjectVm>>(subjectEntites);
            return subjectVms;
        }catch(Exception ex)
        {
            Logger.LogError(ex, ex.Message);
            throw;
        }
    }
}