using Kolokwium.Services.DTO.Book;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Kolokwium.Web.ViewModels.Publisher
{
    public class CreatePublisherViewModel
    {

        [Required(ErrorMessage = "Nazwa jest wymagana.")]
        [Display(Name = "Nazwa wydawnictwa")]
        public string Name { get; set; } = null!;
    }
}
