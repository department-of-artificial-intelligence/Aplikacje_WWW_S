using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace SchoolRegister.Model.DataModels;

public class Student : User
{
    [ForeignKey("Group")]
    public int? GroupId {get; set;}
    public virtual Group? Group {get; set;}

    public virtual IList<Grade>? Grades {get; set;}

    [ForeignKey("Parent")]
    public int? ParentId {get; set;}
    public virtual Parent? Parent {get; set;}

    [NotMapped]
    public double AverageGrade
    {
        get
        {
            if(Grades == null || Grades.Count == 0)
                return 0.0;
            //return Grades.Average(g => (int)g.GradeValue);

            int sum = 0;
            double average = 0.0;
            foreach(var grade in Grades)
            {
                sum += (int)grade.GradeValue;
                average = sum / Grades.Count;
            }
            return average;

        }
    }

    [NotMapped]
    public IDictionary<string, double> AverageGradePerSubject
    {
        get
        {
            if(Grades == null || Grades.Count == 0)
                return new Dictionary<string, double> ();

            // return Grades
            //     .GroupBy(g => g.Subject.Name)
            //     .ToDictionary(
            //         group => group.Key,
            //         group => group.Average(g => (int)g.GradeValue)
            //     );

            Dictionary<string, double> averageGradePerSubject = new();

            foreach(var grade in Grades)
            {
                string subjectName = grade.Subject.Name;

                if(!averageGradePerSubject.ContainsKey(subjectName))
                {
                    averageGradePerSubject[subjectName] = 0;
                }
            }

            Dictionary<string, List<int>> gradesBySubject = new();

            foreach(var grade in Grades)
            {
                string subjectName = grade.Subject.Name;
                int numericGrade = (int)grade.GradeValue;

                if(!gradesBySubject.ContainsKey(subjectName))
                {
                    gradesBySubject[subjectName] = new List<int>();
                }

                gradesBySubject[subjectName].Add(numericGrade);
            }

            foreach(var entry in gradesBySubject)
            {
                string subject = entry.Key;
                List<int> gradesList = entry.Value;

                double average = gradesList.Average();

                averageGradePerSubject[subject] = average;
            }

            return averageGradePerSubject;
        }
    }

    [NotMapped]
    public IDictionary<string, List<GradeScale>> GradesPerSubject
    {
        get
        {

            Dictionary<string, List<GradeScale>> result = new();

            if(Grades == null || Grades.Count == 0)
                return result;
                
            // return Grades
            //     .GroupBy(g => g.Subject.Name)
            //     .ToDictionary(
            //         group => group.Key,
            //         group => group.Select(g => g.GradeValue).ToList()
            //     );

            foreach(var grade in Grades)
            {
                string subjectName = grade.Subject.Name;
                GradeScale gradeScale = grade.GradeValue;

                if(!result.ContainsKey(subjectName))
                {
                    result[subjectName] = new List<GradeScale> ();
                }

                result[subjectName].Add(gradeScale);
            }
        
            return result;
        }
    }

    public Student() {}
}