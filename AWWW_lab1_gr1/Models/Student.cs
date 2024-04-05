using System.Net.NetworkInformation;

namespace AWWW_lab1_gr1.Models{
    public class Student
    {
        public int ID{get; set;}
        public required string FirstName{get;set;}
        public required string LastName{get;set;}
        public int IndexNr{get;set;}
        public DateTime DateOfBirth{get;set;}
        public required string FieldOfStudy{get;set;}
    }
}