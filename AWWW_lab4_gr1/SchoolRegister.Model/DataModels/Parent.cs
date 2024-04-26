namespace SchoolRegister.Model.DataModels
{
    internal class Parent : User
    {
        public IList<Student> Students { get; set; } = null!;
    }
}
