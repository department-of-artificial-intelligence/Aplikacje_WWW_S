using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolRegister.Model.DataModels;

public class Student : User
{
  public virtual Group? Group { get; set; }
  public int? GroupId { get; set; }
  public virtual IList<Grade> Grades { get; set; }
  public virtual Parent? Parent { get; set; }
  public int? ParentId { get; set; }

  [NotMapped]
  public double AverageGrades
  {
    get
    {
      double sum = Grades.Sum(x => (int)x.GradeValue);
      return sum / Grades.Count;
    }
  }

  [NotMapped]
  public IDictionary<string, double> AverageGradesPerSubject
  {
    get
    {
      throw new NotImplementedException();
    }
  }

  [NotMapped]
  public IDictionary<string, IList<GradeScale>> GradePerSubject
  {
    get
    {
      throw new NotImplementedException();
    }
  }
}