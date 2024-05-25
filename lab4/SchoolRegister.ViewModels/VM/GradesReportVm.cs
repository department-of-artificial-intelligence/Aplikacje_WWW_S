public class GradesReportVm
{
    public int StudentId { get; set; }
    public IEnumerable<GradeVm> Grades { get; set; }
}