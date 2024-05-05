namespace SchoolRegister.Model.DataModels
{
    internal class SubjectGroup
    {
        public Subject Subject { get; set; } = null!;
        public int SubjectId { get; set; }
        public Group Group { get; set; } = null!;
        public int GroupId { get; set; }
    }
}
