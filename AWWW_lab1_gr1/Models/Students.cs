using System.ComponentModel.DataAnnotations;

namespace AWWW_lab1_gr1.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int IndexNr { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string FieldOfStudy { get; set; }
    }
}