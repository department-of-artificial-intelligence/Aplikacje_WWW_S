using Kolokwium.Model.DataModels; 

namespace Kolokwium.ViewModel.VM; 



public class AddOrUpdateStudentVm {
    public int? Id {get; set;}
    public required string FirstName {get; set;}
    public required string LastName {get; set;}
   // public IEnumerable<Grade>? Grades {get; set;}
}