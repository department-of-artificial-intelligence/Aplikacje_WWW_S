namespace AWWW_lab1_gr2.Models{
    public class Student{
        public int ID{get;set;}
        public String FirstName{get;set;}
        public String LastName{get;set;}
        public int IndexNr{get;set;}
        public DateTime DateOfBirth{get;set;}
        public String FieldOfStudy{get;set;}
        public Student(){
            ID = 1;
            FirstName = "";
            LastName = "";
            IndexNr = 1;
            DateOfBirth = DateTime.MinValue;
            FieldOfStudy = "";
        }
    }
}