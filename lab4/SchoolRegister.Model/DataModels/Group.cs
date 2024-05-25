public class Group
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public virtual IList<Student> Students { get; set; }
    public virtual IList<SubjectGroup> SubjectGroups { get; set; }
}