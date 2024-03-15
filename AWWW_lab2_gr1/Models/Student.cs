namespace AWWW_lab1_gr1.Models;
public class Student
{
    public int Id {get; set;}
    public string FirstName {get; set;}
    public string SecondName {get; set;}
    public int IndexNumber {get; set;}
    public DateTime DateOfBirth {get; set;}
    public string FieldOfSttudy {get; set;}

    public Student(int Id, string FirstName, string SecondName, int IndexNumber, DateTime DateOfBirth, string FieldOfSttudy)
    {
        this.Id = Id;
        this.FirstName = FirstName;
        this.SecondName = SecondName;
        this.IndexNumber = IndexNumber;
        this.DateOfBirth = DateOfBirth;
        this.FieldOfSttudy = FieldOfSttudy;
  }
}