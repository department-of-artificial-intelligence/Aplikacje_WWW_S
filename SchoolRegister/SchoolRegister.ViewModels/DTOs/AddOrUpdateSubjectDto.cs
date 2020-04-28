using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SchoolRegister.ViewModels.DTOs
{
    public class AddOrUpdateSubjectDto
    {
        public int? Id { get; set; }
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int TeacherID { get; set; }
    }
}
