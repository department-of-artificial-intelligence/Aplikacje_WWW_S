
using System;

namespace SchoolRewgister.Model.DataModels;

public class Grade 
{
    public DateTime DateOfIssue { get; set; }
    public GradeScale GradeValue{get; set; }

    public Subject Subject { get; set; }
    public int SubjectId { get; set; }
    public int StudentId { get; set; }
    public Studetn Studetn{ get; set; }
}