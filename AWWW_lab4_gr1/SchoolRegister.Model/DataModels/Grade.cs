namespace SchoolRegister.Model.DataModels
{
    public class Grade
    {
        public int Id { get; set; }
        public DateTime DateOfIssue { get; set; }
        public GradeScale GradeValue { get; set; }
        public virtual Subject Subject { get; set; } = null!;
        public int SubjectId { get; set; }
        public int StudentId { get; set; }
        public virtual Student Student { get; set; } = null!;
    }
}
