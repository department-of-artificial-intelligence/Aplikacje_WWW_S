public class Group{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public IList<SubjectGroup> SubjectGroups { get; set; } = new List<SubjectGroup>();
    public IList<Student> Students { get; set; } = new List<Student>();

}