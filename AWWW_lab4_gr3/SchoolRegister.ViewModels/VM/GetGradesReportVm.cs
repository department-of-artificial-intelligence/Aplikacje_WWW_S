// Plik: SchoolRegister.ViewModels/VM/GetGradesReportVm.cs
using System.ComponentModel.DataAnnotations;

namespace SchoolRegister.ViewModels.VM
{
    public class GetGradesReportVm
    {
        [Required]
        public int StudentId { get; set; }
        // Można dodać inne filtry, np. zakres dat, konkretny przedmiot itp.
    }
}