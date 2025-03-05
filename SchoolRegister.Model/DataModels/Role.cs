using System;


namespace SchoolRegister.Model.DataModels
{
    public class Role
    {
        public RoleValue RoleValue { get; set; }

        public Role(){
            RoleValue = new RoleValue();
        }

        public Role(string name, RoleValue roleValue){
            RoleValue = roleValue;
        }
    }
}