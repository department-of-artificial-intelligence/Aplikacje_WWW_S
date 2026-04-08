using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AWWW_lab2_gr1.Models;

public class ProductCreateViewModel
{
    [Required(ErrorMessage = "Nazwa produktu jest wymagana")]
    public string Name { get; set; } = string.Empty;

    [Range(typeof(decimal), "0,01", "79228162514264337593543950335", ErrorMessage = "Cena musi byc wieksza od 0")]
    public decimal Price { get; set; }

    [Required(ErrorMessage = "Kategoria jest wymagana")]
    public int? CategoryId { get; set; }

    public List<int> SelectedTagIds { get; set; } = new();

    public IEnumerable<SelectListItem> Categories { get; set; } = Enumerable.Empty<SelectListItem>();
    public IEnumerable<SelectListItem> Tags { get; set; } = Enumerable.Empty<SelectListItem>();
}