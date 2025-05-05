using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolRegister.Model.DataModels {
    public class Parent : User
    {
        public int Id { get; set; }
        public virtual IList<Student> Students { get; set; }

        public Parent() {
            Students = new List<Student>();
        }
    }
}