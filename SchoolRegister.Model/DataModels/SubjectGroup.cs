using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace SchoolRegister.Model.DataModels {
    public class SubjectGroup
    {
        [ForeignKey("Subject")]
        public int SubjectId { get; set; }
        public virtual Subject Subject { get; set; } 
        [ForeignKey("Group")]
        public int GroupId { get; set; }
        public virtual Group Group { get; set; }

        public SubjectGroup() {
            Subject = null!;
            Group = null!;
        }
    }
}