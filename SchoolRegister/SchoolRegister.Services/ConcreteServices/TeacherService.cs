using SchoolRegister.Services.Interfaces;
using AutoMapper;
using SchoolRegister.Services.ConcreteServices;
using SchoolRegister.DAL.EF;
using Microsoft.Extensions.Logging;
using SchoolRegister.ViewModels.VM;
using System.Linq.Expressions;
using SchoolRegister.Model.DataModels;

public class TeacherService : BaseService, ITeacherService
{
    public TeacherService(ApplicationDbContext dbContext, ILogger logger, IMapper mapper) : base(dbContext, logger, mapper)
    {
    }

    public TeacherVm GetTeacher(Expression<Func<Teacher, bool>> filterPredicate)
    {
        if(filterPredicate == null)
            throw new ArgumentNullException("Filter predicate is null");

        var teacher = DbContext.Users.OfType<Teacher>().FirstOrDefault(filterPredicate);
        var teacherVm = Mapper.Map<TeacherVm>(teacher);
        return teacherVm;
    }

    public IEnumerable<TeacherVm> GetTeachers(Expression<Func<Teacher, bool>>? filterPredicate = null)
    {
        var teachers = DbContext.Users.OfType<Teacher>().AsQueryable();
        if(filterPredicate != null)
            teachers = teachers.Where(filterPredicate);
        var teacherVms = Mapper.Map<IEnumerable<TeacherVm>>(teachers);
        return teacherVms;
    }

    public IEnumerable<GroupVm> GetTeachersGroups(TeachersGroupsVm getTeachersGroups)
    {
        if(getTeachersGroups == null)
            throw new ArgumentNullException("Get teacher groups is null");
        var groups = DbContext.Users.OfType<Teacher>()
            .Where(t => t.Id == getTeachersGroups.TeacherId && t.Subjects != null)
            .SelectMany(t => t.Subjects!)
            .Where(s => s.SubjectGroups != null).
            SelectMany(s => s.SubjectGroups!)
            .Select(sg => sg.Group);
        var groupsVm = Mapper.Map<IEnumerable<GroupVm>>(groups);
        return groupsVm;
    }
}