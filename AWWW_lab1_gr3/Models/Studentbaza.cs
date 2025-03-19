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
                FirstName = "Kamil",
                LastName = "Garus",
                IndexNr = 136534,
                DateOfBirth = DateTime.Today,
                FieldOfStudy = "Informatyka"
            },
            new Student{
                Id = 2,
                FirstName = "Michał",
                LastName = "Nowak",
                IndexNr = 202013,
                DateOfBirth = new DateTime(2002, 5, 12),
                FieldOfStudy = "Matematyka"
            },
            new Student{
                Id = 3,
                FirstName = "Anna",
                LastName = "Kowalska",
                IndexNr = 215604,
                DateOfBirth = new DateTime(2000, 8, 22),
                FieldOfStudy = "Biotechnologia"
            },
            new Student{
                Id = 4,
                FirstName = "Karolina",
                LastName = "Nowak",
                IndexNr = 220743,
                DateOfBirth = new DateTime(1998, 11, 3),
                FieldOfStudy = "Psychologia"
            }
        };
    }
}