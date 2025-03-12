using Microsoft.AspNetCore.Identity;
using System;

namespace SchoolRegister.Model.DataModels{
    public class Team{
        public int Id;
        public string Name;
        public string Country;
        public string City;
        public DateTime FoundingDate;
    }
}