using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace SchoolRegister.Model.DataModels {
    public class SubjectGroup
    {
        public int SubjectId { get; set; }
        public Subject Subject { get; set; } = null!;
        public int GroupId { get; set; }
        public Group Group { get; set; } = null!;
    }
}