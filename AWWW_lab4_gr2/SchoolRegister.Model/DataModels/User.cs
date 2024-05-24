using Microsoft.AspNetCore.Identity;
using System;
namespace SchoolRegister.Model.DataModels;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


public class User : IdentityUser<int>
{
    [Required]
    public string FirstName { get; set; } = null!;
    [Required]
    public string LastName { get; set; } = null!;
    public DateTime RegistrationDate { get; set; } = DateTime.Now;
}