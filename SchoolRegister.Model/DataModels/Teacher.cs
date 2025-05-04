using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace SchoolRegister.Model.DataModels {
    public class Teacher
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public IList<Subject> Subjects { get; set; } = new List<Subject>();
    }
}