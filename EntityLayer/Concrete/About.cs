using EntityLayer.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
	public class About : IEntity
	{
		[Key]
		public int AboutId { get; set; }
		public string Title { get; set; }
		public string Desc { get; set; }
	}
}
