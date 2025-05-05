namespace SchoolRegister.Model.DataModels;

public class Teacher : User
{
    public string Title {get; set;} = null!;

    public IList<Subject>? Subjects {get; set;}

    public Teacher() {}
}