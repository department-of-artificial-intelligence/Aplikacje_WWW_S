using Microsoft.AspNetCore.Identity;
using System;
namespace SchoolRegister.Model.DataModels;

public class Student
{
    public Group Group (get; set;)
    public int GroupId {get; set;}
    public IList<Grade> Grades {get; set;}
    public Parent Parent {get; set;}
    public int ParentId {get; set;}
    public double AverageGrade {get;}
}