using System.Net.NetworkInformation;

namespace AWWW_lab1_gr5.Models{
    public class Student{
        public int Id {get;set;}
        public string Title {get;set;} = null!;
        public string FirstName {get;set;} = null!;
        public string LastName {get;set;} = null!;
        public int IndexNr {get;set;}
        public DateTime DateOfBirth {get;set;}
        public string FieldOfStudy {get;set;} = null!;
    }
}