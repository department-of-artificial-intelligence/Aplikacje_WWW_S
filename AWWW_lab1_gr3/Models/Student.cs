namespace AWWWW_lab1_gr3.Models;

using System.Data;
using Microsoft.AspNetCore.Mvc;

public class Student
{
    public string FirstName { get; set;}
    public string LastName { get; set;}
    public int IndexNr { get; set;}
    public DateTime DateOfBirth { get; set;} 
    public string FieldOfStudy { get; set;} 
}