namespace SchoolRegister.Model.DataModels
{
    public class Subject
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;

        public IList<SubjectGroup> SubjectGroups { get; set; } = new List<SubjectGroup>();

        public int TeacherId { get; set; }
		public Teacher Teacher { get; set; } = null!;

        public IList<Grade> Grades { get; set; } = new List<Grade>();

    }
}