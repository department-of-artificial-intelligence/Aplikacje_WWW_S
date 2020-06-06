using System.ComponentModel.DataAnnotations;

namespace SchoolRegister.ViewModels.DTOs
{
    public class GetGradesDto
    {
        [Required]
        public int StudentId { get; set; }
        [Required]
        public int GetterUserId { get; set; }
    }
}
