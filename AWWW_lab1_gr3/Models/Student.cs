using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWWW_lab1_gr3.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string IndexNumber { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }
        public string FieldOfStudy { get; set; } = null!;
    }
}