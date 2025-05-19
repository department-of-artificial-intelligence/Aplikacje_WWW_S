using SchoolRegister.ViewModels.VM;
using SchoolRegister.Model.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
namespace SchoolRegister.Services.Interfaces
{
    public interface IStudentServica
    {
        StudentVm GetStudent(Expression<Func<Student, bool>> filterPredicate);
        IEnumerable<StudentVm> GetStudents([Expression<Func<Student, bool>> filterPredicate = null]);
    }
}