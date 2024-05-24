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
        public virtual Parent Parent {get;set;} = null!;
        public int? ParentId {get;set;}
        public double? AverageGrade {get {return Grades?.Select(x=>((int)x.GradeValue)).Average();}}
        public IDictionary<string,double>? AverageGradePerSubject {get {
            var dict = new Dictionary<string,double>();
            if (Grades == null || !Grades.Any()){
                return dict;
            }
            var subjectList = Grades.Select(x=>x.Subject).Distinct();
            foreach (var subject in subjectList)
            {
                dict.Add(subject.Name,Grades.Where(x=>x.Subject==subject).Select(x=>(int)x.GradeValue).Average());
            }
            return dict;
            }}
        public IDictionary<string,List<GradeScale>>? GradesPerSubject {get {
            var dict = new Dictionary<string,List<GradeScale>>();
            if (Grades == null || !Grades.Any()){
                return dict;
            }
            var subjectList = Grades.Select(x=>x.Subject).Distinct();
            foreach (var subject in subjectList)
            {
                dict.Add(subject.Name,Grades.Where(x=>x.Subject==subject).Select(x=>x.GradeValue).ToList());
            }
            return dict;
            }}
    }
}