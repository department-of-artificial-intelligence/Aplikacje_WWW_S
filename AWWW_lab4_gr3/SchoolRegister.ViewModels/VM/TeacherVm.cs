using System.Collections.Generic; // Dla IList
using System.ComponentModel.DataAnnotations; // Dla Display

namespace SchoolRegister.ViewModels.VM
{
    public class TeacherVm
    {
        public int Id { get; set; }
        public string FirstName { get; set; } =  null!;
        public string LastName { get; set; } =  null!;
        public string FullName => $"{FirstName} {LastName}";
        public IList<SubjectVm> SubjectsTaught { get; set; } = new List<SubjectVm>();
    }
}