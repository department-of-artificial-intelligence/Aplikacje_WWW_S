using Microsoft.AspNetCore.Identity;
using System;

namespace SchoolRegister.Model.DataModels2 {

	public class User : IdentityUser<int> {

		public string FirstName { get; set; }

		public string LastName { get; set; }

		public DateTime RegistrationDate { get; set; }


	}


}