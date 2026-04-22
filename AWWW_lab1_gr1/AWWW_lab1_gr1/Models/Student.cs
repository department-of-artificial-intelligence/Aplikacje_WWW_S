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

        public static List<Student> GetStudents()
        {
            return new List<Student>
            {
                new Student
                {
                    Id = 1,
                    FirstName = "Radosław",
                    LastName = "Kawa",
                    IndexNr = 138248,
                    DateOfBirth = new DateTime(2003,7,15),
                    FieldOfStudy = "IT"
                },
                new Student
                {
                    Id = 2,
                    FirstName = "Bartłomiej",
                    LastName = "Latocha",
                    IndexNr = 111111,
                    DateOfBirth = new DateTime(2003,5,10),
                    FieldOfStudy = "IT"
                },
                new Student
                {
                    Id = 3,
                    FirstName = "Paweł",
                    LastName = "Sczypior",
                    IndexNr = 321123,
                    DateOfBirth = new DateTime(2003,4,23),
                    FieldOfStudy = "PE"
                }
            };
        }
    }
}
