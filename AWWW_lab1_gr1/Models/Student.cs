namespace AWWW_lab1_gr1.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string IndexNr { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public string FieldOfStudy { get; set; } = string.Empty;


        public Student() { }

        public Student(int id, string firstName, string lastName, string indexNr, DateTime dateOfBirth, string fieldOfStudy)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            IndexNr = indexNr;
            DateOfBirth = dateOfBirth;
            FieldOfStudy = fieldOfStudy;
        }


    }
}