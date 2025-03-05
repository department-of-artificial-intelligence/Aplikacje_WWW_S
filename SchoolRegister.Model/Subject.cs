namespace SchoolRegister.Model.DataModels{

    public class Subject{

        public string Desctiption {get; set;}
        public IList<Grade> Grades {get; set;}
        public int Id {get; set;}
        public string Name {get; set;}
   //     public IList<SubjectGroup> SubjectGroups {get; set;}
        public Teacher Teacher {get; set;}


    }


}