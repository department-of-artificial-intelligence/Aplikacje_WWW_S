using System.ComponentModel.DataAnnotations;
using SchoolRegister.BLL.Entities;

namespace SchoolRegister.ViewModels.DTOs
{
    public class AddGradeToStudentDto
    {
        [Required]
        public int StudentId { get; set; }

        [Required]
        public int SubjectId { get; set; }

        [Required]
        public GradeScale GradeValue { get; set; }

        [Required]
        public int TeacherId { get; set; }
    }
}