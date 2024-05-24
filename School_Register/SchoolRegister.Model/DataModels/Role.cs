using System;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolRegister.Model.DataModels
{
    public class Role:IdentityRole<int>
    {
        RoleValue RoleValue{get;set;}
        public Role(){}
        public Role(string name, RoleValue roleValue){
            
        }
    }
}