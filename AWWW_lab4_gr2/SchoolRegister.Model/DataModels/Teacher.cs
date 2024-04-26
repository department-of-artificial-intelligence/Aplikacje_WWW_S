using System.Security.Cryptography.X509Certificates;

namespace SchoolRegister.Model.DataModels;

public class Teacher: User
{
    public virtual IList<Subject>? Subjects {get; set;}
    public string? Title {get; set;}
    
}
