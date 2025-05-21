using System.Linq.Expressions;
using AutoMapper;
using Microsoft.Extensions.Logging;
using SchoolRegister.DAL.EF;
using SchoolRegister.Model.DataModels;
using SchoolRegister.Services.Interfaces;
using SchoolRegister.ViewModels.VM;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlTypes;
using System.Runtime.CompilerServices;

namespace SchoolRegister.Services.ConcreteServices;
public class GroupService : BaseService, IGroupService
{
    protected UserManager<User> _userManager;
    public GroupService(ApplicationDbContext dbContext, ILogger logger, IMapper mapper, UserManager<User> userManager) : base(dbContext, logger, mapper)
    {
        _userManager = userManager;
    }

    public GroupVm AddOrUpdateGroup(AddOrUpdateGroupVm addOrUpdateGroupVm)
    {
        try{
            if(addOrUpdateGroupVm == null)
                throw new ArgumentNullException("addOrUpdateGroupVm is null");
            
            var group = Mapper.Map<SchoolRegister.Model.DataModels.Group>(addOrUpdateGroupVm);
            if(!addOrUpdateGroupVm.Id.HasValue || group.Id == 0)
                DbContext.Groups.Add(group);
            else
                DbContext.Groups.Update(group);
            DbContext.SaveChanges();

            var groupVm = Mapper.Map<GroupVm>(group);
            return groupVm;
        }catch(Exception ex)
        {
            Logger.LogError(ex, ex.Message);
            throw;
        }
    }

    public async Task<StudentVm> AttachStudentToGroup(AttachDetachStudentToGroupVm attachDetachStudentToGroupVm)
    {
        try
        {
            if(attachDetachStudentToGroupVm == null)
                throw new ArgumentNullException("attachDetacHSutdentToGroupVm is null");
            
            var student = await DbContext.Users.OfType<Student>()
                .FirstOrDefaultAsync(s => s.Id == attachDetachStudentToGroupVm.StudentId);
            if(student == null)
                throw new InvalidOperationException($"Student with Id {attachDetachStudentToGroupVm.StudentId} doesn't exist");

            bool isStudent = await _userManager.IsInRoleAsync(student, "Student");
            if(!isStudent)
                throw new ArgumentException($"User with Id {attachDetachStudentToGroupVm.StudentId} is not a student");

            var group = await DbContext.Groups
                .FirstOrDefaultAsync(g => g.Id == attachDetachStudentToGroupVm.GroupId);
            if(group == null)
                throw new ArgumentException($"Group with Id {attachDetachStudentToGroupVm.GroupId} doesn't exist");
            
            student.Group = group;
            student.GroupId = group.Id;
            await DbContext.SaveChangesAsync();
            var studentVm = Mapper.Map<StudentVm>(student);
            
            return studentVm;
        }catch(Exception ex)
        {
            Logger.LogError(ex, ex.Message);
            throw;
        }
    }

    public GroupVm AttachSubjectToGroup(AttachDetachSubjectGroupVm attachDetachSubjectGroupVm)
    {
        try
        {
            if(attachDetachSubjectGroupVm == null)
                throw new ArgumentNullException("attatchDetachSubjectGroupVm is null");
            
            var subject = DbContext.Subjects.FirstOrDefault(s => s.Id == attachDetachSubjectGroupVm.SubjectId) ??
                throw new InvalidOperationException($"Subject with Id {attachDetachSubjectGroupVm.SubjectId} doesn't exist");
            var group = DbContext.Groups.FirstOrDefault(g => g.Id == attachDetachSubjectGroupVm.GroupId) ??
                throw new InvalidOperationException($"Group with Id {attachDetachSubjectGroupVm.GroupId} doesn't exist");

            var subjectGroup = Mapper.Map<SubjectGroup>(attachDetachSubjectGroupVm);
            DbContext.SubjectGroups.Add(subjectGroup);
            DbContext.SaveChanges();

            var groupEntity = DbContext.Groups
                .Include(g => g.SubjectGroups!)
                .ThenInclude(sg => sg.Subject)
                .FirstOrDefault(g => g.Id == attachDetachSubjectGroupVm.GroupId);
            var groupVm = Mapper.Map<GroupVm>(groupEntity);
            return groupVm;

        }catch(Exception ex)
        {
            Logger.LogError(ex, ex.Message);
            throw;
        }
    }

    public async Task<SubjectVm> AttachTeacherToSubject(AttachDetachSubjectToTeacherVm attachDetachSubjectToTeacherVm)
    {
        if(attachDetachSubjectToTeacherVm == null)
            throw new ArgumentNullException(nameof(attachDetachSubjectToTeacherVm));
        
        var techer = await DbContext.Users.OfType<Teacher>().FirstOrDefaultAsync(u => u.Id == attachDetachSubjectToTeacherVm.TeacherId) ??
            throw new InvalidOperationException($"Teacher with Id {attachDetachSubjectToTeacherVm.TeacherId} doesn't exist");

        var isTeacher = await _userManager.IsInRoleAsync(techer, "Teacher");
        if(!isTeacher)
            throw new ArgumentException($"User with Id {attachDetachSubjectToTeacherVm.TeacherId} is not a Teacher"); 

        var subject = await DbContext.Subjects.FirstOrDefaultAsync(s => s.Id == attachDetachSubjectToTeacherVm.SubjectId) ??
            throw new InvalidOperationException($"Subject with Id {attachDetachSubjectToTeacherVm.SubjectId} doesn't exist");
        
        subject.Teacher = techer;
        subject.TeacherId = techer.Id;
        await DbContext.SaveChangesAsync();

        var subjectVm = Mapper.Map<SubjectVm>(subject);
        return subjectVm;
    }

    public async Task<StudentVm> DetachStudentFromGroup(AttachDetachStudentToGroupVm attachDetachStudentToGroupVm)
    {
        if(attachDetachStudentToGroupVm == null)
            throw new ArgumentNullException(nameof(attachDetachStudentToGroupVm));
        
        var student = await DbContext.Users.OfType<Student>().FirstOrDefaultAsync(u => u.Id == attachDetachStudentToGroupVm.StudentId) ??
            throw new InvalidOperationException($"Student with Id {attachDetachStudentToGroupVm.StudentId} doesn't exist");

        var group = await DbContext.Groups
            .Include(g => g.Students)
            .FirstOrDefaultAsync(g => g.Id == attachDetachStudentToGroupVm.GroupId) ??
            throw new InvalidOperationException($"Group with Id {attachDetachStudentToGroupVm.GroupId} doesn't exist");
        
        Logger.LogInformation($"group.Students.Count = {group.Students?.Count}");

        if (student.GroupId != group.Id)
            throw new ArgumentException($"Student with Id {student.Id} is not a member of group with Id {group.Id}");

        student.Group = null;
        student.GroupId = null;
        await DbContext.SaveChangesAsync();

        var studentVm = Mapper.Map<StudentVm>(student);
        return studentVm;
    }

    public GroupVm DetachSubjectFromGroup(AttachDetachSubjectGroupVm attachDetachSubjectGroupVm)
    {
        try
        {
            if(attachDetachSubjectGroupVm == null)
                throw new ArgumentNullException(nameof(attachDetachSubjectGroupVm));
            
            var subject = DbContext.Subjects.FirstOrDefault(s => s.Id == attachDetachSubjectGroupVm.SubjectId) ??
                throw new InvalidOperationException($"Subject with Id {attachDetachSubjectGroupVm.SubjectId} doesn't exist");
            
            var group = DbContext.Groups.FirstOrDefault(g => g.Id == attachDetachSubjectGroupVm.GroupId) ??
                throw new InvalidOperationException($"Group with Id {attachDetachSubjectGroupVm.GroupId} doesn't exist");
            
            var subjectGroup = DbContext.SubjectGroups.FirstOrDefault(sg => sg.GroupId == group.Id && sg.SubjectId == subject.Id) ??
                throw new InvalidOperationException($"Subject with Id {subject.Id} and group with Id {group.Id} are not in the same SubjectGroup");
            
            DbContext.SubjectGroups.Remove(subjectGroup);
            DbContext.SaveChanges();

            var groupEntity = DbContext.Groups
                .Include(g => g.SubjectGroups!)
                .ThenInclude(sg => sg.Subject)
                .FirstOrDefault(g => g.Id == attachDetachSubjectGroupVm.GroupId);

            var groupVm = Mapper.Map<GroupVm>(groupEntity);
            return groupVm;
        }catch(Exception ex)
        {
            Logger.LogError(ex, ex.Message);
            throw;
        }
        
    }

    public SubjectVm DetachTeacherFromSubject(AttachDetachSubjectToTeacherVm attachDetachSubjectToTeacherVm)
    {
        try
        {
            if(attachDetachSubjectToTeacherVm == null)
                throw new ArgumentNullException(nameof(attachDetachSubjectToTeacherVm));

            var teacher = DbContext.Users.OfType<Teacher>().FirstOrDefault(u => u.Id == attachDetachSubjectToTeacherVm.TeacherId) ??
                throw new InvalidOperationException($"Teacher with Id {attachDetachSubjectToTeacherVm.TeacherId} doesn't exist");

            var subject = DbContext.Subjects.FirstOrDefault(s => s.Id == attachDetachSubjectToTeacherVm.SubjectId) ??
                throw new InvalidOperationException($"Subject with Id {attachDetachSubjectToTeacherVm.SubjectId} doesn't exist");

            subject.TeacherId = null;
            subject.Teacher = null;
            DbContext.SaveChanges();

            var subjectVm = Mapper.Map<SubjectVm>(subject);
            return subjectVm;
        }catch(Exception ex)
        {
            Logger.LogError(ex, ex.Message);
            throw;
        }
    }

    public GroupVm GetGroup(Expression<Func<Group, bool>> filterPredicate)
    {
        try
        {
            if(filterPredicate == null)
                throw new ArgumentNullException("filterPredicate is null");
            
            var group = DbContext.Groups.FirstOrDefault(filterPredicate) ??
                throw new InvalidOperationException("Group not found");
            var groupVm = Mapper.Map<GroupVm>(group);
            return groupVm;
        }catch(Exception ex)
        {
            Logger.LogError(ex, ex.Message);
            throw;
        }
    }

    public IEnumerable<GroupVm> GetGroups(Expression<Func<Group, bool>>? filterPredicate = null)
    {
        var groups = DbContext.Groups.AsQueryable();
        if(filterPredicate != null)
            groups = groups.Where(filterPredicate);
        
        var groupVms = Mapper.Map<IEnumerable<GroupVm>>(groups);
        return groupVms;
    }
}