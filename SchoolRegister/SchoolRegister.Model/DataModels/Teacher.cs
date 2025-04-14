public class Teacher {
    public IList<Subject> Subjects { get; set; }
    public string Title { get; set; }
    public Teacher(IList<Subject> subjects) {}
}