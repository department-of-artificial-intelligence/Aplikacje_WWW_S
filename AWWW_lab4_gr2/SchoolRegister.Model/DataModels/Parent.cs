namespace SchoolRegister.Model.DataModels;

public class Parent: User
{
   public Parent() { }
    public virtual IList<Student>? Students {get; set;}
    
}
