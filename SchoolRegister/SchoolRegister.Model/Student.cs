namespace SchoolRegister.Model
{
    public class Student : User
    {
        public int GroupId { get; set; }
        public Group Group { get; set; } = null!;

        public IList<Grade>? Grades { get; set; }

        public int ParentId { get; set; }
        public Parent Parent { get; set; } = null!;

        public double AverageGrade { get; }
        public IDictionary<string, double>? AverageGradePerSubject { get; }
        public IDictionary<string, List<GradeScale>>? GradesPerSubject { get; }
    }
}