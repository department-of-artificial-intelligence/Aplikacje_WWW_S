using SchoolRegister.ViewModels.VMs;
using SchoolRegister.ViewModels.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq.Expressions;
using SchoolRegister.BLL.Entities;

namespace SchoolRegister.Services.Interfaces
{
    public interface ISubjectService
    {
        SubjectVm AddOrUpdate(AddOrUpdateSubjectDto addOrUpdateDto);
        SubjectVm GetSubject(Expression<Func<Subject, bool>> filterPredicate);

        IEnumerable<SubjectVm> GetSubjects(Expression<Func<Subject, bool>> filterPredicate = null);
    }
}
