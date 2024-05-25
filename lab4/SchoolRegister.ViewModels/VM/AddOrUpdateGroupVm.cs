using System.ComponentModel.DataAnnotations;

public class AddOrUpdateGroupVm
{
    public int? Id { get; set; }

    [Required]
    public required string Name { get; set; }
}