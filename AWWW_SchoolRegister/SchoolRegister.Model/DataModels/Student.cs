namespace SchoolRegister.Model.DataModels;

public class Student : User
{
  public Group Group { get; set; }
  public int GroupId { get; set; }
  public IList<Grade> Grades { get; set; }
  public Parent Parent { get; set; }
  public int ParentId { get; set; }

  public double AverageGrades
  {
    get
    {
      double sum = Grades.Sum(x => (int)x.GradeValue);
      return sum / Grades.Count;
    }
  }

  public IDictionary<string, double> AverageGradesPerSubject
  {
    get
    {
      throw new NotImplementedException();
    }
  }

  public IDictionary<string, IList<GradeScale>> GradePerSubject
  {
    get
    {
      throw new NotImplementedException();
    }
  }
}