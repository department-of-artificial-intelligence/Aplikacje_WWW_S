using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SchoolRegister.Model.DataModels
{
    public class Teacher : User
    {
        public virtual IList<Subject>? Subjects { get; set; }
        
        [Required]
        public required string Title { get; set; }
    }
}
