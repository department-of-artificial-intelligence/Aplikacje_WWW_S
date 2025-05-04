using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace SchoolRegister.Model.DataModels {
    public class Parent
    {
        public int Id { get; set; }
        public IList<Student> Students { get; set; } = new List<Student>();
    }
}