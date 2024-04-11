using System.ComponentModel.DataAnnotations;

namespace AWWW_lab1_gr1.Models;

public class Author 
{
    public int Id { get; set; }

    [Required(ErrorMessage = "complete name")]
    public string FirstName { get; set; }

    [Required(ErrorMessage = "complete surname")]
    public string LastName { get; set; }
}
