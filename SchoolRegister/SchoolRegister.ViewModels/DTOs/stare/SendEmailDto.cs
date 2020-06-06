using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SchoolRegister.ViewModels.DTOs
{
    public class SendEmailDto
    {
        public int? Id { get; set; }
        [Required]
        public string Title{ get; set; }

        [Required]
        public string Text { get; set; }

        [Required]
        public int TeacherID { get; set; }

        [Required]
        public int ParentID { get; set; }
    }
}
