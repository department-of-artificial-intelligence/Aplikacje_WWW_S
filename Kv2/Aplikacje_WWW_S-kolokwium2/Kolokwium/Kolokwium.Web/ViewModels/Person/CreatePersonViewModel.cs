using System;
using System.ComponentModel.DataAnnotations;

namespace Kolokwium.Web.ViewModels.Person
{
    public class CreatePersonViewModel
    {
        [Required(ErrorMessage = "Imię jest wymagane.")]
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime RegistrationDate { get; set; } = DateTime.Now;
        public int Age { get; set; }
    }
}
