using Microsoft.AspNetCore.Identity;
using System;
namespace SchoolRegister.Model.DataModels;

public class Parent
{
    public IList<Studnet> Students {get; set;}
}