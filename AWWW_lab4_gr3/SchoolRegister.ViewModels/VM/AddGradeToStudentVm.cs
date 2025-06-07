// Plik: SchoolRegister.ViewModels/VM/AddGradeToStudentVm.cs
using SchoolRegister.Model.DataModels; // Dla GradeScale
using System.ComponentModel.DataAnnotations;

namespace SchoolRegister.ViewModels.VM
{
    public class AddGradeToStudentVm
    {
        [Required]
        public int StudentId { get; set; }

        [Required]
        public int SubjectId { get; set; }

        [Required]
        public GradeScale GradeValue { get; set; } // Lub int Value

        
        [Required]
        public int IssuedByTeacherId { get; set; }

        public string? Comment { get; set; } // Opcjonalny komentarz
        // Data wystawienia zazwyczaj będzie ustawiana przez serwer
    }
}