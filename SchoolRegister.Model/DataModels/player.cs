using Microsoft.AspNetCore.Identity;
using System;

namespace SchoolRegister.Model.DataModels{
    public class Player{
        public int Id;
        public string FirstName;
        public string LastName;
        public string Country;
        public DateTime BirthDate;
    }
}