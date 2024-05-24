using Microsoft.AspNetCore.Identity;
using System;
namespace SchoolRegister.Model.DataModels;

public class SubjectGroup
{
    public Group Group { get; set; } = null!;
    public int GroupId { get; set; }
    public ICollection<Grade> Grades { get; set; } = new List<Grade>();
    public Parent Parent { get; set; } = null!;
    public int? ParentId { get; set; }
    public double AverageGrade { get; }
    public IDictionary<string, double> AverageGradeSubject { get; }
    public IDictionary<string, List<GradeScale>> GradesPerSubject { get; }


}