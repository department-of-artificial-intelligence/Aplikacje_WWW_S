using Microsoft.AspNetCore.Identity;
using System;

namespace SchoolRegister.Model.DataModels;

public class Student : User
{
    public virtual Group Group {get; set;}
    public int? GroupId {get; set;}
    public IList<Grade> Grades {get; set;} = null;
    public virtual Parent Parent {get; set;}
    public int? ParentId {get; set;};
    public double AverageGrade {get;}
    public IDictionary<string,double> AverageGradePerSubject {get;}
    public IDictionary<string, List<GradeScale>> GradesPerSubject {get;}

    public Student(string Name, string Surname) : base(Name,Surname)
    {

    }
}