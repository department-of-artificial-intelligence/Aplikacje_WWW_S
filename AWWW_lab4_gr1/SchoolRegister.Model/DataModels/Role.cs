using Microsoft.AspNetCore.Identity;

namespace SchoolRegister.Model.DataModels
{
    internal class Role : IdentityRole<int>
    {
        public RoleValue RoleValue { get; set; }
        public Role(string name, RoleValue roleValue) { }
    }
}
