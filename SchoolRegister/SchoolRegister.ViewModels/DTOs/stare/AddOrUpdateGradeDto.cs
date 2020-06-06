using SchoolRegister.BLL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SchoolRegister.ViewModels.DTOs
{
    public class AddOrUpdateGradeDto
    {
        [Required]
        public DateTime DateOfIssue { get; set; }

        [Required]
        public GradeScale GradeValue { get; set; }

        [Required]
        public int SubjectId { get; set; }
    }
}
