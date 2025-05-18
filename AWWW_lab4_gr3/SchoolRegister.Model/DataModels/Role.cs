using Microsoft.AspNetCore.Identity;

namespace SchoolRegister.Model.DataModels
{
    public class Role : IdentityRole<int>
    {

        public Role() : base() { }
        public Role(string roleName) : base(roleName) { }
    }
}