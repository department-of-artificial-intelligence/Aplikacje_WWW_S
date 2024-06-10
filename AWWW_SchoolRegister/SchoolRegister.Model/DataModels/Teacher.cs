namespace SchoolRegister.Model.DataModels;

public class Teacher : User
{
  public virtual IList<Subject> Subjects { get; set; }
  public String Title { get; set; } = "";
}