using Microsoft.AspNetCore.Identity;
using System;
namespace SchoolRegister.Model.DataModels;

public class RoleValue
{
    public static int User = 0;
    public static int Student = 1;
    public static int Parent = 2;
    public static int Teacher = 3;
    public static int Admin = 4;
}