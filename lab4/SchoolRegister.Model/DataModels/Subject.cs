public class Subject
{
    public required int Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }

    public virtual IList<SubjectGroup> SubjectGroups { get; set; }

    public virtual Teacher? Teacher { get; set; }

    public int? TeacherId { get; set; }

    public virtual IList<Grade> Grades { get; set; }
}