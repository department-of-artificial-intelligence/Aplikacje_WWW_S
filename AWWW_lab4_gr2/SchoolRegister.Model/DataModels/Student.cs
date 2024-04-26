public class Student{
    public Group? Group { get; set; }
    public int? GroupId { get; set; }
    public IList<Grade> Grades { get; set; } = new List<Grade>();
    public Parent? Parent { get; set; }
    public int? ParentId { get; set; }

}