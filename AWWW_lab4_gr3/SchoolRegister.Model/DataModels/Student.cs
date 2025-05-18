using System;
using System.Collections.Generic;
using System.Linq; 

namespace SchoolRegister.Model.DataModels
{
    public class Student : User
    {
        public int? GroupId { get; set; }
        public virtual Group? Group { get; set; }

        public int? ParentId { get; set; }
        public virtual Parent? Parent { get; set; }

        public virtual IList<Grade>? Grades { get; set; }

        public Student()
        {
            Grades = new List<Grade>();
        }


        public Dictionary<string, double> AverageGradePerSubject
        {
            get
            {
                if (Grades == null || !Grades.Any())
                    return new Dictionary<string, double>();

                return Grades
                    .Where(g => g.Subject != null) 
                    .GroupBy(g => g.Subject!.Name) 
                    .ToDictionary(
                        g => g.Key,
                        g => g.Average(grade => (int)grade.GradeValue) 
                    );
            }
        }

        public double AverageGrade
        {
            get
            {
                if (Grades == null || !Grades.Any())
                    return 0.0;

                return Grades.Average(g => (int)g.GradeValue);
            }
        }

        public Dictionary<string, List<GradeScale>> GradesPerSubject
        {
            get
            {
                if (Grades == null || !Grades.Any())
                    return new Dictionary<string, List<GradeScale>>();

                return Grades
                    .Where(g => g.Subject != null) 
                    .GroupBy(g => g.Subject!.Name)
                    .ToDictionary(
                        g => g.Key,
                        g => g.Select(grade => grade.GradeValue).ToList()
                    );
            }
        }
    }
}