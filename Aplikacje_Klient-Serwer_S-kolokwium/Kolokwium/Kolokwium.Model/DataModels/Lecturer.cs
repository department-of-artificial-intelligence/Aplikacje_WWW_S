using Kolokwium.Model.DataModels;

public class Lecturer : User
{
    public string AcademicTitle { get; set; }
    public virtual ICollection<Student> Students { get; set; }
}