namespace SchoolRegister.Model.DataModels
{
    internal class Teacher : User
    {
        public IList<Subject>? Subjects { get; set; }
        public string Title { get; set; } = "master";
    }
}
