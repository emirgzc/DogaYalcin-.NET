using EntityLayer.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
	public class Galeri : IEntity
	{
		[Key]
		public int PhotoId { get; set; }
		public string Image { get; set; }
		public DateTime DateImage { get; set; }
		public bool Status { get; set; }
	}
}
