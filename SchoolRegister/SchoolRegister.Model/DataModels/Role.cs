using Microsoft.AspNetCore.Identity;

public class Role : IdentityRole<int>{
    public RoleValue RoleValue { get; set; }
}