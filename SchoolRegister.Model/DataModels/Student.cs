using Microsoft.AspNetCore.Identity;
using System;
namespace SchoolRegister.Model.DataModels;
public class Student : User
{
    public Group Group {get; set;} 
    public int? GroupId {get;set;}
    public IList<Grade> Grades {get;set;}
    public Parent Parent { get;set;}
    public int? ParentId {get; set;}
    public double AverageGrade {get;}
    public IDictionary<string,double> AverageGradePerSubject {
        get {
            return Grades.GroupBy(g => g.Subject)
                         .ToDictionary(g => g.Key, g => g.Average(v => (double)v.Value));
        }
    }
    public IDictionary<string,List<GradeScale>> GradesPerSubject {
        get {
            return Grades.GroupBy(g => g.Subject)
                         .ToDictionary(g => g.Key, g => g.Select(v => v.Scale).ToList());
        }
        }

}