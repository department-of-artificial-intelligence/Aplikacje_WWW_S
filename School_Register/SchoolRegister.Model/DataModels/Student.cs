using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolRegister.Model.DataModels
{
    public class Student: User
    {
        public Group Group { get; set; }
        public int? GroupId {get; set;}
        public IList<Grade> Grades {get; set;}
        public Parent Parent { get; set; }
        public int? ParentId {get; set;}
        public double AverageGrade {
            get { return Grades.Sum(g => (double)g.GradeValue) / (Grades.Count()); }
        }

        public IDictionary<string, double> AverageGradePerSubject {
            get { 

                IDictionary<string, double> dict = new Dictionary<string, double>(); 

                var uniqueSubjects = (from grade in Grades 
                                        where grade.Subject == true 
                                        select grade.Subject).Distinct().OrderBy(name => name); 

                foreach(var grade in Grades){
                    dict.Add(grade.Subject.Name, grade.Subject.Grades.Sum(g => (double)g.GradeValue) / (grade.Subject.Grades.Count())); 
                }

                return null; 
             }
        }
        public IDictionary<string, List<GradeScale>> GradesPerSubject {

            get {
                var uniqueSubjects = (from grade in Grades
                                        where grade.Subject == true 
                                        select grade.Subject).Distinct(); 
                IDictionary<string, List<GradeScale>> dict = new Dictionary<string, List<GradeScale>>(); 

                foreach(var grade in Grades){
                    foreach(var subject in uniqueSubjects){
                        IList<GradeScale> list = new List<GradeScale>(); 
                        dict.Add(subject.Name, list.Add(Grades.Where(g => g.Subject.Name == subject.Name).Select(g => g.GradeValue))); 
                    }
                }
                return dict; 
            }
        }
    }
}