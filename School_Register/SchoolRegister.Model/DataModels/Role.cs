
using Microsoft.AspNetCore.Identity;
public class Role : IdentityRole<int>
{
    public RoleValue roleValue { get; set; }

    public Role()
    {
    }
    public Role(string name ,RoleValue roleValue)
    {
        Name = name;
        this.roleValue = roleValue;
    }
}