using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SchoolRegister.DAL.EF;
using SchoolRegister.Model.DataModels;
using SchoolRegister.Services.Interfaces;
using SchoolRegister.ViewModels.VM;

namespace SchoolRegister.Services.ConcreteServices
{
    public class GroupService : BaseService, IGroupService
    {
        public GroupService(AppDbContext dbContext, IMapper mapper, ILogger logger)
            : base(dbContext, mapper, logger) { }

        public GroupVm AddOrUpdateGroup(AddOrUpdateGroupVm addOrUpdateVm)
        {
            try
            {
                if (addOrUpdateVm == null)
                    throw new ArgumentNullException($"View model parameter is null");
                var GroupEntity = Mapper.Map<Group>(addOrUpdateVm);
                if (!addOrUpdateVm.Id.HasValue || addOrUpdateVm.Id == 0)
                    DbContext.Groups.Add(GroupEntity);
                else
                    DbContext.Groups.Update(GroupEntity);
                DbContext.SaveChanges();
                var GroupVm = Mapper.Map<GroupVm>(GroupEntity);
                return GroupVm;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw;
            }
        }

        public GroupVm GetGroup(Expression<Func<Group, bool>> filterExpression)
        {
            try
            {
                if (filterExpression == null)
                    throw new ArgumentNullException($" FilterExpression is null");
                var GroupEntity = DbContext.Groups.FirstOrDefault(filterExpression);
                var GroupVm = Mapper.Map<GroupVm>(GroupEntity);
                return GroupVm;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw;
            }
        }

        public IEnumerable<GroupVm> GetGroups(Expression<Func<Group, bool>> filterExpression = null)
        {
            try
            {
                var GroupEntities = DbContext.Groups.AsQueryable();
                if (filterExpression != null)
                    GroupEntities = GroupEntities.Where(filterExpression);
                var GroupVms = Mapper.Map<IEnumerable<GroupVm>>(GroupEntities);
                return GroupVms;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw;
            }
        }

        public StudentVm AttachStudentToGroup(AttachDetachStudentToGroupVm attachStudentToGroupVm)
        {
            try
            {
                var studentEntity = DbContext.Students.FirstOrDefault(s =>
                    s.Id == attachStudentToGroupVm.StudentId
                );
                studentEntity.GroupId = attachStudentToGroupVm.GroupId;

                var StudentVms = Mapper.Map<StudentVm>(studentEntity);
                DbContext.Students.Update(studentEntity);
                return StudentVms;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw;
            }
        }

        public StudentVm DetachStudentFromGroup(AttachDetachStudentToGroupVm detachStudentToGroupVm)
        {
            try
            {
                var studentEntity = DbContext.Students.FirstOrDefault(s =>
                    s.Id == detachStudentToGroupVm.StudentId
                );
                studentEntity.GroupId = null;

                var StudentVms = Mapper.Map<StudentVm>(studentEntity);
                DbContext.Students.Update(studentEntity);
                return StudentVms;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw;
            }
        }

        public GroupVm AttachSubjectToGroup(AttachDetachSubjectGroupVm attachSubjectGroupVm)
        {
            try
            {
                var subjectGroup = DbContext.SubjectGroups.FirstOrDefault(sg =>
                    sg.SubjectId == attachSubjectGroupVm.SubjectId
                );

                if (subjectGroup != null)
                {
                    DbContext.SubjectGroups.Remove(subjectGroup);
                    DbContext.SaveChanges();
                }
                var newSubjectGroup = new SubjectGroup
                {
                    SubjectId = attachSubjectGroupVm.SubjectId,
                    GroupId = attachSubjectGroupVm.GroupId,
                };

                DbContext.SubjectGroups.Add(newSubjectGroup);
                DbContext.SaveChanges();

                var groupEntity = DbContext.Groups.FirstOrDefault(g =>
                    g.Id == attachSubjectGroupVm.GroupId
                );
                var GroupVms = Mapper.Map<GroupVm>(groupEntity);
                return GroupVms;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw;
            }
        }

        public GroupVm DetachSubjectFromGroup(AttachDetachSubjectGroupVm detachDetachSubjectVm)
        {
            try
            {
                var subjectGroup = DbContext.SubjectGroups.FirstOrDefault(sg =>
                    sg.SubjectId == detachDetachSubjectVm.SubjectId
                    && sg.GroupId == detachDetachSubjectVm.GroupId
                );

                if (subjectGroup != null)
                {
                    DbContext.SubjectGroups.Remove(subjectGroup);
                    DbContext.SaveChanges();
                }

                var groupEntity = DbContext.Groups.FirstOrDefault(g =>
                    g.Id == detachDetachSubjectVm.GroupId
                );
                var GroupVms = Mapper.Map<GroupVm>(groupEntity);
                return GroupVms;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw;
            }
        }

        
        public SubjectVm AttachTeacherToSubject(AttachDetachSubjectToTeacherVm attachDetachSubjectToTeacherVm) {
            try
            {
                var subjectEntity = DbContext.Subjects.FirstOrDefault(s =>
                    s.Id == attachDetachSubjectToTeacherVm.SubjectId
                );
                subjectEntity.TeacherId = attachDetachSubjectToTeacherVm.TeacherId;

                var SubjectVms = Mapper.Map<SubjectVm>(subjectEntity);
                DbContext.Subjects.Update(subjectEntity);
                return SubjectVms;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw;
            }
        }
        
        public SubjectVm DetachTeacherFromSubject(AttachDetachSubjectToTeacherVm attachDetachSubjectToTeacherVm) {
            try
            {
                var subjectEntity = DbContext.Subjects.FirstOrDefault(s =>
                    s.Id == attachDetachSubjectToTeacherVm.SubjectId
                );
                subjectEntity.TeacherId = null;

                var SubjectVms = Mapper.Map<SubjectVm>(subjectEntity);
                DbContext.Subjects.Update(subjectEntity);
                return SubjectVms;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw;
            }
        }
    }
}
