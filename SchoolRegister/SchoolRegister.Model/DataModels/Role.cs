using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace SchoolRegister.Model.DataModels
{
    public class Role: IdentityRole<int>
    {
        public virtual RoleValue RoleValue {get;set;}
        
        public Role(string name, RoleValue roleValue){
            RoleValue = roleValue;
            Name = name;
        }

        public Role(){}
    }
}