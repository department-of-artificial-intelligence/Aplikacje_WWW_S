namespace SchoolRegister.Model.DataModels
{
    internal class Student : User
    {
        public Group Group { get; set; } = null!;
        public int GroupId { get; set; }
        public IList<Grade>? Grades { get; set; }
        public Parent Parent { get; set; } = null!;
        public int ParentId { get; set; }
        public double AverageGrade { get; }
        public IDictionary<string, List<GradeScale>> GradesPerSubject { get; } = null!;
    }
}
