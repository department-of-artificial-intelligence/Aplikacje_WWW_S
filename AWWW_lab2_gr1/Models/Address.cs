using System.ComponentModel.DataAnnotations;

namespace AWWW_lab2_gr1.Models;

public class Address
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Wybierz klienta")]
    public int CustomerId { get; set; }

    [Required(ErrorMessage = "Podaj miasto")]
    public string City { get; set; } = string.Empty;

    [Required(ErrorMessage = "Podaj ulicę")]
    public string Street { get; set; } = string.Empty;

    [Required(ErrorMessage = "Podaj kod pocztowy")]
    public string PostalCode { get; set; } = string.Empty;

    public virtual Customer? Customer { get; set; }
}