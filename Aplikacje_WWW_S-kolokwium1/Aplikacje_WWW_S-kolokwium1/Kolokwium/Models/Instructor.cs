namespace Kolokwium.Models
{
    public class Instructor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }  
        public List<Course> Courses { get; set; } = new(); //1 Instructor : N Kursow
    }
}
