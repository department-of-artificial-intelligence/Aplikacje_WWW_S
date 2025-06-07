// Plik: SchoolRegister.ViewModels/VM/AttachDetachSubjectToGroupVm.cs
using System.ComponentModel.DataAnnotations;

namespace SchoolRegister.ViewModels.VM
{
    public class AttachDetachSubjectToGroupVm
    {
        [Required]
        public int SubjectId { get; set; }

        [Required]
        public int GroupId { get; set; }
    }
}