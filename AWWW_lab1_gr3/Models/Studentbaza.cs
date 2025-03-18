using System;
using System.Collections.Generic;

namespace AWWW_lab1_gr3.Models
{
    public static class StudentRepository
    {
        public static List<Student> Students { get; } = new List<Student>
        {
            new Student{
                Id = 1,
                FirstName = "Adrian",
                LastName = "Sarna",
                IndexNr = 136541,
                DateOfBirth = DateTime.Today,
                FieldOfStudy = "Zarządzanie"
            },
            new Student{
                Id = 2,
                FirstName = "Marceli",
                LastName = "Nowak",
                IndexNr = 200123,
                DateOfBirth = new DateTime(2000, 5, 12),
                FieldOfStudy = "Filologia Angielska"
            },
            new Student{
                Id = 3,
                FirstName = "Maciek",
                LastName = "Kurek",
                IndexNr = 210456,
                DateOfBirth = new DateTime(2001, 8, 22),
                FieldOfStudy = "Ludologia"
            },
            new Student{
                Id = 4,
                FirstName = "Kamil",
                LastName = "Zdun",
                IndexNr = 220789,
                DateOfBirth = new DateTime(1999, 11, 3),
                FieldOfStudy = "Blacharstwo"
            }
        };
    }
}
