namespace SchoolRegister.Model
{
    public class Parent : User
    {
        public IList<Student> Students { get; set; } = null!;
    }
}