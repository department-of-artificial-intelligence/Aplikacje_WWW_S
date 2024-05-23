using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolRegister.Model.DataModels
{
    public class Student:User
    {
        public Group Group{get;set;}
        public int GroupId{get;set;}
        public IList<Grade> Grades{get;set;}
        public Parent Parent{get;set;}
        public int? ParentId{get;set;}
        public double AverageGrade{get{
            double average = 0;
            foreach(Grade g in Grades){
                average+=(double)g.GradeValue;
            }
            return average/Grades.Count;
        }}
        public IDictionary<string, double> AverageGradePerSubject{get{
            IDictionary<string, double> Lista = new Dictionary<string, double>();
            foreach(Grade g in Grades){
                Lista.Add(g.Subject.Name, (double)g.GradeValue);
            }
            return Lista;
        }}
        public IDictionary<string, List<GradeScale>>? GradesPerSubject{get{
            return null;
        }}
    }
}