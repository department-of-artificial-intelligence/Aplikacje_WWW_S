using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace SchoolRegister.Model.DataModels {
    public class Teacher : User
    {
        //public int Id {get;set;}
        public string Title { get; set; } 
        public virtual IList<Subject> Subjects { get; set; }

        public Teacher() {
            Title = null!;
            Subjects = new List<Subject>();
        }
    }
}