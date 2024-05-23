using Microsoft.AspNetCore.Identity;
using System;
namespace SchoolRegister.Model.DataModels;
public class User : IdentityRole<int>
{
    public RoleValue RoleValue { get; set; }

    public Role(string name, RoleValue roleValue) 
    {
        this.RoleValue = roleValue;
        this.Name = name;
    }
}