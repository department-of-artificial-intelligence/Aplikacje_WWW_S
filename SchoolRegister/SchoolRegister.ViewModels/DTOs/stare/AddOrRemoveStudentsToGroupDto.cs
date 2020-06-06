using SchoolRegister.BLL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SchoolRegister.ViewModels.DTOs
{
    public class AddOrRemoveStudentsToGroupDto
    {
        [Required]
        public IList<Student> Students { get; set; }

        [Required]
        public int GroupID { get; set; }
    }
}
