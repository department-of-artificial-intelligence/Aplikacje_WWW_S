using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolRegister.Model.DataModels
{
    public class SubjectGroup
    {
        public virtual Subject Subject { get; set; } = default!;
        [ForeignKey("Subject")]
        public int SubjectId { get; set; }
        public virtual Group Group { get; set; } = default!;
        [ForeignKey("Group")]
        public int GroupId { get; set; }
    }
}