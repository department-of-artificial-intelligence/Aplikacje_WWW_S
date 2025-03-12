namespace AWWW_lab1_gr3.Models
{
    public static class StudentRepository
    {
        public static List<Student> students { get; } = new List<Student>
        {
            new Student { Id = 1, FirstName = "Jan", LastName = "Kowalski", IndexNr = 132550, DateOfBirth = DateTime.Now, FieldOfStudy = "IT"},
            new Student { Id = 2, FirstName = "Adam", LastName = "Nowak", IndexNr = 435412, DateOfBirth = DateTime.Now, FieldOfStudy = "Chemistry"},
            new Student { Id = 3, FirstName = "Ada", LastName = "Krowa", IndexNr = 556312, DateOfBirth = DateTime.Now, FieldOfStudy = "Biology"}
        };
    }
}