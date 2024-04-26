public class Grade
{
    public required DateTime DateOfIssue { get; set; }

    public required GradeScale GradeValue { get; set; }

    public required Subject Subject { get; set; }

    public required int SubjectId { get; set; }

    public required Student Student { get; set; }

    public required int StudentId { get; set; }

}