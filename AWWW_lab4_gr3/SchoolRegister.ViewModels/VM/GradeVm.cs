using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SchoolRegister.ViewModels.VM;

public class GradeVm
{
    public int Id { get; set; }
    public DateTime DateOfIssue { get; set; }
    public GradeScale GradeValue { get; set; }
    public virtual Subject? Subject { get; set; }

    public int? SubjectId { get; set; }

    public int? StudentId { get; set; }
    public virtual Student? Student { get; set; }
}
