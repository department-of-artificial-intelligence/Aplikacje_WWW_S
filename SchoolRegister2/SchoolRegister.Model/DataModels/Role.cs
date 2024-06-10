using Microsoft.AspNetCore.Identity;

namespace SchoolRegister.Model.DataModels
{
    public class Role : IdentityRole<int>
    {
        public RoleValue RoleValue { get; set; }
        public Role()
        {

        }
        public Role(string role, RoleValue roleValue)
            : base(role)
        {
            RoleValue = roleValue;
        }
    }
}
