using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SchoolRegister.BLL.Entities
{
    public class Grade
    {
        [Key]
        public DateTime DateOfIssue { get; set; }

        public GradeScale GradeValue { get; set; }

        public Subject Subject { get; set; }

        [ForeignKey("Subject")]
        public int SubjectId { get; set; } //! 08/04/2020

    }
}
