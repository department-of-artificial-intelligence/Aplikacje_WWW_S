namespace SchoolRegister.Model.DataModels
{
    public class Teacher : User
    {
        public IList<Subject> Subjects { get; set; } = new List<Teacher>();
        public string Title { get; set; } = null!;

    }
}
