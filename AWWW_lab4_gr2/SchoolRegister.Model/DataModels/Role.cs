using Microsoft.AspNetCore.Identity;
using Microsoft.Win32;

namespace SchoolRegister.Model.DataModels;

public class Role: IdentityRole<int>
{
    public RoleValue RoleValue {get; set;}
    public Role() {}
    public Role(string name, RoleValue roleValue) {

    }
}