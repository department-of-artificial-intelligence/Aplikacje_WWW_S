using Microsoft.AspNetCore.Identity;
using System;
namespace SchoolRegister.Model.DataModels;
public class Role : IdentityUser<int>
{
    public RoleValue RoleValue { get; set; }
}