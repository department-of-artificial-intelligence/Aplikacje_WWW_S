using Microsoft.AspNetCore.Identity;

using System;

namespace SchoolRewgister.Model.DataModels;

public class Role: IdentityRole<int>
{
    public RoleValue RoleValue{get; set;}

}