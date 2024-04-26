namespace SchoolRegister.Model.DataModels
{
    public class Teacher : User
    {
        public IList<Subject> Subjects { get; set; } = new List<Subject>();
        public string Title { get; set; } = null!;

    }
}
