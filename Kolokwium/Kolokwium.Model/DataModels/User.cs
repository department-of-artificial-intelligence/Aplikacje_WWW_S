using Microsoft.AspNetCore.Identity;

namespace Kolokwium.Model.DataModels;

public class User : IdentityUser<int>
{
    public User() : base(){}

    public required string FirstName {get; set;}
    public required string LastName {get; set;}
}

