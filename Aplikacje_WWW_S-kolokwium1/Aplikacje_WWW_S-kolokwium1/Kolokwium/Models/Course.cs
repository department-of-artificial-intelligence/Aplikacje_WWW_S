namespace Kolokwium.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; } 
        public int InstructorId { get; set; }// jesli jest to 
        public Instructor Instructor { get; set; } // to musi tez byc to
        public List<Student> Students { get; set; } = new();
    }
}
