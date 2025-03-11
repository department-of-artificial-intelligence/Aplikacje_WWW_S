using System;
using System.Collections.Generic;

namespace AWWW_lab1_gr3.Models
{
    public static class StudentRepository
    {
         public static List<Student> Students { get; } = new List<Student>
         {
            new Student { Id = 1, FirstName = "John", LastName = "Doe", IndexNr = 12345, DateOfBirth = new DateTime(2000,1,1), FieldOfStudy = "Computer Science" },
            new Student { Id = 2, FirstName = "Jane", LastName = "Doe", IndexNr = 54321, DateOfBirth = new DateTime(2001,2,2), FieldOfStudy = "Computer Science" },
            new Student { Id = 3, FirstName = "Alice", LastName = "Smith", IndexNr = 67890, DateOfBirth = new DateTime(2002,3,3), FieldOfStudy = "Computer Science" }
         };
    }
}
