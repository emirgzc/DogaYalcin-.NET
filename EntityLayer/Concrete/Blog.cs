﻿using EntityLayer.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
	public class Blog : IEntity
	{
		[Key]
		public int BlogId { get; set; }
		public string Image { get; set; }
		public string Title { get; set; }
		public string Desc { get; set; }		
		public DateTime BlogDate { get; set; }
		public bool Status { get; set; }
	}
}
