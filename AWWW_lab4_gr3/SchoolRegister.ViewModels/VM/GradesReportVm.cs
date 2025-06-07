 using System.Collections.Generic;

namespace SchoolRegister.ViewModels.VM
{
    public class GradesReportVm
    {
        public string? StudentFullName { get; set; }
        public string? GroupName { get; set; }
        public IList<SubjectGradesVm> SubjectsGrades { get; set; } = new List<SubjectGradesVm>();
        public double FinalAverageGrade { get; set; } // Średnia ze wszystkich przedmiotów
     }

    public class SubjectGradesVm // Pomocniczy VM dla ocen z danego przedmiotu
    {
        public string? SubjectName { get; set; }
        public IList<GradeVm> Grades { get; set; } = new List<GradeVm>();
        public double SubjectAverageGrade { get; set; }
        public string? TeacherFullName { get; set; } // Nauczyciel prowadzący przedmiot
    }
}