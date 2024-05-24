﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolRegister.Model.DataModels
{
	public class Parent : User
	{
		public IList<Student> Students { get; set; } = new List<Student>();
	}
}