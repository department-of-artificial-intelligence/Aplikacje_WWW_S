using Microsoft.AspNetCore.Identity;
using system;

namespace SchoolRegister.Model.DataModels
{
    public class User : IdentityUser<int>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
        public DateTime RegistrationDate { get; set; }
    }
}