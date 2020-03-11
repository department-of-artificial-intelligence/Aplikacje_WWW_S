using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolRegister.BLL.Entities
{
    public class Role : IdentityRole<int>
    {
        public Role() { }
        public Role(string name): base(name) { }
    }
}
