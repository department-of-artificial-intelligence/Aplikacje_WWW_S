public class Group
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required IList<Student> Students { get; set; }
    public required IList<SubjectGroup> SubjectGroups { get; set; }
}