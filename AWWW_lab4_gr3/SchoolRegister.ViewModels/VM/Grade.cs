// Plik: SchoolRegister.ViewModels/VM/GradeVm.cs
using System;
using SchoolRegister.Model.DataModels; // Dla GradeScale, jeśli to enum

namespace SchoolRegister.ViewModels.VM
{
    public class GradeVm
    {
        public int Id { get; set; }
        public GradeScale GradeValue { get; set; } // Lub int Value, jeśli GradeScale nie jest używane bezpośrednio
        public string? SubjectName { get; set; }
        public string? StudentName { get; set; } // Imię i nazwisko studenta
        public string? TeacherName { get; set; } // Kto wystawił
        public DateTime DateOfIssue { get; set; }
        // Można dodać np. wagę oceny, komentarz itp.
    }
}