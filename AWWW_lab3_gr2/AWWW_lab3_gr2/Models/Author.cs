﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWWW_lab3_gr2.Models
{
	public class Author
	{
		public int Id { get; set; }
		public string? FirstName { get; set; }
		public string? LastName { get; set; }

		public virtual ICollection<Article>? Articles { get; set; }
	}
}