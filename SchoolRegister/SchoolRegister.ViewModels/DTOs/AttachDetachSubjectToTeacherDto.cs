using System.ComponentModel.DataAnnotations;

namespace SchoolRegister.ViewModels.DTOs
{
    public class AttachDetachSubjectToTeacherDto
    {
        [Required]
        public int SubjectId { get; set; }
        [Required]
        public int TeacherId { get; set; }
    }
}
