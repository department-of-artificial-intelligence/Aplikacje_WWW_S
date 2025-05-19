using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace SchoolRegister.Model.DataModels;

public class Teacher : User
{
    public string Title { get; set; }
    public virtual IList<Subject> Subjects { get; set; }
    public Teacher() { }
}