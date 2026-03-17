using System;
using System.Collections.Generic;

namespace AWWW_lab1_gr1.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IndexNr { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string FieldOfStudy { get; set; }

        public static List<Student> GetStudents()
        {
            return new List<Student>
            {
                new Student { Id = 1, FirstName = "Jan", LastName = "Kowalski", IndexNr = "12345", DateOfBirth = new DateTime(1995, 5, 15), FieldOfStudy = "IT" },
                new Student { Id = 2, FirstName = "Cristiano", LastName = "Ronaldo", IndexNr = "13370", DateOfBirth = new DateTime(1985, 2, 5), FieldOfStudy = "Science" },
                new Student { Id = 3, FirstName = "Adam", LastName = "Nowak", IndexNr = "54321", DateOfBirth = new DateTime(1999, 1, 9), FieldOfStudy = "Math" }
            };
        }
    }
}