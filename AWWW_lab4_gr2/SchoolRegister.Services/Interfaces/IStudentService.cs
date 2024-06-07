using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using SchoolRegister.Model.DataModels;
using SchoolRegister.ViewModels.VM;

namespace SchoolRegister.Services.Interfaces
{
    public interface IStudentService
    {
        public StudentVm GetStudent(Expression<Func<Student, bool>> predicate);
        public IEnumerable<StudentVm> GetStudents(Expression<Func<Student, bool>>? predicate = null);
    }
}
