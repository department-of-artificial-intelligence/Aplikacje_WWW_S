using System.ComponentModel.DataAnnotations;

namespace SchoolRegister.ViewModels.DTOs
{
    public class SendEmailToParentDto
    {
        [Required]
        public int SenderId { get; set; }
        [Required]
        public int StudentId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
    }
}
