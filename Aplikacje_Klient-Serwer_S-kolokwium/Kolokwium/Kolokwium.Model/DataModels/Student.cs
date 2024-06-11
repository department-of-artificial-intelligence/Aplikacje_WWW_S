using Kolokwium.Model.DataModels;

public class Student : User
{
    public int GroupId { get; set; }

    public virtual Lecturer Lecturer { get; set; }

    public int LecturerId { get; set; }
}