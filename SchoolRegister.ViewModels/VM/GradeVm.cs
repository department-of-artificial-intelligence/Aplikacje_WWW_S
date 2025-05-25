using System.ComponentModel.DataAnnotations;
using SchoolRegister.Model;
using SchoolRegister.Model.DataModels;

namespace SchoolRegister.ViewModels.VM;

public class AddGradeToStudentVm
{
    public int? Id { get; set; }

    [Required]
    public int TeacherId { get; set; }

    [Required]
    public GradeScale GradeValue { get; set; }

    [Required]
    public int SubjectId { get; set; }

    [Required]
    public int StudentId { get; set; }
}

public class GetGradesReportVm
{
    public int StudentId { get; set; }
    public int GetterUserId { get; set; }
}

public class GradesReportVm
{
    public int StudentId { get; set; }
    public IList<GradeVm> Grades { get; set; }
}

public class GradeVm
{
    public int Id { get; set; }
    public DateTime? DateOfIssue { get; set; }
    public GradeScale GradeValue { get; set; }
    public int? SubjectId { get; set; }
    public int? StudentId { get; set; }
    public int? ParentId { get; set; }
}
