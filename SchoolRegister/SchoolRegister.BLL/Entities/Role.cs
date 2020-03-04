using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolRegister.BLL.Entities
{
    public class Role : IdentityUser<int>
    {
        public Role() { }
        public Role(string name): base(name) { }
    }
}
