namespace SchoolRegister.ViewModels.VM;
public class TeacherVM
{
  public int Id { get; set; }
  public virtual IList<SubjectVm> Subjects { get; set; }
  public String FirstName { get; set; }
  public String LastName { get; set; }
  public String Title { get; set; } = "";
}