using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace SchoolRegister.Model.DataModels;
public class User : IdentityUser<int>
{
    [Required]
    public string FirstName { get; set; } = null!;
    [Required]
    public string LastName { get; set; } = null!;
    public DateTime RegistrationDate { get; set; } = DateTime.Now;
    public User() { }
}