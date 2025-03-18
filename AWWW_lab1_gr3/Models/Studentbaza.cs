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
                FirstName = "Natalia",
                LastName = "Kowalska",
                IndexNr = 112233,
                DateOfBirth = new DateTime(1998, 1, 15),
                FieldOfStudy = "Informatyka"
            },
            new Student{
                Id = 2,
                FirstName = "Piotr",
                LastName = "Wójcik",
                IndexNr = 223344,
                DateOfBirth = new DateTime(2000, 4, 25),
                FieldOfStudy = "Matematyka"
            },
            new Student{
                Id = 3,
                FirstName = "Alicja",
                LastName = "Zielinska",
                IndexNr = 334455,
                DateOfBirth = new DateTime(1997, 9, 7),
                FieldOfStudy = "Biotechnologia"
            },
            new Student{
                Id = 4,
                FirstName = "Szymon",
                LastName = "Lewandowski",
                IndexNr = 445566,
                DateOfBirth = new DateTime(1995, 12, 14),
                FieldOfStudy = "Psychologia"
            }
        };
    }
}
