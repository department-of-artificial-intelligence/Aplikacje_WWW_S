using Microsoft.AspNetCore.Identity; 
using System; 

namespace SchoolRegister.Model.DataModels; 
public class User: IdentityUser<int> {
    public required string FirstName {get; set;}
    public required string LastName {get; set;}
    public DateTime RegistrationDate {get ;set;} = DateTime.Now; 

    public User(): base() {}

}