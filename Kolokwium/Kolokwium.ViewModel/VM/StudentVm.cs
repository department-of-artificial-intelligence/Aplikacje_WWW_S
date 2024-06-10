using Kolokwium.Model.DataModels;

namespace Kolokwium.ViewModel.VM; 

public class StudentVm {
    public int Id {get; set;}
    public required string FirstName {get; set;}
    public required string LastName {get; set;}
    public string? StudentName {get; set;}
    public IEnumerable<Grade>? Grades {get; set;}
}