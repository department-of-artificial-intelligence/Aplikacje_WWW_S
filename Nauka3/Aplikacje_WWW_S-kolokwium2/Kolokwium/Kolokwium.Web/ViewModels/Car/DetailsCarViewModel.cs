using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Kolokwium.Web.ViewModels.Car
{
    public class DetailsCarViewModel
    {
        public string Brand { get; set; } = null!;

        public string Model { get; set; } = null!;

        public string DriverFirstName { get; set; } = null!;
        public string DriverLastName { get; set; } = null!;

        public string? DocumentNumber { get; set; }
        public DateTime? RegistrationIssueDate { get; set; }


    }
}
