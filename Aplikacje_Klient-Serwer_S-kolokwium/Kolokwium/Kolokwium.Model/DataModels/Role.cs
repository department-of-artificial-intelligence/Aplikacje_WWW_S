using Microsoft.AspNetCore.Identity;

namespace Kolokwium.Model.DataModels;

public class Role : IdentityRole<int>
{
    public RoleValue RoleValue { get; set; }
}
