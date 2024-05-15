using Microsoft.AspNetCore.Identity;

namespace SchoolRegister.Model.DataModels;
public class User : IdentityUser<int>
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public DateTime RegistrationDate { get; set; } = DateTime.Now;
    public User() { }
}