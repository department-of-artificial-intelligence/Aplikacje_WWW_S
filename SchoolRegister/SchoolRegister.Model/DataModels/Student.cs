using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolRegister.Model.DataModels
{
    public class Student
    {
        public virtual Group? Group{get;set;}
        public int? GroupId {get;set;}
        public virtual IList<Grade>? Grades {get;set;}
        public virtual Parent? Parent {get;set;}
        public int? ParentId {get;set;}
        public double? AverageGrade {get;}
        public IDictionary<string,double>? AverageGradePerSubject {get;}
        public IDictionary<string,List<GradeScale>>? GradesPerSubject {get;}
    }
}