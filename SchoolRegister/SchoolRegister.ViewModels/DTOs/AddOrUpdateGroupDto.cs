using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SchoolRegister.ViewModels.DTOs
{
    public class AddOrUpdateGroupDto
    {
        public int? Id { get; set; }
        [Required]
        public string Name { get; set; }

    }
}
