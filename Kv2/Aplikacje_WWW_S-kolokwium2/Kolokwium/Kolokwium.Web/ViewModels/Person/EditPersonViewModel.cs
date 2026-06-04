using System;
using System.ComponentModel.DataAnnotations;

namespace Kolokwium.Web.ViewModels.Person
{
    public class EditPersonViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Imię jest wymagane.")]
        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;
        public DateTime RegistrationDate { get; set; }
        public int Age { get; set; }
    }
}