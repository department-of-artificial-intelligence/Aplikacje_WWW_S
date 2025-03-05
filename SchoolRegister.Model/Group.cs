namespace SchoolRegister.Model.DataModels{

    public class Group{

        public int Id {get; set;}
        public string Name {get; set;}

        public IList<Student> Students;
       // public IList<SubjectGroup> SubjectGroups {get; set;}

    }


}