namespace SchoolRegister.Model.DataModels
{
    public class Subject
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public IList<SubjectGroup> SubjectGroups { get; set; } = new List<SubjectGroup>();
        public Teacher? Teacher { get; set; }
        public int? TeacherId { get; set; }
        public IList<Grade> Grades { get; set; } = new List<Grade>();

    }
}
