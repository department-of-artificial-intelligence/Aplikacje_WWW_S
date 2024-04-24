using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolRegister.Model.DataModels
{
    public class Student : User
    {
        public virtual Group Group { get; set; }
        public int GroupId { get; set; }
        public virtual IList<Grade> Grades { get; set; }
        public virtual Parent Parent { get; set; }
        public int ParentId { get; set; }
        public double AverageGrade { get { return Grades!.Count() == 0 ? 0 : Grades!.Sum(x => Convert.ToInt32(x)) / Grades!.Count(); } }
        public IDictionary<string, double> AverageGradePerSubject
        {
            get
            {
                var dict = new Dictionary<string, double>();

                foreach (var g in Grades!)
                {
                    if (!dict.ContainsKey(g.Subject.Name))
                    {
                        double avg = Grades.Where(gr => gr.Subject.Name == g.Subject.Name).Sum(gr => (int)gr.GradeValue) / (double)Grades.Count(gr => gr.Subject.Name == g.Subject.Name);
                        dict.Add(g.Subject.Name, avg);
                    }
                }

                return dict;
            }
        }
        public IDictionary<string, List<GradeScale>> GradesPerSubject
        {
            get
            {
                var dict = new Dictionary<string, List<GradeScale>>();

                foreach (var g in Grades!)
                {
                    if (!dict.ContainsKey(g.Subject.Name))
                    {
                        var gradeList = Grades.Where(gr => gr.Subject.Name == g.Subject.Name).Select(gr => gr.GradeValue).ToList();
                        dict.Add(g.Subject.Name, gradeList);
                    }
                }

                return dict;
            }
        }
        public Student()
        {

        }
    }
}