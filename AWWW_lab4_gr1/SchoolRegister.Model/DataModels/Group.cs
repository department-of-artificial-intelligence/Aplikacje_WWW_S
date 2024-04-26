namespace SchoolRegister.Model.DataModels
{
    internal class Group
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public IList<Student>? Students { get; set; }
        public IList<SubjectGroup>? SubjectGroups { get; set; }
    }
}
