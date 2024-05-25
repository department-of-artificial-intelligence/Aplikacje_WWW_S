public class SubjectGroup
{
    public virtual Subject Subject { get; set; }

    public required int SubjectId { get; set; }

    public virtual Group Group { get; set; }

    public required int GroupId { get; set; }
}