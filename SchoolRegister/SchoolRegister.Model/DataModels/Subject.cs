public class Subject
{
    public required int Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }

    public required IList<SubjectGroup> SubjectGroups { get; set; }

    public Teacher? Teacher { get; set; }

    public int? TeacherId { get; set; }

    public required IList<Grade> Grades { get; set; }
}