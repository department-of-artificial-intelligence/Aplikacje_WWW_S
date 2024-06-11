using Microsoft.AspNetCore.Identity;

namespace Kolokwium.Model.DataModels;

public class User : IdentityUser<int>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }

    public DateTime RegistrationDate { get; set; }
}

